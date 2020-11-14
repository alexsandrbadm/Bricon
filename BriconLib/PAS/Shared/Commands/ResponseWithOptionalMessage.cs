// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.Commands.ResponseWithOptionalMessage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;

namespace BriconLib.PAS.Shared.Commands
{
  public class ResponseWithOptionalMessage : Response
  {
    private string _message { get; set; }

    public ResponseWithOptionalMessage(
      Command.CommandType command,
      Response.StatusType status,
      string message = null)
      : base(command, status, ResponseWithOptionalMessage.BuildDataBytes(message))
    {
      this._message = message;
    }

    public static byte[] BuildDataBytes(string message) => string.IsNullOrWhiteSpace(message) ? new byte[0] : Conversion.StringToByteArray(message, 20);

    public override string ToString() => string.Format("{0} - {1} - {2}", (object) this.CMD, (object) this.Status, (object) this._message);
  }
}
