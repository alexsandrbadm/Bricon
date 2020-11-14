// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.SendPoulLetter
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.PrintManager;
using MultiLang;
using System;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class SendPoulLetter
  {
    private ReadOutDataSet _readOut;
    private byte _raceIndex;
    private string _flightID;

    public bool SendIt(ReadOutDataSet readOut, string flightID, byte raceIndex)
    {
      try
      {
        this._readOut = readOut;
        this._flightID = flightID;
        this._raceIndex = raceIndex;
        ActivateBACommand.LastDataRecord = (byte[]) null;
        GetFancierCommand.LastDataRecord = (byte[]) null;
        GetTimerCommand.LastDataRecords.Clear();
        GetPigeonCommand.LastDataRecords.Clear();
        CommunicationState.Instance.GetAndClearCommands();
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
      try
      {
        foreach (ReadOutDataSet.PigeonsRow row in (InternalDataCollectionBase) this._readOut.Pigeons.Rows)
        {
          if (row.Evaluation == "0")
          {
            int pos1 = 0;
            int pos2 = 0;
            int pos3 = 0;
            if (!row.IsPosition1Null())
              pos1 = row.Position1;
            if (!row.IsPosition2Null())
              pos2 = row.Position2;
            if (!row.IsPosition3Null())
              pos3 = row.Position3;
            if (pos1 > 0 || pos2 > 0 || pos3 > 0)
              CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendDesignatedCommand(row.ElBand, pos1, pos2, pos3));
          }
        }
        for (byte level = 1; level <= (byte) 18; ++level)
        {
          ushort[] values = new ushort[33];
          byte result = 0;
          if (!this._readOut.PoulLetter[0].IsNull(1 + (int) level))
            result = (byte) (ushort) this._readOut.PoulLetter[0][1 + (int) level];
          for (int index = 0; index < values.Length; ++index)
          {
            if (!this._readOut.PoulLetter[index + 1].IsNull(1 + (int) level))
              values[index] = (ushort) this._readOut.PoulLetter[index + 1][1 + (int) level];
          }
          CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendBetDataCommand(level, this._flightID, this._raceIndex, result, values));
        }
      }
      catch (Exception ex)
      {
      }
    }

    private void frm_OnHandleCommand(object sender, EventArgs e)
    {
      if (!(sender is SendBetDataCommand))
        return;
      SendBetDataCommand sendBetDataCommand = sender as SendBetDataCommand;
      if (sendBetDataCommand.Status == ResponseStatus.OK)
        return;
      int num = (int) MessageBox.Show(ml.ml_string(1363, "Invalid response, status was : ") + sendBetDataCommand.Status.ToString());
    }
  }
}
