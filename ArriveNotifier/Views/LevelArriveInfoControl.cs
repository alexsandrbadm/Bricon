// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Views.LevelArriveInfoControl
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace ArriveNotifier.Views
{
  public class LevelArriveInfoControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty LevelNameProperty = DependencyProperty.Register(nameof (LevelName), typeof (string), typeof (LevelArriveInfoControl), new PropertyMetadata((object) null));
    internal LevelArriveInfoControl _this;
    private bool _contentLoaded;

    public LevelArriveInfoControl() => this.InitializeComponent();

    public string LevelName
    {
      get => (string) this.GetValue(LevelArriveInfoControl.LevelNameProperty);
      set => this.SetValue(LevelArriveInfoControl.LevelNameProperty, (object) value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/BriconLib;component/arrivenotifier/ui/views/levelarriveinfocontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this._this = (LevelArriveInfoControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
