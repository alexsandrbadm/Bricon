// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.Command
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;

namespace BriconLib.Communications
{
  public abstract class Command
  {
    protected ResponseStatus _status = ResponseStatus.None;

    public virtual bool IsMasterCommand => false;

    public virtual bool HasFeedBack => false;

    public override string ToString() => throw new NotImplementedException();

    public virtual byte[] ToBytes() => throw new NotImplementedException();

    protected byte[] CreateBytes(byte adress, byte cmd, byte length)
    {
      int num1 = 0;
      byte[] numArray = new byte[3 + (int) length];
      int index1 = num1;
      int num2 = index1 + 1;
      numArray[index1] = adress;
      int index2 = num2;
      int num3 = index2 + 1;
      numArray[index2] = cmd;
      int index3 = num3;
      int num4 = index3 + 1;
      numArray[index3] = length;
      return numArray;
    }

    protected string[] ConvertDataBytesToStringArray(Response response) => Conversion.ByteArrayToString(response.DataBytes).Split(';');

    public virtual void HandleResponse(Response response) => this._status = response.Status;

    public virtual void HandleFailedResponce(ResponseStatus status) => this._status = status;

    protected string AddStatusText(string str) => this._status != ResponseStatus.None ? str + " : " + this.StatusText : str;

    public virtual bool Success => this._status == ResponseStatus.OK || this._status == ResponseStatus.NoRecordThatCompliesTheRequest;

    public ResponseStatus Status
    {
      get => this._status;
      set => this._status = value;
    }

    protected string StatusText
    {
      get
      {
        switch (this._status)
        {
          case ResponseStatus.OK:
            return ml.ml_string(114, "OK ");
          case ResponseStatus.NoFancierData:
            return ml.ml_string(109, "ERROR : No Fancier Data!!!");
          case ResponseStatus.InvalidDataFormat:
            return ml.ml_string(110, "ERROR : Invalid Data Format!!!");
          case ResponseStatus.FlightDataNotDeleted:
            return ml.ml_string(111, "ERROR : Flight data not released!!!");
          case ResponseStatus.NoRecordThatCompliesTheRequest:
            return ml.ml_string(112, "No more records");
          case ResponseStatus.NoPigeonTable:
            return ml.ml_string(113, "ERROR : No Pigeon Table!!!");
          case ResponseStatus.ELRingAlreadyPresent:
            return ml.ml_string(115, "ERROR : ELRing Already Present!!!");
          case ResponseStatus.OutOfRange:
            return ml.ml_string(116, "ERROR : Out of Range!!!");
          case ResponseStatus.InvalidPincode:
            return ml.ml_string(117, "ERROR : Invalid Pincode!!!");
          case ResponseStatus.UnknownCommand:
            return ml.ml_string(118, "ERROR : Unknown Command!!!");
          case ResponseStatus.ChecksumError:
            return ml.ml_string(119, "ERROR : Communication error!!!");
          case ResponseStatus.NoRingRead:
            return ml.ml_string(492, "No ring in antenna");
          case ResponseStatus.ActualBaudrateNotChanged:
            return ml.ml_string(363, "Actual Baudrate Not Changed");
          case ResponseStatus.SwitchAfterResponceTo9600:
            return ml.ml_string(364, "Switch After Responce To 9600");
          case ResponseStatus.SwitchAfterResponceTo38400:
            return ml.ml_string(365, "Switch After Responce To 38400");
          case ResponseStatus.StorageNotAllowed:
            return ml.ml_string(366, "Storage Not Allowed");
          case ResponseStatus.IllegalParameters:
            return ml.ml_string(367, "Illegal parameters");
          case ResponseStatus.IllegalUpdateCommand:
            return ml.ml_string(368, "Illegal Update Command");
          case ResponseStatus.UserAbort:
            return ml.ml_string(120, "User aborted");
          case ResponseStatus.PCCommStopped:
            return ml.ml_string(335, "Communication stopped");
          case ResponseStatus.PCInvalidByteReceived:
            return ml.ml_string(121, "ERROR : Invalid characters in received message!!!");
          case ResponseStatus.PCChecksumError:
            return ml.ml_string(122, "ERROR : Checksum error in received message!!!");
          case ResponseStatus.PCTimeOut:
            return ml.ml_string(123, "ERROR : Timeout in communication!!!");
          case ResponseStatus.PCError:
            return ml.ml_string(124, "ERROR : Program error!!!");
          default:
            return string.Format(ml.ml_string(125, "ERROR : Unknown error : {0}!!!"), (object) (byte) this._status);
        }
      }
    }

    public virtual bool NoMoreRecords => this._status == ResponseStatus.NoRecordThatCompliesTheRequest;
  }
}
