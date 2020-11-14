// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.UI.Views.MainWindow
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.Core.ViewModel;
using BriconLib.Properties;
using CoreLib.UI.TaskbarNotification;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ArriveNotifier.UI.Views
{
  public partial class MainWindow : Window, IComponentConnector
  {
    private MainWindowViewModel _viewModel;
    internal TaskbarIcon MyNotifyIcon;
    private bool _contentLoaded;

    public MainWindow()
    {
      this.InitializeComponent();
      this.Visibility = Visibility.Collapsed;
    }

    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
      this.Visibility = Visibility.Collapsed;
      this._viewModel = new MainWindowViewModel(Settings.Default.LoginBriconWeb, Settings.Default.PasswordBriconWeb);
      this._viewModel.DataChanged += new EventHandler(this._viewModel_DataChanged);
      this.DataContext = (object) this._viewModel;
      this.MyNotifyIcon.ShowBalloonTip("Bricon Aanmeldings Melder", "Klik hier om het programma te openen", BalloonIcon.Info);
    }

    private void _viewModel_DataChanged(object sender, EventArgs e) => this.Dispatcher.Invoke((Delegate) (() => this.Show_OnClick(sender, (RoutedEventArgs) null)));

    private void MyNotifyIcon_TrayPopupOpen(object sender, RoutedEventArgs e)
    {
    }

    private void Close_OnClick(object sender, RoutedEventArgs e)
    {
      this.Close();
      this.MyNotifyIcon.CloseBalloon();
      this.MyNotifyIcon.Dispose();
    }

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
    }

    private void Show_OnClick(object sender, RoutedEventArgs e) => this.MyNotifyIcon.ShowTrayPopup(new CoreLib.UI.TaskbarNotification.Interop.Point()
    {
      X = 1000,
      Y = 5000
    });

    private void Settings_OnClick(object sender, RoutedEventArgs e)
    {
      this._viewModel.GoToSettings.Execute((object) null);
      this.Show_OnClick(sender, e);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/BriconLib;component/arrivenotifier/ui/views/mainwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.MainWindow_OnLoaded);
          ((Window) target).Closed += new EventHandler(this.MainWindow_OnClosed);
          break;
        case 2:
          this.MyNotifyIcon = (TaskbarIcon) target;
          break;
        case 3:
          ((MenuItem) target).Click += new RoutedEventHandler(this.Show_OnClick);
          break;
        case 4:
          ((MenuItem) target).Click += new RoutedEventHandler(this.Settings_OnClick);
          break;
        case 5:
          ((MenuItem) target).Click += new RoutedEventHandler(this.Close_OnClick);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
