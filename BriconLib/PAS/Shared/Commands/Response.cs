// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.Commands.Response
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace BriconLib.PAS.Shared.Commands
{
  public class Response
  {
    public Command.CommandType CMD { get; private set; }

    public Response.StatusType Status { get; private set; }

    public byte[] DataBytes { get; private set; }

    public Response(Command.CommandType command, Response.StatusType status, byte[] dataBytes)
    {
      this.CMD = command;
      this.Status = status;
      this.DataBytes = dataBytes;
    }

    public virtual byte[] ToBytes()
    {
      byte[] numArray1 = new byte[5 + this.DataBytes.Length + 1];
      int num1 = 0;
      byte num2 = 0;
      byte[] numArray2 = numArray1;
      int index1 = num1;
      int num3 = index1 + 1;
      numArray2[index1] = (byte) 51;
      byte num4 = (byte) ((uint) num2 + 51U);
      byte[] numArray3 = numArray1;
      int index2 = num3;
      int num5 = index2 + 1;
      numArray3[index2] = (byte) 119;
      byte num6 = (byte) ((uint) num4 + 119U);
      byte[] numArray4 = numArray1;
      int index3 = num5;
      int num7 = index3 + 1;
      int cmd = (int) (byte) this.CMD;
      numArray4[index3] = (byte) cmd;
      byte num8 = (byte) ((uint) num6 + (uint) (byte) this.CMD);
      byte[] numArray5 = numArray1;
      int index4 = num7;
      int num9 = index4 + 1;
      int num10 = (int) (byte) (this.DataBytes.Length + 1);
      numArray5[index4] = (byte) num10;
      byte num11 = (byte) ((uint) num8 + (uint) (byte) (this.DataBytes.Length + 1));
      byte[] numArray6 = numArray1;
      int index5 = num9;
      int destinationIndex = index5 + 1;
      int status = (int) (byte) this.Status;
      numArray6[index5] = (byte) status;
      byte num12 = (byte) ((uint) num11 + (uint) (byte) this.Status);
      Array.Copy((Array) this.DataBytes, 0, (Array) numArray1, destinationIndex, this.DataBytes.Length);
      int num13 = destinationIndex + this.DataBytes.Length;
      foreach (byte dataByte in this.DataBytes)
        num12 += dataByte;
      byte[] numArray7 = numArray1;
      int index6 = num13;
      int num14 = index6 + 1;
      int num15 = (int) num12;
      numArray7[index6] = (byte) num15;
      return numArray1;
    }

    public override string ToString() => string.Format("{0} - {1} - {2}", (object) this.CMD, (object) this.Status, (object) HexEncoding.ToString(this.DataBytes));

    public enum StatusType
    {
      Ok = 0,
      Error = 1,
      RingUnknown = 2,
      RingOfOtherFancier = 3,
      FancierNotFound = 4,
      FancierMismatch = 5,
      TimeNotOk = 6,
      SerialNotOk = 7,
      LicenseNotOk = 8,
      CantAddAnymore = 9,
      BCEOrPasError = 20, // 0x00000014
      BCEOrPasWarning = 21, // 0x00000015
    }
  }
}
