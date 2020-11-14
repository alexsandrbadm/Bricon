// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Interop.NotifyIconData
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Runtime.InteropServices;

namespace CoreLib.UI.TaskbarNotification.Interop
{
  public struct NotifyIconData
  {
    public uint cbSize;
    public IntPtr WindowHandle;
    public uint TaskbarIconId;
    public IconDataMembers ValidMembers;
    public uint CallbackMessageId;
    public IntPtr IconHandle;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
    public string ToolTipText;
    public IconState IconState;
    public IconState StateMask;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
    public string BalloonText;
    public uint VersionOrTimeout;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
    public string BalloonTitle;
    public BalloonFlags BalloonFlags;
    public Guid TaskbarIconGuid;
    public IntPtr CustomBalloonIconHandle;

    public static NotifyIconData CreateDefault(IntPtr handle)
    {
      NotifyIconData notifyIconData = new NotifyIconData();
      if (Environment.OSVersion.Version.Major >= 6)
      {
        notifyIconData.cbSize = (uint) Marshal.SizeOf((object) notifyIconData);
      }
      else
      {
        notifyIconData.cbSize = 504U;
        notifyIconData.VersionOrTimeout = 10U;
      }
      notifyIconData.WindowHandle = handle;
      notifyIconData.TaskbarIconId = 0U;
      notifyIconData.CallbackMessageId = 1024U;
      notifyIconData.VersionOrTimeout = 0U;
      notifyIconData.IconHandle = IntPtr.Zero;
      notifyIconData.IconState = IconState.Hidden;
      notifyIconData.StateMask = IconState.Hidden;
      notifyIconData.ValidMembers = IconDataMembers.Message | IconDataMembers.Icon | IconDataMembers.Tip;
      notifyIconData.ToolTipText = notifyIconData.BalloonText = notifyIconData.BalloonTitle = string.Empty;
      return notifyIconData;
    }
  }
}
