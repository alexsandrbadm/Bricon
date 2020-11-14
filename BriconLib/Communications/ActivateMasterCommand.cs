// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.ActivateMasterCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;

namespace BriconLib.Communications
{
  public class ActivateMasterCommand : Command
  {
    public override string ToString() => this.AddStatusText(!Settings.Default.AntenneWithoutMaster ? string.Format(ml.ml_string(103, "Activate Master")) : string.Format(ml.ml_string(489, "Activate Antenna")));

    public override byte[] ToBytes()
    {
      if (!Settings.Default.AntenneWithoutMaster || Utils.IsCountry("JP") || (Utils.IsCountry("IR") || Utils.IsCountry("UK")) || Utils.IsCountry("KV"))
        return this.CreateBytes((byte) 16, (byte) 97, (byte) 0);
      byte[] bytes = this.CreateBytes((byte) 0, (byte) 189, (byte) 2);
      bytes[3] = bytes[4] = (byte) 0;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      CommunicationState.Instance.WaitingToConnectMaster = false;
      CommunicationState.Instance.MasterFound = true;
      for (int index = 0; index < 6; ++index)
        CommunicationState.Instance.FancierVersionNumbers[index] = (int) byte.MaxValue;
      if (!Settings.Default.AntenneWithoutMaster)
      {
        if (response.DataBytes.Length > 3 && response.DataBytes[0] != (byte) 77 && response.DataBytes[0] != (byte) 66)
        {
          if (response.DataBytes.Length > 4 && response.DataBytes[2] != (byte) 77 && response.DataBytes[2] != (byte) 66)
          {
            CommunicationState.Instance.MasterVersionNumber = ((int) response.DataBytes[0] << 8) + (int) response.DataBytes[1];
            for (int index = 0; index < 6; ++index)
              CommunicationState.Instance.FancierVersionNumbers[index] = (int) response.DataBytes[2 + index];
            CommunicationState.Instance.MasterVersion = Conversion.ByteArrayToString(response.DataBytes, 8, response.DataBytes.Length - 8);
          }
          else
          {
            CommunicationState.Instance.MasterVersionNumber = ((int) response.DataBytes[0] << 8) + (int) response.DataBytes[1];
            CommunicationState.Instance.MasterVersion = Conversion.ByteArrayToString(response.DataBytes, 2, response.DataBytes.Length - 2);
          }
        }
        else
        {
          CommunicationState.Instance.MasterVersionNumber = (int) ushort.MaxValue;
          CommunicationState.Instance.MasterVersion = Conversion.ByteArrayToString(response.DataBytes);
        }
      }
      else
      {
        CommunicationState.Instance.MasterVersionNumber = (int) ushort.MaxValue;
        CommunicationState.Instance.MasterVersion = "";
      }
    }

    public override void HandleFailedResponce(ResponseStatus status)
    {
      base.HandleFailedResponce(status);
      CommunicationState.Instance.MasterFound = false;
    }

    public override bool IsMasterCommand => true;
  }
}
