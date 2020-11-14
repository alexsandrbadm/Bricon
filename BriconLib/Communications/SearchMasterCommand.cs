// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SearchMasterCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Communications
{
  public class SearchMasterCommand : Command
  {
    private byte _baudrate;

    public SearchMasterCommand(byte baudrate) => this._baudrate = baudrate;

    public override string ToString() => this.AddStatusText("Search Master with update function use baudrate " + this._baudrate.ToString());

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes((byte) 16, (byte) 112, (byte) 2);
      int index1 = 3;
      int num1 = index1 + 1;
      bytes[index1] = (byte) 1;
      int index2 = num1;
      int num2 = index2 + 1;
      bytes[index2] = this._baudrate;
      return bytes;
    }

    public override bool IsMasterCommand => true;
  }
}
