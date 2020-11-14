// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.AllFlightsReadOut
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.PrintManager;
using System;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class AllFlightsReadOut
  {
    private ReadOutDataSet _readOut;

    public bool ReadOut(ReadOutDataSet readOut)
    {
      try
      {
        this._readOut = readOut;
        CommunicationForm communicationForm = new CommunicationForm();
        communicationForm.OnHandleCommand += new EventHandler(this.frm_OnHandleCommand);
        communicationForm.OnPostCommands += new EventHandler(this.frm_OnPostCommands);
        if (communicationForm.ShowDialog() == DialogResult.OK)
          return true;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return false;
    }

    private void frm_OnPostCommands(object sender, EventArgs e)
    {
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetTimerCommand(this._readOut));
      CommunicationState.Instance.GetAndClearCommands();
    }

    private void frm_OnHandleCommand(object sender, EventArgs e)
    {
      if (!(sender is GetTimerCommand))
        return;
      GetTimerCommand getTimerCommand = sender as GetTimerCommand;
      if (getTimerCommand._row == null)
        return;
      this._readOut.Timers.AddTimersRow(getTimerCommand._row);
    }
  }
}
