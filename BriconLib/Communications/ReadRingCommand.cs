// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.ReadRingCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class ReadRingCommand : Command
  {
    private string _licence;
    private string _name;
    private int _fancierID;
    public string ReceivedElRing = string.Empty;

    public ReadRingCommand(string licence, string name, int fancierID)
    {
      this._licence = licence;
      this._name = name;
      this._fancierID = fancierID;
    }

    public override string ToString()
    {
      string str = string.Format(ml.ml_string(266, "Read Ring for '{0}' - '{1}'"), (object) this._name, (object) this._licence);
      if (this.CheckOnLicense())
        str += ml.ml_string(222, " with loft number checking");
      return this.AddStatusText(str);
    }

    public override byte[] ToBytes()
    {
      if (Settings.Default.AntenneWithoutMaster && !Utils.IsCountry("IR") && (!Utils.IsCountry("UK") && !Utils.IsCountry("KV")) && !Utils.IsCountry("JP"))
      {
        byte[] bytes = this.CreateBytes((byte) 0, (byte) 183, (byte) 2);
        bytes[3] = (byte) 0;
        bytes[4] = (byte) 5;
        return bytes;
      }
      byte[] bytes1;
      int num1;
      if (Utils.IsCountry("UK"))
      {
        bytes1 = this.CreateBytes((byte) 16, (byte) 102, (byte) 11);
        int num2 = 3;
        int num3;
        switch (Settings.Default.Union)
        {
          case "IHU":
            byte[] numArray1 = bytes1;
            int index1 = num2;
            num3 = index1 + 1;
            numArray1[index1] = (byte) 1;
            break;
          case "RPRA":
            byte[] numArray2 = bytes1;
            int index2 = num2;
            num3 = index2 + 1;
            numArray2[index2] = (byte) 2;
            break;
          case "NEHU":
            byte[] numArray3 = bytes1;
            int index3 = num2;
            num3 = index3 + 1;
            numArray3[index3] = (byte) 3;
            break;
          case "NWHU":
            byte[] numArray4 = bytes1;
            int index4 = num2;
            num3 = index4 + 1;
            numArray4[index4] = (byte) 5;
            break;
          case "WHU":
            byte[] numArray5 = bytes1;
            int index5 = num2;
            num3 = index5 + 1;
            numArray5[index5] = (byte) 7;
            break;
          default:
            byte[] numArray6 = bytes1;
            int index6 = num2;
            num3 = index6 + 1;
            numArray6[index6] = (byte) 0;
            break;
        }
        foreach (byte num4 in Conversion.StringToByteArray(Conversion.StripLicense(this._licence), 9))
          bytes1[num3++] = num4;
        byte[] numArray7 = bytes1;
        int index7 = num3;
        num1 = index7 + 1;
        numArray7[index7] = (byte) 32;
      }
      else if (Utils.IsCountry("HU") || Utils.IsCountry("RO") || (Utils.IsCountry("MD") || Utils.IsCountry("IR")) || Utils.IsCountry("KV"))
      {
        bytes1 = this.CreateBytes((byte) 16, (byte) 102, (byte) 11);
        int num2 = 3;
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.StripLicense(this._licence), 10))
          bytes1[num2++] = num3;
        byte[] numArray = bytes1;
        int index = num2;
        num1 = index + 1;
        numArray[index] = (byte) 32;
      }
      else
        bytes1 = this.CreateBytes((byte) 16, (byte) 102, this.CheckOnLicense() ? (byte) 8 : (byte) 0);
      if (this.CheckOnLicense())
      {
        int num2 = 3;
        foreach (byte num3 in Conversion.StringToByteArray(Conversion.StripLicense(this._licence), 8))
          bytes1[num2++] = num3;
      }
      return bytes1;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      if (Settings.Default.AntenneWithoutMaster)
      {
        this.ReceivedElRing = "";
        for (int index = 2; index < 6; ++index)
          this.ReceivedElRing += response.DataBytes[index].ToString("X2");
      }
      else
        this.ReceivedElRing = Conversion.ByteArrayToString(response.DataBytes, 0, 8);
    }

    public void AskNextRing() => CommunicationPool.Instance.PostNextCommand((Command) new ReadRingCommand(this._licence, this._name, this._fancierID));

    public override bool IsMasterCommand => true;

    public override bool HasFeedBack => true;

    private bool CheckOnLicense() => Settings.Default.Country.Equals("BE", StringComparison.InvariantCultureIgnoreCase);
  }
}
