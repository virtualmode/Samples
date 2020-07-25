using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace pp
{
	/// <summary>
	/// Класс для хранения настроек редактора.
	/// </summary>
	[Serializable]
	public class cSettings
	{
		public const String settingsFolderName = "pp";
		public const String settingsFileName = "settings.bin";

		public int propertiesWidth; // Ширина панели со свойствами.
		// Размер основной формы и состояние:
		public bool fPpMaximized;
		public Rectangle fPpRectangle;

		/// <summary>
		/// Установка настроек по умолчанию:
		/// </summary>
		public cSettings()
		{
			propertiesWidth = 320;
			fPpMaximized = true;
			fPpRectangle = new Rectangle(10, 10, 800, 600);
		}

		/// <summary>
		/// Получение полного пути к файлу с настройками.
		/// </summary>
		/// <returns></returns>
		public static String getSettingsFileName()
		{
			return String.Format("{0}/{1}", cSettings.getSettingsFolderName(), cSettings.settingsFileName);
		}

		/// <summary>
		/// Получение полного пути к каталогу с настройками и шаблонами редактора.
		/// </summary>
		/// <returns></returns>
		public static String getSettingsFolderName()
		{
			return String.Format("{0}/{1}", Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), cSettings.settingsFolderName);
		}

		/// <summary>
		/// Загрузка настроек.
		/// </summary>
		/// <returns></returns>
		public static cSettings deserialize()
		{
			cSettings result = new cSettings(); // Установка настроек по умолчанию.
			Stream settingsFile = null;
			try
			{
				settingsFile = File.OpenRead(cSettings.getSettingsFileName());
				if (settingsFile != null)
				{
					BinaryFormatter formatter = new BinaryFormatter();
					cSettings deserialized = (cSettings)formatter.Deserialize(settingsFile);
					result = deserialized; // Если try выполнен до этого места, значит настройки загружены успешно.
				}
			}
			catch
			{
				// В этом месте можно вывести сообщение о неудачной загрузке настроек.
			}
			finally
			{
				if (settingsFile != null) settingsFile.Close();
			}
			return result;
		}

		/// <summary>
		/// Сохранение настроек.
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public static bool serialize(cSettings settings)
		{
			bool result = true;
			Stream settingsFile = null;
			try
			{
				Directory.CreateDirectory(cSettings.getSettingsFolderName()); // Если необходимо, создается директория для хранения настроек.
				settingsFile = File.Create(cSettings.getSettingsFileName());
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(settingsFile, settings);
			}
			catch
			{
				result = false;
			}
			finally
			{
				if (settingsFile != null) settingsFile.Close();
			}
			return result;
		}
	}
}
