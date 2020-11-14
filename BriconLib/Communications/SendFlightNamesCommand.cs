// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendFlightNamesCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class SendFlightNamesCommand : Command
  {
    private string _flightNames;
    private byte _index = byte.MaxValue;

    public SendFlightNamesCommand(string flightNames) => this._flightNames = flightNames;

    public SendFlightNamesCommand(string flightNames, byte index)
    {
      this._flightNames = flightNames;
      this._index = index;
    }

    public override string ToString() => this.AddStatusText(this._index != byte.MaxValue ? (this._index != (byte) 0 ? string.Format(ml.ml_string(534, "Send Flight {0}: {1}"), (object) this._index, (object) this._flightNames) : string.Format(ml.ml_string(533, "Start sending flights"))) : string.Format(ml.ml_string(415, "Send Races {0}"), (object) this._flightNames));

    public override byte[] ToBytes()
    {
      byte length = 14;
      if (this._index == byte.MaxValue)
        length = (byte) 101;
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, (byte) 250, length);
      int num1 = 3;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      numArray1[index1] = (byte) 11;
      if (this._index == byte.MaxValue)
      {
        foreach (byte num3 in Conversion.StringToByteArray(this._flightNames, 100))
          bytes[num2++] = num3;
      }
      else
      {
        byte[] numArray2 = bytes;
        int index2 = num2;
        int num3 = index2 + 1;
        int index3 = (int) this._index;
        numArray2[index2] = (byte) index3;
        foreach (byte num4 in Conversion.StringToByteArray(this._flightNames, 12))
          bytes[num3++] = num4;
      }
      return bytes;
    }
  }
}
