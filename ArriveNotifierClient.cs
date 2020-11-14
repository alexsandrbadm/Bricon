// Decompiled with JetBrains decompiler
// Type: ArriveNotifierClient
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.WCFService.Data;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "4.0.0.0")]
public class ArriveNotifierClient : ClientBase<IArriveNotifier>, IArriveNotifier
{
  public ArriveNotifierClient()
  {
  }

  public ArriveNotifierClient(string endpointConfigurationName)
    : base(endpointConfigurationName)
  {
  }

  public ArriveNotifierClient(string endpointConfigurationName, string remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public ArriveNotifierClient(string endpointConfigurationName, EndpointAddress remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public ArriveNotifierClient(Binding binding, EndpointAddress remoteAddress)
    : base(binding, remoteAddress)
  {
  }

  public ArriveNotifierResponse GetData(string login, string password) => this.Channel.GetData(login, password);
}
