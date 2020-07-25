using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;

namespace pp
{
	/// <summary>
	/// База данных редактора расходов.
	/// </summary>
	[Serializable]
	public class cDb: cTab
	{
		#region "Свойства и поля класса"

		[NonSerialized] public const String filter = "Файлы редактора расходов (*.pp)|*.pp|Все файлы (*.*)|*.*";
		[NonSerialized] public const String savePromt = "Редактор расходов содержит несохраненные данные. Сохранить?";
		[NonSerialized] public const String openTitle = "Открытие расхода...";
		[NonSerialized] public const String saveTitle = "Сохранение расхода...";
		[NonSerialized] public const String openError = "Не удалось открыть файл с расходом.";
		[NonSerialized] public const String saveError = "Не удалось сохранить файл с расходом.";

		[NonSerialized] private Boolean _changed; // Флаг того, что БД была изменена.
		[NonSerialized] private String _savedFile; // Путь к файлу БД.
		[NonSerialized] private cTab _tab; // Текущий список.
		[NonSerialized] private cReport _report; // Текущий отчёт.

		public String savedFile { get { return _savedFile; } } // Получение пути к сохраненному файлу.
		public override List<Object> list { get { return _tab.list; } } // Список записей текущей вкладки.
		public cReport report { get { return _report; } } // Текущий отчёт.
		public cTab tab { get { return _tab; } } // Текущая вкладка.
		public void setTab(cTab tab) { _tab = tab; } // Установка текущей вкладки.
		public void setReport(cReport report, Boolean afterSelect) { _report = report; if (afterSelect) _report.afterSelect(); } // Установка текущего отчёта. afterSelect - запускать или нет событие afterSelect.

		public Boolean changed
		{
			get { return _changed; }
			set { _changed = value; }
		}

		#endregion

		#region "Вкладки с данными"

		private cSoldierTab _soldiers; // Личный состав.
		private cTaskTab _tasks; // Задачи.
		private cWeaponTab _weapons; // Оружие.
		private cMachineTab _machines; // Техника.
		private cPathTab _paths; // Путевые листы.

		public cTaskTab tasks { get { return _tasks; } }
		public cSoldierTab soldiers { get { return _soldiers; } }
		public cWeaponTab weapons { get { return _weapons; } }
		public cMachineTab machines { get { return _machines; } }
		public cPathTab paths { get { return _paths; } }

		#endregion

		#region "Отчёты"

		private cRsrcReport _rsrcs; // Расход личного состава.

		public cRsrcReport rsrcs { get { return _rsrcs; } }

		#endregion

		/// <summary>
		/// Установка значений по умолчанию (создание пустой базы данных).
		/// </summary>
		public cDb()
		{
			_changed = false;
			_savedFile = null;

			// Создание данных:
			_soldiers = new cSoldierTab();
			_tasks = new cTaskTab();
			_weapons = new cWeaponTab();
			_machines = new cMachineTab();
			_paths = new cPathTab();
			_tab = _soldiers; // Вкладка по умолчанию.

			// Создание отчетов:
			_rsrcs = new cRsrcReport();
			_report = _rsrcs; // Отчёт по умолчанию.
		}

		#region "Сохранение / Загрузка базы данных"

		/// <summary>
		/// Загрузка базы.
		/// </summary>
		/// <returns></returns>
		public static cDb deserialize(String fileName)
		{
			cDb result = null; // Установка по умолчанию.
			Stream dbFile = null;
			try
			{
				dbFile = File.OpenRead(fileName);
				if (dbFile != null)
				{
					BinaryFormatter formatter = new BinaryFormatter();
					result = (cDb)formatter.Deserialize(dbFile);
					// Если try выполнен до этого места, значит база загружена успешно.
				}
			}
			catch (Exception e)
			{
				MessageBox.Show(String.Format("{0} {1}", openError, e.Message), cPp.name, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			finally
			{
				if (dbFile != null) dbFile.Close();
			}
			return result;
		}

		/// <summary>
		/// Сохранение базы.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static Boolean serialize(cDb db, String fileName)
		{
			Boolean result = true;
			Stream dbFile = null;
			try
			{
				dbFile = File.Create(fileName);
				BinaryFormatter formatter = new BinaryFormatter();
				// Получение данных с временных файлов отчётов:
				db.rsrcs.open();
				// Сохранение данных:
				formatter.Serialize(dbFile, db);
			}
			catch (Exception e)
			{
				MessageBox.Show(String.Format("{0} {1}", saveError, e.Message), cPp.name, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				result = false;
			}
			finally
			{
				if (dbFile != null) dbFile.Close();
			}
			return result;
		}

		/// <summary>
		/// Открытие базы данных с использованием диалогового окна.
		/// </summary>
		/// <returns></returns>
		public static cDb open()
		{
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.AddExtension = true;
				ofd.CheckFileExists = true;
				ofd.CheckPathExists = true;
				ofd.Filter = cDb.filter;
				ofd.FilterIndex = 1;
				ofd.Multiselect = false;
				ofd.RestoreDirectory = true;
				ofd.Title = openTitle;
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					return cDb.open(ofd.FileName);
				}
			}
			return null;
		}

		/// <summary>
		/// Открытие базы данных.
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		public static cDb open(String fileName)
		{
			cDb result = cDb.deserialize(fileName);
			if (result == null) result = new cDb(); else result._savedFile = fileName;
			result._changed = false;
			result._tab = result._soldiers;
			return result;
		}

		/// <summary>
		/// Сохранение базы данных.
		/// </summary>
		/// <returns></returns>
		public Boolean save()
		{
			Boolean result = false;
			if (String.IsNullOrEmpty(_savedFile))
			{
				result = saveAs();
			}
			else
			{
				result = cDb.serialize(this, _savedFile);
				if (result == true) _changed = false; // Файл сохранен.
			}
			return result;
		}

		/// <summary>
		/// Сохранение базы данных с использованием диалогового окна.
		/// </summary>
		/// <returns></returns>
		public Boolean saveAs()
		{
			Boolean result = false;
			using (SaveFileDialog sfd = new SaveFileDialog())
			{
				sfd.AddExtension = true;
				sfd.CheckFileExists = false;
				sfd.CheckPathExists = true;
				sfd.Filter = cDb.filter;
				sfd.FilterIndex = 1;
				sfd.OverwritePrompt = true;
				sfd.RestoreDirectory = true;
				sfd.Title = saveTitle;
				if (sfd.ShowDialog() == DialogResult.OK)
				{
					result = cDb.serialize(this, sfd.FileName);
					if (result == true)
					{
						_savedFile = sfd.FileName;
						_changed = false; // Файл сохранен.
					}
				}
			}
			return result;
		}

		#endregion

		#region "Функционал для работы с записями"

		public override void add()
		{
			_tab.add();
		}

		public override void remove(int index)
		{
			_tab.remove(index);
		}

		public override void move(int destinationIndex, int sourceIndex)
		{
			_tab.move(destinationIndex, sourceIndex);
		}

		public override String getText(int index)
		{
			return _tab.getText(index);
		}

		public override Object getObject(int index)
		{
			return _tab.getObject(index);
		}

		public override Color getColor(int index)
		{
			return _tab.getColor(index);
		}

		public override Font getFont(int index)
		{
			return _tab.getFont(index);
		}

		public override Color getTextColor(int index)
		{
			return _tab.getTextColor(index);
		}

		#endregion
	}
}
