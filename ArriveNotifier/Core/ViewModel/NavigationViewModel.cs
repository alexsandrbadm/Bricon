// Decompiled with JetBrains decompiler
// Type: ArriveNotifier.Core.ViewModel.NavigationViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using CoreLib.ViewModels;

namespace ArriveNotifier.Core.ViewModel
{
  public class NavigationViewModel : ViewModelBase
  {
    public ViewModelBase Content { get; private set; }

    public bool Navigate(ViewModelBase viewModel)
    {
      if (this.Content != null && !this.Content.OnNavigatingFrom())
        return false;
      this.Content = viewModel;
      viewModel.OnNavigatingTo();
      this.FirePropertyChanged("Content");
      return true;
    }
  }
}
