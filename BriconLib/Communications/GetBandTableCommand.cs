// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.GetBandTableCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;

namespace BriconLib.Communications
{
  public class GetBandTableCommand : Command
  {
    private int _index;
    public int FancierID;
    public string ReceivedElRing = string.Empty;
    public string ReceivedDBRing = string.Empty;
    public string ReceivedColor = string.Empty;
    public byte ReceivedPos;
    public bool ReceivedSex;

    public GetBandTableCommand()
    {
      this._index = 0;
      this.FancierID = -1;
    }

    public GetBandTableCommand(int fancierID)
    {
      this._index = 0;
      this.FancierID = fancierID;
    }

    private GetBandTableCommand(int index, int fancierID)
    {
      this._index = index;
      this.FancierID = fancierID;
    }

    public override string ToString() => this.AddStatusText(string.Format(ml.ml_string(135, "Get Ring with index {0}"), (object) (this._index + 1)));

    public override byte[] ToBytes()
    {
      byte length = Utils.IsCountry("PL") ? (byte) 3 : (byte) 2;
      byte[] bytes = this.CreateBytes(CommunicationState.Instance.BAAddress, CommunicationState.Instance.BAAddress == (byte) 0 ? (byte) 194 : (byte) 82, length);
      bytes[3] = (byte) (this._index >> 8);
      bytes[4] = (byte) (this._index & (int) byte.MaxValue);
      return bytes;
    }

    public override void HandleResponse(Response response)
    {
      base.HandleResponse(response);
      if (response.Status != ResponseStatus.OK)
        return;
      string str1 = Conversion.ByteArrayToString(response.DataBytes, 2, 8);
      if (Utils.IsUKProtocol())
      {
        if (Utils.IsCountry("PT") || Utils.IsCountry("ES"))
        {
          string str2 = Conversion.ByteArrayToString(response.DataBytes, 10, 14, false);
          this.ReceivedSex = str2[13] != ' ' && str2[13] != 'C';
          this.ReceivedDBRing = str2.Substring(0, 13);
          this.ReceivedColor = "";
          this.ReceivedPos = (byte) 0;
        }
        else if (Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL"))
        {
          string str2 = Conversion.ByteArrayToString(response.DataBytes, 10, 17, false);
          this.ReceivedSex = str2[str2.Length - 1] != ' ' && str2[str2.Length - 1] != 'C';
          this.ReceivedDBRing = str2.Substring(0, str2.Length - 1);
          this.ReceivedColor = Conversion.ByteArrayToString(response.DataBytes, 10 + str2.Length, 4, true);
          this.ReceivedPos = (byte) 0;
        }
        else
        {
          string str2 = Conversion.ByteArrayToString(response.DataBytes, 10, 23, false);
          this.ReceivedSex = !Utils.IsCountry("HU") ? str2[17] != ' ' && str2[17] != 'C' : str2[17] != ' ';
          this.ReceivedDBRing = str2.Substring(0, 17);
          this.ReceivedColor = str2.Substring(18, 4);
          this.ReceivedPos = response.DataBytes[response.DataBytes.Length - 1];
        }
      }
      else
      {
        string str2 = Conversion.ByteArrayToString(response.DataBytes, 10, 14, false);
        this.ReceivedSex = !str2.EndsWith(" ") && !str2.EndsWith("C");
        this.ReceivedDBRing = str2.Substring(0, 13);
      }
      if ((Utils.IsCountry("CZ") || Utils.IsCountry("SK") || Utils.IsCountry("PL")) && this.ReceivedDBRing.LastIndexOf('-') < 6)
        this.ReceivedDBRing = this.ReceivedDBRing.Insert(10, "-");
      this.ReceivedElRing = str1;
      CommunicationPool.Instance.PostNextCommand((Command) new GetBandTableCommand(this._index + 1, this.FancierID));
    }

    public override bool HasFeedBack => true;
  }
}
