// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.ImportDistancesFromFile
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Data;
using System;
using System.IO;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class ImportDistancesFromFile
  {
    public void Do(string fileName, BCEDataSet.ClubsRow clubRow)
    {
      string[] strArray1 = File.ReadAllText(fileName).Split('\r', '\r', '\n');
      int num1 = 0;
      int num2 = 0;
      int num3 = 0;
      foreach (string str1 in strArray1)
      {
        if (!string.IsNullOrWhiteSpace(str1))
        {
          string[] strArray2 = str1.Split(',');
          string str2 = strArray2.Length >= 4 ? strArray2[0] : throw new ApplicationException("Invalid line, each line must contains at least 4 values, line: " + str1);
          string str3 = strArray2[1];
          if (str3.Length < 6)
            throw new ApplicationException("Second column is not long enough (expecting license of 6 or 7 bytes), line: " + str1);
          if (str3.Length < 7)
            str3 = str3.Substring(0, 2) + "0" + str3.Substring(2);
          int result1;
          if (!int.TryParse(strArray2[2], out result1))
            throw new ApplicationException("Third column is not an integer (expecting miles), line: " + str1);
          int result2;
          if (!int.TryParse(strArray2[3], out result2))
            throw new ApplicationException("Fourth column is not an integer (expecting yards), line: " + str1);
          bool flag1 = false;
          foreach (BCEDataSet.AdressenRow adressenRow in clubRow.GetAdressenRows())
          {
            if (adressenRow.Licentie.ToLower() == str3.ToLower())
            {
              flag1 = true;
              bool flag2 = false;
              foreach (BCEDataSet.DistancesRow distancesRow in adressenRow.GetDistancesRows())
              {
                if (distancesRow.RaceCode == str2)
                {
                  flag2 = true;
                  distancesRow.Distance = result1;
                  distancesRow.DistanceYards = result2;
                }
              }
              if (!flag2)
                ++num3;
            }
          }
          if (!flag1)
            ++num2;
          ++num1;
        }
      }
      int num4 = (int) MessageBox.Show(string.Format("Import of {0} lines complete, {1} new distances, {2} updated distances,\n{3} distances with unknown license", (object) num1, (object) num3, (object) (num1 - num3 - num2), (object) num2));
      int num5 = (int) MessageBox.Show("TODO, we are missing the racecode in the releaseplaces");
    }
  }
}
