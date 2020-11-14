// Decompiled with JetBrains decompiler
// Type: CoreLib.UI.Views.PasswordBoxBinding
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Windows;
using System.Windows.Controls;

namespace CoreLib.UI.Views
{
  public static class PasswordBoxBinding
  {
    public static readonly DependencyProperty BoundPassword = DependencyProperty.RegisterAttached(nameof (BoundPassword), typeof (string), typeof (PasswordBoxBinding), new PropertyMetadata((object) string.Empty, new PropertyChangedCallback(PasswordBoxBinding.OnBoundPasswordChanged)));
    public static readonly DependencyProperty BindPassword = DependencyProperty.RegisterAttached(nameof (BindPassword), typeof (bool), typeof (PasswordBoxBinding), new PropertyMetadata((object) false, new PropertyChangedCallback(PasswordBoxBinding.OnBindPasswordChanged)));
    private static readonly DependencyProperty UpdatingPassword = DependencyProperty.RegisterAttached(nameof (UpdatingPassword), typeof (bool), typeof (PasswordBoxBinding), new PropertyMetadata((object) false));

    private static void OnBoundPasswordChanged(
      DependencyObject d,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(d is PasswordBox passwordBox) || !PasswordBoxBinding.GetBindPassword(d))
        return;
      passwordBox.PasswordChanged -= new RoutedEventHandler(PasswordBoxBinding.HandlePasswordChanged);
      string newValue = (string) e.NewValue;
      if (!PasswordBoxBinding.GetUpdatingPassword((DependencyObject) passwordBox))
        passwordBox.Password = newValue;
      passwordBox.PasswordChanged += new RoutedEventHandler(PasswordBoxBinding.HandlePasswordChanged);
    }

    private static void OnBindPasswordChanged(
      DependencyObject dp,
      DependencyPropertyChangedEventArgs e)
    {
      if (!(dp is PasswordBox passwordBox))
        return;
      int num = (bool) e.OldValue ? 1 : 0;
      bool newValue = (bool) e.NewValue;
      if (num != 0)
        passwordBox.PasswordChanged -= new RoutedEventHandler(PasswordBoxBinding.HandlePasswordChanged);
      if (!newValue)
        return;
      passwordBox.PasswordChanged += new RoutedEventHandler(PasswordBoxBinding.HandlePasswordChanged);
    }

    private static void HandlePasswordChanged(object sender, RoutedEventArgs e)
    {
      if (!(sender is PasswordBox passwordBox))
        return;
      PasswordBoxBinding.SetUpdatingPassword((DependencyObject) passwordBox, true);
      PasswordBoxBinding.SetBoundPassword((DependencyObject) passwordBox, passwordBox.Password);
      PasswordBoxBinding.SetUpdatingPassword((DependencyObject) passwordBox, false);
    }

    public static void SetBindPassword(DependencyObject dp, bool value) => dp.SetValue(PasswordBoxBinding.BindPassword, (object) value);

    public static bool GetBindPassword(DependencyObject dp) => (bool) dp.GetValue(PasswordBoxBinding.BindPassword);

    public static string GetBoundPassword(DependencyObject dp) => (string) dp.GetValue(PasswordBoxBinding.BoundPassword);

    public static void SetBoundPassword(DependencyObject dp, string value) => dp.SetValue(PasswordBoxBinding.BoundPassword, (object) value);

    private static bool GetUpdatingPassword(DependencyObject dp) => (bool) dp.GetValue(PasswordBoxBinding.UpdatingPassword);

    private static void SetUpdatingPassword(DependencyObject dp, bool value) => dp.SetValue(PasswordBoxBinding.UpdatingPassword, (object) value);
  }
}
