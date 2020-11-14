// Decompiled with JetBrains decompiler
// Type: CoreLib.ViewModels.RelayCommand
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;

namespace CoreLib.ViewModels
{
  public class RelayCommand : CommandBase
  {
    private Action<object> execute;
    private Func<object, bool> canExecute;

    public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
    {
      if (execute == null)
        throw new ArgumentNullException(nameof (execute));
      if (canExecute == null)
        canExecute = (Func<object, bool>) (o => true);
      this.execute = execute;
      this.canExecute = canExecute;
    }

    public override bool CanExecute(object parameter) => this.canExecute(parameter);

    protected override void OnExecute(object parameter) => this.execute(parameter);
  }
}
