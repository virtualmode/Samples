using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Drawing.Design;
using System.ComponentModel;
using System.Windows.Forms.Design;

namespace pp
{
	[Serializable]
	public class cReport
	{
		protected const String _defaultName = "Report.txt";
		protected const String _variablePlace = "<variable{0}/>";
		protected const String _variablePlaceEx = "&lt;variable{0}/&gt;";

		protected String _template; // HTML c отчетом. <variable0/> - место для вставки отчета.

		[Browsable(false)]
		public virtual String name { get { return _defaultName; } }

		[Browsable(false)]
		public virtual int variableCount { get { return 1; } }

		public cReport()
		{
			// В порожденном файле. _template = "код отчета".
			_template = _variablePlaceEx;
		}

		[DisplayName("Шаблон"),
		Description("Шаблон, по которому формируется отчёт. Изменения в шаблоне вступают в силу после сохранения расхода."),
		Editor(typeof(cTemplateEditor), typeof(UITypeEditor))]
		public cReport report
		{
			get { return this; }
		}

		public override string ToString()
		{
			return "(Редактировать)";
		}

		/// <summary>
		/// Выполняется каждый раз, когда пользователь выбирает отчет в списке.
		/// </summary>
		public virtual void afterSelect() {}

		public String getReportFile()
		{
			return String.Format("{0}\\{1}", cSettings.getSettingsFolderName(), name);
		}

		public void save()
		{
			StreamWriter sw = new StreamWriter(getReportFile(), false, Encoding.UTF8);
			sw.Write(_template);
			sw.Close();
		}

		public void edit()
		{
			Directory.CreateDirectory(cSettings.getSettingsFolderName()); // Если необходимо, создается директория для хранения настроек.
			if (!File.Exists(getReportFile()))
			{
				// сохранение:
				save();
			}
			Process.Start(getReportFile());
		}

		public void open()
		{
			if (File.Exists(getReportFile()))
			{
				StreamReader sr = new StreamReader(getReportFile(), true);
				_template = sr.ReadToEnd();
				sr.Close();
			}
		}

		/// <summary>
		/// Получает HTML-код отдельной переменной.
		/// </summary>
		/// <param name="variableIndex"></param>
		/// <returns></returns>
		protected virtual String getVariableHtml(int variableIndex)
		{
			return "Пустой отчёт";
		}

		/// <summary>
		/// Получает HTML-код отчёта.
		/// </summary>
		/// <param name="variableCount">Количество переменных в отчёте.</param>
		/// <returns></returns>
		public virtual String getHtml()
		{
			String result = _template, // Готовый код отчёта.
					variable; // Переменная для поиска.
			for (int i = 0; i < variableCount; i++)
			{
				variable = String.Format(_variablePlace, i);
				result = result.Replace(variable, getVariableHtml(i));
			}
			return result;
		}

		/// <summary>
		/// Получение месяца прописью в родительном падеже.
		/// </summary>
		/// <param name="month"></param>
		/// <returns></returns>
		public static String getMonth(int month)
		{
			switch (month)
			{
				case 1:
					return "января";
				case 2:
					return "февраля";
				case 3:
					return "марта";
				case 4:
					return "апреля";
				case 5:
					return "мая";
				case 6:
					return "июня";
				case 7:
					return "июля";
				case 8:
					return "августа";
				case 9:
					return "сентября";
				case 10:
					return "октября";
				case 11:
					return "ноября";
				default:
					return "декабря";
			}
		}
	}

	public class cTemplateEditor : UITypeEditor
	{
		/// <summary>
		/// Реализация метода редактирования
		/// </summary>
		public override Object EditValue(ITypeDescriptorContext context, IServiceProvider provider, Object value)
		{
			if ((context != null) && (provider != null))
			{
				cReport r = (cReport)value;
				r.edit();
				// Было произведено редактирование (скорее всего):
				cPp.db.changed = true;
				cPp.pp.updateCaption();
				cPp.flushMemory();
			}
			return base.EditValue(context, provider, value);
		}

		/// <summary>
		/// Возвращаем стиль редактора - выпадающее окно
		/// </summary>
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			if (context != null)
				return UITypeEditorEditStyle.Modal;
			else
				return base.GetEditStyle(context);
		}

	}
}
