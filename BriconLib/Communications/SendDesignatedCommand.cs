// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendDesignatedCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class SendDesignatedCommand : Command
  {
    private string _elband;
    private int _pos1;
    private int _pos2;
    private int _pos3;

    public SendDesignatedCommand(string elband, int pos1, int pos2, int pos3)
    {
      this._elband = elband;
      this._pos1 = pos1;
      this._pos2 = pos2;
      this._pos3 = pos3;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(1162, "Send Designated {0} - {1}, {2}, {3}"), (object) this._elband, (object) this._pos1, (object) this._pos2, (object) this._pos3));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, (byte) 253, (byte) 16);
      int num1 = 3;
      foreach (byte num2 in Conversion.StringToByteArray(this._elband, 8, (byte) 48))
        bytes[num1++] = num2;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num3 = index1 + 1;
      int num4 = (int) Convert.ToByte(this._pos1 >> 8);
      numArray1[index1] = (byte) num4;
      byte[] numArray2 = bytes;
      int index2 = num3;
      int num5 = index2 + 1;
      int num6 = (int) Convert.ToByte(this._pos1 & (int) byte.MaxValue);
      numArray2[index2] = (byte) num6;
      byte[] numArray3 = bytes;
      int index3 = num5;
      int num7 = index3 + 1;
      int num8 = (int) Convert.ToByte(this._pos2 >> 8);
      numArray3[index3] = (byte) num8;
      byte[] numArray4 = bytes;
      int index4 = num7;
      int num9 = index4 + 1;
      int num10 = (int) Convert.ToByte(this._pos2 & (int) byte.MaxValue);
      numArray4[index4] = (byte) num10;
      byte[] numArray5 = bytes;
      int index5 = num9;
      int num11 = index5 + 1;
      int num12 = (int) Convert.ToByte(this._pos3 >> 8);
      numArray5[index5] = (byte) num12;
      byte[] numArray6 = bytes;
      int index6 = num11;
      int num13 = index6 + 1;
      int num14 = (int) Convert.ToByte(this._pos3 & (int) byte.MaxValue);
      numArray6[index6] = (byte) num14;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      int status = (int) response.Status;
    }

    public override bool HasFeedBack => true;
  }
}
