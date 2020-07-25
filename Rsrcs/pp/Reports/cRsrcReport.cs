using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace pp
{
	[Serializable]
	public class cRsrcReport: cReport
	{
		protected DateTime _date; // Число, с которого необходим отчет.
		
		[NonSerialized]
		protected Boolean _contract; // Отображать контрактников.

		[DisplayName("Дата"),
		Description("Число, на которое составляется расход."),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)] // При изменении данные не меняются. Флаг db.changed не изменяется.
		public DateTime date
		{
			get { return _date; }
			set { _date = value; }
		}

		[DisplayName("С контрактниками"),
		Description("Отображать контрактников в расходе."),
		TypeConverter(typeof(cBooleanConverter)),
		DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public Boolean contract
		{
			get { return _contract; }
			set { _contract = value; }
		}

		[Browsable(false)]
		public override String name { get { return "Rsrcs.txt"; } }

		[Browsable(false)]
		public override int variableCount { get { return 2; } }

		public override void afterSelect()
		{
			_date = DateTime.Now;
		}

		/// <summary>
		/// Шаблон по умолчанию.
		/// </summary>
		public cRsrcReport()
		{
			_template = @"<html>

	<head>
		<title>Расход личного состава на <variable1/></title>
		<style>
			.default-margins, .default-borders, html, body { margin:0px; padding:0px; }
			body { background-color: #ffffff; text-align:center; }
			.default-borders, div, span, table, tr, td { border-collapse:collapse; border-color:#000000; border-width:0px; border-style:solid; text-align:left; vertical-align:top; }

			.large, .normal, .small, body, table, div { font-family:""segoe ui"", ""times new roman"", ""tahoma"", ""arial"", ""sans-serif"", ""verdana""; font-color:#000000; font-size:8px; }
			.large { font-size:12px; }
			.normal {}
			.small { font-size:6px; }

			.left { text-align:left; vertical-align:middle; }
			.center { text-align:center; vertical-align:middle; }
			.right { text-align:right; vertical-align:middle; }

			.bold { font-weight:bold; }
			.underline { text-decoration:underline; }
			.italic { font-style:italic; }

			.list { border-collapse:collapse; border-color:#000000; border-width:1px; border-style:solid; font-size:6px; }
			.list td { border-right-width:1px; vertical-align:middle; }
			.dark { background-color:#d8d8d8; }
			.light { background-color:#ffffff; }
			.header { border-bottom-width:2px; }
			.totals { font-size:10px; }
			.total {text-align:center; vertical-align:middle; font-weight:bold;}
			.label { text-align:center; vertical-align:middle; font-style:italic; font-size:12px; }
			.place { text-align:center; vertical-align:middle; font-style:italic; font-size:12px; text-decoration:underline; }
			.group { text-align:center; vertical-align:middle; font-style:italic; font-size:6px; text-decoration:underline; }
		</style>
	</head>

	<body>
		<!-- Расход личного состава. -->
		<table style=""width:100%; margin-bottom:16px;""><tr><td class=""label"">Расход личного состава на <strong><variable1/></strong></td></tr></table>
		<table style=""width:100%;"">
			<tr>
				<!-- Таблицы с личным составом. -->
				<variable0/>
			</tr>
		</table>
		<!-- Разделитель таблиц. Линия отрыва. --><table style=""border-color:#000000; width:100%; margin-bottom:16px; margin-top:16px; border-bottom-width:2px; border-bottom-style:dashed;""><tr><td></td></tr></table>
		<!-- Вторая копия расхода на лист (удобно для печати). -->
		<table style=""width:100%; margin-bottom:16px;""><tr><td class=""label"">Расход личного состава на <strong><variable1/></strong></td></tr></table>
		<table style=""width:100%;"">
			<tr>
				<variable0/>
			</tr>
		</table>
	</body>

</html>
";
		}

		/// <summary>
		/// Разворачивание списка. Подсчет некоторых данных.
		/// </summary>
		/// <param name="treeRoot">Дерево, которое будет развернуто.</param>
		/// <param name="targetList">Одномерный массив с развернутым деревом.</param>
		/// <param name="busy">Количество отсутствующего лс.</param>
		/// <param name="fact">На лицо.</param>
		/// <param name="busyContract">Отсутствующие контрактники.</param>
		/// <param name="factContract">Отсутствующие срочники.</param>
		/// <returns>Количество строк в развернутом дереве.</returns>
		protected int mapTreeToList(cRsrcsNode treeRoot, List<cRsrcsNode> targetList, ref int busy, ref int fact, ref int busyContract, ref int factContract)
		{
			cRsrcsNode node;
			int all = 1, soldiers = 0;
			for (int i = 0; i < treeRoot.Nodes.Count; i++)
			{
				node = treeRoot.Nodes[i];
				targetList.Add(node);
				if (node._soldier == null)
				{
					all += mapTreeToList(node, targetList, ref busy, ref fact, ref busyContract, ref factContract);
					soldiers = 0;
				}
				else
				{
					soldiers++;
					targetList[targetList.Count - 1].Index = soldiers;

					// Подсчёт личного состава:
					if (String.IsNullOrEmpty(node._soldier.task)) // Солдат не занят:
					{
						if (node._soldier.contract) factContract++;
						fact++;
					}
					else // Занят:
					{
						if (node._soldier.contract) busyContract++;
						busy++;
					}
				}
			}
			return all + soldiers;
		}

		protected override String getVariableHtml(int variableIndex)
		{
			switch (variableIndex)
			{
				case 0:
					string result = ""; // HTML-код расхода.
					Boolean otherColor; // Чередование светлых и темных строк.
					cRsrcsNode table, record; // Текущая таблица (deep = 1; например 2 АВТР или АРВ), заголовок.
					cSoldier soldier;
					int maxRows; // Максимальное количество строк в таблице.
					int i, j, k, busy, fact, busyContract, factContract;
					// Создание дерева с результатом (говнокод):
					cRsrcsNode tree = new cRsrcsNode(null, -1, 0);
					// ..Незанятые контрактники и срочники:
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (soldier.contract && _contract && String.IsNullOrEmpty(soldier.task)) tree.insertSoldier(soldier, tree, i, 0);
					}
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (!soldier.contract && String.IsNullOrEmpty(soldier.task)) tree.insertSoldier(soldier, tree, i, 0);
					}
					// ..Занятые контрактники и срочники:
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (soldier.contract && _contract && cRsrcsNode.getTaskCategory(soldier.task) == String.Empty) tree.insertSoldier(soldier, tree, i, 0);
					}
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (soldier.contract && _contract && !String.IsNullOrEmpty(cRsrcsNode.getTaskCategory(soldier.task))) tree.insertSoldier(soldier, tree, i, 0);
					}
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (!soldier.contract && cRsrcsNode.getTaskCategory(soldier.task) == String.Empty) tree.insertSoldier(soldier, tree, i, 0);
					}
					for (i = 0; i < cPp.db.soldiers.list.Count; i++)
					{
						soldier = (cSoldier)cPp.db.soldiers.list[i];
						// Добавляем солдата в список, если он в штате.
						if (!soldier.contract && !String.IsNullOrEmpty(cRsrcsNode.getTaskCategory(soldier.task))) tree.insertSoldier(soldier, tree, i, 0);
					}
					// Формирование HTML-кода расхода:
					for (i = 0; i < tree.Nodes.Count; i++) // Цикл по таблицам:
					{
						maxRows = -1;
						busy = fact = busyContract = factContract = 0;
						// Подготовка данных и запись заголовка таблицы:
						table = tree.Nodes[i]; // i-я таблица.
						result += String.Format(@"<td{0}><table style=""width:100%; margin-bottom:8px;""><tr><td class=""place"">{1}</td></tr></table><table class=""list"" style=""width:100%; margin-bottom:8px;""><tr class=""light"">", i > 0 ? @" style=""padding-left:8px;""" : "", table.Group);
						List<List<cRsrcsNode>> list = new List<List<cRsrcsNode>>(); // Создание таблицы.
						for (j = 0; j < table.Nodes.Count; j++)
						{
							record = table.Nodes[j];
							list.Add(new List<cRsrcsNode>()); // Добавление столбца с военнослужащими.
							k = mapTreeToList(record, list[j], ref busy, ref fact, ref busyContract, ref factContract); // Разворачивание столбца в одномерный массив.
							if (k > maxRows) maxRows = k;
							if (String.IsNullOrEmpty(record.Group))
								result += @"<td class=""header group"">&nbsp;</td>";
							else
								result += String.Format(@"<td class=""header group"">{0} - <strong>{1}</strong></td>", record.Group, record.Count); // Запись группы.
						}
						result += @"</tr>";
						// Вывод строк с военнослужащими в таблицу:
						otherColor = false;
						for (j = 0; j < maxRows - 1; j++)
						{
							otherColor = !otherColor; // Чередование светлых и темных строк.
							result += String.Format(@"<tr class=""{0}"">", otherColor ? "dark" : "light");
							for (k = 0; k < table.Nodes.Count; k++) // Цикл по столбцам таблицы:
							{
								if (list[k].Count > j) // Не пустая строка:
								{
									record = list[k][j];

									if (record._soldier == null) // Группа:
										result += String.Format(@"<td class=""group"">{0} - <strong>{1}</strong></td>", record.Group, record.Count); // Вывод группы.
									else // Солдат:
										result += String.Format(@"<td>{0}. {1}</td>",
											record.Index,
											record._soldier.contract ?
												String.Format(@"<strong>{0}</strong>",
													!String.IsNullOrEmpty(cRsrcsNode.getTaskCategory(record._soldier.task)) ?
														record._soldier.name :
														cPp.getStringWithoutTags(record._soldier.name)) :
												!String.IsNullOrEmpty(cRsrcsNode.getTaskCategory(record._soldier.task)) ?
														record._soldier.name :
														cPp.getStringWithoutTags(record._soldier.name)); // Вывод солдата.
								}
								else // Пустая строка:
								{
									result += @"<td></td>";
								}
							}
							result += @"</tr>";
						}
						if (_contract)
						{
							result += String.Format(@"</table>
					<!-- Общее количество личного состава. -->
					<table class=""totals"" style=""float:right;"">
						<tr>
							<td></td>
							<td class=""italic"">Контр.</td>
							<td class=""italic"">Срочн.</td>
							<td class=""italic"">Всего</td>
						</tr>
						<tr>
							<td class=""italic right"">По списку</td>
							<td class=""total"">{0}</td>
							<td class=""total"">{1}</td>
							<td class=""total"">{2}</td>
						</tr>
						<tr>
							<td class=""italic right"">На лицо</td>
							<td class=""total"">{3}</td>
							<td class=""total"">{4}</td>
							<td class=""total"">{5}</td>
						</tr>
						<tr>
							<td class=""italic right"">Отсутствует</td>
							<td class=""total"">{6}</td>
							<td class=""total"">{7}</td>
							<td class=""total"">{8}</td>
						</tr>
					</table></td>",
								 busyContract + factContract, // Контрактников по списку.
								 busy + fact - busyContract - factContract, // Срочников по списку.
								 busy + fact, // Всего по списку.
								 factContract, // Контрактников на лицо.
								 fact - factContract, // Срочников на лицо.
								 fact, // Всего на лицо.
								 busyContract, // Отсутствует контрактников.
								 busy - busyContract, // Отсутствует срочников.
								 busy); // Отсутствует всего.
						}
						else
						{
							result += String.Format(@"</table>
					<!-- Общее количество только срочников. -->
					<table class=""totals"" style=""float:right;"">
						<!-- tr>
							<td></td>
							<td class=""italic"">Срочн.</td>
						</tr -->
						<tr>
							<td class=""italic right"">По списку</td>
							<td class=""total"">{0}</td>
						</tr>
						<tr>
							<td class=""italic right"">На лицо</td>
							<td class=""total"">{1}</td>
						</tr>
						<tr>
							<td class=""italic right"">Отсутствует</td>
							<td class=""total"">{2}</td>
						</tr>
					</table></td>",
								 busy + fact, // Всего по списку.
								 fact, // Всего на лицо.
								 busy); // Отсутствует всего.
						}
					}
					return result;
				default:
					int toDay = _date.AddDays(1).Day, toMonth = _date.AddMonths(1).Month;
					return String.Format("{0}-{1} {2} {3} г.", _date.Day, toDay, toDay < _date.Day ? cReport.getMonth(toMonth) : cReport.getMonth(_date.Month), toMonth < _date.Month ? _date.AddYears(1).Year : _date.Year);
			}
		}

		/*public string GetHtml(string caption, bool updateGroups)
		{
			// Данный код создавался на скорую руку и требует оптимизации.
			// Создание html кода расхода:
			string result = "", topic1 = String.Format("{0} на ", caption), topic2 = String.Format("{0}-{1} {2} {3} г.", day.Value.Day, day.Value.AddDays(1).Day, GetMonth(day.Value.Month), day.Value.Year);

			// Создание дерева:
			Index = -1;
			Deep = 0;
			naLico.Clear();
			Nodes.Clear();
			// Составляем свободный штат:
			if (money) // Контрактники
			{
				foreach (DataGridViewRow r in soldiers.Rows)
				{
					if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
					{
						string work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
						bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
						if (String.IsNullOrEmpty(work) && kontra)
						{
							InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, null, null, kontra, true);
						}
					}
				}
			}
			foreach (DataGridViewRow r in soldiers.Rows)
			{
				if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
				{
					string work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
					bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
					if (String.IsNullOrEmpty(work) && !kontra)
					{
						InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, null, null, kontra, true);
					}
				}
			}
			// Составляем занятый штат с непустыми группами:
			if (money) // Если с учетом контрабасов.
			{
				foreach (DataGridViewRow r in soldiers.Rows)
				{
					if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
					{
						bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
						string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
						bool founded = false;
						foreach (DataGridViewRow t in tasks.Rows)
						{
							if (t.Index < tasks.Rows.Count - 1)
							{
								nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
								group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
								if (work == nariad) // Только существующие строки:
								{
									founded = true;
									break;
								}
							}
						}
						if (founded && !String.IsNullOrEmpty(group) && kontra)
						{
							cRsrcsNode list;
							list.insertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, false);
						}
					}
				}
			}
			foreach (DataGridViewRow r in soldiers.Rows)
			{
				if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
				{
					bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
					string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
					bool founded = false;
					foreach (DataGridViewRow t in tasks.Rows)
					{
						if (t.Index < tasks.Rows.Count - 1)
						{
							nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
							group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
							if (work == nariad) // Только существующие строки:
							{
								founded = true;
								break;
							}
						}
					}
					if (founded && !String.IsNullOrEmpty(group) && !kontra)
					{
						InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, false);
					}
				}
			}
			// Составляем занятый штат с пустыми группами:
			if (money)
			{
				foreach (DataGridViewRow r in soldiers.Rows)
				{
					if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
					{
						bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
						string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
						bool founded = false;
						foreach (DataGridViewRow t in tasks.Rows)
						{
							if (t.Index < tasks.Rows.Count - 1)
							{
								nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
								group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
								if (work == nariad) // Только существующие строки:
								{
									founded = true;
									break;
								}
							}
						}
						if (founded && String.IsNullOrEmpty(group) && kontra)
						{
							InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, true);
						}
					}
				}
			}
			foreach (DataGridViewRow r in soldiers.Rows)
			{
				if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
				{
					bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
					string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
					bool founded = false;
					foreach (DataGridViewRow t in tasks.Rows)
					{
						if (t.Index < tasks.Rows.Count - 1)
						{
							nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
							group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
							if (work == nariad) // Только существующие строки:
							{
								founded = true;
								break;
							}
						}
					}
					if (founded && String.IsNullOrEmpty(group) && !kontra)
					{
						InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, true);
					}
				}
			}
			
		}*/
	}

	/// <summary>
	/// Дерево для отчёта.
	/// </summary>
	public class cRsrcsNode
	{
		public int Index = -1; // Индекс военнослужащего по штатке.
		protected int Deep = 0; // Глубина дерева.

		public cSoldier _soldier; // Ссылка на военнослужащего.
		public string Group = ""; // Название группы, в которую входит военнослужащий.

		public int Count = 0; // Количество солдат в поддереве.
		public List<int> naLico = new List<int>();
		public List<cRsrcsNode> Nodes = new List<cRsrcsNode>(); // Дочерние элементы.

		/// <summary>
		/// Получение категории для задачи.
		/// </summary>
		/// <param name="task"></param>
		/// <returns></returns>
		public static String getTaskCategory(String task)
		{
			if (!String.IsNullOrEmpty(task)) // Если задач не поставлено, тогда возвращаем null.
			{
				foreach (cTask t in cPp.db.tasks.list)
				{
					if (t.name == task) return t.category;
				}
				return "";
			}
			return null;
		}

		/// <summary>
		/// Разбор строки с подразделением.
		/// </summary>
		/// <param name="parsingString"></param>
		/// <param name="deep"></param>
		/// <returns></returns>
		private static String getGroupName(string parsingString, int deep)
		{
			int word = 0, start = 0;
			parsingString = String.Format("{0}{1}", parsingString, ",");
			for (int i = 1; i < parsingString.Length; i++)
			{
				if (parsingString[i] == ',') // Нашли конец слова.
				{
					if (word == deep)
					{
						return parsingString.Substring(start, i - start).Trim();
					}
					else
					{
						start = i + 1;
						word++;
					}
				}
			}
			return null;
		}

		public cRsrcsNode(cSoldier soldier, int index, int deep)
		{
			_soldier = soldier;
			Deep = deep;
			Index = index;
		}

		/// <summary>
		/// Поиск номера военнослужащего в группе.
		/// </summary>
		/// <param name="root"></param>
		/// <param name="group"></param>
		/// <returns></returns>
		private int getGroupIndex(cRsrcsNode root, string group)
		{
			foreach (cRsrcsNode n in root.Nodes)
			{
				if (String.Compare(n.Group, group) == 0) return n.Index;
			}
			return -1;
		}

		/// <summary>
		/// Формирование дерева с результатом.
		/// </summary>
		//private void insertSoldier(int table, int index, string parsingString, cRsrcsNode parent, int deep, string nariad, string nariadGroup, bool kontrakt, bool free)
		public void insertSoldier(cSoldier soldier, cRsrcsNode parent, int index, int deep)
		{
			// Добавляем солдата в список, если он не скрыт:
			if (!soldier.inUse) return;
			// Вспомогательные переменные:
			string group; // Ищем в parent группу с именем group:
			// Определяем, какого служащего добавляем. Свободного или нет:
			if (String.IsNullOrEmpty(soldier.task)) // Свободного:
			{
				group = getGroupName(soldier.place, deep);
				if ((deep == 0 && group == null) || (deep == 1 && group == null)) return;
				parent.Count++; // Количество личного состава в поддереве.
				if (group == null) // значит элемент записываем в parent:
				{
					parent.Nodes.Add(new cRsrcsNode(soldier, index, deep));
				}
				else // Необходимо дальше искать группу для элемента:
				{
					int ind = getGroupIndex(parent, group);
					if (ind == -1) // Группу с таким именем не нашли, создаем новую:
					{
						cRsrcsNode n = new cRsrcsNode(null, parent.Nodes.Count, deep + 1);
						n.Group = group;
						parent.Nodes.Add(n);
						insertSoldier(soldier, n, index, deep + 1);
					}
					else
					{
						insertSoldier(soldier, parent.Nodes[ind], index, deep + 1);
					}
				}
			}
			else // Добавление столбцов с нарядами:
			{
				switch (deep)
				{
					case 0:
						group = getGroupName(soldier.place, 0);
						break;
					case 1:
						group = getTaskCategory(soldier.task);
						break;
					case 2:
						group = soldier.task;
						break;
					default:
						group = null;
						break;
				}
				parent.Count++; // Количество личного состава в поддереве.
				if (group == null)
				{
					parent.Nodes.Add(new cRsrcsNode(soldier, index, deep)); // ???.
				}
				else
				{
					int ind = getGroupIndex(parent, group);
					if (ind == -1) // Группу с таким именем не нашли, создаем новую:
					{
						cRsrcsNode n = new cRsrcsNode(null, parent.Nodes.Count, deep + 1);
						n.Group = group;
						parent.Nodes.Add(n);
						insertSoldier(soldier, n, index, deep + 1);
					}
					else
					{
						insertSoldier(soldier, parent.Nodes[ind], index, deep + 1);
					}
				}
			}
		}
	}
}
