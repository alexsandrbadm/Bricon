﻿// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.StartReadoutCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Communications
{
  public class StartReadoutCommand : Command
  {
    public override string ToString() => this.AddStatusText(ml.ml_string(1354, "Start Read Out"));

    public override byte[] ToBytes() => this.CreateBytes((byte) 16, (byte) 225, (byte) 0);

    public override void HandleResponse(Response response) => base.HandleResponse(response);

    public override void HandleFailedResponce(ResponseStatus status) => base.HandleFailedResponce(status);

    public override bool IsMasterCommand => true;
  }
}