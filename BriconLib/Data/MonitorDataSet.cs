// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.MonitorDataSet
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
  [XmlRoot("MonitorDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class MonitorDataSet : DataSet
  {
    private MonitorDataSet.RacesDataTable tableRaces;
    private MonitorDataSet.GummiesDataTable tableGummies;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public MonitorDataSet()
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
    protected MonitorDataSet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (Races)] != null)
            base.Tables.Add((DataTable) new MonitorDataSet.RacesDataTable(dataSet.Tables[nameof (Races)]));
          if (dataSet.Tables[nameof (Gummies)] != null)
            base.Tables.Add((DataTable) new MonitorDataSet.GummiesDataTable(dataSet.Tables[nameof (Gummies)]));
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
    public MonitorDataSet.RacesDataTable Races => this.tableRaces;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public MonitorDataSet.GummiesDataTable Gummies => this.tableGummies;

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
      MonitorDataSet monitorDataSet = (MonitorDataSet) base.Clone();
      monitorDataSet.InitVars();
      monitorDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) monitorDataSet;
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
        if (dataSet.Tables["Races"] != null)
          base.Tables.Add((DataTable) new MonitorDataSet.RacesDataTable(dataSet.Tables["Races"]));
        if (dataSet.Tables["Gummies"] != null)
          base.Tables.Add((DataTable) new MonitorDataSet.GummiesDataTable(dataSet.Tables["Gummies"]));
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
      this.tableRaces = (MonitorDataSet.RacesDataTable) base.Tables["Races"];
      if (initTable && this.tableRaces != null)
        this.tableRaces.InitVars();
      this.tableGummies = (MonitorDataSet.GummiesDataTable) base.Tables["Gummies"];
      if (!initTable || this.tableGummies == null)
        return;
      this.tableGummies.InitVars();
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (MonitorDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/MonitorDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableRaces = new MonitorDataSet.RacesDataTable();
      base.Tables.Add((DataTable) this.tableRaces);
      this.tableGummies = new MonitorDataSet.GummiesDataTable();
      base.Tables.Add((DataTable) this.tableGummies);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private bool ShouldSerializeRaces() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    private bool ShouldSerializeGummies() => false;

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
      MonitorDataSet monitorDataSet = new MonitorDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = monitorDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = monitorDataSet.GetSchemaSerializable();
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
    public delegate void RacesRowChangeEventHandler(
      object sender,
      MonitorDataSet.RacesRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public delegate void GummiesRowChangeEventHandler(
      object sender,
      MonitorDataSet.GummiesRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class RacesDataTable : TypedTableBase<MonitorDataSet.RacesRow>
    {
      private DataColumn columnRaceName;
      private DataColumn columnShow;
      private DataColumn columnReleaseDateTime;
      private DataColumn columnDistance;
      private DataColumn columnEmail;
      private DataColumn columnEmail2;
      private DataColumn columnPigeonCloud;
      private DataColumn columnPlaySound;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public RacesDataTable()
      {
        this.TableName = "Races";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal RacesDataTable(DataTable table)
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
      protected RacesDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn RaceNameColumn => this.columnRaceName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ShowColumn => this.columnShow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn ReleaseDateTimeColumn => this.columnReleaseDateTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn EmailColumn => this.columnEmail;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn Email2Column => this.columnEmail2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn PigeonCloudColumn => this.columnPigeonCloud;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn PlaySoundColumn => this.columnPlaySound;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.RacesRow this[int index] => (MonitorDataSet.RacesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.RacesRowChangeEventHandler RacesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.RacesRowChangeEventHandler RacesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.RacesRowChangeEventHandler RacesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.RacesRowChangeEventHandler RacesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void AddRacesRow(MonitorDataSet.RacesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.RacesRow AddRacesRow(
        string RaceName,
        bool Show,
        DateTime ReleaseDateTime,
        int Distance,
        bool Email,
        bool Email2,
        bool PigeonCloud,
        bool PlaySound)
      {
        MonitorDataSet.RacesRow racesRow = (MonitorDataSet.RacesRow) this.NewRow();
        object[] objArray = new object[8]
        {
          (object) RaceName,
          (object) Show,
          (object) ReleaseDateTime,
          (object) Distance,
          (object) Email,
          (object) Email2,
          (object) PigeonCloud,
          (object) PlaySound
        };
        racesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) racesRow);
        return racesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.RacesRow FindByRaceName(string RaceName) => (MonitorDataSet.RacesRow) this.Rows.Find(new object[1]
      {
        (object) RaceName
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public override DataTable Clone()
      {
        MonitorDataSet.RacesDataTable racesDataTable = (MonitorDataSet.RacesDataTable) base.Clone();
        racesDataTable.InitVars();
        return (DataTable) racesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new MonitorDataSet.RacesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal void InitVars()
      {
        this.columnRaceName = this.Columns["RaceName"];
        this.columnShow = this.Columns["Show"];
        this.columnReleaseDateTime = this.Columns["ReleaseDateTime"];
        this.columnDistance = this.Columns["Distance"];
        this.columnEmail = this.Columns["Email"];
        this.columnEmail2 = this.Columns["Email2"];
        this.columnPigeonCloud = this.Columns["PigeonCloud"];
        this.columnPlaySound = this.Columns["PlaySound"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      private void InitClass()
      {
        this.columnRaceName = new DataColumn("RaceName", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRaceName);
        this.columnShow = new DataColumn("Show", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnShow);
        this.columnReleaseDateTime = new DataColumn("ReleaseDateTime", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnReleaseDateTime);
        this.columnDistance = new DataColumn("Distance", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnEmail = new DataColumn("Email", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmail);
        this.columnEmail2 = new DataColumn("Email2", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmail2);
        this.columnPigeonCloud = new DataColumn("PigeonCloud", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPigeonCloud);
        this.columnPlaySound = new DataColumn("PlaySound", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPlaySound);
        this.Constraints.Add((Constraint) new UniqueConstraint("RacesKey1", new DataColumn[1]
        {
          this.columnRaceName
        }, true));
        this.columnRaceName.AllowDBNull = false;
        this.columnRaceName.Unique = true;
        this.columnPigeonCloud.DefaultValue = (object) false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.RacesRow NewRacesRow() => (MonitorDataSet.RacesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new MonitorDataSet.RacesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override Type GetRowType() => typeof (MonitorDataSet.RacesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.RacesRowChanged == null)
          return;
        this.RacesRowChanged((object) this, new MonitorDataSet.RacesRowChangeEvent((MonitorDataSet.RacesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.RacesRowChanging == null)
          return;
        this.RacesRowChanging((object) this, new MonitorDataSet.RacesRowChangeEvent((MonitorDataSet.RacesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.RacesRowDeleted == null)
          return;
        this.RacesRowDeleted((object) this, new MonitorDataSet.RacesRowChangeEvent((MonitorDataSet.RacesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.RacesRowDeleting == null)
          return;
        this.RacesRowDeleting((object) this, new MonitorDataSet.RacesRowChangeEvent((MonitorDataSet.RacesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void RemoveRacesRow(MonitorDataSet.RacesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        MonitorDataSet monitorDataSet = new MonitorDataSet();
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
          FixedValue = monitorDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (RacesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = monitorDataSet.GetSchemaSerializable();
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
    public class GummiesDataTable : TypedTableBase<MonitorDataSet.GummiesRow>
    {
      private DataColumn columnDBRing;
      private DataColumn columnTime;
      private DataColumn columnWingmark;
      private DataColumn columnGummy;
      private DataColumn columnSendedToExtenalParties;
      private DataColumn columnSendedToPigeonCloud;
      private DataColumn columnSendedToCompuClub;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public GummiesDataTable()
      {
        this.TableName = "Gummies";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal GummiesDataTable(DataTable table)
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
      protected GummiesDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn DBRingColumn => this.columnDBRing;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn TimeColumn => this.columnTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn WingmarkColumn => this.columnWingmark;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn GummyColumn => this.columnGummy;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SendedToExtenalPartiesColumn => this.columnSendedToExtenalParties;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SendedToPigeonCloudColumn => this.columnSendedToPigeonCloud;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataColumn SendedToCompuClubColumn => this.columnSendedToCompuClub;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.GummiesRow this[int index] => (MonitorDataSet.GummiesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.GummiesRowChangeEventHandler GummiesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.GummiesRowChangeEventHandler GummiesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.GummiesRowChangeEventHandler GummiesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public event MonitorDataSet.GummiesRowChangeEventHandler GummiesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void AddGummiesRow(MonitorDataSet.GummiesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.GummiesRow AddGummiesRow(
        string DBRing,
        DateTime Time,
        string Wingmark,
        string Gummy,
        bool SendedToExtenalParties,
        bool SendedToPigeonCloud,
        bool SendedToCompuClub)
      {
        MonitorDataSet.GummiesRow gummiesRow = (MonitorDataSet.GummiesRow) this.NewRow();
        object[] objArray = new object[7]
        {
          (object) DBRing,
          (object) Time,
          (object) Wingmark,
          (object) Gummy,
          (object) SendedToExtenalParties,
          (object) SendedToPigeonCloud,
          (object) SendedToCompuClub
        };
        gummiesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) gummiesRow);
        return gummiesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.GummiesRow FindByDBRingTime(string DBRing, DateTime Time) => (MonitorDataSet.GummiesRow) this.Rows.Find(new object[2]
      {
        (object) DBRing,
        (object) Time
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public override DataTable Clone()
      {
        MonitorDataSet.GummiesDataTable gummiesDataTable = (MonitorDataSet.GummiesDataTable) base.Clone();
        gummiesDataTable.InitVars();
        return (DataTable) gummiesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new MonitorDataSet.GummiesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal void InitVars()
      {
        this.columnDBRing = this.Columns["DBRing"];
        this.columnTime = this.Columns["Time"];
        this.columnWingmark = this.Columns["Wingmark"];
        this.columnGummy = this.Columns["Gummy"];
        this.columnSendedToExtenalParties = this.Columns["SendedToExtenalParties"];
        this.columnSendedToPigeonCloud = this.Columns["SendedToPigeonCloud"];
        this.columnSendedToCompuClub = this.Columns["SendedToCompuClub"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      private void InitClass()
      {
        this.columnDBRing = new DataColumn("DBRing", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDBRing);
        this.columnTime = new DataColumn("Time", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTime);
        this.columnWingmark = new DataColumn("Wingmark", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnWingmark);
        this.columnGummy = new DataColumn("Gummy", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGummy);
        this.columnSendedToExtenalParties = new DataColumn("SendedToExtenalParties", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSendedToExtenalParties);
        this.columnSendedToPigeonCloud = new DataColumn("SendedToPigeonCloud", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSendedToPigeonCloud);
        this.columnSendedToCompuClub = new DataColumn("SendedToCompuClub", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSendedToCompuClub);
        this.Constraints.Add((Constraint) new UniqueConstraint("GummiesKey1", new DataColumn[2]
        {
          this.columnDBRing,
          this.columnTime
        }, true));
        this.columnDBRing.AllowDBNull = false;
        this.columnTime.AllowDBNull = false;
        this.columnSendedToPigeonCloud.DefaultValue = (object) false;
        this.columnSendedToCompuClub.DefaultValue = (object) false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.GummiesRow NewGummiesRow() => (MonitorDataSet.GummiesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new MonitorDataSet.GummiesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override Type GetRowType() => typeof (MonitorDataSet.GummiesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.GummiesRowChanged == null)
          return;
        this.GummiesRowChanged((object) this, new MonitorDataSet.GummiesRowChangeEvent((MonitorDataSet.GummiesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.GummiesRowChanging == null)
          return;
        this.GummiesRowChanging((object) this, new MonitorDataSet.GummiesRowChangeEvent((MonitorDataSet.GummiesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.GummiesRowDeleted == null)
          return;
        this.GummiesRowDeleted((object) this, new MonitorDataSet.GummiesRowChangeEvent((MonitorDataSet.GummiesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.GummiesRowDeleting == null)
          return;
        this.GummiesRowDeleting((object) this, new MonitorDataSet.GummiesRowChangeEvent((MonitorDataSet.GummiesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void RemoveGummiesRow(MonitorDataSet.GummiesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        MonitorDataSet monitorDataSet = new MonitorDataSet();
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
          FixedValue = monitorDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (GummiesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = monitorDataSet.GetSchemaSerializable();
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

    public class RacesRow : DataRow
    {
      private MonitorDataSet.RacesDataTable tableRaces;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal RacesRow(DataRowBuilder rb)
        : base(rb)
        => this.tableRaces = (MonitorDataSet.RacesDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string RaceName
      {
        get => (string) this[this.tableRaces.RaceNameColumn];
        set => this[this.tableRaces.RaceNameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool Show
      {
        get
        {
          try
          {
            return (bool) this[this.tableRaces.ShowColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Show' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.ShowColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime ReleaseDateTime
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableRaces.ReleaseDateTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ReleaseDateTime' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.ReleaseDateTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public int Distance
      {
        get
        {
          try
          {
            return (int) this[this.tableRaces.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool Email
      {
        get
        {
          try
          {
            return (bool) this[this.tableRaces.EmailColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Email' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.EmailColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool Email2
      {
        get
        {
          try
          {
            return (bool) this[this.tableRaces.Email2Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Email2' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.Email2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool PigeonCloud
      {
        get
        {
          try
          {
            return (bool) this[this.tableRaces.PigeonCloudColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PigeonCloud' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.PigeonCloudColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool PlaySound
      {
        get
        {
          try
          {
            return (bool) this[this.tableRaces.PlaySoundColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'PlaySound' in table 'Races' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableRaces.PlaySoundColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsShowNull() => this.IsNull(this.tableRaces.ShowColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetShowNull() => this[this.tableRaces.ShowColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsReleaseDateTimeNull() => this.IsNull(this.tableRaces.ReleaseDateTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetReleaseDateTimeNull() => this[this.tableRaces.ReleaseDateTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableRaces.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetDistanceNull() => this[this.tableRaces.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsEmailNull() => this.IsNull(this.tableRaces.EmailColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetEmailNull() => this[this.tableRaces.EmailColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsEmail2Null() => this.IsNull(this.tableRaces.Email2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetEmail2Null() => this[this.tableRaces.Email2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPigeonCloudNull() => this.IsNull(this.tableRaces.PigeonCloudColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPigeonCloudNull() => this[this.tableRaces.PigeonCloudColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsPlaySoundNull() => this.IsNull(this.tableRaces.PlaySoundColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetPlaySoundNull() => this[this.tableRaces.PlaySoundColumn] = Convert.DBNull;
    }

    public class GummiesRow : DataRow
    {
      private MonitorDataSet.GummiesDataTable tableGummies;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      internal GummiesRow(DataRowBuilder rb)
        : base(rb)
        => this.tableGummies = (MonitorDataSet.GummiesDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string DBRing
      {
        get => (string) this[this.tableGummies.DBRingColumn];
        set => this[this.tableGummies.DBRingColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DateTime Time
      {
        get => (DateTime) this[this.tableGummies.TimeColumn];
        set => this[this.tableGummies.TimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Wingmark
      {
        get
        {
          try
          {
            return (string) this[this.tableGummies.WingmarkColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Wingmark' in table 'Gummies' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableGummies.WingmarkColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public string Gummy
      {
        get
        {
          try
          {
            return (string) this[this.tableGummies.GummyColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Gummy' in table 'Gummies' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableGummies.GummyColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool SendedToExtenalParties
      {
        get
        {
          try
          {
            return (bool) this[this.tableGummies.SendedToExtenalPartiesColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SendedToExtenalParties' in table 'Gummies' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableGummies.SendedToExtenalPartiesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool SendedToPigeonCloud
      {
        get
        {
          try
          {
            return (bool) this[this.tableGummies.SendedToPigeonCloudColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SendedToPigeonCloud' in table 'Gummies' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableGummies.SendedToPigeonCloudColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool SendedToCompuClub
      {
        get
        {
          try
          {
            return (bool) this[this.tableGummies.SendedToCompuClubColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SendedToCompuClub' in table 'Gummies' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableGummies.SendedToCompuClubColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsWingmarkNull() => this.IsNull(this.tableGummies.WingmarkColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetWingmarkNull() => this[this.tableGummies.WingmarkColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsGummyNull() => this.IsNull(this.tableGummies.GummyColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetGummyNull() => this[this.tableGummies.GummyColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSendedToExtenalPartiesNull() => this.IsNull(this.tableGummies.SendedToExtenalPartiesColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSendedToExtenalPartiesNull() => this[this.tableGummies.SendedToExtenalPartiesColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSendedToPigeonCloudNull() => this.IsNull(this.tableGummies.SendedToPigeonCloudColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSendedToPigeonCloudNull() => this[this.tableGummies.SendedToPigeonCloudColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public bool IsSendedToCompuClubNull() => this.IsNull(this.tableGummies.SendedToCompuClubColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public void SetSendedToCompuClubNull() => this[this.tableGummies.SendedToCompuClubColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public class RacesRowChangeEvent : EventArgs
    {
      private MonitorDataSet.RacesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public RacesRowChangeEvent(MonitorDataSet.RacesRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.RacesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
    public class GummiesRowChangeEvent : EventArgs
    {
      private MonitorDataSet.GummiesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public GummiesRowChangeEvent(MonitorDataSet.GummiesRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public MonitorDataSet.GummiesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
