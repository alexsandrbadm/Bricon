// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.StartBasketWindow
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;

namespace BriconLib.PAS.Basket
{
  public class StartBasketWindow : Window, IComponentConnector
  {
    internal ComboBox ComboBoxRaces;
    internal Button ButtonOk;
    internal Button ButtonCancel;
    private bool _contentLoaded;

    public GetRacesService.GetRacesModel.Race SelectedRace { get; set; }

    public StartBasketWindow()
    {
      this.DataContext = (object) this;
      this.InitializeComponent();
      this.ComboBoxRaces.Focus();
    }

    private void ButtonCancel_Click(object sender, RoutedEventArgs e)
    {
      this.DialogResult = new bool?(false);
      this.Close();
    }

    private void ButtonOk_Click(object sender, RoutedEventArgs e)
    {
      this.SelectedRace = this.ComboBoxRaces.SelectedItem as GetRacesService.GetRacesModel.Race;
      if (this.SelectedRace == null)
        return;
      this.DialogResult = new bool?(true);
      this.Close();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e) => this.ButtonReload_Click(sender, e);

    private void ButtonReload_Click(object sender, RoutedEventArgs e)
    {
      GetRacesService.GetRacesModel getRacesModel = new GetRacesService().Get();
      if (getRacesModel.Success)
      {
        this.ComboBoxRaces.ItemsSource = (IEnumerable) getRacesModel.Races;
        if (getRacesModel.Races.Count != 1)
          return;
        this.ComboBoxRaces.SelectedItem = (object) getRacesModel.Races[0];
        this.ButtonOk_Click(sender, e);
      }
      else
      {
        int num = (int) MessageBox.Show(ml.ml_string(1381, "Error when loading Races"));
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/BriconLib;component/pas/basket/startbasketwindow.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Window_Loaded);
          break;
        case 2:
          this.ComboBoxRaces = (ComboBox) target;
          break;
        case 3:
          ((ButtonBase) target).Click += new RoutedEventHandler(this.ButtonReload_Click);
          break;
        case 4:
          this.ButtonOk = (Button) target;
          this.ButtonOk.Click += new RoutedEventHandler(this.ButtonOk_Click);
          break;
        case 5:
          this.ButtonCancel = (Button) target;
          this.ButtonCancel.Click += new RoutedEventHandler(this.ButtonCancel_Click);
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
