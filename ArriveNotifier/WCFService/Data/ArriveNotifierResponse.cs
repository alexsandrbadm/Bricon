// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.WCFService.Data.ArriveNotifierResponse
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ArriveNotifier.WCFService.Data
{
  [DebuggerStepThrough]
  [GeneratedCode("System.Runtime.Serialization", "4.0.0.0")]
  [DataContract(Name = "ArriveNotifierResponse", Namespace = "http://schemas.datacontract.org/2004/07/ArriveNotifier.WCFService.Data")]
  public class ArriveNotifierResponse : IExtensibleDataObject
  {
    private ExtensionDataObject extensionDataField;
    private ArriveNotifierData AllDataField;
    private string MessageField;
    private bool SuccessField;

    public ExtensionDataObject ExtensionData
    {
      get => this.extensionDataField;
      set => this.extensionDataField = value;
    }

    [DataMember]
    public ArriveNotifierData AllData
    {
      get => this.AllDataField;
      set => this.AllDataField = value;
    }

    [DataMember]
    public string Message
    {
      get => this.MessageField;
      set => this.MessageField = value;
    }

    [DataMember]
    public bool Success
    {
      get => this.SuccessField;
      set => this.SuccessField = value;
    }
  }
}
