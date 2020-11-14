// Decompiled with JetBrains decompiler
// Type: CalendarEditingControl
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Windows.Forms;

internal class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
{
  private DataGridView dataGridView;
  private bool valueChanged;
  private int rowIndex;

  public CalendarEditingControl() => this.Format = DateTimePickerFormat.Short;

  public object EditingControlFormattedValue
  {
    get => (object) this.Value.ToShortDateString();
    set
    {
      if (!(value is string))
        return;
      this.Value = DateTime.Parse((string) value);
    }
  }

  public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context) => this.EditingControlFormattedValue;

  public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
  {
    this.Font = dataGridViewCellStyle.Font;
    this.CalendarForeColor = dataGridViewCellStyle.ForeColor;
    this.CalendarMonthBackground = dataGridViewCellStyle.BackColor;
  }

  public int EditingControlRowIndex
  {
    get => this.rowIndex;
    set => this.rowIndex = value;
  }

  public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
  {
    switch (key & Keys.KeyCode)
    {
      case Keys.Prior:
      case Keys.Next:
      case Keys.End:
      case Keys.Home:
      case Keys.Left:
      case Keys.Up:
      case Keys.Right:
      case Keys.Down:
        return true;
      default:
        return false;
    }
  }

  public void PrepareEditingControlForEdit(bool selectAll)
  {
  }

  public bool RepositionEditingControlOnValueChange => false;

  public DataGridView EditingControlDataGridView
  {
    get => this.dataGridView;
    set => this.dataGridView = value;
  }

  public bool EditingControlValueChanged
  {
    get => this.valueChanged;
    set => this.valueChanged = value;
  }

  public Cursor EditingPanelCursor => this.Cursor;

  protected override void OnValueChanged(EventArgs eventargs)
  {
    this.valueChanged = true;
    this.EditingControlDataGridView.NotifyCurrentCellDirty(true);
    base.OnValueChanged(eventargs);
  }
}
