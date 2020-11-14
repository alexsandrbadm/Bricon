// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.Views.UserControlBase
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Controls;

namespace CoreLib.UI.Views
{
  public class UserControlBase : UserControl, INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    public void FirePropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    [Conditional("DEBUG")]
    private void CheckIfPropertyNameExists(string propertyName) => this.GetType();
  }
}
