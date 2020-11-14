// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Shared.LogWindowHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace BriconLib.PAS.Shared
{
  public class LogWindowHelper
  {
    public static void AddToLog(
      Window window,
      ListBox listbox,
      ObservableCollection<ListBoxItem> log,
      ApiResponseModel response,
      bool showDebugMessage)
    {
      window.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        foreach (ApiResponseModel.LogMessage logMessage in response.LogMessages)
        {
          if (logMessage.LogType != ApiResponseModel.LogType.Debug || showDebugMessage)
            log.Add(new ListBoxItem()
            {
              Content = (object) logMessage.Message,
              Foreground = LogWindowHelper.GetLogColor(logMessage.LogType)
            });
        }
        while (log.Count > 1000)
          log.RemoveAt(0);
        listbox.ScrollIntoView(listbox.Items[listbox.Items.Count - 1]);
      }));
    }

    public static void AddToLog(
      Window window,
      ListBox listbox,
      ObservableCollection<ListBoxItem> log,
      string txt,
      ApiResponseModel.LogType logType,
      bool showDebugMessage)
    {
      if (logType == ApiResponseModel.LogType.Debug && !showDebugMessage)
        return;
      window.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        log.Add(new ListBoxItem()
        {
          Content = (object) txt,
          Foreground = LogWindowHelper.GetLogColor(logType)
        });
        while (log.Count > 1000)
          log.RemoveAt(0);
        listbox.ScrollIntoView(listbox.Items[listbox.Items.Count - 1]);
      }));
    }

    private static Brush GetLogColor(ApiResponseModel.LogType logType)
    {
      switch (logType)
      {
        case ApiResponseModel.LogType.Warning:
          return (Brush) Brushes.Orange;
        case ApiResponseModel.LogType.Error:
          return (Brush) Brushes.Red;
        case ApiResponseModel.LogType.FatalError:
          return (Brush) Brushes.Purple;
        case ApiResponseModel.LogType.Debug:
          return (Brush) Brushes.Gray;
        default:
          return (Brush) Brushes.Black;
      }
    }
  }
}
