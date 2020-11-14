// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.Util
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using CoreLib.UI.TaskbarNotification.Interop;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CoreLib.UI.TaskbarNotification
{
  internal static class Util
  {
    public static readonly object SyncRoot = new object();
    private static readonly bool isDesignMode = (bool) DependencyPropertyDescriptor.FromProperty(DesignerProperties.IsInDesignModeProperty, typeof (FrameworkElement)).Metadata.DefaultValue;

    public static bool IsDesignMode => Util.isDesignMode;

    public static Window CreateHelperWindow()
    {
      Window window = new Window();
      window.Width = 0.0;
      window.Height = 0.0;
      window.ShowInTaskbar = false;
      window.WindowStyle = WindowStyle.None;
      window.AllowsTransparency = true;
      window.Opacity = 0.0;
      return window;
    }

    public static bool WriteIconData(ref NotifyIconData data, NotifyCommand command) => Util.WriteIconData(ref data, command, data.ValidMembers);

    public static bool WriteIconData(
      ref NotifyIconData data,
      NotifyCommand command,
      IconDataMembers flags)
    {
      if (Util.IsDesignMode)
        return true;
      data.ValidMembers = flags;
      lock (Util.SyncRoot)
        return WinApi.Shell_NotifyIcon(command, ref data);
    }

    public static BalloonFlags GetBalloonFlag(this BalloonIcon icon)
    {
      switch (icon)
      {
        case BalloonIcon.None:
          return BalloonFlags.None;
        case BalloonIcon.Info:
          return BalloonFlags.Info;
        case BalloonIcon.Warning:
          return BalloonFlags.Warning;
        case BalloonIcon.Error:
          return BalloonFlags.Error;
        default:
          throw new ArgumentOutOfRangeException(nameof (icon));
      }
    }

    public static Icon ToIcon(this ImageSource imageSource)
    {
      if (imageSource == null)
        return (Icon) null;
      return new Icon((Application.GetResourceStream(new Uri(imageSource.ToString())) ?? throw new ArgumentException(string.Format("The supplied image source '{0}' could not be resolved.", (object) imageSource))).Stream);
    }

    public static bool Is<T>(this T value, params T[] candidates)
    {
      if (candidates == null)
        return false;
      foreach (T candidate in candidates)
      {
        if (value.Equals((object) candidate))
          return true;
      }
      return false;
    }

    public static bool IsMatch(this MouseEvent me, PopupActivationMode activationMode)
    {
      switch (activationMode)
      {
        case PopupActivationMode.LeftClick:
          return me == MouseEvent.IconLeftMouseUp;
        case PopupActivationMode.RightClick:
          return me == MouseEvent.IconRightMouseUp;
        case PopupActivationMode.DoubleClick:
          return me.Is<MouseEvent>(MouseEvent.IconDoubleClick);
        case PopupActivationMode.LeftOrRightClick:
          return me.Is<MouseEvent>(MouseEvent.IconLeftMouseUp, MouseEvent.IconRightMouseUp);
        case PopupActivationMode.LeftOrDoubleClick:
          return me.Is<MouseEvent>(MouseEvent.IconLeftMouseUp, MouseEvent.IconDoubleClick);
        case PopupActivationMode.MiddleClick:
          return me == MouseEvent.IconMiddleMouseUp;
        case PopupActivationMode.All:
          return (uint) me > 0U;
        default:
          throw new ArgumentOutOfRangeException(nameof (activationMode));
      }
    }

    public static void ExecuteIfEnabled(
      this ICommand command,
      object commandParameter,
      IInputElement target)
    {
      if (command == null)
        return;
      if (command is RoutedCommand routedCommand)
      {
        if (!routedCommand.CanExecute(commandParameter, target))
          return;
        routedCommand.Execute(commandParameter, target);
      }
      else
      {
        if (!command.CanExecute(commandParameter))
          return;
        command.Execute(commandParameter);
      }
    }

    internal static Dispatcher GetDispatcher(this DispatcherObject source)
    {
      if (Application.Current != null)
        return Application.Current.Dispatcher;
      return source.Dispatcher != null ? source.Dispatcher : Dispatcher.CurrentDispatcher;
    }

    public static bool IsDataContextDataBound(this FrameworkElement element)
    {
      if (element == null)
        throw new ArgumentNullException(nameof (element));
      return element.GetBindingExpression(FrameworkElement.DataContextProperty) != null;
    }
  }
}
