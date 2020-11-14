// Decompiled with JetBrains decompiler
// Type: BriconLib.Printing.PrintHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using BriconLib.Other;
using BriconLib.Properties;
using BriconLib.Updater;
using Microsoft.Reporting.WinForms;
using MultiLang;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace BriconLib.Printing
{
  public class PrintHelper
  {
    private static PrintDialog _printDialog;

    public static void SelectPrinter()
    {
      if (PrintHelper._printDialog != null)
        return;
      PrintHelper._printDialog = new PrintDialog();
      int num = (int) PrintHelper._printDialog.ShowDialog();
    }

    public static void PrintBasketingList(ClubPrinterDataSet data)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        LocalReport report = new LocalReport();
        report.DataSources.Add(new ReportDataSource("ClubPrinterDataSet_Settings", (DataTable) data.Settings));
        report.DataSources.Add(new ReportDataSource("ClubPrinterDataSet_Pigeons", (DataTable) data.Pigeons));
        report.ReportEmbeddedResource = !Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ja", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.Printing.BasketingListEN.rdlc" : "BriconLib.Printing.BasketingListJA.rdlc") : "BriconLib.Printing.BasketingListEN.rdlc";
        if (PrintHelper._printDialog == null)
        {
          PrintHelper._printDialog = new PrintDialog();
          if (PrintHelper._printDialog.ShowDialog() != DialogResult.OK)
            return;
        }
        using (DirectPrint directPrint = new DirectPrint())
          directPrint.Run(report, PrintHelper._printDialog);
      }
    }

    public static void PrintReadOutList(ClubPrinterDataSet data)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        LocalReport report = new LocalReport();
        report.DataSources.Add(new ReportDataSource("ClubPrinterDataSet_Settings", (DataTable) data.Settings));
        report.DataSources.Add(new ReportDataSource("ClubPrinterDataSet_Pigeons", (DataTable) data.Pigeons));
        report.ReportEmbeddedResource = !Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ja", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("uk", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.Printing.ReadOutListEN.rdlc" : "BriconLib.Printing.ReadOutListUK.rdlc") : "BriconLib.Printing.ReadOutListJA.rdlc") : "BriconLib.Printing.ReadOutListEN.rdlc";
        if (PrintHelper._printDialog == null)
        {
          PrintHelper._printDialog = new PrintDialog();
          if (PrintHelper._printDialog.ShowDialog() != DialogResult.OK)
            return;
        }
        using (DirectPrint directPrint = new DirectPrint())
          directPrint.Run(report, PrintHelper._printDialog);
      }
    }

    private static DataRow[] GetMaxRows(DataRow[] source, int maxRows)
    {
      DataRow[] dataRowArray = new DataRow[Math.Min(maxRows, source.Length)];
      Array.Copy((Array) source, (Array) dataRowArray, Math.Min(maxRows, source.Length));
      return dataRowArray;
    }

    public static void PrintChampignonShip(ChampignonShip champignonShip)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        PrintPreviewForm printPreviewForm = new PrintPreviewForm();
        if (champignonShip.Settings[0].IsMaxRowCount1Null())
          champignonShip.Settings[0].MaxRowCount1 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount2Null())
          champignonShip.Settings[0].MaxRowCount2 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount3Null())
          champignonShip.Settings[0].MaxRowCount3 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount4Null())
          champignonShip.Settings[0].MaxRowCount4 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount5Null())
          champignonShip.Settings[0].MaxRowCount5 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount6Null())
          champignonShip.Settings[0].MaxRowCount6 = 0;
        if (champignonShip.Settings[0].IsMaxRowCount6bNull())
          champignonShip.Settings[0].MaxRowCount6b = 0;
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Settings", (DataTable) champignonShip.Settings));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query1", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query1.Select("", "PriceCount desc, TotalCoefficient"), champignonShip.Settings[0].MaxRowCount1)));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query2", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query2.Select("PriceCount > 1", "PriceCount desc, TotalCoefficient"), champignonShip.Settings[0].MaxRowCount2)));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query3", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query3.Select("PriceCount >= " + champignonShip.Settings[0].Number3.ToString(), "TotalCoefficient"), champignonShip.Settings[0].MaxRowCount3)));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query4", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query4.Select("", "PointCount desc, TotalCoefficient"), champignonShip.Settings[0].MaxRowCount4)));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query5", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query5.Select("", "PriceCount desc, TotalCoefficient"), champignonShip.Settings[0].MaxRowCount5)));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query6", (IEnumerable) champignonShip.Query6.Select("Nr <= " + champignonShip.Settings[0].MaxRowCount6.ToString(), "FCI desc")));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("ChampignonShip_Query6b", (IEnumerable) PrintHelper.GetMaxRows(champignonShip.Query6b.Select("", "TotalCoefficient desc, PriceCount desc"), champignonShip.Settings[0].MaxRowCount6b)));
        printPreviewForm.reportViewer.LocalReport.ReportEmbeddedResource = !Settings.Default.Language.Equals("gr", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("hu", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.Printing.ChampignonChipGR.rdlc" : "BriconLib.Printing.ChampignonChipHU.rdlc") : "BriconLib.Printing.ChampignonChipGR.rdlc";
        printPreviewForm.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        int num2 = (int) printPreviewForm.ShowDialog();
      }
    }

    public static void PrintFancierDetail(int fancierID)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        PrintPreviewForm printPreviewForm = new PrintPreviewForm();
        DataRow[] dataRowArray1 = BCEDatabase.DataSet.Adressen.Select("ID = " + fancierID.ToString());
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("BCEDataSet_Adressen", (IEnumerable) dataRowArray1));
        DataRow[] dataRowArray2 = BCEDatabase.DataSet.Clubs.Select("ID = " + (dataRowArray1[0] as BCEDataSet.AdressenRow).ClubID.ToString());
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("BCEDataSet_Clubs", (IEnumerable) dataRowArray2));
        DataRow[] dataRowArray3 = BCEDatabase.DataSet.Pigeons.Select("FANCIERID = " + fancierID.ToString(), "DBRING");
        int num2 = 0;
        foreach (BCEDataSet.PigeonsRow pigeonsRow in dataRowArray3)
        {
          pigeonsRow.Column = num2 % 2;
          ++num2;
        }
        DataRow[] dataRowArray4 = BCEDatabase.DataSet.Pigeons.Select("FANCIERID = " + fancierID.ToString(), "DBRing");
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("BCEDataSet_Pigeons", (IEnumerable) dataRowArray4));
        printPreviewForm.reportViewer.LocalReport.ReportEmbeddedResource = !Settings.Default.Language.Equals("en", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("hu", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("fr", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("nl", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("uk", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ja", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.Printing.FancierDetailEN.rdlc" : "BriconLib.Printing.FancierDetailJA.rdlc") : "BriconLib.Printing.FancierDetailUK.rdlc") : "BriconLib.Printing.FancierDetailNL.rdlc") : "BriconLib.Printing.FancierDetailFR.rdlc") : "BriconLib.Printing.FancierDetailHU.rdlc") : "BriconLib.Printing.FancierDetailEN.rdlc";
        printPreviewForm.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        int num3 = (int) printPreviewForm.ShowDialog();
      }
    }

    public static void PrintCalculation(CalculationDataSet dataset)
    {
      if (!PrerequisitesInstall.IsReportViewer2010Installed())
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(1156, "The Microsoft Report Viewer 2010 is needed for printing"));
      }
      else
      {
        PrintPreviewForm printPreviewForm = new PrintPreviewForm();
        CalculationDataSet.ResultsDataTable resultsDataTable = dataset.Results;
        if (!dataset.Information[0].IsPricesNull())
        {
          string prices = dataset.Information[0].Prices;
          bool pigeonForFancier = dataset.Information[0].AddFirstPigeonForFancier;
          string s = "0";
          foreach (char c in prices)
          {
            if (char.IsDigit(c))
              s += c.ToString();
          }
          int result1;
          if (int.TryParse(s, out result1) && result1 > 0)
          {
            int Number = 1;
            if (prices.Contains("%"))
              result1 = Convert.ToInt32((double) dataset.Information[0].TotalBasketted * (double) result1 / 100.0 + 0.5);
            resultsDataTable = new CalculationDataSet.ResultsDataTable();
            List<string> stringList = new List<string>();
            foreach (CalculationDataSet.ResultsRow result2 in (TypedTableBase<CalculationDataSet.ResultsRow>) dataset.Results)
            {
              if (!pigeonForFancier)
              {
                if (Number > result1)
                  break;
              }
              if (pigeonForFancier && Number > result1 && stringList.Contains(result2.FancierName))
              {
                ++Number;
              }
              else
              {
                if (result2.IsOveralPointsNull())
                  result2.OveralPoints = 0M;
                if (result2.IsTimeZoneNull())
                  result2.TimeZone = 0M;
                resultsDataTable.AddResultsRow(Number, result2.FancierName, result2.RingNumber, result2.ClockingTime, result2.Distance, result2.DistanceString, result2.Speed, result2.CorrectedTime, result2.Basketed, result2.ClubID, result2.Position1, result2.Position2, result2.Position3, result2.Position4, result2.Percentage, result2.FCIAB, result2.FCICD, result2.FCIE, dataset.Information[0].ReleaseTime, dataset.Information[0].TotalBasketted, result2.FCI, dataset.Information[0].Flight, result2.CorrectedTimeDigit, result2.FlightTime, result2.TeamNbr, result2.Points100, result2.NaamUnicode, result2.GemeenteUnicode, result2.License, result2.OveralPoints, result2.TimeZone);
                ++Number;
                if (!stringList.Contains(result2.FancierName))
                  stringList.Add(result2.FancierName);
              }
            }
          }
        }
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("CalculationDataSet_Information", (DataTable) dataset.Information));
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("CalculationDataSet_Results", (DataTable) resultsDataTable));
        BCEDatabase.DataSet.Settings[0].CalculationPrintImperial = Utils.UnitsUsed() == "Imperial";
        printPreviewForm.reportViewer.LocalReport.DataSources.Add(new ReportDataSource("BCEDataSet_Settings", (DataTable) BCEDatabase.DataSet.Settings));
        printPreviewForm.reportViewer.LocalReport.ReportEmbeddedResource = !Settings.Default.Language.Equals("en", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("hu", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ja", StringComparison.InvariantCultureIgnoreCase) ? (!Settings.Default.Language.Equals("ar-SA", StringComparison.InvariantCultureIgnoreCase) ? "BriconLib.Printing.CalculationEN.rdlc" : "BriconLib.Printing.CalculationAR.rdlc") : "BriconLib.Printing.CalculationJA.rdlc") : "BriconLib.Printing.CalculationHU.rdlc") : "BriconLib.Printing.CalculationEN.rdlc";
        printPreviewForm.reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
        int num2 = (int) printPreviewForm.ShowDialog();
      }
    }
  }
}
