// Decompiled with JetBrains decompiler
// Type: BriconLib.UI.LoadingMasterForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BriconLib.UI
{
  public class LoadingMasterForm : Form
  {
    private IContainer components;
    private ImageList imageList1;
    private Timer timer1;
    public PictureBox pictureBox1;
    public Label labelTime;
    public ProgressBar progressBar;
    public Label labelText;

    public LoadingMasterForm()
    {
      this.InitializeComponent();
      this.pictureBox1.Image = this.imageList1.Images[0];
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (LoadingMasterForm));
      this.imageList1 = new ImageList(this.components);
      this.pictureBox1 = new PictureBox();
      this.labelText = new Label();
      this.timer1 = new Timer(this.components);
      this.labelTime = new Label();
      this.progressBar = new ProgressBar();
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "Clubmaster9740.jpg");
      this.imageList1.Images.SetKeyName(1, "MasterActive.bmp");
      this.pictureBox1.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      this.labelText.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.labelText, "labelText");
      this.labelText.Name = "labelText";
      this.timer1.Enabled = true;
      this.timer1.Interval = 1000;
      componentResourceManager.ApplyResources((object) this.labelTime, "labelTime");
      this.labelTime.Name = "labelTime";
      componentResourceManager.ApplyResources((object) this.progressBar, "progressBar");
      this.progressBar.Name = "progressBar";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.GradientInactiveCaption;
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelTime);
      this.Controls.Add((Control) this.progressBar);
      this.Controls.Add((Control) this.labelText);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (LoadingMasterForm);
      this.ShowIcon = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
