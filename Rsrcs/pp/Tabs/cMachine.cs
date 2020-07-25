using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace pp
{
	[Serializable]
	public class cMachine
	{
		protected String _name, // Марка машины (марка агрегата, тип воздушного судна).
							_number, // Номер машины.
							_place, // Подразделение.
							_note; // Заметка.

		[DisplayName("Наименование"),
		Description("Марка машины, агрегата или тип воздушного судна.")]
		public String name
		{
			get { return _name; }
			set { _name = value; }
		}

		[DisplayName("Номер"),
		Description("Номер машины (двигателя, шасси), агрегата или бортовой номер.")]
		public String number
		{
			get { return _number; }
			set { _number = value; }
		}

		[DisplayName("Подразделение"),
		Description("Подразделение, в котором числится техника.")]
		public String place
		{
			get { return _place; }
			set { _place = value; }
		}

		[DisplayName("Заметка"),
		Description("Дополнительная информация о технике.")]
		public String note
		{
			get { return _note; }
			set { _note = value; }
		}

		public cMachine()
		{
			_name = "";
			_number = "";
			_note = "";
		}

		public override String ToString()
		{
			if (String.IsNullOrEmpty(_name))
				return "(Новая техника)";
			else
				return String.Format("{0} {1}", cPp.getStringWithoutTags(_name), String.IsNullOrEmpty(_number) ? "" : String.Format("№ {0}", _number));
		}
	}

	[Serializable]
	public class cMachineTab : cTab
	{
		public cMachineTab()
		{
		}

		public override void add()
		{
			list.Add(new cMachine());
		}
	}
}
