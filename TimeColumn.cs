// Decompiled with JetBrains decompiler
// Type: TimeColumn
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows.Forms;

public class TimeColumn : DataGridViewColumn
{
  public TimeColumn()
    : base((DataGridViewCell) new TimeCell())
  {
  }

  public override DataGridViewCell CellTemplate
  {
    get => base.CellTemplate;
    set => base.CellTemplate = value == null || value.GetType().IsAssignableFrom(typeof (TimeCell)) ? value : throw new InvalidCastException("Must be a TimeCell");
  }
}
