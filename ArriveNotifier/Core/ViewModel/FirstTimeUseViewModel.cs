// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ViewModel.FirstTimeUseViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using ArriveNotifier.Core.Models;
using CoreLib.ViewModels;
using System;
using System.Windows.Input;

namespace ArriveNotifier.Core.ViewModel
{
  public class FirstTimeUseViewModel : ViewModelBase
  {
    public FirstTimeUseViewModel(
      ArriveNotifierModel loginModel,
      NavigationViewModel navigation,
      ViewModelBase nextViewModel)
    {
      FirstTimeUseViewModel timeUseViewModel = this;
      this.LoginModel = loginModel;
      this.LoginCommand = (ICommand) new RelayCommand((Action<object>) (o =>
      {
        if (timeUseViewModel.LoginModel.TryLogin())
          navigation.Navigate(nextViewModel);
        timeUseViewModel.FirePropertyChanged(nameof (LoginModel));
      }), (Func<object, bool>) (o => timeUseViewModel.LoginModel.CanTryLogin()));
    }

    public ArriveNotifierModel LoginModel { get; private set; }

    public ICommand LoginCommand { get; private set; }
  }
}
