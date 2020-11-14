// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.AskDistanceForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class AskDistanceForm : Form
  {
    private IContainer components;
    private Button buttonOK;
    private Label labelCaption;
    private NumericUpDown numericUpDownDistance;
    private Label labelUnit;
    private NumericUpDown numericUpDownMeter;
    private Label labelUnit2;
    private Label label1;
    private ComboBox comboBoxRace;

    public AskDistanceForm(string fancierLicense, string fancierName, string flightName)
    {
      this.InitializeComponent();
      this.labelCaption.Text = string.Format(this.labelCaption.Text, (object) fancierName, (object) flightName);
      this.labelUnit.Text = Utils.UnitsUsed() == "Imperial" ? ml.ml_string(602, "Miles") : ml.ml_string(599, "Km");
      this.labelUnit2.Text = Utils.UnitsUsed() == "Imperial" ? ml.ml_string(601, "Yards") : ml.ml_string(814, "m");
      this.numericUpDownDistance.Maximum = (Decimal) (Utils.UnitsUsed() == "Imperial" ? 999 : 1999);
      this.numericUpDownMeter.Maximum = (Decimal) (Utils.UnitsUsed() == "Imperial" ? 1759 : 1000);
      if (!Settings.Default.UseDistanceDB)
        return;
      DataRow[] dataRowArray = BCEDatabase.DataSet.Adressen.Select("Licentie = '" + fancierLicense + "'");
      if (dataRowArray.Length != 1)
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1398, "Error: Fancier not found with license ") + fancierLicense + " Format : " + BCEDatabase.DataSet.Adressen[0]["Licentie"]?.ToString());
      }
      if ((int) dataRowArray[0]["Id"] == 0)
      {
        int num2 = (int) MessageBox.Show("ID is 0");
      }
      foreach (BCEDataSet.DistancesRow distancesRow in BCEDatabase.DataSet.Distances.Select("FancierID = " + dataRowArray[0]["Id"]?.ToString() + " and distance <> 0"))
      {
        BCEDataSet.LossingsplaatsRow byid = BCEDatabase.DataSet.Lossingsplaats.FindByid(distancesRow.LosplaatsID);
        if (byid != null)
        {
          if (Utils.UnitsUsed() == "Imperial")
            this.comboBoxRace.Items.Add((object) new KeyValuePair<string, Decimal>(byid.Losplaats + " - " + distancesRow.Distance.ToString() + "m" + distancesRow.DistanceYards.ToString() + "y", (Decimal) (distancesRow.Distance + distancesRow.DistanceYards / 1760)));
          else
            this.comboBoxRace.Items.Add((object) new KeyValuePair<string, Decimal>(byid.Losplaats + " - " + distancesRow.Distance.ToString() + "km" + distancesRow.DistanceYards.ToString() + "m", (Decimal) (distancesRow.Distance + distancesRow.DistanceYards / 1000)));
          if (byid.Losplaats.ToLower().StartsWith(flightName.ToLower()))
          {
            this.comboBoxRace.SelectedIndex = this.comboBoxRace.Items.Count - 1;
            this.numericUpDownMeter.Value = (Decimal) distancesRow.DistanceYards;
            this.numericUpDownDistance.Value = (Decimal) distancesRow.Distance;
          }
        }
      }
    }

    public Decimal Distance
    {
      get => Utils.UnitsUsed() == "Imperial" ? this.numericUpDownDistance.Value + this.numericUpDownMeter.Value / 1760M : this.numericUpDownDistance.Value + this.numericUpDownMeter.Value / 1000M;
      private set
      {
        this.numericUpDownDistance.Value = (Decimal) (int) value;
        if (Utils.UnitsUsed() == "Imperial")
          this.numericUpDownMeter.Value = (value - (Decimal) (int) value) * 1760M;
        else
          this.numericUpDownMeter.Value = (value - (Decimal) (int) value) * 1000M;
      }
    }

    private void buttonOK_Click(object sender, EventArgs e) => this.Close();

    private void AskDistanceForm_Load(object sender, EventArgs e)
    {
    }

    private void AskDistanceForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (!(this.numericUpDownDistance.Value == 0M))
        return;
      int num = (int) MessageBox.Show(ml.ml_string(598, "Please fill in the distance."));
      e.Cancel = true;
    }

    private void numericUpDownMeter_Enter(object sender, EventArgs e) => (sender as NumericUpDown).Select(0, (sender as NumericUpDown).Text.Length);

    private void comboBoxRace_SelectionChangeCommitted(object sender, EventArgs e)
    {
      if (!(this.comboBoxRace.SelectedItem is KeyValuePair<string, Decimal>))
        return;
      this.Distance = ((KeyValuePair<string, Decimal>) this.comboBoxRace.SelectedItem).Value;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AskDistanceForm));
      this.buttonOK = new Button();
      this.labelCaption = new Label();
      this.numericUpDownDistance = new NumericUpDown();
      this.labelUnit = new Label();
      this.numericUpDownMeter = new NumericUpDown();
      this.labelUnit2 = new Label();
      this.label1 = new Label();
      this.comboBoxRace = new ComboBox();
      this.numericUpDownDistance.BeginInit();
      this.numericUpDownMeter.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonOK, "buttonOK");
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new EventHandler(this.buttonOK_Click);
      componentResourceManager.ApplyResources((object) this.labelCaption, "labelCaption");
      this.labelCaption.Name = "labelCaption";
      componentResourceManager.ApplyResources((object) this.numericUpDownDistance, "numericUpDownDistance");
      this.numericUpDownDistance.Maximum = new Decimal(new int[4]
      {
        1500,
        0,
        0,
        0
      });
      this.numericUpDownDistance.Name = "numericUpDownDistance";
      this.numericUpDownDistance.Enter += new EventHandler(this.numericUpDownMeter_Enter);
      componentResourceManager.ApplyResources((object) this.labelUnit, "labelUnit");
      this.labelUnit.Name = "labelUnit";
      componentResourceManager.ApplyResources((object) this.numericUpDownMeter, "numericUpDownMeter");
      this.numericUpDownMeter.Maximum = new Decimal(new int[4]
      {
        1000,
        0,
        0,
        0
      });
      this.numericUpDownMeter.Name = "numericUpDownMeter";
      this.numericUpDownMeter.Enter += new EventHandler(this.numericUpDownMeter_Enter);
      componentResourceManager.ApplyResources((object) this.labelUnit2, "labelUnit2");
      this.labelUnit2.Name = "labelUnit2";
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.DataBindings.Add(new Binding("Visible", (object) Settings.Default, "UseDistanceDB", true, DataSourceUpdateMode.OnPropertyChanged));
      this.label1.Name = "label1";
      this.label1.Visible = Settings.Default.UseDistanceDB;
      this.comboBoxRace.DataBindings.Add(new Binding("Visible", (object) Settings.Default, "UseDistanceDB", true, DataSourceUpdateMode.OnPropertyChanged));
      this.comboBoxRace.DisplayMember = "Key";
      this.comboBoxRace.DropDownStyle = ComboBoxStyle.DropDownList;
      this.comboBoxRace.FormattingEnabled = true;
      componentResourceManager.ApplyResources((object) this.comboBoxRace, "comboBoxRace");
      this.comboBoxRace.Name = "comboBoxRace";
      this.comboBoxRace.ValueMember = "Value";
      this.comboBoxRace.Visible = Settings.Default.UseDistanceDB;
      this.comboBoxRace.SelectionChangeCommitted += new EventHandler(this.comboBoxRace_SelectionChangeCommitted);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.comboBoxRace);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.labelUnit2);
      this.Controls.Add((Control) this.labelUnit);
      this.Controls.Add((Control) this.numericUpDownMeter);
      this.Controls.Add((Control) this.numericUpDownDistance);
      this.Controls.Add((Control) this.labelCaption);
      this.Controls.Add((Control) this.buttonOK);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (AskDistanceForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.FormClosing += new FormClosingEventHandler(this.AskDistanceForm_FormClosing);
      this.Load += new EventHandler(this.AskDistanceForm_Load);
      this.numericUpDownDistance.EndInit();
      this.numericUpDownMeter.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
