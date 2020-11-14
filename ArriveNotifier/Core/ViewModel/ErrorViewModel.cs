// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ViewModel.ErrorViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using CoreLib.ViewModels;
using System;
using System.Windows.Input;

namespace ArriveNotifier.Core.ViewModel
{
  public class ErrorViewModel : ViewModelBase
  {
    public ErrorViewModel(
      NavigationViewModel navigation,
      ViewModelBase previousViewModel,
      string message)
    {
      this.Message = message;
      this.OkCommand = (ICommand) new RelayCommand((Action<object>) (o => navigation.Navigate(previousViewModel)));
    }

    public string Message { get; private set; }

    public ICommand OkCommand { get; private set; }
  }
}
