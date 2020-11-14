// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.FancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Monitor
{
  public class FancierCommand : Command
  {
    private byte[] _bytes;

    public FancierCommand()
    {
      this.Name = "Test Naam";
      this.License = "12345678";
    }

    public FancierCommand(byte[] bytes)
    {
      this._bytes = bytes;
      int num = 5;
      this.License = Conversion.ByteArrayToString(this._bytes, 10 + num, 10);
      this.Name = Conversion.ByteArrayToString(this._bytes, 22 + num, 20);
      this.City = Conversion.ByteArrayToString(this._bytes, 22 + num + 20 + 20 + 8, 20);
    }

    public override string ToString() => string.Format(ml.ml_string(889, "Fancier data received, name : {0} "), (object) this.Name);

    public string Name { get; private set; }

    public string License { get; private set; }

    public string City { get; private set; }
  }
}
