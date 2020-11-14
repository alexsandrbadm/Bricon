// Decompiled with JetBrains decompiler
// Type: PrintmanagerClient
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

[DebuggerStepThrough]
[GeneratedCode("System.ServiceModel", "3.0.0.0")]
public class PrintmanagerClient : ClientBase<IPrintmanager>, IPrintmanager
{
  public PrintmanagerClient()
  {
  }

  public PrintmanagerClient(string endpointConfigurationName)
    : base(endpointConfigurationName)
  {
  }

  public PrintmanagerClient(string endpointConfigurationName, string remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public PrintmanagerClient(string endpointConfigurationName, EndpointAddress remoteAddress)
    : base(endpointConfigurationName, remoteAddress)
  {
  }

  public PrintmanagerClient(Binding binding, EndpointAddress remoteAddress)
    : base(binding, remoteAddress)
  {
  }

  public string GetStatus(string header) => this.Channel.GetStatus(header);

  public string GetFlights(string header, string flights) => this.Channel.GetFlights(header, flights);

  public string GetPigeons(string header, string pigeons) => this.Channel.GetPigeons(header, pigeons);

  public string SendBCEData(string clubid, string header, string data) => this.Channel.SendBCEData(clubid, header, data);

  public string SendMonitorData(string header, string data) => this.Channel.SendMonitorData(header, data);

  public string SendSettings(string header, string settings) => this.Channel.SendSettings(header, settings);

  public string SendPmReadOut(
    string header,
    string data,
    string fileName,
    DateTime fileTime,
    DateTime readOutTime)
  {
    return this.Channel.SendPmReadOut(header, data, fileName, fileTime, readOutTime);
  }
}
