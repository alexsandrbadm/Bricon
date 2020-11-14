// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.Communication
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using BriconLib.Win32;
using System;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace BriconLib.Communications
{
  public class Communication
  {
    private SerialPort _serialPort;
    private byte[] _adresses;
    private byte[] _tempBuf = new byte[1];
    private int _lastAdressTried;
    private int _lastPortTried;
    private string[] _activePorts;
    private bool _resetPort;
    private int _timeOutActivateBA = 100;
    private int _timeOutActivateMaster = 100;
    private int _timeOutCommands = 2000;
    private int _readRingDelay = 50;
    private int _delayAfterCommand = 50;
    private bool _CommandBusy;
    private bool _commStopped;

    public Communication() => this.RefreshComPort();

    public int ActiveComport => Convert.ToInt32(this._activePorts[this._lastPortTried].Replace("COM", ""));

    public void StartComm(string portName, int baud)
    {
      if (this._serialPort != null && this._serialPort.IsOpen)
        return;
      this._serialPort = new SerialPort(portName, baud, Parity.None, 8, StopBits.Two);
      this._serialPort.Open();
      this._serialPort.RtsEnable = true;
      Thread.Sleep(50);
    }

    public void StopComm()
    {
      try
      {
        if (this._serialPort == null || !this._serialPort.IsOpen)
          return;
        this._serialPort.Close();
        this._serialPort.Dispose();
        this._serialPort = (SerialPort) null;
      }
      catch (Exception ex)
      {
      }
    }

    public void Stop()
    {
      this._commStopped = true;
      Thread.Sleep(500);
      do
        ;
      while (this._CommandBusy);
      this.StopComm();
    }

    private void FillComportNames()
    {
      this._activePorts = SerialPort.GetPortNames();
      string str = "Auto";
      foreach (string activePort in this._activePorts)
      {
        if (activePort.Equals(Settings.Default.ComPort))
          str = Settings.Default.ComPort;
      }
      if (!str.Equals("Auto"))
      {
        this._activePorts = new string[1];
        this._activePorts[0] = str;
      }
      this._lastPortTried = 0;
      this._resetPort = true;
    }

    private void NextComport()
    {
      if (this._commStopped)
        return;
      ++this._lastPortTried;
      if (this._lastPortTried < this._activePorts.Length)
        return;
      this.FillComportNames();
    }

    public void RefreshComPort()
    {
      if (Settings.Default.AntenneWithoutMaster)
      {
        this._adresses = new byte[7];
        this._adresses[0] = (byte) 16;
        int num = 1;
        for (byte index = 128; index <= (byte) 133; ++index)
          this._adresses[num++] = index;
      }
      else
      {
        this._adresses = new byte[8];
        int num1 = 0;
        byte[] adresses1 = this._adresses;
        int index1 = num1;
        int num2 = index1 + 1;
        adresses1[index1] = (byte) 16;
        for (byte index2 = 128; index2 <= (byte) 133; ++index2)
          this._adresses[num2++] = index2;
        byte[] adresses2 = this._adresses;
        int index3 = num2;
        int num3 = index3 + 1;
        adresses2[index3] = (byte) 0;
      }
      this._commStopped = false;
      this.FillComportNames();
      this._timeOutActivateBA = Convert.ToInt32(Settings.Default.TimeOutPolling);
      this._timeOutActivateMaster = Convert.ToInt32(Settings.Default.TimeOutPolling);
      this._timeOutCommands = 5000;
      this._readRingDelay = 50;
      this._delayAfterCommand = 50;
    }

    public ResponseStatus SendCommand(Command command) => this.SendCommand(command, this._timeOutCommands);

    public ResponseStatus SendCommand(Command command, int timeout)
    {
      try
      {
        bool flag = command.GetType() == typeof (SendUpdateFileCommand);
        if (this._commStopped)
          return ResponseStatus.PCError;
        this._CommandBusy = true;
        byte[] bytes1 = command.ToBytes();
        if (bytes1 == null)
        {
          command.HandleFailedResponce(ResponseStatus.UserAbort);
          this._CommandBusy = false;
          return ResponseStatus.UserAbort;
        }
        byte num1 = 108;
        foreach (byte num2 in bytes1)
          num1 += num2;
        if (!flag)
        {
          if (this._serialPort == null || !this._serialPort.IsOpen)
          {
            command.HandleFailedResponce(ResponseStatus.PCError);
            this._CommandBusy = false;
            return ResponseStatus.PCError;
          }
          int num2 = (int) User32.timeBeginPeriod(1U);
          Thread.Sleep(10);
          this._serialPort.DiscardInBuffer();
          this._serialPort.DiscardOutBuffer();
          this._serialPort.ReadTimeout = timeout;
          if (command.GetType() == typeof (ReadRingCommand) || command.GetType() == typeof (CheckRingCommand))
            Thread.Sleep(this._readRingDelay);
          this._tempBuf[0] = (byte) 108;
          this._serialPort.Write(this._tempBuf, 0, 1);
          Thread.Sleep(1);
          foreach (byte num3 in bytes1)
          {
            this._tempBuf[0] = num3;
            this._serialPort.Write(this._tempBuf, 0, 1);
            Thread.Sleep(1);
          }
          int num4 = (int) User32.timeEndPeriod(1U);
          this._tempBuf[0] = num1;
          this._serialPort.Write(this._tempBuf, 0, 1);
        }
        else
        {
          this._tempBuf[0] = (byte) 108;
          this._serialPort.Write(this._tempBuf, 0, 1);
          this._serialPort.Write(bytes1, 0, bytes1.Length);
          this._tempBuf[0] = num1;
          this._serialPort.Write(this._tempBuf, 0, 1);
        }
        try
        {
          if ((command.GetType() == typeof (ReadRingCommand) || command.GetType() == typeof (CheckRingCommand)) && !Settings.Default.AntenneWithoutMaster)
          {
            this._serialPort.ReadTimeout = 50;
            for (int index = 0; index < 5; ++index)
            {
              while (this._serialPort.BytesToRead > 0)
              {
                this._serialPort.ReadByte();
                Thread.Sleep(20);
                index = 10;
              }
              Thread.Sleep(60);
              if (index == 10 && this._serialPort.BytesToRead == 0)
                break;
            }
            while (CommunicationState.Instance.ReadingRing)
            {
              Thread.Sleep(10);
              if (this._serialPort.BytesToRead > 0)
                break;
            }
            if (!CommunicationState.Instance.ReadingRing)
            {
              this._CommandBusy = false;
              return ResponseStatus.UserAbort;
            }
          }
          int num2 = this._serialPort.ReadByte();
          int num3 = (int) byte.MaxValue;
          int num4 = (int) byte.MaxValue;
          if (num2 == 51)
          {
            num3 = this._serialPort.ReadByte();
            num4 = this._serialPort.ReadByte();
          }
          if (num2 == 51)
          {
            if (num3 == (int) bytes1[0])
            {
              if (num4 == (int) bytes1[1])
              {
                int num5 = this._serialPort.ReadByte();
                int num6 = num5 != 0 ? this._serialPort.ReadByte() : 0;
                byte[] bytes2 = num5 <= 0 ? new byte[0] : new byte[num5 - 1];
                for (int index = 0; index < num5 - 1; ++index)
                  bytes2[index] = (byte) this._serialPort.ReadByte();
                byte num7 = (byte) this._serialPort.ReadByte();
                byte num8 = (byte) (51U + (uint) bytes1[0] + (uint) bytes1[1] + (uint) (byte) num5 + (uint) (byte) num6);
                foreach (byte num9 in bytes2)
                  num8 += num9;
                Thread.Sleep(this._delayAfterCommand);
                if (command.GetType() == typeof (ReadRingCommand) || command.GetType() == typeof (CheckRingCommand))
                  Thread.Sleep(this._readRingDelay * 10);
                if ((int) num7 != (int) num8)
                {
                  command.HandleFailedResponce(ResponseStatus.PCChecksumError);
                  this._CommandBusy = false;
                  return ResponseStatus.PCChecksumError;
                }
                command.HandleResponse(new Response((ResponseStatus) num6, bytes2));
                this._CommandBusy = false;
                return (ResponseStatus) num6;
              }
            }
          }
        }
        catch (TimeoutException ex)
        {
          command.HandleFailedResponce(ResponseStatus.PCTimeOut);
          this._CommandBusy = false;
          return ResponseStatus.PCTimeOut;
        }
        command.HandleFailedResponce(ResponseStatus.PCInvalidByteReceived);
        this._CommandBusy = false;
        return ResponseStatus.PCInvalidByteReceived;
      }
      catch (IOException ex)
      {
        this._CommandBusy = false;
        return ResponseStatus.PCError;
      }
    }

    public void OnIdle()
    {
      if (this._commStopped)
        return;
      if (this._lastAdressTried != 0 && CommunicationState.Instance.BAAddress != byte.MaxValue)
      {
        if (this._lastPortTried < this._activePorts.Length)
          this.TryToActivateDevice(this._activePorts[this._lastPortTried], CommunicationState.Instance.BAAddress);
        else
          Thread.Sleep(100);
        this._lastAdressTried = -1;
      }
      else
      {
        try
        {
          string activePort = this._activePorts[this._lastPortTried];
        }
        catch (Exception ex)
        {
        }
        if (this._lastPortTried < this._activePorts.Length && this._lastAdressTried < this._adresses.Length)
        {
          int adress = (int) this._adresses[this._lastAdressTried];
          this.TryToActivateDevice(this._activePorts[this._lastPortTried], this._adresses[this._lastAdressTried]);
        }
        else
          Thread.Sleep(100);
      }
      ++this._lastAdressTried;
      if (this._lastAdressTried < this._adresses.Length)
        return;
      this._lastAdressTried = 0;
      if (CommunicationState.Instance.MasterFound || CommunicationState.Instance.BAFound)
        return;
      this.NextComport();
    }

    private void TryToActivateDevice(string portName, byte adress)
    {
      try
      {
        if (this._commStopped)
          return;
        if (this._resetPort && this._serialPort != null)
        {
          this._resetPort = false;
          this._serialPort.Close();
          this._serialPort = (SerialPort) null;
        }
        this.StartComm(portName, 9600);
        if (adress == (byte) 16)
        {
          int num = (int) this.SendCommand((Command) new ActivateMasterCommand(), this._timeOutActivateMaster);
        }
        else if (this.SendCommand((Command) new ActivateBACommand(adress), this._timeOutActivateBA) == ResponseStatus.OK)
          this._lastAdressTried = -1;
        if (CommunicationState.Instance.BAFound || CommunicationState.Instance.MasterFound || this._commStopped)
          return;
        this._serialPort.Close();
        this._serialPort = (SerialPort) null;
      }
      catch (Exception ex)
      {
        CommunicationState.Instance.MasterFound = false;
        CommunicationState.Instance.BAAddress = byte.MaxValue;
        this._lastAdressTried = -1;
        this.NextComport();
      }
    }
  }
}
