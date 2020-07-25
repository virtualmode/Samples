using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace pp
{
	/// <summary>
	/// Родительский класс для работы со списками (личного состава, ГСМ, нарядов и т.д.)
	/// </summary>
	[Serializable]
	public class cTab
	{
		private List<Object> _list; // Записи по умолчанию.
		public virtual List<Object> list { get { return _list; } }

		public cTab()
		{
			_list = new List<Object>();
		}

		/// <summary>
		/// Добавления нового объекта в список.
		/// </summary>
		public virtual void add()
		{
			throw new Exception(cPp.stuff);
		}

		/// <summary>
		/// Удаление существующего объекта из списка.
		/// </summary>
		/// <param name="index"></param>
		public virtual void remove(int index)
		{
			list.RemoveAt(index);
		}

		/// <summary>
		/// Перемещение объекта из одного места списка в другое.
		/// </summary>
		/// <param name="destinationIndex"></param>
		/// <param name="sourceIndex"></param>
		public virtual void move(int destinationIndex, int sourceIndex)
		{
			if (destinationIndex != sourceIndex)
			{
				if (destinationIndex < sourceIndex)
				{
					list.Insert(destinationIndex, list[sourceIndex]);
					list.RemoveAt(sourceIndex + 1);
				}
				else
				{
					list.Insert(destinationIndex + 1, list[sourceIndex]);
					list.RemoveAt(sourceIndex);
				}
			}
		}

		/// <summary>
		/// Определение стиля текста для некоторой записи.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual String getText(int index)
		{
			return String.Format("{0}. {1}", index + 1, list[index].ToString());
		}

		/// <summary>
		/// Получение указателя на запись.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual Object getObject(int index)
		{
			return list[index];
		}

		/// <summary>
		/// Получение цвета заднего фона для записи.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual Color getColor(int index)
		{
			return SystemColors.Window;
		}

		/// <summary>
		/// Получение цвета текста для записи.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual Color getTextColor(int index)
		{
			return SystemColors.WindowText;
		}

		/// <summary>
		/// Получение шрифта для записи.
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public virtual Font getFont(int index)
		{
			return SystemFonts.DefaultFont;
		}
	}
}
