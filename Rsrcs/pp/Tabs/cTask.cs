using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace pp
{
	[Serializable]
	public class cTask
	{
		private String _name, // Название.
						_category, // Категория.
						_note; // Заметка.

		private Color _color; // Цвет выделения.

		/// <summary>
		/// Установка задачи по умолчанию.
		/// </summary>
		public cTask()
		{
			_name = "";
			_category = "";
			_note = "";
			_color = SystemColors.Window;
		}

		[DisplayName("Название"),
		Description("Краткая информация о задаче.")]
		public String name
		{
			get { return _name; }
			set { _name = value; }
		}

		[DisplayName("Категория"),
		Description("Название категории, в которую будет включена данная задача. Все задачи в расходе группируются по категориям.")]
		public String category
		{
			get { return _category; }
			set { _category = value; }
		}

		[DisplayName("Заметка"),
		Description("Дополнительная информация о задаче.")]
		public String note
		{
			get { return _note; }
			set { _note = value; }
		}

		[DisplayName("Цвет"),
		Description("Цвет, которым будут отмечены в списке военнослужащие, выполняющие данную задачу.")]
		public Color color
		{
			get { return _color; }
			set { _color = value; }
		}

		public override String ToString()
		{
			if (String.IsNullOrEmpty(_name))
				return "(Новая задача)";
			else
				return String.Format("{0}", _name);
		}
	}

	[Serializable]
	public class cTaskTab : cTab
	{
		public override void add()
		{
			list.Add(new cTask());
		}

		public override Color getColor(int index)
		{
			return ((cTask)list[index]).color;
		}
	}

}
