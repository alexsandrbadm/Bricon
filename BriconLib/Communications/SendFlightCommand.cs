// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendFlightCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class SendFlightCommand : Command
  {
    private byte _index;
    private string _name;
    private string _shortName;

    public SendFlightCommand(byte index, string name, string shortName)
    {
      this._index = index;
      this._name = name;
      this._shortName = shortName;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(171, "Send Race '{0}'-'{1}' with index {2}"), (object) this._name, (object) this._shortName, (object) this._index));

    public override byte[] ToBytes()
    {
      string str = this._name.PadRight(20).Substring(0, 20) + ";" + this._shortName + ";";
      byte[] bytes = this.CreateBytes((byte) 16, (byte) 101, Convert.ToByte(str.Length + 1 + 1));
      int num1 = 3;
      byte[] numArray = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      int index2 = (int) this._index;
      numArray[index1] = (byte) index2;
      foreach (byte num3 in Conversion.StringToByteArray(str, str.Length + 1))
        bytes[num2++] = num3;
      return bytes;
    }

    public override bool IsMasterCommand => true;
  }
}
