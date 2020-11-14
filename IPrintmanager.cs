// Decompiled with JetBrains decompiler
// Type: IPrintmanager
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.ServiceModel;

[GeneratedCode("System.ServiceModel", "3.0.0.0")]
[ServiceContract(ConfigurationName = "IPrintmanager")]
public interface IPrintmanager
{
  [OperationContract(Action = "http://tempuri.org/IPrintmanager/GetStatus", ReplyAction = "http://tempuri.org/IPrintmanager/GetStatusResponse")]
  string GetStatus(string header);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/GetFlights", ReplyAction = "http://tempuri.org/IPrintmanager/GetFlightsResponse")]
  string GetFlights(string header, string flights);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/GetPigeons", ReplyAction = "http://tempuri.org/IPrintmanager/GetPigeonsResponse")]
  string GetPigeons(string header, string pigeons);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/SendBCEData", ReplyAction = "http://tempuri.org/IPrintmanager/SendBCEDataResponse")]
  string SendBCEData(string clubid, string header, string data);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/SendMonitorData", ReplyAction = "http://tempuri.org/IPrintmanager/SendMonitorDataResponse")]
  string SendMonitorData(string header, string data);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/SendSettings", ReplyAction = "http://tempuri.org/IPrintmanager/SendSettingsResponse")]
  string SendSettings(string header, string settings);

  [OperationContract(Action = "http://tempuri.org/IPrintmanager/SendPmReadOut", ReplyAction = "http://tempuri.org/IPrintmanager/SendPmReadOutResponse")]
  string SendPmReadOut(
    string header,
    string data,
    string fileName,
    DateTime fileTime,
    DateTime readOutTime);
}
