// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.MessageDisplayer
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class MessageDisplayer
  {
    private Thread _thread;
    private string _message;

    public MessageDisplayer(string message)
    {
      this._message = message;
      this._thread = new Thread(new ThreadStart(this.ShowMessage));
      if (Settings.Default.Language != "Auto")
        this._thread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      this._thread.Start();
    }

    private void ShowMessage()
    {
      int num = (int) MessageBox.Show(this._message, Defines.MessageBoxCaption);
    }
  }
}
