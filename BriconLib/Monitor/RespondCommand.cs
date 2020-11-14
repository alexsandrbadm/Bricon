// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.RespondCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;

namespace BriconLib.Monitor
{
  public class RespondCommand : Command
  {
    public byte Status;

    public RespondCommand(byte status) => this.Status = status;

    public override string ToString() => string.Format(ml.ml_string(1159, "Respond message sended: Status : {0}"), (object) this.Status);

    public override byte[] ToBytes()
    {
      int num1 = 0;
      byte[] numArray1 = new byte[7];
      byte[] numArray2 = numArray1;
      int index1 = num1;
      int num2 = index1 + 1;
      numArray2[index1] = (byte) 51;
      byte[] numArray3 = numArray1;
      int index2 = num2;
      int num3 = index2 + 1;
      numArray3[index2] = (byte) 133;
      byte[] numArray4 = numArray1;
      int index3 = num3;
      int num4 = index3 + 1;
      numArray4[index3] = (byte) 16;
      byte[] numArray5 = numArray1;
      int index4 = num4;
      int num5 = index4 + 1;
      numArray5[index4] = (byte) 2;
      byte[] numArray6 = numArray1;
      int index5 = num5;
      int num6 = index5 + 1;
      numArray6[index5] = (byte) 0;
      byte[] numArray7 = numArray1;
      int index6 = num6;
      int index7 = index6 + 1;
      numArray7[index6] = (byte) 0;
      numArray1[index7] = (byte) 0;
      for (int index8 = 0; index8 < numArray1.Length - 1; ++index8)
        numArray1[index7] += numArray1[index8];
      return numArray1;
    }
  }
}
