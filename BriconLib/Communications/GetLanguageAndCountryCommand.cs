// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetLanguageAndCountryCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class GetLanguageAndCountryCommand : Command
  {
    public string ReceivedLanguage = string.Empty;
    public string ReceivedCountry = string.Empty;

    public override string ToString() => this.AddStatusText(ml.ml_string(143, "Get Language and Country codes"));

    public override byte[] ToBytes() => this.CreateBytes((byte) 16, (byte) 100, (byte) 0);

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      string[] stringArray = this.ConvertDataBytesToStringArray(response);
      if (stringArray.Length < 2)
        return;
      this.ReceivedLanguage = stringArray[0];
      this.ReceivedCountry = stringArray[1];
      if (this.ReceivedLanguage.ToUpper() == "RO")
        this.ReceivedCountry = "RO";
      if (this.ReceivedLanguage.ToUpper() == "MD")
        this.ReceivedCountry = "MD";
      if (!(this.ReceivedCountry == "AR"))
        return;
      if (Utils.IsCountry("IQ"))
        this.ReceivedCountry = "IQ";
      else if (Utils.IsCountry("RN"))
        this.ReceivedCountry = "RN";
      else
        this.ReceivedCountry = "KSA";
    }

    public override bool IsMasterCommand => true;

    public override bool HasFeedBack => true;
  }
}
