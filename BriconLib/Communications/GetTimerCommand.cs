// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetTimerCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PrintManager;
using MultiLang;
using System.Collections.Generic;

namespace BriconLib.Communications
{
  public class GetTimerCommand : Command
  {
    private byte _index;
    public ReadOutDataSet.TimersRow _row;
    private ReadOutDataSet _readout;
    private string _clubID;
    private string _flightID;
    public static List<byte[]> LastDataRecords = new List<byte[]>();

    public GetTimerCommand(ReadOutDataSet readout)
    {
      this._clubID = "0000";
      this._flightID = (string) null;
      this._readout = readout;
      this._index = (byte) 0;
    }

    public GetTimerCommand(ReadOutDataSet readout, string clubID, string flightID)
    {
      this._clubID = clubID;
      this._flightID = flightID;
      this._readout = readout;
      this._index = (byte) 0;
    }

    private GetTimerCommand(byte index, ReadOutDataSet readout, string clubID, string flightID)
    {
      this._clubID = clubID;
      this._flightID = flightID;
      this._readout = readout;
      this._index = index;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(495, "Get Timer with index {0}"), (object) ((int) this._index + 1)));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 205 : (byte) 93, (byte) 5);
      bytes[3] = this._index;
      for (int index = 0; index < 4; ++index)
        bytes[4 + index] = (byte) 48;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      GetTimerCommand.LastDataRecords.Add((byte[]) response.DataBytes.Clone());
      int start1 = 1;
      string str = Conversion.ByteArrayToString(response.DataBytes, start1, 4, false);
      int start2 = start1 + 4;
      string unicode = Conversion.ToUnicode(Conversion.ByteArrayToString(response.DataBytes, start2, 4, false));
      int start3 = start2 + 4;
      if (this._flightID == null || str == this._clubID && unicode == this._flightID)
      {
        this._row = this._readout.Timers.NewTimersRow();
        string date1 = Conversion.ByteArrayToString(response.DataBytes, start3, 6);
        int start4 = start3 + 6;
        string time1 = Conversion.ByteArrayToString(response.DataBytes, start4, 6);
        int start5 = start4 + 6;
        this._row.BasketingMasterTime = Conversion.DateTimeFromStrings(date1, time1);
        this._row.ClubID = str;
        this._row.FlightID = unicode;
        string time2 = Conversion.ByteArrayToString(response.DataBytes, start5, 6);
        int start6 = start5 + 6;
        this._row.BasketingInternalTime = Conversion.DateTimeFromStrings(date1, time2);
        this._row.BasketingDiff = Conversion.ByteArrayToString(response.DataBytes, start6, 4, false);
        int start7 = start6 + 4;
        string date2 = Conversion.ByteArrayToString(response.DataBytes, start7, 6);
        int start8 = start7 + 6;
        string time3 = Conversion.ByteArrayToString(response.DataBytes, start8, 6);
        int start9 = start8 + 6;
        this._row.ReadOutMasterTime = Conversion.DateTimeFromStrings(date2, time3);
        string time4 = Conversion.ByteArrayToString(response.DataBytes, start9, 6);
        int start10 = start9 + 6;
        this._row.ReadOutInternalTime = Conversion.DateTimeFromStrings(date2, time4);
        this._row.ReadOutDiff = Conversion.ByteArrayToString(response.DataBytes, start10, 4, false);
        int start11 = start10 + 4;
        this._row.Diff = Conversion.ByteArrayToString(response.DataBytes, start11, 4, false);
        int num = start11 + 4;
      }
      CommunicationPool.Instance.PostNextCommand((Command) new GetTimerCommand((byte) ((uint) this._index + 1U), this._readout, this._clubID, this._flightID));
    }

    public override bool HasFeedBack => true;
  }
}
