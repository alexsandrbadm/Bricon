// Decompiled with JetBrains decompiler
// Type: BriconLib.Basket.BasketWindow
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.PAS.Basket;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace BriconLib.Basket
{
  public class BasketWindow : Window, IComponentConnector
  {
    internal Label LabelFancier;
    internal ListBox ListBoxLog;
    private bool _contentLoaded;

    public BasketWindow(BasketViewModel model)
    {
      model.BasketWindow = this;
      this.DataContext = (object) model;
      this.InitializeComponent();
      this.WindowState = WindowState.Maximized;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/BriconLib;component/pas/basket/basketwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      if (connectionId != 1)
      {
        if (connectionId == 2)
          this.ListBoxLog = (ListBox) target;
        else
          this._contentLoaded = true;
      }
      else
        this.LabelFancier = (Label) target;
    }
  }
}
