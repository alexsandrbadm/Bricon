// Decompiled with JetBrains decompiler
// Type: BriconLib.Printmanager.MainFormPM
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BriconWeb;
using BriconLib.Communications;
using BriconLib.Data;
using BriconLib.Other;
using BriconLib.PrintManager;
using BriconLib.Properties;
using BriconLib.Updater;
using MultiLang;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace BriconLib.Printmanager
{
  public class MainFormPM : Form
  {
    private string _folder;
    private string _extension = ".rdo";
    private IContainer components;
    private Button buttonOptions;
    private Button buttonExit;
    private Button buttonAbout;
    private Button buttonReadOut;
    private ListView listView1;
    private Button buttonOverViewList;
    private Button buttonViewData;
    private ImageList imageList1;
    private Button buttonTraining;
    private Button buttonPigeonsList;
    private Button buttonBasketingList;
    private Button buttonName;
    private Button buttonDelete;
    private Button buttonMonitor;
    private Button buttonBetMoney;
    private Button buttonSendToBC;
    private Button buttonArriveNotifier;
    private Button button1;

    public MainFormPM()
    {
      if (!Settings.Default.Version.Equals(Assembly.GetEntryAssembly().GetName().Version.ToString()))
      {
        Settings.Default.Upgrade();
        Settings.Default.Version = Assembly.GetEntryAssembly().GetName().Version.ToString();
      }
      this.AdjustLanguage();
      PrerequisitesInstall.InstallIfNeeded();
      string path = Application.UserAppDataPath + "\\..\\ReadOuts\\";
      this._folder = "c:\\ReadOuts\\Printmanager\\";
      if (!Directory.Exists("c:\\ReadOuts"))
        Directory.CreateDirectory(this._folder);
      if (!Directory.Exists(this._folder))
      {
        Directory.CreateDirectory(this._folder);
        foreach (string file in Directory.GetFiles(path))
          File.Move(file, Path.Combine(this._folder, Path.GetFileName(file)));
      }
      UpdateCheckingThread.Start(false);
      foreach (string file in Directory.GetFiles(this._folder, "ReadOut *" + this._extension))
        File.Move(file, file.Replace("\\ReadOut ", "\\"));
      this.InitializeComponent();
      this.RefreshFileList();
      if (Utils.IsCountry("UA") || Utils.IsCountry("RU"))
        this.buttonMonitor.Visible = false;
      if (!Utils.IsCountry("BE") && !Utils.IsCountry("FR") && !Utils.IsCountry("NL"))
        this.buttonBetMoney.Visible = false;
      if (Utils.IsCountry("NL"))
        this.buttonBetMoney.Text = ml.ml_string(1394, "    Aanwijzen en Poelen");
      string str = "      ";
      this.buttonReadOut.Text = "    " + this.buttonReadOut.Text.Trim();
      this.buttonMonitor.Text = "    " + this.buttonMonitor.Text.Trim();
      this.buttonExit.Text = "    " + this.buttonExit.Text.Trim();
      this.buttonAbout.Text = str + this.buttonAbout.Text.Trim();
      this.buttonBasketingList.Text = str + this.buttonBasketingList.Text.Trim();
      this.buttonDelete.Text = str + this.buttonDelete.Text.Trim();
      this.buttonName.Text = str + this.buttonName.Text.Trim();
      this.buttonOptions.Text = str + this.buttonOptions.Text.Trim();
      this.buttonOverViewList.Text = str + this.buttonOverViewList.Text.Trim();
      this.buttonPigeonsList.Text = str + this.buttonPigeonsList.Text.Trim();
      this.buttonTraining.Text = str + this.buttonTraining.Text.Trim();
      this.buttonViewData.Text = str + this.buttonViewData.Text.Trim();
      if (Utils.IsCountry("BE"))
        return;
      this.buttonArriveNotifier.Visible = false;
    }

    private void AdjustLanguage()
    {
      try
      {
        if (Settings.Default.Language == "Auto")
        {
          Settings.Default.Language = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
          Settings.Default.Save();
        }
        if (Settings.Default.Country == "Auto")
        {
          if (CultureInfo.CurrentCulture.Name.Length >= 5)
            Settings.Default.Country = CultureInfo.CurrentCulture.Name.Substring(3, 2);
          int num = (int) MessageBox.Show(ml.ml_string(1102, "Please verify your country and language in the options"), ml.ml_string(1103, "Country/Language"));
        }
        if (!(Settings.Default.Language != "Auto"))
          return;
        Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.Language);
      }
      catch (Exception ex)
      {
        Settings.Default.Language = "Auto";
        Settings.Default.Save();
      }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
    }

    private void buttonReadOut_Click(object sender, EventArgs e)
    {
      ReadOutDataSet readOutDataSet = new FancierReadOut().ReadOut(false);
      if (readOutDataSet == null)
        return;
      string fileName = this._folder + DateTime.Now.ToString("yyyy-MM-dd HHmm") + this._extension;
      readOutDataSet.WriteXml(fileName);
      this.RefreshFileList();
      if (!Settings.Default.BCSendAutomatic || string.IsNullOrWhiteSpace(Settings.Default.LoginBriconWeb) || string.IsNullOrWhiteSpace(Settings.Default.PasswordBriconWeb))
        return;
      BriconWebHelper.SendPmReadOut(fileName);
    }

    private void RefreshFileList()
    {
      this.listView1.Clear();
      foreach (string file in Directory.GetFiles(this._folder, "*" + this._extension))
        this.listView1.Items.Add(Path.GetFileNameWithoutExtension(file)).ImageIndex = 0;
      this.listView1.SelectedItems.Clear();
      if (this.listView1.Items.Count > 0)
        this.listView1.SelectedIndices.Add(this.listView1.Items.Count - 1);
      this.EnableButtons();
    }

    private void buttonExit_Click(object sender, EventArgs e) => this.Close();

    private void buttonViewData_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
      {
        int num = (int) new ViewDataForm(this._folder + selectedItem.Text + this._extension).ShowDialog();
      }
    }

    private void button1_Click(object sender, EventArgs e)
    {
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
      {
        ReadOutDataSet readout = new ReadOutDataSet();
        string str = this._folder + selectedItem.Text + this._extension;
        if (!File.ReadAllText(str).StartsWith("<"))
        {
          BCEDatabase.DecryptFile(str, str + "xml");
          int num = (int) readout.ReadXml(str + "xml");
          File.Delete(str + "xml");
        }
        else
        {
          int num1 = (int) readout.ReadXml(str);
        }
        PrintHelper.Printlist(readout, (sender as Button).Tag as string);
      }
    }

    private void buttonAbout_Click(object sender, EventArgs e) => SplashForm.ShowSplash();

    private void buttonOptions_Click(object sender, EventArgs e)
    {
      Settings.Default.Save();
      if (new OptionsForm().ShowDialog() == DialogResult.OK)
        Settings.Default.Save();
      else
        Settings.Default.Reload();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      CommunicationPool.Instance.Stop();
      UpdateCheckingThread.Stop();
      Settings.Default.Save();
    }

    private void EnableButtons()
    {
      bool flag = this.listView1.SelectedItems.Count > 0;
      this.buttonDelete.Enabled = flag;
      this.buttonName.Enabled = flag;
      this.buttonOverViewList.Enabled = flag;
      this.buttonPigeonsList.Enabled = flag;
      this.buttonBasketingList.Enabled = flag;
      this.buttonTraining.Enabled = flag;
    }

    private void buttonDelete_Click(object sender, EventArgs e)
    {
      if (MessageBox.Show(ml.ml_string(455, "This will delete the selected ReadOut, are you sure?"), ml.ml_string(23, "Delete"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Cancel)
        return;
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
        File.Delete(this._folder + selectedItem.Text + this._extension);
      this.RefreshFileList();
    }

    private void buttonName_Click(object sender, EventArgs e)
    {
      DescriptionForm descriptionForm = new DescriptionForm();
      string text = this.listView1.SelectedItems[0].Text;
      if (text.Length > 15)
        descriptionForm.textBoxDescription.Text = text.Substring(16);
      else
        descriptionForm.textBoxDescription.Text = text.Substring(15);
      if (descriptionForm.ShowDialog() == DialogResult.OK)
      {
        try
        {
          string str = "";
          if (descriptionForm.textBoxDescription.Text.Length > 0)
            str = "-" + descriptionForm.textBoxDescription.Text;
          File.Move(this._folder + text + this._extension, this._folder + text.Substring(0, 15) + str + this._extension);
        }
        catch (Exception ex)
        {
          int num = (int) MessageBox.Show(ml.ml_string(456, "Could not change description (probably duplicate file, invalid characters in description or read only)"), ml.ml_string(457, "Description"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }
      }
      this.RefreshFileList();
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e) => this.EnableButtons();

    private void buttonMonitor_Click(object sender, EventArgs e)
    {
      if (Settings.Default.Country == "Auto")
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1104, "Please first select your country in the options"));
      }
      else
      {
        int num2 = (int) new MonitorForm().ShowDialog();
      }
    }

    private void buttonBetMoney_Click(object sender, EventArgs e) => new PoulLetter().DoIt();

    private void buttonSendToBC_Click(object sender, EventArgs e)
    {
      string text = "";
      foreach (ListViewItem selectedItem in this.listView1.SelectedItems)
      {
        string fileName = this._folder + selectedItem.Text + this._extension;
        text += BriconWebHelper.SendPmReadOut(fileName);
      }
      int num = (int) MessageBox.Show(text);
    }

    private void buttonArriveNotifier_Click(object sender, EventArgs e)
    {
      if (Process.GetProcessesByName("ArriveNotifier").Length != 0)
      {
        int num = (int) MessageBox.Show(ml.ml_string(1395, "Bricon Aankomst Melder is reeds aktief, dubbelklik op het wit duifje links onderaan naast de tijd om deze te tonen."));
      }
      else
      {
        Directory.SetCurrentDirectory(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\ArriveNotifier\\");
        Process.Start("ArriveNotifier.exe");
      }
    }

    private void buttonTestXtreme_Click(object sender, EventArgs e) => new TestXtreme().DoIt();

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (MainFormPM));
      this.buttonOptions = new Button();
      this.imageList1 = new ImageList(this.components);
      this.buttonExit = new Button();
      this.buttonAbout = new Button();
      this.buttonReadOut = new Button();
      this.listView1 = new ListView();
      this.buttonOverViewList = new Button();
      this.buttonViewData = new Button();
      this.buttonTraining = new Button();
      this.buttonPigeonsList = new Button();
      this.buttonBasketingList = new Button();
      this.buttonName = new Button();
      this.buttonDelete = new Button();
      this.buttonMonitor = new Button();
      this.buttonBetMoney = new Button();
      this.buttonSendToBC = new Button();
      this.buttonArriveNotifier = new Button();
      this.button1 = new Button();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonOptions, "buttonOptions");
      this.buttonOptions.ImageList = this.imageList1;
      this.buttonOptions.Name = "buttonOptions";
      this.buttonOptions.UseVisualStyleBackColor = true;
      this.buttonOptions.Click += new EventHandler(this.buttonOptions_Click);
      this.imageList1.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageList1.ImageStream");
      this.imageList1.TransparentColor = Color.Fuchsia;
      this.imageList1.Images.SetKeyName(0, "FromBA.bmp");
      this.imageList1.Images.SetKeyName(1, "Delete.bmp");
      this.imageList1.Images.SetKeyName(2, "EditInformation.bmp");
      this.imageList1.Images.SetKeyName(3, "Properties.bmp");
      this.imageList1.Images.SetKeyName(4, "Help.bmp");
      this.imageList1.Images.SetKeyName(5, "Print.bmp");
      this.imageList1.Images.SetKeyName(6, "CriticalError.bmp");
      this.imageList1.Images.SetKeyName(7, "AutoLoad.bmp");
      componentResourceManager.ApplyResources((object) this.buttonExit, "buttonExit");
      this.buttonExit.DialogResult = DialogResult.Cancel;
      this.buttonExit.ImageList = this.imageList1;
      this.buttonExit.Name = "buttonExit";
      this.buttonExit.UseVisualStyleBackColor = true;
      this.buttonExit.Click += new EventHandler(this.buttonExit_Click);
      componentResourceManager.ApplyResources((object) this.buttonAbout, "buttonAbout");
      this.buttonAbout.ImageList = this.imageList1;
      this.buttonAbout.Name = "buttonAbout";
      this.buttonAbout.UseVisualStyleBackColor = true;
      this.buttonAbout.Click += new EventHandler(this.buttonAbout_Click);
      componentResourceManager.ApplyResources((object) this.buttonReadOut, "buttonReadOut");
      this.buttonReadOut.ImageList = this.imageList1;
      this.buttonReadOut.Name = "buttonReadOut";
      this.buttonReadOut.UseVisualStyleBackColor = true;
      this.buttonReadOut.Click += new EventHandler(this.buttonReadOut_Click);
      componentResourceManager.ApplyResources((object) this.listView1, "listView1");
      this.listView1.FullRowSelect = true;
      this.listView1.HideSelection = false;
      this.listView1.Items.AddRange(new ListViewItem[1]
      {
        (ListViewItem) componentResourceManager.GetObject("listView1.Items")
      });
      this.listView1.MultiSelect = false;
      this.listView1.Name = "listView1";
      this.listView1.SmallImageList = this.imageList1;
      this.listView1.UseCompatibleStateImageBehavior = false;
      this.listView1.View = View.List;
      this.listView1.SelectedIndexChanged += new EventHandler(this.listView1_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.buttonOverViewList, "buttonOverViewList");
      this.buttonOverViewList.ImageList = this.imageList1;
      this.buttonOverViewList.Name = "buttonOverViewList";
      this.buttonOverViewList.Tag = (object) "OverViewList";
      this.buttonOverViewList.UseVisualStyleBackColor = true;
      this.buttonOverViewList.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.buttonViewData, "buttonViewData");
      this.buttonViewData.Name = "buttonViewData";
      this.buttonViewData.UseVisualStyleBackColor = true;
      this.buttonViewData.Click += new EventHandler(this.buttonViewData_Click);
      componentResourceManager.ApplyResources((object) this.buttonTraining, "buttonTraining");
      this.buttonTraining.ImageList = this.imageList1;
      this.buttonTraining.Name = "buttonTraining";
      this.buttonTraining.Tag = (object) "TrainingList";
      this.buttonTraining.UseVisualStyleBackColor = true;
      this.buttonTraining.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.buttonPigeonsList, "buttonPigeonsList");
      this.buttonPigeonsList.ImageList = this.imageList1;
      this.buttonPigeonsList.Name = "buttonPigeonsList";
      this.buttonPigeonsList.Tag = (object) "PigeonList";
      this.buttonPigeonsList.UseVisualStyleBackColor = true;
      this.buttonPigeonsList.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.buttonBasketingList, "buttonBasketingList");
      this.buttonBasketingList.ImageList = this.imageList1;
      this.buttonBasketingList.Name = "buttonBasketingList";
      this.buttonBasketingList.Tag = (object) "BasketingList";
      this.buttonBasketingList.UseVisualStyleBackColor = true;
      this.buttonBasketingList.Click += new EventHandler(this.button1_Click);
      componentResourceManager.ApplyResources((object) this.buttonName, "buttonName");
      this.buttonName.ImageList = this.imageList1;
      this.buttonName.Name = "buttonName";
      this.buttonName.UseVisualStyleBackColor = true;
      this.buttonName.Click += new EventHandler(this.buttonName_Click);
      componentResourceManager.ApplyResources((object) this.buttonDelete, "buttonDelete");
      this.buttonDelete.ImageList = this.imageList1;
      this.buttonDelete.Name = "buttonDelete";
      this.buttonDelete.UseVisualStyleBackColor = true;
      this.buttonDelete.Click += new EventHandler(this.buttonDelete_Click);
      componentResourceManager.ApplyResources((object) this.buttonMonitor, "buttonMonitor");
      this.buttonMonitor.ImageList = this.imageList1;
      this.buttonMonitor.Name = "buttonMonitor";
      this.buttonMonitor.UseVisualStyleBackColor = true;
      this.buttonMonitor.Click += new EventHandler(this.buttonMonitor_Click);
      componentResourceManager.ApplyResources((object) this.buttonBetMoney, "buttonBetMoney");
      this.buttonBetMoney.ImageList = this.imageList1;
      this.buttonBetMoney.Name = "buttonBetMoney";
      this.buttonBetMoney.Tag = (object) "";
      this.buttonBetMoney.UseVisualStyleBackColor = true;
      this.buttonBetMoney.Click += new EventHandler(this.buttonBetMoney_Click);
      componentResourceManager.ApplyResources((object) this.buttonSendToBC, "buttonSendToBC");
      this.buttonSendToBC.ImageList = this.imageList1;
      this.buttonSendToBC.Name = "buttonSendToBC";
      this.buttonSendToBC.Tag = (object) "";
      this.buttonSendToBC.UseVisualStyleBackColor = true;
      this.buttonSendToBC.Click += new EventHandler(this.buttonSendToBC_Click);
      componentResourceManager.ApplyResources((object) this.buttonArriveNotifier, "buttonArriveNotifier");
      this.buttonArriveNotifier.ImageList = this.imageList1;
      this.buttonArriveNotifier.Name = "buttonArriveNotifier";
      this.buttonArriveNotifier.UseVisualStyleBackColor = true;
      this.buttonArriveNotifier.Click += new EventHandler(this.buttonArriveNotifier_Click);
      componentResourceManager.ApplyResources((object) this.button1, "button1");
      this.button1.ImageList = this.imageList1;
      this.button1.Name = "button1";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new EventHandler(this.buttonTestXtreme_Click);
      this.AcceptButton = (IButtonControl) this.buttonReadOut;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.None;
      this.BackgroundImage = (Image) Resources.BackGroundPM;
      this.CancelButton = (IButtonControl) this.buttonExit;
      this.Controls.Add((Control) this.buttonArriveNotifier);
      this.Controls.Add((Control) this.buttonDelete);
      this.Controls.Add((Control) this.buttonName);
      this.Controls.Add((Control) this.buttonViewData);
      this.Controls.Add((Control) this.buttonBasketingList);
      this.Controls.Add((Control) this.buttonSendToBC);
      this.Controls.Add((Control) this.buttonPigeonsList);
      this.Controls.Add((Control) this.buttonTraining);
      this.Controls.Add((Control) this.buttonBetMoney);
      this.Controls.Add((Control) this.buttonOverViewList);
      this.Controls.Add((Control) this.listView1);
      this.Controls.Add((Control) this.buttonExit);
      this.Controls.Add((Control) this.buttonAbout);
      this.Controls.Add((Control) this.buttonMonitor);
      this.Controls.Add((Control) this.buttonReadOut);
      this.Controls.Add((Control) this.button1);
      this.Controls.Add((Control) this.buttonOptions);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (MainFormPM);
      this.FormClosing += new FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new EventHandler(this.MainForm_Load);
      this.ResumeLayout(false);
    }
  }
}
