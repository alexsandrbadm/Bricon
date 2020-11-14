// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.WinApi
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Runtime.InteropServices;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  internal static class WinApi
  {
    [DllImport("shell32.Dll")]
    public static extern bool Shell_NotifyIcon(NotifyCommand cmd, [In] ref NotifyIconData data);

    [DllImport("USER32.DLL", EntryPoint = "CreateWindowExW", SetLastError = true)]
    public static extern IntPtr CreateWindowEx(
      int dwExStyle,
      [MarshalAs(UnmanagedType.LPWStr)] string lpClassName,
      [MarshalAs(UnmanagedType.LPWStr)] string lpWindowName,
      int dwStyle,
      int x,
      int y,
      int nWidth,
      int nHeight,
      uint hWndParent,
      int hMenu,
      int hInstance,
      int lpParam);

    [DllImport("USER32.DLL")]
    public static extern long DefWindowProc(IntPtr hWnd, uint msg, uint wparam, uint lparam);

    [DllImport("USER32.DLL", EntryPoint = "RegisterClassW", SetLastError = true)]
    public static extern short RegisterClass(ref WindowClass lpWndClass);

    [DllImport("User32.Dll", EntryPoint = "RegisterWindowMessageW")]
    public static extern uint RegisterWindowMessage([MarshalAs(UnmanagedType.LPWStr)] string lpString);

    [DllImport("USER32.DLL", SetLastError = true)]
    public static extern bool DestroyWindow(IntPtr hWnd);

    [DllImport("USER32.DLL")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    public static extern int GetDoubleClickTime();

    [DllImport("USER32.DLL", SetLastError = true)]
    public static extern bool GetCursorPos(ref Point lpPoint);
  }
}
