// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendBetDataCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class SendBetDataCommand : Command
  {
    private byte _level;
    private string _raceCode;
    private byte _raceIndex;
    private byte _result;
    private ushort[] _values;

    public SendBetDataCommand(
      byte level,
      string raceCode,
      byte raceIndex,
      byte result,
      ushort[] values)
    {
      this._level = level;
      this._raceIndex = raceIndex;
      this._result = result;
      this._raceCode = raceCode;
      this._values = values;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(1160, "Send money data, for level ") + this._level.ToString() + ml.ml_string(1161, " and race ") + this._raceCode));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, (byte) 89, (byte) (7 + this._values.Length * 2));
      int num1 = 3;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      int level = (int) this._level;
      numArray1[index1] = (byte) level;
      byte[] numArray2 = bytes;
      int index2 = num2;
      int num3 = index2 + 1;
      int raceIndex = (int) this._raceIndex;
      numArray2[index2] = (byte) raceIndex;
      foreach (byte num4 in Conversion.StringToByteArray(this._raceCode, 4, (byte) 48))
        bytes[num3++] = num4;
      byte[] numArray3 = bytes;
      int index3 = num3;
      int num5 = index3 + 1;
      int result = (int) this._result;
      numArray3[index3] = (byte) result;
      foreach (ushort num4 in this._values)
      {
        byte[] numArray4 = bytes;
        int index4 = num5;
        int num6 = index4 + 1;
        int num7 = (int) (byte) ((uint) num4 >> 8);
        numArray4[index4] = (byte) num7;
        byte[] numArray5 = bytes;
        int index5 = num6;
        num5 = index5 + 1;
        int num8 = (int) (byte) ((uint) num4 & (uint) byte.MaxValue);
        numArray5[index5] = (byte) num8;
      }
      return bytes;
    }

    public override bool HasFeedBack => true;
  }
}
