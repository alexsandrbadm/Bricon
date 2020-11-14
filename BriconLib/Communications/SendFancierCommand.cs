// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendFancierCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class SendFancierCommand : Command
  {
    public static byte fancierPos;
    public int FancierID;
    private string _licence = string.Empty;
    private string _name = string.Empty;
    private string _address = string.Empty;
    private string _zipcode = string.Empty;
    private string _city = string.Empty;
    private string _coordinateX = string.Empty;
    private string _coordinateY = string.Empty;
    private byte _fancierPos;
    private string _serial = string.Empty;
    public string ReceivedSerial = string.Empty;

    public SendFancierCommand(
      int fancierID,
      string licence,
      string name,
      string address,
      string zipcode,
      string city,
      string coordinateX,
      string coordinateY,
      string serial)
    {
      this.FancierID = fancierID;
      this._licence = licence;
      this._name = name;
      this._address = address;
      this._zipcode = zipcode;
      this._city = city;
      this._coordinateX = coordinateX;
      this._coordinateY = coordinateY;
      this._serial = serial;
      this._fancierPos = SendFancierCommand.fancierPos;
    }

    public override string ToString()
    {
      string str;
      if (this._fancierPos == (byte) 1)
        str = string.Format(ml.ml_string(172, "Send SECOND Fancier {0} with loft number {1} and serial {2} to BA with serial {3}"), (object) this._name, (object) this._licence, (object) this._serial, (object) this.ReceivedSerial);
      else if (this._fancierPos == (byte) 2)
        str = string.Format(ml.ml_string(496, "Send THIRD Fancier {0} with loft number {1} and serial {2} to BA with serial {3}"), (object) this._name, (object) this._licence, (object) this._serial, (object) this.ReceivedSerial);
      else
        str = string.Format(ml.ml_string(497, "Send Fancier {0} with loft number {1} and serial {2} to BA with serial {3}"), (object) this._name, (object) this._licence, (object) this._serial, (object) this.ReceivedSerial);
      return this.AddStatusText(str);
    }

    public override byte[] ToBytes()
    {
      byte num1 = 8;
      if (Utils.IsInternationaal())
        num1 = (byte) 10;
      byte length = (byte) (96U + (uint) num1);
      if (Utils.IsUKProtocol())
        length = (byte) 105;
      if (Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        length -= (byte) 4;
      this.ReceivedSerial = Conversion.SerialFromVersion(CommunicationState.Instance.BAVersion, CommunicationState.Instance.BAAddress);
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 193 : (byte) 81, length);
      int num2 = 3;
      if (Utils.IsUKProtocol() && !Utils.IsCountry("PT") && !Utils.IsCountry("ES"))
      {
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.StripLicense(this._licence), 10, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.FromUnicode(this._name), 24, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._address, 24, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._zipcode, 8, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._city, 18, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._coordinateX, 10, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._coordinateY, 10, (byte) 32))
          bytes[num2++] = num3;
        byte[] numArray = bytes;
        int index = num2;
        int num4 = index + 1;
        int fancierPos = (int) this._fancierPos;
        numArray[index] = (byte) fancierPos;
      }
      else
      {
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.StripLicense(this._licence), (int) num1, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.FromUnicode(this._name), 25, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._address, 25, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._zipcode, 6, (byte) 32))
          bytes[num2++] = num3;
        foreach (byte num3 in Conversion.StringToByteArray(this._city, 20, (byte) 32))
          bytes[num2++] = num3;
        if (Utils.IsCountry("KSA") || Utils.IsCountry("IQ") || Utils.IsCountry("RN"))
        {
          foreach (byte num3 in Conversion.StringToByteArray(this._coordinateX.Replace("+", "").Replace(".", ""), 8, (byte) 32))
            bytes[num2++] = num3;
          foreach (byte num3 in Conversion.StringToByteArray(this._coordinateY.Replace("+", "").Replace(".", ""), 8, (byte) 32))
            bytes[num2++] = num3;
        }
        else
        {
          foreach (byte num3 in Conversion.StringToByteArray(this._coordinateX, 10, (byte) 32))
            bytes[num2++] = num3;
          foreach (byte num3 in Conversion.StringToByteArray(this._coordinateY, 10, (byte) 32))
            bytes[num2++] = num3;
        }
      }
      return bytes;
    }

    public override bool HasFeedBack => true;
  }
}
