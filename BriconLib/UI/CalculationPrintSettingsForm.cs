// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.CalculationPrintSettingsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class CalculationPrintSettingsForm : Form
  {
    private IContainer components;
    private CheckBox checkBox1;
    private BindingSource settingsBindingSource;
    private BCEDataSet bCEDataSet;
    private CheckBox checkBox2;
    private CheckBox checkBox3;
    private CheckBox checkBox4;
    private CheckBox checkBox5;
    private Button buttonOK;
    private Button buttonCancel;
    private CheckBox checkBox6;
    private CheckBox checkBox7;
    private NumericUpDown numericUpDown1;
    private Label label1;
    private CheckBox checkBox8;
    private CheckBox checkBox9;
    private CheckBox checkBox10;
    private CheckBox checkBox11;

    public CalculationPrintSettingsForm()
    {
      this.InitializeComponent();
      if (BCEDatabase.DataSet.Settings[0].CalculationPrintFCIAB)
        this.checkBox3.Checked = true;
      else if (BCEDatabase.DataSet.Settings[0].CalculationPrintFCICD)
      {
        this.checkBox4.Checked = true;
      }
      else
      {
        if (!BCEDatabase.DataSet.Settings[0].CalculationPrintFCIE)
          return;
        this.checkBox5.Checked = true;
      }
    }

    private void CalculationPrintSettingsForm_Load(object sender, EventArgs e) => this.settingsBindingSource.DataSource = (object) BCEDatabase.DataSet;

    private void buttonOK_Click(object sender, EventArgs e)
    {
      BCEDatabase.DataSet.Settings.AcceptChanges();
      this.Close();
    }

    private void CalculationPrintSettingsForm_FormClosing(object sender, FormClosingEventArgs e) => BCEDatabase.DataSet.Settings.RejectChanges();

    private void checkBox3_Click(object sender, EventArgs e)
    {
      this.checkBox4.Checked = false;
      this.checkBox5.Checked = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIAB = this.checkBox3.Checked;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCICD = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIE = false;
    }

    private void checkBox4_Click(object sender, EventArgs e)
    {
      this.checkBox3.Checked = false;
      this.checkBox5.Checked = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIAB = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCICD = this.checkBox4.Checked;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIE = false;
    }

    private void checkBox5_Click(object sender, EventArgs e)
    {
      this.checkBox3.Checked = false;
      this.checkBox4.Checked = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIAB = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCICD = false;
      BCEDatabase.DataSet.Settings[0].CalculationPrintFCIE = this.checkBox5.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CalculationPrintSettingsForm));
      this.checkBox1 = new CheckBox();
      this.settingsBindingSource = new BindingSource(this.components);
      this.bCEDataSet = new BCEDataSet();
      this.checkBox2 = new CheckBox();
      this.checkBox3 = new CheckBox();
      this.checkBox4 = new CheckBox();
      this.checkBox5 = new CheckBox();
      this.buttonOK = new Button();
      this.buttonCancel = new Button();
      this.checkBox6 = new CheckBox();
      this.checkBox7 = new CheckBox();
      this.numericUpDown1 = new NumericUpDown();
      this.label1 = new Label();
      this.checkBox8 = new CheckBox();
      this.checkBox9 = new CheckBox();
      this.checkBox10 = new CheckBox();
      this.checkBox11 = new CheckBox();
      ((ISupportInitialize) this.settingsBindingSource).BeginInit();
      this.bCEDataSet.BeginInit();
      this.numericUpDown1.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintClubID", true));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.settingsBindingSource.DataMember = "Settings";
      this.settingsBindingSource.DataSource = (object) this.bCEDataSet;
      this.bCEDataSet.DataSetName = "BCEDataSet";
      this.bCEDataSet.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      componentResourceManager.ApplyResources((object) this.checkBox2, "checkBox2");
      this.checkBox2.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintPositie", true));
      this.checkBox2.Name = "checkBox2";
      this.checkBox2.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox3, "checkBox3");
      this.checkBox3.Name = "checkBox3";
      this.checkBox3.UseVisualStyleBackColor = true;
      this.checkBox3.Click += new EventHandler(this.checkBox3_Click);
      componentResourceManager.ApplyResources((object) this.checkBox4, "checkBox4");
      this.checkBox4.Name = "checkBox4";
      this.checkBox4.UseVisualStyleBackColor = true;
      this.checkBox4.Click += new EventHandler(this.checkBox4_Click);
      componentResourceManager.ApplyResources((object) this.checkBox5, "checkBox5");
      this.checkBox5.Name = "checkBox5";
      this.checkBox5.UseVisualStyleBackColor = true;
      this.checkBox5.Click += new EventHandler(this.checkBox5_Click);
      this.buttonOK.DialogResult = DialogResult.OK;
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox6, "checkBox6");
      this.checkBox6.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintPercentage", true));
      this.checkBox6.Name = "checkBox6";
      this.checkBox6.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox7, "checkBox7");
      this.checkBox7.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintFCICustom", true));
      this.checkBox7.Name = "checkBox7";
      this.checkBox7.UseVisualStyleBackColor = true;
      this.numericUpDown1.DataBindings.Add(new Binding("Value", (object) this.settingsBindingSource, "CalculationPrintFCIPercentage", true));
      this.numericUpDown1.DecimalPlaces = 2;
      componentResourceManager.ApplyResources((object) this.numericUpDown1, "numericUpDown1");
      this.numericUpDown1.Name = "numericUpDown1";
      this.numericUpDown1.Value = new Decimal(new int[4]
      {
        10000,
        0,
        0,
        131072
      });
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.checkBox8, "checkBox8");
      this.checkBox8.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintFlightTime", true));
      this.checkBox8.Name = "checkBox8";
      this.checkBox8.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox9, "checkBox9");
      this.checkBox9.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintTeamNbr", true));
      this.checkBox9.Name = "checkBox9";
      this.checkBox9.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox10, "checkBox10");
      this.checkBox10.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintLicense", true));
      this.checkBox10.Name = "checkBox10";
      this.checkBox10.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBox11, "checkBox11");
      this.checkBox11.DataBindings.Add(new Binding("Checked", (object) this.settingsBindingSource, "CalculationPrintOveralPoints", true));
      this.checkBox11.Name = "checkBox11";
      this.checkBox11.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBox11);
      this.Controls.Add((Control) this.checkBox10);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.numericUpDown1);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonOK);
      this.Controls.Add((Control) this.checkBox7);
      this.Controls.Add((Control) this.checkBox9);
      this.Controls.Add((Control) this.checkBox5);
      this.Controls.Add((Control) this.checkBox4);
      this.Controls.Add((Control) this.checkBox6);
      this.Controls.Add((Control) this.checkBox3);
      this.Controls.Add((Control) this.checkBox2);
      this.Controls.Add((Control) this.checkBox8);
      this.Controls.Add((Control) this.checkBox1);
      this.Name = nameof (CalculationPrintSettingsForm);
      this.FormClosing += new FormClosingEventHandler(this.CalculationPrintSettingsForm_FormClosing);
      this.Load += new EventHandler(this.CalculationPrintSettingsForm_Load);
      ((ISupportInitialize) this.settingsBindingSource).EndInit();
      this.bCEDataSet.EndInit();
      this.numericUpDown1.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
