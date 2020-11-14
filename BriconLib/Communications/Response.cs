// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.Response
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Communications
{
  public class Response
  {
    private ResponseStatus _status;
    private byte[] _dataBytes;

    public Response(ResponseStatus status)
    {
      this._status = status;
      this._dataBytes = new byte[0];
    }

    public Response(ResponseStatus status, byte[] bytes)
    {
      this._status = status;
      this._dataBytes = bytes;
    }

    public ResponseStatus Status => this._status;

    public byte[] DataBytes => this._dataBytes;
  }
}
