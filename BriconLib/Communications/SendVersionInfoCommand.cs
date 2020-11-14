// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendVersionInfoCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;

namespace BriconLib.Communications
{
  public class SendVersionInfoCommand : Command
  {
    private string _menuString;
    private byte _type;
    private byte _version;
    private byte _storage;

    public SendVersionInfoCommand(string menuString, byte type, byte version, byte storage)
    {
      this._menuString = menuString;
      this._type = type;
      this._version = version;
      this._storage = storage;
    }

    public override string ToString() => this.AddStatusText(string.Format("Send version and storage information with menuentry = '{0}', Type = {1}, Version = {2}, Storage = {3}", (object) this._menuString, (object) this._type, (object) this._version, (object) this._storage));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes((byte) 16, (byte) 112, (byte) 19);
      int num1 = 3;
      byte[] numArray1 = bytes;
      int index1 = num1;
      int num2 = index1 + 1;
      numArray1[index1] = (byte) 2;
      byte[] numArray2 = bytes;
      int index2 = num2;
      int num3 = index2 + 1;
      int type = (int) this._type;
      numArray2[index2] = (byte) type;
      byte[] numArray3 = bytes;
      int index3 = num3;
      int num4 = index3 + 1;
      int version = (int) this._version;
      numArray3[index3] = (byte) version;
      byte[] numArray4 = bytes;
      int index4 = num4;
      int num5 = index4 + 1;
      int storage = (int) this._storage;
      numArray4[index4] = (byte) storage;
      foreach (byte num6 in Conversion.StringToByteArray(this._menuString, 15, (byte) 32))
        bytes[num5++] = num6;
      return bytes;
    }

    public override bool IsMasterCommand => true;
  }
}
