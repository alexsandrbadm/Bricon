// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.GenerateRingsForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class GenerateRingsForm : Form
  {
    private int _fancierID;
    private IContainer components;
    private Button buttonAdd;
    private Button buttonCancel;
    private ListBox listBoxPreview;
    private Label labelPreview;
    private Label labelCountryCode;
    private TextBox textBoxCountryCode;
    private Label labelYear;
    private NumericUpDown numericUpDownYear;
    private Label labelFrom;
    private TextBox textBoxFrom;
    private Label labelTo;
    private TextBox textBoxTo;
    private Button buttonReplace;
    private Button buttonPreview;

    public GenerateRingsForm(int fancierID)
    {
      this._fancierID = fancierID;
      this.InitializeComponent();
    }

    private void buttonAdd_Click(object sender, EventArgs e)
    {
      if (!this.BuildPreview())
      {
        this.DialogResult = DialogResult.None;
      }
      else
      {
        foreach (string DBRing in this.listBoxPreview.Items)
          BCEDatabase.DataSet.Pigeons.AddPigeonsRow(BCEDatabase.DataSet.Adressen.FindById(this._fancierID), DBRing, "", false, "", 0, false, 0);
      }
    }

    private void GenerateRingsForm_Load(object sender, EventArgs e)
    {
      this.textBoxCountryCode.Text = Settings.Default.Country;
      switch (Validation.RingType)
      {
        case Validation.RingTypes.ShortWithLongCountry:
          this.textBoxCountryCode.Text = Settings.Default.Country;
          this.textBoxCountryCode.MaxLength = 3;
          this.textBoxFrom.MaxLength = 7;
          this.textBoxTo.MaxLength = 7;
          break;
        case Validation.RingTypes.UKRing:
          this.textBoxCountryCode.Text = "    ";
          if (Utils.IsCountry("JP"))
            this.textBoxCountryCode.Text = "  JP";
          this.textBoxCountryCode.MaxLength = 4;
          this.textBoxFrom.MaxLength = 10;
          this.textBoxTo.MaxLength = 10;
          this.textBoxFrom.Text = "000000000";
          this.textBoxTo.Text = "000000000";
          break;
        case Validation.RingTypes.HURing:
          this.textBoxCountryCode.Text = "  HU";
          this.textBoxCountryCode.MaxLength = 4;
          this.textBoxFrom.MaxLength = 10;
          this.textBoxTo.MaxLength = 10;
          this.textBoxFrom.Text = "000000000";
          this.textBoxTo.Text = "000000000";
          break;
      }
      this.numericUpDownYear.Value = (Decimal) (DateTime.Now.Year % 100);
      this.textBoxCountryCode.Focus();
    }

    private void buttonReplace_Click(object sender, EventArgs e)
    {
      if (!this.BuildPreview())
      {
        this.DialogResult = DialogResult.None;
      }
      else
      {
        BCEDatabase.DeletePigeonsForFancier(this._fancierID);
        this.buttonAdd_Click(sender, e);
      }
    }

    private void buttonPreview_Click(object sender, EventArgs e) => this.BuildPreview();

    private bool BuildPreview()
    {
      if (Validation.RingType == Validation.RingTypes.UKRing || Validation.RingType == Validation.RingTypes.HURing)
      {
        while (this.textBoxCountryCode.Text.Length != 4)
          this.textBoxCountryCode.Text = " " + this.textBoxCountryCode.Text;
        while (this.textBoxFrom.Text.Length != 9)
          this.textBoxFrom.Text = " " + this.textBoxFrom.Text;
        while (this.textBoxTo.Text.Length != 9)
          this.textBoxTo.Text = " " + this.textBoxTo.Text;
      }
      string text1 = this.textBoxCountryCode.Text + "-" + this.numericUpDownYear.Value.ToString("00") + "-" + this.textBoxFrom.Text;
      string[] strArray = new string[5]
      {
        this.textBoxCountryCode.Text,
        "-",
        null,
        null,
        null
      };
      Decimal num1 = this.numericUpDownYear.Value;
      strArray[2] = num1.ToString("00");
      strArray[3] = "-";
      strArray[4] = this.textBoxTo.Text;
      string text2 = string.Concat(strArray);
      if (Validation.RingType == Validation.RingTypes.ShortWithLongCountry)
      {
        string text3 = this.textBoxCountryCode.Text;
        num1 = this.numericUpDownYear.Value;
        string str1 = num1.ToString("00");
        string text4 = this.textBoxFrom.Text;
        text1 = text3 + str1 + "-" + text4;
        string text5 = this.textBoxCountryCode.Text;
        num1 = this.numericUpDownYear.Value;
        string str2 = num1.ToString("00");
        string text6 = this.textBoxTo.Text;
        text2 = text5 + str2 + "-" + text6;
      }
      if (text1.Length != text2.Length)
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(212, "Length of the 'From' and 'To' should be the same."), Defines.MessageBoxCaption);
        return false;
      }
      if (text1.Equals(text2))
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(214, "The 'From' and the 'To' should be different from each other."), Defines.MessageBoxCaption);
        return false;
      }
      if (!Validation.DBRing(text1) || !Validation.DBRing(text2))
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(213, "Some of the parameters are incorrect. The generated rings would not be valid."), Defines.MessageBoxCaption);
        return false;
      }
      string str3 = string.Empty;
      char ch;
      for (int index = 0; index < text1.Length && (int) text1[index] == (int) text2[index]; ++index)
      {
        string str1 = str3;
        ch = text1[index];
        string str2 = ch.ToString();
        str3 = str1 + str2;
      }
      string str4 = string.Empty;
      for (int index = text1.Length - 1; index >= 0 && (int) text1[index] == (int) text2[index]; --index)
      {
        ch = text1[index];
        str4 = ch.ToString() + str4;
      }
      string str5 = str4.TrimStart('0', '1', '2', '3', '4', '5', '6', '7', '8', '9');
      string s1 = text1.Substring(str3.Length, text1.Length - str3.Length - str5.Length);
      string s2 = text2.Substring(str3.Length, text2.Length - str3.Length - str5.Length);
      int result1;
      int result2;
      if (!int.TryParse(s1, out result1) || !int.TryParse(s2, out result2))
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(215, "Some of the parameters are incorrect."), Defines.MessageBoxCaption);
        return false;
      }
      if (result1 > result2)
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(216, "The 'From' is bigger then the 'To'."), Defines.MessageBoxCaption);
        return false;
      }
      if (result2 - result1 > 1000)
      {
        int num2 = (int) MessageBox.Show(ml.ml_string(217, "More then 1000 rings would be created, this is to much."), Defines.MessageBoxCaption);
        return false;
      }
      this.listBoxPreview.BeginUpdate();
      this.listBoxPreview.Items.Clear();
      for (; result1 <= result2; ++result1)
      {
        string str1 = result1.ToString();
        while (str1.Length != s1.Length)
          str1 = "0" + str1;
        this.listBoxPreview.Items.Add((object) (str3 + str1 + str5));
      }
      this.listBoxPreview.EndUpdate();
      return true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (GenerateRingsForm));
      this.buttonAdd = new Button();
      this.buttonCancel = new Button();
      this.listBoxPreview = new ListBox();
      this.labelPreview = new Label();
      this.labelCountryCode = new Label();
      this.textBoxCountryCode = new TextBox();
      this.labelYear = new Label();
      this.numericUpDownYear = new NumericUpDown();
      this.labelFrom = new Label();
      this.textBoxFrom = new TextBox();
      this.labelTo = new Label();
      this.textBoxTo = new TextBox();
      this.buttonReplace = new Button();
      this.buttonPreview = new Button();
      this.numericUpDownYear.BeginInit();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonAdd, "buttonAdd");
      this.buttonAdd.DialogResult = DialogResult.OK;
      this.buttonAdd.Name = "buttonAdd";
      this.buttonAdd.UseVisualStyleBackColor = true;
      this.buttonAdd.Click += new EventHandler(this.buttonAdd_Click);
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.DialogResult = DialogResult.Cancel;
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.listBoxPreview, "listBoxPreview");
      this.listBoxPreview.FormattingEnabled = true;
      this.listBoxPreview.Name = "listBoxPreview";
      componentResourceManager.ApplyResources((object) this.labelPreview, "labelPreview");
      this.labelPreview.Name = "labelPreview";
      componentResourceManager.ApplyResources((object) this.labelCountryCode, "labelCountryCode");
      this.labelCountryCode.Name = "labelCountryCode";
      componentResourceManager.ApplyResources((object) this.textBoxCountryCode, "textBoxCountryCode");
      this.textBoxCountryCode.Name = "textBoxCountryCode";
      componentResourceManager.ApplyResources((object) this.labelYear, "labelYear");
      this.labelYear.Name = "labelYear";
      componentResourceManager.ApplyResources((object) this.numericUpDownYear, "numericUpDownYear");
      this.numericUpDownYear.Maximum = new Decimal(new int[4]
      {
        99,
        0,
        0,
        0
      });
      this.numericUpDownYear.Name = "numericUpDownYear";
      componentResourceManager.ApplyResources((object) this.labelFrom, "labelFrom");
      this.labelFrom.Name = "labelFrom";
      componentResourceManager.ApplyResources((object) this.textBoxFrom, "textBoxFrom");
      this.textBoxFrom.Name = "textBoxFrom";
      componentResourceManager.ApplyResources((object) this.labelTo, "labelTo");
      this.labelTo.Name = "labelTo";
      componentResourceManager.ApplyResources((object) this.textBoxTo, "textBoxTo");
      this.textBoxTo.Name = "textBoxTo";
      componentResourceManager.ApplyResources((object) this.buttonReplace, "buttonReplace");
      this.buttonReplace.DialogResult = DialogResult.OK;
      this.buttonReplace.Name = "buttonReplace";
      this.buttonReplace.UseVisualStyleBackColor = true;
      this.buttonReplace.Click += new EventHandler(this.buttonReplace_Click);
      componentResourceManager.ApplyResources((object) this.buttonPreview, "buttonPreview");
      this.buttonPreview.Name = "buttonPreview";
      this.buttonPreview.UseVisualStyleBackColor = true;
      this.buttonPreview.Click += new EventHandler(this.buttonPreview_Click);
      this.AcceptButton = (IButtonControl) this.buttonAdd;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonCancel;
      this.Controls.Add((Control) this.buttonPreview);
      this.Controls.Add((Control) this.numericUpDownYear);
      this.Controls.Add((Control) this.labelYear);
      this.Controls.Add((Control) this.textBoxTo);
      this.Controls.Add((Control) this.labelTo);
      this.Controls.Add((Control) this.textBoxFrom);
      this.Controls.Add((Control) this.labelFrom);
      this.Controls.Add((Control) this.textBoxCountryCode);
      this.Controls.Add((Control) this.labelCountryCode);
      this.Controls.Add((Control) this.labelPreview);
      this.Controls.Add((Control) this.listBoxPreview);
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.buttonReplace);
      this.Controls.Add((Control) this.buttonAdd);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (GenerateRingsForm);
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Load += new EventHandler(this.GenerateRingsForm_Load);
      this.numericUpDownYear.EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
