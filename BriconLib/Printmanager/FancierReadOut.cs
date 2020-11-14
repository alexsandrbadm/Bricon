// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.FancierReadOut
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Other;
using BriconLib.Updater;
using System;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  internal class FancierReadOut
  {
    private ReadOutDataSet _readOut = new ReadOutDataSet();
    private bool _poulLetter;
    private bool _testXtreme;
    private string _raceId;
    private string _clubId;

    public ReadOutDataSet ReadOut(
      bool poulLetter,
      bool testXtreme = false,
      string raceId = null,
      string clubId = null)
    {
      this._testXtreme = testXtreme;
      this._poulLetter = poulLetter;
      this._raceId = raceId;
      this._clubId = clubId;
      try
      {
        CommunicationForm communicationForm = new CommunicationForm();
        communicationForm.OnHandleCommand += new EventHandler(this.frm_OnHandleCommand);
        communicationForm.OnPostCommands += new EventHandler(this.frm_OnPostCommands);
        communicationForm.OnFinish += new EventHandler(this.frm_OnFinish);
        if (communicationForm.ShowDialog() == DialogResult.OK)
          return this._readOut;
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return (ReadOutDataSet) null;
    }

    private void frm_OnFinish(object sender, EventArgs e)
    {
      if (this._clubId != null && this._raceId != null)
        return;
      XtremeLoader.TryToLoad(sender as CommunicationForm);
    }

    private void frm_OnPostCommands(object sender, EventArgs e)
    {
      if (this._clubId != null && this._raceId != null)
        CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new SendSecSyncCommand(this._clubId, this._raceId));
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFancierCommand());
      if (this._testXtreme)
        return;
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetPigeonCommand(this._readOut));
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetTimerCommand(this._readOut));
      if (!this._poulLetter)
        return;
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFlightNamesCommand());
    }

    private void frm_OnHandleCommand(object sender, EventArgs e)
    {
      if (sender is GetFancierCommand)
      {
        GetFancierCommand getFancierCommand = sender as GetFancierCommand;
        if (getFancierCommand.Success)
          this._readOut.Fancier.AddFancierRow(getFancierCommand.ReceivedLicentie, getFancierCommand.ReceivedNaam, getFancierCommand.ReceivedAdres, getFancierCommand.ReceivedPostcode, getFancierCommand.ReceivedGemeente, Conversion.CoordinateToString(getFancierCommand.ReceivedCoordX, true), Conversion.CoordinateToString(getFancierCommand.ReceivedCoordY, true), Conversion.SerialFromVersion(CommunicationState.Instance.BAVersion, CommunicationState.Instance.BAAddress), 1M, "Metric", "1", "", "", "", 0M);
      }
      if (sender is GetPigeonCommand)
      {
        GetPigeonCommand getPigeonCommand = sender as GetPigeonCommand;
        if (getPigeonCommand.Success && getPigeonCommand._row != null)
          this._readOut.Pigeons.AddPigeonsRow(getPigeonCommand._row);
      }
      if (sender is GetTimerCommand)
      {
        GetTimerCommand getTimerCommand = sender as GetTimerCommand;
        if (getTimerCommand.Success && getTimerCommand._row != null)
          this._readOut.Timers.AddTimersRow(getTimerCommand._row);
      }
      if (!(sender is GetFlightNamesCommand))
        return;
      GetFlightNamesCommand flightNamesCommand = sender as GetFlightNamesCommand;
      if (!flightNamesCommand.Success)
        return;
      for (int start = 1; start < flightNamesCommand.FlightNames.Length; start += 12)
      {
        string Name = Conversion.ByteArrayToString(flightNamesCommand.FlightNames, start, 12, true);
        this._readOut.RaceNames.AddRaceNamesRow(Name.PadRight(4).Substring(0, 4), Name);
      }
    }
  }
}
