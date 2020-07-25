using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Collections;

namespace pp
{
	[Serializable]
    public class cSoldier
    {
		// TODO: Для путевых листов необходим еще и код получателя.

		private String _name, // ФИО.
							_post, // Должность.
							_rank, // Звание.
							_place, // Подразделение.
							_task, // Поставленная задача.
							_note; // Заметка.

		private Boolean _contract, // Контрактная, срочная служба.
						_inUse; // Учитывать военнослужащего при создании отчётов. Необходимо для создания записей ВАКАНТ.

		[DisplayName("Должность"),
		Description("Должность, занимаемая военнослужащим.")]
		public String post
		{
			get { return _post; }
			set { _post = value; }
		}

		[DisplayName("Подразделение"),
		Description("Подразделение, в котором числится военнослужащий.")]
		public String place
		{
			get { return _place; }
			set { _place = value; }
		}

		[DisplayName("Звание"),
		Description("Воинское звание военнослужащего.")]
		public String rank
		{
			get { return _rank; }
			set { _rank = value; }
		}

		[Browsable(true), // Отображать в окне свойств.
		DisplayName("ФИО"),
		Description("Фамилия, инициалы военнослужащего, его подразделение и т.д.")]
		public String name
		{
			get { return _name; }
			set { _name = value; }
		}

		[DisplayName("Контракт"),
		Description("Контрактная либо срочная служба."),
		TypeConverter(typeof(cBooleanConverter))]
		public Boolean contract
		{
			get { return _contract; }
			set { _contract = value; }
		}

		[DisplayName("Отображать в отчётах"),
		Description("Необходимость скрывать или показывать военнослужащего в отчётах."),
		TypeConverter(typeof(cBooleanConverter))]
		public Boolean inUse
		{
			get { return _inUse; }
			set { _inUse = value; }
		}

		[DisplayName("Заметка"),
		Description("Дополнительная информация о военнослужащем.")]
		public String note
		{
			get { return _note; }
			set { _note = value; }
		}

		[DisplayName("Поставленная задача"),
		Description("Задача, выполняемая военнослужащим в данный момент."),
		TypeConverter(typeof(cTaskConverter))] // Добавляет список стандартных значений.
		public String task
		{
			get { return _task; }
			set { _task = value; }
		}

		/// <summary>
		/// Конструктор по умолчанию.
		/// </summary>
		public cSoldier()
		{
			_contract = false;
			_inUse = true;
			_post = "Водитель";
			_rank = "ряд.";
			_name = "";
			_place = "";
			_task = "";
			_note = "";
		}

		/// <summary>
		/// Отображение военнослужащего в списке.
		/// </summary>
		/// <returns></returns>
		public override String ToString()
		{
			if (String.IsNullOrEmpty(_name))
				return "(Новый военнослужащий)";
			else
				return String.Format("{0}{1}{2}{3}{4}",
								String.IsNullOrEmpty(_post) ? "" : String.Format("{0} ", _post),
								String.IsNullOrEmpty(_rank) ? "" : String.Format("{0} ", _rank),
								cPp.getStringAsArgument(cPp.getStringWithoutTags(_name)),
								String.IsNullOrEmpty(_note) ? "" : String.Format("● {0} ", _note),
								String.IsNullOrEmpty(_task) ? "" : String.Format("● {0} ", _task));
		}
    }

	/// <summary>
	/// Запись для ведения истории личного состава.
	/// </summary>
	[Serializable]
	public class cSoldiers
	{
		public List<Object> soldiers; // Личный состав.
		public DateTime date; // Число, за которое сделан снимок (по числу будем определять, нужно ли создавать новый).

		public cSoldiers()
		{
			soldiers = new List<Object>();
			date = DateTime.Now;
		}
	}

	/// <summary>
	/// Данные по личному составу.
	/// </summary>
	[Serializable]
	public class cSoldierTab : cTab
	{
		protected static Font _boldFont = new Font(SystemFonts.DialogFont, FontStyle.Bold); // Шрифт для отображения контрактников.

