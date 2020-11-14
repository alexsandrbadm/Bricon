// Decompiled with JetBrains decompiler
// Type: WebServer
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

public class WebServer
{
  private static AutoResetEvent listenForNextRequest = new AutoResetEvent(false);
  private HttpListener _httpListener;
  private MonitorForm _monitorForm;

  public WebServer(MonitorForm monitorForm)
  {
    this._httpListener = new HttpListener();
    this._monitorForm = monitorForm;
  }

  public void Start()
  {
    try
    {
      string uriPrefix = "http://*:" + Settings.Default.WebServerPort.ToString() + "/";
      if (string.IsNullOrEmpty(uriPrefix))
        throw new InvalidOperationException("No prefix has been specified");
      this._httpListener.Prefixes.Clear();
      this._httpListener.Prefixes.Add(uriPrefix);
      this._httpListener.Start();
      ThreadPool.QueueUserWorkItem(new WaitCallback(this.Listen));
    }
    catch (Exception ex)
    {
      Utils.LogErrorToBWLog(ex.ToString());
    }
  }

  public void Stop()
  {
    try
    {
      this._httpListener.Stop();
    }
    catch (Exception ex)
    {
      Utils.LogErrorToBWLog(ex.ToString());
    }
  }

  private void ListenerCallback(IAsyncResult result)
  {
    try
    {
      HttpListener asyncState = result.AsyncState as HttpListener;
      HttpListenerContext context = (HttpListenerContext) null;
      if (asyncState == null)
        return;
      try
      {
        context = asyncState.EndGetContext(result);
      }
      finally
      {
        WebServer.listenForNextRequest.Set();
      }
      if (context == null)
        return;
      this.ProcessRequest(context);
    }
    catch (Exception ex1)
    {
      try
      {
        Utils.LogErrorToBWLog(ex1.ToString());
      }
      catch (Exception ex2)
      {
      }
    }
  }

  private void Listen(object state)
  {
    while (this._httpListener.IsListening)
    {
      try
      {
        this._httpListener.BeginGetContext(new AsyncCallback(this.ListenerCallback), (object) this._httpListener);
        WebServer.listenForNextRequest.WaitOne();
      }
      catch (Exception ex)
      {
        Utils.LogErrorToBWLog(ex.ToString());
      }
    }
  }

  public void ProcessRequest(HttpListenerContext context)
  {
    context.Response.AppendHeader("Access-Control-Allow-Origin", "*");
    context.Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
    if (!(context.Request.HttpMethod == "GET"))
      return;
    byte[] buffer = this.ProcessFile(context.Request.Url.AbsolutePath);
    context.Response.ContentLength64 = (long) buffer.Length;
    try
    {
      Stream outputStream = context.Response.OutputStream;
      outputStream.Write(buffer, 0, buffer.Length);
      outputStream.Close();
    }
    catch (Exception ex)
    {
    }
  }

  private byte[] ProcessFile(string url)
  {
    string str = url.Replace("/", "\\").Replace("%5C", "\\");
    if (str.Contains("\\\\"))
      return new byte[0];
    if (!Path.GetFullPath(FileIO.Instance.RootDirectory + str).ToLower().StartsWith(FileIO.Instance.RootDirectory.ToLower()))
      return new byte[0];
    if (str == "\\")
      str = "\\index.html";
    if (str == "\\getdata")
      return Encoding.UTF8.GetBytes(this._monitorForm.GetDataForWebserver());
    string fileName = "\\www" + str;
    try
    {
      return FileIO.Instance.GetFileFromCache(fileName);
    }
    catch (Exception ex)
    {
      Utils.LogErrorToBWLog(ex.ToString());
    }
    return new byte[0];
  }
}
