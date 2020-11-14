// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.DatabaseUpdater
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using MultiLang;
using System;
using System.Data.OleDb;
using System.IO;

namespace BriconLib.Data
{
  public class DatabaseUpdater
  {
    private OleDbConnection _connection;
    private StreamWriter _logFile;

    public static void Update(string connectionString)
    {
      try
      {
        new DatabaseUpdater().Update_P(connectionString);
      }
      catch (ApplicationException ex)
      {
        throw new ApplicationException(ml.ml_string(130, "Could not update database"), (Exception) ex);
      }
    }

    private void ExecuteQuery(string query)
    {
      new OleDbCommand(query, this._connection).ExecuteNonQuery();
      this._logFile.WriteLine(DateTime.Now.ToString() + " : " + query);
    }

    private int GetDatabaseVersion()
    {
      try
      {
        return Convert.ToInt32(new OleDbCommand("SELECT DatabaseVersion from Version", this._connection).ExecuteScalar());
      }
      catch (OleDbException ex)
      {
        return 0;
      }
    }

    private void SetDatabaseVersion(int version)
    {
      if (version == 1)
      {
        this.ExecuteQuery("CREATE TABLE Version (ID int IDENTITY(1,1) PRIMARY KEY,DatabaseVersion int not null)");
        this.ExecuteQuery("INSERT into Version (DatabaseVersion) values (" + version.ToString() + ")");
      }
      else
        this.ExecuteQuery("Update Version Set DatabaseVersion = " + version.ToString());
    }

    private void Update_P(string connectionString)
    {
      this._logFile = new StreamWriter("databasechanges.log", true);
      this._connection = new OleDbConnection(connectionString);
      this._connection.Open();
      int version1 = this.GetDatabaseVersion();
      if (version1 < 1)
      {
        version1 = 1;
        try
        {
          this._logFile.WriteLine("********** Database version " + version1.ToString() + " changes done **********");
          this.ExecuteQuery("ALTER TABLE Adressen ADD Serial String, ClubID int, Notes String, Country String");
          this.ExecuteQuery("CREATE TABLE Pigeons (ID int IDENTITY(1,1) PRIMARY KEY,FancierID int not null,DBRing String not null,ELRing String not null,Color String not null,Female bit)");
          this.ExecuteQuery("CREATE TABLE Clubs (ID int IDENTITY(1,1) PRIMARY KEY,ClubID String not null,Pincode String not null,Name String not null)");
          this.ExecuteQuery("Insert into Clubs (ClubID, Pincode, Name) values ('9999','999999','Default')");
          this.ExecuteQuery("Update Adressen set ClubID = 1");
          this.ExecuteQuery("ALTER TABLE Lossingsplaats ADD Selected bit");
          this.SetDatabaseVersion(version1);
          this._logFile.WriteLine("********** Database version " + version1.ToString() + " changes done **********");
        }
        catch (Exception ex)
        {
          this._logFile.WriteLine("Fatal Error:" + ex.ToString());
        }
      }
      if (version1 < 5)
      {
        version1 = 5;
        try
        {
          this._logFile.WriteLine("********** Database version " + version1.ToString() + " changes done **********");
          this.ExecuteQuery("ALTER TABLE PIGEONS ADD FEMALE bit");
          this.SetDatabaseVersion(version1);
          this._logFile.WriteLine("********** Database version " + version1.ToString() + " changes done **********");
        }
        catch (Exception ex)
        {
          this._logFile.WriteLine("Fatal Error:" + ex.ToString());
        }
      }
      if (version1 < 6)
      {
        int version2 = 6;
        try
        {
          this._logFile.WriteLine("********** Database version " + version2.ToString() + " changes done **********");
          this.ExecuteQuery("ALTER TABLE LOSSINGSPLAATS ADD Place String, Country String");
          this.SetDatabaseVersion(version2);
          this._logFile.WriteLine("********** Database version " + version2.ToString() + " changes done **********");
        }
        catch (Exception ex)
        {
          this._logFile.WriteLine("Fatal Error:" + ex.ToString());
        }
      }
      this._logFile.Close();
      this._connection.Close();
    }
  }
}
