using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace rsrcs
{
  public partial class fRsrcs : Form
  {
    private const string _rsrcsFilter = "Файлы расходов (*.rsh)|*.rsh|Все файлы (*.*)|*.*";
    private string _file = null;

    public fRsrcs()
    {
      InitializeComponent();
    }

    private void fRsrcs_Load(object sender, EventArgs e)
    {
      // Справка:
      lAuthor.Text = "Автор: © virtualmode.\n\r\n\rДМБ Осень 2011 г.";
      // Установка значений по умолчанию:
      CreateRsrcs();
      UpdateCaption();
      UpdateSoldiers();
      UpdateTasks();
      // Загрузка файла:
      string[] args = Environment.GetCommandLineArgs();
      if (args.Length > 1)
      {
        OpenRsrcs(args[1]);
      }
    }

    /// <summary>
    /// Создание нового расхода.
    /// </summary>
    private void CreateRsrcs()
    {
      // Сброс файла:
      _file = null;
      // Обнуление настроек:
      tbTopic.Text = "Расход личного состава";
      dtpFrom.Value = DateTime.Today;
      dtpTo.Value = DateTime.Today.AddDays(1);
      // Обнуление списков:
      dgvSoldiers.Rows.Clear();
      dgvTasks.Rows.Clear();
      UpdateCaption();
    }

    /// <summary>
    /// Обновление заголовка окна в соответствии с открытым расходом.
    /// </summary>
    private void UpdateCaption()
    {
      const string appName = "Редактор расходов";
      if (String.IsNullOrEmpty(_file))
        Text = String.Format("Безымянный - {0}", appName);
      else
        Text = String.Format("{0} - {1}", _file, appName);
    }

    /// <summary>
    /// Обновление статистики штата.
    /// </summary>
    private void UpdateSoldiers()
    {
      tpSoldiers.Text = String.Format("Штат - {0} чел.", dgvSoldiers.Rows.Count - 1);
      for (int i = 0; i < dgvSoldiers.Rows.Count - 1; i++)
      {
        dgvSoldiers["cSLine", i].Value = String.Format("{0}", i + 1);
        dgvSoldiers.Rows[i].DefaultCellStyle.BackColor = GetNariadColor((string)dgvSoldiers["cTask", i].Value);
        // Снятие задачи:
        if (!String.IsNullOrEmpty((string)dgvSoldiers["cTask", i].Value))
        {
          bool flag = false;
          foreach (DataGridViewRow r in dgvTasks.Rows)
          {
            if (r.Index < dgvTasks.Rows.Count - 1 && !String.IsNullOrEmpty((string)r.Cells["cName"].Value) && String.Compare((string)r.Cells["cName"].Value, (string)dgvSoldiers["cTask", i].Value) == 0)
            {
              flag = true;
              break;
            }
          }
          if (!flag) dgvSoldiers["cTask", i].Value = "";
        }
      }
    }

    /// <summary>
    /// Обновление статистики задач.
    /// </summary>
    private void UpdateTasks()
    {
      tpTasks.Text = String.Format("Задачи - {0} шт.", dgvTasks.Rows.Count - 1);
      for (int i = 0; i < dgvTasks.Rows.Count - 1; i++)
      {
        dgvTasks["cTLine", i].Value = String.Format("{0}", i + 1);
      }
    }

    private void dgvSoldiers_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      UpdateSoldiers();
    }

    private void dgvSoldiers_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
      UpdateSoldiers();
    }

    private void dgvTasks_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
    {
      UpdateTasks();
    }

    private void dgvTasks_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
    {
      // Обновление интерфейса:
      UpdateTasks();
      UpdateSoldiers();
    }

    private bool SaveRsrcs(string file)
    {
      // В _file адрес, куда сохранять.
      cRsrcs cs = new cRsrcs();
      DataGridViewRow r = null;
      // Сохранение настроек:
      cs.Options.Topic = tbTopic.Text;
      // Сохранение штатки:
      for (int i = 0; i < dgvSoldiers.Rows.Count - 1; i++)
      {
        r = dgvSoldiers.Rows[i];
        cs.Soldiers.Add(new sSoldier((string)(r.Cells["cProfession"].Value == null ? "" : r.Cells["cProfession"].Value),
                                     (string)(r.Cells["cGroup"].Value == null ? "" : r.Cells["cGroup"].Value),
                                     (string)(r.Cells["cCategory"].Value == null ? "" : r.Cells["cCategory"].Value),
                                     (string)(r.Cells["cFIO"].Value == null ? "" : r.Cells["cFIO"].Value),
                                     (bool)(r.Cells["cMoney"].Value == null ? false : r.Cells["cMoney"].Value),
                                     (string)(r.Cells["cDate"].Value == null ? "" : r.Cells["cDate"].Value),
                                     (string)(r.Cells["cTask"].Value == null ? "" : r.Cells["cTask"].Value)));
      }
      // Сохранение задач и нарядов:
      for (int i = 0; i < dgvTasks.Rows.Count - 1; i++)
      {
        r = dgvTasks.Rows[i];         
        cs.Tasks.Add(new sTask((string)(r.Cells["cName"].Value == null ? "" : r.Cells["cName"].Value),
                               (string)(r.Cells["cTGroup"].Value == null ? "" : r.Cells["cTGroup"].Value),
                               (Color)r.DefaultCellStyle.BackColor));
      }
      // Запись в файл:
      if (cs.Serialize(file))
      {
        _file = file;
        UpdateCaption();
        return true;
      }
      UpdateCaption();
      return false;
    }

    private bool SaveAsRsrcs()
    {
      using (SaveFileDialog sfd = new SaveFileDialog())
      {
        sfd.AddExtension = true;
        sfd.CheckPathExists = true;
        sfd.Filter = _rsrcsFilter;
        sfd.FilterIndex = 1;
        sfd.OverwritePrompt = true;
        sfd.RestoreDirectory = true;
        sfd.Title = "Сохранение расхода...";
        if (sfd.ShowDialog() == DialogResult.OK)
        {
          SaveRsrcs(sfd.FileName);
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    private void msSaveAs_Click(object sender, EventArgs e)
    {
      SaveAsRsrcs();
    }

    private void msSave_Click(object sender, EventArgs e)
    {
      if (String.IsNullOrEmpty(_file)) SaveAsRsrcs(); else SaveRsrcs(_file);
    }

    private bool CloseAndSaveSoldiers()
    {
      switch (MessageBox.Show("Сохранить текущий расход перед закрытием?", "Сохранение...", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3))
      {
        case DialogResult.No:
          return true;
        case DialogResult.Yes:
          if (String.IsNullOrEmpty(_file)) return SaveAsRsrcs(); else return SaveRsrcs(_file);
        default:
          return false;
      }
    }

    private void OpenRsrcs(string file)
    {
      cRsrcs cs = new cRsrcs();
      if (cs.Deserialize(file))
      {
        // Открытие настроек:
        tbTopic.Text = cs.Options.Topic;
        // Открытие задач и нарядов:
        dgvTasks.Rows.Clear();
        for (int i = 0; i < cs.Tasks.Count; i++)
        {
          dgvTasks.Rows[dgvTasks.Rows.Add("", cs.Tasks[i].Name, cs.Tasks[i].Group)].DefaultCellStyle.BackColor = cs.Tasks[i].Selection;
        }
        // Открытие штатки:
        dgvSoldiers.Rows.Clear();
        for (int i = 0; i < cs.Soldiers.Count; i++)
        {
          dgvSoldiers.Rows.Add("",
                               cs.Soldiers[i].Profession,
                               cs.Soldiers[i].Group,
                               cs.Soldiers[i].Category,
                               cs.Soldiers[i].FIO,
                               cs.Soldiers[i].Money,
                               cs.Soldiers[i].Date,
                               cs.Soldiers[i].Task);
        }
        // Обновление интерфейса:
        tcRsrcs.SelectedTab = tcRsrcs.TabPages[0];
        _file = file;
        UpdateCaption();
        UpdateSoldiers();
      }
    }

    private void msOpen_Click(object sender, EventArgs e)
    {
      if (CloseAndSaveSoldiers())
      {
        // Открытие нового файла.
        using (OpenFileDialog ofd = new OpenFileDialog())
        {
          ofd.AddExtension = true;
          ofd.CheckFileExists = true;
          ofd.CheckPathExists = true;
          ofd.Filter = _rsrcsFilter;
          ofd.FilterIndex = 1;
          ofd.Multiselect = false;
          ofd.RestoreDirectory = true;
          ofd.Title = "Открытие расхода...";
          if (ofd.ShowDialog() == DialogResult.OK)
          {
            OpenRsrcs(ofd.FileName);
          }
        }
      }
    }

    private void msNew_Click(object sender, EventArgs e)
    {
      if (CloseAndSaveSoldiers())
      {
        // Создание нового файла.
        CreateRsrcs();
      }
    }

    private void UnselectSoldiers()
    {
      foreach (DataGridViewRow r in dgvSoldiers.Rows)
      {
        r.Selected = false;
      }
      foreach (DataGridViewRow r in dgvTasks.Rows)
      {
        r.Selected = false;
      }
    }

    private void msSLink_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow r in dgvSoldiers.SelectedRows)
      {
        if (r.Index < dgvSoldiers.Rows.Count - 1) // Только непустые строки:
        {
          r.Cells["cTask"].Value = ((ToolStripMenuItem)sender).Text;
        }
      }
      UpdateSoldiers();
    }

    private void dgvSoldiers_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex != -1 && e.ColumnIndex != -1 && e.Button == MouseButtons.Right)
      {
        // Обработка меню назначения:
        msSLink.DropDownItems.Clear();
        for (int i = 0; i < dgvTasks.Rows.Count - 1; i++)
        {
          msSLink.DropDownItems.Add((string)dgvTasks["cName", i].Value).Click += new System.EventHandler(msSLink_Click);
        }
        // Обработка интерфейса:
        if (!dgvSoldiers.Rows[e.RowIndex].Selected) UnselectSoldiers();
        dgvSoldiers.Rows[e.RowIndex].Selected = true;
        DataGridViewCell c = dgvSoldiers[e.ColumnIndex, e.RowIndex];
        cmsSoldiers.Show(MousePosition.X, MousePosition.Y);
      }
    }

    private bool _contextFlag = false;

    private void cbSMove_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (!_contextFlag) cmsSoldiers.Hide();
    }

    private void cmsSoldiers_Opening(object sender, CancelEventArgs e)
    {
      if (dgvSoldiers.SelectedRows.Count > 0)
      {
        _contextFlag = true;
        int index = dgvSoldiers.SelectedRows[0].Index;
        if (index < dgvSoldiers.Rows.Count - 1)
        {
          cmsSoldiers.Enabled = true;
        }
        else
        {
          cmsSoldiers.Enabled = false;
        }
        _contextFlag = false;
      }
    }

    private void dgvTasks_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.RowIndex != -1 && e.Button == MouseButtons.Right)
      {
        // Обработка интерфейса:
        if (!dgvTasks.Rows[e.RowIndex].Selected) UnselectSoldiers();
        dgvTasks.Rows[e.RowIndex].Selected = true;
        DataGridViewCell c = dgvTasks[e.ColumnIndex, e.RowIndex];
        cmsTasks.Show(MousePosition.X, MousePosition.Y);
      }
    }

    private void cmsTasks_Opening(object sender, CancelEventArgs e)
    {
      if (dgvTasks.SelectedRows.Count > 0)
      {
        _contextFlag = true;
        int index = dgvTasks.SelectedRows[0].Index;
        if (index < dgvTasks.Rows.Count - 1)
        {
          cmsTasks.Enabled = true;
        }
        else
        {
          cmsTasks.Enabled = false;
        }
        _contextFlag = false;
      }
    }

    /// <summary>
    /// Выбор цвета для конкретного наряда:
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void msColor_Click(object sender, EventArgs e)
    {
      using (ColorDialog cd = new ColorDialog())
      {
        cd.AllowFullOpen = true;
        cd.SolidColorOnly = false;
        cd.FullOpen = false;
        cd.AnyColor = true;
        if (cd.ShowDialog() == DialogResult.OK)
        {
          foreach (DataGridViewRow r in dgvTasks.SelectedRows)
          {
            if (r.Index < dgvTasks.Rows.Count - 1) // Только непустые строки:
            {
              r.DefaultCellStyle.BackColor = cd.Color;
            }
          }
        }
      }
    }

    /// <summary>
    /// Определение цвета для выбранного наряда.
    /// </summary>
    /// <param name="nariad"></param>
    /// <returns></returns>
    private Color GetNariadColor(string nariad)
    {
      for (int i = 0; i < dgvTasks.Rows.Count - 1; i++)
      {
        if ((string)dgvTasks["cName", i].Value == nariad)
        {
          return dgvTasks.Rows[i].DefaultCellStyle.BackColor;
        }
      }
      return SystemColors.Window;
    }

    private void msSReset_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow r in dgvSoldiers.SelectedRows)
      {
        if (r.Index < dgvSoldiers.Rows.Count - 1) // Только непустые строки:
        {
          r.Cells["cTask"].Value = "";
        }
      }
      UpdateSoldiers();
    }

    private void fRsrcs_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!CloseAndSaveSoldiers()) e.Cancel = true;
    }

    private void msExit_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void msSDelete_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow r in dgvSoldiers.SelectedRows)
      {
        dgvSoldiers.Rows.Remove(r);
      }
    }

    private void msTDelete_Click(object sender, EventArgs e)
    {
      foreach (DataGridViewRow r in dgvTasks.SelectedRows)
      {
        dgvTasks.Rows.Remove(r);
      }
    }

    /// <summary>
    /// Обновление расхода.
    /// </summary>
    public void UpdatePreview(bool updateGroups)
    {
      cRsrcsNode r = new cRsrcsNode(0, -1, false, false);
      wbPreview.DocumentText = r.GetHtml(tbTopic.Text, dgvSoldiers, dgvTasks, dtpFrom, cbMoney.Checked, clbGroups, updateGroups);
    }

    private void tcRsrcs_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (tcRsrcs.SelectedTab.Name == tpRsrcs.Name) // Открыта вкладка с расходом.
      {
        //wbPreview.Navigate(Application.StartupPath + "/index.htm");
        UpdatePreview(true);
      }
    }

    private void bUpdate_Click(object sender, EventArgs e)
    {
      UpdatePreview(false);
    }

    private void dgvSoldiers_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
      if (e.Column.Name == "cSLine")
      {
        double a = Convert.ToDouble(e.CellValue1), b = Convert.ToDouble(e.CellValue2);
        if (a == b)
        {
          e.SortResult = 0;
        }
        else
        {
          if (a > b) e.SortResult = -1; else e.SortResult = 1;
        }
      }
      e.Handled = true;
    }

    private bool sortMode = false;

    private void dgvSoldiers_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex == dgvSoldiers.Columns["cSLine"].Index)
      {
        sortMode = !sortMode;
        dgvSoldiers.Sort(dgvSoldiers.Columns[e.ColumnIndex], sortMode ? ListSortDirection.Ascending : ListSortDirection.Descending);
      }
    }

    private void dgvTasks_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
    {
      if (e.Column.Name == "cTLine")
      {
        double a = Convert.ToDouble(e.CellValue1), b = Convert.ToDouble(e.CellValue2);
        if (a == b)
        {
          e.SortResult = 0;
        }
        else
        {
          if (a > b) e.SortResult = -1; else e.SortResult = 1;
        }
      }
      e.Handled = true;
    }

    private void dgvTasks_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
    {
      if (e.ColumnIndex == dgvTasks.Columns["cTLine"].Index)
      {
        sortMode = !sortMode;
        dgvTasks.Sort(dgvTasks.Columns[e.ColumnIndex], sortMode ? ListSortDirection.Ascending : ListSortDirection.Descending);
      }
    }

    private void dtpFrom_ValueChanged(object sender, EventArgs e)
    {
      //bUpdate_Click(null, null);
    }

    private void cbMoney_CheckedChanged(object sender, EventArgs e)
    {
      //bUpdate_Click(null, null);
    }
  }

  class cRsrcsNode
  {
    public int Index = -1; // Индекс военнослужащего по штатке.
    protected bool Kontrakt = false;
    protected bool Free = false; // свободн. от нарядов.
    protected int Count = 0; // Количество солдат в поддереве.
    protected int Deep = 0; // Глубина дерева.
    protected List<int> naLico = new List<int>();
    public string Group = ""; // Название группы, в которую входит военнослужащий.
    public List<cRsrcsNode> Nodes = new List<cRsrcsNode>(); // Дочерние элементы.

    public cRsrcsNode(int deep, int index, bool kontrakt, bool free)
    {
      Deep = deep;
      Index = index;
      Kontrakt = kontrakt;
      Free = free;
    }

    private string GetMonth(int month)
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

    private string GetGroupName(string parsingString, int deep)
    {
      int word = 0, start = 0;
      parsingString = String.Format("{0}{1}", parsingString, ",");
      for (int i = 1; i < parsingString.Length; i++)
      {
        if (parsingString[i] == ',') // Нашли конец слова.
        {
          if (word == deep)
          {
            return parsingString.Substring(start, i - start).Trim();
          }
          else
          {
            start = i + 1;
            word++;
          }
        }
      }
      return null;
    }

    private int GetGroupIndex(cRsrcsNode root, string group)
    {
      foreach (cRsrcsNode n in root.Nodes)
      {
        if (String.Compare(n.Group, group) == 0) return n.Index;
      }
      return -1;
    }

    private void InsertSoldier(int table, int index, string parsingString, cRsrcsNode parent, int deep, string nariad, string nariadGroup, bool kontrakt, bool free)
    {
      // Вспомогательные переменные:
      string group; // Ищем в parent группу с именем group:
      // Определяем, какого служащего добавляем. Свободного или нет:
      if (nariad == null) // Свободного:
      {
        group = GetGroupName(parsingString, deep);
        if ((deep == 0 && group == null) || (deep == 1 && group == null)) return;
        parent.Count++; // Количество личного состава в поддереве.
        if (group == null) // значит элемент записываем в parent:
        {
          if (table != -1) naLico[table]++;
          parent.Nodes.Add(new cRsrcsNode(deep, index, kontrakt, free));
        }
        else // Необходимо дальше искать группу для элемента:
        {
          int ind = GetGroupIndex(parent, group);
          if (ind == -1) // Группу с таким именем не нашли, создаем новую:
          {
            cRsrcsNode n = new cRsrcsNode(deep + 1, parent.Nodes.Count, kontrakt, free);
            if (deep == 0) { table = parent.Nodes.Count; naLico.Add(0); } // Добавление 'на лицо' для новой таблицы.
            n.Group = group;
            parent.Nodes.Add(n);
            InsertSoldier(table, index, parsingString, n, deep + 1, nariad, nariadGroup, kontrakt, free);
          }
          else
          {
            if (deep == 0) { table = ind; } // На лицо уже есть, передаем только индекс.
            InsertSoldier(table, index, parsingString, parent.Nodes[ind], deep + 1, nariad, nariadGroup, kontrakt, free);
          }
        }
      }
      else // Добавление столбцов с нарядами:
      {
        switch (deep)
        {
          case 0:
            group = GetGroupName(parsingString, 0);
            break;
          case 1:
            group = nariadGroup;
            break;
          case 2:
            group = nariad;
            break;
          default:
            group = null;
            break;
        }
        parent.Count++; // Количество личного состава в поддереве.
        if (group == null)
        {
          parent.Nodes.Add(new cRsrcsNode(deep, index, kontrakt, free)); // ???.
        }
        else
        {
          int ind = GetGroupIndex(parent, group);
          if (ind == -1) // Группу с таким именем не нашли, создаем новую:
          {
            cRsrcsNode n = new cRsrcsNode(deep + 1, parent.Nodes.Count, kontrakt, free);
            n.Group = group;
            parent.Nodes.Add(n);
            InsertSoldier(-1, index, parsingString, n, deep + 1, nariad, nariadGroup, kontrakt, free);
          }
          else
          {
            InsertSoldier(-1, index, parsingString, parent.Nodes[ind], deep + 1, nariad, nariadGroup, kontrakt, free);
          }
        }
      }
    }

    /// <summary>
    /// Убирает подписи к фамилиям.
    /// </summary>
    /// <param name="parsingString"></param>
    /// <returns></returns>
    private string FormatFIO(string parsingString, bool withoutTags)
    {
      if (withoutTags)
      {
        for (int i = 0; i < parsingString.Length; i++)
        {
          if (parsingString[i] == '<') return parsingString.Substring(0, i).Trim();
        }
      }
      return parsingString.Trim();
    }

    public string GetHtml(string caption, DataGridView soldiers, DataGridView tasks, DateTimePicker day, bool money, CheckedListBox groups, bool updateGroups)
    {
      // Данный код создавался на скорую руку и требует оптимизации.
      // Создание html кода расхода:
      string result = "", topic1 = String.Format("{0} на ", caption), topic2 = String.Format("{0}-{1} {2} {3} г.", day.Value.Day, day.Value.AddDays(1).Day, GetMonth(day.Value.Month), day.Value.Year);

      // Создание дерева:
      Index = -1;
      Deep = 0;
      naLico.Clear();
      Nodes.Clear();
      // Составляем свободный штат:
      if (money) // Контрактники
      {
        foreach (DataGridViewRow r in soldiers.Rows)
        {
          if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
          {
            string work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
            bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
            if (String.IsNullOrEmpty(work) && kontra)
            {
              InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, null, null, kontra, true);
            }
          }
        }
      }
      foreach (DataGridViewRow r in soldiers.Rows)
      {
        if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
        {
          string work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
          bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
          if (String.IsNullOrEmpty(work) && !kontra)
          {
            InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, null, null, kontra, true);
          }
        }
      }
      // Составляем занятый штат с непустыми группами:
      if (money)
      {
        foreach (DataGridViewRow r in soldiers.Rows)
        {
          if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
          {
            bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
            string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
            bool founded = false;
            foreach (DataGridViewRow t in tasks.Rows)
            {
              if (t.Index < tasks.Rows.Count - 1)
              {
                nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
                group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
                if (work == nariad) // Только существующие строки:
                {
                  founded = true;
                  break;
                }
              }
            }
            if (founded && !String.IsNullOrEmpty(group) && kontra)
            {
              InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, false);
            }
          }
        }
      }
      foreach (DataGridViewRow r in soldiers.Rows)
      {
        if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
        {
          bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
          string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
          bool founded = false;
          foreach (DataGridViewRow t in tasks.Rows)
          {
            if (t.Index < tasks.Rows.Count - 1)
            {
              nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
              group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
              if (work == nariad) // Только существующие строки:
              {
                founded = true;
                break;
              }
            }
          }
          if (founded && !String.IsNullOrEmpty(group) && !kontra)
          {
            InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, false);
          }
        }
      }
      // Составляем занятый штат с пустыми группами:
      if (money)
      {
        foreach (DataGridViewRow r in soldiers.Rows)
        {
          if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
          {
            bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
            string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
            bool founded = false;
            foreach (DataGridViewRow t in tasks.Rows)
            {
              if (t.Index < tasks.Rows.Count - 1)
              {
                nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
                group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
                if (work == nariad) // Только существующие строки:
                {
                  founded = true;
                  break;
                }
              }
            }
            if (founded && String.IsNullOrEmpty(group) && kontra)
            {
              InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, true);
            }
          }
        }
      }
      foreach (DataGridViewRow r in soldiers.Rows)
      {
        if (r.Index < soldiers.Rows.Count - 1) // Только существующие строки:
        {
          bool kontra = r.Cells["cMoney"].Value == null ? false : (bool)r.Cells["cMoney"].Value;
          string nariad = "", group = "", work = r.Cells["cTask"].Value == null ? null : (string)r.Cells["cTask"].Value;
          bool founded = false;
          foreach (DataGridViewRow t in tasks.Rows)
          {
            if (t.Index < tasks.Rows.Count - 1)
            {
              nariad = t.Cells["cName"].Value == null ? null : (string)t.Cells["cName"].Value;
              group = t.Cells["cTGroup"].Value == null ? "" : (string)t.Cells["cTGroup"].Value;
              if (work == nariad) // Только существующие строки:
              {
                founded = true;
                break;
              }
            }
          }
          if (founded && String.IsNullOrEmpty(group) && !kontra)
          {
            InsertSoldier(-1, r.Index, r.Cells["cGroup"].Value == null ? "" : (string)r.Cells["cGroup"].Value, this, Deep, nariad, group, kontra, true);
          }
        }
      }
      // Получение максимального размера столбца:
      int maxGroup = 0;
      for (int i = 0; i < Nodes.Count; i++) // Таблицы.
      {
        for (int j = 0; j < Nodes[i].Nodes.Count; j++) // Группы.
        {
          int groupCount = 0;
          for (int k = 0; k < Nodes[i].Nodes[j].Nodes.Count; k++) // Подгруппы.
          {
            groupCount++;
            for (int l = 0; l < Nodes[i].Nodes[j].Nodes[k].Count; l++) // Военнослужащие.
            {
              groupCount++;
            }
          }
          if (maxGroup < groupCount) maxGroup = groupCount;
        }
      }
      // Создание списка подразделений (при необходимости):
      if (updateGroups)
      {
        groups.Items.Clear();
        for (int i = 0; i < Nodes.Count; i++)
        {
          groups.Items.Add(Nodes[i].Group, true);
        }
      }
      // Создание хтмл:
      result = String.Format("{0}{1}{2}{3}{4}{5}{6}{7}",
                             @"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd"">",
                             @"<html xmlns=""http://www.w3.org/1999/xhtml"" ><head><title>",
                             topic1 + topic2,
                             @"</title><style type=""text/css"">.font{font-family:""Verdana"", ""Tahoma"", ""Segoe UI"";font-size:6pt;vertical-align:middle;}.fontGroup{text-decoration:underline;text-align:center;font-style:italic;}.fontCell{font-size:5pt;text-align:left;}.cell{height:11px;border-style:solid;border-collapse:collapse;border-color:#000000;margin-bottom:0px;margin-left:0px;margin-right:0px;margin-top:0px;padding-bottom:0px;padding-left:3px;padding-right:3px;padding-top:0px;border-bottom-width:0px;border-left-width:0px;border-right-width:1px;border-top-width:0px;}.cellDark{background-color:#d8d8d8;}.cellGroup{border-bottom-width:2px;}.frame{border-collapse:collapse;border-style:solid;border-color:#000000;border-bottom-width:1px;border-left-width:1px;border-right-width:0px;border-top-width:1px;}</style></head><body class=""font""><table cellpadding=""0"" cellspacing=""0"" style=""width:100%;padding-left:10px;""><tr><td class=""fontGroup"" style=""padding-bottom:10px;font-size:8pt;text-decoration:none;"">",
                             topic1,
                             @"<strong>",
                             topic2,
                             @"</strong></td></tr><tr><td><table cellpadding=""0"" cellspacing=""0"" style=""width:100%;""><tr>");
      // Создание заголовков таблиц:
      for (int i = 0; i < Nodes.Count; i++)
      {
        if (!groups.CheckedIndices.Contains(i)) continue; // i-ая таблица не выбрана.
        result += String.Format("{0}{1}{2}", @"<td class=""fontGroup"" style=""text-decoration:none;"">", Nodes[i].Group, @"</td><td style=""width:10px;""></td>");
      }
      result += @"</tr><tr style=""height:3px;"">";
      for (int i = 0; i < Nodes.Count; i++)
      {
        if (!groups.CheckedIndices.Contains(i)) continue; // i-ая таблица не выбрана.
        result += String.Format(@"<td></td>");
      }
      // Заполнение тел таблиц:
      result += @"</tr><tr>";
      for (int i = 0; i < Nodes.Count; i++) // цикл по таблицам:
      {
        if (!groups.CheckedIndices.Contains(i)) continue; // i-ая таблица не выбрана.
        List<cRsrcsNode> jNode = Nodes[i].Nodes; // i-я таблица.
        result += @"<td class=""frame"" style=""vertical-align:top;""><table cellpadding=""0"" cellspacing=""0"" style=""width:100%;""><tr>";
        for (int j = 0; j < jNode.Count; j++) // цикл по группам:
        {
          // В этой группе может быть несколько подразделений:
          List<cRsrcsNode> kNode = Nodes[i].Nodes[j].Nodes; // j-ая группа.
          result += @"<td style=""vertical-align:top;""><table class=""cell"" cellpadding=""0"" cellspacing=""0"" style=""width:100%;"">";
          result += @"<tr><td class=""cell cellGroup fontGroup"">";
          if (String.IsNullOrEmpty(Nodes[i].Nodes[j].Group))
            result += @"&nbsp;</td></tr>";
          else
            result += Nodes[i].Nodes[j].Group + " - <strong>" + Nodes[i].Nodes[j].Count + "</strong></td></tr>";
          // В этом месте необходимо вывести личн. состав, либо список подразделений:
          bool grey = false;
          int rows = 0; // Количество заполненных строк в столбце.
          if (kNode[0].Nodes.Count > 0) // Группа
          {
            for (int k = 0; k < kNode.Count; k++)
            {
              grey = !grey; // чередование цветов строк.
              List<cRsrcsNode> lNode = kNode[k].Nodes;
              result += @"<tr><td class=""cell ";
              if (grey) result += @"cellDark ";
              result += @"fontGroup"">" + kNode[k].Group + " - <strong>" + Convert.ToString(kNode[k].Count) + "</strong></td></tr>";
              rows++;
              for (int l = 0; l < lNode.Count; l++)
              {
                rows++;
                grey = !grey; // чередование цветов строк.
                result += @"<tr><td class=""cell ";
                if (grey) result += @"cellDark ";
                if (lNode[l].Kontrakt)
                {
                  result += @"fontCell"">" + Convert.ToString(l + 1) + ". <strong>" + FormatFIO((string)soldiers.Rows[lNode[l].Index].Cells["cFIO"].Value, lNode[l].Free) + @"</strong></td></tr>";
                }
                else
                {
                  result += @"fontCell"">" + Convert.ToString(l + 1) + ". " + FormatFIO((string)soldiers.Rows[lNode[l].Index].Cells["cFIO"].Value, lNode[l].Free) + @"</td></tr>";
                }
              }
            }
          }
          else
          {
            for (int k = 0; k < kNode.Count; k++)
            {
              rows++;
              grey = !grey; // чередование цветов строк.
              result += @"<tr><td class=""cell ";
              if (grey) result += @"cellDark ";
              if (kNode[k].Kontrakt)
              {
                result += @"fontCell"">" + Convert.ToString(k + 1) + ". <strong>" + FormatFIO((string)soldiers.Rows[kNode[k].Index].Cells["cFIO"].Value, kNode[k].Free) + @"</strong></td></tr>";
              }
              else
              {
                result += @"fontCell"">" + Convert.ToString(k + 1) + ". " + FormatFIO((string)soldiers.Rows[kNode[k].Index].Cells["cFIO"].Value, kNode[k].Free) + @"</td></tr>";
              }
            }
          }
          // Заполнение пустых строк:
          for (int l = 0; l < maxGroup - rows; l++)
          {
            grey = !grey; // чередование цветов строк.
            result += @"<tr><td class=""cell ";
            if (grey) result += @"cellDark ";
            result += @"fontCell""></td></tr>";
          }
          // Низ:
          result += @"</table></td>";
        }
        result += @"</tr></table></td><td style=""width:10px; min-width:10px;""></td>";
      }
      // Дописывание информации по количеству личного состава:
      result += @"</tr><tr>";
      for (int i = 0; i < Nodes.Count; i++)
      {
        if (!groups.CheckedIndices.Contains(i)) continue; // i-ая таблица не выбрана.
        result += @"<td style=""text-align:right;font-size:8pt;"">";
        result += @"По списку: <strong>" + Convert.ToString(Nodes[i].Count) + "</strong><br />";
        result += @"На лицо: <strong>" + ((naLico.Count > i) ? Convert.ToString(naLico[i]) : "0") + "</strong><br />";
        result += @"Отсутствует: <strong>" + ((naLico.Count > i) ? Convert.ToString(Nodes[i].Count - naLico[i]) : Convert.ToString(Nodes[i].Count)) + "</strong><br />";
        result += @"</td><td style=""width:10px;""></td>";
      }
      result += @"</tr></table></td></tr></table></body></html>";
      return result;
    }
  }
}
