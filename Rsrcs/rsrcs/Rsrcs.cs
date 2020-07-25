using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace rsrcs
{
  static class Rsrcs
  {
    /// <summary>
    /// Программа для составления расходов. Автор: virtualmode, 2011.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new fRsrcs());
    }
  }
}
