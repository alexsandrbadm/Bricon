// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetClubIDAndPincodeCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Communications
{
  public class GetClubIDAndPincodeCommand : Command
  {
    public int ClubID;
    public string Name = string.Empty;
    public string ReceivedClubID = string.Empty;
    public string ReceivedPinCode = string.Empty;

    public GetClubIDAndPincodeCommand(int clubID, string name)
    {
      this.ClubID = clubID;
      this.Name = name;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(137, "Get ClubID and Pincode for '{0}'"), (object) this.Name));

    public override byte[] ToBytes() => this.CreateBytes((byte) 16, (byte) 99, (byte) 0);

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      string[] stringArray = this.ConvertDataBytesToStringArray(response);
      if (stringArray.Length < 2)
        return;
      this.ReceivedClubID = stringArray[0];
      this.ReceivedPinCode = stringArray[1];
    }

    public override bool IsMasterCommand => true;

    public override bool HasFeedBack => true;
  }
}
