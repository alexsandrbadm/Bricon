// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.PASPage
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.PAS.Basket;
using BriconLib.PAS.BceDatabase;
using BriconLib.PAS.ReadOut;
using BriconLib.Properties;
using MultiLang;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class PASPage : UserControl
  {
    private IContainer components;
    private Panel panel1;
    private Button buttonToPas;
    private ImageList imageList1;
    private Button buttonFromPas;
    private CheckBox checkBoxAlwaysload;
    private CheckBox checkBox1;
    private Button buttonBasket;
    private Button buttonTempReadOut;
    private ImageList imageList2;
    private PictureBox pictureBox1;
    private Button buttonReadOut;

    public PASPage() => this.InitializeComponent();

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) => Process.Start("http://www.pas-live.nl/Register/Register");

    private void buttonTest_Click(object sender, EventArgs e) => new PasDataTester().Test();

    private void buttonToPas_Click(object sender, EventArgs e) => new PasDataSaver().Save(true);

    private void buttonFromPas_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(ml.ml_string(1412, "Warning, this will overwrite all your clubs, fanciers, rings that are linked to the clubs where the login is linked to."), ml.ml_string(1413, "Receive data from PAS-Live"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
        return;
      new PasDataLoader().Load(true);
    }

    private void buttonBasket_Click(object sender, EventArgs e)
    {
      if (this.GetFancierPage().GetActiveClubRow() == null)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1414, "Please select your club."));
      }
      else
        new BasketProcess().Start(this.GetFancierPage().GetActiveClubRow()?.ClubID, this.GetFancierPage().GetActiveClubRow()?.Name);
    }

    private ClubsPage GetFancierPage()
    {
      Control parent = this.Parent;
      while (true)
      {
        switch (parent)
        {
          case MainForm _:
          case null:
            goto label_3;
          default:
            parent = parent.Parent;
            continue;
        }
      }
label_3:
      return parent is MainForm ? (parent as MainForm).clubsPage : (ClubsPage) null;
    }

    private void buttonReadOut_Click(object sender, EventArgs e)
    {
      if (this.GetFancierPage().GetActiveClubRow() == null)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1414, "Please select your club."));
      }
      else
        new ReadOutProcess().Start(this.GetFancierPage().GetActiveClubRow()?.ClubID, this.GetFancierPage().GetActiveClubRow()?.Name, true);
    }

    private void buttonTempReadOut_Click(object sender, EventArgs e)
    {
      if (this.GetFancierPage().GetActiveClubRow() == null)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1414, "Please select your club."));
      }
      else
        new ReadOutProcess().Start(this.GetFancierPage().GetActiveClubRow()?.ClubID, this.GetFancierPage().GetActiveClubRow()?.Name, false);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (PASPage));
      this.panel1 = new Panel();
      this.pictureBox1 = new PictureBox();
      this.buttonToPas = new Button();
      this.imageList1 = new ImageList(this.components);
      this.buttonReadOut = new Button();
      this.imageList2 = new ImageList(this.components);
      this.buttonTempReadOut = new Button();
      this.buttonBasket = new Button();
      this.buttonFromPas = new Button();
      this.checkBox1 = new CheckBox();
      this.checkBoxAlwaysload = new CheckBox();
      this.panel1.SuspendLayout();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.panel1.Controls.Add((Control) this.pictureBox1);
      this.panel1.Controls.Add((Control) this.buttonToPas);
      this.panel1.Controls.Add((Control) this.buttonReadOut);
      this.panel1.Controls.Add((Control) this.buttonTempReadOut);
      this.panel1.Controls.Add((Control) this.buttonBasket);
      this.panel1.Controls.Add((Control) this.buttonFromPas);
      this.panel1.Controls.Add((Control) this.checkBox1);
      this.panel1.Controls.Add((Control) this.checkBoxAlwaysload);
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonToPas, "buttonToPas");
      this.buttonToPas.ImageList = this.imageList1;
      this.buttonToPas.Name = "buttonToPas";
      this.buttonToPas.UseVisualStyleBackColor = true;
      this.buttonToPas.Click += new EventHandler(this.buttonToPas_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Magenta;
      this.imageList1.Images.SetKeyName(0, "FromBA.bmp");
      this.imageList1.Images.SetKeyName(1, "ToBA.bmp");
      componentResourceManager.ApplyResources((object) this.buttonReadOut, "buttonReadOut");
      this.buttonReadOut.ForeColor = SystemColors.ControlText;
      this.buttonReadOut.ImageList = this.imageList2;
      this.buttonReadOut.Name = "buttonReadOut";
      this.buttonReadOut.UseVisualStyleBackColor = true;
      this.buttonReadOut.Click += new EventHandler(this.buttonReadOut_Click);
      this.imageList2.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList2.ImageStream");
      this.imageList2.TransparentColor = Color.Magenta;
      this.imageList2.Images.SetKeyName(0, "MasterActive.bmp");
      componentResourceManager.ApplyResources((object) this.buttonTempReadOut, "buttonTempReadOut");
      this.buttonTempReadOut.ForeColor = SystemColors.ControlText;
      this.buttonTempReadOut.ImageList = this.imageList2;
      this.buttonTempReadOut.Name = "buttonTempReadOut";
      this.buttonTempReadOut.UseVisualStyleBackColor = true;
      this.buttonTempReadOut.Click += new EventHandler(this.buttonTempReadOut_Click);
      componentResourceManager.ApplyResources((object) this.buttonBasket, "buttonBasket");
      this.buttonBasket.ForeColor = SystemColors.ControlText;
      this.buttonBasket.ImageList = this.imageList2;
      this.buttonBasket.Name = "buttonBasket";
      this.buttonBasket.UseVisualStyleBackColor = true;
      this.buttonBasket.Click += new EventHandler(this.buttonBasket_Click);
      componentResourceManager.ApplyResources((object) this.buttonFromPas, "buttonFromPas");
      this.buttonFromPas.ImageList = this.imageList1;
      this.buttonFromPas.Name = "buttonFromPas";
      this.buttonFromPas.UseVisualStyleBackColor = true;
      this.buttonFromPas.Click += new EventHandler(this.buttonFromPas_Click);
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Checked = Settings.Default.PASAlwaysSave;
      this.checkBox1.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "PASAlwaysSave", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this.checkBoxAlwaysload, "checkBoxAlwaysload");
      this.checkBoxAlwaysload.Checked = Settings.Default.PASAlwaysLoad;
      this.checkBoxAlwaysload.DataBindings.Add(new Binding("Checked", (object) Settings.Default, "PASAlwaysLoad", true, DataSourceUpdateMode.OnPropertyChanged));
      this.checkBoxAlwaysload.Name = "checkBoxAlwaysload";
      this.checkBoxAlwaysload.UseVisualStyleBackColor = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.panel1);
      this.Name = nameof (PASPage);
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
