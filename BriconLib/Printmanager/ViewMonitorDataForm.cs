// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.ViewMonitorDataForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class ViewMonitorDataForm : Form
  {
    private IContainer components;
    private GroupBox groupBox1;
    private TextBox textBox2;
    private Label label2;
    private TextBox textBox1;
    private Label label1;
    private TextBox textBox6;
    private TextBox textBox3;
    private Label label4;
    private Label label3;
    private TextBox textBox5;
    private TextBox textBox4;
    private GroupBox groupBox2;
    private Label label8;
    private Label label6;
    private Label label7;
    private Label label5;
    private GroupBox groupBox3;
    private Button button1;
    private DataGridView dataGridView1;
    private DataGridViewTextBoxColumn DBRing;
    private DataGridViewTextBoxColumn ELRing;
    private DataGridViewTextBoxColumn Clockedtime;
    private Button button2;
    private Button button3;

    public ViewMonitorDataForm() => this.InitializeComponent();

    private void button1_Click(object sender, EventArgs e)
    {
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ViewMonitorDataForm));
      this.groupBox1 = new GroupBox();
      this.textBox6 = new TextBox();
      this.textBox3 = new TextBox();
      this.label4 = new Label();
      this.label3 = new Label();
      this.textBox5 = new TextBox();
      this.textBox4 = new TextBox();
      this.textBox2 = new TextBox();
      this.label2 = new Label();
      this.textBox1 = new TextBox();
      this.label1 = new Label();
      this.groupBox2 = new GroupBox();
      this.label8 = new Label();
      this.label6 = new Label();
      this.label7 = new Label();
      this.label5 = new Label();
      this.groupBox3 = new GroupBox();
      this.dataGridView1 = new DataGridView();
      this.DBRing = new DataGridViewTextBoxColumn();
      this.ELRing = new DataGridViewTextBoxColumn();
      this.Clockedtime = new DataGridViewTextBoxColumn();
      this.button1 = new Button();
      this.button2 = new Button();
      this.button3 = new Button();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox3.SuspendLayout();
      ((ISupportInitialize) this.dataGridView1).BeginInit();
      this.SuspendLayout();
      this.groupBox1.Controls.Add((Control) this.textBox6);
      this.groupBox1.Controls.Add((Control) this.textBox3);
      this.groupBox1.Controls.Add((Control) this.label4);
      this.groupBox1.Controls.Add((Control) this.label3);
      this.groupBox1.Controls.Add((Control) this.textBox5);
      this.groupBox1.Controls.Add((Control) this.textBox4);
      this.groupBox1.Controls.Add((Control) this.textBox2);
      this.groupBox1.Controls.Add((Control) this.label2);
      this.groupBox1.Controls.Add((Control) this.textBox1);
      this.groupBox1.Controls.Add((Control) this.label1);
      componentResourceManager.ApplyResources((object) this.groupBox1, "groupBox1");
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.textBox6, "textBox6");
      this.textBox6.Name = "textBox6";
      this.textBox6.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.textBox3, "textBox3");
      this.textBox3.Name = "textBox3";
      this.textBox3.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.label4, "label4");
      this.label4.Name = "label4";
      componentResourceManager.ApplyResources((object) this.label3, "label3");
      this.label3.Name = "label3";
      componentResourceManager.ApplyResources((object) this.textBox5, "textBox5");
      this.textBox5.Name = "textBox5";
      this.textBox5.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.textBox4, "textBox4");
      this.textBox4.Name = "textBox4";
      this.textBox4.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.textBox2, "textBox2");
      this.textBox2.Name = "textBox2";
      this.textBox2.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.label2, "label2");
      this.label2.Name = "label2";
      componentResourceManager.ApplyResources((object) this.textBox1, "textBox1");
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      this.groupBox2.Controls.Add((Control) this.label8);
      this.groupBox2.Controls.Add((Control) this.label6);
      this.groupBox2.Controls.Add((Control) this.label7);
      this.groupBox2.Controls.Add((Control) this.label5);
      componentResourceManager.ApplyResources((object) this.groupBox2, "groupBox2");
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      componentResourceManager.ApplyResources((object) this.label8, "label8");
      this.label8.Name = "label8";
      componentResourceManager.ApplyResources((object) this.label6, "label6");
      this.label6.Name = "label6";
      componentResourceManager.ApplyResources((object) this.label7, "label7");
      this.label7.Name = "label7";
      componentResourceManager.ApplyResources((object) this.label5, "label5");
      this.label5.Name = "label5";
      this.groupBox3.Controls.Add((Control) this.dataGridView1);
      componentResourceManager.ApplyResources((object) this.groupBox3, "groupBox3");
      this.groupBox3.Name = "groupBox3";
      this.groupBox3.TabStop = false;
      componentResourceManager.ApplyResources((object) this.dataGridView1, "dataGridView1");
      this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.Columns.AddRange((DataGridViewColumn) this.DBRing, (DataGridViewColumn) this.ELRing, (DataGridViewColumn) this.Clockedtime);
      this.dataGridView1.Name = "dataGridView1";
      componentResourceManager.ApplyResources((object) this.DBRing, "DBRing");
      this.DBRing.Name = "DBRing";
      componentResourceManager.ApplyResources((object) this.ELRing, "ELRing");
      this.ELRing.Name = "ELRing";
      componentResourceManager.ApplyResources((object) this.Clockedtime, "Clockedtime");
      this.Clockedtime.Name = "Clockedtime";
      this.button1.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.button1_Click);
      this.button2.DialogResult = DialogResult.Cancel;
      componentResourceManager.ApplyResources((object) this.button2, "button2");
      this.button2.Name = "button2";
      this.button2.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.button3, "button3");
      this.button3.Name = "button3";
      this.button3.UseVisualStyleBackColor = true;
      this.button3.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.button1;
      this.Controls.Add((Control) this.button2);
      this.Controls.Add((Control) this.button3);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.groupBox3);
      this.Controls.Add((Control) this.groupBox2);
      this.Controls.Add((Control) this.groupBox1);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ViewMonitorDataForm);
      this.ShowInTaskbar = false;
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.groupBox3.ResumeLayout(false);
      ((ISupportInitialize) this.dataGridView1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
