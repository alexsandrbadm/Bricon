// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.CommunicationPool
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Communications
{
  public class CommunicationPool
  {
    private bool NoComPorts;
    private Communication _communication = new Communication();
    private List<Command> _commandsToSend = new List<Command>();
    private bool _pausePolling;
    private bool _masterReset;
    private BackgroundWorker _backgroundWorker;
    private static CommunicationPool _instance;

    public static CommunicationPool Instance
    {
      get
      {
        if (CommunicationPool._instance == null)
          CommunicationPool._instance = new CommunicationPool();
        return CommunicationPool._instance;
      }
      set => CommunicationPool._instance = value;
    }

    public int ActiveComport => this._communication.ActiveComport;

    public void ReInit()
    {
      this._backgroundWorker = (BackgroundWorker) null;
      CommunicationState.Instance.GetAndClearCommands();
      CommunicationPool.Instance.Stop();
      CommunicationPool.Instance.RefreshComPort();
    }

    public void RefreshComPort()
    {
      this._pausePolling = true;
      Thread.Sleep(500);
      this._commandsToSend.Clear();
      this._communication.RefreshComPort();
      this._pausePolling = false;
    }

    public void FullStop()
    {
      if (this._backgroundWorker == null)
        return;
      this._backgroundWorker.CancelAsync();
    }

    public void Stop()
    {
      try
      {
        this._pausePolling = true;
        Command[] array = new Command[this._commandsToSend.Count];
        this._commandsToSend.CopyTo(array);
        this._commandsToSend.Clear();
        this._communication.Stop();
        CommunicationState.Instance.MasterFound = false;
        CommunicationState.Instance.BAAddress = byte.MaxValue;
        CommunicationState.Instance.ReadingRing = false;
        CommunicationState.Instance.WaitingToConnectBA = false;
        CommunicationState.Instance.WaitingToConnectMaster = false;
        foreach (Command command in array)
          command.Status = ResponseStatus.PCCommStopped;
        if (this._backgroundWorker == null)
          return;
        this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
      }
      catch (Exception ex)
      {
      }
    }

    public bool AreCommandsPending
    {
      get
      {
        if (this._commandsToSend.Count == 0)
          return false;
        Command command = this._commandsToSend[0];
        if (command.IsMasterCommand && !CommunicationState.Instance.MasterFound)
        {
          CommunicationState.Instance.WaitingToConnectMaster = true;
          return false;
        }
        if (command.IsMasterCommand || CommunicationState.Instance.BAFound)
          return true;
        CommunicationState.Instance.WaitingToConnectBA = true;
        return false;
      }
    }

    public bool AreReadRingCommandsPending
    {
      get
      {
        foreach (Command command in this._commandsToSend)
        {
          if (command is ReadRingCommand || command is CheckRingCommand)
            return true;
        }
        return false;
      }
    }

    public void CommunicationsLoop(BackgroundWorker worker)
    {
      if (Settings.Default.Language != "Auto")
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      int num1 = 0;
      this._backgroundWorker = worker;
      while (!worker.CancellationPending)
      {
        try
        {
          if (SerialPort.GetPortNames().Length == 0)
          {
            this.NoComPorts = true;
          }
          else
          {
            if (this.NoComPorts)
              this._communication.RefreshComPort();
            this.NoComPorts = false;
            if (!this.AreCommandsPending)
            {
              if (!this._pausePolling)
                this._communication.OnIdle();
              else
                continue;
            }
            else
            {
              Command command = this._commandsToSend[0];
              if (command.GetType() == typeof (ReadRingCommand) || command.GetType() == typeof (CheckRingCommand))
              {
                CommunicationState.Instance.ReadingRing = true;
                this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
              }
              if (command is SendBandTableCommand)
              {
                int num2 = 750;
                if (CommunicationState.Instance.IsSpeedyXtreme)
                  num2 = 300;
                if (CommunicationState.Instance.IsSpeedy)
                  num2 = 200;
                if (CommunicationState.Instance.IsExtreme)
                  num2 = 1000;
                if ((command as SendBandTableCommand)._index > num2)
                {
                  command.Status = ResponseStatus.OutOfRange;
                  CommunicationState.Instance.AddCommandWithFeedBack(command);
                  this._commandsToSend.Remove(command);
                  continue;
                }
              }
              ResponseStatus responseStatus = this._communication.SendCommand(command);
              if (responseStatus != ResponseStatus.NoRingRead)
              {
                CommunicationState.Instance.ReadingRing = false;
                if (responseStatus != ResponseStatus.OK && responseStatus != ResponseStatus.UserAbort && responseStatus != ResponseStatus.FlightDataNotDeleted)
                {
                  if (!this._pausePolling)
                  {
                    this._communication.OnIdle();
                    this._communication.OnIdle();
                  }
                  if (num1++ > 5 || command.NoMoreRecords)
                  {
                    if (command is ResetMasterCommand)
                      throw new Exception(ml.ml_string(283, "Could not reset Master, please restart program."));
                    if (command.NoMoreRecords && command.HasFeedBack)
                      CommunicationState.Instance.AddCommandWithFeedBack(command);
                    CommunicationState.Instance.AddCompletedCommand(command);
                    this._commandsToSend.Remove(command);
                    num1 = 0;
                  }
                }
                else
                {
                  if (command is ResetMasterCommand && command.Success)
                  {
                    this._masterReset = true;
                    this._pausePolling = true;
                  }
                  if (command is SendFancierCommand && responseStatus == ResponseStatus.FlightDataNotDeleted)
                  {
                    MessageDisplayer messageDisplayer = new MessageDisplayer(ml.ml_string(312, "Race data not deleted."));
                  }
                  if (command.Success && command.HasFeedBack)
                    CommunicationState.Instance.AddCommandWithFeedBack(command);
                  CommunicationState.Instance.AddCompletedCommand(command);
                  this._commandsToSend.Remove(command);
                }
              }
              else
                continue;
            }
            if (CommunicationState.Instance.Modified)
            {
              if (this._backgroundWorker != null)
                this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
            }
          }
        }
        catch (Exception ex)
        {
          CommunicationState.Instance.ReadingRing = false;
          int num2 = (int) MessageBox.Show(ml.ml_string((int) sbyte.MaxValue, "Fatal Error occurred, the commandlist will be cleared, please try again. \n\nError : \n") + ex.ToString());
          foreach (Command cmd in this._commandsToSend)
          {
            cmd.HandleFailedResponce(ResponseStatus.PCError);
            CommunicationState.Instance.AddCompletedCommand(cmd);
          }
          this._commandsToSend.Clear();
          this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
        }
      }
    }

    public void ClearMessages(bool master)
    {
      bool pausePolling = this._pausePolling;
      this._pausePolling = true;
      Thread.Sleep(500);
      for (int index = 0; index < this._commandsToSend.Count; ++index)
      {
        if (this._commandsToSend[index].IsMasterCommand == master)
          this._commandsToSend.RemoveAt(index--);
      }
      this._pausePolling = pausePolling;
    }

    public void PostCommand(Command command)
    {
      CommunicationState.Instance.AddCommand(command);
      if (this._backgroundWorker != null)
        this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
      this._commandsToSend.Add(command);
    }

    public void PostNextCommand(Command command)
    {
      CommunicationState.Instance.InsertCommand(command);
      if (this._backgroundWorker != null)
        this._backgroundWorker.ReportProgress(-1, (object) CommunicationState.Instance);
      this._commandsToSend.Insert(0, command);
    }

    public bool IsCountryCodeCorrect()
    {
      this.ClearMessages(true);
      this.ClearMessages(false);
      bool pausePolling = this._pausePolling;
      this._pausePolling = true;
      GetLanguageAndCountryCommand andCountryCommand = new GetLanguageAndCountryCommand();
      if (this._communication.SendCommand((Command) andCountryCommand) == ResponseStatus.OK && !Utils.IsCountry("KSA") && (!Utils.IsCountry("IQ") && !Utils.IsCountry("RN")) && (!Utils.IsCountry("AR") && !Utils.IsCountry("IN") && !andCountryCommand.ReceivedCountry.Equals(SoftwareDownloader.DownloadedCountry, StringComparison.InvariantCultureIgnoreCase)))
      {
        int num = (int) MessageBox.Show(ml.ml_string(406, "Countrycode of downloaded versions not the same like in Master, aborting update"));
        this._pausePolling = pausePolling;
        return false;
      }
      this._pausePolling = pausePolling;
      return true;
    }

    public int SendResetMasterCommand()
    {
      this._masterReset = false;
      this._pausePolling = true;
      if (!this.IsCountryCodeCorrect())
        return -1;
      this.PostNextCommand((Command) new ResetMasterCommand());
      DateTime now = DateTime.Now;
      while (!this._masterReset)
      {
        Thread.Sleep(100);
        if ((DateTime.Now - now).TotalMinutes >= 1.0)
          return 0;
      }
      return 1;
    }
  }
}
