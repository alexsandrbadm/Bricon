// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetPigeonCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PrintManager;
using MultiLang;
using System;
using System.Collections.Generic;

namespace BriconLib.Communications
{
  public class GetPigeonCommand : Command
  {
    private int _index;
    public ReadOutDataSet.PigeonsRow _row;
    private ReadOutDataSet _readout;
    private string _clubID;
    private string _flightID;
    public static List<byte[]> LastDataRecords = new List<byte[]>();

    public GetPigeonCommand(ReadOutDataSet readout)
    {
      this._clubID = "0000";
      this._flightID = "0000";
      this._readout = readout;
      this._index = 0;
    }

    public GetPigeonCommand(ReadOutDataSet readout, string clubID, string flightID)
    {
      this._clubID = clubID;
      this._flightID = flightID;
      this._readout = readout;
      this._index = 0;
    }

    private GetPigeonCommand(int index, ReadOutDataSet readout, string clubID, string flightID)
    {
      this._clubID = clubID;
      this._flightID = flightID;
      this._readout = readout;
      this._index = index;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(494, "Get PigeonData with index {0}"), (object) (this._index + 1)));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 200 : (byte) 88, (byte) 10);
      bytes[3] = (byte) (this._index >> 8);
      bytes[4] = (byte) (this._index & (int) byte.MaxValue);
      for (int index = 0; index < 4; ++index)
        bytes[5 + index] = Convert.ToByte(this._clubID[index]);
      for (int index = 0; index < 4; ++index)
        bytes[9 + index] = Convert.ToByte(this._flightID[index]);
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      GetPigeonCommand.LastDataRecords.Add((byte[]) response.DataBytes.Clone());
      this._row = this._readout.Pigeons.NewPigeonsRow();
      int start1 = 2;
      this._row.ElBand = Conversion.ByteArrayToString(response.DataBytes, start1, 8);
      int start2 = start1 + 8;
      int start3;
      if (!Utils.IsCountry("JP") && !Utils.IsCountry("UK") && (response.DataBytes.Length == 53 || response.DataBytes.Length == 60 || (response.DataBytes.Length == 54 || response.DataBytes.Length == 61) || (response.DataBytes.Length == 71 || response.DataBytes.Length == 70 || (Utils.IsCountry("PT") || Utils.IsCountry("ES"))) || (Utils.IsCountry("NL") || Utils.IsCountry("UA") || Utils.IsCountry("PL"))) || (Utils.IsCountry("FR") || Utils.IsCountry("KSA")))
      {
        this._row.FedBand = Conversion.ByteArrayToString(response.DataBytes, start2, 14);
        start3 = start2 + 14;
      }
      else
      {
        this._row.FedBand = Conversion.ByteArrayToString(response.DataBytes, start2, 22);
        start3 = start2 + 22;
      }
      if ((Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL")) && this._row.FedBand.LastIndexOf('-') < 6)
        this._row.FedBand = this._row.FedBand.Insert(10, "-");
      int num1;
      if (Utils.IsCountry("UA") || Utils.IsCountry("PL"))
      {
        this._row.FlightID = Conversion.ToUnicode(Conversion.ByteArrayToString(response.DataBytes, start3, 4));
        int start4 = start3 + 4;
        this._row.ClubID = Conversion.ByteArrayToString(response.DataBytes, start4, 4);
        num1 = start4 + 4;
      }
      else
      {
        this._row.ClubID = Conversion.ByteArrayToString(response.DataBytes, start3, 4);
        int start4 = start3 + 4;
        this._row.FlightID = Conversion.ToUnicode(Conversion.ByteArrayToString(response.DataBytes, start4, 4));
        num1 = start4 + 4;
      }
      ReadOutDataSet.PigeonsRow row1 = this._row;
      byte[] dataBytes1 = response.DataBytes;
      int index1 = num1;
      int num2 = index1 + 1;
      int num3 = (int) dataBytes1[index1] << 8;
      byte[] dataBytes2 = response.DataBytes;
      int index2 = num2;
      int num4 = index2 + 1;
      int num5 = (int) dataBytes2[index2];
      int num6 = num3 + num5;
      row1.Position1 = num6;
      ReadOutDataSet.PigeonsRow row2 = this._row;
      byte[] dataBytes3 = response.DataBytes;
      int index3 = num4;
      int num7 = index3 + 1;
      int num8 = (int) dataBytes3[index3] << 8;
      byte[] dataBytes4 = response.DataBytes;
      int index4 = num7;
      int num9 = index4 + 1;
      int num10 = (int) dataBytes4[index4];
      int num11 = num8 + num10;
      row2.Position2 = num11;
      ReadOutDataSet.PigeonsRow row3 = this._row;
      byte[] dataBytes5 = response.DataBytes;
      int index5 = num9;
      int num12 = index5 + 1;
      int num13 = (int) dataBytes5[index5] << 8;
      byte[] dataBytes6 = response.DataBytes;
      int index6 = num12;
      int num14 = index6 + 1;
      int num15 = (int) dataBytes6[index6];
      int num16 = num13 + num15;
      row3.Position3 = num16;
      ReadOutDataSet.PigeonsRow row4 = this._row;
      byte[] dataBytes7 = response.DataBytes;
      int index7 = num14;
      int num17 = index7 + 1;
      int num18 = (int) dataBytes7[index7] << 8;
      byte[] dataBytes8 = response.DataBytes;
      int index8 = num17;
      int start5 = index8 + 1;
      int num19 = (int) dataBytes8[index8];
      int num20 = num18 + num19;
      row4.Position4 = num20;
      string date = Conversion.ByteArrayToString(response.DataBytes, start5, 6);
      int start6 = start5 + 6;
      string time = Conversion.ByteArrayToString(response.DataBytes, start6, 6);
      int start7 = start6 + 6;
      this._row.Time = Conversion.DateTimeFromStrings(date, time);
      this._row.Evaluation = Conversion.ByteArrayToString(response.DataBytes, start7, 1);
      int num21 = start7 + 1;
      if (num21 < response.DataBytes.Length)
        ++num21;
      if (num21 < response.DataBytes.Length)
        ++num21;
      if (!Utils.IsCountry("RO") && !Utils.IsCountry("MD") && num21 < response.DataBytes.Length)
      {
        ReadOutDataSet.PigeonsRow row5 = this._row;
        byte[] dataBytes9 = response.DataBytes;
        int index9 = num21;
        int num22 = index9 + 1;
        int num23 = (int) dataBytes9[index9];
        row5.TeamNbr = num23;
      }
      if (this._row.ClubID == "0000" && this._row.FlightID == "0000" && (this._clubID != "0000" && this._clubID != "0000"))
      {
        this._row.ClubID = this._clubID;
        this._row.FlightID = this._flightID;
      }
      CommunicationPool.Instance.PostNextCommand((Command) new GetPigeonCommand(this._index + 1, this._readout, this._clubID, this._flightID));
    }

    public override bool HasFeedBack => true;
  }
}
