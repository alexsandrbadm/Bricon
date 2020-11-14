// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.TaskbarNotification.TaskbarIcon
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using CoreLib.UI.TaskbarNotification.Interop;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

namespace CoreLib.UI.TaskbarNotification
{
  public class TaskbarIcon : FrameworkElement, IDisposable
  {
    private NotifyIconData iconData;
    private readonly WindowMessageSink messageSink;
    private Action delayedTimerAction;
    private readonly Timer singleClickTimer;
    private readonly Timer balloonCloseTimer;
    public const string CategoryName = "NotifyIcon";
    private static readonly DependencyPropertyKey TrayPopupResolvedPropertyKey = DependencyProperty.RegisterReadOnly(nameof (TrayPopupResolved), typeof (Popup), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty TrayPopupResolvedProperty = TaskbarIcon.TrayPopupResolvedPropertyKey.DependencyProperty;
    private static readonly DependencyPropertyKey TrayToolTipResolvedPropertyKey = DependencyProperty.RegisterReadOnly(nameof (TrayToolTipResolved), typeof (ToolTip), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty TrayToolTipResolvedProperty = TaskbarIcon.TrayToolTipResolvedPropertyKey.DependencyProperty;
    private static readonly DependencyPropertyKey CustomBalloonPropertyKey = DependencyProperty.RegisterReadOnly(nameof (CustomBalloon), typeof (Popup), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty CustomBalloonProperty = TaskbarIcon.CustomBalloonPropertyKey.DependencyProperty;
    private Icon icon;
    public static readonly DependencyProperty IconSourceProperty = DependencyProperty.Register(nameof (IconSource), typeof (ImageSource), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(TaskbarIcon.IconSourcePropertyChanged)));
    public static readonly DependencyProperty ToolTipTextProperty = DependencyProperty.Register(nameof (ToolTipText), typeof (string), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) string.Empty, new PropertyChangedCallback(TaskbarIcon.ToolTipTextPropertyChanged)));
    public static readonly DependencyProperty TrayToolTipProperty = DependencyProperty.Register(nameof (TrayToolTip), typeof (UIElement), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(TaskbarIcon.TrayToolTipPropertyChanged)));
    public static readonly DependencyProperty TrayPopupProperty = DependencyProperty.Register(nameof (TrayPopup), typeof (UIElement), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(TaskbarIcon.TrayPopupPropertyChanged)));
    public static readonly DependencyProperty MenuActivationProperty = DependencyProperty.Register(nameof (MenuActivation), typeof (PopupActivationMode), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) PopupActivationMode.RightClick));
    public static readonly DependencyProperty PopupActivationProperty = DependencyProperty.Register(nameof (PopupActivation), typeof (PopupActivationMode), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((object) PopupActivationMode.LeftClick));
    public static readonly DependencyProperty DoubleClickCommandProperty = DependencyProperty.Register(nameof (DoubleClickCommand), typeof (ICommand), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty DoubleClickCommandParameterProperty = DependencyProperty.Register(nameof (DoubleClickCommandParameter), typeof (object), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty DoubleClickCommandTargetProperty = DependencyProperty.Register(nameof (DoubleClickCommandTarget), typeof (IInputElement), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty LeftClickCommandProperty = DependencyProperty.Register(nameof (LeftClickCommand), typeof (ICommand), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty LeftClickCommandParameterProperty = DependencyProperty.Register(nameof (LeftClickCommandParameter), typeof (object), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty LeftClickCommandTargetProperty = DependencyProperty.Register(nameof (LeftClickCommandTarget), typeof (IInputElement), typeof (TaskbarIcon), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    public static readonly RoutedEvent TrayLeftMouseDownEvent = EventManager.RegisterRoutedEvent("TrayLeftMouseDown", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayRightMouseDownEvent = EventManager.RegisterRoutedEvent("TrayRightMouseDown", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayMiddleMouseDownEvent = EventManager.RegisterRoutedEvent("TrayMiddleMouseDown", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayLeftMouseUpEvent = EventManager.RegisterRoutedEvent("TrayLeftMouseUp", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayRightMouseUpEvent = EventManager.RegisterRoutedEvent("TrayRightMouseUp", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayMiddleMouseUpEvent = EventManager.RegisterRoutedEvent("TrayMiddleMouseUp", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayMouseDoubleClickEvent = EventManager.RegisterRoutedEvent("TrayMouseDoubleClick", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayMouseMoveEvent = EventManager.RegisterRoutedEvent("TrayMouseMove", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayBalloonTipShownEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipShown", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayBalloonTipClosedEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipClosed", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayBalloonTipClickedEvent = EventManager.RegisterRoutedEvent("TrayBalloonTipClicked", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayContextMenuOpenEvent = EventManager.RegisterRoutedEvent("TrayContextMenuOpen", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent PreviewTrayContextMenuOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayContextMenuOpen", RoutingStrategy.Tunnel, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayPopupOpenEvent = EventManager.RegisterRoutedEvent("TrayPopupOpen", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent PreviewTrayPopupOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayPopupOpen", RoutingStrategy.Tunnel, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayToolTipOpenEvent = EventManager.RegisterRoutedEvent("TrayToolTipOpen", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent PreviewTrayToolTipOpenEvent = EventManager.RegisterRoutedEvent("PreviewTrayToolTipOpen", RoutingStrategy.Tunnel, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent TrayToolTipCloseEvent = EventManager.RegisterRoutedEvent("TrayToolTipClose", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent PreviewTrayToolTipCloseEvent = EventManager.RegisterRoutedEvent("PreviewTrayToolTipClose", RoutingStrategy.Tunnel, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent ToolTipOpenedEvent = EventManager.RegisterRoutedEvent("ToolTipOpened", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent ToolTipCloseEvent = EventManager.RegisterRoutedEvent("ToolTipClose", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent BalloonShowingEvent = EventManager.RegisterRoutedEvent("BalloonShowing", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly RoutedEvent BalloonClosingEvent = EventManager.RegisterRoutedEvent("BalloonClosing", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (TaskbarIcon));
    public static readonly DependencyProperty ParentTaskbarIconProperty = DependencyProperty.RegisterAttached("ParentTaskbarIcon", typeof (TaskbarIcon), typeof (TaskbarIcon));

    public bool IsTaskbarIconCreated { get; private set; }

    public bool SupportsCustomToolTips => this.messageSink.Version == NotifyIconVersion.Vista;

    private bool IsPopupOpen
    {
      get
      {
        Popup trayPopupResolved = this.TrayPopupResolved;
        ContextMenu contextMenu = this.ContextMenu;
        Popup customBalloon = this.CustomBalloon;
        if (trayPopupResolved != null && trayPopupResolved.IsOpen || contextMenu != null && contextMenu.IsOpen)
          return true;
        return customBalloon != null && customBalloon.IsOpen;
      }
    }

    public TaskbarIcon()
    {
      this.messageSink = Util.IsDesignMode ? WindowMessageSink.CreateEmpty() : new WindowMessageSink(NotifyIconVersion.Win95);
      this.iconData = NotifyIconData.CreateDefault(this.messageSink.MessageWindowHandle);
      this.CreateTaskbarIcon();
      this.messageSink.MouseEventReceived += new Action<MouseEvent>(this.OnMouseEvent);
      this.messageSink.TaskbarCreated += new Action(this.OnTaskbarCreated);
      this.messageSink.ChangeToolTipStateRequest += new Action<bool>(this.OnToolTipChange);
      this.messageSink.BalloonToolTipChanged += new Action<bool>(this.OnBalloonToolTipChanged);
      this.singleClickTimer = new Timer(new TimerCallback(this.DoSingleClickAction));
      this.balloonCloseTimer = new Timer(new TimerCallback(this.CloseBalloonCallback));
      if (Application.Current == null)
        return;
      Application.Current.Exit += new ExitEventHandler(this.OnExit);
    }

    public void ShowCustomBalloon(UIElement balloon, PopupAnimation animation, int? timeout)
    {
      Dispatcher dispatcher = this.GetDispatcher();
      if (!dispatcher.CheckAccess())
      {
        Action action = (Action) (() => this.ShowCustomBalloon(balloon, animation, timeout));
        dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) action);
      }
      else
      {
        if (balloon == null)
          throw new ArgumentNullException(nameof (balloon));
        if (timeout.HasValue)
        {
          int? nullable = timeout;
          int num = 500;
          if (nullable.GetValueOrDefault() < num & nullable.HasValue)
            throw new ArgumentOutOfRangeException(nameof (timeout), string.Format("Invalid timeout of {0} milliseconds. Timeout must be at least 500 ms", (object) timeout));
        }
        this.EnsureNotDisposed();
        lock (this)
          this.CloseBalloon();
        Popup popup = new Popup();
        popup.AllowsTransparency = true;
        this.UpdateDataContext((FrameworkElement) popup, (object) null, this.DataContext);
        popup.PopupAnimation = animation;
        popup.Child = balloon;
        popup.Placement = PlacementMode.AbsolutePoint;
        popup.StaysOpen = true;
        CoreLib.UI.TaskbarNotification.Interop.Point trayLocation = TrayInfo.GetTrayLocation();
        popup.HorizontalOffset = (double) (trayLocation.X - 1);
        popup.VerticalOffset = (double) (trayLocation.Y - 1);
        lock (this)
          this.SetCustomBalloon(popup);
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) balloon, this);
        TaskbarIcon.RaiseBalloonShowingEvent((DependencyObject) balloon, this);
        popup.IsOpen = true;
        if (!timeout.HasValue)
          return;
        this.balloonCloseTimer.Change(timeout.Value, -1);
      }
    }

    public void ResetBalloonCloseTimer()
    {
      if (this.IsDisposed)
        return;
      lock (this)
        this.balloonCloseTimer.Change(-1, -1);
    }

    public void CloseBalloon()
    {
      if (this.IsDisposed)
        return;
      Dispatcher dispatcher = this.GetDispatcher();
      if (!dispatcher.CheckAccess())
      {
        Action action = new Action(this.CloseBalloon);
        dispatcher.Invoke(DispatcherPriority.Normal, (Delegate) action);
      }
      else
      {
        lock (this)
        {
          this.balloonCloseTimer.Change(-1, -1);
          Popup customBalloon = this.CustomBalloon;
          if (customBalloon == null)
            return;
          UIElement child = customBalloon.Child;
          if (!TaskbarIcon.RaiseBalloonClosingEvent((DependencyObject) child, this).Handled)
          {
            customBalloon.IsOpen = false;
            if (child != null)
              TaskbarIcon.SetParentTaskbarIcon((DependencyObject) child, (TaskbarIcon) null);
          }
          this.SetCustomBalloon((Popup) null);
        }
      }
    }

    private void CloseBalloonCallback(object state)
    {
      if (this.IsDisposed)
        return;
      Action action = new Action(this.CloseBalloon);
      this.GetDispatcher().Invoke((Delegate) action);
    }

    private void OnMouseEvent(MouseEvent me)
    {
      if (this.IsDisposed)
        return;
      switch (me)
      {
        case MouseEvent.MouseMove:
          this.RaiseTrayMouseMoveEvent();
          return;
        case MouseEvent.IconRightMouseDown:
          this.RaiseTrayRightMouseDownEvent();
          break;
        case MouseEvent.IconLeftMouseDown:
          this.RaiseTrayLeftMouseDownEvent();
          break;
        case MouseEvent.IconRightMouseUp:
          this.RaiseTrayRightMouseUpEvent();
          break;
        case MouseEvent.IconLeftMouseUp:
          this.RaiseTrayLeftMouseUpEvent();
          break;
        case MouseEvent.IconMiddleMouseDown:
          this.RaiseTrayMiddleMouseDownEvent();
          break;
        case MouseEvent.IconMiddleMouseUp:
          this.RaiseTrayMiddleMouseUpEvent();
          break;
        case MouseEvent.IconDoubleClick:
          this.singleClickTimer.Change(-1, -1);
          this.RaiseTrayMouseDoubleClickEvent();
          break;
        case MouseEvent.BalloonToolTipClicked:
          this.RaiseTrayBalloonTipClickedEvent();
          break;
        default:
          throw new ArgumentOutOfRangeException(nameof (me), "Missing handler for mouse event flag: " + me.ToString());
      }
      CoreLib.UI.TaskbarNotification.Interop.Point cursorPosition = new CoreLib.UI.TaskbarNotification.Interop.Point();
      WinApi.GetCursorPos(ref cursorPosition);
      bool flag = false;
      if (me.IsMatch(this.PopupActivation))
        this.ShowTrayPopup(cursorPosition);
      if (me.IsMatch(this.MenuActivation))
      {
        if (me == MouseEvent.IconLeftMouseUp)
        {
          this.delayedTimerAction = (Action) (() =>
          {
            this.LeftClickCommand.ExecuteIfEnabled(this.LeftClickCommandParameter, this.LeftClickCommandTarget ?? (IInputElement) this);
            this.ShowContextMenu(cursorPosition);
          });
          this.singleClickTimer.Change(WinApi.GetDoubleClickTime(), -1);
          flag = true;
        }
        else
          this.ShowContextMenu(cursorPosition);
      }
      if (me != MouseEvent.IconLeftMouseUp || flag)
        return;
      this.delayedTimerAction = (Action) (() => this.LeftClickCommand.ExecuteIfEnabled(this.LeftClickCommandParameter, this.LeftClickCommandTarget ?? (IInputElement) this));
      this.singleClickTimer.Change(WinApi.GetDoubleClickTime(), -1);
    }

    private void OnToolTipChange(bool visible)
    {
      if (this.TrayToolTipResolved == null)
        return;
      if (visible)
      {
        if (this.IsPopupOpen || this.RaisePreviewTrayToolTipOpenEvent().Handled)
          return;
        this.TrayToolTipResolved.IsOpen = true;
        if (this.TrayToolTip != null)
          TaskbarIcon.RaiseToolTipOpenedEvent((DependencyObject) this.TrayToolTip);
        this.RaiseTrayToolTipOpenEvent();
      }
      else
      {
        if (this.RaisePreviewTrayToolTipCloseEvent().Handled)
          return;
        if (this.TrayToolTip != null)
          TaskbarIcon.RaiseToolTipCloseEvent((DependencyObject) this.TrayToolTip);
        this.TrayToolTipResolved.IsOpen = false;
        this.RaiseTrayToolTipCloseEvent();
      }
    }

    private void CreateCustomToolTip()
    {
      if (!(this.TrayToolTip is ToolTip toolTip) && this.TrayToolTip != null)
      {
        toolTip = new ToolTip();
        toolTip.Placement = PlacementMode.Mouse;
        toolTip.HasDropShadow = false;
        toolTip.BorderThickness = new Thickness(0.0);
        toolTip.Background = (System.Windows.Media.Brush) System.Windows.Media.Brushes.Transparent;
        toolTip.StaysOpen = true;
        toolTip.Content = (object) this.TrayToolTip;
      }
      else if (toolTip == null && !string.IsNullOrEmpty(this.ToolTipText))
      {
        toolTip = new ToolTip();
        toolTip.Content = (object) this.ToolTipText;
      }
      if (toolTip != null)
        this.UpdateDataContext((FrameworkElement) toolTip, (object) null, this.DataContext);
      this.SetTrayToolTipResolved(toolTip);
    }

    private void WriteToolTipSettings()
    {
      this.iconData.ToolTipText = this.ToolTipText;
      if (this.messageSink.Version == NotifyIconVersion.Vista && string.IsNullOrEmpty(this.iconData.ToolTipText) && this.TrayToolTipResolved != null)
        this.iconData.ToolTipText = "ToolTip";
      Util.WriteIconData(ref this.iconData, NotifyCommand.Modify, IconDataMembers.Tip);
    }

    private void CreatePopup()
    {
      if (!(this.TrayPopup is Popup popup) && this.TrayPopup != null)
      {
        popup = new Popup();
        popup.AllowsTransparency = true;
        popup.PopupAnimation = PopupAnimation.None;
        popup.Child = this.TrayPopup;
        popup.Placement = PlacementMode.AbsolutePoint;
        popup.StaysOpen = false;
      }
      if (popup != null)
        this.UpdateDataContext((FrameworkElement) popup, (object) null, this.DataContext);
      this.SetTrayPopupResolved(popup);
    }

    public void ShowTrayPopup(CoreLib.UI.TaskbarNotification.Interop.Point cursorPosition)
    {
      if (this.IsDisposed || this.RaisePreviewTrayPopupOpenEvent().Handled || this.TrayPopup == null)
        return;
      this.TrayPopupResolved.Placement = PlacementMode.AbsolutePoint;
      this.TrayPopupResolved.HorizontalOffset = (double) cursorPosition.X;
      this.TrayPopupResolved.VerticalOffset = (double) cursorPosition.Y;
      this.TrayPopupResolved.IsOpen = true;
      IntPtr hWnd = IntPtr.Zero;
      if (this.TrayPopupResolved.Child != null)
      {
        HwndSource hwndSource = (HwndSource) PresentationSource.FromVisual((Visual) this.TrayPopupResolved.Child);
        if (hwndSource != null)
          hWnd = hwndSource.Handle;
      }
      if (hWnd == IntPtr.Zero)
        hWnd = this.messageSink.MessageWindowHandle;
      WinApi.SetForegroundWindow(hWnd);
      if (this.TrayPopup != null)
        TaskbarIcon.RaisePopupOpenedEvent((DependencyObject) this.TrayPopup);
      this.RaiseTrayPopupOpenEvent();
    }

    private void ShowContextMenu(CoreLib.UI.TaskbarNotification.Interop.Point cursorPosition)
    {
      if (this.IsDisposed || this.RaisePreviewTrayContextMenuOpenEvent().Handled || this.ContextMenu == null)
        return;
      this.ContextMenu.Placement = PlacementMode.AbsolutePoint;
      this.ContextMenu.HorizontalOffset = (double) cursorPosition.X;
      this.ContextMenu.VerticalOffset = (double) cursorPosition.Y;
      this.ContextMenu.IsOpen = true;
      WinApi.SetForegroundWindow(this.messageSink.MessageWindowHandle);
      this.RaiseTrayContextMenuOpenEvent();
    }

    private void OnBalloonToolTipChanged(bool visible)
    {
      if (visible)
        this.RaiseTrayBalloonTipShownEvent();
      else
        this.RaiseTrayBalloonTipClosedEvent();
    }

    public void ShowBalloonTip(string title, string message, BalloonIcon symbol)
    {
      lock (this)
        this.ShowBalloonTip(title, message, symbol.GetBalloonFlag(), IntPtr.Zero);
    }

    public void ShowBalloonTip(string title, string message, Icon customIcon)
    {
      if (customIcon == null)
        throw new ArgumentNullException(nameof (customIcon));
      lock (this)
        this.ShowBalloonTip(title, message, BalloonFlags.User, customIcon.Handle);
    }

    private void ShowBalloonTip(
      string title,
      string message,
      BalloonFlags flags,
      IntPtr balloonIconHandle)
    {
      this.EnsureNotDisposed();
      this.iconData.BalloonText = message ?? string.Empty;
      this.iconData.BalloonTitle = title ?? string.Empty;
      this.iconData.BalloonFlags = flags;
      this.iconData.CustomBalloonIconHandle = balloonIconHandle;
      Util.WriteIconData(ref this.iconData, NotifyCommand.Modify, IconDataMembers.Icon | IconDataMembers.Info);
    }

    public void HideBalloonTip()
    {
      this.EnsureNotDisposed();
      this.iconData.BalloonText = this.iconData.BalloonTitle = string.Empty;
      Util.WriteIconData(ref this.iconData, NotifyCommand.Modify, IconDataMembers.Info);
    }

    private void DoSingleClickAction(object state)
    {
      if (this.IsDisposed)
        return;
      Action delayedTimerAction = this.delayedTimerAction;
      if (delayedTimerAction == null)
        return;
      this.delayedTimerAction = (Action) null;
      this.GetDispatcher().Invoke((Delegate) delayedTimerAction);
    }

    private void SetVersion()
    {
      this.iconData.VersionOrTimeout = 4U;
      bool flag = WinApi.Shell_NotifyIcon(NotifyCommand.SetVersion, ref this.iconData);
      if (!flag)
      {
        this.iconData.VersionOrTimeout = 3U;
        flag = Util.WriteIconData(ref this.iconData, NotifyCommand.SetVersion);
      }
      if (!flag)
      {
        this.iconData.VersionOrTimeout = 0U;
        flag = Util.WriteIconData(ref this.iconData, NotifyCommand.SetVersion);
      }
      int num = flag ? 1 : 0;
    }

    private void OnTaskbarCreated()
    {
      this.IsTaskbarIconCreated = false;
      this.CreateTaskbarIcon();
    }

    private void CreateTaskbarIcon()
    {
      lock (this)
      {
        if (this.IsTaskbarIconCreated)
          return;
        if (!Util.WriteIconData(ref this.iconData, NotifyCommand.Add, IconDataMembers.Message | IconDataMembers.Icon | IconDataMembers.Tip))
          throw new Win32Exception("Could not create icon data");
        this.SetVersion();
        this.messageSink.Version = (NotifyIconVersion) this.iconData.VersionOrTimeout;
        this.IsTaskbarIconCreated = true;
      }
    }

    private void RemoveTaskbarIcon()
    {
      lock (this)
      {
        if (!this.IsTaskbarIconCreated)
          return;
        Util.WriteIconData(ref this.iconData, NotifyCommand.Delete, IconDataMembers.Message);
        this.IsTaskbarIconCreated = false;
      }
    }

    public bool IsDisposed { get; private set; }

    private void EnsureNotDisposed()
    {
      if (this.IsDisposed)
        throw new ObjectDisposedException(this.Name ?? this.GetType().FullName);
    }

    private void OnExit(object sender, EventArgs e) => this.Dispose();

    ~TaskbarIcon() => this.Dispose(false);

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }

    private void Dispose(bool disposing)
    {
      if (this.IsDisposed || !disposing)
        return;
      lock (this)
      {
        this.IsDisposed = true;
        if (Application.Current != null)
          Application.Current.Exit -= new ExitEventHandler(this.OnExit);
        this.singleClickTimer.Dispose();
        this.balloonCloseTimer.Dispose();
        this.messageSink.Dispose();
        this.RemoveTaskbarIcon();
      }
    }

    [Category("NotifyIcon")]
    public Popup TrayPopupResolved => (Popup) this.GetValue(TaskbarIcon.TrayPopupResolvedProperty);

    protected void SetTrayPopupResolved(Popup value) => this.SetValue(TaskbarIcon.TrayPopupResolvedPropertyKey, (object) value);

    [Category("NotifyIcon")]
    [Browsable(true)]
    [Bindable(true)]
    public ToolTip TrayToolTipResolved => (ToolTip) this.GetValue(TaskbarIcon.TrayToolTipResolvedProperty);

    protected void SetTrayToolTipResolved(ToolTip value) => this.SetValue(TaskbarIcon.TrayToolTipResolvedPropertyKey, (object) value);

    public Popup CustomBalloon => (Popup) this.GetValue(TaskbarIcon.CustomBalloonProperty);

    protected void SetCustomBalloon(Popup value) => this.SetValue(TaskbarIcon.CustomBalloonPropertyKey, (object) value);

    [Browsable(false)]
    public Icon Icon
    {
      get => this.icon;
      set
      {
        this.icon = value;
        this.iconData.IconHandle = value == null ? IntPtr.Zero : this.icon.Handle;
        Util.WriteIconData(ref this.iconData, NotifyCommand.Modify, IconDataMembers.Icon);
      }
    }

    [Category("NotifyIcon")]
    [Description("Sets the displayed taskbar icon.")]
    public ImageSource IconSource
    {
      get => (ImageSource) this.GetValue(TaskbarIcon.IconSourceProperty);
      set => this.SetValue(TaskbarIcon.IconSourceProperty, (object) value);
    }

    private static void IconSourcePropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnIconSourcePropertyChanged(e);
    }

    private void OnIconSourcePropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      ImageSource newValue = (ImageSource) e.NewValue;
      if (Util.IsDesignMode)
        return;
      this.Icon = newValue.ToIcon();
    }

    [Category("NotifyIcon")]
    [Description("Alternative to a fully blown ToolTip, which is only displayed on Vista and above.")]
    public string ToolTipText
    {
      get => (string) this.GetValue(TaskbarIcon.ToolTipTextProperty);
      set => this.SetValue(TaskbarIcon.ToolTipTextProperty, (object) value);
    }

    private static void ToolTipTextPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnToolTipTextPropertyChanged(e);
    }

    private void OnToolTipTextPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (this.TrayToolTipResolved == null || this.TrayToolTipResolved.Content is string)
        this.CreateCustomToolTip();
      this.WriteToolTipSettings();
    }

    [Category("NotifyIcon")]
    [Description("Custom UI element that is displayed as a tooltip. Only on Vista and above")]
    public UIElement TrayToolTip
    {
      get => (UIElement) this.GetValue(TaskbarIcon.TrayToolTipProperty);
      set => this.SetValue(TaskbarIcon.TrayToolTipProperty, (object) value);
    }

    private static void TrayToolTipPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnTrayToolTipPropertyChanged(e);
    }

    private void OnTrayToolTipPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      this.CreateCustomToolTip();
      if (e.OldValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.OldValue, (TaskbarIcon) null);
      if (e.NewValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.NewValue, this);
      this.WriteToolTipSettings();
    }

    [Category("NotifyIcon")]
    [Description("Displayed as a Popup if the user clicks on the taskbar icon.")]
    public UIElement TrayPopup
    {
      get => (UIElement) this.GetValue(TaskbarIcon.TrayPopupProperty);
      set => this.SetValue(TaskbarIcon.TrayPopupProperty, (object) value);
    }

    private static void TrayPopupPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnTrayPopupPropertyChanged(e);
    }

    private void OnTrayPopupPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (e.OldValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.OldValue, (TaskbarIcon) null);
      if (e.NewValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.NewValue, this);
      this.CreatePopup();
    }

    [Category("NotifyIcon")]
    [Description("Defines what mouse events display the context menu.")]
    public PopupActivationMode MenuActivation
    {
      get => (PopupActivationMode) this.GetValue(TaskbarIcon.MenuActivationProperty);
      set => this.SetValue(TaskbarIcon.MenuActivationProperty, (object) value);
    }

    [Category("NotifyIcon")]
    [Description("Defines what mouse events display the TaskbarIconPopup.")]
    public PopupActivationMode PopupActivation
    {
      get => (PopupActivationMode) this.GetValue(TaskbarIcon.PopupActivationProperty);
      set => this.SetValue(TaskbarIcon.PopupActivationProperty, (object) value);
    }

    private static void VisibilityPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnVisibilityPropertyChanged(e);
    }

    private void OnVisibilityPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      if ((Visibility) e.NewValue == Visibility.Visible)
        this.CreateTaskbarIcon();
      else
        this.RemoveTaskbarIcon();
    }

    private void UpdateDataContext(
      FrameworkElement target,
      object oldDataContextValue,
      object newDataContextValue)
    {
      if (target == null || target.IsDataContextDataBound() || this != target.DataContext && !object.Equals(oldDataContextValue, target.DataContext))
        return;
      target.DataContext = newDataContextValue ?? (object) this;
    }

    private static void DataContextPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnDataContextPropertyChanged(e);
    }

    private void OnDataContextPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      object newValue = e.NewValue;
      object oldValue = e.OldValue;
      this.UpdateDataContext((FrameworkElement) this.TrayPopupResolved, oldValue, newValue);
      this.UpdateDataContext((FrameworkElement) this.TrayToolTipResolved, oldValue, newValue);
      this.UpdateDataContext((FrameworkElement) this.ContextMenu, oldValue, newValue);
    }

    private static void ContextMenuPropertyChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      ((TaskbarIcon) d).OnContextMenuPropertyChanged(e);
    }

    private void OnContextMenuPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
      if (e.OldValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.OldValue, (TaskbarIcon) null);
      if (e.NewValue != null)
        TaskbarIcon.SetParentTaskbarIcon((DependencyObject) e.NewValue, this);
      this.UpdateDataContext((FrameworkElement) e.NewValue, (object) null, this.DataContext);
    }

    public ICommand DoubleClickCommand
    {
      get => (ICommand) this.GetValue(TaskbarIcon.DoubleClickCommandProperty);
      set => this.SetValue(TaskbarIcon.DoubleClickCommandProperty, (object) value);
    }

    public object DoubleClickCommandParameter
    {
      get => this.GetValue(TaskbarIcon.DoubleClickCommandParameterProperty);
      set => this.SetValue(TaskbarIcon.DoubleClickCommandParameterProperty, value);
    }

    public IInputElement DoubleClickCommandTarget
    {
      get => (IInputElement) this.GetValue(TaskbarIcon.DoubleClickCommandTargetProperty);
      set => this.SetValue(TaskbarIcon.DoubleClickCommandTargetProperty, (object) value);
    }

    public ICommand LeftClickCommand
    {
      get => (ICommand) this.GetValue(TaskbarIcon.LeftClickCommandProperty);
      set => this.SetValue(TaskbarIcon.LeftClickCommandProperty, (object) value);
    }

    public object LeftClickCommandParameter
    {
      get => this.GetValue(TaskbarIcon.LeftClickCommandParameterProperty);
      set => this.SetValue(TaskbarIcon.LeftClickCommandParameterProperty, value);
    }

    public IInputElement LeftClickCommandTarget
    {
      get => (IInputElement) this.GetValue(TaskbarIcon.LeftClickCommandTargetProperty);
      set => this.SetValue(TaskbarIcon.LeftClickCommandTargetProperty, (object) value);
    }

    [Category("NotifyIcon")]
    public event RoutedEventHandler TrayLeftMouseDown
    {
      add => this.AddHandler(TaskbarIcon.TrayLeftMouseDownEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayLeftMouseDownEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayLeftMouseDownEvent() => TaskbarIcon.RaiseTrayLeftMouseDownEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayLeftMouseDownEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayLeftMouseDownEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayRightMouseDown
    {
      add => this.AddHandler(TaskbarIcon.TrayRightMouseDownEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayRightMouseDownEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayRightMouseDownEvent() => TaskbarIcon.RaiseTrayRightMouseDownEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayRightMouseDownEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayRightMouseDownEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayMiddleMouseDown
    {
      add => this.AddHandler(TaskbarIcon.TrayMiddleMouseDownEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayMiddleMouseDownEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayMiddleMouseDownEvent() => TaskbarIcon.RaiseTrayMiddleMouseDownEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayMiddleMouseDownEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayMiddleMouseDownEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayLeftMouseUp
    {
      add => this.AddHandler(TaskbarIcon.TrayLeftMouseUpEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayLeftMouseUpEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayLeftMouseUpEvent() => TaskbarIcon.RaiseTrayLeftMouseUpEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayLeftMouseUpEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayLeftMouseUpEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayRightMouseUp
    {
      add => this.AddHandler(TaskbarIcon.TrayRightMouseUpEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayRightMouseUpEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayRightMouseUpEvent() => TaskbarIcon.RaiseTrayRightMouseUpEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayRightMouseUpEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayRightMouseUpEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayMiddleMouseUp
    {
      add => this.AddHandler(TaskbarIcon.TrayMiddleMouseUpEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayMiddleMouseUpEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayMiddleMouseUpEvent() => TaskbarIcon.RaiseTrayMiddleMouseUpEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayMiddleMouseUpEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayMiddleMouseUpEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayMouseDoubleClick
    {
      add => this.AddHandler(TaskbarIcon.TrayMouseDoubleClickEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayMouseDoubleClickEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayMouseDoubleClickEvent()
    {
      RoutedEventArgs routedEventArgs = TaskbarIcon.RaiseTrayMouseDoubleClickEvent((DependencyObject) this);
      this.DoubleClickCommand.ExecuteIfEnabled(this.DoubleClickCommandParameter, this.DoubleClickCommandTarget ?? (IInputElement) this);
      return routedEventArgs;
    }

    internal static RoutedEventArgs RaiseTrayMouseDoubleClickEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayMouseDoubleClickEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayMouseMove
    {
      add => this.AddHandler(TaskbarIcon.TrayMouseMoveEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayMouseMoveEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayMouseMoveEvent() => TaskbarIcon.RaiseTrayMouseMoveEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayMouseMoveEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayMouseMoveEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayBalloonTipShown
    {
      add => this.AddHandler(TaskbarIcon.TrayBalloonTipShownEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayBalloonTipShownEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayBalloonTipShownEvent() => TaskbarIcon.RaiseTrayBalloonTipShownEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayBalloonTipShownEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayBalloonTipShownEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayBalloonTipClosed
    {
      add => this.AddHandler(TaskbarIcon.TrayBalloonTipClosedEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayBalloonTipClosedEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayBalloonTipClosedEvent() => TaskbarIcon.RaiseTrayBalloonTipClosedEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayBalloonTipClosedEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayBalloonTipClosedEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayBalloonTipClicked
    {
      add => this.AddHandler(TaskbarIcon.TrayBalloonTipClickedEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayBalloonTipClickedEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayBalloonTipClickedEvent() => TaskbarIcon.RaiseTrayBalloonTipClickedEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayBalloonTipClickedEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayBalloonTipClickedEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayContextMenuOpen
    {
      add => this.AddHandler(TaskbarIcon.TrayContextMenuOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayContextMenuOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayContextMenuOpenEvent() => TaskbarIcon.RaiseTrayContextMenuOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayContextMenuOpenEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayContextMenuOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler PreviewTrayContextMenuOpen
    {
      add => this.AddHandler(TaskbarIcon.PreviewTrayContextMenuOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.PreviewTrayContextMenuOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaisePreviewTrayContextMenuOpenEvent() => TaskbarIcon.RaisePreviewTrayContextMenuOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaisePreviewTrayContextMenuOpenEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.PreviewTrayContextMenuOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayPopupOpen
    {
      add => this.AddHandler(TaskbarIcon.TrayPopupOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayPopupOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayPopupOpenEvent() => TaskbarIcon.RaiseTrayPopupOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayPopupOpenEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayPopupOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler PreviewTrayPopupOpen
    {
      add => this.AddHandler(TaskbarIcon.PreviewTrayPopupOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.PreviewTrayPopupOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaisePreviewTrayPopupOpenEvent() => TaskbarIcon.RaisePreviewTrayPopupOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaisePreviewTrayPopupOpenEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.PreviewTrayPopupOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayToolTipOpen
    {
      add => this.AddHandler(TaskbarIcon.TrayToolTipOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayToolTipOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayToolTipOpenEvent() => TaskbarIcon.RaiseTrayToolTipOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayToolTipOpenEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayToolTipOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler PreviewTrayToolTipOpen
    {
      add => this.AddHandler(TaskbarIcon.PreviewTrayToolTipOpenEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.PreviewTrayToolTipOpenEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaisePreviewTrayToolTipOpenEvent() => TaskbarIcon.RaisePreviewTrayToolTipOpenEvent((DependencyObject) this);

    internal static RoutedEventArgs RaisePreviewTrayToolTipOpenEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.PreviewTrayToolTipOpenEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler TrayToolTipClose
    {
      add => this.AddHandler(TaskbarIcon.TrayToolTipCloseEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.TrayToolTipCloseEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaiseTrayToolTipCloseEvent() => TaskbarIcon.RaiseTrayToolTipCloseEvent((DependencyObject) this);

    internal static RoutedEventArgs RaiseTrayToolTipCloseEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.TrayToolTipCloseEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public event RoutedEventHandler PreviewTrayToolTipClose
    {
      add => this.AddHandler(TaskbarIcon.PreviewTrayToolTipCloseEvent, (Delegate) value);
      remove => this.RemoveHandler(TaskbarIcon.PreviewTrayToolTipCloseEvent, (Delegate) value);
    }

    protected RoutedEventArgs RaisePreviewTrayToolTipCloseEvent() => TaskbarIcon.RaisePreviewTrayToolTipCloseEvent((DependencyObject) this);

    internal static RoutedEventArgs RaisePreviewTrayToolTipCloseEvent(
      DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.PreviewTrayToolTipCloseEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static void AddPopupOpenedHandler(DependencyObject element, RoutedEventHandler handler) => RoutedEventHelper.AddHandler(element, TaskbarIcon.PopupOpenedEvent, (Delegate) handler);

    public static void RemovePopupOpenedHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.RemoveHandler(element, TaskbarIcon.PopupOpenedEvent, (Delegate) handler);
    }

    internal static RoutedEventArgs RaisePopupOpenedEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.PopupOpenedEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static void AddToolTipOpenedHandler(DependencyObject element, RoutedEventHandler handler) => RoutedEventHelper.AddHandler(element, TaskbarIcon.ToolTipOpenedEvent, (Delegate) handler);

    public static void RemoveToolTipOpenedHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.RemoveHandler(element, TaskbarIcon.ToolTipOpenedEvent, (Delegate) handler);
    }

    internal static RoutedEventArgs RaiseToolTipOpenedEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.ToolTipOpenedEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static void AddToolTipCloseHandler(DependencyObject element, RoutedEventHandler handler) => RoutedEventHelper.AddHandler(element, TaskbarIcon.ToolTipCloseEvent, (Delegate) handler);

    public static void RemoveToolTipCloseHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.RemoveHandler(element, TaskbarIcon.ToolTipCloseEvent, (Delegate) handler);
    }

    internal static RoutedEventArgs RaiseToolTipCloseEvent(DependencyObject target)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs();
      args.RoutedEvent = TaskbarIcon.ToolTipCloseEvent;
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static void AddBalloonShowingHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.AddHandler(element, TaskbarIcon.BalloonShowingEvent, (Delegate) handler);
    }

    public static void RemoveBalloonShowingHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.RemoveHandler(element, TaskbarIcon.BalloonShowingEvent, (Delegate) handler);
    }

    internal static RoutedEventArgs RaiseBalloonShowingEvent(
      DependencyObject target,
      TaskbarIcon source)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs(TaskbarIcon.BalloonShowingEvent, (object) source);
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static void AddBalloonClosingHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.AddHandler(element, TaskbarIcon.BalloonClosingEvent, (Delegate) handler);
    }

    public static void RemoveBalloonClosingHandler(
      DependencyObject element,
      RoutedEventHandler handler)
    {
      RoutedEventHelper.RemoveHandler(element, TaskbarIcon.BalloonClosingEvent, (Delegate) handler);
    }

    internal static RoutedEventArgs RaiseBalloonClosingEvent(
      DependencyObject target,
      TaskbarIcon source)
    {
      if (target == null)
        return (RoutedEventArgs) null;
      RoutedEventArgs args = new RoutedEventArgs(TaskbarIcon.BalloonClosingEvent, (object) source);
      RoutedEventHelper.RaiseEvent(target, args);
      return args;
    }

    public static TaskbarIcon GetParentTaskbarIcon(DependencyObject d) => (TaskbarIcon) d.GetValue(TaskbarIcon.ParentTaskbarIconProperty);

    public static void SetParentTaskbarIcon(DependencyObject d, TaskbarIcon value) => d.SetValue(TaskbarIcon.ParentTaskbarIconProperty, (object) value);

    static TaskbarIcon()
    {
      PropertyMetadata typeMetadata1 = new PropertyMetadata((object) Visibility.Visible, new PropertyChangedCallback(TaskbarIcon.VisibilityPropertyChanged));
      UIElement.VisibilityProperty.OverrideMetadata(typeof (TaskbarIcon), typeMetadata1);
      PropertyMetadata typeMetadata2 = (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(TaskbarIcon.DataContextPropertyChanged));
      FrameworkElement.DataContextProperty.OverrideMetadata(typeof (TaskbarIcon), typeMetadata2);
      PropertyMetadata typeMetadata3 = (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(TaskbarIcon.ContextMenuPropertyChanged));
      FrameworkElement.ContextMenuProperty.OverrideMetadata(typeof (TaskbarIcon), typeMetadata3);
    }
  }
}
