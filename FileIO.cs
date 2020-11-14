// Decompiled with JetBrains decompiler
// Type: FileIO
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.Collections;
using System.IO;
using System.Reflection;

public class FileIO
{
  private static FileIO _instance;
  private Hashtable _fileCache = new Hashtable();

  public static FileIO Instance
  {
    get
    {
      if (FileIO._instance == null)
        FileIO._instance = new FileIO();
      return FileIO._instance;
    }
  }

  public string RootDirectory { get; private set; }

  private FileIO()
  {
    this.RootDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    Directory.SetCurrentDirectory(this.RootDirectory);
  }

  public void ClearCache() => this._fileCache = new Hashtable();

  public byte[] GetFileFromCache(string fileName) => this.DoesFileExists(fileName) ? this.ReadAllBytes(fileName) : new byte[0];

  public bool DoesFileExists(string filename) => File.Exists(this.RootDirectory + filename);

  public byte[] ReadAllBytes(string filename)
  {
    try
    {
      return File.ReadAllBytes(this.RootDirectory + filename);
    }
    catch (Exception ex)
    {
      throw new Exception("ReadAllBytes failed for " + filename, ex);
    }
  }

  public FileStream OpenFileForReading(string filename)
  {
    try
    {
      return File.OpenRead(this.RootDirectory + filename);
    }
    catch (Exception ex)
    {
      throw new Exception("OpenFileForReading failed for " + filename, ex);
    }
  }

  public FileStream OpenFileForWriting(string filename)
  {
    try
    {
      return File.OpenWrite(this.RootDirectory + filename);
    }
    catch (Exception ex)
    {
      throw new Exception("OpenFileForWriting failed for " + filename, ex);
    }
  }
}
