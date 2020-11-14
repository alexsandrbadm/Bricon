// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.Upload95Importer
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Other;
using MultiLang;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BriconLib.Data
{
  public class Upload95Importer
  {
    public static void Import()
    {
      if (MessageBox.Show(ml.ml_string(269, "For this to work you need to have the Bricon PC-Communication program (Upload95) installed on this computer."), ml.ml_string(270, "Importing"), MessageBoxButtons.OKCancel) == DialogResult.Cancel || MessageBox.Show(ml.ml_string(271, "Step 1: Converting the old database to a text file."), ml.ml_string(270, "Importing"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
        return;
      Process process1 = Process.Start("BCE_DBConverter.exe");
      do
        ;
      while (!process1.HasExited);
      string str1 = "DataToImport.txt";
      FileInfo fileInfo1 = new FileInfo(str1);
      if (!fileInfo1.Exists || fileInfo1.Length == 0L)
      {
        int num1 = (int) MessageBox.Show(ml.ml_string(274, "Data could not be imported, please make sure you have the latest Bricon PC-Communication Software installed (version 4.62)"), ml.ml_string(834, "Error"));
      }
      else
      {
        switch (MessageBox.Show(ml.ml_string(276, "Step 2: If you wish you can edit the text file to delete unwanted data, however only delete/move lines at a whole, do you want to edit this file before importing it(don't forget to save it)?"), ml.ml_string(270, "Importing"), MessageBoxButtons.YesNoCancel))
        {
          case DialogResult.Cancel:
            return;
          case DialogResult.Yes:
            Process process2 = Process.Start(str1);
            while (!process2.HasExited)
              ;
            break;
        }
        if (MessageBox.Show(ml.ml_string(277, "Step 3: Importing the text file to the BCE database."), ml.ml_string(270, "Importing"), MessageBoxButtons.OKCancel) == DialogResult.Cancel)
          return;
        FileInfo fileInfo2 = new FileInfo(str1);
        if (!fileInfo2.Exists || fileInfo2.Length == 0L)
        {
          int num2 = (int) MessageBox.Show(str1 + ml.ml_string(278, " is missing"), ml.ml_string(834, "Error"));
        }
        else
        {
          BCEDatabase.SaveToDisk(true);
          using (StreamReader streamReader = new StreamReader(str1))
          {
            BCEDataSet.ClubsRow parentClubsRowByClubs_Adressen = (BCEDataSet.ClubsRow) null;
            BCEDataSet.AdressenRow parentAdressenRowByAdressen_Pigeons = (BCEDataSet.AdressenRow) null;
            int num3 = 1;
            string str2;
            while ((str2 = streamReader.ReadLine()) != null)
            {
              string[] strArray = str2.Split(';');
              if (strArray.Length != 0)
              {
                if (strArray[0] == "CLUB" && strArray.Length == 5)
                {
                  parentClubsRowByClubs_Adressen = parentClubsRowByClubs_Adressen != null || BCEDatabase.DataSet.Clubs.Rows.Count <= 0 ? BCEDatabase.DataSet.Clubs.NewClubsRow() : BCEDatabase.DataSet.Clubs.Rows[0] as BCEDataSet.ClubsRow;
                  parentClubsRowByClubs_Adressen.BeginEdit();
                  parentClubsRowByClubs_Adressen.ClubID = strArray[2];
                  parentClubsRowByClubs_Adressen.Name = strArray[1];
                  parentClubsRowByClubs_Adressen.Pincode = strArray[3];
                  parentClubsRowByClubs_Adressen.EndEdit();
                }
                if (strArray[0] == " FANCIER" && strArray.Length == 14 && parentClubsRowByClubs_Adressen != null)
                  parentAdressenRowByAdressen_Pigeons = BCEDatabase.DataSet.Adressen.AddAdressenRow(strArray[1].PadRight(1), strArray[2].PadRight(1), strArray[3].PadRight(1), strArray[4].PadRight(1), strArray[5].PadRight(1), strArray[8].PadRight(1), strArray[10].PadRight(1), "", strArray[11].PadRight(1), "", Conversion.CoordinateToInt(strArray[6]), Conversion.CoordinateToInt(strArray[7]), "", parentClubsRowByClubs_Adressen, strArray[12].PadRight(1), "", "", "", DateTime.MinValue, "", "", false);
                if (strArray[0] == "  RING" && strArray.Length == 6 && (parentClubsRowByClubs_Adressen != null && parentAdressenRowByAdressen_Pigeons != null))
                  BCEDatabase.DataSet.Pigeons.AddPigeonsRow(parentAdressenRowByAdressen_Pigeons, strArray[1] + strArray[4], strArray[2], strArray[3] == "True", "", 0, false, num3++);
              }
            }
          }
          BCEDatabase.SaveToDisk(true);
        }
      }
    }
  }
}
