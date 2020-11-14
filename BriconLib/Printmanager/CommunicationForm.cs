// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.CommunicationForm
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Communications;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class CommunicationForm : Form
  {
    public int SecondsRemaining;
    private bool finished;
    private BackgroundWorker _worker = new BackgroundWorker();
    private IContainer components;
    private ImageList imageList1;
    private Label label1;
    public PictureBox pictureBox1;
    public Label labelTime;
    public ProgressBar progressBar;
    private Button buttonCancel;
    private System.Windows.Forms.Timer timerUpdateMessage;

    public CommunicationForm(bool init = true)
    {
      this.InitializeComponent();
      this.pictureBox1.Image = this.imageList1.Images[0];
      this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
      this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
      this._worker.WorkerSupportsCancellation = true;
      this._worker.WorkerReportsProgress = true;
      if (!init)
        return;
      CommunicationPool.Instance.ReInit();
    }

    private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      if (this.finished)
        return;
      if (!CommunicationPool.Instance.AreCommandsPending && !CommunicationState.Instance.WaitingToConnectBA)
      {
        CommunicationState.Instance.GetAndClearCommands();
        CommunicationState.Instance.GetAndClearCommandWithFeedBack();
        CommunicationState.Instance.GetAndClearCompletedCommands();
        this.finished = true;
        this._worker.CancelAsync();
        if (this.OnFinish != null)
        {
          this.timerUpdateMessage.Enabled = true;
          this.buttonCancel.Visible = false;
          this.label1.Text = ml.ml_string(1097, "Checking software version in device...");
          this.label1.Update();
          Thread.Sleep(100);
          this.OnFinish((object) this, (EventArgs) null);
          this.timerUpdateMessage.Enabled = false;
        }
        this.DialogResult = DialogResult.OK;
        this.Close();
      }
      else
        this.HandleCommunicationState(e.UserState as CommunicationState);
    }

    public event EventHandler OnHandleCommand;

    public event EventHandler OnPostCommands;

    public event EventHandler OnFinish;

    private void HandleCommunicationState(CommunicationState state)
    {
      foreach (BriconLib.Communications.Command command in state.GetAndClearCommandWithFeedBack())
      {
        if (this.label1.Text != command.ToString())
        {
          this.label1.Text = command.ToString();
          this.Update();
          Thread.Sleep(100);
        }
        this.OnHandleCommand((object) command, (EventArgs) null);
      }
    }

    private void _worker_DoWork(object sender, DoWorkEventArgs e)
    {
      if (this.OnPostCommands == null)
        this._worker.ReportProgress(0);
      else
        CommunicationPool.Instance.CommunicationsLoop(sender as BackgroundWorker);
    }

    private void buttonCancel_Click(object sender, EventArgs e)
    {
      this._worker.CancelAsync();
      Thread.Sleep(500);
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }

    private void CommunicationForm_Load(object sender, EventArgs e)
    {
      if (this.OnPostCommands != null)
        this.OnPostCommands((object) null, (EventArgs) null);
      this._worker.RunWorkerAsync();
    }

    private void timerUpdateMessage_Tick(object sender, EventArgs e)
    {
      if (this.SecondsRemaining <= 0)
        return;
      this.label1.Text = ml.ml_string(1096, "Loading new software in device, estimated time remaining : ") + this.SecondsRemaining.ToString() + ml.ml_string(1098, " seconds");
      this.label1.Update();
      Thread.Sleep(100);
      --this.SecondsRemaining;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CommunicationForm));
      this.imageList1 = new ImageList(this.components);
      this.pictureBox1 = new PictureBox();
      this.label1 = new Label();
      this.labelTime = new Label();
      this.progressBar = new ProgressBar();
      this.buttonCancel = new Button();
      this.timerUpdateMessage = new System.Windows.Forms.Timer(this.components);
      ((ISupportInitialize) this.pictureBox1).BeginInit();
      this.SuspendLayout();
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "BAActive.bmp");
      this.pictureBox1.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      this.label1.BackColor = Color.Transparent;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this.labelTime, "labelTime");
      this.labelTime.Name = "labelTime";
      componentResourceManager.ApplyResources((object) this.progressBar, "progressBar");
      this.progressBar.Name = "progressBar";
      componentResourceManager.ApplyResources((object) this.buttonCancel, "buttonCancel");
      this.buttonCancel.Name = "buttonCancel";
      this.buttonCancel.UseVisualStyleBackColor = true;
      this.buttonCancel.Click += new EventHandler(this.buttonCancel_Click);
      this.timerUpdateMessage.Interval = 1000;
      this.timerUpdateMessage.Tick += new EventHandler(this.timerUpdateMessage_Tick);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.GradientInactiveCaption;
      this.ControlBox = false;
      this.Controls.Add((Control) this.buttonCancel);
      this.Controls.Add((Control) this.labelTime);
      this.Controls.Add((Control) this.progressBar);
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.pictureBox1);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (CommunicationForm);
      this.ShowIcon = false;
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.Load += new EventHandler(this.CommunicationForm_Load);
      ((ISupportInitialize) this.pictureBox1).EndInit();
      this.ResumeLayout(false);
    }
  }
}
