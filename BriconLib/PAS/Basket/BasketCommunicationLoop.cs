// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.BasketCommunicationLoop
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using BriconLib.PAS.Shared.Commands;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

namespace BriconLib.PAS.Basket
{
  internal class BasketCommunicationLoop : IDisposable
  {
    private byte[] _receivedBytes = new byte[0];
    private readonly CommandFactory _commandFactory = new CommandFactory();
    private Func<BriconLib.PAS.Shared.Commands.Command, BriconLib.PAS.Shared.Commands.Response> _onCommandReceived;
    private readonly List<SerialPort> _ports = new List<SerialPort>();

    public void Start(Func<BriconLib.PAS.Shared.Commands.Command, BriconLib.PAS.Shared.Commands.Response> onCommandReceived, bool readout, bool tempReadout)
    {
      this._onCommandReceived = onCommandReceived;
      CommunicationPool.Instance.Stop();
      foreach (string portName in SerialPort.GetPortNames())
      {
        try
        {
          SerialPort port = new SerialPort(portName, 9600, Parity.None, 8, StopBits.Two);
          port.Open();
          this.SendStartCommand(port, readout ? (tempReadout ? (BriconLib.Communications.Command) new StartTempReadoutCommand() : (BriconLib.Communications.Command) new StartReadoutCommand()) : (BriconLib.Communications.Command) new StartBasketCommand());
          port.DataReceived += new SerialDataReceivedEventHandler(this.Port_DataReceived);
          this._ports.Add(port);
        }
        catch (Exception ex)
        {
        }
      }
    }

    private void SendStartCommand(SerialPort port, BriconLib.Communications.Command command)
    {
      byte[] bytes = command.ToBytes();
      byte num1 = 108;
      byte[] buffer = new byte[1]{ (byte) 108 };
      port.Write(buffer, 0, 1);
      Thread.Sleep(1);
      foreach (byte num2 in bytes)
      {
        buffer[0] = num2;
        num1 += num2;
        port.Write(buffer, 0, 1);
        Thread.Sleep(1);
      }
      buffer[0] = num1;
      port.Write(buffer, 0, 1);
    }

    private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
      try
      {
        SerialPort serialPort = sender as SerialPort;
        byte[] buffer1 = new byte[serialPort.BytesToRead];
        if (buffer1.Length == 0)
          return;
        serialPort.Read(buffer1, 0, buffer1.Length);
        foreach (int num in buffer1)
          ;
        if (buffer1[0] == (byte) 108)
        {
          this._receivedBytes = buffer1;
        }
        else
        {
          byte[] receivedBytes = this._receivedBytes;
          this._receivedBytes = new byte[buffer1.Length + receivedBytes.Length];
          receivedBytes.CopyTo((Array) this._receivedBytes, 0);
          buffer1.CopyTo((Array) this._receivedBytes, receivedBytes.Length);
        }
        if (this._receivedBytes.Length <= 5)
          return;
        int num1 = (int) this._receivedBytes[3] + 8;
        if (num1 != this._receivedBytes.Length)
          return;
        ushort num2 = 43981;
        ushort num3 = 56506;
        for (int index = 0; index < num1 - 4; ++index)
        {
          num2 += (ushort) ((int) this._receivedBytes[index] * 2 + 172);
          num3 += (ushort) ((int) this._receivedBytes[index] * 3 + 14);
        }
        if ((int) this._receivedBytes[num1 - 4] == ((int) num3 & (int) byte.MaxValue) && (int) this._receivedBytes[num1 - 3] == (int) num2 >> 8 && ((int) this._receivedBytes[num1 - 2] == ((int) num2 & (int) byte.MaxValue) && (int) this._receivedBytes[num1 - 1] == (int) num3 >> 8) && this._receivedBytes[1] == (byte) 119)
        {
          byte[] buffer2 = this.ProcessCommand((byte[]) this._receivedBytes.Clone());
          serialPort.Write(buffer2, 0, buffer2.Length);
        }
        this._receivedBytes = new byte[0];
      }
      catch (Exception ex)
      {
      }
    }

    public byte[] ProcessCommand(byte[] bytes) => this._onCommandReceived(this._commandFactory.Create(bytes)).ToBytes();

    public void Dispose()
    {
      this._ports.ForEach((Action<SerialPort>) (p => p.Dispose()));
      CommunicationPool.Instance.RefreshComPort();
    }
  }
}
