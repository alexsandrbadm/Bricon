// Decompiled with JetBrains decompiler
// Type: BriconLib.PrintManager.ReadOutDataSet
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

namespace BriconLib.PrintManager
{
  [DesignerCategory("code")]
  [ToolboxItem(true)]
  [XmlSchemaProvider("GetTypedDataSetSchema")]
  [XmlRoot("ReadOutDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class ReadOutDataSet : DataSet
  {
    private ReadOutDataSet.FancierDataTable tableFancier;
    private ReadOutDataSet.PigeonsDataTable tablePigeons;
    private ReadOutDataSet.TimersDataTable tableTimers;
    private ReadOutDataSet.PigeonsMonitorDataTable tablePigeonsMonitor;
    private ReadOutDataSet.PoulLetterDataTable tablePoulLetter;
    private ReadOutDataSet.RaceNamesDataTable tableRaceNames;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public ReadOutDataSet()
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
    protected ReadOutDataSet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (Fancier)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.FancierDataTable(dataSet.Tables[nameof (Fancier)]));
          if (dataSet.Tables[nameof (Pigeons)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.PigeonsDataTable(dataSet.Tables[nameof (Pigeons)]));
          if (dataSet.Tables[nameof (Timers)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.TimersDataTable(dataSet.Tables[nameof (Timers)]));
          if (dataSet.Tables[nameof (PigeonsMonitor)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.PigeonsMonitorDataTable(dataSet.Tables[nameof (PigeonsMonitor)]));
          if (dataSet.Tables[nameof (PoulLetter)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.PoulLetterDataTable(dataSet.Tables[nameof (PoulLetter)]));
          if (dataSet.Tables[nameof (RaceNames)] != null)
            base.Tables.Add((DataTable) new ReadOutDataSet.RaceNamesDataTable(dataSet.Tables[nameof (RaceNames)]));
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
    public ReadOutDataSet.FancierDataTable Fancier => this.tableFancier;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReadOutDataSet.PigeonsDataTable Pigeons => this.tablePigeons;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReadOutDataSet.TimersDataTable Timers => this.tableTimers;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReadOutDataSet.PigeonsMonitorDataTable PigeonsMonitor => this.tablePigeonsMonitor;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReadOutDataSet.PoulLetterDataTable PoulLetter => this.tablePoulLetter;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ReadOutDataSet.RaceNamesDataTable RaceNames => this.tableRaceNames;

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
      ReadOutDataSet readOutDataSet = (ReadOutDataSet) base.Clone();
      readOutDataSet.InitVars();
      readOutDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) readOutDataSet;
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
        if (dataSet.Tables["Fancier"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.FancierDataTable(dataSet.Tables["Fancier"]));
        if (dataSet.Tables["Pigeons"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.PigeonsDataTable(dataSet.Tables["Pigeons"]));
        if (dataSet.Tables["Timers"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.TimersDataTable(dataSet.Tables["Timers"]));
        if (dataSet.Tables["PigeonsMonitor"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.PigeonsMonitorDataTable(dataSet.Tables["PigeonsMonitor"]));
        if (dataSet.Tables["PoulLetter"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.PoulLetterDataTable(dataSet.Tables["PoulLetter"]));
        if (dataSet.Tables["RaceNames"] != null)
          base.Tables.Add((DataTable) new ReadOutDataSet.RaceNamesDataTable(dataSet.Tables["RaceNames"]));
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
      this.tableFancier = (ReadOutDataSet.FancierDataTable) base.Tables["Fancier"];
      if (initTable && this.tableFancier != null)
        this.tableFancier.InitVars();
      this.tablePigeons = (ReadOutDataSet.PigeonsDataTable) base.Tables["Pigeons"];
      if (initTable && this.tablePigeons != null)
        this.tablePigeons.InitVars();
      this.tableTimers = (ReadOutDataSet.TimersDataTable) base.Tables["Timers"];
      if (initTable && this.tableTimers != null)
        this.tableTimers.InitVars();
      this.tablePigeonsMonitor = (ReadOutDataSet.PigeonsMonitorDataTable) base.Tables["PigeonsMonitor"];
      if (initTable && this.tablePigeonsMonitor != null)
        this.tablePigeonsMonitor.InitVars();
      this.tablePoulLetter = (ReadOutDataSet.PoulLetterDataTable) base.Tables["PoulLetter"];
      if (initTable && this.tablePoulLetter != null)
        this.tablePoulLetter.InitVars();
      this.tableRaceNames = (ReadOutDataSet.RaceNamesDataTable) base.Tables["RaceNames"];
      if (!initTable || this.tableRaceNames == null)
        return;
      this.tableRaceNames.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (ReadOutDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/ReadOutDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableFancier = new ReadOutDataSet.FancierDataTable();
      base.Tables.Add((DataTable) this.tableFancier);
      this.tablePigeons = new ReadOutDataSet.PigeonsDataTable();
      base.Tables.Add((DataTable) this.tablePigeons);
      this.tableTimers = new ReadOutDataSet.TimersDataTable();
      base.Tables.Add((DataTable) this.tableTimers);
      this.tablePigeonsMonitor = new ReadOutDataSet.PigeonsMonitorDataTable();
      base.Tables.Add((DataTable) this.tablePigeonsMonitor);
      this.tablePoulLetter = new ReadOutDataSet.PoulLetterDataTable();
      base.Tables.Add((DataTable) this.tablePoulLetter);
      this.tableRaceNames = new ReadOutDataSet.RaceNamesDataTable();
      base.Tables.Add((DataTable) this.tableRaceNames);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeFancier() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializePigeons() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeTimers() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializePigeonsMonitor() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializePoulLetter() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeRaceNames() => false;

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
      ReadOutDataSet readOutDataSet = new ReadOutDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = readOutDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public class RaceNamesDataTable : TypedTableBase<ReadOutDataSet.RaceNamesRow>
    {
      private DataColumn columnID;
      private DataColumn columnFlightID;
      private DataColumn columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public RaceNamesDataTable()
      {
        this.TableName = "RaceNames";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal RaceNamesDataTable(DataTable table)
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
      protected RaceNamesDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightIDColumn => this.columnFlightID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.RaceNamesRow this[int index] => (ReadOutDataSet.RaceNamesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.RaceNamesRowChangeEventHandler RaceNamesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.RaceNamesRowChangeEventHandler RaceNamesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.RaceNamesRowChangeEventHandler RaceNamesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.RaceNamesRowChangeEventHandler RaceNamesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddRaceNamesRow(ReadOutDataSet.RaceNamesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.RaceNamesRow AddRaceNamesRow(string FlightID, string Name)
      {
        ReadOutDataSet.RaceNamesRow raceNamesRow = (ReadOutDataSet.RaceNamesRow) this.NewRow();
        object[] objArray = new object[3]
        {
          null,
          (object) FlightID,
          (object) Name
        };
        raceNamesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) raceNamesRow);
        return raceNamesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.RaceNamesRow FindByID(int ID) => (ReadOutDataSet.RaceNamesRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.RaceNamesDataTable raceNamesDataTable = (ReadOutDataSet.RaceNamesDataTable) base.Clone();
        raceNamesDataTable.InitVars();
        return (DataTable) raceNamesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.RaceNamesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFlightID = this.Columns["FlightID"];
        this.columnName = this.Columns["Name"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFlightID = new DataColumn("FlightID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.Constraints.Add((Constraint) new UniqueConstraint("RaceNamesKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.RaceNamesRow NewRaceNamesRow() => (ReadOutDataSet.RaceNamesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.RaceNamesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.RaceNamesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.RaceNamesRowChanged == null)
          return;
        this.RaceNamesRowChanged((object) this, new ReadOutDataSet.RaceNamesRowChangeEvent((ReadOutDataSet.RaceNamesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.RaceNamesRowChanging == null)
          return;
        this.RaceNamesRowChanging((object) this, new ReadOutDataSet.RaceNamesRowChangeEvent((ReadOutDataSet.RaceNamesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.RaceNamesRowDeleted == null)
          return;
        this.RaceNamesRowDeleted((object) this, new ReadOutDataSet.RaceNamesRowChangeEvent((ReadOutDataSet.RaceNamesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.RaceNamesRowDeleting == null)
          return;
        this.RaceNamesRowDeleting((object) this, new ReadOutDataSet.RaceNamesRowChangeEvent((ReadOutDataSet.RaceNamesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveRaceNamesRow(ReadOutDataSet.RaceNamesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (RaceNamesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public class PoulLetterDataTable : TypedTableBase<ReadOutDataSet.PoulLetterRow>
    {
      private DataColumn columnID;
      private DataColumn columnCol0;
      private DataColumn columnCol1;
      private DataColumn columnCol2;
      private DataColumn columnCol3;
      private DataColumn columnCol4;
      private DataColumn columnCol5;
      private DataColumn columnCol6;
      private DataColumn columnCol7;
      private DataColumn columnCol8;
      private DataColumn columnCol9;
      private DataColumn columnCol10;
      private DataColumn columnCol11;
      private DataColumn columnCol12;
      private DataColumn columnCol13;
      private DataColumn columnCol14;
      private DataColumn columnCol15;
      private DataColumn columnCol16;
      private DataColumn columnCol17;
      private DataColumn columnCol18;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PoulLetterDataTable()
      {
        this.TableName = "PoulLetter";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PoulLetterDataTable(DataTable table)
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
      protected PoulLetterDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col0Column => this.columnCol0;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col1Column => this.columnCol1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col2Column => this.columnCol2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col3Column => this.columnCol3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col4Column => this.columnCol4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col5Column => this.columnCol5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col6Column => this.columnCol6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col7Column => this.columnCol7;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col8Column => this.columnCol8;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col9Column => this.columnCol9;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col10Column => this.columnCol10;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col11Column => this.columnCol11;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col12Column => this.columnCol12;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col13Column => this.columnCol13;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col14Column => this.columnCol14;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col15Column => this.columnCol15;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col16Column => this.columnCol16;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col17Column => this.columnCol17;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Col18Column => this.columnCol18;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PoulLetterRow this[int index] => (ReadOutDataSet.PoulLetterRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PoulLetterRowChangeEventHandler PoulLetterRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PoulLetterRowChangeEventHandler PoulLetterRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PoulLetterRowChangeEventHandler PoulLetterRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PoulLetterRowChangeEventHandler PoulLetterRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddPoulLetterRow(ReadOutDataSet.PoulLetterRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PoulLetterRow AddPoulLetterRow(
        string Col0,
        ushort Col1,
        ushort Col2,
        ushort Col3,
        ushort Col4,
        ushort Col5,
        ushort Col6,
        ushort Col7,
        ushort Col8,
        ushort Col9,
        ushort Col10,
        ushort Col11,
        ushort Col12,
        ushort Col13,
        ushort Col14,
        ushort Col15,
        ushort Col16,
        ushort Col17,
        ushort Col18)
      {
        ReadOutDataSet.PoulLetterRow poulLetterRow = (ReadOutDataSet.PoulLetterRow) this.NewRow();
        object[] objArray = new object[20]
        {
          null,
          (object) Col0,
          (object) Col1,
          (object) Col2,
          (object) Col3,
          (object) Col4,
          (object) Col5,
          (object) Col6,
          (object) Col7,
          (object) Col8,
          (object) Col9,
          (object) Col10,
          (object) Col11,
          (object) Col12,
          (object) Col13,
          (object) Col14,
          (object) Col15,
          (object) Col16,
          (object) Col17,
          (object) Col18
        };
        poulLetterRow.ItemArray = objArray;
        this.Rows.Add((DataRow) poulLetterRow);
        return poulLetterRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PoulLetterRow FindByID(int ID) => (ReadOutDataSet.PoulLetterRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.PoulLetterDataTable poulLetterDataTable = (ReadOutDataSet.PoulLetterDataTable) base.Clone();
        poulLetterDataTable.InitVars();
        return (DataTable) poulLetterDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.PoulLetterDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnCol0 = this.Columns["Col0"];
        this.columnCol1 = this.Columns["Col1"];
        this.columnCol2 = this.Columns["Col2"];
        this.columnCol3 = this.Columns["Col3"];
        this.columnCol4 = this.Columns["Col4"];
        this.columnCol5 = this.Columns["Col5"];
        this.columnCol6 = this.Columns["Col6"];
        this.columnCol7 = this.Columns["Col7"];
        this.columnCol8 = this.Columns["Col8"];
        this.columnCol9 = this.Columns["Col9"];
        this.columnCol10 = this.Columns["Col10"];
        this.columnCol11 = this.Columns["Col11"];
        this.columnCol12 = this.Columns["Col12"];
        this.columnCol13 = this.Columns["Col13"];
        this.columnCol14 = this.Columns["Col14"];
        this.columnCol15 = this.Columns["Col15"];
        this.columnCol16 = this.Columns["Col16"];
        this.columnCol17 = this.Columns["Col17"];
        this.columnCol18 = this.Columns["Col18"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnCol0 = new DataColumn("Col0", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol0);
        this.columnCol1 = new DataColumn("Col1", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol1);
        this.columnCol2 = new DataColumn("Col2", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol2);
        this.columnCol3 = new DataColumn("Col3", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol3);
        this.columnCol4 = new DataColumn("Col4", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol4);
        this.columnCol5 = new DataColumn("Col5", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol5);
        this.columnCol6 = new DataColumn("Col6", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol6);
        this.columnCol7 = new DataColumn("Col7", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol7);
        this.columnCol8 = new DataColumn("Col8", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol8);
        this.columnCol9 = new DataColumn("Col9", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol9);
        this.columnCol10 = new DataColumn("Col10", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol10);
        this.columnCol11 = new DataColumn("Col11", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol11);
        this.columnCol12 = new DataColumn("Col12", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol12);
        this.columnCol13 = new DataColumn("Col13", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol13);
        this.columnCol14 = new DataColumn("Col14", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol14);
        this.columnCol15 = new DataColumn("Col15", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol15);
        this.columnCol16 = new DataColumn("Col16", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol16);
        this.columnCol17 = new DataColumn("Col17", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol17);
        this.columnCol18 = new DataColumn("Col18", typeof (ushort), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCol18);
        this.Constraints.Add((Constraint) new UniqueConstraint("PoulLetterKey", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnCol0.Caption = "Niv";
        this.columnCol1.Caption = "1";
        this.columnCol2.Caption = "2";
        this.columnCol3.Caption = "3";
        this.columnCol4.Caption = "4";
        this.columnCol5.Caption = "5";
        this.columnCol6.Caption = "6";
        this.columnCol7.Caption = "7";
        this.columnCol8.Caption = "8";
        this.columnCol9.Caption = "9";
        this.columnCol10.Caption = "10";
        this.columnCol11.Caption = "11";
        this.columnCol12.Caption = "12";
        this.columnCol13.Caption = "13";
        this.columnCol14.Caption = "14";
        this.columnCol15.Caption = "15";
        this.columnCol16.Caption = "16";
        this.columnCol17.Caption = "17";
        this.columnCol18.Caption = "18";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PoulLetterRow NewPoulLetterRow() => (ReadOutDataSet.PoulLetterRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.PoulLetterRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.PoulLetterRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PoulLetterRowChanged == null)
          return;
        this.PoulLetterRowChanged((object) this, new ReadOutDataSet.PoulLetterRowChangeEvent((ReadOutDataSet.PoulLetterRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PoulLetterRowChanging == null)
          return;
        this.PoulLetterRowChanging((object) this, new ReadOutDataSet.PoulLetterRowChangeEvent((ReadOutDataSet.PoulLetterRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PoulLetterRowDeleted == null)
          return;
        this.PoulLetterRowDeleted((object) this, new ReadOutDataSet.PoulLetterRowChangeEvent((ReadOutDataSet.PoulLetterRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PoulLetterRowDeleting == null)
          return;
        this.PoulLetterRowDeleting((object) this, new ReadOutDataSet.PoulLetterRowChangeEvent((ReadOutDataSet.PoulLetterRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovePoulLetterRow(ReadOutDataSet.PoulLetterRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PoulLetterDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public delegate void FancierRowChangeEventHandler(
      object sender,
      ReadOutDataSet.FancierRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void PigeonsRowChangeEventHandler(
      object sender,
      ReadOutDataSet.PigeonsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void TimersRowChangeEventHandler(
      object sender,
      ReadOutDataSet.TimersRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void PigeonsMonitorRowChangeEventHandler(
      object sender,
      ReadOutDataSet.PigeonsMonitorRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void PoulLetterRowChangeEventHandler(
      object sender,
      ReadOutDataSet.PoulLetterRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void RaceNamesRowChangeEventHandler(
      object sender,
      ReadOutDataSet.RaceNamesRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class FancierDataTable : TypedTableBase<ReadOutDataSet.FancierRow>
    {
      private DataColumn columnID;
      private DataColumn columnLicense;
      private DataColumn columnName;
      private DataColumn columnAddress;
      private DataColumn columnZipCode;
      private DataColumn columnCity;
      private DataColumn columnCoordX;
      private DataColumn columnCoordY;
      private DataColumn columnSerial;
      private DataColumn columnDistance;
      private DataColumn columnDistanceUnit;
      private DataColumn columnDistanceString;
      private DataColumn columnFlightDesignated;
      private DataColumn columnNaamUnicode;
      private DataColumn columnGemeenteUnicode;
      private DataColumn columnTimeZone;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public FancierDataTable()
      {
        this.TableName = "Fancier";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal FancierDataTable(DataTable table)
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
      protected FancierDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LicenseColumn => this.columnLicense;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn AddressColumn => this.columnAddress;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ZipCodeColumn => this.columnZipCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CityColumn => this.columnCity;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordXColumn => this.columnCoordX;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CoordYColumn => this.columnCoordY;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SerialColumn => this.columnSerial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceUnitColumn => this.columnDistanceUnit;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceStringColumn => this.columnDistanceString;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightDesignatedColumn => this.columnFlightDesignated;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NaamUnicodeColumn => this.columnNaamUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GemeenteUnicodeColumn => this.columnGemeenteUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeZoneColumn => this.columnTimeZone;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.FancierRow this[int index] => (ReadOutDataSet.FancierRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.FancierRowChangeEventHandler FancierRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.FancierRowChangeEventHandler FancierRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.FancierRowChangeEventHandler FancierRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.FancierRowChangeEventHandler FancierRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddFancierRow(ReadOutDataSet.FancierRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.FancierRow AddFancierRow(
        string License,
        string Name,
        string Address,
        string ZipCode,
        string City,
        string CoordX,
        string CoordY,
        string Serial,
        Decimal Distance,
        string DistanceUnit,
        string DistanceString,
        string FlightDesignated,
        string NaamUnicode,
        string GemeenteUnicode,
        Decimal TimeZone)
      {
        ReadOutDataSet.FancierRow fancierRow = (ReadOutDataSet.FancierRow) this.NewRow();
        object[] objArray = new object[16]
        {
          null,
          (object) License,
          (object) Name,
          (object) Address,
          (object) ZipCode,
          (object) City,
          (object) CoordX,
          (object) CoordY,
          (object) Serial,
          (object) Distance,
          (object) DistanceUnit,
          (object) DistanceString,
          (object) FlightDesignated,
          (object) NaamUnicode,
          (object) GemeenteUnicode,
          (object) TimeZone
        };
        fancierRow.ItemArray = objArray;
        this.Rows.Add((DataRow) fancierRow);
        return fancierRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.FancierRow FindByID(int ID) => (ReadOutDataSet.FancierRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.FancierDataTable fancierDataTable = (ReadOutDataSet.FancierDataTable) base.Clone();
        fancierDataTable.InitVars();
        return (DataTable) fancierDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.FancierDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnLicense = this.Columns["License"];
        this.columnName = this.Columns["Name"];
        this.columnAddress = this.Columns["Address"];
        this.columnZipCode = this.Columns["ZipCode"];
        this.columnCity = this.Columns["City"];
        this.columnCoordX = this.Columns["CoordX"];
        this.columnCoordY = this.Columns["CoordY"];
        this.columnSerial = this.Columns["Serial"];
        this.columnDistance = this.Columns["Distance"];
        this.columnDistanceUnit = this.Columns["DistanceUnit"];
        this.columnDistanceString = this.Columns["DistanceString"];
        this.columnFlightDesignated = this.Columns["FlightDesignated"];
        this.columnNaamUnicode = this.Columns["NaamUnicode"];
        this.columnGemeenteUnicode = this.Columns["GemeenteUnicode"];
        this.columnTimeZone = this.Columns["TimeZone"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnLicense = new DataColumn("License", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLicense);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnAddress = new DataColumn("Address", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAddress);
        this.columnZipCode = new DataColumn("ZipCode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnZipCode);
        this.columnCity = new DataColumn("City", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCity);
        this.columnCoordX = new DataColumn("CoordX", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordX);
        this.columnCoordY = new DataColumn("CoordY", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCoordY);
        this.columnSerial = new DataColumn("Serial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerial);
        this.columnDistance = new DataColumn("Distance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnDistanceUnit = new DataColumn("DistanceUnit", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceUnit);
        this.columnDistanceString = new DataColumn("DistanceString", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceString);
        this.columnFlightDesignated = new DataColumn("FlightDesignated", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightDesignated);
        this.columnNaamUnicode = new DataColumn("NaamUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNaamUnicode);
        this.columnGemeenteUnicode = new DataColumn("GemeenteUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGemeenteUnicode);
        this.columnTimeZone = new DataColumn("TimeZone", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeZone);
        this.Constraints.Add((Constraint) new UniqueConstraint("FancierKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnDistance.DefaultValue = (object) 0M;
        this.columnDistanceUnit.DefaultValue = (object) "Metric";
        this.columnDistanceString.DefaultValue = (object) "";
        this.columnNaamUnicode.DefaultValue = (object) "";
        this.columnNaamUnicode.MaxLength = 50;
        this.columnGemeenteUnicode.DefaultValue = (object) "";
        this.columnGemeenteUnicode.MaxLength = 50;
        this.columnTimeZone.DefaultValue = (object) 0M;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.FancierRow NewFancierRow() => (ReadOutDataSet.FancierRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.FancierRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.FancierRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.FancierRowChanged == null)
          return;
        this.FancierRowChanged((object) this, new ReadOutDataSet.FancierRowChangeEvent((ReadOutDataSet.FancierRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.FancierRowChanging == null)
          return;
        this.FancierRowChanging((object) this, new ReadOutDataSet.FancierRowChangeEvent((ReadOutDataSet.FancierRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.FancierRowDeleted == null)
          return;
        this.FancierRowDeleted((object) this, new ReadOutDataSet.FancierRowChangeEvent((ReadOutDataSet.FancierRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.FancierRowDeleting == null)
          return;
        this.FancierRowDeleting((object) this, new ReadOutDataSet.FancierRowChangeEvent((ReadOutDataSet.FancierRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveFancierRow(ReadOutDataSet.FancierRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (FancierDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public class PigeonsDataTable : TypedTableBase<ReadOutDataSet.PigeonsRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnElBand;
      private DataColumn columnFedBand;
      private DataColumn columnClubID;
      private DataColumn columnFlightID;
      private DataColumn columnPosition1;
      private DataColumn columnPosition2;
      private DataColumn columnPosition3;
      private DataColumn columnPosition4;
      private DataColumn columnTime;
      private DataColumn columnEvaluation;
      private DataColumn columnNr;
      private DataColumn columnTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsDataTable()
      {
        this.TableName = "Pigeons";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsDataTable(DataTable table)
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
      protected PigeonsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FancierIDColumn => this.columnFancierID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ElBandColumn => this.columnElBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FedBandColumn => this.columnFedBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightIDColumn => this.columnFlightID;

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
      public DataColumn TimeColumn => this.columnTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EvaluationColumn => this.columnEvaluation;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NrColumn => this.columnNr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TeamNbrColumn => this.columnTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsRow this[int index] => (ReadOutDataSet.PigeonsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsRowChangeEventHandler PigeonsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsRowChangeEventHandler PigeonsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddPigeonsRow(ReadOutDataSet.PigeonsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsRow AddPigeonsRow(
        int FancierID,
        string ElBand,
        string FedBand,
        string ClubID,
        string FlightID,
        int Position1,
        int Position2,
        int Position3,
        int Position4,
        DateTime Time,
        string Evaluation,
        string Nr,
        int TeamNbr)
      {
        ReadOutDataSet.PigeonsRow pigeonsRow = (ReadOutDataSet.PigeonsRow) this.NewRow();
        object[] objArray = new object[14]
        {
          null,
          (object) FancierID,
          (object) ElBand,
          (object) FedBand,
          (object) ClubID,
          (object) FlightID,
          (object) Position1,
          (object) Position2,
          (object) Position3,
          (object) Position4,
          (object) Time,
          (object) Evaluation,
          (object) Nr,
          (object) TeamNbr
        };
        pigeonsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) pigeonsRow);
        return pigeonsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsRow FindByID(int ID) => (ReadOutDataSet.PigeonsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.PigeonsDataTable pigeonsDataTable = (ReadOutDataSet.PigeonsDataTable) base.Clone();
        pigeonsDataTable.InitVars();
        return (DataTable) pigeonsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.PigeonsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnElBand = this.Columns["ElBand"];
        this.columnFedBand = this.Columns["FedBand"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnFlightID = this.Columns["FlightID"];
        this.columnPosition1 = this.Columns["Position1"];
        this.columnPosition2 = this.Columns["Position2"];
        this.columnPosition3 = this.Columns["Position3"];
        this.columnPosition4 = this.Columns["Position4"];
        this.columnTime = this.Columns["Time"];
        this.columnEvaluation = this.Columns["Evaluation"];
        this.columnNr = this.Columns["Nr"];
        this.columnTeamNbr = this.Columns["TeamNbr"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnElBand = new DataColumn("ElBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnElBand);
        this.columnFedBand = new DataColumn("FedBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFedBand);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnFlightID = new DataColumn("FlightID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightID);
        this.columnPosition1 = new DataColumn("Position1", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition1);
        this.columnPosition2 = new DataColumn("Position2", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition2);
        this.columnPosition3 = new DataColumn("Position3", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition3);
        this.columnPosition4 = new DataColumn("Position4", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition4);
        this.columnTime = new DataColumn("Time", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTime);
        this.columnEvaluation = new DataColumn("Evaluation", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEvaluation);
        this.columnNr = new DataColumn("Nr", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNr);
        this.columnTeamNbr = new DataColumn("TeamNbr", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTeamNbr);
        this.Constraints.Add((Constraint) new UniqueConstraint("PigeonsKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierID.DefaultValue = (object) 0;
        this.columnTeamNbr.DefaultValue = (object) 0;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsRow NewPigeonsRow() => (ReadOutDataSet.PigeonsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.PigeonsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.PigeonsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PigeonsRowChanged == null)
          return;
        this.PigeonsRowChanged((object) this, new ReadOutDataSet.PigeonsRowChangeEvent((ReadOutDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PigeonsRowChanging == null)
          return;
        this.PigeonsRowChanging((object) this, new ReadOutDataSet.PigeonsRowChangeEvent((ReadOutDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PigeonsRowDeleted == null)
          return;
        this.PigeonsRowDeleted((object) this, new ReadOutDataSet.PigeonsRowChangeEvent((ReadOutDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PigeonsRowDeleting == null)
          return;
        this.PigeonsRowDeleting((object) this, new ReadOutDataSet.PigeonsRowChangeEvent((ReadOutDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovePigeonsRow(ReadOutDataSet.PigeonsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PigeonsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public class TimersDataTable : TypedTableBase<ReadOutDataSet.TimersRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnClubID;
      private DataColumn columnFlightID;
      private DataColumn columnBasketingMasterTime;
      private DataColumn columnBasketingInternalTime;
      private DataColumn columnBasketingDiff;
      private DataColumn columnReadOutMasterTime;
      private DataColumn columnReadOutInternalTime;
      private DataColumn columnReadOutDiff;
      private DataColumn columnDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public TimersDataTable()
      {
        this.TableName = "Timers";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal TimersDataTable(DataTable table)
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
      protected TimersDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FancierIDColumn => this.columnFancierID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightIDColumn => this.columnFlightID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BasketingMasterTimeColumn => this.columnBasketingMasterTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BasketingInternalTimeColumn => this.columnBasketingInternalTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BasketingDiffColumn => this.columnBasketingDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReadOutMasterTimeColumn => this.columnReadOutMasterTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReadOutInternalTimeColumn => this.columnReadOutInternalTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReadOutDiffColumn => this.columnReadOutDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DiffColumn => this.columnDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.TimersRow this[int index] => (ReadOutDataSet.TimersRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.TimersRowChangeEventHandler TimersRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.TimersRowChangeEventHandler TimersRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.TimersRowChangeEventHandler TimersRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.TimersRowChangeEventHandler TimersRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddTimersRow(ReadOutDataSet.TimersRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.TimersRow AddTimersRow(
        int FancierID,
        string ClubID,
        string FlightID,
        DateTime BasketingMasterTime,
        DateTime BasketingInternalTime,
        string BasketingDiff,
        DateTime ReadOutMasterTime,
        DateTime ReadOutInternalTime,
        string ReadOutDiff,
        string Diff)
      {
        ReadOutDataSet.TimersRow timersRow = (ReadOutDataSet.TimersRow) this.NewRow();
        object[] objArray = new object[11]
        {
          null,
          (object) FancierID,
          (object) ClubID,
          (object) FlightID,
          (object) BasketingMasterTime,
          (object) BasketingInternalTime,
          (object) BasketingDiff,
          (object) ReadOutMasterTime,
          (object) ReadOutInternalTime,
          (object) ReadOutDiff,
          (object) Diff
        };
        timersRow.ItemArray = objArray;
        this.Rows.Add((DataRow) timersRow);
        return timersRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.TimersRow FindByID(int ID) => (ReadOutDataSet.TimersRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.TimersDataTable timersDataTable = (ReadOutDataSet.TimersDataTable) base.Clone();
        timersDataTable.InitVars();
        return (DataTable) timersDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.TimersDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnFlightID = this.Columns["FlightID"];
        this.columnBasketingMasterTime = this.Columns["BasketingMasterTime"];
        this.columnBasketingInternalTime = this.Columns["BasketingInternalTime"];
        this.columnBasketingDiff = this.Columns["BasketingDiff"];
        this.columnReadOutMasterTime = this.Columns["ReadOutMasterTime"];
        this.columnReadOutInternalTime = this.Columns["ReadOutInternalTime"];
        this.columnReadOutDiff = this.Columns["ReadOutDiff"];
        this.columnDiff = this.Columns["Diff"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnFlightID = new DataColumn("FlightID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightID);
        this.columnBasketingMasterTime = new DataColumn("BasketingMasterTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBasketingMasterTime);
        this.columnBasketingInternalTime = new DataColumn("BasketingInternalTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBasketingInternalTime);
        this.columnBasketingDiff = new DataColumn("BasketingDiff", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBasketingDiff);
        this.columnReadOutMasterTime = new DataColumn("ReadOutMasterTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReadOutMasterTime);
        this.columnReadOutInternalTime = new DataColumn("ReadOutInternalTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReadOutInternalTime);
        this.columnReadOutDiff = new DataColumn("ReadOutDiff", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReadOutDiff);
        this.columnDiff = new DataColumn("Diff", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDiff);
        this.Constraints.Add((Constraint) new UniqueConstraint("PigeonsKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierID.DefaultValue = (object) 0;
        this.columnBasketingMasterTime.Caption = "Basketing Master Time";
        this.columnBasketingInternalTime.Caption = "Basketing Internal Time";
        this.columnBasketingDiff.Caption = "Basketing Diff";
        this.columnReadOutMasterTime.Caption = "ReadOut Master Time";
        this.columnReadOutInternalTime.Caption = "ReadOut Internal Time";
        this.columnReadOutDiff.Caption = "ReadOut Diff";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.TimersRow NewTimersRow() => (ReadOutDataSet.TimersRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.TimersRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.TimersRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.TimersRowChanged == null)
          return;
        this.TimersRowChanged((object) this, new ReadOutDataSet.TimersRowChangeEvent((ReadOutDataSet.TimersRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.TimersRowChanging == null)
          return;
        this.TimersRowChanging((object) this, new ReadOutDataSet.TimersRowChangeEvent((ReadOutDataSet.TimersRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.TimersRowDeleted == null)
          return;
        this.TimersRowDeleted((object) this, new ReadOutDataSet.TimersRowChangeEvent((ReadOutDataSet.TimersRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.TimersRowDeleting == null)
          return;
        this.TimersRowDeleting((object) this, new ReadOutDataSet.TimersRowChangeEvent((ReadOutDataSet.TimersRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveTimersRow(ReadOutDataSet.TimersRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (TimersDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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
    public class PigeonsMonitorDataTable : TypedTableBase<ReadOutDataSet.PigeonsMonitorRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnElBand;
      private DataColumn columnFedBand;
      private DataColumn columnClubID;
      private DataColumn columnFlightID;
      private DataColumn columnPosition1;
      private DataColumn columnPosition2;
      private DataColumn columnPosition3;
      private DataColumn columnPosition4;
      private DataColumn columnTime;
      private DataColumn columnEvaluation;
      private DataColumn columnNr;
      private DataColumn columnTeamNbr;
      private DataColumn columnSpeed;
      private DataColumn columnDistance;
      private DataColumn columnSpeed2;
      private DataColumn columnArrivePositionClub;
      private DataColumn columnArrivePositionProvincial;
      private DataColumn columnArrivePositionNational;
      private DataColumn columnArrivePositionInternational;
      private DataColumn columnEnterPositionClub;
      private DataColumn columnEnterPositionProvincial;
      private DataColumn columnEnterPositionNational;
      private DataColumn columnEnterPositionInternational;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsMonitorDataTable()
      {
        this.TableName = "PigeonsMonitor";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsMonitorDataTable(DataTable table)
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
      protected PigeonsMonitorDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FancierIDColumn => this.columnFancierID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ElBandColumn => this.columnElBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FedBandColumn => this.columnFedBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightIDColumn => this.columnFlightID;

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
      public DataColumn TimeColumn => this.columnTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EvaluationColumn => this.columnEvaluation;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NrColumn => this.columnNr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TeamNbrColumn => this.columnTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SpeedColumn => this.columnSpeed;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Speed2Column => this.columnSpeed2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ArrivePositionClubColumn => this.columnArrivePositionClub;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ArrivePositionProvincialColumn => this.columnArrivePositionProvincial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ArrivePositionNationalColumn => this.columnArrivePositionNational;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ArrivePositionInternationalColumn => this.columnArrivePositionInternational;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnterPositionClubColumn => this.columnEnterPositionClub;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnterPositionProvincialColumn => this.columnEnterPositionProvincial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnterPositionNationalColumn => this.columnEnterPositionNational;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EnterPositionInternationalColumn => this.columnEnterPositionInternational;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsMonitorRow this[int index] => (ReadOutDataSet.PigeonsMonitorRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsMonitorRowChangeEventHandler PigeonsMonitorRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsMonitorRowChangeEventHandler PigeonsMonitorRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsMonitorRowChangeEventHandler PigeonsMonitorRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ReadOutDataSet.PigeonsMonitorRowChangeEventHandler PigeonsMonitorRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddPigeonsMonitorRow(ReadOutDataSet.PigeonsMonitorRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsMonitorRow AddPigeonsMonitorRow(
        int FancierID,
        string ElBand,
        string FedBand,
        string ClubID,
        string FlightID,
        int Position1,
        int Position2,
        int Position3,
        int Position4,
        DateTime Time,
        string Evaluation,
        string Nr,
        int TeamNbr,
        double Speed,
        double Distance,
        double Speed2,
        int ArrivePositionClub,
        int ArrivePositionProvincial,
        int ArrivePositionNational,
        int ArrivePositionInternational,
        int EnterPositionClub,
        int EnterPositionProvincial,
        int EnterPositionNational,
        int EnterPositionInternational)
      {
        ReadOutDataSet.PigeonsMonitorRow pigeonsMonitorRow = (ReadOutDataSet.PigeonsMonitorRow) this.NewRow();
        object[] objArray = new object[25]
        {
          null,
          (object) FancierID,
          (object) ElBand,
          (object) FedBand,
          (object) ClubID,
          (object) FlightID,
          (object) Position1,
          (object) Position2,
          (object) Position3,
          (object) Position4,
          (object) Time,
          (object) Evaluation,
          (object) Nr,
          (object) TeamNbr,
          (object) Speed,
          (object) Distance,
          (object) Speed2,
          (object) ArrivePositionClub,
          (object) ArrivePositionProvincial,
          (object) ArrivePositionNational,
          (object) ArrivePositionInternational,
          (object) EnterPositionClub,
          (object) EnterPositionProvincial,
          (object) EnterPositionNational,
          (object) EnterPositionInternational
        };
        pigeonsMonitorRow.ItemArray = objArray;
        this.Rows.Add((DataRow) pigeonsMonitorRow);
        return pigeonsMonitorRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsMonitorRow FindByID(int ID) => (ReadOutDataSet.PigeonsMonitorRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ReadOutDataSet.PigeonsMonitorDataTable monitorDataTable = (ReadOutDataSet.PigeonsMonitorDataTable) base.Clone();
        monitorDataTable.InitVars();
        return (DataTable) monitorDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ReadOutDataSet.PigeonsMonitorDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnElBand = this.Columns["ElBand"];
        this.columnFedBand = this.Columns["FedBand"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnFlightID = this.Columns["FlightID"];
        this.columnPosition1 = this.Columns["Position1"];
        this.columnPosition2 = this.Columns["Position2"];
        this.columnPosition3 = this.Columns["Position3"];
        this.columnPosition4 = this.Columns["Position4"];
        this.columnTime = this.Columns["Time"];
        this.columnEvaluation = this.Columns["Evaluation"];
        this.columnNr = this.Columns["Nr"];
        this.columnTeamNbr = this.Columns["TeamNbr"];
        this.columnSpeed = this.Columns["Speed"];
        this.columnDistance = this.Columns["Distance"];
        this.columnSpeed2 = this.Columns["Speed2"];
        this.columnArrivePositionClub = this.Columns["ArrivePositionClub"];
        this.columnArrivePositionProvincial = this.Columns["ArrivePositionProvincial"];
        this.columnArrivePositionNational = this.Columns["ArrivePositionNational"];
        this.columnArrivePositionInternational = this.Columns["ArrivePositionInternational"];
        this.columnEnterPositionClub = this.Columns["EnterPositionClub"];
        this.columnEnterPositionProvincial = this.Columns["EnterPositionProvincial"];
        this.columnEnterPositionNational = this.Columns["EnterPositionNational"];
        this.columnEnterPositionInternational = this.Columns["EnterPositionInternational"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnElBand = new DataColumn("ElBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnElBand);
        this.columnFedBand = new DataColumn("FedBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFedBand);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnFlightID = new DataColumn("FlightID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightID);
        this.columnPosition1 = new DataColumn("Position1", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition1);
        this.columnPosition2 = new DataColumn("Position2", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition2);
        this.columnPosition3 = new DataColumn("Position3", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition3);
        this.columnPosition4 = new DataColumn("Position4", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition4);
        this.columnTime = new DataColumn("Time", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTime);
        this.columnEvaluation = new DataColumn("Evaluation", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEvaluation);
        this.columnNr = new DataColumn("Nr", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNr);
        this.columnTeamNbr = new DataColumn("TeamNbr", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTeamNbr);
        this.columnSpeed = new DataColumn("Speed", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSpeed);
        this.columnDistance = new DataColumn("Distance", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnSpeed2 = new DataColumn("Speed2", typeof (double), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSpeed2);
        this.columnArrivePositionClub = new DataColumn("ArrivePositionClub", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnArrivePositionClub);
        this.columnArrivePositionProvincial = new DataColumn("ArrivePositionProvincial", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnArrivePositionProvincial);
        this.columnArrivePositionNational = new DataColumn("ArrivePositionNational", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnArrivePositionNational);
        this.columnArrivePositionInternational = new DataColumn("ArrivePositionInternational", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnArrivePositionInternational);
        this.columnEnterPositionClub = new DataColumn("EnterPositionClub", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnterPositionClub);
        this.columnEnterPositionProvincial = new DataColumn("EnterPositionProvincial", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnterPositionProvincial);
        this.columnEnterPositionNational = new DataColumn("EnterPositionNational", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnterPositionNational);
        this.columnEnterPositionInternational = new DataColumn("EnterPositionInternational", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEnterPositionInternational);
        this.Constraints.Add((Constraint) new UniqueConstraint("PigeonsKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierID.DefaultValue = (object) 0;
        this.columnTeamNbr.DefaultValue = (object) 0;
        this.columnArrivePositionProvincial.Caption = "ArrivePositionClub";
        this.columnArrivePositionNational.Caption = "ArrivePositionClub";
        this.columnArrivePositionInternational.Caption = "ArrivePositionClub";
        this.columnEnterPositionClub.Caption = "ArrivePositionClub";
        this.columnEnterPositionProvincial.Caption = "ArrivePositionClub";
        this.columnEnterPositionNational.Caption = "ArrivePositionClub";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsMonitorRow NewPigeonsMonitorRow() => (ReadOutDataSet.PigeonsMonitorRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ReadOutDataSet.PigeonsMonitorRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ReadOutDataSet.PigeonsMonitorRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PigeonsMonitorRowChanged == null)
          return;
        this.PigeonsMonitorRowChanged((object) this, new ReadOutDataSet.PigeonsMonitorRowChangeEvent((ReadOutDataSet.PigeonsMonitorRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PigeonsMonitorRowChanging == null)
          return;
        this.PigeonsMonitorRowChanging((object) this, new ReadOutDataSet.PigeonsMonitorRowChangeEvent((ReadOutDataSet.PigeonsMonitorRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PigeonsMonitorRowDeleted == null)
          return;
        this.PigeonsMonitorRowDeleted((object) this, new ReadOutDataSet.PigeonsMonitorRowChangeEvent((ReadOutDataSet.PigeonsMonitorRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PigeonsMonitorRowDeleting == null)
          return;
        this.PigeonsMonitorRowDeleting((object) this, new ReadOutDataSet.PigeonsMonitorRowChangeEvent((ReadOutDataSet.PigeonsMonitorRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovePigeonsMonitorRow(ReadOutDataSet.PigeonsMonitorRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ReadOutDataSet readOutDataSet = new ReadOutDataSet();
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
          FixedValue = readOutDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PigeonsMonitorDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = readOutDataSet.GetSchemaSerializable();
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

    public class FancierRow : DataRow
    {
      private ReadOutDataSet.FancierDataTable tableFancier;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal FancierRow(DataRowBuilder rb)
        : base(rb)
        => this.tableFancier = (ReadOutDataSet.FancierDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableFancier.IDColumn];
        set => this[this.tableFancier.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string License
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.LicenseColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'License' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.LicenseColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.NameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Name' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Address
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.AddressColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Address' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.AddressColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ZipCode
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.ZipCodeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ZipCode' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.ZipCodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string City
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.CityColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'City' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.CityColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CoordX
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.CoordXColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordX' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.CoordXColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string CoordY
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.CoordYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordY' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.CoordYColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Serial
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.SerialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Serial' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.SerialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Distance
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableFancier.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DistanceUnit
      {
        get => this.IsDistanceUnitNull() ? string.Empty : (string) this[this.tableFancier.DistanceUnitColumn];
        set => this[this.tableFancier.DistanceUnitColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string DistanceString
      {
        get => this.IsDistanceStringNull() ? string.Empty : (string) this[this.tableFancier.DistanceStringColumn];
        set => this[this.tableFancier.DistanceStringColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightDesignated
      {
        get
        {
          try
          {
            return (string) this[this.tableFancier.FlightDesignatedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightDesignated' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.FlightDesignatedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NaamUnicode
      {
        get => this.IsNaamUnicodeNull() ? string.Empty : (string) this[this.tableFancier.NaamUnicodeColumn];
        set => this[this.tableFancier.NaamUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string GemeenteUnicode
      {
        get => this.IsGemeenteUnicodeNull() ? string.Empty : (string) this[this.tableFancier.GemeenteUnicodeColumn];
        set => this[this.tableFancier.GemeenteUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TimeZone
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableFancier.TimeZoneColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TimeZone' in table 'Fancier' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableFancier.TimeZoneColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLicenseNull() => this.IsNull(this.tableFancier.LicenseColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLicenseNull() => this[this.tableFancier.LicenseColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableFancier.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableFancier.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAddressNull() => this.IsNull(this.tableFancier.AddressColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAddressNull() => this[this.tableFancier.AddressColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsZipCodeNull() => this.IsNull(this.tableFancier.ZipCodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetZipCodeNull() => this[this.tableFancier.ZipCodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCityNull() => this.IsNull(this.tableFancier.CityColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCityNull() => this[this.tableFancier.CityColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordXNull() => this.IsNull(this.tableFancier.CoordXColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordXNull() => this[this.tableFancier.CoordXColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCoordYNull() => this.IsNull(this.tableFancier.CoordYColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCoordYNull() => this[this.tableFancier.CoordYColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSerialNull() => this.IsNull(this.tableFancier.SerialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSerialNull() => this[this.tableFancier.SerialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableFancier.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableFancier.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceUnitNull() => this.IsNull(this.tableFancier.DistanceUnitColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceUnitNull() => this[this.tableFancier.DistanceUnitColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceStringNull() => this.IsNull(this.tableFancier.DistanceStringColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceStringNull() => this[this.tableFancier.DistanceStringColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightDesignatedNull() => this.IsNull(this.tableFancier.FlightDesignatedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightDesignatedNull() => this[this.tableFancier.FlightDesignatedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNaamUnicodeNull() => this.IsNull(this.tableFancier.NaamUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNaamUnicodeNull() => this[this.tableFancier.NaamUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGemeenteUnicodeNull() => this.IsNull(this.tableFancier.GemeenteUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGemeenteUnicodeNull() => this[this.tableFancier.GemeenteUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeZoneNull() => this.IsNull(this.tableFancier.TimeZoneColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeZoneNull() => this[this.tableFancier.TimeZoneColumn] = Convert.DBNull;
    }

    public class PigeonsRow : DataRow
    {
      private ReadOutDataSet.PigeonsDataTable tablePigeons;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePigeons = (ReadOutDataSet.PigeonsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tablePigeons.IDColumn];
        set => this[this.tablePigeons.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FancierID
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.FancierIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FancierID' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.FancierIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ElBand
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.ElBandColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ElBand' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.ElBandColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FedBand
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.FedBandColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FedBand' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.FedBandColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubID
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.ClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubID' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightID
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.FlightIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightID' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.FlightIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position1
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.Position1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position1' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.Position1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position2
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.Position2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position2' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.Position2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position3
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.Position3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position3' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.Position3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position4
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.Position4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position4' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.Position4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime Time
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablePigeons.TimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Time' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.TimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Evaluation
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.EvaluationColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Evaluation' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.EvaluationColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Nr
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.NrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Nr' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.NrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TeamNbr
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.TeamNbrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TeamNbr' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.TeamNbrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tablePigeons.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tablePigeons.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsElBandNull() => this.IsNull(this.tablePigeons.ElBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetElBandNull() => this[this.tablePigeons.ElBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFedBandNull() => this.IsNull(this.tablePigeons.FedBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFedBandNull() => this[this.tablePigeons.FedBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tablePigeons.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tablePigeons.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightIDNull() => this.IsNull(this.tablePigeons.FlightIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightIDNull() => this[this.tablePigeons.FlightIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition1Null() => this.IsNull(this.tablePigeons.Position1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition1Null() => this[this.tablePigeons.Position1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition2Null() => this.IsNull(this.tablePigeons.Position2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition2Null() => this[this.tablePigeons.Position2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition3Null() => this.IsNull(this.tablePigeons.Position3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition3Null() => this[this.tablePigeons.Position3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition4Null() => this.IsNull(this.tablePigeons.Position4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition4Null() => this[this.tablePigeons.Position4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeNull() => this.IsNull(this.tablePigeons.TimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeNull() => this[this.tablePigeons.TimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEvaluationNull() => this.IsNull(this.tablePigeons.EvaluationColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEvaluationNull() => this[this.tablePigeons.EvaluationColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNrNull() => this.IsNull(this.tablePigeons.NrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNrNull() => this[this.tablePigeons.NrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTeamNbrNull() => this.IsNull(this.tablePigeons.TeamNbrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTeamNbrNull() => this[this.tablePigeons.TeamNbrColumn] = Convert.DBNull;
    }

    public class TimersRow : DataRow
    {
      private ReadOutDataSet.TimersDataTable tableTimers;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal TimersRow(DataRowBuilder rb)
        : base(rb)
        => this.tableTimers = (ReadOutDataSet.TimersDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableTimers.IDColumn];
        set => this[this.tableTimers.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FancierID
      {
        get
        {
          try
          {
            return (int) this[this.tableTimers.FancierIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FancierID' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.FancierIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubID
      {
        get
        {
          try
          {
            return (string) this[this.tableTimers.ClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubID' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightID
      {
        get
        {
          try
          {
            return (string) this[this.tableTimers.FlightIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightID' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.FlightIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime BasketingMasterTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTimers.BasketingMasterTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingMasterTime' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.BasketingMasterTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime BasketingInternalTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTimers.BasketingInternalTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingInternalTime' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.BasketingInternalTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string BasketingDiff
      {
        get
        {
          try
          {
            return (string) this[this.tableTimers.BasketingDiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingDiff' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.BasketingDiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ReadOutMasterTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTimers.ReadOutMasterTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutMasterTime' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.ReadOutMasterTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ReadOutInternalTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableTimers.ReadOutInternalTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutInternalTime' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.ReadOutInternalTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ReadOutDiff
      {
        get
        {
          try
          {
            return (string) this[this.tableTimers.ReadOutDiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutDiff' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.ReadOutDiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Diff
      {
        get
        {
          try
          {
            return (string) this[this.tableTimers.DiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Diff' in table 'Timers' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableTimers.DiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tableTimers.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tableTimers.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tableTimers.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tableTimers.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightIDNull() => this.IsNull(this.tableTimers.FlightIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightIDNull() => this[this.tableTimers.FlightIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBasketingMasterTimeNull() => this.IsNull(this.tableTimers.BasketingMasterTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBasketingMasterTimeNull() => this[this.tableTimers.BasketingMasterTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBasketingInternalTimeNull() => this.IsNull(this.tableTimers.BasketingInternalTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBasketingInternalTimeNull() => this[this.tableTimers.BasketingInternalTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBasketingDiffNull() => this.IsNull(this.tableTimers.BasketingDiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBasketingDiffNull() => this[this.tableTimers.BasketingDiffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReadOutMasterTimeNull() => this.IsNull(this.tableTimers.ReadOutMasterTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReadOutMasterTimeNull() => this[this.tableTimers.ReadOutMasterTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReadOutInternalTimeNull() => this.IsNull(this.tableTimers.ReadOutInternalTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReadOutInternalTimeNull() => this[this.tableTimers.ReadOutInternalTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReadOutDiffNull() => this.IsNull(this.tableTimers.ReadOutDiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReadOutDiffNull() => this[this.tableTimers.ReadOutDiffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDiffNull() => this.IsNull(this.tableTimers.DiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDiffNull() => this[this.tableTimers.DiffColumn] = Convert.DBNull;
    }

    public class PigeonsMonitorRow : DataRow
    {
      private ReadOutDataSet.PigeonsMonitorDataTable tablePigeonsMonitor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsMonitorRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePigeonsMonitor = (ReadOutDataSet.PigeonsMonitorDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tablePigeonsMonitor.IDColumn];
        set => this[this.tablePigeonsMonitor.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FancierID
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.FancierIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FancierID' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.FancierIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ElBand
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.ElBandColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ElBand' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ElBandColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FedBand
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.FedBandColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FedBand' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.FedBandColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubID
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.ClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubID' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightID
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.FlightIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightID' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.FlightIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position1
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.Position1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position1' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.Position1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position2
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.Position2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position2' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.Position2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position3
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.Position3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position3' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.Position3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position4
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.Position4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position4' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.Position4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime Time
      {
        get
        {
          try
          {
            return (DateTime) this[this.tablePigeonsMonitor.TimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Time' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.TimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Evaluation
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.EvaluationColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Evaluation' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.EvaluationColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Nr
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeonsMonitor.NrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Nr' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.NrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int TeamNbr
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.TeamNbrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TeamNbr' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.TeamNbrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double Speed
      {
        get
        {
          try
          {
            return (double) this[this.tablePigeonsMonitor.SpeedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Speed' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.SpeedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double Distance
      {
        get
        {
          try
          {
            return (double) this[this.tablePigeonsMonitor.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public double Speed2
      {
        get
        {
          try
          {
            return (double) this[this.tablePigeonsMonitor.Speed2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Speed2' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.Speed2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ArrivePositionClub
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.ArrivePositionClubColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ArrivePositionClub' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ArrivePositionClubColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ArrivePositionProvincial
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.ArrivePositionProvincialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ArrivePositionProvincial' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ArrivePositionProvincialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ArrivePositionNational
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.ArrivePositionNationalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ArrivePositionNational' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ArrivePositionNationalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ArrivePositionInternational
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.ArrivePositionInternationalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ArrivePositionInternational' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.ArrivePositionInternationalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EnterPositionClub
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.EnterPositionClubColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'EnterPositionClub' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.EnterPositionClubColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EnterPositionProvincial
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.EnterPositionProvincialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'EnterPositionProvincial' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.EnterPositionProvincialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EnterPositionNational
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.EnterPositionNationalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'EnterPositionNational' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.EnterPositionNationalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int EnterPositionInternational
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeonsMonitor.EnterPositionInternationalColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'EnterPositionInternational' in table 'PigeonsMonitor' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeonsMonitor.EnterPositionInternationalColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tablePigeonsMonitor.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tablePigeonsMonitor.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsElBandNull() => this.IsNull(this.tablePigeonsMonitor.ElBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetElBandNull() => this[this.tablePigeonsMonitor.ElBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFedBandNull() => this.IsNull(this.tablePigeonsMonitor.FedBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFedBandNull() => this[this.tablePigeonsMonitor.FedBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tablePigeonsMonitor.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tablePigeonsMonitor.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightIDNull() => this.IsNull(this.tablePigeonsMonitor.FlightIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightIDNull() => this[this.tablePigeonsMonitor.FlightIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition1Null() => this.IsNull(this.tablePigeonsMonitor.Position1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition1Null() => this[this.tablePigeonsMonitor.Position1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition2Null() => this.IsNull(this.tablePigeonsMonitor.Position2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition2Null() => this[this.tablePigeonsMonitor.Position2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition3Null() => this.IsNull(this.tablePigeonsMonitor.Position3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition3Null() => this[this.tablePigeonsMonitor.Position3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPosition4Null() => this.IsNull(this.tablePigeonsMonitor.Position4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPosition4Null() => this[this.tablePigeonsMonitor.Position4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeNull() => this.IsNull(this.tablePigeonsMonitor.TimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeNull() => this[this.tablePigeonsMonitor.TimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEvaluationNull() => this.IsNull(this.tablePigeonsMonitor.EvaluationColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEvaluationNull() => this[this.tablePigeonsMonitor.EvaluationColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNrNull() => this.IsNull(this.tablePigeonsMonitor.NrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNrNull() => this[this.tablePigeonsMonitor.NrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTeamNbrNull() => this.IsNull(this.tablePigeonsMonitor.TeamNbrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTeamNbrNull() => this[this.tablePigeonsMonitor.TeamNbrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSpeedNull() => this.IsNull(this.tablePigeonsMonitor.SpeedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSpeedNull() => this[this.tablePigeonsMonitor.SpeedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tablePigeonsMonitor.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tablePigeonsMonitor.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSpeed2Null() => this.IsNull(this.tablePigeonsMonitor.Speed2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSpeed2Null() => this[this.tablePigeonsMonitor.Speed2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsArrivePositionClubNull() => this.IsNull(this.tablePigeonsMonitor.ArrivePositionClubColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetArrivePositionClubNull() => this[this.tablePigeonsMonitor.ArrivePositionClubColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsArrivePositionProvincialNull() => this.IsNull(this.tablePigeonsMonitor.ArrivePositionProvincialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetArrivePositionProvincialNull() => this[this.tablePigeonsMonitor.ArrivePositionProvincialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsArrivePositionNationalNull() => this.IsNull(this.tablePigeonsMonitor.ArrivePositionNationalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetArrivePositionNationalNull() => this[this.tablePigeonsMonitor.ArrivePositionNationalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsArrivePositionInternationalNull() => this.IsNull(this.tablePigeonsMonitor.ArrivePositionInternationalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetArrivePositionInternationalNull() => this[this.tablePigeonsMonitor.ArrivePositionInternationalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnterPositionClubNull() => this.IsNull(this.tablePigeonsMonitor.EnterPositionClubColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnterPositionClubNull() => this[this.tablePigeonsMonitor.EnterPositionClubColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnterPositionProvincialNull() => this.IsNull(this.tablePigeonsMonitor.EnterPositionProvincialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnterPositionProvincialNull() => this[this.tablePigeonsMonitor.EnterPositionProvincialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnterPositionNationalNull() => this.IsNull(this.tablePigeonsMonitor.EnterPositionNationalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnterPositionNationalNull() => this[this.tablePigeonsMonitor.EnterPositionNationalColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEnterPositionInternationalNull() => this.IsNull(this.tablePigeonsMonitor.EnterPositionInternationalColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEnterPositionInternationalNull() => this[this.tablePigeonsMonitor.EnterPositionInternationalColumn] = Convert.DBNull;
    }

    public class PoulLetterRow : DataRow
    {
      private ReadOutDataSet.PoulLetterDataTable tablePoulLetter;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PoulLetterRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePoulLetter = (ReadOutDataSet.PoulLetterDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tablePoulLetter.IDColumn];
        set => this[this.tablePoulLetter.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Col0
      {
        get
        {
          try
          {
            return (string) this[this.tablePoulLetter.Col0Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col0' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col0Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col1
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col1' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col2
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col2' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col3
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col3' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col4
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col4' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col5
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col5Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col5' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col6
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col6Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col6' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col7
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col7Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col7' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col7Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col8
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col8Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col8' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col8Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col9
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col9Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col9' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col9Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col10
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col10Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col10' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col10Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col11
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col11Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col11' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col11Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col12
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col12Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col12' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col12Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col13
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col13Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col13' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col13Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col14
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col14Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col14' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col14Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col15
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col15Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col15' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col15Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col16
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col16Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col16' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col16Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col17
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col17Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col17' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col17Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ushort Col18
      {
        get
        {
          try
          {
            return (ushort) this[this.tablePoulLetter.Col18Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Col18' in table 'PoulLetter' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePoulLetter.Col18Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol0Null() => this.IsNull(this.tablePoulLetter.Col0Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol0Null() => this[this.tablePoulLetter.Col0Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol1Null() => this.IsNull(this.tablePoulLetter.Col1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol1Null() => this[this.tablePoulLetter.Col1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol2Null() => this.IsNull(this.tablePoulLetter.Col2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol2Null() => this[this.tablePoulLetter.Col2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol3Null() => this.IsNull(this.tablePoulLetter.Col3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol3Null() => this[this.tablePoulLetter.Col3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol4Null() => this.IsNull(this.tablePoulLetter.Col4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol4Null() => this[this.tablePoulLetter.Col4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol5Null() => this.IsNull(this.tablePoulLetter.Col5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol5Null() => this[this.tablePoulLetter.Col5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol6Null() => this.IsNull(this.tablePoulLetter.Col6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol6Null() => this[this.tablePoulLetter.Col6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol7Null() => this.IsNull(this.tablePoulLetter.Col7Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol7Null() => this[this.tablePoulLetter.Col7Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol8Null() => this.IsNull(this.tablePoulLetter.Col8Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol8Null() => this[this.tablePoulLetter.Col8Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol9Null() => this.IsNull(this.tablePoulLetter.Col9Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol9Null() => this[this.tablePoulLetter.Col9Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol10Null() => this.IsNull(this.tablePoulLetter.Col10Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol10Null() => this[this.tablePoulLetter.Col10Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol11Null() => this.IsNull(this.tablePoulLetter.Col11Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol11Null() => this[this.tablePoulLetter.Col11Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol12Null() => this.IsNull(this.tablePoulLetter.Col12Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol12Null() => this[this.tablePoulLetter.Col12Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol13Null() => this.IsNull(this.tablePoulLetter.Col13Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol13Null() => this[this.tablePoulLetter.Col13Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol14Null() => this.IsNull(this.tablePoulLetter.Col14Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol14Null() => this[this.tablePoulLetter.Col14Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol15Null() => this.IsNull(this.tablePoulLetter.Col15Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol15Null() => this[this.tablePoulLetter.Col15Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol16Null() => this.IsNull(this.tablePoulLetter.Col16Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol16Null() => this[this.tablePoulLetter.Col16Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol17Null() => this.IsNull(this.tablePoulLetter.Col17Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol17Null() => this[this.tablePoulLetter.Col17Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCol18Null() => this.IsNull(this.tablePoulLetter.Col18Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCol18Null() => this[this.tablePoulLetter.Col18Column] = Convert.DBNull;
    }

    public class RaceNamesRow : DataRow
    {
      private ReadOutDataSet.RaceNamesDataTable tableRaceNames;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal RaceNamesRow(DataRowBuilder rb)
        : base(rb)
        => this.tableRaceNames = (ReadOutDataSet.RaceNamesDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableRaceNames.IDColumn];
        set => this[this.tableRaceNames.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightID
      {
        get
        {
          try
          {
            return (string) this[this.tableRaceNames.FlightIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightID' in table 'RaceNames' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaceNames.FlightIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get
        {
          try
          {
            return (string) this[this.tableRaceNames.NameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Name' in table 'RaceNames' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaceNames.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightIDNull() => this.IsNull(this.tableRaceNames.FlightIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightIDNull() => this[this.tableRaceNames.FlightIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableRaceNames.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableRaceNames.NameColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class FancierRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.FancierRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public FancierRowChangeEvent(ReadOutDataSet.FancierRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.FancierRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class PigeonsRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.PigeonsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsRowChangeEvent(ReadOutDataSet.PigeonsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class TimersRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.TimersRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public TimersRowChangeEvent(ReadOutDataSet.TimersRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.TimersRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class PigeonsMonitorRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.PigeonsMonitorRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsMonitorRowChangeEvent(
        ReadOutDataSet.PigeonsMonitorRow row,
        DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PigeonsMonitorRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class PoulLetterRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.PoulLetterRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PoulLetterRowChangeEvent(ReadOutDataSet.PoulLetterRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.PoulLetterRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class RaceNamesRowChangeEvent : EventArgs
    {
      private ReadOutDataSet.RaceNamesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public RaceNamesRowChangeEvent(ReadOutDataSet.RaceNamesRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ReadOutDataSet.RaceNamesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
