// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.RoutedEventHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows;

namespace CoreLib.UI.TaskbarNotification
{
  internal static class RoutedEventHelper
  {
    internal static void RaiseEvent(DependencyObject target, RoutedEventArgs args)
    {
      switch (target)
      {
        case UIElement _:
          (target as UIElement).RaiseEvent(args);
          break;
        case ContentElement _:
          (target as ContentElement).RaiseEvent(args);
          break;
      }
    }

    internal static void AddHandler(
      DependencyObject element,
      RoutedEvent routedEvent,
      Delegate handler)
    {
      switch (element)
      {
        case UIElement uiElement:
          uiElement.AddHandler(routedEvent, handler);
          break;
        case ContentElement contentElement:
          contentElement.AddHandler(routedEvent, handler);
          break;
      }
    }

    internal static void RemoveHandler(
      DependencyObject element,
      RoutedEvent routedEvent,
      Delegate handler)
    {
      switch (element)
      {
        case UIElement uiElement:
          uiElement.RemoveHandler(routedEvent, handler);
          break;
        case ContentElement contentElement:
          contentElement.RemoveHandler(routedEvent, handler);
          break;
      }
    }
  }
}
