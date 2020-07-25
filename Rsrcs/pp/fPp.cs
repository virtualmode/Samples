using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace pp
{
	/// <summary>
	/// Основное окно редактора.
	/// </summary>
    public partial class fPp : Form
	{
		#region "Свойства и поля класса"

		private Boolean _cbPositionFlag; // Флаг для работы с событиями cbPosition.
		private Boolean _pgPpFlag; // Флаг отключения отображения свойств объекта.
		private Boolean _cbHistoryEdited; // Был ли изменен текст.
		private int _cbHistoryEditedIndex; // Редактируемый элемент.

		#endregion

		#region "Работа с базой данных"

		/// <summary>
		/// Инициализация формы по умолчанию.
		/// </summary>
		public fPp()
		{
			InitializeComponent();
			_cbPositionFlag = false;
			_pgPpFlag = false;
			_cbHistoryEdited = false;
			_cbHistoryEditedIndex = -1;
		}

		/// <summary>
		/// Настройка редактора перед открытием.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fPp_Load(object sender, EventArgs e)
		{
			// Загрузка настроек программы:
			cPp.settings = cSettings.deserialize();

			// Установка загруженных настроек:
			DesktopBounds = cPp.settings.fPpRectangle;
			if (cPp.settings.fPpMaximized)
			{
				WindowState = FormWindowState.Maximized;
			}
			scPp.SplitterDistance = scPp.Width - cPp.settings.propertiesWidth;

			// Загрузка файла с расходом:
			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
			{
				cPp.db = cDb.open(args[1]); // Открытие существующего расхода.
			}
			else
			{
				cPp.db = new cDb(); // Создание пустого расхода.
			}

			// Изменение интерфейса (общее):
			afterOpen();

			// Изменение интерфейса (страница со справкой):
			pbAuthor.Left = pbAuthor.Top = 10;
			lHelp.Top = pbAuthor.Top - 3;
			lHelp.Left = pbAuthor.Right + 5;
			tbHelp.Top = lHelp.Bottom + 10;
			tbHelp.Left = lHelp.Left + 5;
			tbHelp.Width = pHelp.Width - tbHelp.Left - 10;
			tbHelp.Height = pHelp.Height - tbHelp.Top - 10;
		}

		private void fPp_Shown(object sender, EventArgs e)
		{
			cPp.flushMemory();
		}

		/// <summary>
		/// Обновляет интерфейс в соответствии с данными.
		/// </summary>
		private void synchronizeDb(Boolean clear, int selectedIndex = -1)
		{
			// Обработка записей:
			int j = 0;
			if (clear)
			{
				lvPp.Visible = false;
				lvPp.Items.Clear(); // Очищаем данные.
				for (int i = 0; i < cPp.db.list.Count; i++)
				{
					if (find(cPp.db.getText(i), cbSearch.Text))
					{
						lvPp.Items.Add("");
						updateRecord(lvPp.Items[j], i);
						j++;
					}
				}
				lvPp.Visible = true;
			}
			else
			{
				for (int i = 0; i < lvPp.Items.Count; i++) updateRecord(lvPp.Items[i], (int)lvPp.Items[i].Tag);
			}

			// Установка предустановленных значений для поиска:
			if (!tsbReport.Checked)
			{
				cbSearch.Items.Clear();
				if (tsbSoldiers.Checked == true)
				{
					cbSearch.Items.Add("");
					foreach (cTask t in cPp.db.tasks.list)
					{
						cbSearch.Items.Add(t.name);
					}
				}
			}

			// Установка истории:
			_pgPpFlag = true; // Не запускать событие на изменение cbHistory.SelectedIndex.
			cbHistory.Items.Clear();
			cbHistory.Items.Add("(Очистить)");
			cbHistory.Items.Add("(Новая запись)");
			for (int i = 0; i < cPp.db.soldiers.records.Count; i++)
			{
				cbHistory.Items.Add(cPp.db.soldiers.records[i].date.ToShortDateString());
			}
			cbHistory.SelectedIndex = cPp.db.soldiers.recordIndex + 2; //cbHistory.Items.Count - 1;
			_pgPpFlag = false;

			// Изменение интерфейса:
			updateTabs();
			updateCaption();
			fPp_SizeChanged(null, null); // Позиционирование элементов.
			

			// Дополнительное выделение:
			if (selectedIndex > -1)
			{
				if (0 <= selectedIndex && selectedIndex < lvPp.Items.Count) lvPp.Items[selectedIndex].Selected = true; else pgPp.SelectedObject = null;
			}
		}

		/// <summary>
		/// Метод закрытия редактора.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		/// <summary>
		/// Сохраняет измененные данные по необходимости.
		/// </summary>
		/// <returns>Возвращает false - данные не сохранялись, true - сохранение произведено, либо пользователь отменил сохранение.</returns>
		private Boolean processUnsavedData()
		{
			if (cPp.db.changed) // Есть несохраненные данные.
			{
				switch (MessageBox.Show(cDb.savePromt, cPp.name, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information))
				{
					case DialogResult.Yes:
						return cPp.db.save(); // Сохранение.
					case DialogResult.Cancel:
						return false; // Отмена операции. Данные нужны, но сохранение пока не требуется.
					default: // Сохранение не требуется.
						break;
				}
			}
			return true; // Все прошло успешно. Данные сохранены.
		}

		/// <summary>
		/// Закрытие окна, сохранение настроек и базы данных.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fPp_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (processUnsavedData() == true)
			{
				if (WindowState == FormWindowState.Maximized)
				{
					cPp.settings.fPpMaximized = true;
				}
				else
				{
					cPp.settings.fPpMaximized = false;
					cPp.settings.fPpRectangle = DesktopBounds; // Границы сохраняем, если окно не раскрыто на весь экран.
				}
				cPp.settings.propertiesWidth = scPp.Width - scPp.SplitterDistance;//scpp.Panel2.Width + ;
				cSettings.serialize(cPp.settings);
			}
			else
			{
				e.Cancel = true;
			}
		}

		/// <summary>
		/// Метод создания новой базы с расходом.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mCreate_Click(object sender, EventArgs e)
		{
			if (processUnsavedData() == true)
			{
				cPp.db = new cDb();
				synchronizeDb(true);
				tsbSoldiers_Click(null, null);
				cPp.flushMemory(); // Принудительное освобождение памяти.
			}
		}

		/// <summary>
		/// Метод открытия файла с расходом.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mOpen_Click(object sender, EventArgs e)
		{
			if (processUnsavedData() == true) // Если требуется, сохраняем данные.
			{
				cDb db = cDb.open();
				if (db != null)
				{
					cPp.db = db;
					afterOpen();
				}
			}
		}

		/// <summary>
		/// Предпросмотр.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tsbPreview_Click(object sender, EventArgs e)
		{
			wbReport.ShowPrintPreviewDialog();
		}

		/// <summary>
		/// Инициализация открытых ранее данных.
		/// </summary>
		private void afterOpen()
		{
			// Ведение истории:
			int lastRecordIndex = cPp.db.soldiers.records.Count - 1;
			if (cPp.db.soldiers.records[lastRecordIndex].date.Date < DateTime.Now.Date) // Сегодня новое число. Создаем копию личного состава для ведения истории:
			{
				cPp.db.soldiers.addRecord(ObjectCloner.DeepClone(cPp.db.soldiers.records[lastRecordIndex]));
				lastRecordIndex++; // Записей стало на одну больше.
				cPp.db.changed = true; // База данных была изменена.
			}

			// Изменение интерфейса:
			cPp.db.soldiers.recordIndex = lastRecordIndex;
			synchronizeDb(true);
			tsbSoldiers_Click(null, null);
			cPp.flushMemory(); // Принудительное освобождение памяти.
		}

		/// <summary>
		/// Метод сохранения расхода в имеющийся файл.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mSave_Click(object sender, EventArgs e)
		{
			if (cPp.db.save())
			{
				updateCaption();
				cPp.flushMemory(); // Принудительное освобождение памяти.
			}
		}

		/// <summary>
		/// Метод сохранения расхода в новый файл.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mSaveAs_Click(object sender, EventArgs e)
		{
			if (cPp.db.saveAs())
			{
				updateCaption();
				cPp.flushMemory(); // Принудительное освобождение памяти.
			}
		}

		#endregion

		#region "Работа с интерфейсом"

		/// <summary>
		/// Изменение интерфейса при перемещении сплиттера.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void scPp_SplitterMoved(object sender, SplitterEventArgs e)
        {
			fPp_SizeChanged(null, null); // Позиционирование элементов.
            pgPp.Focus();
        }

		/// <summary>
		/// Метод выравнивания компонентов при изменении размеров формы.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fPp_SizeChanged(object sender, EventArgs e)
		{
			if (pList.Visible == true) // Обрабатываем, если элементы того требуют:
			{
				tsTools.CanOverflow = false;
				cbSearch.Width = scPp.Panel1.Width - lSearch.Width - 10;
				cbHistory.Width = scPp.Panel2.Width - lHistory.Width - 10;
				lvColumn.Width = lvPp.ClientSize.Width - 5;
				tsTools.CanOverflow = true;
			}
		}

		/// <summary>
		/// Изменение заголовка в соответствии с состоянием данных.
		/// </summary>
		public void updateCaption()
		{
			String star = cPp.db.changed ? "*" : "";
			if (String.IsNullOrEmpty(cPp.db.savedFile))
			{
				Text = String.Format("Без названия{0} - {1}", star, cPp.name);
			}
			else
			{
				Text = String.Format("{0}{1} - {2}", Path.GetFileNameWithoutExtension(cPp.db.savedFile), star, cPp.name);
			}
		}

		/// <summary>
		/// Метод обновления надписей на вкладках.
		/// </summary>
		private void updateTabs()
		{
			tsbSoldiers.Text = String.Format("Личный состав - {0} чел.", cPp.db.soldiers.list.Count);
			tsbTasks.Text = String.Format("Задачи - {0} шт.", cPp.db.tasks.list.Count);
			tsbWeapons.Text = String.Format("Оружие - {0} ед.", cPp.db.weapons.list.Count);
			tsbMachines.Text = String.Format("Техника - {0} ед.", cPp.db.machines.list.Count);
			tsbPaths.Text = String.Format("Путевые листы - {0} шт.", cPp.db.paths.list.Count);
		}

		/// <summary>
		/// Изменяет элемент списка в соответствии с записью в базе данных.
		/// </summary>
		/// <param name="lvi"></param>
		/// <param name="index"></param>
		private void updateRecord(ListViewItem lvi, int index)
		{
			lvi.Tag = index;
			lvi.Text = cPp.db.getText(index);
			lvi.BackColor = cPp.db.getColor(index);
			lvi.ForeColor = cPp.db.getTextColor(index);
			lvi.Font = cPp.db.getFont(index);
		}

		#endregion

		#region "Редактирование записей"

		/// <summary>
		/// Выбор редактируемых объектов.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lvPp_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_pgPpFlag == false) // Не всегда обновлять информацию (например не обновлять при удалении диапазона элементов).
			{
				if (lvPp.SelectedItems.Count > 0)
				{
					// Создание массива объектов:
					Object[] objs = new Object[lvPp.SelectedItems.Count];
					for (int i = 0; i < objs.Length; i++)
					{
						objs[i] = cPp.db.getObject((int)lvPp.SelectedItems[i].Tag);
					}
					// Выбор объектов:
					pgPp.SelectedObjects = objs;
				}
				else
				{
					pgPp.SelectedObject = null;
				}
			}
		}

		/// <summary>
		/// Данные были изменены.
		/// </summary>
		/// <param name="s"></param>
		/// <param name="e"></param>
		private void pgPp_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
		{
			if (e.ChangedItem.PropertyDescriptor.SerializationVisibility == DesignerSerializationVisibility.Visible)
			{
				cPp.db.changed = true;
				synchronizeDb(false);
			}
			cbSearch_SelectedIndexChanged(null, null); // Перерисовываем отчёт.
		}

		/// <summary>
		/// Добавление новой записи в список.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mAdd_Click(object sender, EventArgs e)
		{
			_pgPpFlag = true;
			// Добавление записи:
			lvPp.Items.Add("").Tag = cPp.db.list.Count;
			cPp.db.add();
			cPp.db.changed = true;
			synchronizeDb(false);
			_pgPpFlag = false;
		}

		/// <summary>
		/// Метод удаления записи из списка.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mDelete_Click(object sender, EventArgs e)
		{
			if (lvPp.SelectedItems.Count > 0)
			{
				_pgPpFlag = true;
				int selectedRow = lvPp.SelectedItems[0].Index; // После удаления оставляем курсор на текущей записи.
				// Удаление из базы данных:
				int i = 0, k = 0;
				while (i < lvPp.Items.Count)
				{
					if (lvPp.Items[i].Selected)
					{
						cPp.db.remove((int)lvPp.Items[i].Tag - k);
						lvPp.Items.RemoveAt(i);
						k++;
					}
					else
					{
						lvPp.Items[i].Tag = (int)lvPp.Items[i].Tag - k;
						i++;
					}
				}
				_pgPpFlag = false;
				// Обновление списка:
				cPp.db.changed = true;
				synchronizeDb(false, selectedRow);
			}
		}

		/// <summary>
		/// Метод настройки контекстного меню списка.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmsPp_Opening(object sender, CancelEventArgs e)
		{
			if (lvPp.SelectedItems.Count > 0)
			{
				// Отображение допустимых позиций для записи:
				_cbPositionFlag = true;
				cbPosition.Items.Clear();
				for (int i = 0; i < cPp.db.list.Count; i++)
				{
					cbPosition.Items.Add(String.Format("№ {0}", i + 1));
				}
				cbPosition.SelectedIndex = (int)lvPp.SelectedItems[0].Tag;
				_cbPositionFlag = false;
				// Отображение дополнительных пунктов меню:
				cbPosition.Visible = true;
				mDelete.Visible = true;
			}
			else
			{
				// Сокрытие дополнительных пунктов меню:
				cbPosition.Visible = false;
				mDelete.Visible = false;
			}
		}

		/// <summary>
		/// Метод перемещения записей.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbPosition_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!_cbPositionFlag && lvPp.SelectedItems.Count > 0 && cbPosition.SelectedIndex > -1)
			{
				// Первый этап. Смещение записей в конец:
				for (int i = lvPp.SelectedItems.Count - 1; i >= 0; i--)
				{
					cPp.db.move(cPp.db.list.Count - 1, (int)lvPp.SelectedItems[i].Tag);
				}
				// Второй этап. Смещение записей в необходимый пункт:
				int start = cPp.db.list.Count - lvPp.SelectedItems.Count;
				int to = (cbPosition.SelectedIndex > start) ? start : cbPosition.SelectedIndex;
				for (int i = start; i < cPp.db.list.Count; i++)
				{
					cPp.db.move(to, i);
				}
				start = lvPp.SelectedItems.Count; // Количество записей для выделения.
				// Мелочи:
				cPp.db.changed = true;
				synchronizeDb(false);
				cmsPp.Close();
				// Выделение:
				_pgPpFlag = true; // Запрещаем отображения свойств (оптимизация).
				for (int i = 0; i < lvPp.Items.Count; i++) // Выделение перемещенных элементов:
					if (i >= to && i < to + start) lvPp.Items[i].Selected = true; else lvPp.Items[i].Selected = false;
				// Отображение их свойств:
				_pgPpFlag = false;
				lvPp_SelectedIndexChanged(null, null);
			}
		}

		/// <summary>
		/// Метод выделения всех записей в списке.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mSelectAll_Click(object sender, EventArgs e)
		{
			_cbPositionFlag = true; // Отключение отображения свойств объекта (оптимизация).
			foreach (ListViewItem lvi in lvPp.Items) lvi.Selected = true;
			_cbPositionFlag = false; // Включение отображения свойств объекта.
			cbPosition_SelectedIndexChanged(null, null); // Отображение свойств.
		}

		#endregion

		#region "Поиск записей"

		/// <summary>
		/// Метод поиска набора слов в строке.
		/// </summary>
		/// <param name="source"></param>
		/// <param name="what"></param>
		/// <returns></returns>
		private Boolean find(String source, String what)
		{
			if (String.IsNullOrEmpty(what)) return true;
			// Поиск подстроки:
			String s = null;
			int start = 0;
			source = source.ToLower(); // Перевод в нижний регистр для упрощения поиска.
			what = String.Format("{0} ", what.ToLower()); // Добавление закрывающего пробела.
			for (int i = 0; i < what.Length; i++)
			{
				if (what[i] == ' ') // Конец слова
				{
					s = what.Substring(start, i - start).Trim();
					if (!String.IsNullOrEmpty(s) && source.IndexOf(s) >= 0) return true; else start = i;
				}
			}
			// Если дошли до этого места, значит ничего не было найдено:
			return false;
		}

		/// <summary>
		/// Поиск данных с определенным интервалом.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void tSearch_Tick(object sender, EventArgs e)
		{
			synchronizeDb(true, 0); // Выводим данные с учетом фильтра и выделяем нулевой элемент.
			tSearch.Enabled = false; // Остановка фильтрации.
			cbSearch.SelectionStart = cbSearch.Text.Length; // Возвращаем указатель обратно в конец строки.
		}

		/// <summary>
		/// Начало поиска.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbSearch_TextChanged(object sender, EventArgs e)
		{
			if (_pgPpFlag == false && !tsbReport.Checked) tSearch.Enabled = true;
		}

		/// <summary>
		/// Выбор отчета.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Изменение текущего отчета:
			if (tsbReport.Checked)
			{
				switch (cbSearch.SelectedIndex)
				{
					default: // 0 и др.:
						cPp.db.setReport(cPp.db.rsrcs, sender != null);
						break;
				}
				pgPp.SelectedObject = cPp.db.report;
				wbReport.DocumentText = cPp.db.report.getHtml();
			}
		}

		#endregion

		#region "Переключение вкладок редактора"

		private void changeTab(cTab tab)
		{
			cPp.db.setTab(tab);
			cbSearch.Text = "";
			synchronizeDb(true, 0);
			tSearch.Enabled = false;
		}

		private void toList(Boolean showHistory)
		{
			_pgPpFlag = true;
			cbSearch.DropDownStyle = ComboBoxStyle.DropDown;
			lSearch.Text = "Поиск:";
			_pgPpFlag = false;

			pList.Visible = lvPp.Visible = true;
			pHelp.Visible = wbReport.Visible = false;
			tsbPreview.Enabled = false;
			lHistory.Visible = cbHistory.Visible = showHistory;
		}

		private void toReports()
		{
			_pgPpFlag = true;
			pList.Visible = wbReport.Visible = true;
			tsbPreview.Enabled = true;
			lvPp.Visible = pHelp.Visible = false;
			lHistory.Visible = cbHistory.Visible = false;

			lSearch.Text = "Тип:";
			cbSearch.DropDownStyle = ComboBoxStyle.DropDownList;

			// Выбор отчета:
			cbSearch.Items.Clear();
			cbSearch.Items.Add("Расход личного состава");
			cbSearch.SelectedIndex = 0;

			fPp_SizeChanged(null, null); // Позиционирование элементов.
			pgPp.Focus();
		}

		private void tsbSoldiers_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbSoldiers.Checked = true;
			tsbTasks.Checked = tsbWeapons.Checked = tsbHelp.Checked = tsbMachines.Checked = tsbPaths.Checked = tsbReport.Checked = false;
			// Отображение содержимого:
			toList(true);
			changeTab(cPp.db.soldiers);
		}

		private void tsbTasks_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbTasks.Checked = true;
			tsbSoldiers.Checked = tsbWeapons.Checked = tsbHelp.Checked = tsbMachines.Checked = tsbPaths.Checked = tsbReport.Checked = false;
			// Отображение содержимого:
			toList(false);
			changeTab(cPp.db.tasks);
		}

		private void tsbWeapons_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbWeapons.Checked = true;
			tsbSoldiers.Checked = tsbTasks.Checked = tsbHelp.Checked = tsbMachines.Checked = tsbPaths.Checked = tsbReport.Checked = false;
			// Отображение содержимого:
			toList(false);
			changeTab(cPp.db.weapons);
		}

		private void tsbMachines_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbMachines.Checked = true;
			tsbSoldiers.Checked = tsbTasks.Checked = tsbWeapons.Checked = tsbReport.Checked = tsbPaths.Checked = tsbHelp.Checked = false;
			// Отображение содержимого:
			toList(false);
			changeTab(cPp.db.machines);
		}

		private void tsbPath_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbPaths.Checked = true;
			tsbSoldiers.Checked = tsbTasks.Checked = tsbWeapons.Checked = tsbMachines.Checked = tsbHelp.Checked = tsbReport.Checked = false;
			// Отображение содержимого:
			toList(false);
			changeTab(cPp.db.paths);
		}

		private void tsbReports_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbReport.Checked = true;
			tsbSoldiers.Checked = tsbTasks.Checked = tsbWeapons.Checked = tsbMachines.Checked = tsbPaths.Checked = tsbHelp.Checked = false;
			// Отображение содержимого:
			toReports();
		}

		private void tsbHelp_Click(object sender, EventArgs e)
		{
			// Отображения вкладок:
			tsbHelp.Checked = true;
			tsbSoldiers.Checked = tsbTasks.Checked = tsbWeapons.Checked = tsbMachines.Checked = tsbPaths.Checked = tsbReport.Checked = false;
			tsbPreview.Enabled = false;
			// Отображение содержимого:
			pHelp.Visible = true;
			pList.Visible = false;
		}

		#endregion

		#region "Ведение истории изменения личного состава"

		/// <summary>
		/// Обработка выбора записи из истории.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbHistory_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (_pgPpFlag == false)
			{
				switch (cbHistory.SelectedIndex)
				{
					case 0: // Очистка истории:
						if (MessageBox.Show("Вы действительно хотите удалить все записи?", cPp.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
						{
							cPp.db.soldiers.removeAllButOneRecords();
							cPp.db.changed = true;
						}
						break;

					case 1: // Создание новой записи:
						if (noHistoryRecord(DateTime.Now.ToShortDateString()))
						{
							cPp.db.soldiers.addRecord(ObjectCloner.DeepClone(cPp.db.soldiers.record));
							cPp.db.changed = true;
						}
						else
						{
							MessageBox.Show(String.Format("Запись с именем {0} уже существует.", DateTime.Now.ToShortDateString()), cPp.name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						break;

					default: // Выбор:
						cPp.db.soldiers.recordIndex = cbHistory.SelectedIndex - 2; // Первые два элемента зарезервированы.
						break;
				}
				tsbSoldiers_Click(null, null);
			}
		}

		/// <summary>
		/// Обработка удаления записи из истории.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbHistory_TextUpdate(object sender, EventArgs e)
		{
			// Началось редактирование:
			if (_cbHistoryEdited == false)
			{
				_cbHistoryEdited = true;
				if (cbHistory.SelectedIndex != -1) _cbHistoryEditedIndex = cbHistory.SelectedIndex;
			}
			// Ожидание удаления:
			if (String.IsNullOrEmpty(cbHistory.Text) && _cbHistoryEditedIndex > 1) // Первые две строчки зарезервированы.
			{
				if (cPp.db.soldiers.records.Count > 1 && MessageBox.Show("Вы действительно хотите удалить запись?", cPp.name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
				{
					cPp.db.soldiers.removeRecord(cPp.db.soldiers.recordIndex);
					cbHistory.Items.RemoveAt(_cbHistoryEditedIndex);
					cbHistory.SelectedIndex = cbHistory.Items.Count - 1;
					cPp.db.changed = true;
				}
				else
				{
					// Возвращаем к первоначальному значению:
					cbHistory.Text = cbHistory.Items[_cbHistoryEditedIndex].ToString();
					cbHistory.SelectedIndex = _cbHistoryEditedIndex;
				}
				// Редактирование закончено:
				_cbHistoryEdited = false;
			}
		}

		/// <summary>
		/// Обработка переименовывания записи из истории.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cbHistory_Validating(object sender, CancelEventArgs e)
		{
			if (_cbHistoryEdited == true && _cbHistoryEditedIndex > 1) // Первые две строчки зарезервированы.
			{
				DateTime newDateTime;
				try
				{
					newDateTime = DateTime.Parse(cbHistory.Text);
					// Переименовывание:
					if (noHistoryRecord(newDateTime.ToShortDateString()) == false) throw new Exception(); // Запись уже имеется. Переименовывать нельзя.
					cPp.db.soldiers.record.date = newDateTime;
					cbHistory.Items[_cbHistoryEditedIndex] = newDateTime.ToShortDateString();
					// Редактирование закончено:
					_cbHistoryEdited = false;
					cPp.db.changed = true;
					updateCaption();
				}
				catch
				{
					// Возвращаем к первоначальному значению:
					cbHistory.Text = cbHistory.Items[_cbHistoryEditedIndex].ToString();
					cbHistory.SelectedIndex = _cbHistoryEditedIndex;
				}
				finally
				{
				}
			}
		}

		/// <summary>
		/// Определяет, что запись единственная в истории.
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		private Boolean noHistoryRecord(String name)
		{
			foreach (String s in cbHistory.Items)
			{
				if (String.Equals(s, name)) return false;
			}
			return true;
		}

		#endregion
	}
}
