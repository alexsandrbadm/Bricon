// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.PrintHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using BriconLib.Printing;
using BriconLib.Properties;
using BriconLib.Updater;
using Microsoft.Reporting.WinForms;
using MultiLang;
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.PrintManager
{
  public class PrintHelper
  {
    public static void Printlist(ReadOutDataSet readout, string reportName)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        PrintPreviewForm printPreviewForm = new PrintPreviewForm();
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Fancier", (DataTable) readout.Fancier));
        if (reportName.Equals("BasketingList", StringComparison.InvariantCultureIgnoreCase))
        {
          DataRow[] dataRowArray = readout.Pigeons.Select("Evaluation = '2' or Evaluation = '4' or Evaluation = '1' or Evaluation = '!'", "FlightID, Evaluation, Time");
          string str = "aa";
          int num2 = 1;
          foreach (ReadOutDataSet.PigeonsRow pigeonsRow in dataRowArray)
          {
            if (pigeonsRow.FlightID != str)
            {
              str = pigeonsRow.FlightID;
              num2 = 1;
            }
            if (pigeonsRow.Evaluation == "1")
            {
              pigeonsRow.Nr = num2.ToString();
              ++num2;
            }
            else
              pigeonsRow.Nr = "-";
          }
          printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Pigeons", (IEnumerable) dataRowArray));
        }
        else if (reportName.Equals("MonitorList", StringComparison.InvariantCultureIgnoreCase))
          printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Pigeons", (DataTable) readout.PigeonsMonitor));
        else
          printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Pigeons", (DataTable) readout.Pigeons));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Timers", (DataTable) readout.Timers));
        printPreviewForm.reportViewer.LocalReport.ReportEmbeddedResource = !Settings.Default.Language.Equals("en", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("fr", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("hu", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("uk", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ja", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.PrintManager.Reports." + reportName + "EN.rdlc" : "BriconLib.PrintManager.Reports." + reportName + "JA.rdlc") : "BriconLib.PrintManager.Reports." + reportName + "UK.rdlc") : "BriconLib.PrintManager.Reports." + reportName + "HU.rdlc") : "BriconLib.PrintManager.Reports." + reportName + "NL.rdlc") : "BriconLib.PrintManager.Reports." + reportName + "FR.rdlc") : "BriconLib.PrintManager.Reports." + reportName + "EN.rdlc";
        printPreviewForm.reportViewer.Visible = false;
        int num3 = (int) printPreviewForm.ShowDialog();
      }
    }

    public static void PrintBetForm(ReadOutDataSet readout)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        PrintPreviewForm printPreviewForm1 = new PrintPreviewForm();
        printPreviewForm1.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Fancier", (DataTable) readout.Fancier));
        foreach (ReadOutDataSet.PigeonsRow pigeon in (TypedTableBase<ReadOutDataSet.PigeonsRow>) readout.Pigeons)
        {
          if (pigeon.IsPosition1Null())
            pigeon.Position1 = 50000;
          if (pigeon.IsPosition2Null())
            pigeon.Position2 = 50000;
          if (pigeon.IsPosition3Null())
            pigeon.Position3 = 50000;
          if (pigeon.IsPosition4Null())
            pigeon.Position4 = 50000;
        }
        DataRow[] dataRowArray = readout.Pigeons.Select("((Position1 > 0 and Position1 < 50000) or (Position2 > 0 and Position2 < 50000) or (Position3 > 0 and Position3 < 50000)) and Evaluation = '0'", "Position1 ASC, Position2 ASC, Position3 ASC");
        printPreviewForm1.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Pigeons", (IEnumerable) dataRowArray));
        printPreviewForm1.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Timers", (DataTable) readout.Timers));
        printPreviewForm1.reportViewer.LocalReport.ReportEmbeddedResource = !Utils.IsCountry("BE") ? (!Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.PrintManager.Reports.DesignatedListNL.rdlc" : "BriconLib.PrintManager.Reports.DesignatedListNL.rdlc") : (!Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.PrintManager.Reports.DesignatedListNL-BE.rdlc" : "BriconLib.PrintManager.Reports.DesignatedListNL-BE.rdlc");
        printPreviewForm1.reportViewer.Visible = false;
        int num2 = (int) printPreviewForm1.ShowDialog();
        if (Utils.IsCountry("NL"))
        {
          PrintPreviewForm printPreviewForm2 = new PrintPreviewForm();
          printPreviewForm2.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_Fancier", (DataTable) readout.Fancier));
          printPreviewForm2.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ReadOutDataSet_PoulLetter", (DataTable) readout.PoulLetter));
          printPreviewForm2.reportViewer.LocalReport.ReportEmbeddedResource = "BriconLib.PrintManager.Reports.PoulletterNL.rdlc";
          printPreviewForm2.reportViewer.Visible = false;
          int num3 = (int) printPreviewForm2.ShowDialog();
        }
        foreach (ReadOutDataSet.PigeonsRow pigeon in (TypedTableBase<ReadOutDataSet.PigeonsRow>) readout.Pigeons)
        {
          if (pigeon.Position1 == 50000)
            pigeon.SetPosition1Null();
          if (pigeon.Position2 == 50000)
            pigeon.SetPosition2Null();
          if (pigeon.Position3 == 50000)
            pigeon.SetPosition3Null();
          if (pigeon.Position4 == 50000)
            pigeon.SetPosition4Null();
        }
      }
    }
  }
}
