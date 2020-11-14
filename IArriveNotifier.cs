// Decompiled with JetBrains decompiler
// Type: IArriveNotifier
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.WCFService.Data;
using System.CodeDom.Compiler;
using System.ServiceModel;

[GeneratedCode("System.ServiceModel", "4.0.0.0")]
[ServiceContract(ConfigurationName = "IArriveNotifier")]
public interface IArriveNotifier
{
  [OperationContract(Action = "http://tempuri.org/IArriveNotifier/GetData", ReplyAction = "http://tempuri.org/IArriveNotifier/GetDataResponse")]
  ArriveNotifierResponse GetData(string login, string password);
}
