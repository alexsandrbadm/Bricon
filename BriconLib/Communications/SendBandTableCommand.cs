// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendBandTableCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class SendBandTableCommand : Command
  {
    public int _index;
    private string _elband;
    private string _dbring;
    private string _pincode;
    private bool _lastRecord;
    private byte _fancierPos;

    public SendBandTableCommand(string pincode)
    {
      this._index = 0;
      this._pincode = pincode;
    }

    public SendBandTableCommand(
      int index,
      string elband,
      string dbring,
      bool female,
      string color)
    {
      this._index = index;
      this._elband = elband;
      this._dbring = dbring;
      if (Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL"))
      {
        int startIndex = this._dbring.LastIndexOf('-');
        if (startIndex > 5)
          this._dbring = this._dbring.Remove(startIndex, 1);
      }
      if (Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL"))
        this._dbring = this._dbring.PadRight(16).Substring(0, 16);
      this._dbring = !female ? this._dbring + " " : (!Utils.IsUKProtocol() || Utils.IsCountry("PT") || (Utils.IsCountry("ES") || Utils.IsCountry("RO")) || Utils.IsCountry("MD") ? this._dbring + ml.ml_string(224, "F") : this._dbring + "H");
      if (Utils.IsUKProtocol())
      {
        color = color.PadLeft(4);
        this._dbring += color.Substring(0, 4);
      }
      this._fancierPos = SendFancierCommand.fancierPos;
    }

    public override string ToString() => this.AddStatusText(this._pincode == null ? string.Format(ml.ml_string(174, "Send Ring {0} - {1} with index {2}"), (object) this._dbring, (object) this._elband, (object) this._index) : string.Format(ml.ml_string(170, "Start sending rings")));

    public override byte[] ToBytes()
    {
      byte length = this._pincode != null ? (byte) 8 : (byte) 24;
      if (Utils.IsUKProtocol() && this._pincode == null)
        length += (byte) 9;
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 194 : (byte) 82, length);
      int num1 = 3;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      int num3 = (int) Convert.ToByte(this._index >> 8);
      numArray1[index1] = (byte) num3;
      byte[] numArray2 = bytes;
      int index2 = num2;
      int num4 = index2 + 1;
      int num5 = (int) Convert.ToByte(this._index & (int) byte.MaxValue);
      numArray2[index2] = (byte) num5;
      if (this._pincode != null)
      {
        foreach (byte num6 in Conversion.StringToByteArray(this._pincode, 6, (byte) 48))
          bytes[num4++] = num6;
      }
      else
      {
        foreach (byte num6 in Conversion.StringToByteArray(this._elband.ToUpper(), 8, (byte) 48))
          bytes[num4++] = num6;
        if (Utils.IsUKProtocol())
        {
          foreach (byte num6 in Conversion.StringToByteArray(this._dbring.ToUpper(), 22, (byte) 32))
            bytes[num4++] = num6;
          byte[] numArray3 = bytes;
          int index3 = num4;
          int num7 = index3 + 1;
          int fancierPos = (int) this._fancierPos;
          numArray3[index3] = (byte) fancierPos;
        }
        else
        {
          foreach (byte num6 in Conversion.StringToByteArray(this._dbring.ToUpper(), 14, (byte) 32))
            bytes[num4++] = num6;
        }
      }
      return bytes;
    }

    public bool LastRecord
    {
      get => this._lastRecord;
      set => this._lastRecord = value;
    }

    public override bool HasFeedBack => true;
  }
}
