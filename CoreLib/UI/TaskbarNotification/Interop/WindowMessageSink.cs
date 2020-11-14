// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.WindowMessageSink
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.ComponentModel;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  public class WindowMessageSink : IDisposable
  {
    public const int CallbackMessageId = 1024;
    private uint taskbarRestartMessageId;
    private bool isDoubleClick;
    private WindowProcedureHandler messageHandler;

    internal string WindowId { get; private set; }

    internal IntPtr MessageWindowHandle { get; private set; }

    public NotifyIconVersion Version { get; set; }

    public event Action<bool> ChangeToolTipStateRequest;

    public event Action<MouseEvent> MouseEventReceived;

    public event Action<bool> BalloonToolTipChanged;

    public event Action TaskbarCreated;

    public WindowMessageSink(NotifyIconVersion version)
    {
      this.Version = version;
      this.CreateMessageWindow();
    }

    private WindowMessageSink()
    {
    }

    internal static WindowMessageSink CreateEmpty() => new WindowMessageSink()
    {
      MessageWindowHandle = IntPtr.Zero,
      Version = NotifyIconVersion.Vista
    };

    private void CreateMessageWindow()
    {
      this.WindowId = "WPFTaskbarIcon_" + DateTime.Now.Ticks.ToString();
      this.messageHandler = new WindowProcedureHandler(this.OnWindowMessageReceived);
      WindowClass lpWndClass;
      lpWndClass.style = 0U;
      lpWndClass.lpfnWndProc = this.messageHandler;
      lpWndClass.cbClsExtra = 0;
      lpWndClass.cbWndExtra = 0;
      lpWndClass.hInstance = IntPtr.Zero;
      lpWndClass.hIcon = IntPtr.Zero;
      lpWndClass.hCursor = IntPtr.Zero;
      lpWndClass.hbrBackground = IntPtr.Zero;
      lpWndClass.lpszMenuName = "";
      lpWndClass.lpszClassName = this.WindowId;
      int num = (int) WinApi.RegisterClass(ref lpWndClass);
      this.taskbarRestartMessageId = WinApi.RegisterWindowMessage("TaskbarCreated");
      this.MessageWindowHandle = WinApi.CreateWindowEx(0, this.WindowId, "", 0, 0, 0, 1, 1, 0U, 0, 0, 0);
      if (this.MessageWindowHandle == IntPtr.Zero)
        throw new Win32Exception();
    }

    private long OnWindowMessageReceived(IntPtr hwnd, uint messageId, uint wparam, uint lparam)
    {
      if ((int) messageId == (int) this.taskbarRestartMessageId)
        this.TaskbarCreated();
      this.ProcessWindowMessage(messageId, wparam, lparam);
      return WinApi.DefWindowProc(hwnd, messageId, wparam, lparam);
    }

    private void ProcessWindowMessage(uint msg, uint wParam, uint lParam)
    {
      if (msg != 1024U)
        return;
      switch (lParam)
      {
        case 512:
          this.MouseEventReceived(MouseEvent.MouseMove);
          break;
        case 513:
          this.MouseEventReceived(MouseEvent.IconLeftMouseDown);
          break;
        case 514:
          if (!this.isDoubleClick)
            this.MouseEventReceived(MouseEvent.IconLeftMouseUp);
          this.isDoubleClick = false;
          break;
        case 515:
          this.isDoubleClick = true;
          this.MouseEventReceived(MouseEvent.IconDoubleClick);
          break;
        case 516:
          this.MouseEventReceived(MouseEvent.IconRightMouseDown);
          break;
        case 517:
          this.MouseEventReceived(MouseEvent.IconRightMouseUp);
          break;
        case 519:
          this.MouseEventReceived(MouseEvent.IconMiddleMouseDown);
          break;
        case 520:
          this.MouseEventReceived(MouseEvent.IconMiddleMouseUp);
          break;
        case 1026:
          this.BalloonToolTipChanged(true);
          break;
        case 1027:
        case 1028:
          this.BalloonToolTipChanged(false);
          break;
        case 1029:
          this.MouseEventReceived(MouseEvent.BalloonToolTipClicked);
          break;
        case 1030:
          this.ChangeToolTipStateRequest(true);
          break;
        case 1031:
          this.ChangeToolTipStateRequest(false);
          break;
      }
    }

    public bool IsDisposed { get; private set; }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    ~WindowMessageSink() => this.Dispose(false);

    private void Dispose(bool disposing)
    {
      if (this.IsDisposed || !disposing)
        return;
      this.IsDisposed = true;
      WinApi.DestroyWindow(this.MessageWindowHandle);
      this.messageHandler = (WindowProcedureHandler) null;
    }
  }
}
