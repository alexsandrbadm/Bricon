// Decompiled with JetBrains decompiler
// Type: CalendarColumn
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows.Forms;

public class CalendarColumn : DataGridViewColumn
{
  public CalendarColumn()
    : base((DataGridViewCell) new CalendarCell())
  {
  }

  public override DataGridViewCell CellTemplate
  {
    get => base.CellTemplate;
    set => base.CellTemplate = value == null || value.GetType().IsAssignableFrom(typeof (CalendarCell)) ? value : throw new InvalidCastException("Must be a CalendarCell");
  }
}
