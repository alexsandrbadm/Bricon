// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.Kernel32
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Runtime.InteropServices;

namespace BriconLib.Win32
{
  public class Kernel32
  {
    public const int INVALID_HANDLE_VALUE = -1;
    public const int ERROR_INVALID_HANDLE = 6;

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int GlobalAlloc(int wFlags, int dwBytes);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int GlobalLock(int hMem);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern int GlobalUnlock(int hMem);

    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern IntPtr CreateFileMapping(
      IntPtr hFile,
      IntPtr secAttributes,
      ProtectionLevel dwProtect,
      int dwMaximumSizeHigh,
      int dwMaximumSizeLow,
      string lpName);

    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern bool CloseHandle(IntPtr handle);

    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern IntPtr MapViewOfFile(
      IntPtr hFileMappingObject,
      FileMap dwDesiredAccess,
      int dwFileOffsetHigh,
      int dwFileOffsetLow,
      int dwNumberOfBytesToMap);

    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern bool UnmapViewOfFile(IntPtr map);

    [DllImport("Kernel32.dll", SetLastError = true)]
    internal static extern IntPtr OpenFileMapping(
      FileMap dwDesiredAccess,
      bool bInheritHandle,
      string lpName);

    [DllImport("Kernel32.dll")]
    internal static extern uint GetLastError();

    [DllImport("Kernel32.dll")]
    internal static extern void CopyMemory(int dest, int source, int size);

    [DllImport("Kernel32.dll")]
    public static extern void Sleep(int dwMilliseconds);
  }
}
