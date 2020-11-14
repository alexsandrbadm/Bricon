// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendSecSyncCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using CoreLib.Helpers;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class SendSecSyncCommand : Command
  {
    private readonly string _clubId;
    private readonly string _raceId;

    public SendSecSyncCommand(string clubId, string raceId)
    {
      this._clubId = clubId;
      this._raceId = raceId;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(1352, "Sync race {0} with clubId {1}"), (object) this._raceId, (object) this._clubId));

    public override byte[] ToBytes()
    {
      byte length = 26;
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 202 : (byte) 90, length);
      int num1 = 3;
      DateTime networkTimeCached = NtpClient.GetNetworkTimeCached();
      foreach (byte num2 in Conversion.StringToByteArray(networkTimeCached.ToString("ddMMyy"), 6, (byte) 32))
        bytes[num1++] = num2;
      foreach (byte num2 in Conversion.StringToByteArray(networkTimeCached.ToString("HHmmss"), 6, (byte) 32))
        bytes[num1++] = num2;
      foreach (byte num2 in Conversion.StringToByteArray(this._clubId, 4, (byte) 32))
        bytes[num1++] = num2;
      foreach (byte num2 in Conversion.StringToByteArray(this._raceId, 4, (byte) 32))
        bytes[num1++] = num2;
      foreach (byte num2 in Conversion.StringToByteArray("000000", 6, (byte) 32))
        bytes[num1++] = num2;
      return bytes;
    }
  }
}
