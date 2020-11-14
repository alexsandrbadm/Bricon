// Decompiled with JetBrains decompiler
// Type: CoreLib.ViewModels.ViewModelBase
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.ComponentModel;
using System.Diagnostics;

namespace CoreLib.ViewModels
{
  public class ViewModelBase : INotifyPropertyChanged
  {
    public virtual void OnNavigatingTo()
    {
    }

    public virtual bool OnNavigatingFrom() => true;

    public event PropertyChangedEventHandler PropertyChanged;

    public void FirePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    [Conditional("DEBUG")]
    private void CheckIfPropertyNameExists(string propertyName)
    {
      if (string.IsNullOrWhiteSpace(propertyName))
        return;
      this.GetType();
    }
  }
}
