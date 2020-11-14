// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.Commands.CommandFactory
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.ReadOut.Commands;
using MultiLang;
using System;

namespace BriconLib.PAS.Shared.Commands
{
  public class CommandFactory
  {
    public Command Create(byte[] bytes)
    {
      switch (new Command(bytes).CMD)
      {
        case Command.CommandType.GetFlight:
          return (Command) new GetFlightCommand(bytes);
        case Command.CommandType.StartBasketFancier:
          return (Command) new StartBasketFancierCommand(bytes);
        case Command.CommandType.BasketPigeon:
          return (Command) new BasketPigeonCommand(bytes);
        case Command.CommandType.FinishBasketFancier:
          return (Command) new FinishBasketFancierCommand(bytes);
        case Command.CommandType.EmergencyLink:
          return (Command) new EmergencyLinkCommand(bytes);
        case Command.CommandType.CancelPigeon:
          return (Command) new CancelPigeonCommand(bytes);
        case Command.CommandType.StartReadOut:
          return (Command) new ReadOutCommand(bytes);
        case Command.CommandType.ReadOutPigeon:
          return (Command) new ReadOutPigeonCommand(bytes);
        case Command.CommandType.StartReadOutFancier:
          return (Command) new StartReadOutFancierCommand(bytes);
        case Command.CommandType.FinishReadOutFancier:
          return (Command) new FinishReadOutFancierCommand(bytes);
        default:
          throw new InvalidOperationException(ml.ml_string(1390, "Unsupported command"));
      }
    }
  }
}
