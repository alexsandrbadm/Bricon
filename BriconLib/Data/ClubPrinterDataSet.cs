// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.ClubPrinterDataSet
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
  [XmlRoot("ClubPrinterDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class ClubPrinterDataSet : DataSet
  {
    private ClubPrinterDataSet.PigeonsDataTable tablePigeons;
    private ClubPrinterDataSet.SettingsDataTable tableSettings;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public ClubPrinterDataSet()
    {
      this.BeginInit();
      this.InitClass();
      CollectionChangeEventHandler changeEventHandler = new CollectionChangeEventHandler(this.SchemaChanged);
      base.Tables.CollectionChanged += changeEventHandler;
      base.Relations.CollectionChanged += changeEventHandler;
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected ClubPrinterDataSet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (Pigeons)] != null)
            base.Tables.Add((DataTable) new ClubPrinterDataSet.PigeonsDataTable(dataSet.Tables[nameof (Pigeons)]));
          if (dataSet.Tables[nameof (Settings)] != null)
            base.Tables.Add((DataTable) new ClubPrinterDataSet.SettingsDataTable(dataSet.Tables[nameof (Settings)]));
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
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ClubPrinterDataSet.PigeonsDataTable Pigeons => this.tablePigeons;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ClubPrinterDataSet.SettingsDataTable Settings => this.tableSettings;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public override SchemaSerializationMode SchemaSerializationMode
    {
      get => this._schemaSerializationMode;
      set => this._schemaSerializationMode = value;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataTableCollection Tables => base.Tables;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public new DataRelationCollection Relations => base.Relations;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override void InitializeDerivedDataSet()
    {
      this.BeginInit();
      this.InitClass();
      this.EndInit();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public override DataSet Clone()
    {
      ClubPrinterDataSet clubPrinterDataSet = (ClubPrinterDataSet) base.Clone();
      clubPrinterDataSet.InitVars();
      clubPrinterDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) clubPrinterDataSet;
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override bool ShouldSerializeTables() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override bool ShouldSerializeRelations() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override void ReadXmlSerializable(XmlReader reader)
    {
      if (this.DetermineSchemaSerializationMode(reader) == SchemaSerializationMode.IncludeSchema)
      {
        this.Reset();
        DataSet dataSet = new DataSet();
        int num = (int) dataSet.ReadXml(reader);
        if (dataSet.Tables["Pigeons"] != null)
          base.Tables.Add((DataTable) new ClubPrinterDataSet.PigeonsDataTable(dataSet.Tables["Pigeons"]));
        if (dataSet.Tables["Settings"] != null)
          base.Tables.Add((DataTable) new ClubPrinterDataSet.SettingsDataTable(dataSet.Tables["Settings"]));
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
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    protected override XmlSchema GetSchemaSerializable()
    {
      MemoryStream memoryStream = new MemoryStream();
      this.WriteXmlSchema((XmlWriter) new XmlTextWriter((Stream) memoryStream, (Encoding) null));
      memoryStream.Position = 0L;
      return XmlSchema.Read((XmlReader) new XmlTextReader((Stream) memoryStream), (ValidationEventHandler) null);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal void InitVars() => this.InitVars(true);

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    internal void InitVars(bool initTable)
    {
      this.tablePigeons = (ClubPrinterDataSet.PigeonsDataTable) base.Tables["Pigeons"];
      if (initTable && this.tablePigeons != null)
        this.tablePigeons.InitVars();
      this.tableSettings = (ClubPrinterDataSet.SettingsDataTable) base.Tables["Settings"];
      if (!initTable || this.tableSettings == null)
        return;
      this.tableSettings.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (ClubPrinterDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/ReadOutDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tablePigeons = new ClubPrinterDataSet.PigeonsDataTable();
      base.Tables.Add((DataTable) this.tablePigeons);
      this.tableSettings = new ClubPrinterDataSet.SettingsDataTable();
      base.Tables.Add((DataTable) this.tableSettings);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private bool ShouldSerializePigeons() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private bool ShouldSerializeSettings() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void SchemaChanged(object sender, CollectionChangeEventArgs e)
    {
      if (e.Action != CollectionChangeAction.Remove)
        return;
      this.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public static XmlSchemaComplexType GetTypedDataSetSchema(XmlSchemaSet xs)
    {
      ClubPrinterDataSet clubPrinterDataSet = new ClubPrinterDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = clubPrinterDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = clubPrinterDataSet.GetSchemaSerializable();
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

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public delegate void PigeonsRowChangeEventHandler(
      object sender,
      ClubPrinterDataSet.PigeonsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public delegate void SettingsRowChangeEventHandler(
      object sender,
      ClubPrinterDataSet.SettingsRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class PigeonsDataTable : TypedTableBase<ClubPrinterDataSet.PigeonsRow>
    {
      private DataColumn columnID;
      private DataColumn columnElBand;
      private DataColumn columnFedBand;
      private DataColumn columnPosition1;
      private DataColumn columnPosition2;
      private DataColumn columnPosition3;
      private DataColumn columnPosition4;
      private DataColumn columnTime;
      private DataColumn columnNr;
      private DataColumn columnSerial;
      private DataColumn columnEvaluatie;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public PigeonsDataTable()
      {
        this.TableName = "Pigeons";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected PigeonsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ElBandColumn => this.columnElBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn FedBandColumn => this.columnFedBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn Position1Column => this.columnPosition1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn Position2Column => this.columnPosition2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn Position3Column => this.columnPosition3;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn Position4Column => this.columnPosition4;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TimeColumn => this.columnTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn NrColumn => this.columnNr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SerialColumn => this.columnSerial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn EvaluatieColumn => this.columnEvaluatie;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.PigeonsRow this[int index] => (ClubPrinterDataSet.PigeonsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.PigeonsRowChangeEventHandler PigeonsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.PigeonsRowChangeEventHandler PigeonsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void AddPigeonsRow(ClubPrinterDataSet.PigeonsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.PigeonsRow AddPigeonsRow(
        string ElBand,
        string FedBand,
        int Position1,
        int Position2,
        int Position3,
        int Position4,
        DateTime Time,
        string Nr,
        string Serial,
        string Evaluatie)
      {
        ClubPrinterDataSet.PigeonsRow pigeonsRow = (ClubPrinterDataSet.PigeonsRow) this.NewRow();
        object[] objArray = new object[11]
        {
          null,
          (object) ElBand,
          (object) FedBand,
          (object) Position1,
          (object) Position2,
          (object) Position3,
          (object) Position4,
          (object) Time,
          (object) Nr,
          (object) Serial,
          (object) Evaluatie
        };
        pigeonsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) pigeonsRow);
        return pigeonsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.PigeonsRow FindByID(int ID) => (ClubPrinterDataSet.PigeonsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public override DataTable Clone()
      {
        ClubPrinterDataSet.PigeonsDataTable pigeonsDataTable = (ClubPrinterDataSet.PigeonsDataTable) base.Clone();
        pigeonsDataTable.InitVars();
        return (DataTable) pigeonsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ClubPrinterDataSet.PigeonsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnElBand = this.Columns["ElBand"];
        this.columnFedBand = this.Columns["FedBand"];
        this.columnPosition1 = this.Columns["Position1"];
        this.columnPosition2 = this.Columns["Position2"];
        this.columnPosition3 = this.Columns["Position3"];
        this.columnPosition4 = this.Columns["Position4"];
        this.columnTime = this.Columns["Time"];
        this.columnNr = this.Columns["Nr"];
        this.columnSerial = this.Columns["Serial"];
        this.columnEvaluatie = this.Columns["Evaluatie"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnElBand = new DataColumn("ElBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnElBand);
        this.columnFedBand = new DataColumn("FedBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFedBand);
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
        this.columnNr = new DataColumn("Nr", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNr);
        this.columnSerial = new DataColumn("Serial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerial);
        this.columnEvaluatie = new DataColumn("Evaluatie", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEvaluatie);
        this.Constraints.Add((Constraint) new UniqueConstraint("PigeonsKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.PigeonsRow NewPigeonsRow() => (ClubPrinterDataSet.PigeonsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ClubPrinterDataSet.PigeonsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override Type GetRowType() => typeof (ClubPrinterDataSet.PigeonsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PigeonsRowChanged == null)
          return;
        this.PigeonsRowChanged((object) this, new ClubPrinterDataSet.PigeonsRowChangeEvent((ClubPrinterDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PigeonsRowChanging == null)
          return;
        this.PigeonsRowChanging((object) this, new ClubPrinterDataSet.PigeonsRowChangeEvent((ClubPrinterDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PigeonsRowDeleted == null)
          return;
        this.PigeonsRowDeleted((object) this, new ClubPrinterDataSet.PigeonsRowChangeEvent((ClubPrinterDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PigeonsRowDeleting == null)
          return;
        this.PigeonsRowDeleting((object) this, new ClubPrinterDataSet.PigeonsRowChangeEvent((ClubPrinterDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void RemovePigeonsRow(ClubPrinterDataSet.PigeonsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ClubPrinterDataSet clubPrinterDataSet = new ClubPrinterDataSet();
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
          FixedValue = clubPrinterDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PigeonsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = clubPrinterDataSet.GetSchemaSerializable();
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
    public class SettingsDataTable : TypedTableBase<ClubPrinterDataSet.SettingsRow>
    {
      private DataColumn columnID;
      private DataColumn columnLicense;
      private DataColumn columnName;
      private DataColumn columnAddress;
      private DataColumn columnZipCode;
      private DataColumn columnCity;
      private DataColumn columnCoordX;
      private DataColumn columnCoordY;
      private DataColumn columnBASerial;
      private DataColumn columnSerial;
      private DataColumn columnFlightName;
      private DataColumn columnClubID;
      private DataColumn columnFlightID;
      private DataColumn columnDateTime;
      private DataColumn columnBasketingMasterTime;
      private DataColumn columnBasketingInternalTime;
      private DataColumn columnBasketingDiff;
      private DataColumn columnReadOutMasterTime;
      private DataColumn columnReadOutInternalTime;
      private DataColumn columnReadOutDiff;
      private DataColumn columnDiff;
      private DataColumn columnCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public SettingsDataTable()
      {
        this.TableName = "Settings";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected SettingsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn LicenseColumn => this.columnLicense;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn AddressColumn => this.columnAddress;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ZipCodeColumn => this.columnZipCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn CityColumn => this.columnCity;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn CoordXColumn => this.columnCoordX;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn CoordYColumn => this.columnCoordY;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn BASerialColumn => this.columnBASerial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SerialColumn => this.columnSerial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn FlightNameColumn => this.columnFlightName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn FlightIDColumn => this.columnFlightID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn DateTimeColumn => this.columnDateTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn BasketingMasterTimeColumn => this.columnBasketingMasterTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn BasketingInternalTimeColumn => this.columnBasketingInternalTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn BasketingDiffColumn => this.columnBasketingDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ReadOutMasterTimeColumn => this.columnReadOutMasterTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ReadOutInternalTimeColumn => this.columnReadOutInternalTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ReadOutDiffColumn => this.columnReadOutDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn DiffColumn => this.columnDiff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn CountColumn => this.columnCount;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.SettingsRow this[int index] => (ClubPrinterDataSet.SettingsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.SettingsRowChangeEventHandler SettingsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.SettingsRowChangeEventHandler SettingsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.SettingsRowChangeEventHandler SettingsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event ClubPrinterDataSet.SettingsRowChangeEventHandler SettingsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void AddSettingsRow(ClubPrinterDataSet.SettingsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.SettingsRow AddSettingsRow(
        string License,
        string Name,
        string Address,
        string ZipCode,
        string City,
        string CoordX,
        string CoordY,
        string BASerial,
        string Serial,
        string FlightName,
        string ClubID,
        string FlightID,
        DateTime DateTime,
        DateTime BasketingMasterTime,
        DateTime BasketingInternalTime,
        string BasketingDiff,
        DateTime ReadOutMasterTime,
        DateTime ReadOutInternalTime,
        string ReadOutDiff,
        string Diff,
        int Count)
      {
        ClubPrinterDataSet.SettingsRow settingsRow = (ClubPrinterDataSet.SettingsRow) this.NewRow();
        object[] objArray = new object[22]
        {
          null,
          (object) License,
          (object) Name,
          (object) Address,
          (object) ZipCode,
          (object) City,
          (object) CoordX,
          (object) CoordY,
          (object) BASerial,
          (object) Serial,
          (object) FlightName,
          (object) ClubID,
          (object) FlightID,
          (object) DateTime,
          (object) BasketingMasterTime,
          (object) BasketingInternalTime,
          (object) BasketingDiff,
          (object) ReadOutMasterTime,
          (object) ReadOutInternalTime,
          (object) ReadOutDiff,
          (object) Diff,
          (object) Count
        };
        settingsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) settingsRow);
        return settingsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.SettingsRow FindByID(int ID) => (ClubPrinterDataSet.SettingsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public override DataTable Clone()
      {
        ClubPrinterDataSet.SettingsDataTable settingsDataTable = (ClubPrinterDataSet.SettingsDataTable) base.Clone();
        settingsDataTable.InitVars();
        return (DataTable) settingsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ClubPrinterDataSet.SettingsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
        this.columnBASerial = this.Columns["BASerial"];
        this.columnSerial = this.Columns["Serial"];
        this.columnFlightName = this.Columns["FlightName"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnFlightID = this.Columns["FlightID"];
        this.columnDateTime = this.Columns["DateTime"];
        this.columnBasketingMasterTime = this.Columns["BasketingMasterTime"];
        this.columnBasketingInternalTime = this.Columns["BasketingInternalTime"];
        this.columnBasketingDiff = this.Columns["BasketingDiff"];
        this.columnReadOutMasterTime = this.Columns["ReadOutMasterTime"];
        this.columnReadOutInternalTime = this.Columns["ReadOutInternalTime"];
        this.columnReadOutDiff = this.Columns["ReadOutDiff"];
        this.columnDiff = this.Columns["Diff"];
        this.columnCount = this.Columns["Count"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
        this.columnBASerial = new DataColumn("BASerial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBASerial);
        this.columnSerial = new DataColumn("Serial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerial);
        this.columnFlightName = new DataColumn("FlightName", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightName);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnFlightID = new DataColumn("FlightID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFlightID);
        this.columnDateTime = new DataColumn("DateTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDateTime);
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
        this.columnCount = new DataColumn("Count", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCount);
        this.Constraints.Add((Constraint) new UniqueConstraint("PigeonsKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnBASerial.Caption = "Serial";
        this.columnFlightName.Caption = "ClubID";
        this.columnBasketingMasterTime.Caption = "Basketing Master Time";
        this.columnBasketingInternalTime.Caption = "Basketing Internal Time";
        this.columnBasketingDiff.Caption = "Basketing Diff";
        this.columnReadOutMasterTime.Caption = "ReadOut Master Time";
        this.columnReadOutInternalTime.Caption = "ReadOut Internal Time";
        this.columnReadOutDiff.Caption = "ReadOut Diff";
        this.columnCount.DefaultValue = (object) 0;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.SettingsRow NewSettingsRow() => (ClubPrinterDataSet.SettingsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ClubPrinterDataSet.SettingsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override Type GetRowType() => typeof (ClubPrinterDataSet.SettingsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.SettingsRowChanged == null)
          return;
        this.SettingsRowChanged((object) this, new ClubPrinterDataSet.SettingsRowChangeEvent((ClubPrinterDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.SettingsRowChanging == null)
          return;
        this.SettingsRowChanging((object) this, new ClubPrinterDataSet.SettingsRowChangeEvent((ClubPrinterDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.SettingsRowDeleted == null)
          return;
        this.SettingsRowDeleted((object) this, new ClubPrinterDataSet.SettingsRowChangeEvent((ClubPrinterDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.SettingsRowDeleting == null)
          return;
        this.SettingsRowDeleting((object) this, new ClubPrinterDataSet.SettingsRowChangeEvent((ClubPrinterDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void RemoveSettingsRow(ClubPrinterDataSet.SettingsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ClubPrinterDataSet clubPrinterDataSet = new ClubPrinterDataSet();
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
          FixedValue = clubPrinterDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (SettingsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = clubPrinterDataSet.GetSchemaSerializable();
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

    public class PigeonsRow : DataRow
    {
      private ClubPrinterDataSet.PigeonsDataTable tablePigeons;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal PigeonsRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePigeons = (ClubPrinterDataSet.PigeonsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int ID
      {
        get => (int) this[this.tablePigeons.IDColumn];
        set => this[this.tablePigeons.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
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
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Serial
      {
        get => this.IsSerialNull() ? string.Empty : (string) this[this.tablePigeons.SerialColumn];
        set => this[this.tablePigeons.SerialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Evaluatie
      {
        get
        {
          try
          {
            return (string) this[this.tablePigeons.EvaluatieColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Evaluatie' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.EvaluatieColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsElBandNull() => this.IsNull(this.tablePigeons.ElBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetElBandNull() => this[this.tablePigeons.ElBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsFedBandNull() => this.IsNull(this.tablePigeons.FedBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetFedBandNull() => this[this.tablePigeons.FedBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPosition1Null() => this.IsNull(this.tablePigeons.Position1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPosition1Null() => this[this.tablePigeons.Position1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPosition2Null() => this.IsNull(this.tablePigeons.Position2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPosition2Null() => this[this.tablePigeons.Position2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPosition3Null() => this.IsNull(this.tablePigeons.Position3Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPosition3Null() => this[this.tablePigeons.Position3Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPosition4Null() => this.IsNull(this.tablePigeons.Position4Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPosition4Null() => this[this.tablePigeons.Position4Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsTimeNull() => this.IsNull(this.tablePigeons.TimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetTimeNull() => this[this.tablePigeons.TimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsNrNull() => this.IsNull(this.tablePigeons.NrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetNrNull() => this[this.tablePigeons.NrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSerialNull() => this.IsNull(this.tablePigeons.SerialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSerialNull() => this[this.tablePigeons.SerialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsEvaluatieNull() => this.IsNull(this.tablePigeons.EvaluatieColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetEvaluatieNull() => this[this.tablePigeons.EvaluatieColumn] = Convert.DBNull;
    }

    public class SettingsRow : DataRow
    {
      private ClubPrinterDataSet.SettingsDataTable tableSettings;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal SettingsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableSettings = (ClubPrinterDataSet.SettingsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableSettings.IDColumn];
        set => this[this.tableSettings.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string License
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.LicenseColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'License' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.LicenseColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Name
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.NameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Name' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Address
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.AddressColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Address' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.AddressColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string ZipCode
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.ZipCodeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ZipCode' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.ZipCodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string City
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.CityColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'City' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CityColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string CoordX
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.CoordXColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordX' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CoordXColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string CoordY
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.CoordYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CoordY' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CoordYColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string BASerial
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.BASerialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BASerial' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.BASerialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Serial
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.SerialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Serial' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.SerialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string FlightName
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.FlightNameColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightName' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.FlightNameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string ClubID
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.ClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubID' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string FlightID
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.FlightIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FlightID' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.FlightIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime DateTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSettings.DateTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'DateTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.DateTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime BasketingMasterTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSettings.BasketingMasterTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingMasterTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.BasketingMasterTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime BasketingInternalTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSettings.BasketingInternalTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingInternalTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.BasketingInternalTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string BasketingDiff
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.BasketingDiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'BasketingDiff' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.BasketingDiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime ReadOutMasterTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSettings.ReadOutMasterTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutMasterTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.ReadOutMasterTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime ReadOutInternalTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableSettings.ReadOutInternalTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutInternalTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.ReadOutInternalTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string ReadOutDiff
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.ReadOutDiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReadOutDiff' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.ReadOutDiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Diff
      {
        get
        {
          try
          {
            return (string) this[this.tableSettings.DiffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Diff' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.DiffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int Count
      {
        get
        {
          try
          {
            return (int) this[this.tableSettings.CountColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Count' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CountColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsLicenseNull() => this.IsNull(this.tableSettings.LicenseColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetLicenseNull() => this[this.tableSettings.LicenseColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableSettings.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetNameNull() => this[this.tableSettings.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsAddressNull() => this.IsNull(this.tableSettings.AddressColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetAddressNull() => this[this.tableSettings.AddressColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsZipCodeNull() => this.IsNull(this.tableSettings.ZipCodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetZipCodeNull() => this[this.tableSettings.ZipCodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsCityNull() => this.IsNull(this.tableSettings.CityColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetCityNull() => this[this.tableSettings.CityColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsCoordXNull() => this.IsNull(this.tableSettings.CoordXColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetCoordXNull() => this[this.tableSettings.CoordXColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsCoordYNull() => this.IsNull(this.tableSettings.CoordYColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetCoordYNull() => this[this.tableSettings.CoordYColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsBASerialNull() => this.IsNull(this.tableSettings.BASerialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetBASerialNull() => this[this.tableSettings.BASerialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSerialNull() => this.IsNull(this.tableSettings.SerialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSerialNull() => this[this.tableSettings.SerialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsFlightNameNull() => this.IsNull(this.tableSettings.FlightNameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetFlightNameNull() => this[this.tableSettings.FlightNameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tableSettings.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetClubIDNull() => this[this.tableSettings.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsFlightIDNull() => this.IsNull(this.tableSettings.FlightIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetFlightIDNull() => this[this.tableSettings.FlightIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsDateTimeNull() => this.IsNull(this.tableSettings.DateTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetDateTimeNull() => this[this.tableSettings.DateTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsBasketingMasterTimeNull() => this.IsNull(this.tableSettings.BasketingMasterTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetBasketingMasterTimeNull() => this[this.tableSettings.BasketingMasterTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsBasketingInternalTimeNull() => this.IsNull(this.tableSettings.BasketingInternalTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetBasketingInternalTimeNull() => this[this.tableSettings.BasketingInternalTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsBasketingDiffNull() => this.IsNull(this.tableSettings.BasketingDiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetBasketingDiffNull() => this[this.tableSettings.BasketingDiffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsReadOutMasterTimeNull() => this.IsNull(this.tableSettings.ReadOutMasterTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetReadOutMasterTimeNull() => this[this.tableSettings.ReadOutMasterTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsReadOutInternalTimeNull() => this.IsNull(this.tableSettings.ReadOutInternalTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetReadOutInternalTimeNull() => this[this.tableSettings.ReadOutInternalTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsReadOutDiffNull() => this.IsNull(this.tableSettings.ReadOutDiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetReadOutDiffNull() => this[this.tableSettings.ReadOutDiffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsDiffNull() => this.IsNull(this.tableSettings.DiffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetDiffNull() => this[this.tableSettings.DiffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsCountNull() => this.IsNull(this.tableSettings.CountColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetCountNull() => this[this.tableSettings.CountColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public class PigeonsRowChangeEvent : EventArgs
    {
      private ClubPrinterDataSet.PigeonsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public PigeonsRowChangeEvent(ClubPrinterDataSet.PigeonsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.PigeonsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public class SettingsRowChangeEvent : EventArgs
    {
      private ClubPrinterDataSet.SettingsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public SettingsRowChangeEvent(ClubPrinterDataSet.SettingsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public ClubPrinterDataSet.SettingsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
