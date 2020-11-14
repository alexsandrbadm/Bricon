// Decompiled with JetBrains decompiler
// Type: DirectPrint
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;

public class DirectPrint : IDisposable
{
  private int m_currentPageIndex;
  private IList<Stream> m_streams;

  private Stream CreateStream(
    string name,
    string fileNameExtension,
    Encoding encoding,
    string mimeType,
    bool willSeek)
  {
    Stream stream = (Stream) new MemoryStream();
    this.m_streams.Add(stream);
    return stream;
  }

  private void Export(LocalReport report)
  {
    string deviceInfo = "<DeviceInfo>  <OutputFormat>EMF</OutputFormat>  <PageWidth>8.26in</PageWidth>  <PageHeight>11.8in</PageHeight>  <MarginTop>0.25in</MarginTop>  <MarginLeft>0.25in</MarginLeft>  <MarginRight>0.25in</MarginRight>  <MarginBottom>0.25in</MarginBottom></DeviceInfo>";
    this.m_streams = (IList<Stream>) new List<Stream>();
    report.Render("Image", deviceInfo, new CreateStreamCallback(this.CreateStream), out Warning[] _);
    foreach (Stream stream in (IEnumerable<Stream>) this.m_streams)
      stream.Position = 0L;
  }

  private void PrintPage(object sender, PrintPageEventArgs ev)
  {
    Metafile metafile = new Metafile(this.m_streams[this.m_currentPageIndex]);
    ev.Graphics.DrawImage((Image) metafile, ev.PageBounds);
    ++this.m_currentPageIndex;
    ev.HasMorePages = this.m_currentPageIndex < this.m_streams.Count;
  }

  private void Print(PrintDialog printDialog)
  {
    if (this.m_streams == null || this.m_streams.Count == 0)
      return;
    PrintDocument printDocument = new PrintDocument();
    printDocument.PrinterSettings = printDialog.PrinterSettings;
    if (!printDocument.PrinterSettings.IsValid)
    {
      int num = (int) MessageBox.Show(string.Format("Can't find printer \"{0}\".", (object) printDocument.PrinterSettings.PrinterName), "Print Error");
    }
    else
    {
      printDocument.PrintPage += new PrintPageEventHandler(this.PrintPage);
      printDocument.Print();
    }
  }

  public void Run(LocalReport report, PrintDialog printDialog)
  {
    this.Export(report);
    this.m_currentPageIndex = 0;
    this.Print(printDialog);
  }

  public void Dispose()
  {
    if (this.m_streams == null)
      return;
    foreach (Stream stream in (IEnumerable<Stream>) this.m_streams)
      stream.Close();
    this.m_streams = (IList<Stream>) null;
  }
}
