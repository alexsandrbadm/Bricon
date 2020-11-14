// Decompiled with JetBrains decompiler
// Type: MultiLanguageMarkup.LangExtension
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows;
using System.Windows.Markup;

namespace MultiLanguageMarkup
{
  internal class LangExtension : MarkupExtension
  {
    private static string RootNamespace = "BriconLib";
    private static ResourceManager ResMgr = new ResourceManager(Assembly.GetExecutingAssembly().GetName().Name + ".MultiLang", Assembly.GetExecutingAssembly());
    private string _ResourceKey;
    private List<LangExtension.target> _Targets;

    public LangExtension(string resourceKey)
    {
      this._ResourceKey = resourceKey;
      this._Targets = new List<LangExtension.target>();
    }

    public override object ProvideValue(IServiceProvider serviceProvider)
    {
      IProvideValueTarget service = serviceProvider.GetService(typeof (IProvideValueTarget)) as IProvideValueTarget;
      DependencyProperty targetProperty = service.TargetProperty as DependencyProperty;
      if (service.TargetObject is FrameworkElement)
      {
        FrameworkElement targetObject = service.TargetObject as FrameworkElement;
        PropertyInfo property = targetObject.GetType().GetProperty(targetProperty.Name);
        targetObject.Unloaded += new RoutedEventHandler(this.Element_Unloaded);
        targetObject.Loaded += new RoutedEventHandler(this.Element_Loaded);
        this._Targets.Add(new LangExtension.target()
        {
          elem = targetObject,
          prop = property,
          loaded = false
        });
      }
      else if (service.TargetObject.GetType().FullName == "System.Windows.SharedDp")
        return (object) this;
      return (object) LangExtension.ResMgr.GetString(this._ResourceKey);
    }

    protected virtual void ml_UpdateControls()
    {
      foreach (LangExtension.target target in this._Targets)
      {
        if (target.loaded && target.elem != null && target.prop != (PropertyInfo) null)
        {
          string str = LangExtension.ResMgr.GetString(this._ResourceKey);
          target.prop.SetValue((object) target.elem, (object) str, (object[]) null);
        }
      }
    }

    private void Element_Unloaded(object sender, RoutedEventArgs e)
    {
      FrameworkElement element = sender as FrameworkElement;
      if (element == null)
        return;
      this._Targets.Where<LangExtension.target>((Func<LangExtension.target, bool>) (x => x.elem == element)).ToList<LangExtension.target>().ForEach((Action<LangExtension.target>) (x => x.loaded = false));
    }

    private void Element_Loaded(object sender, RoutedEventArgs e)
    {
      if (!(sender is FrameworkElement frameworkElement))
        return;
      foreach (LangExtension.target target in this._Targets)
      {
        if (target.elem == frameworkElement && !target.loaded)
        {
          target.loaded = true;
          if (target.prop != (PropertyInfo) null)
          {
            string str = LangExtension.ResMgr.GetString(this._ResourceKey);
            target.prop.SetValue((object) target.elem, (object) str, (object[]) null);
          }
        }
      }
    }

    private class target
    {
      public FrameworkElement elem;
      public PropertyInfo prop;
      public bool loaded;
    }
  }
}
