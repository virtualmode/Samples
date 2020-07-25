/*
	Редактор расходов. Поможет ускорить и упростить создание расхода личного состава.
	Автор: © virtualmode, 2011.

	Permission is hereby granted, free of charge, to any person obtaining a copy
	of this software and associated documentation files (the "Software"), to deal
	in the Software without restriction, including without limitation the rights
	to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
	copies of the Software, and to permit persons to whom the Software is
	furnished to do so, subject to the following conditions:

	The above copyright notice and this permission notice shall be included in
	all copies or substantial portions of the Software.

	THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
	IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
	FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
	AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
	LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
	OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
	THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace pp
{
	/// <summary>
	/// Основной класс редактора расходов.
	/// </summary>
	static class cPp
	{
		[DllImport("kernel32.dll")]
		public static extern bool SetProcessWorkingSetSize(IntPtr proc, int min, int max);

		public const String name = "Редактор расходов";
		public const String stuff = "Необходимо написать метод.";

		public static cSettings settings = null; // Настройки приложения.
		public static cDb db = null; // База данных.

		// Основное окно редактора:
		private static fPp _pp = null;
		public static fPp pp { get { return _pp; } }

		/// <summary>
		/// Точка входа для приложения.
		/// </summary>
		[STAThread]
		public static void Main()
		{
			// Удаление старых шаблонов:
			try
			{
				foreach (String fileName in Directory.GetFiles(cSettings.getSettingsFolderName()))
				{
					if (Path.GetFileName(fileName) != cSettings.settingsFileName) File.Delete(fileName);
				}
			}
			catch {}
			// Запуск приложения:
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			_pp = new fPp(); 
			Application.Run(_pp);
		}

		/// <summary>
		/// Метод получения строки без тегов.
		/// </summary>
		/// <param name="parsingString"></param>
		/// <returns></returns>
		public static String getStringWithoutTags(String parsingString)
		{
			for (int i = 0; i < parsingString.Length; i++)
			{
				if (parsingString[i] == '<') return parsingString.Substring(0, i).Trim();
			}
			return parsingString.Trim();
		}

		public static Boolean haveTags(String parsingString)
		{
			return parsingString.IndexOf('<') != -1;
		}

		public static String getStringAsArgument(String parsingString)
		{
			return String.IsNullOrWhiteSpace(parsingString) ? "" : String.Format("{0} ", getStringWithoutTags(parsingString).Trim());
		}

		public static void flushMemory()
		{
			GC.Collect();
			GC.WaitForPendingFinalizers();
			//if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
		}
	}

	/// <summary>
	/// Класс для клонирования сериализуемых объектов.
	/// </summary>
	public static class ObjectCloner
	{
		public static T DeepClone<T>(T source) where T : class
		{
			MemoryStream stream = new MemoryStream();
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.Serialize(stream, source);
			stream.Position = 0;
			return (T)formatter.Deserialize(stream);
		}
	}
}
