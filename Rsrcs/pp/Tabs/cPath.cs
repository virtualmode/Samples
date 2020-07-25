using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Collections;

namespace pp
{
    [Serializable]
    public class cPath
    {
		protected String _number, // Номер путевого листа.
							_machine, // Номер машины, на которую выписан путевой лист.
							_pilot; // Водитель.
		protected DateTime _date; // Дата выписки путевого листа.
		protected List<Double> _materials; // Список используемых материалов.

		[Browsable(true), // Отображать в окне свойств.
		DisplayName("Номер"),
		Description("Номер путевого листа.")]
		// [Category("Name of the category")] // Так задается название категории.
		public String number
		{
			get { return _number; }
			set { _number = value; }
		}

		[DisplayName("ГСМ"),
		Description("Список горючих и смазочных материалов.")]
		public List<Double> materials
		{
			get { return _materials; }
			set { _materials = value; }
		}

		[DisplayName("Машина"),
		Description("Машина, на которую выписан путевой лист.")]
		public String machine
		{
			get { return _machine; }
			set { _machine = value; }
		}

		[DisplayName("Дата"),
		Description("Дата, с которой путевой лист действителен.")]
		public DateTime date
		{
			get { return _date; }
			set { _date = value; }
		}

		[DisplayName("Водитель"),
		Description("Водитель автомобиля.")]
		public String pilot
		{
			get { return _pilot; }
			set { _pilot = value; }
		}

        public cPath()
        {
			_number = "";
			_machine = "";
			_pilot = "";
			_date = DateTime.Now;
			_materials = new List<Double>();
        }

		public override String ToString()
		{
			if (String.IsNullOrEmpty(_number))
				return "(Новый путевой лист)";
			else
				return String.Format("№ {0} от {1} {2}", cPp.getStringWithoutTags(_number), _date.ToShortDateString(), String.IsNullOrEmpty(_machine) ? "" : String.Format("({0})", _machine));
		}
    }

	[Serializable]
	public class cPathTab : cTab
	{
		public cPathTab()
		{
		}

		public override void add()
		{
			list.Add(new cPath());
		}
	}
}
