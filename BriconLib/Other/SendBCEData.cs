// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.SendBCEData
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.BCE;
using BriconLib.Data;
using BriconLib.KBDB;
using MultiLang;
using System;
using System.Windows.Forms;

namespace BriconLib.Other
{
  internal class SendBCEData
  {
    public void SendToKBDB()
    {
      try
      {
        BCEDataSet.ClubsRow activeClubRow = MainForm.Instance.clubsPage.GetActiveClubRow();
        if (activeClubRow.IsClubIDNull() || activeClubRow.ClubID.Length != 4 || (activeClubRow.ClubID == "9999" || activeClubRow.ClubID == "0000"))
        {
          int num1 = (int) MessageBox.Show(ml.ml_string(1237, "Gelieve een geldige clubid in te vullen voor de active club"));
        }
        else if (activeClubRow.IsNameNull() || activeClubRow.Name == "")
        {
          int num2 = (int) MessageBox.Show(ml.ml_string(1238, "Gelieve de naam in te vullen van de aktieve club"));
        }
        else if (activeClubRow.IsGemeenteNull() || activeClubRow.Gemeente == "")
        {
          int num3 = (int) MessageBox.Show(ml.ml_string(1239, "Gelieve de gemeente in te vullen van de aktieve club"));
        }
        else
        {
          SendBceDataToKbdb.Send(activeClubRow.ClubID);
          int num4 = (int) MessageBox.Show("OK");
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show("Error: " + ex?.ToString());
      }
    }
  }
}
