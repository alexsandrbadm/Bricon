// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.ChampignonShip
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
  [XmlRoot("ChampignonShip")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class ChampignonShip : DataSet
  {
    private ChampignonShip.Query1DataTable tableQuery1;
    private ChampignonShip.Query2DataTable tableQuery2;
    private ChampignonShip.Query3DataTable tableQuery3;
    private ChampignonShip.Query4DataTable tableQuery4;
    private ChampignonShip.Query5DataTable tableQuery5;
    private ChampignonShip.SettingsDataTable tableSettings;
    private ChampignonShip.Query6DataTable tableQuery6;
    private ChampignonShip.FlightsDataTable tableFlights;
    private ChampignonShip.Query6bDataTable tableQuery6b;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public ChampignonShip()
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
    protected ChampignonShip(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (Query1)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query1DataTable(dataSet.Tables[nameof (Query1)]));
          if (dataSet.Tables[nameof (Query2)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query2DataTable(dataSet.Tables[nameof (Query2)]));
          if (dataSet.Tables[nameof (Query3)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query3DataTable(dataSet.Tables[nameof (Query3)]));
          if (dataSet.Tables[nameof (Query4)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query4DataTable(dataSet.Tables[nameof (Query4)]));
          if (dataSet.Tables[nameof (Query5)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query5DataTable(dataSet.Tables[nameof (Query5)]));
          if (dataSet.Tables[nameof (Settings)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.SettingsDataTable(dataSet.Tables[nameof (Settings)]));
          if (dataSet.Tables[nameof (Query6)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query6DataTable(dataSet.Tables[nameof (Query6)]));
          if (dataSet.Tables[nameof (Flights)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.FlightsDataTable(dataSet.Tables[nameof (Flights)]));
          if (dataSet.Tables[nameof (Query6b)] != null)
            base.Tables.Add((DataTable) new ChampignonShip.Query6bDataTable(dataSet.Tables[nameof (Query6b)]));
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
    public ChampignonShip.Query1DataTable Query1 => this.tableQuery1;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query2DataTable Query2 => this.tableQuery2;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query3DataTable Query3 => this.tableQuery3;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query4DataTable Query4 => this.tableQuery4;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query5DataTable Query5 => this.tableQuery5;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.SettingsDataTable Settings => this.tableSettings;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query6DataTable Query6 => this.tableQuery6;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.FlightsDataTable Flights => this.tableFlights;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ChampignonShip.Query6bDataTable Query6b => this.tableQuery6b;

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
      ChampignonShip champignonShip = (ChampignonShip) base.Clone();
      champignonShip.InitVars();
      champignonShip.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) champignonShip;
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
        if (dataSet.Tables["Query1"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query1DataTable(dataSet.Tables["Query1"]));
        if (dataSet.Tables["Query2"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query2DataTable(dataSet.Tables["Query2"]));
        if (dataSet.Tables["Query3"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query3DataTable(dataSet.Tables["Query3"]));
        if (dataSet.Tables["Query4"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query4DataTable(dataSet.Tables["Query4"]));
        if (dataSet.Tables["Query5"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query5DataTable(dataSet.Tables["Query5"]));
        if (dataSet.Tables["Settings"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.SettingsDataTable(dataSet.Tables["Settings"]));
        if (dataSet.Tables["Query6"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query6DataTable(dataSet.Tables["Query6"]));
        if (dataSet.Tables["Flights"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.FlightsDataTable(dataSet.Tables["Flights"]));
        if (dataSet.Tables["Query6b"] != null)
          base.Tables.Add((DataTable) new ChampignonShip.Query6bDataTable(dataSet.Tables["Query6b"]));
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
      this.tableQuery1 = (ChampignonShip.Query1DataTable) base.Tables["Query1"];
      if (initTable && this.tableQuery1 != null)
        this.tableQuery1.InitVars();
      this.tableQuery2 = (ChampignonShip.Query2DataTable) base.Tables["Query2"];
      if (initTable && this.tableQuery2 != null)
        this.tableQuery2.InitVars();
      this.tableQuery3 = (ChampignonShip.Query3DataTable) base.Tables["Query3"];
      if (initTable && this.tableQuery3 != null)
        this.tableQuery3.InitVars();
      this.tableQuery4 = (ChampignonShip.Query4DataTable) base.Tables["Query4"];
      if (initTable && this.tableQuery4 != null)
        this.tableQuery4.InitVars();
      this.tableQuery5 = (ChampignonShip.Query5DataTable) base.Tables["Query5"];
      if (initTable && this.tableQuery5 != null)
        this.tableQuery5.InitVars();
      this.tableSettings = (ChampignonShip.SettingsDataTable) base.Tables["Settings"];
      if (initTable && this.tableSettings != null)
        this.tableSettings.InitVars();
      this.tableQuery6 = (ChampignonShip.Query6DataTable) base.Tables["Query6"];
      if (initTable && this.tableQuery6 != null)
        this.tableQuery6.InitVars();
      this.tableFlights = (ChampignonShip.FlightsDataTable) base.Tables["Flights"];
      if (initTable && this.tableFlights != null)
        this.tableFlights.InitVars();
      this.tableQuery6b = (ChampignonShip.Query6bDataTable) base.Tables["Query6b"];
      if (!initTable || this.tableQuery6b == null)
        return;
      this.tableQuery6b.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (ChampignonShip);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/ChampignonShip.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableQuery1 = new ChampignonShip.Query1DataTable();
      base.Tables.Add((DataTable) this.tableQuery1);
      this.tableQuery2 = new ChampignonShip.Query2DataTable();
      base.Tables.Add((DataTable) this.tableQuery2);
      this.tableQuery3 = new ChampignonShip.Query3DataTable();
      base.Tables.Add((DataTable) this.tableQuery3);
      this.tableQuery4 = new ChampignonShip.Query4DataTable();
      base.Tables.Add((DataTable) this.tableQuery4);
      this.tableQuery5 = new ChampignonShip.Query5DataTable();
      base.Tables.Add((DataTable) this.tableQuery5);
      this.tableSettings = new ChampignonShip.SettingsDataTable();
      base.Tables.Add((DataTable) this.tableSettings);
      this.tableQuery6 = new ChampignonShip.Query6DataTable();
      base.Tables.Add((DataTable) this.tableQuery6);
      this.tableFlights = new ChampignonShip.FlightsDataTable();
      base.Tables.Add((DataTable) this.tableFlights);
      this.tableQuery6b = new ChampignonShip.Query6bDataTable();
      base.Tables.Add((DataTable) this.tableQuery6b);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery1() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery2() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery3() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery4() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery5() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeSettings() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery6() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeFlights() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeQuery6b() => false;

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
      ChampignonShip champignonShip = new ChampignonShip();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = champignonShip.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query2DataTable : TypedTableBase<ChampignonShip.Query2Row>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnRingNumber;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query2DataTable()
      {
        this.TableName = "Query2";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query2DataTable(DataTable table)
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
      protected Query2DataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn RingNumberColumn => this.columnRingNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PriceCountColumn => this.columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query2Row this[int index] => (ChampignonShip.Query2Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query2RowChangeEventHandler Query2RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query2RowChangeEventHandler Query2RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query2RowChangeEventHandler Query2RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query2RowChangeEventHandler Query2RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery2Row(ChampignonShip.Query2Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query2Row AddQuery2Row(
        string Name,
        string RingNumber,
        Decimal TotalCoefficient,
        int PriceCount)
      {
        ChampignonShip.Query2Row query2Row = (ChampignonShip.Query2Row) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) RingNumber,
          (object) TotalCoefficient,
          (object) PriceCount
        };
        query2Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query2Row);
        return query2Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query2Row FindByID(int ID) => (ChampignonShip.Query2Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query2DataTable query2DataTable = (ChampignonShip.Query2DataTable) base.Clone();
        query2DataTable.InitVars();
        return (DataTable) query2DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query2DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnRingNumber = this.Columns["RingNumber"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnPriceCount = this.Columns["PriceCount"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnRingNumber = new DataColumn("RingNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRingNumber);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnPriceCount = new DataColumn("PriceCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPriceCount);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnRingNumber.Caption = "BaskettedCount";
        this.columnRingNumber.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query2Row NewQuery2Row() => (ChampignonShip.Query2Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query2Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query2Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query2RowChanged == null)
          return;
        this.Query2RowChanged((object) this, new ChampignonShip.Query2RowChangeEvent((ChampignonShip.Query2Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query2RowChanging == null)
          return;
        this.Query2RowChanging((object) this, new ChampignonShip.Query2RowChangeEvent((ChampignonShip.Query2Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query2RowDeleted == null)
          return;
        this.Query2RowDeleted((object) this, new ChampignonShip.Query2RowChangeEvent((ChampignonShip.Query2Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query2RowDeleting == null)
          return;
        this.Query2RowDeleting((object) this, new ChampignonShip.Query2RowChangeEvent((ChampignonShip.Query2Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery2Row(ChampignonShip.Query2Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query2DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query1DataTable : TypedTableBase<ChampignonShip.Query1Row>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnPriceCount;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnBaskettedCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query1DataTable()
      {
        this.TableName = "Query1";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query1DataTable(DataTable table)
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
      protected Query1DataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn PriceCountColumn => this.columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BaskettedCountColumn => this.columnBaskettedCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query1Row this[int index] => (ChampignonShip.Query1Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query1RowChangeEventHandler Query1RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query1RowChangeEventHandler Query1RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query1RowChangeEventHandler Query1RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query1RowChangeEventHandler Query1RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery1Row(ChampignonShip.Query1Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query1Row AddQuery1Row(
        string Name,
        int PriceCount,
        Decimal TotalCoefficient,
        int BaskettedCount)
      {
        ChampignonShip.Query1Row query1Row = (ChampignonShip.Query1Row) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) PriceCount,
          (object) TotalCoefficient,
          (object) BaskettedCount
        };
        query1Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query1Row);
        return query1Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query1Row FindByID(int ID) => (ChampignonShip.Query1Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query1DataTable query1DataTable = (ChampignonShip.Query1DataTable) base.Clone();
        query1DataTable.InitVars();
        return (DataTable) query1DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query1DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnPriceCount = this.Columns["PriceCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnBaskettedCount = this.Columns["BaskettedCount"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnPriceCount = new DataColumn("PriceCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPriceCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnBaskettedCount = new DataColumn("BaskettedCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBaskettedCount);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query1Row NewQuery1Row() => (ChampignonShip.Query1Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query1Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query1Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query1RowChanged == null)
          return;
        this.Query1RowChanged((object) this, new ChampignonShip.Query1RowChangeEvent((ChampignonShip.Query1Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query1RowChanging == null)
          return;
        this.Query1RowChanging((object) this, new ChampignonShip.Query1RowChangeEvent((ChampignonShip.Query1Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query1RowDeleted == null)
          return;
        this.Query1RowDeleted((object) this, new ChampignonShip.Query1RowChangeEvent((ChampignonShip.Query1Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query1RowDeleting == null)
          return;
        this.Query1RowDeleting((object) this, new ChampignonShip.Query1RowChangeEvent((ChampignonShip.Query1Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery1Row(ChampignonShip.Query1Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query1DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public delegate void Query1RowChangeEventHandler(
      object sender,
      ChampignonShip.Query1RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query2RowChangeEventHandler(
      object sender,
      ChampignonShip.Query2RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query3RowChangeEventHandler(
      object sender,
      ChampignonShip.Query3RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query4RowChangeEventHandler(
      object sender,
      ChampignonShip.Query4RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query5RowChangeEventHandler(
      object sender,
      ChampignonShip.Query5RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void SettingsRowChangeEventHandler(
      object sender,
      ChampignonShip.SettingsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query6RowChangeEventHandler(
      object sender,
      ChampignonShip.Query6RowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void FlightsRowChangeEventHandler(
      object sender,
      ChampignonShip.FlightsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void Query6bRowChangeEventHandler(
      object sender,
      ChampignonShip.Query6bRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class Query3DataTable : TypedTableBase<ChampignonShip.Query3Row>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnRingNumber;
      private DataColumn columnPriceCount;
      private DataColumn columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query3DataTable()
      {
        this.TableName = "Query3";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query3DataTable(DataTable table)
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
      protected Query3DataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn RingNumberColumn => this.columnRingNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PriceCountColumn => this.columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query3Row this[int index] => (ChampignonShip.Query3Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query3RowChangeEventHandler Query3RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query3RowChangeEventHandler Query3RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query3RowChangeEventHandler Query3RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query3RowChangeEventHandler Query3RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery3Row(ChampignonShip.Query3Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query3Row AddQuery3Row(
        string Name,
        string RingNumber,
        int PriceCount,
        Decimal TotalCoefficient)
      {
        ChampignonShip.Query3Row query3Row = (ChampignonShip.Query3Row) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) RingNumber,
          (object) PriceCount,
          (object) TotalCoefficient
        };
        query3Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query3Row);
        return query3Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query3Row FindByID(int ID) => (ChampignonShip.Query3Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query3DataTable query3DataTable = (ChampignonShip.Query3DataTable) base.Clone();
        query3DataTable.InitVars();
        return (DataTable) query3DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query3DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnRingNumber = this.Columns["RingNumber"];
        this.columnPriceCount = this.Columns["PriceCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnRingNumber = new DataColumn("RingNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRingNumber);
        this.columnPriceCount = new DataColumn("PriceCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPriceCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnRingNumber.Caption = "BaskettedCount";
        this.columnRingNumber.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query3Row NewQuery3Row() => (ChampignonShip.Query3Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query3Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query3Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query3RowChanged == null)
          return;
        this.Query3RowChanged((object) this, new ChampignonShip.Query3RowChangeEvent((ChampignonShip.Query3Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query3RowChanging == null)
          return;
        this.Query3RowChanging((object) this, new ChampignonShip.Query3RowChangeEvent((ChampignonShip.Query3Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query3RowDeleted == null)
          return;
        this.Query3RowDeleted((object) this, new ChampignonShip.Query3RowChangeEvent((ChampignonShip.Query3Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query3RowDeleting == null)
          return;
        this.Query3RowDeleting((object) this, new ChampignonShip.Query3RowChangeEvent((ChampignonShip.Query3Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery3Row(ChampignonShip.Query3Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query3DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query4DataTable : TypedTableBase<ChampignonShip.Query4Row>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnPointCount;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnCountPerRace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query4DataTable()
      {
        this.TableName = "Query4";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query4DataTable(DataTable table)
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
      protected Query4DataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn PointCountColumn => this.columnPointCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CountPerRaceColumn => this.columnCountPerRace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query4Row this[int index] => (ChampignonShip.Query4Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query4RowChangeEventHandler Query4RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query4RowChangeEventHandler Query4RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query4RowChangeEventHandler Query4RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query4RowChangeEventHandler Query4RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery4Row(ChampignonShip.Query4Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query4Row AddQuery4Row(
        string Name,
        int PointCount,
        Decimal TotalCoefficient,
        int CountPerRace)
      {
        ChampignonShip.Query4Row query4Row = (ChampignonShip.Query4Row) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) PointCount,
          (object) TotalCoefficient,
          (object) CountPerRace
        };
        query4Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query4Row);
        return query4Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query4Row FindByID(int ID) => (ChampignonShip.Query4Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query4DataTable query4DataTable = (ChampignonShip.Query4DataTable) base.Clone();
        query4DataTable.InitVars();
        return (DataTable) query4DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query4DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnPointCount = this.Columns["PointCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnCountPerRace = this.Columns["CountPerRace"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnPointCount = new DataColumn("PointCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPointCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnCountPerRace = new DataColumn("CountPerRace", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCountPerRace);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnPointCount.Caption = "PriceCount";
        this.columnCountPerRace.Caption = "PriceCount";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query4Row NewQuery4Row() => (ChampignonShip.Query4Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query4Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query4Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query4RowChanged == null)
          return;
        this.Query4RowChanged((object) this, new ChampignonShip.Query4RowChangeEvent((ChampignonShip.Query4Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query4RowChanging == null)
          return;
        this.Query4RowChanging((object) this, new ChampignonShip.Query4RowChangeEvent((ChampignonShip.Query4Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query4RowDeleted == null)
          return;
        this.Query4RowDeleted((object) this, new ChampignonShip.Query4RowChangeEvent((ChampignonShip.Query4Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query4RowDeleting == null)
          return;
        this.Query4RowDeleting((object) this, new ChampignonShip.Query4RowChangeEvent((ChampignonShip.Query4Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery4Row(ChampignonShip.Query4Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query4DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query5DataTable : TypedTableBase<ChampignonShip.Query5Row>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnPriceCount;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnCountPerRace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query5DataTable()
      {
        this.TableName = "Query5";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query5DataTable(DataTable table)
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
      protected Query5DataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn PriceCountColumn => this.columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CountPerRaceColumn => this.columnCountPerRace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query5Row this[int index] => (ChampignonShip.Query5Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query5RowChangeEventHandler Query5RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query5RowChangeEventHandler Query5RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query5RowChangeEventHandler Query5RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query5RowChangeEventHandler Query5RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery5Row(ChampignonShip.Query5Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query5Row AddQuery5Row(
        string Name,
        int PriceCount,
        Decimal TotalCoefficient,
        int CountPerRace)
      {
        ChampignonShip.Query5Row query5Row = (ChampignonShip.Query5Row) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) PriceCount,
          (object) TotalCoefficient,
          (object) CountPerRace
        };
        query5Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query5Row);
        return query5Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query5Row FindByID(int ID) => (ChampignonShip.Query5Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query5DataTable query5DataTable = (ChampignonShip.Query5DataTable) base.Clone();
        query5DataTable.InitVars();
        return (DataTable) query5DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query5DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnPriceCount = this.Columns["PriceCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnCountPerRace = this.Columns["CountPerRace"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnPriceCount = new DataColumn("PriceCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPriceCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnCountPerRace = new DataColumn("CountPerRace", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCountPerRace);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnCountPerRace.Caption = "PriceCount";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query5Row NewQuery5Row() => (ChampignonShip.Query5Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query5Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query5Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query5RowChanged == null)
          return;
        this.Query5RowChanged((object) this, new ChampignonShip.Query5RowChangeEvent((ChampignonShip.Query5Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query5RowChanging == null)
          return;
        this.Query5RowChanging((object) this, new ChampignonShip.Query5RowChangeEvent((ChampignonShip.Query5Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query5RowDeleted == null)
          return;
        this.Query5RowDeleted((object) this, new ChampignonShip.Query5RowChangeEvent((ChampignonShip.Query5Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query5RowDeleting == null)
          return;
        this.Query5RowDeleting((object) this, new ChampignonShip.Query5RowChangeEvent((ChampignonShip.Query5Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery5Row(ChampignonShip.Query5Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query5DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class SettingsDataTable : TypedTableBase<ChampignonShip.SettingsRow>
    {
      private DataColumn columnID;
      private DataColumn columnPercentage;
      private DataColumn columnName6;
      private DataColumn columnName5;
      private DataColumn columnName4;
      private DataColumn columnName3;
      private DataColumn columnName2;
      private DataColumn columnName1;
      private DataColumn columnDescription6;
      private DataColumn columnDescription5;
      private DataColumn columnDescription4;
      private DataColumn columnDescription3;
      private DataColumn columnDescription2;
      private DataColumn columnDescription1;
      private DataColumn columnNumber6;
      private DataColumn columnNumber4b;
      private DataColumn columnNumber4a;
      private DataColumn columnNumber5;
      private DataColumn columnNumber3;
      private DataColumn columnPrint6;
      private DataColumn columnPrint5;
      private DataColumn columnPrint4;
      private DataColumn columnPrint3;
      private DataColumn columnPrint2;
      private DataColumn columnPrint1;
      private DataColumn columnCategorie6;
      private DataColumn columnMainTitle;
      private DataColumn columnMaxRowCount6;
      private DataColumn columnMaxRowCount5;
      private DataColumn columnMaxRowCount4;
      private DataColumn columnMaxRowCount3;
      private DataColumn columnMaxRowCount2;
      private DataColumn columnMaxRowCount6b;
      private DataColumn columnMaxRowCount1;
      private DataColumn columnDescription6b;
      private DataColumn columnPrint6b;
      private DataColumn columnName6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SettingsDataTable()
      {
        this.TableName = "Settings";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal SettingsDataTable(DataTable table)
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
      protected SettingsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PercentageColumn => this.columnPercentage;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name6Column => this.columnName6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name5Column => this.columnName5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name4Column => this.columnName4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name3Column => this.columnName3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name2Column => this.columnName2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name1Column => this.columnName1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description6Column => this.columnDescription6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description5Column => this.columnDescription5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description4Column => this.columnDescription4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description3Column => this.columnDescription3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description2Column => this.columnDescription2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description1Column => this.columnDescription1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Number6Column => this.columnNumber6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Number4bColumn => this.columnNumber4b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Number4aColumn => this.columnNumber4a;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Number5Column => this.columnNumber5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Number3Column => this.columnNumber3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print6Column => this.columnPrint6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print5Column => this.columnPrint5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print4Column => this.columnPrint4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print3Column => this.columnPrint3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print2Column => this.columnPrint2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print1Column => this.columnPrint1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Categorie6Column => this.columnCategorie6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MainTitleColumn => this.columnMainTitle;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount6Column => this.columnMaxRowCount6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount5Column => this.columnMaxRowCount5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount4Column => this.columnMaxRowCount4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount3Column => this.columnMaxRowCount3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount2Column => this.columnMaxRowCount2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount6bColumn => this.columnMaxRowCount6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn MaxRowCount1Column => this.columnMaxRowCount1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Description6bColumn => this.columnDescription6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Print6bColumn => this.columnPrint6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Name6bColumn => this.columnName6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.SettingsRow this[int index] => (ChampignonShip.SettingsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.SettingsRowChangeEventHandler SettingsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.SettingsRowChangeEventHandler SettingsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.SettingsRowChangeEventHandler SettingsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.SettingsRowChangeEventHandler SettingsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddSettingsRow(ChampignonShip.SettingsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.SettingsRow AddSettingsRow(
        Decimal Percentage,
        string Name6,
        string Name5,
        string Name4,
        string Name3,
        string Name2,
        string Name1,
        string Description6,
        string Description5,
        string Description4,
        string Description3,
        string Description2,
        string Description1,
        int Number6,
        int Number4b,
        int Number4a,
        int Number5,
        int Number3,
        bool Print6,
        bool Print5,
        bool Print4,
        bool Print3,
        bool Print2,
        bool Print1,
        string Categorie6,
        string MainTitle,
        int MaxRowCount6,
        int MaxRowCount5,
        int MaxRowCount4,
        int MaxRowCount3,
        int MaxRowCount2,
        int MaxRowCount6b,
        int MaxRowCount1,
        string Description6b,
        bool Print6b,
        string Name6b)
      {
        ChampignonShip.SettingsRow settingsRow = (ChampignonShip.SettingsRow) this.NewRow();
        object[] objArray = new object[37]
        {
          null,
          (object) Percentage,
          (object) Name6,
          (object) Name5,
          (object) Name4,
          (object) Name3,
          (object) Name2,
          (object) Name1,
          (object) Description6,
          (object) Description5,
          (object) Description4,
          (object) Description3,
          (object) Description2,
          (object) Description1,
          (object) Number6,
          (object) Number4b,
          (object) Number4a,
          (object) Number5,
          (object) Number3,
          (object) Print6,
          (object) Print5,
          (object) Print4,
          (object) Print3,
          (object) Print2,
          (object) Print1,
          (object) Categorie6,
          (object) MainTitle,
          (object) MaxRowCount6,
          (object) MaxRowCount5,
          (object) MaxRowCount4,
          (object) MaxRowCount3,
          (object) MaxRowCount2,
          (object) MaxRowCount6b,
          (object) MaxRowCount1,
          (object) Description6b,
          (object) Print6b,
          (object) Name6b
        };
        settingsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) settingsRow);
        return settingsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.SettingsRow FindByID(int ID) => (ChampignonShip.SettingsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.SettingsDataTable settingsDataTable = (ChampignonShip.SettingsDataTable) base.Clone();
        settingsDataTable.InitVars();
        return (DataTable) settingsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.SettingsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnPercentage = this.Columns["Percentage"];
        this.columnName6 = this.Columns["Name6"];
        this.columnName5 = this.Columns["Name5"];
        this.columnName4 = this.Columns["Name4"];
        this.columnName3 = this.Columns["Name3"];
        this.columnName2 = this.Columns["Name2"];
        this.columnName1 = this.Columns["Name1"];
        this.columnDescription6 = this.Columns["Description6"];
        this.columnDescription5 = this.Columns["Description5"];
        this.columnDescription4 = this.Columns["Description4"];
        this.columnDescription3 = this.Columns["Description3"];
        this.columnDescription2 = this.Columns["Description2"];
        this.columnDescription1 = this.Columns["Description1"];
        this.columnNumber6 = this.Columns["Number6"];
        this.columnNumber4b = this.Columns["Number4b"];
        this.columnNumber4a = this.Columns["Number4a"];
        this.columnNumber5 = this.Columns["Number5"];
        this.columnNumber3 = this.Columns["Number3"];
        this.columnPrint6 = this.Columns["Print6"];
        this.columnPrint5 = this.Columns["Print5"];
        this.columnPrint4 = this.Columns["Print4"];
        this.columnPrint3 = this.Columns["Print3"];
        this.columnPrint2 = this.Columns["Print2"];
        this.columnPrint1 = this.Columns["Print1"];
        this.columnCategorie6 = this.Columns["Categorie6"];
        this.columnMainTitle = this.Columns["MainTitle"];
        this.columnMaxRowCount6 = this.Columns["MaxRowCount6"];
        this.columnMaxRowCount5 = this.Columns["MaxRowCount5"];
        this.columnMaxRowCount4 = this.Columns["MaxRowCount4"];
        this.columnMaxRowCount3 = this.Columns["MaxRowCount3"];
        this.columnMaxRowCount2 = this.Columns["MaxRowCount2"];
        this.columnMaxRowCount6b = this.Columns["MaxRowCount6b"];
        this.columnMaxRowCount1 = this.Columns["MaxRowCount1"];
        this.columnDescription6b = this.Columns["Description6b"];
        this.columnPrint6b = this.Columns["Print6b"];
        this.columnName6b = this.Columns["Name6b"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnPercentage = new DataColumn("Percentage", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPercentage);
        this.columnName6 = new DataColumn("Name6", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName6);
        this.columnName5 = new DataColumn("Name5", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName5);
        this.columnName4 = new DataColumn("Name4", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName4);
        this.columnName3 = new DataColumn("Name3", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName3);
        this.columnName2 = new DataColumn("Name2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName2);
        this.columnName1 = new DataColumn("Name1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName1);
        this.columnDescription6 = new DataColumn("Description6", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription6);
        this.columnDescription5 = new DataColumn("Description5", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription5);
        this.columnDescription4 = new DataColumn("Description4", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription4);
        this.columnDescription3 = new DataColumn("Description3", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription3);
        this.columnDescription2 = new DataColumn("Description2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription2);
        this.columnDescription1 = new DataColumn("Description1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription1);
        this.columnNumber6 = new DataColumn("Number6", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber6);
        this.columnNumber4b = new DataColumn("Number4b", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber4b);
        this.columnNumber4a = new DataColumn("Number4a", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber4a);
        this.columnNumber5 = new DataColumn("Number5", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber5);
        this.columnNumber3 = new DataColumn("Number3", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNumber3);
        this.columnPrint6 = new DataColumn("Print6", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint6);
        this.columnPrint5 = new DataColumn("Print5", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint5);
        this.columnPrint4 = new DataColumn("Print4", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint4);
        this.columnPrint3 = new DataColumn("Print3", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint3);
        this.columnPrint2 = new DataColumn("Print2", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint2);
        this.columnPrint1 = new DataColumn("Print1", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint1);
        this.columnCategorie6 = new DataColumn("Categorie6", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCategorie6);
        this.columnMainTitle = new DataColumn("MainTitle", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMainTitle);
        this.columnMaxRowCount6 = new DataColumn("MaxRowCount6", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount6);
        this.columnMaxRowCount5 = new DataColumn("MaxRowCount5", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount5);
        this.columnMaxRowCount4 = new DataColumn("MaxRowCount4", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount4);
        this.columnMaxRowCount3 = new DataColumn("MaxRowCount3", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount3);
        this.columnMaxRowCount2 = new DataColumn("MaxRowCount2", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount2);
        this.columnMaxRowCount6b = new DataColumn("MaxRowCount6b", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount6b);
        this.columnMaxRowCount1 = new DataColumn("MaxRowCount1", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnMaxRowCount1);
        this.columnDescription6b = new DataColumn("Description6b", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDescription6b);
        this.columnPrint6b = new DataColumn("Print6b", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPrint6b);
        this.columnName6b = new DataColumn("Name6b", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName6b);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnPercentage.DefaultValue = (object) 33.33M;
        this.columnName6.Caption = "Name";
        this.columnName6.DefaultValue = (object) "";
        this.columnName5.Caption = "Name";
        this.columnName5.DefaultValue = (object) "";
        this.columnName4.Caption = "Name";
        this.columnName4.DefaultValue = (object) "";
        this.columnName3.Caption = "Name";
        this.columnName3.DefaultValue = (object) "";
        this.columnName2.Caption = "Name";
        this.columnName2.DefaultValue = (object) "";
        this.columnName1.Caption = "Name";
        this.columnName1.DefaultValue = (object) "";
        this.columnDescription6.Caption = "Name";
        this.columnDescription6.DefaultValue = (object) "";
        this.columnDescription5.Caption = "Name";
        this.columnDescription5.DefaultValue = (object) "";
        this.columnDescription4.Caption = "Name";
        this.columnDescription4.DefaultValue = (object) "";
        this.columnDescription3.Caption = "Name";
        this.columnDescription3.DefaultValue = (object) "";
        this.columnDescription2.Caption = "Name";
        this.columnDescription2.DefaultValue = (object) "";
        this.columnDescription1.Caption = "Name";
        this.columnDescription1.DefaultValue = (object) "";
        this.columnNumber6.Caption = "Number3";
        this.columnNumber4b.Caption = "Number3";
        this.columnNumber4a.Caption = "Number3";
        this.columnNumber5.Caption = "Number3";
        this.columnPrint6.Caption = "Print";
        this.columnPrint6.DefaultValue = (object) true;
        this.columnPrint5.Caption = "Print";
        this.columnPrint5.DefaultValue = (object) true;
        this.columnPrint4.Caption = "Print";
        this.columnPrint4.DefaultValue = (object) true;
        this.columnPrint3.Caption = "Print";
        this.columnPrint3.DefaultValue = (object) true;
        this.columnPrint2.Caption = "Print";
        this.columnPrint2.DefaultValue = (object) true;
        this.columnPrint1.Caption = "Print";
        this.columnPrint1.DefaultValue = (object) true;
        this.columnCategorie6.DefaultValue = (object) "FCI-AB";
        this.columnMainTitle.DefaultValue = (object) "Title";
        this.columnMaxRowCount6.Caption = "MaxRowCount";
        this.columnMaxRowCount6.DefaultValue = (object) 20;
        this.columnMaxRowCount5.Caption = "MaxRowCount";
        this.columnMaxRowCount5.DefaultValue = (object) 20;
        this.columnMaxRowCount4.Caption = "MaxRowCount";
        this.columnMaxRowCount4.DefaultValue = (object) 20;
        this.columnMaxRowCount3.Caption = "MaxRowCount";
        this.columnMaxRowCount3.DefaultValue = (object) 20;
        this.columnMaxRowCount2.Caption = "MaxRowCount";
        this.columnMaxRowCount2.DefaultValue = (object) 20;
        this.columnMaxRowCount6b.Caption = "MaxRowCount";
        this.columnMaxRowCount6b.DefaultValue = (object) 20;
        this.columnMaxRowCount1.Caption = "MaxRowCount";
        this.columnMaxRowCount1.DefaultValue = (object) 20;
        this.columnDescription6b.Caption = "Name";
        this.columnDescription6b.DefaultValue = (object) "";
        this.columnPrint6b.Caption = "Print";
        this.columnPrint6b.DefaultValue = (object) true;
        this.columnName6b.Caption = "Name";
        this.columnName6b.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.SettingsRow NewSettingsRow() => (ChampignonShip.SettingsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.SettingsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.SettingsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.SettingsRowChanged == null)
          return;
        this.SettingsRowChanged((object) this, new ChampignonShip.SettingsRowChangeEvent((ChampignonShip.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.SettingsRowChanging == null)
          return;
        this.SettingsRowChanging((object) this, new ChampignonShip.SettingsRowChangeEvent((ChampignonShip.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.SettingsRowDeleted == null)
          return;
        this.SettingsRowDeleted((object) this, new ChampignonShip.SettingsRowChangeEvent((ChampignonShip.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.SettingsRowDeleting == null)
          return;
        this.SettingsRowDeleting((object) this, new ChampignonShip.SettingsRowChangeEvent((ChampignonShip.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveSettingsRow(ChampignonShip.SettingsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (SettingsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query6DataTable : TypedTableBase<ChampignonShip.Query6Row>
    {
      private DataColumn columnID;
      private DataColumn columnNr;
      private DataColumn columnName;
      private DataColumn columnRingNumber;
      private DataColumn columnFlightCount;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnTotalDistance;
      private DataColumn columnFlightName;
      private DataColumn columnDateTime;
      private DataColumn columnDistance;
      private DataColumn columnPigeonPos;
      private DataColumn columnReleaseTime;
      private DataColumn columnPigeonCount;
      private DataColumn columnFCI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query6DataTable()
      {
        this.TableName = "Query6";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query6DataTable(DataTable table)
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
      protected Query6DataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NrColumn => this.columnNr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RingNumberColumn => this.columnRingNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightCountColumn => this.columnFlightCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalDistanceColumn => this.columnTotalDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FlightNameColumn => this.columnFlightName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DateTimeColumn => this.columnDateTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PigeonPosColumn => this.columnPigeonPos;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ReleaseTimeColumn => this.columnReleaseTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PigeonCountColumn => this.columnPigeonCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FCIColumn => this.columnFCI;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6Row this[int index] => (ChampignonShip.Query6Row) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6RowChangeEventHandler Query6RowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6RowChangeEventHandler Query6RowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6RowChangeEventHandler Query6RowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6RowChangeEventHandler Query6RowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery6Row(ChampignonShip.Query6Row row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6Row AddQuery6Row(
        int Nr,
        string Name,
        string RingNumber,
        int FlightCount,
        Decimal TotalCoefficient,
        Decimal TotalDistance,
        string FlightName,
        DateTime DateTime,
        Decimal Distance,
        int PigeonPos,
        DateTime ReleaseTime,
        int PigeonCount,
        Decimal FCI)
      {
        ChampignonShip.Query6Row query6Row = (ChampignonShip.Query6Row) this.NewRow();
        object[] objArray = new object[14]
        {
          null,
          (object) Nr,
          (object) Name,
          (object) RingNumber,
          (object) FlightCount,
          (object) TotalCoefficient,
          (object) TotalDistance,
          (object) FlightName,
          (object) DateTime,
          (object) Distance,
          (object) PigeonPos,
          (object) ReleaseTime,
          (object) PigeonCount,
          (object) FCI
        };
        query6Row.ItemArray = objArray;
        this.Rows.Add((DataRow) query6Row);
        return query6Row;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6Row FindByID(int ID) => (ChampignonShip.Query6Row) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query6DataTable query6DataTable = (ChampignonShip.Query6DataTable) base.Clone();
        query6DataTable.InitVars();
        return (DataTable) query6DataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query6DataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnNr = this.Columns["Nr"];
        this.columnName = this.Columns["Name"];
        this.columnRingNumber = this.Columns["RingNumber"];
        this.columnFlightCount = this.Columns["FlightCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnTotalDistance = this.Columns["TotalDistance"];
        this.columnFlightName = this.Columns["FlightName"];
        this.columnDateTime = this.Columns["DateTime"];
        this.columnDistance = this.Columns["Distance"];
        this.columnPigeonPos = this.Columns["PigeonPos"];
        this.columnReleaseTime = this.Columns["ReleaseTime"];
        this.columnPigeonCount = this.Columns["PigeonCount"];
        this.columnFCI = this.Columns["FCI"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnNr = new DataColumn("Nr", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNr);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnRingNumber = new DataColumn("RingNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRingNumber);
        this.columnFlightCount = new DataColumn("FlightCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnTotalDistance = new DataColumn("TotalDistance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalDistance);
        this.columnFlightName = new DataColumn("FlightName", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightName);
        this.columnDateTime = new DataColumn("DateTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDateTime);
        this.columnDistance = new DataColumn("Distance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnPigeonPos = new DataColumn("PigeonPos", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPigeonPos);
        this.columnReleaseTime = new DataColumn("ReleaseTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReleaseTime);
        this.columnPigeonCount = new DataColumn("PigeonCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPigeonCount);
        this.columnFCI = new DataColumn("FCI", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFCI);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
        this.columnFlightName.DefaultValue = (object) "";
        this.columnFCI.DefaultValue = (object) 0M;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6Row NewQuery6Row() => (ChampignonShip.Query6Row) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query6Row(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query6Row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query6RowChanged == null)
          return;
        this.Query6RowChanged((object) this, new ChampignonShip.Query6RowChangeEvent((ChampignonShip.Query6Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query6RowChanging == null)
          return;
        this.Query6RowChanging((object) this, new ChampignonShip.Query6RowChangeEvent((ChampignonShip.Query6Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query6RowDeleted == null)
          return;
        this.Query6RowDeleted((object) this, new ChampignonShip.Query6RowChangeEvent((ChampignonShip.Query6Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query6RowDeleting == null)
          return;
        this.Query6RowDeleting((object) this, new ChampignonShip.Query6RowChangeEvent((ChampignonShip.Query6Row) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery6Row(ChampignonShip.Query6Row row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query6DataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class FlightsDataTable : TypedTableBase<ChampignonShip.FlightsRow>
    {
      private DataColumn columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public FlightsDataTable()
      {
        this.TableName = "Flights";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal FlightsDataTable(DataTable table)
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
      protected FlightsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.FlightsRow this[int index] => (ChampignonShip.FlightsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.FlightsRowChangeEventHandler FlightsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.FlightsRowChangeEventHandler FlightsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.FlightsRowChangeEventHandler FlightsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.FlightsRowChangeEventHandler FlightsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddFlightsRow(ChampignonShip.FlightsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.FlightsRow AddFlightsRow(string Name)
      {
        ChampignonShip.FlightsRow flightsRow = (ChampignonShip.FlightsRow) this.NewRow();
        object[] objArray = new object[1]{ (object) Name };
        flightsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) flightsRow);
        return flightsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.FlightsRow FindByName(string Name) => (ChampignonShip.FlightsRow) this.Rows.Find(new object[1]
      {
        (object) Name
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.FlightsDataTable flightsDataTable = (ChampignonShip.FlightsDataTable) base.Clone();
        flightsDataTable.InitVars();
        return (DataTable) flightsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.FlightsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars() => this.columnName = this.Columns["Name"];

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.Constraints.Add((Constraint) new UniqueConstraint("FlightsKey1", new DataColumn[1]
        {
          this.columnName
        }, true));
        this.columnName.AllowDBNull = false;
        this.columnName.Unique = true;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.FlightsRow NewFlightsRow() => (ChampignonShip.FlightsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.FlightsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.FlightsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.FlightsRowChanged == null)
          return;
        this.FlightsRowChanged((object) this, new ChampignonShip.FlightsRowChangeEvent((ChampignonShip.FlightsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.FlightsRowChanging == null)
          return;
        this.FlightsRowChanging((object) this, new ChampignonShip.FlightsRowChangeEvent((ChampignonShip.FlightsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.FlightsRowDeleted == null)
          return;
        this.FlightsRowDeleted((object) this, new ChampignonShip.FlightsRowChangeEvent((ChampignonShip.FlightsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.FlightsRowDeleting == null)
          return;
        this.FlightsRowDeleting((object) this, new ChampignonShip.FlightsRowChangeEvent((ChampignonShip.FlightsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveFlightsRow(ChampignonShip.FlightsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (FlightsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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
    public class Query6bDataTable : TypedTableBase<ChampignonShip.Query6bRow>
    {
      private DataColumn columnID;
      private DataColumn columnName;
      private DataColumn columnPriceCount;
      private DataColumn columnTotalCoefficient;
      private DataColumn columnBaskettedCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query6bDataTable()
      {
        this.TableName = "Query6b";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query6bDataTable(DataTable table)
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
      protected Query6bDataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn PriceCountColumn => this.columnPriceCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TotalCoefficientColumn => this.columnTotalCoefficient;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BaskettedCountColumn => this.columnBaskettedCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6bRow this[int index] => (ChampignonShip.Query6bRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6bRowChangeEventHandler Query6bRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6bRowChangeEventHandler Query6bRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6bRowChangeEventHandler Query6bRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ChampignonShip.Query6bRowChangeEventHandler Query6bRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddQuery6bRow(ChampignonShip.Query6bRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6bRow AddQuery6bRow(
        string Name,
        int PriceCount,
        Decimal TotalCoefficient,
        int BaskettedCount)
      {
        ChampignonShip.Query6bRow query6bRow = (ChampignonShip.Query6bRow) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Name,
          (object) PriceCount,
          (object) TotalCoefficient,
          (object) BaskettedCount
        };
        query6bRow.ItemArray = objArray;
        this.Rows.Add((DataRow) query6bRow);
        return query6bRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6bRow FindByID(int ID) => (ChampignonShip.Query6bRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ChampignonShip.Query6bDataTable query6bDataTable = (ChampignonShip.Query6bDataTable) base.Clone();
        query6bDataTable.InitVars();
        return (DataTable) query6bDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ChampignonShip.Query6bDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnName = this.Columns["Name"];
        this.columnPriceCount = this.Columns["PriceCount"];
        this.columnTotalCoefficient = this.Columns["TotalCoefficient"];
        this.columnBaskettedCount = this.Columns["BaskettedCount"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnPriceCount = new DataColumn("PriceCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPriceCount);
        this.columnTotalCoefficient = new DataColumn("TotalCoefficient", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTotalCoefficient);
        this.columnBaskettedCount = new DataColumn("BaskettedCount", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBaskettedCount);
        this.Constraints.Add((Constraint) new UniqueConstraint("Query1Key1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnName.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6bRow NewQuery6bRow() => (ChampignonShip.Query6bRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ChampignonShip.Query6bRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ChampignonShip.Query6bRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.Query6bRowChanged == null)
          return;
        this.Query6bRowChanged((object) this, new ChampignonShip.Query6bRowChangeEvent((ChampignonShip.Query6bRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.Query6bRowChanging == null)
          return;
        this.Query6bRowChanging((object) this, new ChampignonShip.Query6bRowChangeEvent((ChampignonShip.Query6bRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.Query6bRowDeleted == null)
          return;
        this.Query6bRowDeleted((object) this, new ChampignonShip.Query6bRowChangeEvent((ChampignonShip.Query6bRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.Query6bRowDeleting == null)
          return;
        this.Query6bRowDeleting((object) this, new ChampignonShip.Query6bRowChangeEvent((ChampignonShip.Query6bRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveQuery6bRow(ChampignonShip.Query6bRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ChampignonShip champignonShip = new ChampignonShip();
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
          FixedValue = champignonShip.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (Query6bDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = champignonShip.GetSchemaSerializable();
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

    public class Query1Row : DataRow
    {
      private ChampignonShip.Query1DataTable tableQuery1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query1Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery1 = (ChampignonShip.Query1DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery1.IDColumn];
        set => this[this.tableQuery1.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery1.NameColumn];
        set => this[this.tableQuery1.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PriceCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery1.PriceCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PriceCount' in table 'Query1' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery1.PriceCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery1.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query1' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery1.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int BaskettedCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery1.BaskettedCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BaskettedCount' in table 'Query1' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery1.BaskettedCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery1.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery1.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPriceCountNull() => this.IsNull(this.tableQuery1.PriceCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPriceCountNull() => this[this.tableQuery1.PriceCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery1.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery1.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBaskettedCountNull() => this.IsNull(this.tableQuery1.BaskettedCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBaskettedCountNull() => this[this.tableQuery1.BaskettedCountColumn] = Convert.DBNull;
    }

    public class Query2Row : DataRow
    {
      private ChampignonShip.Query2DataTable tableQuery2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query2Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery2 = (ChampignonShip.Query2DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery2.IDColumn];
        set => this[this.tableQuery2.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery2.NameColumn];
        set => this[this.tableQuery2.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RingNumber
      {
        get => this.IsRingNumberNull() ? string.Empty : (string) this[this.tableQuery2.RingNumberColumn];
        set => this[this.tableQuery2.RingNumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery2.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query2' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery2.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PriceCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery2.PriceCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PriceCount' in table 'Query2' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery2.PriceCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery2.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery2.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRingNumberNull() => this.IsNull(this.tableQuery2.RingNumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRingNumberNull() => this[this.tableQuery2.RingNumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery2.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery2.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPriceCountNull() => this.IsNull(this.tableQuery2.PriceCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPriceCountNull() => this[this.tableQuery2.PriceCountColumn] = Convert.DBNull;
    }

    public class Query3Row : DataRow
    {
      private ChampignonShip.Query3DataTable tableQuery3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query3Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery3 = (ChampignonShip.Query3DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery3.IDColumn];
        set => this[this.tableQuery3.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery3.NameColumn];
        set => this[this.tableQuery3.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RingNumber
      {
        get => this.IsRingNumberNull() ? string.Empty : (string) this[this.tableQuery3.RingNumberColumn];
        set => this[this.tableQuery3.RingNumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PriceCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery3.PriceCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PriceCount' in table 'Query3' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery3.PriceCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery3.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query3' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery3.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery3.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery3.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRingNumberNull() => this.IsNull(this.tableQuery3.RingNumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRingNumberNull() => this[this.tableQuery3.RingNumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPriceCountNull() => this.IsNull(this.tableQuery3.PriceCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPriceCountNull() => this[this.tableQuery3.PriceCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery3.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery3.TotalCoefficientColumn] = Convert.DBNull;
    }

    public class Query4Row : DataRow
    {
      private ChampignonShip.Query4DataTable tableQuery4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query4Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery4 = (ChampignonShip.Query4DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery4.IDColumn];
        set => this[this.tableQuery4.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery4.NameColumn];
        set => this[this.tableQuery4.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PointCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery4.PointCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PointCount' in table 'Query4' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery4.PointCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery4.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query4' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery4.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int CountPerRace
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery4.CountPerRaceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CountPerRace' in table 'Query4' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery4.CountPerRaceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery4.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery4.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPointCountNull() => this.IsNull(this.tableQuery4.PointCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPointCountNull() => this[this.tableQuery4.PointCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery4.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery4.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCountPerRaceNull() => this.IsNull(this.tableQuery4.CountPerRaceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCountPerRaceNull() => this[this.tableQuery4.CountPerRaceColumn] = Convert.DBNull;
    }

    public class Query5Row : DataRow
    {
      private ChampignonShip.Query5DataTable tableQuery5;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query5Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery5 = (ChampignonShip.Query5DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery5.IDColumn];
        set => this[this.tableQuery5.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery5.NameColumn];
        set => this[this.tableQuery5.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PriceCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery5.PriceCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PriceCount' in table 'Query5' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery5.PriceCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery5.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query5' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery5.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int CountPerRace
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery5.CountPerRaceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CountPerRace' in table 'Query5' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery5.CountPerRaceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery5.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery5.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPriceCountNull() => this.IsNull(this.tableQuery5.PriceCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPriceCountNull() => this[this.tableQuery5.PriceCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery5.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery5.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCountPerRaceNull() => this.IsNull(this.tableQuery5.CountPerRaceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCountPerRaceNull() => this[this.tableQuery5.CountPerRaceColumn] = Convert.DBNull;
    }

    public class SettingsRow : DataRow
    {
      private ChampignonShip.SettingsDataTable tableSettings;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal SettingsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableSettings = (ChampignonShip.SettingsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableSettings.IDColumn];
        set => this[this.tableSettings.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Percentage
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableSettings.PercentageColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Percentage' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.PercentageColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name6
      {
        get => this.IsName6Null() ? string.Empty : (string) this[this.tableSettings.Name6Column];
        set => this[this.tableSettings.Name6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name5
      {
        get => this.IsName5Null() ? string.Empty : (string) this[this.tableSettings.Name5Column];
        set => this[this.tableSettings.Name5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name4
      {
        get => this.IsName4Null() ? string.Empty : (string) this[this.tableSettings.Name4Column];
        set => this[this.tableSettings.Name4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name3
      {
        get => this.IsName3Null() ? string.Empty : (string) this[this.tableSettings.Name3Column];
        set => this[this.tableSettings.Name3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name2
      {
        get => this.IsName2Null() ? string.Empty : (string) this[this.tableSettings.Name2Column];
        set => this[this.tableSettings.Name2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name1
      {
        get => this.IsName1Null() ? string.Empty : (string) this[this.tableSettings.Name1Column];
        set => this[this.tableSettings.Name1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description6
      {
        get => this.IsDescription6Null() ? string.Empty : (string) this[this.tableSettings.Description6Column];
        set => this[this.tableSettings.Description6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description5
      {
        get => this.IsDescription5Null() ? string.Empty : (string) this[this.tableSettings.Description5Column];
        set => this[this.tableSettings.Description5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description4
      {
        get => this.IsDescription4Null() ? string.Empty : (string) this[this.tableSettings.Description4Column];
        set => this[this.tableSettings.Description4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description3
      {
        get => this.IsDescription3Null() ? string.Empty : (string) this[this.tableSettings.Description3Column];
        set => this[this.tableSettings.Description3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description2
      {
        get => this.IsDescription2Null() ? string.Empty : (string) this[this.tableSettings.Description2Column];
        set => this[this.tableSettings.Description2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description1
      {
        get => this.IsDescription1Null() ? string.Empty : (string) this[this.tableSettings.Description1Column];
        set => this[this.tableSettings.Description1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number6
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.Number6Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number6' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Number6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number4b
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.Number4bColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number4b' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Number4bColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number4a
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.Number4aColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number4a' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Number4aColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number5
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.Number5Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number5' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Number5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Number3
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.Number3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Number3' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Number3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print6
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print6Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print6' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print5
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print5Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print5' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print4
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print4' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print3
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print3' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print2
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print2' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print1
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print1' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Categorie6
      {
        get => this.IsCategorie6Null() ? string.Empty : (string) this[this.tableSettings.Categorie6Column];
        set => this[this.tableSettings.Categorie6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string MainTitle
      {
        get => this.IsMainTitleNull() ? string.Empty : (string) this[this.tableSettings.MainTitleColumn];
        set => this[this.tableSettings.MainTitleColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount6
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount6Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount6' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount6Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount5
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount5Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount5' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount5Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount4
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount4Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount4' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount4Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount3
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount3Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount3' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount3Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount2
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount2' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount6b
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount6bColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount6b' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount6bColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int MaxRowCount1
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.MaxRowCount1Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'MaxRowCount1' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.MaxRowCount1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Description6b
      {
        get => this.IsDescription6bNull() ? string.Empty : (string) this[this.tableSettings.Description6bColumn];
        set => this[this.tableSettings.Description6bColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Print6b
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.Print6bColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Print6b' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.Print6bColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name6b
      {
        get => this.IsName6bNull() ? string.Empty : (string) this[this.tableSettings.Name6bColumn];
        set => this[this.tableSettings.Name6bColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPercentageNull() => this.IsNull(this.tableSettings.PercentageColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPercentageNull() => this[this.tableSettings.PercentageColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName6Null() => this.IsNull(this.tableSettings.Name6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName6Null() => this[this.tableSettings.Name6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName5Null() => this.IsNull(this.tableSettings.Name5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName5Null() => this[this.tableSettings.Name5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName4Null() => this.IsNull(this.tableSettings.Name4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName4Null() => this[this.tableSettings.Name4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName3Null() => this.IsNull(this.tableSettings.Name3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName3Null() => this[this.tableSettings.Name3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName2Null() => this.IsNull(this.tableSettings.Name2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName2Null() => this[this.tableSettings.Name2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName1Null() => this.IsNull(this.tableSettings.Name1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName1Null() => this[this.tableSettings.Name1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription6Null() => this.IsNull(this.tableSettings.Description6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription6Null() => this[this.tableSettings.Description6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription5Null() => this.IsNull(this.tableSettings.Description5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription5Null() => this[this.tableSettings.Description5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription4Null() => this.IsNull(this.tableSettings.Description4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription4Null() => this[this.tableSettings.Description4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription3Null() => this.IsNull(this.tableSettings.Description3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription3Null() => this[this.tableSettings.Description3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription2Null() => this.IsNull(this.tableSettings.Description2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription2Null() => this[this.tableSettings.Description2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription1Null() => this.IsNull(this.tableSettings.Description1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription1Null() => this[this.tableSettings.Description1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumber6Null() => this.IsNull(this.tableSettings.Number6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumber6Null() => this[this.tableSettings.Number6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumber4bNull() => this.IsNull(this.tableSettings.Number4bColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumber4bNull() => this[this.tableSettings.Number4bColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumber4aNull() => this.IsNull(this.tableSettings.Number4aColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumber4aNull() => this[this.tableSettings.Number4aColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumber5Null() => this.IsNull(this.tableSettings.Number5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumber5Null() => this[this.tableSettings.Number5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNumber3Null() => this.IsNull(this.tableSettings.Number3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNumber3Null() => this[this.tableSettings.Number3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint6Null() => this.IsNull(this.tableSettings.Print6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint6Null() => this[this.tableSettings.Print6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint5Null() => this.IsNull(this.tableSettings.Print5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint5Null() => this[this.tableSettings.Print5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint4Null() => this.IsNull(this.tableSettings.Print4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint4Null() => this[this.tableSettings.Print4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint3Null() => this.IsNull(this.tableSettings.Print3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint3Null() => this[this.tableSettings.Print3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint2Null() => this.IsNull(this.tableSettings.Print2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint2Null() => this[this.tableSettings.Print2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint1Null() => this.IsNull(this.tableSettings.Print1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint1Null() => this[this.tableSettings.Print1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCategorie6Null() => this.IsNull(this.tableSettings.Categorie6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCategorie6Null() => this[this.tableSettings.Categorie6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMainTitleNull() => this.IsNull(this.tableSettings.MainTitleColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMainTitleNull() => this[this.tableSettings.MainTitleColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount6Null() => this.IsNull(this.tableSettings.MaxRowCount6Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount6Null() => this[this.tableSettings.MaxRowCount6Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount5Null() => this.IsNull(this.tableSettings.MaxRowCount5Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount5Null() => this[this.tableSettings.MaxRowCount5Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount4Null() => this.IsNull(this.tableSettings.MaxRowCount4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount4Null() => this[this.tableSettings.MaxRowCount4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount3Null() => this.IsNull(this.tableSettings.MaxRowCount3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount3Null() => this[this.tableSettings.MaxRowCount3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount2Null() => this.IsNull(this.tableSettings.MaxRowCount2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount2Null() => this[this.tableSettings.MaxRowCount2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount6bNull() => this.IsNull(this.tableSettings.MaxRowCount6bColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount6bNull() => this[this.tableSettings.MaxRowCount6bColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsMaxRowCount1Null() => this.IsNull(this.tableSettings.MaxRowCount1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetMaxRowCount1Null() => this[this.tableSettings.MaxRowCount1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDescription6bNull() => this.IsNull(this.tableSettings.Description6bColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDescription6bNull() => this[this.tableSettings.Description6bColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPrint6bNull() => this.IsNull(this.tableSettings.Print6bColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPrint6bNull() => this[this.tableSettings.Print6bColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsName6bNull() => this.IsNull(this.tableSettings.Name6bColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetName6bNull() => this[this.tableSettings.Name6bColumn] = Convert.DBNull;
    }

    public class Query6Row : DataRow
    {
      private ChampignonShip.Query6DataTable tableQuery6;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query6Row(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery6 = (ChampignonShip.Query6DataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery6.IDColumn];
        set => this[this.tableQuery6.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Nr
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6.NrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Nr' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.NrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery6.NameColumn];
        set => this[this.tableQuery6.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RingNumber
      {
        get
        {
          try
          {
            return (string) this[this.tableQuery6.RingNumberColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RingNumber' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.RingNumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FlightCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6.FlightCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightCount' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.FlightCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery6.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalDistance
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery6.TotalDistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalDistance' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.TotalDistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FlightName
      {
        get => this.IsFlightNameNull() ? string.Empty : (string) this[this.tableQuery6.FlightNameColumn];
        set => this[this.tableQuery6.FlightNameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime DateTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableQuery6.DateTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'DateTime' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.DateTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal Distance
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery6.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PigeonPos
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6.PigeonPosColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PigeonPos' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.PigeonPosColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ReleaseTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableQuery6.ReleaseTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReleaseTime' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.ReleaseTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PigeonCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6.PigeonCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PigeonCount' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.PigeonCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal FCI
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery6.FCIColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FCI' in table 'Query6' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6.FCIColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNrNull() => this.IsNull(this.tableQuery6.NrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNrNull() => this[this.tableQuery6.NrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery6.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery6.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRingNumberNull() => this.IsNull(this.tableQuery6.RingNumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRingNumberNull() => this[this.tableQuery6.RingNumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightCountNull() => this.IsNull(this.tableQuery6.FlightCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightCountNull() => this[this.tableQuery6.FlightCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery6.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery6.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalDistanceNull() => this.IsNull(this.tableQuery6.TotalDistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalDistanceNull() => this[this.tableQuery6.TotalDistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFlightNameNull() => this.IsNull(this.tableQuery6.FlightNameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFlightNameNull() => this[this.tableQuery6.FlightNameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDateTimeNull() => this.IsNull(this.tableQuery6.DateTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDateTimeNull() => this[this.tableQuery6.DateTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableQuery6.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableQuery6.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPigeonPosNull() => this.IsNull(this.tableQuery6.PigeonPosColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPigeonPosNull() => this[this.tableQuery6.PigeonPosColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsReleaseTimeNull() => this.IsNull(this.tableQuery6.ReleaseTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetReleaseTimeNull() => this[this.tableQuery6.ReleaseTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPigeonCountNull() => this.IsNull(this.tableQuery6.PigeonCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPigeonCountNull() => this[this.tableQuery6.PigeonCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFCINull() => this.IsNull(this.tableQuery6.FCIColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFCINull() => this[this.tableQuery6.FCIColumn] = Convert.DBNull;
    }

    public class FlightsRow : DataRow
    {
      private ChampignonShip.FlightsDataTable tableFlights;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal FlightsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableFlights = (ChampignonShip.FlightsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => (string) this[this.tableFlights.NameColumn];
        set => this[this.tableFlights.NameColumn] = (object) value;
      }
    }

    public class Query6bRow : DataRow
    {
      private ChampignonShip.Query6bDataTable tableQuery6b;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal Query6bRow(DataRowBuilder rb)
        : base(rb)
        => this.tableQuery6b = (ChampignonShip.Query6bDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableQuery6b.IDColumn];
        set => this[this.tableQuery6b.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableQuery6b.NameColumn];
        set => this[this.tableQuery6b.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int PriceCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6b.PriceCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PriceCount' in table 'Query6b' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6b.PriceCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal TotalCoefficient
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableQuery6b.TotalCoefficientColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TotalCoefficient' in table 'Query6b' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6b.TotalCoefficientColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int BaskettedCount
      {
        get
        {
          try
          {
            return (int) this[this.tableQuery6b.BaskettedCountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BaskettedCount' in table 'Query6b' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableQuery6b.BaskettedCountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableQuery6b.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableQuery6b.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPriceCountNull() => this.IsNull(this.tableQuery6b.PriceCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPriceCountNull() => this[this.tableQuery6b.PriceCountColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTotalCoefficientNull() => this.IsNull(this.tableQuery6b.TotalCoefficientColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTotalCoefficientNull() => this[this.tableQuery6b.TotalCoefficientColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBaskettedCountNull() => this.IsNull(this.tableQuery6b.BaskettedCountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBaskettedCountNull() => this[this.tableQuery6b.BaskettedCountColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query1RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query1Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query1RowChangeEvent(ChampignonShip.Query1Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query1Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query2RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query2Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query2RowChangeEvent(ChampignonShip.Query2Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query2Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query3RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query3Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query3RowChangeEvent(ChampignonShip.Query3Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query3Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query4RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query4Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query4RowChangeEvent(ChampignonShip.Query4Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query4Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query5RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query5Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query5RowChangeEvent(ChampignonShip.Query5Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query5Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class SettingsRowChangeEvent : EventArgs
    {
      private ChampignonShip.SettingsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SettingsRowChangeEvent(ChampignonShip.SettingsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.SettingsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query6RowChangeEvent : EventArgs
    {
      private ChampignonShip.Query6Row eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query6RowChangeEvent(ChampignonShip.Query6Row row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6Row Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class FlightsRowChangeEvent : EventArgs
    {
      private ChampignonShip.FlightsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public FlightsRowChangeEvent(ChampignonShip.FlightsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.FlightsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class Query6bRowChangeEvent : EventArgs
    {
      private ChampignonShip.Query6bRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Query6bRowChangeEvent(ChampignonShip.Query6bRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ChampignonShip.Query6bRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
