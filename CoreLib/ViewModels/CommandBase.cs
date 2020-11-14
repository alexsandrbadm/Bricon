// Decompiled with JetBrains decompiler
// Type: CoreLib.ViewModels.CommandBase
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows.Input;

namespace CoreLib.ViewModels
{
  public abstract class CommandBase : ICommand
  {
    public event EventHandler CanExecuteChanged
    {
      add => CommandManager.RequerySuggested += value;
      remove => CommandManager.RequerySuggested -= value;
    }

    public void OnCanExecuteChanged() => CommandManager.InvalidateRequerySuggested();

    public virtual bool CanExecute(object parameter) => true;

    public void Execute(object parameter)
    {
      if (!this.CanExecute(parameter))
        return;
      this.OnExecute(parameter);
    }

    protected abstract void OnExecute(object parameter);
  }
}
