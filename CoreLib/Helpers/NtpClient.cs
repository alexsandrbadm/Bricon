// Decompiled with JetBrains decompiler
// Type: CoreLib.Helpers.NtpClient
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using System;
using System.Net;
using System.Net.Sockets;
using System.Windows;

namespace CoreLib.Helpers
{
  public class NtpClient
  {
    private static TimeSpan _delta;
    private static DateTime? _lastSync;

    public static bool CheckPcTime()
    {
      DateTime? networkTime = NtpClient.TryGetNetworkTime();
      if (!networkTime.HasValue)
      {
        int num = (int) MessageBox.Show("Could not get the time from the internet time server.");
        return false;
      }
      if (Math.Abs((networkTime.Value - DateTime.Now).TotalMinutes) > 2.0)
      {
        int num1 = (int) MessageBox.Show("PC time is more then 2 minutes wrong, it is recommended that you adjust the pc time.");
      }
      return true;
    }

    public static DateTime GetNetworkTimeCached()
    {
      if (NtpClient._lastSync.HasValue)
      {
        DateTime? lastSync = NtpClient._lastSync;
        DateTime dateTime = DateTime.Now - TimeSpan.FromMinutes(30.0);
        if ((lastSync.HasValue ? (lastSync.GetValueOrDefault() < dateTime ? 1 : 0) : 0) == 0)
          goto label_4;
      }
      NtpClient._lastSync = NtpClient.TryGetNetworkTime();
      if (NtpClient._lastSync.HasValue)
        NtpClient._delta = NtpClient._lastSync.Value - DateTime.Now;
label_4:
      return DateTime.Now + NtpClient._delta;
    }

    public static DateTime? TryGetNetworkTime()
    {
      try
      {
        return new DateTime?(NtpClient.GetNetworkTime());
      }
      catch (Exception ex)
      {
        return new DateTime?();
      }
    }

    private static DateTime GetNetworkTime()
    {
      byte[] buffer = new byte[48];
      buffer[0] = (byte) 27;
      IPEndPoint ipEndPoint = new IPEndPoint(Dns.GetHostEntry("time.windows.com").AddressList[0], 123);
      using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp))
      {
        socket.Connect((EndPoint) ipEndPoint);
        socket.ReceiveTimeout = 3000;
        socket.Send(buffer);
        socket.Receive(buffer);
        socket.Close();
      }
      long uint32_1 = (long) BitConverter.ToUInt32(buffer, 40);
      ulong uint32_2 = (ulong) BitConverter.ToUInt32(buffer, 44);
      DateTime dateTime = new DateTime(1900, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds((double) (long) ((ulong) ((long) NtpClient.SwapEndianness((ulong) uint32_1) * 1000L) + (ulong) NtpClient.SwapEndianness(uint32_2) * 1000UL / 4294967296UL));
      TimeZoneInfo systemTimeZoneById = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");
      if (Utils.IsCountry("RO") || Utils.IsCountry("MD"))
        systemTimeZoneById = TimeZoneInfo.FindSystemTimeZoneById("GTB Standard Time");
      TimeZoneInfo destinationTimeZone = systemTimeZoneById;
      return TimeZoneInfo.ConvertTimeFromUtc(dateTime, destinationTimeZone);
    }

    private static uint SwapEndianness(ulong x) => (uint) ((ulong) ((((long) x & (long) byte.MaxValue) << 24) + (((long) x & 65280L) << 8)) + ((x & 16711680UL) >> 8) + ((x & 4278190080UL) >> 24));
  }
}
