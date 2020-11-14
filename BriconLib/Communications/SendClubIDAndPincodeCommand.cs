// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.SendClubIDAndPincodeCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public class SendClubIDAndPincodeCommand : Command
  {
    private string _clubID;
    private string _pincode;
    private string _name;
    public int ID;

    public SendClubIDAndPincodeCommand(string clubID, string pincode, string name, int ID)
    {
      this._clubID = clubID;
      this._pincode = pincode;
      this._name = name;
      this.ID = ID;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(173, "Send ClubID '{0}' or club {1}"), (object) this._clubID, (object) this._name));

    public override byte[] ToBytes()
    {
      string str = this._clubID + ";" + this._pincode + ";";
      byte length = Convert.ToByte(str.Length + 1);
      byte[] bytes = this.CreateBytes((byte) 16, (byte) 99, length);
      int num1 = 3;
      foreach (byte num2 in Conversion.StringToByteArray(str, (int) length))
        bytes[num1++] = num2;
      return bytes;
    }

    public override bool IsMasterCommand => true;

    public override bool HasFeedBack => true;
  }
}
