// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.CalculationDataSet
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace BriconLib.Data
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("CalculationDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class CalculationDataSet : DataSet
  {
    private CalculationDataSet.InformationDataTable tableInformation;
    private CalculationDataSet.ReadOutsDataTable tableReadOuts;
    private CalculationDataSet.ResultsDataTable tableResults;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public CalculationDataSet()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected CalculationDataSet(SerializationInfo info, StreamingContext context)
      : base(info, context, false)
    {
      if (this.IsBinarySerialized(info, context))
      {
        this.InitVars(false);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        this.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
      else
      {
        string s = (string) info.GetValue("XmlSchema", typeof (string));
        if (this.DetermineSchemaSerializationMode(info, context) == SchemaSerializationMode.IncludeSchema)
        {
          DataSet dataSet = new DataSet();
          dataSet.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
          if (dataSet.Tables[nameof (Information)] != null)
            base.Tables.Add((DataTable) new CalculationDataSet.InformationDataTable(dataSet.Tables[nameof (Information)]));
          if (dataSet.Tables[nameof (ReadOuts)] != null)
            base.Tables.Add((DataTable) new CalculationDataSet.ReadOutsDataTable(dataSet.Tables[nameof (ReadOuts)]));
          if (dataSet.Tables[nameof (Results)] != null)
            base.Tables.Add((DataTable) new CalculationDataSet.ResultsDataTable(dataSet.Tables[nameof (Results)]));
          this.DataSetName = dataSet.DataSetName;
          this.Prefix = dataSet.Prefix;
          this.Namespace = dataSet.Namespace;
          this.Locale = dataSet.Locale;
          this.CaseSensitive = dataSet.CaseSensitive;
          this.EnforceConstraints = dataSet.EnforceConstraints;
          this.Merge(dataSet, false, MissingSchemaAction.Add);
          this.InitVars();
        }
        else
          this.ReadXmlSchema((XmlReader) new XmlTextReader((TextReader) new StringReader(s)));
        this.GetSerializationData(info, context);
        CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
        base.Tables.CollectionChanged += changeEventHandler;
        this.Relations.CollectionChanged += changeEventHandler;
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public CalculationDataSet.InformationDataTable Information => this.tableInformation;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public CalculationDataSet.ReadOutsDataTable ReadOuts => this.tableReadOuts;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public CalculationDataSet.ResultsDataTable Results => this.tableResults;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get => this._schemaSerializationMode;
      set => this._schemaSerializationMode = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables => base.Tables;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations => base.Relations;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public override DataSet Clone()
    {
      CalculationDataSet calculationDataSet = (CalculationDataSet) base.Clone();
      calculationDataSet.InitVars();
      calculationDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) calculationDataSet;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeTables() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override bool ShouldSerializeRelations() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["Information"] != null)
          base.Tables.Add((DataTable) new CalculationDataSet.InformationDataTable(dataSet.Tables["Information"]));
        if (dataSet.Tables["ReadOuts"] != null)
          base.Tables.Add((DataTable) new CalculationDataSet.ReadOutsDataTable(dataSet.Tables["ReadOuts"]));
        if (dataSet.Tables["Results"] != null)
          base.Tables.Add((DataTable) new CalculationDataSet.ResultsDataTable(dataSet.Tables["Results"]));
        this.DataSetName = dataSet.DataSetName;
        this.Prefix = dataSet.Prefix;
        this.Namespace = dataSet.Namespace;
        this.Locale = dataSet.Locale;
        this.CaseSensitive = dataSet.CaseSensitive;
        this.EnforceConstraints = dataSet.EnforceConstraints;
        this.Merge(dataSet, false, MissingSchemaAction.Add);
        this.InitVars();
      }
      else
      {
        int num = (int) this.ReadXml(reader);
        this.InitVars();
      }
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars() => this.InitVars(true);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    internal void InitVars(bool initTable)
    {
      this.tableInformation = (CalculationDataSet.InformationDataTable) base.Tables["Information"];
      if (initTable && this.tableInformation != null)
        this.tableInformation.InitVars();
      this.tableReadOuts = (CalculationDataSet.ReadOutsDataTable) base.Tables["ReadOuts"];
      if (initTable && this.tableReadOuts != null)
        this.tableReadOuts.InitVars();
      this.tableResults = (CalculationDataSet.ResultsDataTable) base.Tables["Results"];
      if (!initTable || this.tableResults == null)
        return;
      this.tableResults.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (CalculationDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/CalculationDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableInformation = new CalculationDataSet.InformationDataTable();
      base.Tables.Add((DataTable) this.tableInformation);
      this.tableReadOuts = new CalculationDataSet.ReadOutsDataTable();
      base.Tables.Add((DataTable) this.tableReadOuts);
      this.tableResults = new CalculationDataSet.ResultsDataTable();
      base.Tables.Add((DataTable) this.tableResults);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeInformation() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeReadOuts() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeResults() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      CalculationDataSet calculationDataSet = new CalculationDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = calculationDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = calculationDataSet.GetSchemaSerializable();
      if (xs.Contains(schemaSerializable.TargetNamespace))
      {
        MemoryStream memoryStream1 = new MemoryStream();
        MemoryStream memoryStream2 = new MemoryStream();
        try
        {
          schemaSerializable.Write((Stream) memoryStream1);
          IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
          while (enumerator.MoveNext())
          {
            XmlSchema current = (XmlSchema) enumerator.Current;
            memoryStream2.SetLength(0L);
            MemoryStream memoryStream3 = memoryStream2;
            current.Write((Stream) memoryStream3);
            if (memoryStream1.Length == memoryStream2.Length)
            {
              memoryStream1.Position = 0L;
              memoryStream2.Position = 0L;
              do
                ;
              while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
              if (memoryStream1.Position == memoryStream1.Length)
                return schemaComplexType;
            }
          }
        }
        finally
        {
          memoryStream1?.Close();
          memoryStream2?.Close();
        }
      }
      xs.Add(schemaSerializable);
      return schemaComplexType;
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class ResultsDataTable : TypedTableBase<CalculationDataSet.ResultsRow>
    {
      private DataColumn columnID;
      private DataColumn columnNumber;
      private DataColumn columnFancierName;
      private DataColumn columnRingNumber;
      private DataColumn columnClockingTime;
      private DataColumn columnDistance;
      private DataColumn columnDistanceString;
      private DataColumn columnSpeed;
      private DataColumn columnCorrectedTime;
      private DataColumn columnBasketed;
      private DataColumn columnClubID;
      private DataColumn columnPosition1;
      private DataColumn columnPosition2;
      private DataColumn columnPosition3;
      private DataColumn columnPosition4;
      private DataColumn columnPercentage;
      private DataColumn columnFCIAB;
      private DataColumn columnFCICD;
      private DataColumn columnFCIE;
      private DataColumn columnReleaseTime;
      private DataColumn columnTotalBasketed;
      private DataColumn columnFCI;
      private DataColumn columnFlight;
      private DataColumn columnCorrectedTimeDigit;
      private DataColumn columnFlightTime;
      private DataColumn columnTeamNbr;
      private DataColumn columnPoints100;
      private DataColumn columnNaamUnicode;
      private DataColumn columnGemeenteUnicode;
      private DataColumn columnLicense;
      private DataColumn columnOveralPoints;
      private DataColumn columnTimeZone;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ResultsDataTable()
      {
        this.TableName = "Results";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ResultsDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected ResultsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NumberColumn => this.columnNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FancierNameColumn => this.columnFancierName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RingNumberColumn => this.columnRingNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClockingTimeColumn => this.columnClockingTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceStringColumn => this.columnDistanceString;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SpeedColumn => this.columnSpeed;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CorrectedTimeColumn => this.columnCorrectedTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BasketedColumn => this.columnBasketed;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Position1Column => this.columnPosition1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Position2Column => this.columnPosition2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Position3Column => this.columnPosition3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Position4Column => this.columnPosition4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PercentageColumn => this.columnPercentage;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCIABColumn => this.columnFCIAB;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCICDColumn => this.columnFCICD;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCIEColumn => this.columnFCIE;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReleaseTimeColumn => this.columnReleaseTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalBasketedColumn => this.columnTotalBasketed;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCIColumn => this.columnFCI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightColumn => this.columnFlight;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CorrectedTimeDigitColumn => this.columnCorrectedTimeDigit;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightTimeColumn => this.columnFlightTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TeamNbrColumn => this.columnTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Points100Column => this.columnPoints100;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NaamUnicodeColumn => this.columnNaamUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GemeenteUnicodeColumn => this.columnGemeenteUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LicenseColumn => this.columnLicense;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OveralPointsColumn => this.columnOveralPoints;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeZoneColumn => this.columnTimeZone;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ResultsRow this[int index] => (CalculationDataSet.ResultsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ResultsRowChangeEventHandler ResultsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ResultsRowChangeEventHandler ResultsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ResultsRowChangeEventHandler ResultsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ResultsRowChangeEventHandler ResultsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddResultsRow(CalculationDataSet.ResultsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ResultsRow AddResultsRow(
        int Number,
        string FancierName,
        string RingNumber,
        DateTime ClockingTime,
        Decimal Distance,
        string DistanceString,
        Decimal Speed,
        DateTime CorrectedTime,
        int Basketed,
        string ClubID,
        int Position1,
        int Position2,
        int Position3,
        int Position4,
        double Percentage,
        double FCIAB,
        double FCICD,
        double FCIE,
        DateTime ReleaseTime,
        int TotalBasketed,
        double FCI,
        string Flight,
        int CorrectedTimeDigit,
        DateTime FlightTime,
        int TeamNbr,
        int Points100,
        string NaamUnicode,
        string GemeenteUnicode,
        string License,
        Decimal OveralPoints,
        Decimal TimeZone)
      {
        CalculationDataSet.ResultsRow resultsRow = (CalculationDataSet.ResultsRow) this.NewRow();
        object[] objArray = new object[32]
        {
          null,
          (object) Number,
          (object) FancierName,
          (object) RingNumber,
          (object) ClockingTime,
          (object) Distance,
          (object) DistanceString,
          (object) Speed,
          (object) CorrectedTime,
          (object) Basketed,
          (object) ClubID,
          (object) Position1,
          (object) Position2,
          (object) Position3,
          (object) Position4,
          (object) Percentage,
          (object) FCIAB,
          (object) FCICD,
          (object) FCIE,
          (object) ReleaseTime,
          (object) TotalBasketed,
          (object) FCI,
          (object) Flight,
          (object) CorrectedTimeDigit,
          (object) FlightTime,
          (object) TeamNbr,
          (object) Points100,
          (object) NaamUnicode,
          (object) GemeenteUnicode,
          (object) License,
          (object) OveralPoints,
          (object) TimeZone
        };
        resultsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) resultsRow);
        return resultsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ResultsRow FindByID(int ID) => (CalculationDataSet.ResultsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        CalculationDataSet.ResultsDataTable resultsDataTable = (CalculationDataSet.ResultsDataTable) base.Clone();
        resultsDataTable.InitVars();
        return (DataTable) resultsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new CalculationDataSet.ResultsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnNumber = this.Columns["Number"];
        this.columnFancierName = this.Columns["FancierName"];
        this.columnRingNumber = this.Columns["RingNumber"];
        this.columnClockingTime = this.Columns["ClockingTime"];
        this.columnDistance = this.Columns["Distance"];
        this.columnDistanceString = this.Columns["DistanceString"];
        this.columnSpeed = this.Columns["Speed"];
        this.columnCorrectedTime = this.Columns["CorrectedTime"];
        this.columnBasketed = this.Columns["Basketed"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnPosition1 = this.Columns["Position1"];
        this.columnPosition2 = this.Columns["Position2"];
        this.columnPosition3 = this.Columns["Position3"];
        this.columnPosition4 = this.Columns["Position4"];
        this.columnPercentage = this.Columns["Percentage"];
        this.columnFCIAB = this.Columns["FCIAB"];
        this.columnFCICD = this.Columns["FCICD"];
        this.columnFCIE = this.Columns["FCIE"];
        this.columnReleaseTime = this.Columns["ReleaseTime"];
        this.columnTotalBasketed = this.Columns["TotalBasketed"];
        this.columnFCI = this.Columns["FCI"];
        this.columnFlight = this.Columns["Flight"];
        this.columnCorrectedTimeDigit = this.Columns["CorrectedTimeDigit"];
        this.columnFlightTime = this.Columns["FlightTime"];
        this.columnTeamNbr = this.Columns["TeamNbr"];
        this.columnPoints100 = this.Columns["Points100"];
        this.columnNaamUnicode = this.Columns["NaamUnicode"];
        this.columnGemeenteUnicode = this.Columns["GemeenteUnicode"];
        this.columnLicense = this.Columns["License"];
        this.columnOveralPoints = this.Columns["OveralPoints"];
        this.columnTimeZone = this.Columns["TimeZone"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnNumber = new DataColumn("Number", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber);
        this.columnFancierName = new DataColumn("FancierName", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierName);
        this.columnRingNumber = new DataColumn("RingNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRingNumber);
        this.columnClockingTime = new DataColumn("ClockingTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClockingTime);
        this.columnDistance = new DataColumn("Distance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnDistanceString = new DataColumn("DistanceString", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceString);
        this.columnSpeed = new DataColumn("Speed", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSpeed);
        this.columnCorrectedTime = new DataColumn("CorrectedTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCorrectedTime);
        this.columnBasketed = new DataColumn("Basketed", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBasketed);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnPosition1 = new DataColumn("Position1", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition1);
        this.columnPosition2 = new DataColumn("Position2", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition2);
        this.columnPosition3 = new DataColumn("Position3", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition3);
        this.columnPosition4 = new DataColumn("Position4", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition4);
        this.columnPercentage = new DataColumn("Percentage", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPercentage);
        this.columnFCIAB = new DataColumn("FCIAB", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFCIAB);
        this.columnFCICD = new DataColumn("FCICD", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFCICD);
        this.columnFCIE = new DataColumn("FCIE", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFCIE);
        this.columnReleaseTime = new DataColumn("ReleaseTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReleaseTime);
        this.columnTotalBasketed = new DataColumn("TotalBasketed", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalBasketed);
        this.columnFCI = new DataColumn("FCI", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFCI);
        this.columnFlight = new DataColumn("Flight", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlight);
        this.columnCorrectedTimeDigit = new DataColumn("CorrectedTimeDigit", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCorrectedTimeDigit);
        this.columnFlightTime = new DataColumn("FlightTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightTime);
        this.columnTeamNbr = new DataColumn("TeamNbr", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTeamNbr);
        this.columnPoints100 = new DataColumn("Points100", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPoints100);
        this.columnNaamUnicode = new DataColumn("NaamUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNaamUnicode);
        this.columnGemeenteUnicode = new DataColumn("GemeenteUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGemeenteUnicode);
        this.columnLicense = new DataColumn("License", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLicense);
        this.columnOveralPoints = new DataColumn("OveralPoints", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOveralPoints);
        this.columnTimeZone = new DataColumn("TimeZone", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeZone);
        this.Constraints.Add((Constraint) new UniqueConstraint("OKResults", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierName.DefaultValue = (object) "";
        this.columnRingNumber.DefaultValue = (object) "";
        this.columnDistanceString.DefaultValue = (object) "";
        this.columnClubID.DefaultValue = (object) "";
        this.columnPosition1.DefaultValue = (object) 0;
        this.columnPosition2.Caption = "Position1";
        this.columnPosition2.DefaultValue = (object) 0;
        this.columnPosition3.Caption = "Position1";
        this.columnPosition3.DefaultValue = (object) 0;
        this.columnPosition4.DefaultValue = (object) 0;
        this.columnPercentage.DefaultValue = (object) 0.0;
        this.columnFCIAB.DefaultValue = (object) 0.0;
        this.columnFCICD.DefaultValue = (object) 0.0;
        this.columnFCIE.DefaultValue = (object) 0.0;
        this.columnTotalBasketed.Caption = "Basketed";
        this.columnFCI.DefaultValue = (object) 0.0;
        this.columnFlight.DefaultValue = (object) "";
        this.columnCorrectedTimeDigit.DefaultValue = (object) 0;
        this.columnTeamNbr.DefaultValue = (object) 0;
        this.columnPoints100.DefaultValue = (object) 0;
        this.columnNaamUnicode.DefaultValue = (object) "";
        this.columnNaamUnicode.MaxLength = 50;
        this.columnGemeenteUnicode.DefaultValue = (object) "";
        this.columnGemeenteUnicode.MaxLength = 50;
        this.columnLicense.DefaultValue = (object) "";
        this.columnLicense.MaxLength = 50;
        this.columnOveralPoints.DefaultValue = (object) 0M;
        this.columnTimeZone.DefaultValue = (object) 0M;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ResultsRow NewResultsRow() => (CalculationDataSet.ResultsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new CalculationDataSet.ResultsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (CalculationDataSet.ResultsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.ResultsRowChanged == null)
          return;
        this.ResultsRowChanged((object) this, new CalculationDataSet.ResultsRowChangeEvent((CalculationDataSet.ResultsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.ResultsRowChanging == null)
          return;
        this.ResultsRowChanging((object) this, new CalculationDataSet.ResultsRowChangeEvent((CalculationDataSet.ResultsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.ResultsRowDeleted == null)
          return;
        this.ResultsRowDeleted((object) this, new CalculationDataSet.ResultsRowChangeEvent((CalculationDataSet.ResultsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.ResultsRowDeleting == null)
          return;
        this.ResultsRowDeleting((object) this, new CalculationDataSet.ResultsRowChangeEvent((CalculationDataSet.ResultsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveResultsRow(CalculationDataSet.ResultsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        CalculationDataSet calculationDataSet = new CalculationDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = calculationDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (ResultsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = calculationDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              MemoryStream memoryStream3 = memoryStream2;
              current.Write((Stream) memoryStream3);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class InformationDataTable : TypedTableBase<CalculationDataSet.InformationRow>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnClub;
      private DataColumn columnFlight;
      private DataColumn columnReleaseTime;
      private DataColumn columnUnits;
      private DataColumn columnRemarks;
      private DataColumn columnPrices;
      private DataColumn columnAddFirstPigeonForFancier;
      private DataColumn columnCoordinateY;
      private DataColumn columnCoordinateX;
      private DataColumn columnTotalBasketted;
      private DataColumn columnTotalFanciers;
      private DataColumn columnCoordinateXString;
      private DataColumn columnCoordinateYString;
      private DataColumn columnTwoDayRace;
      private DataColumn columnTwoDayRaceFrom;
      private DataColumn columnTwoDayRaceTo;
      private DataColumn columnTimeZone;
      private DataColumn columnManualFancierCount;
      private DataColumn columnManualPigeonCount;
      private DataColumn columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public InformationDataTable()
      {
        this.TableName = "Information";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal InformationDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected InformationDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubColumn => this.columnClub;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightColumn => this.columnFlight;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReleaseTimeColumn => this.columnReleaseTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn UnitsColumn => this.columnUnits;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RemarksColumn => this.columnRemarks;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PricesColumn => this.columnPrices;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn AddFirstPigeonForFancierColumn => this.columnAddFirstPigeonForFancier;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordinateYColumn => this.columnCoordinateY;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordinateXColumn => this.columnCoordinateX;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalBaskettedColumn => this.columnTotalBasketted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalFanciersColumn => this.columnTotalFanciers;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordinateXStringColumn => this.columnCoordinateXString;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordinateYStringColumn => this.columnCoordinateYString;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TwoDayRaceColumn => this.columnTwoDayRace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TwoDayRaceFromColumn => this.columnTwoDayRaceFrom;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TwoDayRaceToColumn => this.columnTwoDayRaceTo;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeZoneColumn => this.columnTimeZone;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ManualFancierCountColumn => this.columnManualFancierCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ManualPigeonCountColumn => this.columnManualPigeonCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.InformationRow this[int index] => (CalculationDataSet.InformationRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.InformationRowChangeEventHandler InformationRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.InformationRowChangeEventHandler InformationRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.InformationRowChangeEventHandler InformationRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.InformationRowChangeEventHandler InformationRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddInformationRow(CalculationDataSet.InformationRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.InformationRow AddInformationRow(
        string Name,
        string Club,
        string Flight,
        DateTime ReleaseTime,
        string Units,
        string Remarks,
        string Prices,
        bool AddFirstPigeonForFancier,
        int CoordinateY,
        int CoordinateX,
        int TotalBasketted,
        int TotalFanciers,
        string CoordinateXString,
        string CoordinateYString,
        bool TwoDayRace,
        DateTime TwoDayRaceFrom,
        DateTime TwoDayRaceTo,
        Decimal TimeZone,
        int ManualFancierCount,
        int ManualPigeonCount,
        Decimal Distance)
      {
        CalculationDataSet.InformationRow informationRow = (CalculationDataSet.InformationRow) this.NewRow();
        object[] objArray = new object[22]
        {
          null,
          (object) Name,
          (object) Club,
          (object) Flight,
          (object) ReleaseTime,
          (object) Units,
          (object) Remarks,
          (object) Prices,
          (object) AddFirstPigeonForFancier,
          (object) CoordinateY,
          (object) CoordinateX,
          (object) TotalBasketted,
          (object) TotalFanciers,
          (object) CoordinateXString,
          (object) CoordinateYString,
          (object) TwoDayRace,
          (object) TwoDayRaceFrom,
          (object) TwoDayRaceTo,
          (object) TimeZone,
          (object) ManualFancierCount,
          (object) ManualPigeonCount,
          (object) Distance
        };
        informationRow.ItemArray = objArray;
        this.Rows.Add((DataRow) informationRow);
        return informationRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.InformationRow FindByID(int ID) => (CalculationDataSet.InformationRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        CalculationDataSet.InformationDataTable informationDataTable = (CalculationDataSet.InformationDataTable) base.Clone();
        informationDataTable.InitVars();
        return (DataTable) informationDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new CalculationDataSet.InformationDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnClub = this.Columns["Club"];
        this.columnFlight = this.Columns["Flight"];
        this.columnReleaseTime = this.Columns["ReleaseTime"];
        this.columnUnits = this.Columns["Units"];
        this.columnRemarks = this.Columns["Remarks"];
        this.columnPrices = this.Columns["Prices"];
        this.columnAddFirstPigeonForFancier = this.Columns["AddFirstPigeonForFancier"];
        this.columnCoordinateY = this.Columns["CoordinateY"];
        this.columnCoordinateX = this.Columns["CoordinateX"];
        this.columnTotalBasketted = this.Columns["TotalBasketted"];
        this.columnTotalFanciers = this.Columns["TotalFanciers"];
        this.columnCoordinateXString = this.Columns["CoordinateXString"];
        this.columnCoordinateYString = this.Columns["CoordinateYString"];
        this.columnTwoDayRace = this.Columns["TwoDayRace"];
        this.columnTwoDayRaceFrom = this.Columns["TwoDayRaceFrom"];
        this.columnTwoDayRaceTo = this.Columns["TwoDayRaceTo"];
        this.columnTimeZone = this.Columns["TimeZone"];
        this.columnManualFancierCount = this.Columns["ManualFancierCount"];
        this.columnManualPigeonCount = this.Columns["ManualPigeonCount"];
        this.columnDistance = this.Columns["Distance"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnClub = new DataColumn("Club", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClub);
        this.columnFlight = new DataColumn("Flight", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlight);
        this.columnReleaseTime = new DataColumn("ReleaseTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReleaseTime);
        this.columnUnits = new DataColumn("Units", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUnits);
        this.columnRemarks = new DataColumn("Remarks", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRemarks);
        this.columnPrices = new DataColumn("Prices", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrices);
        this.columnAddFirstPigeonForFancier = new DataColumn("AddFirstPigeonForFancier", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddFirstPigeonForFancier);
        this.columnCoordinateY = new DataColumn("CoordinateY", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordinateY);
        this.columnCoordinateX = new DataColumn("CoordinateX", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordinateX);
        this.columnTotalBasketted = new DataColumn("TotalBasketted", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalBasketted);
        this.columnTotalFanciers = new DataColumn("TotalFanciers", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalFanciers);
        this.columnCoordinateXString = new DataColumn("CoordinateXString", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordinateXString);
        this.columnCoordinateYString = new DataColumn("CoordinateYString", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordinateYString);
        this.columnTwoDayRace = new DataColumn("TwoDayRace", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTwoDayRace);
        this.columnTwoDayRaceFrom = new DataColumn("TwoDayRaceFrom", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTwoDayRaceFrom);
        this.columnTwoDayRaceTo = new DataColumn("TwoDayRaceTo", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTwoDayRaceTo);
        this.columnTimeZone = new DataColumn("TimeZone", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeZone);
        this.columnManualFancierCount = new DataColumn("ManualFancierCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnManualFancierCount);
        this.columnManualPigeonCount = new DataColumn("ManualPigeonCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnManualPigeonCount);
        this.columnDistance = new DataColumn("Distance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.Constraints.Add((Constraint) new UniqueConstraint("PKInformation", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnClub.DefaultValue = (object) "";
        this.columnFlight.DefaultValue = (object) "";
        this.columnUnits.DefaultValue = (object) "";
        this.columnRemarks.DefaultValue = (object) "";
        this.columnPrices.DefaultValue = (object) "";
        this.columnAddFirstPigeonForFancier.DefaultValue = (object) false;
        this.columnCoordinateY.DefaultValue = (object) 0;
        this.columnCoordinateX.DefaultValue = (object) 0;
        this.columnTotalBasketted.DefaultValue = (object) 0;
        this.columnTotalFanciers.DefaultValue = (object) 0;
        this.columnCoordinateXString.DefaultValue = (object) "";
        this.columnCoordinateYString.DefaultValue = (object) "";
        this.columnTwoDayRace.DefaultValue = (object) false;
        this.columnTimeZone.DefaultValue = (object) 0M;
        this.columnManualFancierCount.DefaultValue = (object) 0;
        this.columnManualPigeonCount.DefaultValue = (object) 0;
        this.columnDistance.DefaultValue = (object) 0M;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.InformationRow NewInformationRow() => (CalculationDataSet.InformationRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new CalculationDataSet.InformationRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (CalculationDataSet.InformationRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.InformationRowChanged == null)
          return;
        this.InformationRowChanged((object) this, new CalculationDataSet.InformationRowChangeEvent((CalculationDataSet.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.InformationRowChanging == null)
          return;
        this.InformationRowChanging((object) this, new CalculationDataSet.InformationRowChangeEvent((CalculationDataSet.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.InformationRowDeleted == null)
          return;
        this.InformationRowDeleted((object) this, new CalculationDataSet.InformationRowChangeEvent((CalculationDataSet.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.InformationRowDeleting == null)
          return;
        this.InformationRowDeleting((object) this, new CalculationDataSet.InformationRowChangeEvent((CalculationDataSet.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveInformationRow(CalculationDataSet.InformationRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        CalculationDataSet calculationDataSet = new CalculationDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = calculationDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (InformationDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = calculationDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              MemoryStream memoryStream3 = memoryStream2;
              current.Write((Stream) memoryStream3);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void InformationRowChangeEventHandler(
      object sender,
      CalculationDataSet.InformationRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void ReadOutsRowChangeEventHandler(
      object sender,
      CalculationDataSet.ReadOutsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void ResultsRowChangeEventHandler(
      object sender,
      CalculationDataSet.ResultsRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class ReadOutsDataTable : TypedTableBase<CalculationDataSet.ReadOutsRow>
    {
      private DataColumn columnID;
      private DataColumn columnFileName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutsDataTable()
      {
        this.TableName = "ReadOuts";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ReadOutsDataTable(DataTable table)
      {
        this.TableName = table.TableName;
        if (table.CaseSensitive != table.DataSet.CaseSensitive)
          this.CaseSensitive = table.CaseSensitive;
        if (table.Locale.ToString() != table.DataSet.Locale.ToString())
          this.Locale = table.Locale;
        if (table.Namespace != table.DataSet.Namespace)
          this.Namespace = table.Namespace;
        this.Prefix = table.Prefix;
        this.MinimumCapacity = table.MinimumCapacity;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected ReadOutsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FileNameColumn => this.columnFileName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ReadOutsRow this[int index] => (CalculationDataSet.ReadOutsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ReadOutsRowChangeEventHandler ReadOutsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ReadOutsRowChangeEventHandler ReadOutsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ReadOutsRowChangeEventHandler ReadOutsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event CalculationDataSet.ReadOutsRowChangeEventHandler ReadOutsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddReadOutsRow(CalculationDataSet.ReadOutsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ReadOutsRow AddReadOutsRow(string FileName)
      {
        CalculationDataSet.ReadOutsRow readOutsRow = (CalculationDataSet.ReadOutsRow) this.NewRow();
        object[] objArray = new object[2]
        {
          null,
          (object) FileName
        };
        readOutsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) readOutsRow);
        return readOutsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ReadOutsRow FindByID(int ID) => (CalculationDataSet.ReadOutsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        CalculationDataSet.ReadOutsDataTable readOutsDataTable = (CalculationDataSet.ReadOutsDataTable) base.Clone();
        readOutsDataTable.InitVars();
        return (DataTable) readOutsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new CalculationDataSet.ReadOutsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFileName = this.Columns["FileName"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFileName = new DataColumn("FileName", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFileName);
        this.Constraints.Add((Constraint) new UniqueConstraint("PKReadOuts", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFileName.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ReadOutsRow NewReadOutsRow() => (CalculationDataSet.ReadOutsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new CalculationDataSet.ReadOutsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (CalculationDataSet.ReadOutsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.ReadOutsRowChanged == null)
          return;
        this.ReadOutsRowChanged((object) this, new CalculationDataSet.ReadOutsRowChangeEvent((CalculationDataSet.ReadOutsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.ReadOutsRowChanging == null)
          return;
        this.ReadOutsRowChanging((object) this, new CalculationDataSet.ReadOutsRowChangeEvent((CalculationDataSet.ReadOutsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.ReadOutsRowDeleted == null)
          return;
        this.ReadOutsRowDeleted((object) this, new CalculationDataSet.ReadOutsRowChangeEvent((CalculationDataSet.ReadOutsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.ReadOutsRowDeleting == null)
          return;
        this.ReadOutsRowDeleting((object) this, new CalculationDataSet.ReadOutsRowChangeEvent((CalculationDataSet.ReadOutsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveReadOutsRow(CalculationDataSet.ReadOutsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        CalculationDataSet calculationDataSet = new CalculationDataSet();
        XmlSchemaAny xmlSchemaAny1 = new XmlSchemaAny();
        xmlSchemaAny1.Namespace = "http://www.w3.org/2001/XMLSchema";
        xmlSchemaAny1.MinOccurs = 0M;
        xmlSchemaAny1.MaxOccurs = Decimal.MaxValue;
        xmlSchemaAny1.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny1);
        XmlSchemaAny xmlSchemaAny2 = new XmlSchemaAny();
        xmlSchemaAny2.Namespace = "urn:schemas-microsoft-com:xml-diffgram-v1";
        xmlSchemaAny2.MinOccurs = 1M;
        xmlSchemaAny2.ProcessContents = XmlSchemaContentProcessing.Lax;
        xmlSchemaSequence.Items.Add((XmlSchemaObject) xmlSchemaAny2);
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "namespace",
          FixedValue = calculationDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (ReadOutsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = calculationDataSet.GetSchemaSerializable();
        if (xs.Contains(schemaSerializable.TargetNamespace))
        {
          MemoryStream memoryStream1 = new MemoryStream();
          MemoryStream memoryStream2 = new MemoryStream();
          try
          {
            schemaSerializable.Write((Stream) memoryStream1);
            IEnumerator enumerator = xs.Schemas(schemaSerializable.TargetNamespace).GetEnumerator();
            while (enumerator.MoveNext())
            {
              XmlSchema current = (XmlSchema) enumerator.Current;
              memoryStream2.SetLength(0L);
              MemoryStream memoryStream3 = memoryStream2;
              current.Write((Stream) memoryStream3);
              if (memoryStream1.Length == memoryStream2.Length)
              {
                memoryStream1.Position = 0L;
                memoryStream2.Position = 0L;
                do
                  ;
                while (memoryStream1.Position != memoryStream1.Length && memoryStream1.ReadByte() == memoryStream2.ReadByte());
                if (memoryStream1.Position == memoryStream1.Length)
                  return schemaComplexType;
              }
            }
          }
          finally
          {
            memoryStream1?.Close();
            memoryStream2?.Close();
          }
        }
        xs.Add(schemaSerializable);
        return schemaComplexType;
      }
    }

    public class InformationRow : DataRow
    {
      private CalculationDataSet.InformationDataTable tableInformation;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal InformationRow(DataRowBuilder rb)
        : base(rb)
        => this.tableInformation = (CalculationDataSet.InformationDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableInformation.IDColumn];
        set => this[this.tableInformation.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableInformation.NameColumn];
        set => this[this.tableInformation.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Club
      {
        get => this.IsClubNull() ? string.Empty : (string) this[this.tableInformation.ClubColumn];
        set => this[this.tableInformation.ClubColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Flight
      {
        get => this.IsFlightNull() ? string.Empty : (string) this[this.tableInformation.FlightColumn];
        set => this[this.tableInformation.FlightColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ReleaseTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.ReleaseTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReleaseTime' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.ReleaseTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Units
      {
        get => this.IsUnitsNull() ? string.Empty : (string) this[this.tableInformation.UnitsColumn];
        set => this[this.tableInformation.UnitsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Remarks
      {
        get => this.IsRemarksNull() ? string.Empty : (string) this[this.tableInformation.RemarksColumn];
        set => this[this.tableInformation.RemarksColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Prices
      {
        get => this.IsPricesNull() ? string.Empty : (string) this[this.tableInformation.PricesColumn];
        set => this[this.tableInformation.PricesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool AddFirstPigeonForFancier
      {
        get
        {
          try
          {
            return (bool) this[this.tableInformation.AddFirstPigeonForFancierColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'AddFirstPigeonForFancier' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.AddFirstPigeonForFancierColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int CoordinateY
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.CoordinateYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordinateY' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.CoordinateYColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int CoordinateX
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.CoordinateXColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordinateX' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.CoordinateXColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TotalBasketted
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.TotalBaskettedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalBasketted' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TotalBaskettedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TotalFanciers
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.TotalFanciersColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalFanciers' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TotalFanciersColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CoordinateXString
      {
        get => this.IsCoordinateXStringNull() ? string.Empty : (string) this[this.tableInformation.CoordinateXStringColumn];
        set => this[this.tableInformation.CoordinateXStringColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CoordinateYString
      {
        get => this.IsCoordinateYStringNull() ? string.Empty : (string) this[this.tableInformation.CoordinateYStringColumn];
        set => this[this.tableInformation.CoordinateYStringColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool TwoDayRace
      {
        get
        {
          try
          {
            return (bool) this[this.tableInformation.TwoDayRaceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TwoDayRace' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TwoDayRaceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime TwoDayRaceFrom
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.TwoDayRaceFromColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TwoDayRaceFrom' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TwoDayRaceFromColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime TwoDayRaceTo
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.TwoDayRaceToColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TwoDayRaceTo' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TwoDayRaceToColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TimeZone
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableInformation.TimeZoneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TimeZone' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TimeZoneColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ManualFancierCount
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.ManualFancierCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ManualFancierCount' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.ManualFancierCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ManualPigeonCount
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.ManualPigeonCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ManualPigeonCount' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.ManualPigeonCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Distance
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableInformation.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableInformation.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableInformation.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubNull() => this.IsNull(this.tableInformation.ClubColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubNull() => this[this.tableInformation.ClubColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightNull() => this.IsNull(this.tableInformation.FlightColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightNull() => this[this.tableInformation.FlightColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReleaseTimeNull() => this.IsNull(this.tableInformation.ReleaseTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReleaseTimeNull() => this[this.tableInformation.ReleaseTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsUnitsNull() => this.IsNull(this.tableInformation.UnitsColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetUnitsNull() => this[this.tableInformation.UnitsColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRemarksNull() => this.IsNull(this.tableInformation.RemarksColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRemarksNull() => this[this.tableInformation.RemarksColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPricesNull() => this.IsNull(this.tableInformation.PricesColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPricesNull() => this[this.tableInformation.PricesColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAddFirstPigeonForFancierNull() => this.IsNull(this.tableInformation.AddFirstPigeonForFancierColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAddFirstPigeonForFancierNull() => this[this.tableInformation.AddFirstPigeonForFancierColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordinateYNull() => this.IsNull(this.tableInformation.CoordinateYColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordinateYNull() => this[this.tableInformation.CoordinateYColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordinateXNull() => this.IsNull(this.tableInformation.CoordinateXColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordinateXNull() => this[this.tableInformation.CoordinateXColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalBaskettedNull() => this.IsNull(this.tableInformation.TotalBaskettedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalBaskettedNull() => this[this.tableInformation.TotalBaskettedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalFanciersNull() => this.IsNull(this.tableInformation.TotalFanciersColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalFanciersNull() => this[this.tableInformation.TotalFanciersColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordinateXStringNull() => this.IsNull(this.tableInformation.CoordinateXStringColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordinateXStringNull() => this[this.tableInformation.CoordinateXStringColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordinateYStringNull() => this.IsNull(this.tableInformation.CoordinateYStringColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordinateYStringNull() => this[this.tableInformation.CoordinateYStringColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTwoDayRaceNull() => this.IsNull(this.tableInformation.TwoDayRaceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTwoDayRaceNull() => this[this.tableInformation.TwoDayRaceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTwoDayRaceFromNull() => this.IsNull(this.tableInformation.TwoDayRaceFromColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTwoDayRaceFromNull() => this[this.tableInformation.TwoDayRaceFromColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTwoDayRaceToNull() => this.IsNull(this.tableInformation.TwoDayRaceToColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTwoDayRaceToNull() => this[this.tableInformation.TwoDayRaceToColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeZoneNull() => this.IsNull(this.tableInformation.TimeZoneColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeZoneNull() => this[this.tableInformation.TimeZoneColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsManualFancierCountNull() => this.IsNull(this.tableInformation.ManualFancierCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetManualFancierCountNull() => this[this.tableInformation.ManualFancierCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsManualPigeonCountNull() => this.IsNull(this.tableInformation.ManualPigeonCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetManualPigeonCountNull() => this[this.tableInformation.ManualPigeonCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableInformation.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableInformation.DistanceColumn] = Convert.DBNull;
    }

    public class ReadOutsRow : DataRow
    {
      private CalculationDataSet.ReadOutsDataTable tableReadOuts;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ReadOutsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableReadOuts = (CalculationDataSet.ReadOutsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableReadOuts.IDColumn];
        set => this[this.tableReadOuts.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FileName
      {
        get => this.IsFileNameNull() ? string.Empty : (string) this[this.tableReadOuts.FileNameColumn];
        set => this[this.tableReadOuts.FileNameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFileNameNull() => this.IsNull(this.tableReadOuts.FileNameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFileNameNull() => this[this.tableReadOuts.FileNameColumn] = Convert.DBNull;
    }

    public class ResultsRow : DataRow
    {
      private CalculationDataSet.ResultsDataTable tableResults;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ResultsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableResults = (CalculationDataSet.ResultsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableResults.IDColumn];
        set => this[this.tableResults.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.NumberColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.NumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FancierName
      {
        get => this.IsFancierNameNull() ? string.Empty : (string) this[this.tableResults.FancierNameColumn];
        set => this[this.tableResults.FancierNameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RingNumber
      {
        get => this.IsRingNumberNull() ? string.Empty : (string) this[this.tableResults.RingNumberColumn];
        set => this[this.tableResults.RingNumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ClockingTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableResults.ClockingTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClockingTime' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.ClockingTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Distance
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableResults.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DistanceString
      {
        get => this.IsDistanceStringNull() ? string.Empty : (string) this[this.tableResults.DistanceStringColumn];
        set => this[this.tableResults.DistanceStringColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Speed
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableResults.SpeedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Speed' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.SpeedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime CorrectedTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableResults.CorrectedTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CorrectedTime' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.CorrectedTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Basketed
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.BasketedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Basketed' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.BasketedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubID
      {
        get => this.IsClubIDNull() ? string.Empty : (string) this[this.tableResults.ClubIDColumn];
        set => this[this.tableResults.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position1
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.Position1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position1' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.Position1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position2
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.Position2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position2' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.Position2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position3
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.Position3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position3' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.Position3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position4
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.Position4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position4' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.Position4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double Percentage
      {
        get
        {
          try
          {
            return (double) this[this.tableResults.PercentageColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Percentage' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.PercentageColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double FCIAB
      {
        get
        {
          try
          {
            return (double) this[this.tableResults.FCIABColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FCIAB' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.FCIABColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double FCICD
      {
        get
        {
          try
          {
            return (double) this[this.tableResults.FCICDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FCICD' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.FCICDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double FCIE
      {
        get
        {
          try
          {
            return (double) this[this.tableResults.FCIEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FCIE' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.FCIEColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ReleaseTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableResults.ReleaseTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReleaseTime' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.ReleaseTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TotalBasketed
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.TotalBasketedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalBasketed' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.TotalBasketedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double FCI
      {
        get
        {
          try
          {
            return (double) this[this.tableResults.FCIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FCI' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.FCIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Flight
      {
        get => this.IsFlightNull() ? string.Empty : (string) this[this.tableResults.FlightColumn];
        set => this[this.tableResults.FlightColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int CorrectedTimeDigit
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.CorrectedTimeDigitColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CorrectedTimeDigit' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.CorrectedTimeDigitColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime FlightTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableResults.FlightTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightTime' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.FlightTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TeamNbr
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.TeamNbrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TeamNbr' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.TeamNbrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Points100
      {
        get
        {
          try
          {
            return (int) this[this.tableResults.Points100Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Points100' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.Points100Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NaamUnicode
      {
        get => this.IsNaamUnicodeNull() ? string.Empty : (string) this[this.tableResults.NaamUnicodeColumn];
        set => this[this.tableResults.NaamUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string GemeenteUnicode
      {
        get => this.IsGemeenteUnicodeNull() ? string.Empty : (string) this[this.tableResults.GemeenteUnicodeColumn];
        set => this[this.tableResults.GemeenteUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string License
      {
        get => this.IsLicenseNull() ? string.Empty : (string) this[this.tableResults.LicenseColumn];
        set => this[this.tableResults.LicenseColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal OveralPoints
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableResults.OveralPointsColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'OveralPoints' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.OveralPointsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TimeZone
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableResults.TimeZoneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TimeZone' in table 'Results' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableResults.TimeZoneColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumberNull() => this.IsNull(this.tableResults.NumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumberNull() => this[this.tableResults.NumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierNameNull() => this.IsNull(this.tableResults.FancierNameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierNameNull() => this[this.tableResults.FancierNameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRingNumberNull() => this.IsNull(this.tableResults.RingNumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRingNumberNull() => this[this.tableResults.RingNumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClockingTimeNull() => this.IsNull(this.tableResults.ClockingTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClockingTimeNull() => this[this.tableResults.ClockingTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableResults.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableResults.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceStringNull() => this.IsNull(this.tableResults.DistanceStringColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceStringNull() => this[this.tableResults.DistanceStringColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSpeedNull() => this.IsNull(this.tableResults.SpeedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSpeedNull() => this[this.tableResults.SpeedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCorrectedTimeNull() => this.IsNull(this.tableResults.CorrectedTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCorrectedTimeNull() => this[this.tableResults.CorrectedTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBasketedNull() => this.IsNull(this.tableResults.BasketedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBasketedNull() => this[this.tableResults.BasketedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tableResults.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tableResults.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition1Null() => this.IsNull(this.tableResults.Position1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition1Null() => this[this.tableResults.Position1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition2Null() => this.IsNull(this.tableResults.Position2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition2Null() => this[this.tableResults.Position2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition3Null() => this.IsNull(this.tableResults.Position3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition3Null() => this[this.tableResults.Position3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition4Null() => this.IsNull(this.tableResults.Position4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition4Null() => this[this.tableResults.Position4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPercentageNull() => this.IsNull(this.tableResults.PercentageColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPercentageNull() => this[this.tableResults.PercentageColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCIABNull() => this.IsNull(this.tableResults.FCIABColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCIABNull() => this[this.tableResults.FCIABColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCICDNull() => this.IsNull(this.tableResults.FCICDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCICDNull() => this[this.tableResults.FCICDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCIENull() => this.IsNull(this.tableResults.FCIEColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCIENull() => this[this.tableResults.FCIEColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReleaseTimeNull() => this.IsNull(this.tableResults.ReleaseTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReleaseTimeNull() => this[this.tableResults.ReleaseTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalBasketedNull() => this.IsNull(this.tableResults.TotalBasketedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalBasketedNull() => this[this.tableResults.TotalBasketedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCINull() => this.IsNull(this.tableResults.FCIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCINull() => this[this.tableResults.FCIColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightNull() => this.IsNull(this.tableResults.FlightColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightNull() => this[this.tableResults.FlightColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCorrectedTimeDigitNull() => this.IsNull(this.tableResults.CorrectedTimeDigitColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCorrectedTimeDigitNull() => this[this.tableResults.CorrectedTimeDigitColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightTimeNull() => this.IsNull(this.tableResults.FlightTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightTimeNull() => this[this.tableResults.FlightTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTeamNbrNull() => this.IsNull(this.tableResults.TeamNbrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTeamNbrNull() => this[this.tableResults.TeamNbrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPoints100Null() => this.IsNull(this.tableResults.Points100Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPoints100Null() => this[this.tableResults.Points100Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNaamUnicodeNull() => this.IsNull(this.tableResults.NaamUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNaamUnicodeNull() => this[this.tableResults.NaamUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGemeenteUnicodeNull() => this.IsNull(this.tableResults.GemeenteUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGemeenteUnicodeNull() => this[this.tableResults.GemeenteUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLicenseNull() => this.IsNull(this.tableResults.LicenseColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLicenseNull() => this[this.tableResults.LicenseColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOveralPointsNull() => this.IsNull(this.tableResults.OveralPointsColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOveralPointsNull() => this[this.tableResults.OveralPointsColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeZoneNull() => this.IsNull(this.tableResults.TimeZoneColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeZoneNull() => this[this.tableResults.TimeZoneColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class InformationRowChangeEvent : EventArgs
    {
      private CalculationDataSet.InformationRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public InformationRowChangeEvent(CalculationDataSet.InformationRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.InformationRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class ReadOutsRowChangeEvent : EventArgs
    {
      private CalculationDataSet.ReadOutsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutsRowChangeEvent(CalculationDataSet.ReadOutsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ReadOutsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class ResultsRowChangeEvent : EventArgs
    {
      private CalculationDataSet.ResultsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ResultsRowChangeEvent(CalculationDataSet.ResultsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public CalculationDataSet.ResultsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
