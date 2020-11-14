// Decompiled with JetBrains decompiler
// Type: TimeCell
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows.Forms;

public class TimeCell : DataGridViewTextBoxCell
{
  public TimeCell() => this.Style.Format = "HH:mm";

  public override void InitializeEditingControl(
    int rowIndex,
    object initialFormattedValue,
    DataGridViewCellStyle dataGridViewCellStyle)
  {
    base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
    (this.DataGridView.EditingControl as TimeEditingControl).Value = (DateTime) this.Value;
  }

  public override System.Type EditType => typeof (TimeEditingControl);

  public override System.Type ValueType => typeof (DateTime);

  public override object DefaultNewRowValue => (object) DateTime.Now;
}
