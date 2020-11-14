// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Views.CategoryArriveInfoControl
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
  public class CategoryArriveInfoControl : UserControl, IComponentConnector
  {
    public static readonly DependencyProperty CategoryNameProperty = DependencyProperty.Register(nameof (CategoryName), typeof (string), typeof (CategoryArriveInfoControl), new PropertyMetadata((object) null));
    internal CategoryArriveInfoControl _this;
    private bool _contentLoaded;

    public CategoryArriveInfoControl() => this.InitializeComponent();

    public string CategoryName
    {
      get => (string) this.GetValue(CategoryArriveInfoControl.CategoryNameProperty);
      set => this.SetValue(CategoryArriveInfoControl.CategoryNameProperty, (object) value);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/BriconLib;component/arrivenotifier/ui/views/categoryarriveinfocontrol.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId == 1)
        this._this = (CategoryArriveInfoControl) target;
      else
        this._contentLoaded = true;
    }
  }
}
