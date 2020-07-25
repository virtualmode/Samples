using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Drawing;

namespace rsrcs
{
  [Serializable]
  struct sOptions
  {
    public string Topic;

    public sOptions(string topic)
    {
      Topic = topic;
    }
  }

  [Serializable]
  struct sSoldier
  {
    public sSoldier(string profession, string group, string category, string fio, bool money, string date, string task)
    {
      Profession = profession;
      Category = category;
      FIO = fio;
      Date = date;
      Group = group;
      Task = task;
      Money = money;
    }

    public string Profession, Category, FIO, Date, Task, Group;
    public bool Money;
  }

  [Serializable]
  struct sTask
  {
    public sTask(string name, string group, Color selection)
    {
      Name = name;
      Group = group;
      Selection = selection;
    }

    public string Name, Group;
    public Color Selection;
  }

  [Serializable]
  class cRsrcs
  {
    public sOptions Options = new sOptions();
    public List<sSoldier> Soldiers = null;
    public List<sTask> Tasks = null;

    public cRsrcs()
    {
      Soldiers = new List<sSoldier>();
      Tasks = new List<sTask>();
    }

    /// <summary>
    /// Сохранение расхода.
    /// </summary>
    /// <param name="file"></param>
    public bool Serialize(string file)
    {
      bool result = true;
      FileStream fs = null;
      try
      {
        fs = new FileStream(file, FileMode.Create);
        // Construct a BinaryFormatter and use it to serialize the data to the stream.
        BinaryFormatter formatter = new BinaryFormatter();
        formatter.Serialize(fs, Options);
        formatter.Serialize(fs, Soldiers);
        formatter.Serialize(fs, Tasks);
      }
      //catch (SerializationException e)
      catch
      {
        MessageBox.Show("Файл с расходом не может быть сохранен в данное место.", "Ошибка сохранения расхода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        result = false;
      }
      finally
      {
        if (fs != null) fs.Close();
      }
      return result;
    }

    /// <summary>
    /// Открытие расхода.
    /// </summary>
    /// <param name="file"></param>
    public bool Deserialize(string file)
    {
      bool result = true;
      Soldiers.Clear();
      FileStream fs = null;
      try
      {
        // Open the file containing the data that you want to deserialize.
        fs = new FileStream(file, FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        // Deserialize the hashtable from the file and 
        // assign the reference to the local variable.
        Options = (sOptions)formatter.Deserialize(fs);
        Soldiers = (List<sSoldier>)formatter.Deserialize(fs);
        Tasks = (List<sTask>)formatter.Deserialize(fs);
      }
      catch
      {
        MessageBox.Show("Файл с расходом поврежден, или защищен от записи / чтения.", "Ошибка открытия расхода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        result = false;
      }
      finally
      {
        if (fs != null) fs.Close();
      }
      return result;
    }
  }
}
