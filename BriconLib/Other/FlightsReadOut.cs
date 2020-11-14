// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.FlightsReadOut
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.PrintManager;
using BriconLib.UI;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class FlightsReadOut
  {
    private int lastFancierID;
    private ReadOutDataSet _readOut;
    private string _clubID;
    private string _flightID;
    private Decimal _timeZone;

    public bool ReadOut(ReadOutDataSet readOut, string clubID, string flightID, Decimal timeZone)
    {
      try
      {
        this._readOut = readOut;
        this._clubID = clubID;
        this._flightID = flightID;
        this._timeZone = timeZone;
        ActivateBACommand.LastDataRecord = (byte[]) null;
        GetFancierCommand.LastDataRecord = (byte[]) null;
        GetTimerCommand.LastDataRecords.Clear();
        GetPigeonCommand.LastDataRecords.Clear();
        CommunicationForm communicationForm = new CommunicationForm();
        communicationForm.OnHandleCommand += new EventHandler(this.frm_OnHandleCommand);
        communicationForm.OnPostCommands += new EventHandler(this.frm_OnPostCommands);
        if (communicationForm.ShowDialog() == DialogResult.OK)
        {
          if (Utils.IsCountry("UK") || Utils.IsCountry("IR"))
          {
            ReadOutDataSet.FancierRow byId = this._readOut.Fancier.FindByID(this.lastFancierID);
            AskDistanceForm askDistanceForm = new AskDistanceForm(byId.License, byId.Name, this._flightID);
            int num = (int) askDistanceForm.ShowDialog();
            byId.Distance = askDistanceForm.Distance;
          }
          return true;
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
      return false;
    }

    private void frm_OnPostCommands(object sender, EventArgs e)
    {
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetFancierCommand());
      CommunicationState.Instance.GetAndClearCommands();
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetPigeonCommand(this._readOut, this._clubID, this._flightID));
      CommunicationState.Instance.GetAndClearCommands();
      CommunicationPool.Instance.PostCommand((BriconLib.Communications.Command) new GetTimerCommand(this._readOut, this._clubID, this._flightID));
      CommunicationState.Instance.GetAndClearCommands();
    }

    private void frm_OnHandleCommand(object sender, EventArgs e)
    {
      if (sender is GetFancierCommand)
      {
        GetFancierCommand getFancierCommand = sender as GetFancierCommand;
        List<ReadOutDataSet.FancierRow> fancierRowList = new List<ReadOutDataSet.FancierRow>();
        foreach (ReadOutDataSet.FancierRow fancierRow in this._readOut.Fancier.Select("License = '" + getFancierCommand.ReceivedLicentie + "'"))
          fancierRowList.Add(fancierRow);
        foreach (ReadOutDataSet.FancierRow row1 in fancierRowList)
        {
          int id = row1.ID;
          this._readOut.Fancier.RemoveFancierRow(row1);
          List<ReadOutDataSet.PigeonsRow> pigeonsRowList = new List<ReadOutDataSet.PigeonsRow>();
          foreach (ReadOutDataSet.PigeonsRow pigeonsRow in this._readOut.Pigeons.Select("FancierID = " + id.ToString()))
            pigeonsRowList.Add(pigeonsRow);
          foreach (ReadOutDataSet.PigeonsRow row2 in pigeonsRowList)
            this._readOut.Pigeons.RemovePigeonsRow(row2);
          List<ReadOutDataSet.TimersRow> timersRowList = new List<ReadOutDataSet.TimersRow>();
          foreach (ReadOutDataSet.TimersRow timersRow in this._readOut.Timers.Select("FancierID = " + id.ToString()))
            timersRowList.Add(timersRow);
          foreach (ReadOutDataSet.TimersRow row2 in timersRowList)
            this._readOut.Timers.RemoveTimersRow(row2);
        }
        string GemeenteUnicode = "";
        DataRow[] dataRowArray = BCEDatabase.DataSet.Adressen.Select("Licentie = '" + getFancierCommand.ReceivedLicentie + "'");
        string NaamUnicode;
        if (dataRowArray.Length == 1)
        {
          NaamUnicode = (dataRowArray[0] as BCEDataSet.AdressenRow).NaamUnicode;
          GemeenteUnicode = (dataRowArray[0] as BCEDataSet.AdressenRow).GemeenteUnicode;
        }
        else
          NaamUnicode = dataRowArray.Length != 0 ? ml.ml_string(1360, "Multiple matches") : ml.ml_string(1359, "No exact match");
        this.lastFancierID = this._readOut.Fancier.AddFancierRow(getFancierCommand.ReceivedLicentie, getFancierCommand.ReceivedNaam, getFancierCommand.ReceivedAdres, getFancierCommand.ReceivedPostcode, getFancierCommand.ReceivedGemeente, Conversion.CoordinateToString(getFancierCommand.ReceivedCoordX, true), Conversion.CoordinateToString(getFancierCommand.ReceivedCoordY, true), Conversion.SerialFromVersion(CommunicationState.Instance.BAVersion, CommunicationState.Instance.BAAddress), 0M, Utils.UnitsUsed(), "0", "", NaamUnicode, GemeenteUnicode, this._timeZone).ID;
      }
      if (sender is GetPigeonCommand)
      {
        GetPigeonCommand getPigeonCommand = sender as GetPigeonCommand;
        if (getPigeonCommand._row != null)
        {
          getPigeonCommand._row.FancierID = this.lastFancierID;
          if (!((IEnumerable<DataRow>) this._readOut.Pigeons.Select("ElBand = '" + getPigeonCommand._row.ElBand + "' AND FedBand = '" + getPigeonCommand._row.FedBand + "'")).Any<DataRow>())
            this._readOut.Pigeons.AddPigeonsRow(getPigeonCommand._row);
        }
      }
      if (!(sender is GetTimerCommand))
        return;
      GetTimerCommand getTimerCommand = sender as GetTimerCommand;
      if (getTimerCommand._row == null)
        return;
      getTimerCommand._row.FancierID = this.lastFancierID;
      this._readOut.Timers.AddTimersRow(getTimerCommand._row);
    }
  }
}