		private List<cSoldiers> _records; // Список личного состава за период времени.
		[NonSerialized]
		private int _recordIndex; // Текущая запись.

		public cSoldierTab()
		{
			_records = new List<cSoldiers>();
			addRecord(new cSoldiers());
		}

		public override List<object> list
		{
			get { return _records[_recordIndex].soldiers; }
		}

		public List<cSoldiers> records
		{
			get { return _records; }
		}

		public cSoldiers record
		{
			get { return _records[_recordIndex]; }
		}

		public int recordIndex
		{
			get
			{
				return _recordIndex;
			}
			set
			{
				if (value > -1 && value < _records.Count) _recordIndex = value; else _recordIndex = 0;
			}
		}

		public void addRecord(cSoldiers soldiersRecord)
		{
			cSoldiers soldiers = soldiersRecord;
			soldiers.date = DateTime.Now;
			_records.Add(soldiers);
			_recordIndex = _records.Count - 1;
		}

		public void removeRecord(int index)
		{
			if (index > -1 && index < _records.Count && _records.Count > 1)
			{
				_records.RemoveAt(index);
				if (index <= _recordIndex) _recordIndex--;
			}
		}

		/// <summary>
		/// Удаление всех записей кроме последней.
		/// </summary>
		public void removeAllButOneRecords()
		{
			for (int i = _records.Count - 2; i >= 0; i--)
			{
				_records.RemoveAt(i);
			}
			_recordIndex = 0;
		}

		public override void add()
		{
			list.Add(new cSoldier());
		}

		public override Color getColor(int index)
		{
			String task = ((cSoldier)list[index]).task; // Задача военнослужащего.
			foreach (cTask t in cPp.db.tasks.list)
			{
				if (t.name == task) return t.color;
			}
			return base.getColor(index);
		}

		public override Color getTextColor(int index)
		{
			if (((cSoldier)list[index]).inUse == false) return SystemColors.GrayText;
			return base.getTextColor(index);
		}

		public override Font getFont(int index)
		{
			if (((cSoldier)list[index]).contract == true)
				return _boldFont;
			else
				return base.getFont(index);
		}
	}

	/// <summary>
	/// Отображение списка с задачами в PropertyGrid.
	/// </summary>
	public class cTaskConverter: TypeConverter // Необходимо для отображения класса в PropertyView.
	{
		public const String no = "(Нет)"; // Без поставленной задачи.
		private List<String> _values;

		public cTaskConverter()
		{
			_values = new List<String>();
		}

		/// <summary>
		/// Включает поддержку предустановленных значений.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			return true;
		}

		/// <summary>
		/// Получение списка предустановленных значений.
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
		{
			_values.Clear();
			_values.Add(no);
			foreach (cTask t in cPp.db.tasks.list) _values.Add(t.name);
			return new StandardValuesCollection(_values);
		}

		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			if (destinationType == typeof(String))
				return true;
			else
				return base.CanConvertTo(context, destinationType);
		}

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
		{
			if (value != null && value.GetType() == typeof(String))
			{
				if (String.IsNullOrEmpty((String)value)) return no; else return (String)value;
			}
			else
				return base.ConvertTo(context, culture, value, destinationType);
		}

		public override bool CanConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Type sourceType)
		{
			if (sourceType == typeof(String))
				return true;
			else
				return base.CanConvertFrom(context, sourceType);
		}

		public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
			if (value.GetType() == typeof(String))
			{
				if ((String)value == no) return ""; else return (String)value;
			}
			else
				return base.ConvertFrom(context, culture, value);
        }
    }

	/// <summary>
	/// Преобразование Boolean типа в приличный вид для отображения в PropertyGrid.
	/// </summary>
	class cBooleanConverter: BooleanConverter
	{
		public const String yes = "Да";
		public const String no = "Нет";

		public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destType)
		{
			return (bool)value ? yes : no;
		}

		public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
		{
			return (string)value == yes;
		}
	}
}
