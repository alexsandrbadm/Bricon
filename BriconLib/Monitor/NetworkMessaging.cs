// Decompiled with JetBrains decompiler
// Type: BriconLib.Monitor.NetworkMessaging
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BriconLib.Monitor
{
  internal class NetworkMessaging : IDisposable
  {
    public const int ServerPort = 8810;
    private const int Forever = -1;
    private string lastMessageSended;
    private Thread _threadSend;
    private Thread _threadReceive;
    private Thread _threadProcess;
    private Queue<string> _queueMessagesToSend = new Queue<string>();
    private Queue<string> _queueMessagesReceived = new Queue<string>();

    public NetworkMessaging()
    {
      this._threadProcess = new Thread(new ThreadStart(this.ProcessLoop));
      this._threadProcess.Start();
      this._threadSend = new Thread(new ThreadStart(this.SendLoop));
      this._threadSend.Start();
      this._threadReceive = new Thread(new ThreadStart(this.WaitForRequest));
      this._threadReceive.Start();
    }

    public void Dispose()
    {
      this._threadProcess.Abort();
      this._threadSend.Abort();
      this._threadReceive.Abort();
    }

    public void BroadCastMessage(string message) => this._queueMessagesToSend.Enqueue(message);

    private void ProcessLoop()
    {
      while (true)
      {
        if (this._queueMessagesReceived.Count > 0)
        {
          try
          {
            this.AddMessage(this._queueMessagesReceived.Dequeue());
          }
          catch (ThreadAbortException ex)
          {
            break;
          }
          catch (Exception ex)
          {
            Thread.Sleep(50);
          }
        }
        Thread.Sleep(10);
      }
    }

    private void SendLoop()
    {
      while (true)
      {
        if (this._queueMessagesToSend.Count > 0)
        {
          try
          {
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
            {
              string str = this._queueMessagesToSend.Dequeue();
              socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
              EndPoint remoteEP = (EndPoint) new IPEndPoint(IPAddress.Broadcast, 8810);
              socket.Connect(remoteEP);
              this.lastMessageSended = DateTime.Now.ToString("ssfff") + "§" + str;
              socket.Send(Encoding.UTF8.GetBytes(this.lastMessageSended));
            }
          }
          catch (ThreadAbortException ex)
          {
            break;
          }
          catch (Exception ex)
          {
          }
        }
        Thread.Sleep(150);
      }
    }

    private void WaitForRequest()
    {
      while (true)
      {
        try
        {
          using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
          {
            socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            EndPoint remoteEP = (EndPoint) new IPEndPoint(IPAddress.Any, 8810);
            socket.Bind(remoteEP);
            while (true)
            {
              try
              {
                if (socket.Poll(1000, SelectMode.SelectRead))
                {
                  byte[] numArray = new byte[socket.Available];
                  socket.ReceiveFrom(numArray, ref remoteEP);
                  string str = new string(Encoding.UTF8.GetChars(numArray));
                  if (this.lastMessageSended != str)
                  {
                    if (!this._queueMessagesReceived.Contains(str))
                    {
                      string[] strArray = str.Split('§');
                      if (strArray.Length > 1)
                        str = strArray[1];
                      this._queueMessagesReceived.Enqueue(str);
                    }
                  }
                }
              }
              catch (ThreadAbortException ex)
              {
              }
              Thread.Sleep(10);
            }
          }
        }
        catch (ThreadAbortException ex)
        {
          break;
        }
        catch (Exception ex)
        {
          Thread.Sleep(1000);
        }
        Thread.Sleep(10);
      }
    }

    protected void AddMessage(string message)
    {
      if (this.OnMessage == null)
        return;
      this.OnMessage(message);
    }

    public event MessageReceivedEventHandler OnMessage;
  }
}
