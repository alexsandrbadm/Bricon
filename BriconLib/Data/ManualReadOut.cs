// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.ManualReadOut
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
  [XmlRoot("ManualReadOut")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class ManualReadOut : DataSet
  {
    private ManualReadOut.InformationDataTable tableInformation;
    private ManualReadOut.PigeonsDataTable tablePigeons;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public ManualReadOut()
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
    protected ManualReadOut(SerializationInfo info, StreamingContext context)
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
            base.Tables.Add((DataTable) new ManualReadOut.InformationDataTable(dataSet.Tables[nameof (Information)]));
          if (dataSet.Tables[nameof (Pigeons)] != null)
            base.Tables.Add((DataTable) new ManualReadOut.PigeonsDataTable(dataSet.Tables[nameof (Pigeons)]));
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
    public ManualReadOut.InformationDataTable Information => this.tableInformation;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public ManualReadOut.PigeonsDataTable Pigeons => this.tablePigeons;

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
      ManualReadOut manualReadOut = (ManualReadOut) base.Clone();
      manualReadOut.InitVars();
      manualReadOut.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) manualReadOut;
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
          base.Tables.Add((DataTable) new ManualReadOut.InformationDataTable(dataSet.Tables["Information"]));
        if (dataSet.Tables["Pigeons"] != null)
          base.Tables.Add((DataTable) new ManualReadOut.PigeonsDataTable(dataSet.Tables["Pigeons"]));
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
      this.tableInformation = (ManualReadOut.InformationDataTable) base.Tables["Information"];
      if (initTable && this.tableInformation != null)
        this.tableInformation.InitVars();
      this.tablePigeons = (ManualReadOut.PigeonsDataTable) base.Tables["Pigeons"];
      if (!initTable || this.tablePigeons == null)
        return;
      this.tablePigeons.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (ManualReadOut);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/ManualReadOut.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableInformation = new ManualReadOut.InformationDataTable();
      base.Tables.Add((DataTable) this.tableInformation);
      this.tablePigeons = new ManualReadOut.PigeonsDataTable();
      base.Tables.Add((DataTable) this.tablePigeons);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeInformation() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializePigeons() => false;

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
      ManualReadOut manualReadOut = new ManualReadOut();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = manualReadOut.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = manualReadOut.GetSchemaSerializable();
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
    public class InformationDataTable : TypedTableBase<ManualReadOut.InformationRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnBasketed;
      private DataColumn columnTimeSet;
      private DataColumn columnStrikeOff;
      private DataColumn columnClockTime;
      private DataColumn columnDistance;
      private DataColumn columnDistanceString;
      private DataColumn columnTimeSetClock;

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
      public DataColumn FancierIDColumn => this.columnFancierID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BasketedColumn => this.columnBasketed;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeSetColumn => this.columnTimeSet;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn StrikeOffColumn => this.columnStrikeOff;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClockTimeColumn => this.columnClockTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceStringColumn => this.columnDistanceString;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeSetClockColumn => this.columnTimeSetClock;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.InformationRow this[int index] => (ManualReadOut.InformationRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.InformationRowChangeEventHandler InformationRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.InformationRowChangeEventHandler InformationRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.InformationRowChangeEventHandler InformationRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.InformationRowChangeEventHandler InformationRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddInformationRow(ManualReadOut.InformationRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.InformationRow AddInformationRow(
        int FancierID,
        int Basketed,
        DateTime TimeSet,
        DateTime StrikeOff,
        DateTime ClockTime,
        Decimal Distance,
        string DistanceString,
        DateTime TimeSetClock)
      {
        ManualReadOut.InformationRow informationRow = (ManualReadOut.InformationRow) this.NewRow();
        object[] objArray = new object[9]
        {
          null,
          (object) FancierID,
          (object) Basketed,
          (object) TimeSet,
          (object) StrikeOff,
          (object) ClockTime,
          (object) Distance,
          (object) DistanceString,
          (object) TimeSetClock
        };
        informationRow.ItemArray = objArray;
        this.Rows.Add((DataRow) informationRow);
        return informationRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.InformationRow FindByID(int ID) => (ManualReadOut.InformationRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ManualReadOut.InformationDataTable informationDataTable = (ManualReadOut.InformationDataTable) base.Clone();
        informationDataTable.InitVars();
        return (DataTable) informationDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ManualReadOut.InformationDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnBasketed = this.Columns["Basketed"];
        this.columnTimeSet = this.Columns["TimeSet"];
        this.columnStrikeOff = this.Columns["StrikeOff"];
        this.columnClockTime = this.Columns["ClockTime"];
        this.columnDistance = this.Columns["Distance"];
        this.columnDistanceString = this.Columns["DistanceString"];
        this.columnTimeSetClock = this.Columns["TimeSetClock"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnBasketed = new DataColumn("Basketed", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBasketed);
        this.columnTimeSet = new DataColumn("TimeSet", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeSet);
        this.columnStrikeOff = new DataColumn("StrikeOff", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnStrikeOff);
        this.columnClockTime = new DataColumn("ClockTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClockTime);
        this.columnDistance = new DataColumn("Distance", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnDistanceString = new DataColumn("DistanceString", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceString);
        this.columnTimeSetClock = new DataColumn("TimeSetClock", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTimeSetClock);
        this.Constraints.Add((Constraint) new UniqueConstraint("InformationKey1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierID.DefaultValue = (object) 0;
        this.columnBasketed.DefaultValue = (object) 0;
        this.columnStrikeOff.Caption = "TimeSet";
        this.columnDistance.DefaultValue = (object) 0M;
        this.columnDistanceString.DefaultValue = (object) "";
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.InformationRow NewInformationRow() => (ManualReadOut.InformationRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ManualReadOut.InformationRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ManualReadOut.InformationRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.InformationRowChanged == null)
          return;
        this.InformationRowChanged((object) this, new ManualReadOut.InformationRowChangeEvent((ManualReadOut.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.InformationRowChanging == null)
          return;
        this.InformationRowChanging((object) this, new ManualReadOut.InformationRowChangeEvent((ManualReadOut.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.InformationRowDeleted == null)
          return;
        this.InformationRowDeleted((object) this, new ManualReadOut.InformationRowChangeEvent((ManualReadOut.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.InformationRowDeleting == null)
          return;
        this.InformationRowDeleting((object) this, new ManualReadOut.InformationRowChangeEvent((ManualReadOut.InformationRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveInformationRow(ManualReadOut.InformationRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ManualReadOut manualReadOut = new ManualReadOut();
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
          FixedValue = manualReadOut.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (InformationDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = manualReadOut.GetSchemaSerializable();
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
      ManualReadOut.InformationRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void PigeonsRowChangeEventHandler(
      object sender,
      ManualReadOut.PigeonsRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class PigeonsDataTable : TypedTableBase<ManualReadOut.PigeonsRow>
    {
      private DataColumn columnID;
      private DataColumn columnPosition;
      private DataColumn columnFedBand;
      private DataColumn columnTime;
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
      public DataColumn PositionColumn => this.columnPosition;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FedBandColumn => this.columnFedBand;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TimeColumn => this.columnTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TeamNbrColumn => this.columnTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.PigeonsRow this[int index] => (ManualReadOut.PigeonsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.PigeonsRowChangeEventHandler PigeonsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.PigeonsRowChangeEventHandler PigeonsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.PigeonsRowChangeEventHandler PigeonsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event ManualReadOut.PigeonsRowChangeEventHandler PigeonsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddPigeonsRow(ManualReadOut.PigeonsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.PigeonsRow AddPigeonsRow(
        int Position,
        string FedBand,
        DateTime Time,
        int TeamNbr)
      {
        ManualReadOut.PigeonsRow pigeonsRow = (ManualReadOut.PigeonsRow) this.NewRow();
        object[] objArray = new object[5]
        {
          null,
          (object) Position,
          (object) FedBand,
          (object) Time,
          (object) TeamNbr
        };
        pigeonsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) pigeonsRow);
        return pigeonsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.PigeonsRow FindByID(int ID) => (ManualReadOut.PigeonsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        ManualReadOut.PigeonsDataTable pigeonsDataTable = (ManualReadOut.PigeonsDataTable) base.Clone();
        pigeonsDataTable.InitVars();
        return (DataTable) pigeonsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new ManualReadOut.PigeonsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnPosition = this.Columns["Position"];
        this.columnFedBand = this.Columns["FedBand"];
        this.columnTime = this.Columns["Time"];
        this.columnTeamNbr = this.Columns["TeamNbr"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnPosition = new DataColumn("Position", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPosition);
        this.columnFedBand = new DataColumn("FedBand", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFedBand);
        this.columnTime = new DataColumn("Time", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTime);
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
        this.columnPosition.DefaultValue = (object) 0;
        this.columnFedBand.DefaultValue = (object) "";
        this.columnTeamNbr.DefaultValue = (object) 0;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.PigeonsRow NewPigeonsRow() => (ManualReadOut.PigeonsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new ManualReadOut.PigeonsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (ManualReadOut.PigeonsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PigeonsRowChanged == null)
          return;
        this.PigeonsRowChanged((object) this, new ManualReadOut.PigeonsRowChangeEvent((ManualReadOut.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PigeonsRowChanging == null)
          return;
        this.PigeonsRowChanging((object) this, new ManualReadOut.PigeonsRowChangeEvent((ManualReadOut.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PigeonsRowDeleted == null)
          return;
        this.PigeonsRowDeleted((object) this, new ManualReadOut.PigeonsRowChangeEvent((ManualReadOut.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PigeonsRowDeleting == null)
          return;
        this.PigeonsRowDeleting((object) this, new ManualReadOut.PigeonsRowChangeEvent((ManualReadOut.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovePigeonsRow(ManualReadOut.PigeonsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        ManualReadOut manualReadOut = new ManualReadOut();
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
          FixedValue = manualReadOut.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PigeonsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = manualReadOut.GetSchemaSerializable();
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
      private ManualReadOut.InformationDataTable tableInformation;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal InformationRow(DataRowBuilder rb)
        : base(rb)
        => this.tableInformation = (ManualReadOut.InformationDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableInformation.IDColumn];
        set => this[this.tableInformation.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FancierID
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.FancierIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FancierID' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.FancierIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Basketed
      {
        get
        {
          try
          {
            return (int) this[this.tableInformation.BasketedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Basketed' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.BasketedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime TimeSet
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.TimeSetColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TimeSet' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TimeSetColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime StrikeOff
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.StrikeOffColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'StrikeOff' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.StrikeOffColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime ClockTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.ClockTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClockTime' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.ClockTimeColumn] = (object) value;
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
      public string DistanceString
      {
        get => this.IsDistanceStringNull() ? string.Empty : (string) this[this.tableInformation.DistanceStringColumn];
        set => this[this.tableInformation.DistanceStringColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime TimeSetClock
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableInformation.TimeSetClockColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'TimeSetClock' in table 'Information' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableInformation.TimeSetClockColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tableInformation.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tableInformation.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBasketedNull() => this.IsNull(this.tableInformation.BasketedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBasketedNull() => this[this.tableInformation.BasketedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeSetNull() => this.IsNull(this.tableInformation.TimeSetColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeSetNull() => this[this.tableInformation.TimeSetColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsStrikeOffNull() => this.IsNull(this.tableInformation.StrikeOffColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetStrikeOffNull() => this[this.tableInformation.StrikeOffColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClockTimeNull() => this.IsNull(this.tableInformation.ClockTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClockTimeNull() => this[this.tableInformation.ClockTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableInformation.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableInformation.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceStringNull() => this.IsNull(this.tableInformation.DistanceStringColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceStringNull() => this[this.tableInformation.DistanceStringColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeSetClockNull() => this.IsNull(this.tableInformation.TimeSetClockColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeSetClockNull() => this[this.tableInformation.TimeSetClockColumn] = Convert.DBNull;
    }

    public class PigeonsRow : DataRow
    {
      private ManualReadOut.PigeonsDataTable tablePigeons;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePigeons = (ManualReadOut.PigeonsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tablePigeons.IDColumn];
        set => this[this.tablePigeons.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Position
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.PositionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Position' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.PositionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string FedBand
      {
        get => this.IsFedBandNull() ? string.Empty : (string) this[this.tablePigeons.FedBandColumn];
        set => this[this.tablePigeons.FedBandColumn] = (object) value;
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
      public bool IsPositionNull() => this.IsNull(this.tablePigeons.PositionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPositionNull() => this[this.tablePigeons.PositionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFedBandNull() => this.IsNull(this.tablePigeons.FedBandColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFedBandNull() => this[this.tablePigeons.FedBandColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTimeNull() => this.IsNull(this.tablePigeons.TimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTimeNull() => this[this.tablePigeons.TimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTeamNbrNull() => this.IsNull(this.tablePigeons.TeamNbrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTeamNbrNull() => this[this.tablePigeons.TeamNbrColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class InformationRowChangeEvent : EventArgs
    {
      private ManualReadOut.InformationRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public InformationRowChangeEvent(ManualReadOut.InformationRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.InformationRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class PigeonsRowChangeEvent : EventArgs
    {
      private ManualReadOut.PigeonsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsRowChangeEvent(ManualReadOut.PigeonsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ManualReadOut.PigeonsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
