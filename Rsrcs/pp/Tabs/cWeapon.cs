using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;

namespace pp
{
	[Serializable]
	public class cWeapon
	{
		private String _name, // Наименование (модель).
						_number, // Номер.
						_place, // Подразделение.
						_note; // Заметка.

		[DisplayName("Наименование"),
		Description("Модель оружия.")]
		public String name
		{
			get { return _name; }
			set { _name = value; }
		}

		[DisplayName("Номер"),
		Description("Номер оружия.")]
		public String number
		{
			get { return _number; }
			set { _number = value; }
		}

		[DisplayName("Подразделение"),
		Description("Подразделение, в котором числится оружие.")]
		public String place
		{
			get { return _place; }
			set { _place = value; }
		}

		[DisplayName("Заметка"),
		Description("Дополнительная информация об оружии.")]
		public String note
		{
			get { return _note; }
			set { _note = value; }
		}

		public cWeapon()
		{
			_name = "";
			_note = "";
			_number = "";
		}

		public override String ToString()
		{
			if (String.IsNullOrEmpty(_name))
				return "(Новое оружие)";
			else
				return String.Format("{0} {1}", cPp.getStringWithoutTags(_name), String.IsNullOrEmpty(_number) ? "" : String.Format("№ {0}", _number));
		}
	}

	[Serializable]
	public class cWeaponTab : cTab
	{
		public cWeaponTab()
		{
		}

		public override void add()
		{
			list.Add(new cWeapon());
		}
	}
}
