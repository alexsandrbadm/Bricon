// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class GetFancierCommand : Command
  {
    public int FancierID;
    public string OldName = string.Empty;
    public string OldLicence = string.Empty;
    public string ReceivedSerial = string.Empty;
    public string ReceivedLicentie = string.Empty;
    public string ReceivedNaam = string.Empty;
    public string ReceivedAdres = string.Empty;
    public string ReceivedPostcode = string.Empty;
    public string ReceivedGemeente = string.Empty;
    public string ReceivedFancierPos = string.Empty;
    public int ReceivedCoordX;
    public int ReceivedCoordY;
    public static byte[] LastDataRecord;

    public GetFancierCommand() => this.FancierID = -1;

    public GetFancierCommand(int fancierID, string oldName, string oldLicence)
    {
      this.FancierID = fancierID;
      this.OldName = oldName;
      this.OldLicence = oldLicence;
    }

    public override string ToString() => this.AddStatusText(this.FancierID < 0 ? ml.ml_string(291, "Get Fancier data") : string.Format(ml.ml_string(139, "Get Fancier old data : {0} with loft number {1}"), (object) this.OldName, (object) this.OldLicence));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 193 : (byte) 81, (byte) 1);
      bytes[3] = (byte) 0;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      GetFancierCommand.LastDataRecord = response.DataBytes;
      this.ReceivedSerial = Conversion.SerialFromVersion(CommunicationState.Instance.BAVersion, CommunicationState.Instance.BAAddress);
      if (Utils.IsUKProtocol() && !Utils.IsCountry("PT") && !Utils.IsCountry("ES"))
      {
        this.ReceivedLicentie = Conversion.MakeLicense(Conversion.ByteArrayToString(response.DataBytes, 0, 10));
        this.ReceivedNaam = Conversion.ByteArrayToString(response.DataBytes, 10, 24);
        this.ReceivedNaam = Conversion.ToUnicode(this.ReceivedNaam);
        this.ReceivedAdres = Conversion.ByteArrayToString(response.DataBytes, 34, 24);
        this.ReceivedPostcode = Conversion.ByteArrayToString(response.DataBytes, 58, 8);
        this.ReceivedGemeente = Conversion.ByteArrayToString(response.DataBytes, 66, 18);
        string coordinate1 = Conversion.ByteArrayToString(response.DataBytes, 84, 10);
        string coordinate2 = Conversion.ByteArrayToString(response.DataBytes, 94, 10);
        this.ReceivedCoordX = Conversion.CoordinateToInt(coordinate1);
        this.ReceivedCoordY = Conversion.CoordinateToInt(coordinate2);
        this.ReceivedFancierPos = Conversion.ByteArrayToString(response.DataBytes, 104, 1);
      }
      else
      {
        int num = 8;
        if (Utils.IsInternationaal())
          num = 10;
        this.ReceivedLicentie = Conversion.MakeLicense(Conversion.ByteArrayToString(response.DataBytes, 0, num));
        this.ReceivedNaam = Conversion.ByteArrayToString(response.DataBytes, num, 25);
        this.ReceivedAdres = Conversion.ByteArrayToString(response.DataBytes, num + 25, 25);
        this.ReceivedPostcode = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25, 6);
        this.ReceivedGemeente = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25 + 6, 20);
        if (Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        {
          string coordinate1 = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25 + 6 + 20, 8);
          string coordinate2 = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25 + 6 + 20 + 8, 8);
          this.ReceivedCoordX = Conversion.CoordinateToInt(coordinate1);
          this.ReceivedCoordY = Conversion.CoordinateToInt(coordinate2);
        }
        else
        {
          string coordinate1 = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25 + 6 + 20, 10);
          string coordinate2 = Conversion.ByteArrayToString(response.DataBytes, num + 25 + 25 + 6 + 20 + 10, 10);
          this.ReceivedCoordX = Conversion.CoordinateToInt(coordinate1);
          this.ReceivedCoordY = Conversion.CoordinateToInt(coordinate2);
        }
      }
    }

    public override bool HasFeedBack => true;
  }
}
