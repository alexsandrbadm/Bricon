// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.CheckRingCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class CheckRingCommand : Command
  {
    private string _name;
    public string Ring = string.Empty;
    public byte StatusSecondPage;
    public uint Licence;
    public byte MasterType;
    public ushort SerialMaster;
    public byte Year;

    public CheckRingCommand(string name) => this._name = name;

    public override string ToString() => this.AddStatusText(this._name == null ? string.Format(ml.ml_string(888, "Check Ring for export")) : string.Format(ml.ml_string(490, "Check Ring for '{0}'"), (object) this._name));

    public override byte[] ToBytes()
    {
      byte[] bytes = this.CreateBytes((byte) 16, (byte) 102, (byte) 1);
      bytes[3] = (byte) 10;
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      this.Ring = Conversion.ByteArrayToString(response.DataBytes, 0, 8);
      if (!Utils.IsCountry("BE"))
        return;
      int num1 = 10;
      byte[] dataBytes1 = response.DataBytes;
      int index1 = num1;
      int num2 = index1 + 1;
      this.StatusSecondPage = dataBytes1[index1];
      if (this.StatusSecondPage != (byte) 1 || response.DataBytes.Length <= 12)
        return;
      byte[] dataBytes2 = response.DataBytes;
      int index2 = num2;
      int num3 = index2 + 1;
      this.Licence = (uint) dataBytes2[index2] << 24;
      int licence1 = (int) this.Licence;
      byte[] dataBytes3 = response.DataBytes;
      int index3 = num3;
      int num4 = index3 + 1;
      int num5 = (int) dataBytes3[index3] << 16;
      this.Licence = (uint) (licence1 + num5);
      int licence2 = (int) this.Licence;
      byte[] dataBytes4 = response.DataBytes;
      int index4 = num4;
      int num6 = index4 + 1;
      int num7 = (int) dataBytes4[index4] << 8;
      this.Licence = (uint) (licence2 + num7);
      int licence3 = (int) this.Licence;
      byte[] dataBytes5 = response.DataBytes;
      int index5 = num6;
      int num8 = index5 + 1;
      int num9 = (int) dataBytes5[index5];
      this.Licence = (uint) (licence3 + num9);
      byte[] dataBytes6 = response.DataBytes;
      int index6 = num8;
      int num10 = index6 + 1;
      this.MasterType = dataBytes6[index6];
      byte[] dataBytes7 = response.DataBytes;
      int index7 = num10;
      int num11 = index7 + 1;
      this.SerialMaster = (ushort) ((uint) dataBytes7[index7] << 8);
      int serialMaster = (int) this.SerialMaster;
      byte[] dataBytes8 = response.DataBytes;
      int index8 = num11;
      int num12 = index8 + 1;
      int num13 = (int) dataBytes8[index8];
      this.SerialMaster = (ushort) (serialMaster + num13);
      byte[] dataBytes9 = response.DataBytes;
      int index9 = num12;
      int num14 = index9 + 1;
      this.Year = dataBytes9[index9];
    }

    public void AskNextRing() => CommunicationPool.Instance.PostNextCommand((Command) new CheckRingCommand(this._name));

    public override bool IsMasterCommand => true;

    public override bool HasFeedBack => true;

    private bool CheckOnLicense() => Utils.IsCountry("BE");
  }
}
