// Decompiled with JetBrains decompiler
// Type: BriconLib.Data.BCEDataSet
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
  [XmlRoot("BCEDataSet")]
  [HelpKeyword("vs.data.DataSet")]
  [Serializable]
  public class BCEDataSet : DataSet
  {
    private BCEDataSet.LossingsplaatsDataTable tableLossingsplaats;
    private BCEDataSet.ClubsDataTable tableClubs;
    private BCEDataSet.AdressenDataTable tableAdressen;
    private BCEDataSet.PigeonsDataTable tablePigeons;
    private BCEDataSet.SettingsDataTable tableSettings;
    private BCEDataSet.DistancesDataTable tableDistances;
    private DataRelation relationClubs_Adressen;
    private DataRelation relationAdressen_Pigeons;
    private DataRelation relationAdressen_Distances;
    private DataRelation relationLossingsplaats_Distances;
    private SchemaSerializationMode _schemaSerializationMode = SchemaSerializationMode.IncludeSchema;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public BCEDataSet()
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
    protected BCEDataSet(SerializationInfo info, StreamingContext context)
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
          if (dataSet.Tables[nameof (Lossingsplaats)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.LossingsplaatsDataTable(dataSet.Tables[nameof (Lossingsplaats)]));
          if (dataSet.Tables[nameof (Clubs)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.ClubsDataTable(dataSet.Tables[nameof (Clubs)]));
          if (dataSet.Tables[nameof (Adressen)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.AdressenDataTable(dataSet.Tables[nameof (Adressen)]));
          if (dataSet.Tables[nameof (Pigeons)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.PigeonsDataTable(dataSet.Tables[nameof (Pigeons)]));
          if (dataSet.Tables[nameof (Settings)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.SettingsDataTable(dataSet.Tables[nameof (Settings)]));
          if (dataSet.Tables[nameof (Distances)] != null)
            base.Tables.Add((DataTable) new BCEDataSet.DistancesDataTable(dataSet.Tables[nameof (Distances)]));
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
    public BCEDataSet.LossingsplaatsDataTable Lossingsplaats => this.tableLossingsplaats;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BCEDataSet.ClubsDataTable Clubs => this.tableClubs;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BCEDataSet.AdressenDataTable Adressen => this.tableAdressen;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BCEDataSet.PigeonsDataTable Pigeons => this.tablePigeons;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BCEDataSet.SettingsDataTable Settings => this.tableSettings;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public BCEDataSet.DistancesDataTable Distances => this.tableDistances;

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
      BCEDataSet bceDataSet = (BCEDataSet) base.Clone();
      bceDataSet.InitVars();
      bceDataSet.SchemaSerializationMode = this.SchemaSerializationMode;
      return (DataSet) bceDataSet;
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
        if (dataSet.Tables["Lossingsplaats"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.LossingsplaatsDataTable(dataSet.Tables["Lossingsplaats"]));
        if (dataSet.Tables["Clubs"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.ClubsDataTable(dataSet.Tables["Clubs"]));
        if (dataSet.Tables["Adressen"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.AdressenDataTable(dataSet.Tables["Adressen"]));
        if (dataSet.Tables["Pigeons"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.PigeonsDataTable(dataSet.Tables["Pigeons"]));
        if (dataSet.Tables["Settings"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.SettingsDataTable(dataSet.Tables["Settings"]));
        if (dataSet.Tables["Distances"] != null)
          base.Tables.Add((DataTable) new BCEDataSet.DistancesDataTable(dataSet.Tables["Distances"]));
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
      this.tableLossingsplaats = (BCEDataSet.LossingsplaatsDataTable) base.Tables["Lossingsplaats"];
      if (initTable && this.tableLossingsplaats != null)
        this.tableLossingsplaats.InitVars();
      this.tableClubs = (BCEDataSet.ClubsDataTable) base.Tables["Clubs"];
      if (initTable && this.tableClubs != null)
        this.tableClubs.InitVars();
      this.tableAdressen = (BCEDataSet.AdressenDataTable) base.Tables["Adressen"];
      if (initTable && this.tableAdressen != null)
        this.tableAdressen.InitVars();
      this.tablePigeons = (BCEDataSet.PigeonsDataTable) base.Tables["Pigeons"];
      if (initTable && this.tablePigeons != null)
        this.tablePigeons.InitVars();
      this.tableSettings = (BCEDataSet.SettingsDataTable) base.Tables["Settings"];
      if (initTable && this.tableSettings != null)
        this.tableSettings.InitVars();
      this.tableDistances = (BCEDataSet.DistancesDataTable) base.Tables["Distances"];
      if (initTable && this.tableDistances != null)
        this.tableDistances.InitVars();
      this.relationClubs_Adressen = this.Relations["Clubs_Adressen"];
      this.relationAdressen_Pigeons = this.Relations["Adressen_Pigeons"];
      this.relationAdressen_Distances = this.Relations["Adressen_Distances"];
      this.relationLossingsplaats_Distances = this.Relations["Lossingsplaats_Distances"];
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private void InitClass()
    {
      this.DataSetName = nameof (BCEDataSet);
      this.Prefix = "";
      this.Namespace = "http://tempuri.org/AdminBackupDataSet.xsd";
      this.EnforceConstraints = true;
      this.SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
      this.tableLossingsplaats = new BCEDataSet.LossingsplaatsDataTable();
      base.Tables.Add((DataTable) this.tableLossingsplaats);
      this.tableClubs = new BCEDataSet.ClubsDataTable();
      base.Tables.Add((DataTable) this.tableClubs);
      this.tableAdressen = new BCEDataSet.AdressenDataTable();
      base.Tables.Add((DataTable) this.tableAdressen);
      this.tablePigeons = new BCEDataSet.PigeonsDataTable();
      base.Tables.Add((DataTable) this.tablePigeons);
      this.tableSettings = new BCEDataSet.SettingsDataTable();
      base.Tables.Add((DataTable) this.tableSettings);
      this.tableDistances = new BCEDataSet.DistancesDataTable();
      base.Tables.Add((DataTable) this.tableDistances);
      ForeignKeyConstraint foreignKeyConstraint1 = new ForeignKeyConstraint("Clubs_Adressen", new DataColumn[1]
      {
        this.tableClubs.IDColumn
      }, new DataColumn[1]
      {
        this.tableAdressen.ClubIDColumn
      });
      this.tableAdressen.Constraints.Add((Constraint) foreignKeyConstraint1);
      foreignKeyConstraint1.AcceptRejectRule = AcceptRejectRule.Cascade;
      foreignKeyConstraint1.DeleteRule = Rule.Cascade;
      foreignKeyConstraint1.UpdateRule = Rule.Cascade;
      ForeignKeyConstraint foreignKeyConstraint2 = new ForeignKeyConstraint("Adressen_Pigeons", new DataColumn[1]
      {
        this.tableAdressen.IdColumn
      }, new DataColumn[1]
      {
        this.tablePigeons.FancierIDColumn
      });
      this.tablePigeons.Constraints.Add((Constraint) foreignKeyConstraint2);
      foreignKeyConstraint2.AcceptRejectRule = AcceptRejectRule.Cascade;
      foreignKeyConstraint2.DeleteRule = Rule.Cascade;
      foreignKeyConstraint2.UpdateRule = Rule.Cascade;
      this.relationClubs_Adressen = new DataRelation("Clubs_Adressen", new DataColumn[1]
      {
        this.tableClubs.IDColumn
      }, new DataColumn[1]
      {
        this.tableAdressen.ClubIDColumn
      }, false);
      this.relationClubs_Adressen.Nested = true;
      this.Relations.Add(this.relationClubs_Adressen);
      this.relationAdressen_Pigeons = new DataRelation("Adressen_Pigeons", new DataColumn[1]
      {
        this.tableAdressen.IdColumn
      }, new DataColumn[1]
      {
        this.tablePigeons.FancierIDColumn
      }, false);
      this.relationAdressen_Pigeons.Nested = true;
      this.Relations.Add(this.relationAdressen_Pigeons);
      this.relationAdressen_Distances = new DataRelation("Adressen_Distances", new DataColumn[1]
      {
        this.tableAdressen.IdColumn
      }, new DataColumn[1]
      {
        this.tableDistances.FancierIDColumn
      }, false);
      this.Relations.Add(this.relationAdressen_Distances);
      this.relationLossingsplaats_Distances = new DataRelation("Lossingsplaats_Distances", new DataColumn[1]
      {
        this.tableLossingsplaats.idColumn
      }, new DataColumn[1]
      {
        this.tableDistances.LosplaatsIDColumn
      }, false);
      this.Relations.Add(this.relationLossingsplaats_Distances);
    }

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeLossingsplaats() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeClubs() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeAdressen() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializePigeons() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeSettings() => false;

    [DebuggerNonUserCode]
    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    private bool ShouldSerializeDistances() => false;

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
      BCEDataSet bceDataSet = new BCEDataSet();
      XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
      XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
      xmlSchemaSequence.Items.Add((XmlSchemaObject) new XmlSchemaAny()
      {
        Namespace = bceDataSet.Namespace
      });
      schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
      XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void LossingsplaatsRowChangeEventHandler(
      object sender,
      BCEDataSet.LossingsplaatsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void ClubsRowChangeEventHandler(object sender, BCEDataSet.ClubsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void AdressenRowChangeEventHandler(
      object sender,
      BCEDataSet.AdressenRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void PigeonsRowChangeEventHandler(
      object sender,
      BCEDataSet.PigeonsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void SettingsRowChangeEventHandler(
      object sender,
      BCEDataSet.SettingsRowChangeEvent e);

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public delegate void DistancesRowChangeEventHandler(
      object sender,
      BCEDataSet.DistancesRowChangeEvent e);

    [XmlSchemaProvider("GetTypedTableSchema")]
    [Serializable]
    public class LossingsplaatsDataTable : TypedTableBase<BCEDataSet.LossingsplaatsRow>
    {
      private DataColumn columnid;
      private DataColumn columnLosplaats;
      private DataColumn columnCode;
      private DataColumn columnLWX;
      private DataColumn columnLWY;
      private DataColumn columnSelected;
      private DataColumn columnPlace;
      private DataColumn columnCountry;
      private DataColumn columnVolgordeNummer;
      private DataColumn columnDistance;
      private DataColumn columnDistanceYards;
      private DataColumn columnRaceCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public LossingsplaatsDataTable()
      {
        this.TableName = "Lossingsplaats";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal LossingsplaatsDataTable(DataTable table)
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
      protected LossingsplaatsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn idColumn => this.columnid;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LosplaatsColumn => this.columnLosplaats;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CodeColumn => this.columnCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LWXColumn => this.columnLWX;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LWYColumn => this.columnLWY;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SelectedColumn => this.columnSelected;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PlaceColumn => this.columnPlace;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CountryColumn => this.columnCountry;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn VolgordeNummerColumn => this.columnVolgordeNummer;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceYardsColumn => this.columnDistanceYards;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RaceCodeColumn => this.columnRaceCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow this[int index] => (BCEDataSet.LossingsplaatsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.LossingsplaatsRowChangeEventHandler LossingsplaatsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.LossingsplaatsRowChangeEventHandler LossingsplaatsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.LossingsplaatsRowChangeEventHandler LossingsplaatsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.LossingsplaatsRowChangeEventHandler LossingsplaatsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddLossingsplaatsRow(BCEDataSet.LossingsplaatsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow AddLossingsplaatsRow(
        string Losplaats,
        string Code,
        int LWX,
        int LWY,
        bool Selected,
        string Place,
        string Country,
        int VolgordeNummer,
        int Distance,
        int DistanceYards,
        string RaceCode)
      {
        BCEDataSet.LossingsplaatsRow lossingsplaatsRow = (BCEDataSet.LossingsplaatsRow) this.NewRow();
        object[] objArray = new object[12]
        {
          null,
          (object) Losplaats,
          (object) Code,
          (object) LWX,
          (object) LWY,
          (object) Selected,
          (object) Place,
          (object) Country,
          (object) VolgordeNummer,
          (object) Distance,
          (object) DistanceYards,
          (object) RaceCode
        };
        lossingsplaatsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) lossingsplaatsRow);
        return lossingsplaatsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow FindByid(int id) => (BCEDataSet.LossingsplaatsRow) this.Rows.Find(new object[1]
      {
        (object) id
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.LossingsplaatsDataTable lossingsplaatsDataTable = (BCEDataSet.LossingsplaatsDataTable) base.Clone();
        lossingsplaatsDataTable.InitVars();
        return (DataTable) lossingsplaatsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.LossingsplaatsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnid = this.Columns["id"];
        this.columnLosplaats = this.Columns["Losplaats"];
        this.columnCode = this.Columns["Code"];
        this.columnLWX = this.Columns["LWX"];
        this.columnLWY = this.Columns["LWY"];
        this.columnSelected = this.Columns["Selected"];
        this.columnPlace = this.Columns["Place"];
        this.columnCountry = this.Columns["Country"];
        this.columnVolgordeNummer = this.Columns["VolgordeNummer"];
        this.columnDistance = this.Columns["Distance"];
        this.columnDistanceYards = this.Columns["DistanceYards"];
        this.columnRaceCode = this.Columns["RaceCode"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnid = new DataColumn("id", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnid);
        this.columnLosplaats = new DataColumn("Losplaats", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLosplaats);
        this.columnCode = new DataColumn("Code", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCode);
        this.columnLWX = new DataColumn("LWX", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLWX);
        this.columnLWY = new DataColumn("LWY", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLWY);
        this.columnSelected = new DataColumn("Selected", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSelected);
        this.columnPlace = new DataColumn("Place", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPlace);
        this.columnCountry = new DataColumn("Country", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCountry);
        this.columnVolgordeNummer = new DataColumn("VolgordeNummer", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVolgordeNummer);
        this.columnDistance = new DataColumn("Distance", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnDistanceYards = new DataColumn("DistanceYards", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceYards);
        this.columnRaceCode = new DataColumn("RaceCode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRaceCode);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnid
        }, true));
        this.columnid.AutoIncrement = true;
        this.columnid.AllowDBNull = false;
        this.columnid.Unique = true;
        this.columnLosplaats.DefaultValue = (object) "";
        this.columnLosplaats.MaxLength = 30;
        this.columnCode.DefaultValue = (object) "";
        this.columnCode.MaxLength = 4;
        this.columnLWX.DefaultValue = (object) 0;
        this.columnLWY.DefaultValue = (object) 0;
        this.columnSelected.DefaultValue = (object) false;
        this.columnPlace.DefaultValue = (object) "";
        this.columnPlace.MaxLength = (int) byte.MaxValue;
        this.columnCountry.DefaultValue = (object) "";
        this.columnCountry.MaxLength = (int) byte.MaxValue;
        this.columnDistance.AllowDBNull = false;
        this.columnDistance.DefaultValue = (object) 0;
        this.columnDistanceYards.AllowDBNull = false;
        this.columnDistanceYards.DefaultValue = (object) 0;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow NewLossingsplaatsRow() => (BCEDataSet.LossingsplaatsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.LossingsplaatsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.LossingsplaatsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.LossingsplaatsRowChanged == null)
          return;
        this.LossingsplaatsRowChanged((object) this, new BCEDataSet.LossingsplaatsRowChangeEvent((BCEDataSet.LossingsplaatsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.LossingsplaatsRowChanging == null)
          return;
        this.LossingsplaatsRowChanging((object) this, new BCEDataSet.LossingsplaatsRowChangeEvent((BCEDataSet.LossingsplaatsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.LossingsplaatsRowDeleted == null)
          return;
        this.LossingsplaatsRowDeleted((object) this, new BCEDataSet.LossingsplaatsRowChangeEvent((BCEDataSet.LossingsplaatsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.LossingsplaatsRowDeleting == null)
          return;
        this.LossingsplaatsRowDeleting((object) this, new BCEDataSet.LossingsplaatsRowChangeEvent((BCEDataSet.LossingsplaatsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveLossingsplaatsRow(BCEDataSet.LossingsplaatsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (LossingsplaatsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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
    public class ClubsDataTable : TypedTableBase<BCEDataSet.ClubsRow>
    {
      private DataColumn columnID;
      private DataColumn columnClubID;
      private DataColumn columnName;
      private DataColumn columnPincode;
      private DataColumn columnAdres;
      private DataColumn columnPostcode;
      private DataColumn columnGemeente;
      private DataColumn columnTelefoon;
      private DataColumn columnSerieNrMaster;
      private DataColumn columnVerantwoordelijke;
      private DataColumn columnVerantwoordelijkeTelefoon;
      private DataColumn columnEmail;
      private DataColumn columnClubNumber;
      private DataColumn columnUnion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ClubsDataTable()
      {
        this.TableName = "Clubs";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ClubsDataTable(DataTable table)
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
      protected ClubsDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IDColumn => this.columnID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NameColumn => this.columnName;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PincodeColumn => this.columnPincode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn AdresColumn => this.columnAdres;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PostcodeColumn => this.columnPostcode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GemeenteColumn => this.columnGemeente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TelefoonColumn => this.columnTelefoon;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SerieNrMasterColumn => this.columnSerieNrMaster;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn VerantwoordelijkeColumn => this.columnVerantwoordelijke;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn VerantwoordelijkeTelefoonColumn => this.columnVerantwoordelijkeTelefoon;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EmailColumn => this.columnEmail;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubNumberColumn => this.columnClubNumber;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn UnionColumn => this.columnUnion;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow this[int index] => (BCEDataSet.ClubsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.ClubsRowChangeEventHandler ClubsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.ClubsRowChangeEventHandler ClubsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.ClubsRowChangeEventHandler ClubsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.ClubsRowChangeEventHandler ClubsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddClubsRow(BCEDataSet.ClubsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow AddClubsRow(
        string ClubID,
        string Name,
        string Pincode,
        string Adres,
        string Postcode,
        string Gemeente,
        string Telefoon,
        string SerieNrMaster,
        string Verantwoordelijke,
        string VerantwoordelijkeTelefoon,
        string Email,
        string ClubNumber,
        string Union)
      {
        BCEDataSet.ClubsRow clubsRow = (BCEDataSet.ClubsRow) this.NewRow();
        object[] objArray = new object[14]
        {
          null,
          (object) ClubID,
          (object) Name,
          (object) Pincode,
          (object) Adres,
          (object) Postcode,
          (object) Gemeente,
          (object) Telefoon,
          (object) SerieNrMaster,
          (object) Verantwoordelijke,
          (object) VerantwoordelijkeTelefoon,
          (object) Email,
          (object) ClubNumber,
          (object) Union
        };
        clubsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) clubsRow);
        return clubsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow FindByID(int ID) => (BCEDataSet.ClubsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.ClubsDataTable clubsDataTable = (BCEDataSet.ClubsDataTable) base.Clone();
        clubsDataTable.InitVars();
        return (DataTable) clubsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.ClubsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnName = this.Columns["Name"];
        this.columnPincode = this.Columns["Pincode"];
        this.columnAdres = this.Columns["Adres"];
        this.columnPostcode = this.Columns["Postcode"];
        this.columnGemeente = this.Columns["Gemeente"];
        this.columnTelefoon = this.Columns["Telefoon"];
        this.columnSerieNrMaster = this.Columns["SerieNrMaster"];
        this.columnVerantwoordelijke = this.Columns["Verantwoordelijke"];
        this.columnVerantwoordelijkeTelefoon = this.Columns["VerantwoordelijkeTelefoon"];
        this.columnEmail = this.Columns["Email"];
        this.columnClubNumber = this.Columns["ClubNumber"];
        this.columnUnion = this.Columns["Union"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnClubID = new DataColumn("ClubID", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnName = new DataColumn("Name", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnName);
        this.columnPincode = new DataColumn("Pincode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPincode);
        this.columnAdres = new DataColumn("Adres", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAdres);
        this.columnPostcode = new DataColumn("Postcode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPostcode);
        this.columnGemeente = new DataColumn("Gemeente", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGemeente);
        this.columnTelefoon = new DataColumn("Telefoon", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelefoon);
        this.columnSerieNrMaster = new DataColumn("SerieNrMaster", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerieNrMaster);
        this.columnVerantwoordelijke = new DataColumn("Verantwoordelijke", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVerantwoordelijke);
        this.columnVerantwoordelijkeTelefoon = new DataColumn("VerantwoordelijkeTelefoon", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnVerantwoordelijkeTelefoon);
        this.columnEmail = new DataColumn("Email", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmail);
        this.columnClubNumber = new DataColumn("ClubNumber", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubNumber);
        this.columnUnion = new DataColumn("Union", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnUnion);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnClubID.DefaultValue = (object) "";
        this.columnClubID.MaxLength = (int) byte.MaxValue;
        this.columnName.DefaultValue = (object) "";
        this.columnName.MaxLength = (int) byte.MaxValue;
        this.columnPincode.DefaultValue = (object) "999999";
        this.columnPincode.MaxLength = 50;
        this.columnAdres.DefaultValue = (object) "";
        this.columnAdres.MaxLength = 30;
        this.columnPostcode.DefaultValue = (object) "";
        this.columnPostcode.MaxLength = 10;
        this.columnGemeente.DefaultValue = (object) "";
        this.columnGemeente.MaxLength = 30;
        this.columnTelefoon.DefaultValue = (object) "";
        this.columnTelefoon.MaxLength = 30;
        this.columnSerieNrMaster.DefaultValue = (object) "";
        this.columnSerieNrMaster.MaxLength = 30;
        this.columnVerantwoordelijke.DefaultValue = (object) "";
        this.columnVerantwoordelijke.MaxLength = 30;
        this.columnVerantwoordelijkeTelefoon.DefaultValue = (object) "";
        this.columnVerantwoordelijkeTelefoon.MaxLength = 30;
        this.columnEmail.DefaultValue = (object) "";
        this.columnEmail.MaxLength = 30;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow NewClubsRow() => (BCEDataSet.ClubsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.ClubsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.ClubsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.ClubsRowChanged == null)
          return;
        this.ClubsRowChanged((object) this, new BCEDataSet.ClubsRowChangeEvent((BCEDataSet.ClubsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.ClubsRowChanging == null)
          return;
        this.ClubsRowChanging((object) this, new BCEDataSet.ClubsRowChangeEvent((BCEDataSet.ClubsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.ClubsRowDeleted == null)
          return;
        this.ClubsRowDeleted((object) this, new BCEDataSet.ClubsRowChangeEvent((BCEDataSet.ClubsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.ClubsRowDeleting == null)
          return;
        this.ClubsRowDeleting((object) this, new BCEDataSet.ClubsRowChangeEvent((BCEDataSet.ClubsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveClubsRow(BCEDataSet.ClubsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (ClubsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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
    public class AdressenDataTable : TypedTableBase<BCEDataSet.AdressenRow>
    {
      private DataColumn columnId;
      private DataColumn columnLicentie;
      private DataColumn columnNaam;
      private DataColumn columnAdres;
      private DataColumn columnPostcode;
      private DataColumn columnGemeente;
      private DataColumn columnTelefoon;
      private DataColumn columnFax;
      private DataColumn columnEmail;
      private DataColumn columnBankrekening;
      private DataColumn columnLaatste;
      private DataColumn columnKWX;
      private DataColumn columnKWY;
      private DataColumn columnSerial;
      private DataColumn columnClubID;
      private DataColumn columnNotes;
      private DataColumn columnCountry;
      private DataColumn columnClub1;
      private DataColumn columnClub2;
      private DataColumn columnLastSendedToBA;
      private DataColumn columnNaamUnicode;
      private DataColumn columnGemeenteUnicode;
      private DataColumn columnIsManual;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public AdressenDataTable()
      {
        this.TableName = "Adressen";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal AdressenDataTable(DataTable table)
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
      protected AdressenDataTable(SerializationInfo info, StreamingContext context)
        : base(info, context)
        => this.InitVars();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IdColumn => this.columnId;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LicentieColumn => this.columnLicentie;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NaamColumn => this.columnNaam;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn AdresColumn => this.columnAdres;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn PostcodeColumn => this.columnPostcode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GemeenteColumn => this.columnGemeente;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn TelefoonColumn => this.columnTelefoon;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FaxColumn => this.columnFax;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn EmailColumn => this.columnEmail;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn BankrekeningColumn => this.columnBankrekening;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LaatsteColumn => this.columnLaatste;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn KWXColumn => this.columnKWX;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn KWYColumn => this.columnKWY;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SerialColumn => this.columnSerial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ClubIDColumn => this.columnClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NotesColumn => this.columnNotes;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CountryColumn => this.columnCountry;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Club1Column => this.columnClub1;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn Club2Column => this.columnClub2;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LastSendedToBAColumn => this.columnLastSendedToBA;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn NaamUnicodeColumn => this.columnNaamUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn GemeenteUnicodeColumn => this.columnGemeenteUnicode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn IsManualColumn => this.columnIsManual;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow this[int index] => (BCEDataSet.AdressenRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.AdressenRowChangeEventHandler AdressenRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.AdressenRowChangeEventHandler AdressenRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.AdressenRowChangeEventHandler AdressenRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.AdressenRowChangeEventHandler AdressenRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddAdressenRow(BCEDataSet.AdressenRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow AddAdressenRow(
        string Licentie,
        string Naam,
        string Adres,
        string Postcode,
        string Gemeente,
        string Telefoon,
        string Fax,
        string Email,
        string Bankrekening,
        string Laatste,
        int KWX,
        int KWY,
        string Serial,
        BCEDataSet.ClubsRow parentClubsRowByClubs_Adressen,
        string Notes,
        string Country,
        string Club1,
        string Club2,
        DateTime LastSendedToBA,
        string NaamUnicode,
        string GemeenteUnicode,
        bool IsManual)
      {
        BCEDataSet.AdressenRow adressenRow = (BCEDataSet.AdressenRow) this.NewRow();
        object[] objArray = new object[23]
        {
          null,
          (object) Licentie,
          (object) Naam,
          (object) Adres,
          (object) Postcode,
          (object) Gemeente,
          (object) Telefoon,
          (object) Fax,
          (object) Email,
          (object) Bankrekening,
          (object) Laatste,
          (object) KWX,
          (object) KWY,
          (object) Serial,
          null,
          (object) Notes,
          (object) Country,
          (object) Club1,
          (object) Club2,
          (object) LastSendedToBA,
          (object) NaamUnicode,
          (object) GemeenteUnicode,
          (object) IsManual
        };
        if (parentClubsRowByClubs_Adressen != null)
          objArray[14] = parentClubsRowByClubs_Adressen[0];
        adressenRow.ItemArray = objArray;
        this.Rows.Add((DataRow) adressenRow);
        return adressenRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow FindById(int Id) => (BCEDataSet.AdressenRow) this.Rows.Find(new object[1]
      {
        (object) Id
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.AdressenDataTable adressenDataTable = (BCEDataSet.AdressenDataTable) base.Clone();
        adressenDataTable.InitVars();
        return (DataTable) adressenDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.AdressenDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnId = this.Columns["Id"];
        this.columnLicentie = this.Columns["Licentie"];
        this.columnNaam = this.Columns["Naam"];
        this.columnAdres = this.Columns["Adres"];
        this.columnPostcode = this.Columns["Postcode"];
        this.columnGemeente = this.Columns["Gemeente"];
        this.columnTelefoon = this.Columns["Telefoon"];
        this.columnFax = this.Columns["Fax"];
        this.columnEmail = this.Columns["Email"];
        this.columnBankrekening = this.Columns["Bankrekening"];
        this.columnLaatste = this.Columns["Laatste"];
        this.columnKWX = this.Columns["KWX"];
        this.columnKWY = this.Columns["KWY"];
        this.columnSerial = this.Columns["Serial"];
        this.columnClubID = this.Columns["ClubID"];
        this.columnNotes = this.Columns["Notes"];
        this.columnCountry = this.Columns["Country"];
        this.columnClub1 = this.Columns["Club1"];
        this.columnClub2 = this.Columns["Club2"];
        this.columnLastSendedToBA = this.Columns["LastSendedToBA"];
        this.columnNaamUnicode = this.Columns["NaamUnicode"];
        this.columnGemeenteUnicode = this.Columns["GemeenteUnicode"];
        this.columnIsManual = this.Columns["IsManual"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnId = new DataColumn("Id", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnId);
        this.columnLicentie = new DataColumn("Licentie", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLicentie);
        this.columnNaam = new DataColumn("Naam", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNaam);
        this.columnAdres = new DataColumn("Adres", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnAdres);
        this.columnPostcode = new DataColumn("Postcode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnPostcode);
        this.columnGemeente = new DataColumn("Gemeente", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGemeente);
        this.columnTelefoon = new DataColumn("Telefoon", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnTelefoon);
        this.columnFax = new DataColumn("Fax", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFax);
        this.columnEmail = new DataColumn("Email", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnEmail);
        this.columnBankrekening = new DataColumn("Bankrekening", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnBankrekening);
        this.columnLaatste = new DataColumn("Laatste", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLaatste);
        this.columnKWX = new DataColumn("KWX", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnKWX);
        this.columnKWY = new DataColumn("KWY", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnKWY);
        this.columnSerial = new DataColumn("Serial", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSerial);
        this.columnClubID = new DataColumn("ClubID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClubID);
        this.columnNotes = new DataColumn("Notes", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNotes);
        this.columnCountry = new DataColumn("Country", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCountry);
        this.columnClub1 = new DataColumn("Club1", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClub1);
        this.columnClub2 = new DataColumn("Club2", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnClub2);
        this.columnLastSendedToBA = new DataColumn("LastSendedToBA", typeof (DateTime), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLastSendedToBA);
        this.columnNaamUnicode = new DataColumn("NaamUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnNaamUnicode);
        this.columnGemeenteUnicode = new DataColumn("GemeenteUnicode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnGemeenteUnicode);
        this.columnIsManual = new DataColumn("IsManual", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnIsManual);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnId
        }, true));
        this.columnId.AutoIncrement = true;
        this.columnId.AllowDBNull = false;
        this.columnId.Unique = true;
        this.columnLicentie.DefaultValue = (object) "";
        this.columnLicentie.MaxLength = 11;
        this.columnNaam.DefaultValue = (object) "";
        this.columnNaam.MaxLength = 30;
        this.columnAdres.DefaultValue = (object) "";
        this.columnAdres.MaxLength = 30;
        this.columnPostcode.DefaultValue = (object) "";
        this.columnPostcode.MaxLength = 8;
        this.columnGemeente.DefaultValue = (object) "";
        this.columnGemeente.MaxLength = 30;
        this.columnTelefoon.DefaultValue = (object) "";
        this.columnTelefoon.MaxLength = 30;
        this.columnFax.DefaultValue = (object) "";
        this.columnFax.MaxLength = 30;
        this.columnEmail.DefaultValue = (object) "";
        this.columnEmail.MaxLength = 50;
        this.columnBankrekening.DefaultValue = (object) "";
        this.columnBankrekening.MaxLength = 30;
        this.columnLaatste.DefaultValue = (object) "";
        this.columnLaatste.MaxLength = 4;
        this.columnKWX.DefaultValue = (object) 0;
        this.columnKWY.DefaultValue = (object) 0;
        this.columnSerial.DefaultValue = (object) "";
        this.columnSerial.MaxLength = (int) byte.MaxValue;
        this.columnClubID.DefaultValue = (object) 1;
        this.columnNotes.DefaultValue = (object) "";
        this.columnNotes.MaxLength = (int) byte.MaxValue;
        this.columnCountry.DefaultValue = (object) "";
        this.columnCountry.MaxLength = (int) byte.MaxValue;
        this.columnClub1.DefaultValue = (object) "";
        this.columnClub2.DefaultValue = (object) "";
        this.columnNaamUnicode.DefaultValue = (object) "";
        this.columnNaamUnicode.MaxLength = 50;
        this.columnGemeenteUnicode.DefaultValue = (object) "";
        this.columnGemeenteUnicode.MaxLength = 50;
        this.columnIsManual.AllowDBNull = false;
        this.columnIsManual.DefaultValue = (object) false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow NewAdressenRow() => (BCEDataSet.AdressenRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.AdressenRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.AdressenRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.AdressenRowChanged == null)
          return;
        this.AdressenRowChanged((object) this, new BCEDataSet.AdressenRowChangeEvent((BCEDataSet.AdressenRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.AdressenRowChanging == null)
          return;
        this.AdressenRowChanging((object) this, new BCEDataSet.AdressenRowChangeEvent((BCEDataSet.AdressenRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.AdressenRowDeleted == null)
          return;
        this.AdressenRowDeleted((object) this, new BCEDataSet.AdressenRowChangeEvent((BCEDataSet.AdressenRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.AdressenRowDeleting == null)
          return;
        this.AdressenRowDeleting((object) this, new BCEDataSet.AdressenRowChangeEvent((BCEDataSet.AdressenRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveAdressenRow(BCEDataSet.AdressenRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (AdressenDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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
    public class PigeonsDataTable : TypedTableBase<BCEDataSet.PigeonsRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnDBRing;
      private DataColumn columnELRing;
      private DataColumn columnFEMALE;
      private DataColumn columnColor;
      private DataColumn columnFieldColumn;
      private DataColumn columnSel;
      private DataColumn columnOrder;

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
      public DataColumn DBRingColumn => this.columnDBRing;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ELRingColumn => this.columnELRing;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn FEMALEColumn => this.columnFEMALE;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ColorColumn => this.columnColor;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn ColumnColumn => this.columnFieldColumn;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn SelColumn => this.columnSel;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn OrderColumn => this.columnOrder;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow this[int index] => (BCEDataSet.PigeonsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.PigeonsRowChangeEventHandler PigeonsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.PigeonsRowChangeEventHandler PigeonsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.PigeonsRowChangeEventHandler PigeonsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddPigeonsRow(BCEDataSet.PigeonsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow AddPigeonsRow(
        BCEDataSet.AdressenRow parentAdressenRowByAdressen_Pigeons,
        string DBRing,
        string ELRing,
        bool FEMALE,
        string Color,
        int Column,
        bool Sel,
        int Order)
      {
        BCEDataSet.PigeonsRow pigeonsRow = (BCEDataSet.PigeonsRow) this.NewRow();
        object[] objArray = new object[9]
        {
          null,
          null,
          (object) DBRing,
          (object) ELRing,
          (object) FEMALE,
          (object) Color,
          (object) Column,
          (object) Sel,
          (object) Order
        };
        if (parentAdressenRowByAdressen_Pigeons != null)
          objArray[1] = parentAdressenRowByAdressen_Pigeons[0];
        pigeonsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) pigeonsRow);
        return pigeonsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow FindByID(int ID) => (BCEDataSet.PigeonsRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.PigeonsDataTable pigeonsDataTable = (BCEDataSet.PigeonsDataTable) base.Clone();
        pigeonsDataTable.InitVars();
        return (DataTable) pigeonsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.PigeonsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnDBRing = this.Columns["DBRing"];
        this.columnELRing = this.Columns["ELRing"];
        this.columnFEMALE = this.Columns["FEMALE"];
        this.columnColor = this.Columns["Color"];
        this.columnFieldColumn = this.Columns["Column"];
        this.columnSel = this.Columns["Sel"];
        this.columnOrder = this.Columns["Order"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnDBRing = new DataColumn("DBRing", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDBRing);
        this.columnELRing = new DataColumn("ELRing", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnELRing);
        this.columnFEMALE = new DataColumn("FEMALE", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFEMALE);
        this.columnColor = new DataColumn("Color", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnColor);
        this.columnFieldColumn = new DataColumn("Column", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFieldColumn);
        this.columnSel = new DataColumn("Sel", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnSel);
        this.columnOrder = new DataColumn("Order", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnOrder);
        this.Constraints.Add((Constraint) new UniqueConstraint("Constraint1", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnFancierID.DefaultValue = (object) 0;
        this.columnDBRing.DefaultValue = (object) "";
        this.columnDBRing.MaxLength = (int) byte.MaxValue;
        this.columnELRing.DefaultValue = (object) "";
        this.columnELRing.MaxLength = (int) byte.MaxValue;
        this.columnFEMALE.DefaultValue = (object) false;
        this.columnColor.DefaultValue = (object) "";
        this.columnFieldColumn.DefaultValue = (object) 0;
        this.columnSel.DefaultValue = (object) false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow NewPigeonsRow() => (BCEDataSet.PigeonsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.PigeonsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.PigeonsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.PigeonsRowChanged == null)
          return;
        this.PigeonsRowChanged((object) this, new BCEDataSet.PigeonsRowChangeEvent((BCEDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.PigeonsRowChanging == null)
          return;
        this.PigeonsRowChanging((object) this, new BCEDataSet.PigeonsRowChangeEvent((BCEDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.PigeonsRowDeleted == null)
          return;
        this.PigeonsRowDeleted((object) this, new BCEDataSet.PigeonsRowChangeEvent((BCEDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.PigeonsRowDeleting == null)
          return;
        this.PigeonsRowDeleting((object) this, new BCEDataSet.PigeonsRowChangeEvent((BCEDataSet.PigeonsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemovePigeonsRow(BCEDataSet.PigeonsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (PigeonsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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
    public class SettingsDataTable : TypedTableBase<BCEDataSet.SettingsRow>
    {
      private DataColumn columnCalculationPrintClubID;
      private DataColumn columnCalculationPrintPositie;
      private DataColumn columnCalculationPrintPercentage;
      private DataColumn columnCalculationPrintFCIAB;
      private DataColumn columnCalculationPrintFCICD;
      private DataColumn columnCalculationPrintFCIE;
      private DataColumn columnCalculationPrintImperial;
      private DataColumn columnCalculationPrintFCICustom;
      private DataColumn columnCalculationPrintFCIPercentage;
      private DataColumn columnCalculationPrintFlightTime;
      private DataColumn columnCalculationPrintTeamNbr;
      private DataColumn columnCalculationPrintPoints100;
      private DataColumn columnCalculationPrintLicense;
      private DataColumn columnCalculationPrintOveralPoints;

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
      public DataColumn CalculationPrintClubIDColumn => this.columnCalculationPrintClubID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintPositieColumn => this.columnCalculationPrintPositie;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintPercentageColumn => this.columnCalculationPrintPercentage;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFCIABColumn => this.columnCalculationPrintFCIAB;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFCICDColumn => this.columnCalculationPrintFCICD;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFCIEColumn => this.columnCalculationPrintFCIE;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintImperialColumn => this.columnCalculationPrintImperial;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFCICustomColumn => this.columnCalculationPrintFCICustom;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFCIPercentageColumn => this.columnCalculationPrintFCIPercentage;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintFlightTimeColumn => this.columnCalculationPrintFlightTime;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintTeamNbrColumn => this.columnCalculationPrintTeamNbr;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintPoints100Column => this.columnCalculationPrintPoints100;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintLicenseColumn => this.columnCalculationPrintLicense;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn CalculationPrintOveralPointsColumn => this.columnCalculationPrintOveralPoints;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.SettingsRow this[int index] => (BCEDataSet.SettingsRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.SettingsRowChangeEventHandler SettingsRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.SettingsRowChangeEventHandler SettingsRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.SettingsRowChangeEventHandler SettingsRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.SettingsRowChangeEventHandler SettingsRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddSettingsRow(BCEDataSet.SettingsRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.SettingsRow AddSettingsRow(
        bool CalculationPrintClubID,
        bool CalculationPrintPositie,
        bool CalculationPrintPercentage,
        bool CalculationPrintFCIAB,
        bool CalculationPrintFCICD,
        bool CalculationPrintFCIE,
        bool CalculationPrintImperial,
        bool CalculationPrintFCICustom,
        Decimal CalculationPrintFCIPercentage,
        bool CalculationPrintFlightTime,
        bool CalculationPrintTeamNbr,
        bool CalculationPrintPoints100,
        bool CalculationPrintLicense,
        bool CalculationPrintOveralPoints)
      {
        BCEDataSet.SettingsRow settingsRow = (BCEDataSet.SettingsRow) this.NewRow();
        object[] objArray = new object[14]
        {
          (object) CalculationPrintClubID,
          (object) CalculationPrintPositie,
          (object) CalculationPrintPercentage,
          (object) CalculationPrintFCIAB,
          (object) CalculationPrintFCICD,
          (object) CalculationPrintFCIE,
          (object) CalculationPrintImperial,
          (object) CalculationPrintFCICustom,
          (object) CalculationPrintFCIPercentage,
          (object) CalculationPrintFlightTime,
          (object) CalculationPrintTeamNbr,
          (object) CalculationPrintPoints100,
          (object) CalculationPrintLicense,
          (object) CalculationPrintOveralPoints
        };
        settingsRow.ItemArray = objArray;
        this.Rows.Add((DataRow) settingsRow);
        return settingsRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.SettingsDataTable settingsDataTable = (BCEDataSet.SettingsDataTable) base.Clone();
        settingsDataTable.InitVars();
        return (DataTable) settingsDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.SettingsDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnCalculationPrintClubID = this.Columns["CalculationPrintClubID"];
        this.columnCalculationPrintPositie = this.Columns["CalculationPrintPositie"];
        this.columnCalculationPrintPercentage = this.Columns["CalculationPrintPercentage"];
        this.columnCalculationPrintFCIAB = this.Columns["CalculationPrintFCIAB"];
        this.columnCalculationPrintFCICD = this.Columns["CalculationPrintFCICD"];
        this.columnCalculationPrintFCIE = this.Columns["CalculationPrintFCIE"];
        this.columnCalculationPrintImperial = this.Columns["CalculationPrintImperial"];
        this.columnCalculationPrintFCICustom = this.Columns["CalculationPrintFCICustom"];
        this.columnCalculationPrintFCIPercentage = this.Columns["CalculationPrintFCIPercentage"];
        this.columnCalculationPrintFlightTime = this.Columns["CalculationPrintFlightTime"];
        this.columnCalculationPrintTeamNbr = this.Columns["CalculationPrintTeamNbr"];
        this.columnCalculationPrintPoints100 = this.Columns["CalculationPrintPoints100"];
        this.columnCalculationPrintLicense = this.Columns["CalculationPrintLicense"];
        this.columnCalculationPrintOveralPoints = this.Columns["CalculationPrintOveralPoints"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnCalculationPrintClubID = new DataColumn("CalculationPrintClubID", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintClubID);
        this.columnCalculationPrintPositie = new DataColumn("CalculationPrintPositie", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintPositie);
        this.columnCalculationPrintPercentage = new DataColumn("CalculationPrintPercentage", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintPercentage);
        this.columnCalculationPrintFCIAB = new DataColumn("CalculationPrintFCIAB", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFCIAB);
        this.columnCalculationPrintFCICD = new DataColumn("CalculationPrintFCICD", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFCICD);
        this.columnCalculationPrintFCIE = new DataColumn("CalculationPrintFCIE", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFCIE);
        this.columnCalculationPrintImperial = new DataColumn("CalculationPrintImperial", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintImperial);
        this.columnCalculationPrintFCICustom = new DataColumn("CalculationPrintFCICustom", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFCICustom);
        this.columnCalculationPrintFCIPercentage = new DataColumn("CalculationPrintFCIPercentage", typeof (Decimal), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFCIPercentage);
        this.columnCalculationPrintFlightTime = new DataColumn("CalculationPrintFlightTime", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintFlightTime);
        this.columnCalculationPrintTeamNbr = new DataColumn("CalculationPrintTeamNbr", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintTeamNbr);
        this.columnCalculationPrintPoints100 = new DataColumn("CalculationPrintPoints100", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintPoints100);
        this.columnCalculationPrintLicense = new DataColumn("CalculationPrintLicense", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintLicense);
        this.columnCalculationPrintOveralPoints = new DataColumn("CalculationPrintOveralPoints", typeof (bool), (string) null, MappingType.Element);
        this.Columns.Add(this.columnCalculationPrintOveralPoints);
        this.columnCalculationPrintClubID.DefaultValue = (object) false;
        this.columnCalculationPrintPositie.DefaultValue = (object) false;
        this.columnCalculationPrintPercentage.DefaultValue = (object) false;
        this.columnCalculationPrintFCIAB.DefaultValue = (object) false;
        this.columnCalculationPrintFCICD.DefaultValue = (object) false;
        this.columnCalculationPrintFCIE.DefaultValue = (object) false;
        this.columnCalculationPrintImperial.DefaultValue = (object) false;
        this.columnCalculationPrintFCICustom.DefaultValue = (object) false;
        this.columnCalculationPrintFCIPercentage.DefaultValue = (object) 100M;
        this.columnCalculationPrintFlightTime.DefaultValue = (object) false;
        this.columnCalculationPrintTeamNbr.DefaultValue = (object) false;
        this.columnCalculationPrintPoints100.DefaultValue = (object) false;
        this.columnCalculationPrintLicense.DefaultValue = (object) false;
        this.columnCalculationPrintOveralPoints.DefaultValue = (object) false;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.SettingsRow NewSettingsRow() => (BCEDataSet.SettingsRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.SettingsRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.SettingsRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.SettingsRowChanged == null)
          return;
        this.SettingsRowChanged((object) this, new BCEDataSet.SettingsRowChangeEvent((BCEDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.SettingsRowChanging == null)
          return;
        this.SettingsRowChanging((object) this, new BCEDataSet.SettingsRowChangeEvent((BCEDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.SettingsRowDeleted == null)
          return;
        this.SettingsRowDeleted((object) this, new BCEDataSet.SettingsRowChangeEvent((BCEDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.SettingsRowDeleting == null)
          return;
        this.SettingsRowDeleting((object) this, new BCEDataSet.SettingsRowChangeEvent((BCEDataSet.SettingsRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveSettingsRow(BCEDataSet.SettingsRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (SettingsDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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
    public class DistancesDataTable : TypedTableBase<BCEDataSet.DistancesRow>
    {
      private DataColumn columnID;
      private DataColumn columnFancierID;
      private DataColumn columnLosplaatsID;
      private DataColumn columnDistance;
      private DataColumn columnDistanceYards;
      private DataColumn columnLosplaatsNaam;
      private DataColumn columnRaceCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DistancesDataTable()
      {
        this.TableName = "Distances";
        this.BeginInit();
        this.InitClass();
        this.EndInit();
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal DistancesDataTable(DataTable table)
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
      protected DistancesDataTable(SerializationInfo info, StreamingContext context)
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
      public DataColumn LosplaatsIDColumn => this.columnLosplaatsID;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceColumn => this.columnDistance;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn DistanceYardsColumn => this.columnDistanceYards;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn LosplaatsNaamColumn => this.columnLosplaatsNaam;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataColumn RaceCodeColumn => this.columnRaceCode;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      [Browsable(false)]
      public int Count => this.Rows.Count;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow this[int index] => (BCEDataSet.DistancesRow) this.Rows[index];

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.DistancesRowChangeEventHandler DistancesRowChanging;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.DistancesRowChangeEventHandler DistancesRowChanged;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.DistancesRowChangeEventHandler DistancesRowDeleting;

      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public event BCEDataSet.DistancesRowChangeEventHandler DistancesRowDeleted;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void AddDistancesRow(BCEDataSet.DistancesRow row) => this.Rows.Add((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow AddDistancesRow(
        BCEDataSet.AdressenRow parentAdressenRowByAdressen_Distances,
        BCEDataSet.LossingsplaatsRow parentLossingsplaatsRowByLossingsplaats_Distances,
        int Distance,
        int DistanceYards,
        string LosplaatsNaam,
        string RaceCode)
      {
        BCEDataSet.DistancesRow distancesRow = (BCEDataSet.DistancesRow) this.NewRow();
        object[] objArray = new object[7]
        {
          null,
          null,
          null,
          (object) Distance,
          (object) DistanceYards,
          (object) LosplaatsNaam,
          (object) RaceCode
        };
        if (parentAdressenRowByAdressen_Distances != null)
          objArray[1] = parentAdressenRowByAdressen_Distances[0];
        if (parentLossingsplaatsRowByLossingsplaats_Distances != null)
          objArray[2] = parentLossingsplaatsRowByLossingsplaats_Distances[0];
        distancesRow.ItemArray = objArray;
        this.Rows.Add((DataRow) distancesRow);
        return distancesRow;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow FindByID(int ID) => (BCEDataSet.DistancesRow) this.Rows.Find(new object[1]
      {
        (object) ID
      });

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public override DataTable Clone()
      {
        BCEDataSet.DistancesDataTable distancesDataTable = (BCEDataSet.DistancesDataTable) base.Clone();
        distancesDataTable.InitVars();
        return (DataTable) distancesDataTable;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataTable CreateInstance() => (DataTable) new BCEDataSet.DistancesDataTable();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal void InitVars()
      {
        this.columnID = this.Columns["ID"];
        this.columnFancierID = this.Columns["FancierID"];
        this.columnLosplaatsID = this.Columns["LosplaatsID"];
        this.columnDistance = this.Columns["Distance"];
        this.columnDistanceYards = this.Columns["DistanceYards"];
        this.columnLosplaatsNaam = this.Columns["LosplaatsNaam"];
        this.columnRaceCode = this.Columns["RaceCode"];
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      private void InitClass()
      {
        this.columnID = new DataColumn("ID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnID);
        this.columnFancierID = new DataColumn("FancierID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnFancierID);
        this.columnLosplaatsID = new DataColumn("LosplaatsID", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLosplaatsID);
        this.columnDistance = new DataColumn("Distance", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistance);
        this.columnDistanceYards = new DataColumn("DistanceYards", typeof (int), (string) null, MappingType.Element);
        this.Columns.Add(this.columnDistanceYards);
        this.columnLosplaatsNaam = new DataColumn("LosplaatsNaam", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnLosplaatsNaam);
        this.columnRaceCode = new DataColumn("RaceCode", typeof (string), (string) null, MappingType.Element);
        this.Columns.Add(this.columnRaceCode);
        this.Constraints.Add((Constraint) new UniqueConstraint("PKDistances", new DataColumn[1]
        {
          this.columnID
        }, true));
        this.columnID.AutoIncrement = true;
        this.columnID.AutoIncrementSeed = 1L;
        this.columnID.AllowDBNull = false;
        this.columnID.Unique = true;
        this.columnLosplaatsNaam.DefaultValue = (object) "";
        this.columnLosplaatsNaam.MaxLength = 30;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow NewDistancesRow() => (BCEDataSet.DistancesRow) this.NewRow();

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override DataRow NewRowFromBuilder(DataRowBuilder builder) => (DataRow) new BCEDataSet.DistancesRow(builder);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override Type GetRowType() => typeof (BCEDataSet.DistancesRow);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanged(DataRowChangeEventArgs e)
      {
        base.OnRowChanged(e);
        if (this.DistancesRowChanged == null)
          return;
        this.DistancesRowChanged((object) this, new BCEDataSet.DistancesRowChangeEvent((BCEDataSet.DistancesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowChanging(DataRowChangeEventArgs e)
      {
        base.OnRowChanging(e);
        if (this.DistancesRowChanging == null)
          return;
        this.DistancesRowChanging((object) this, new BCEDataSet.DistancesRowChangeEvent((BCEDataSet.DistancesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleted(DataRowChangeEventArgs e)
      {
        base.OnRowDeleted(e);
        if (this.DistancesRowDeleted == null)
          return;
        this.DistancesRowDeleted((object) this, new BCEDataSet.DistancesRowChangeEvent((BCEDataSet.DistancesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      protected override void OnRowDeleting(DataRowChangeEventArgs e)
      {
        base.OnRowDeleting(e);
        if (this.DistancesRowDeleting == null)
          return;
        this.DistancesRowDeleting((object) this, new BCEDataSet.DistancesRowChangeEvent((BCEDataSet.DistancesRow) e.Row, e.Action));
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void RemoveDistancesRow(BCEDataSet.DistancesRow row) => this.Rows.Remove((DataRow) row);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public static XmlSchemaComplexType GetTypedTableSchema(XmlSchemaSet xs)
      {
        XmlSchemaComplexType schemaComplexType = new XmlSchemaComplexType();
        XmlSchemaSequence xmlSchemaSequence = new XmlSchemaSequence();
        BCEDataSet bceDataSet = new BCEDataSet();
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
          FixedValue = bceDataSet.Namespace
        });
        schemaComplexType.Attributes.Add((XmlSchemaObject) new XmlSchemaAttribute()
        {
          Name = "tableTypeName",
          FixedValue = nameof (DistancesDataTable)
        });
        schemaComplexType.Particle = (XmlSchemaParticle) xmlSchemaSequence;
        XmlSchema schemaSerializable = bceDataSet.GetSchemaSerializable();
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

    public class LossingsplaatsRow : DataRow
    {
      private BCEDataSet.LossingsplaatsDataTable tableLossingsplaats;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal LossingsplaatsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableLossingsplaats = (BCEDataSet.LossingsplaatsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int id
      {
        get => (int) this[this.tableLossingsplaats.idColumn];
        set => this[this.tableLossingsplaats.idColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Losplaats
      {
        get => this.IsLosplaatsNull() ? string.Empty : (string) this[this.tableLossingsplaats.LosplaatsColumn];
        set => this[this.tableLossingsplaats.LosplaatsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Code
      {
        get => this.IsCodeNull() ? string.Empty : (string) this[this.tableLossingsplaats.CodeColumn];
        set => this[this.tableLossingsplaats.CodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int LWX
      {
        get
        {
          try
          {
            return (int) this[this.tableLossingsplaats.LWXColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'LWX' in table 'Lossingsplaats' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableLossingsplaats.LWXColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int LWY
      {
        get
        {
          try
          {
            return (int) this[this.tableLossingsplaats.LWYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'LWY' in table 'Lossingsplaats' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableLossingsplaats.LWYColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Selected
      {
        get
        {
          try
          {
            return (bool) this[this.tableLossingsplaats.SelectedColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Selected' in table 'Lossingsplaats' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableLossingsplaats.SelectedColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Place
      {
        get => this.IsPlaceNull() ? string.Empty : (string) this[this.tableLossingsplaats.PlaceColumn];
        set => this[this.tableLossingsplaats.PlaceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Country
      {
        get => this.IsCountryNull() ? string.Empty : (string) this[this.tableLossingsplaats.CountryColumn];
        set => this[this.tableLossingsplaats.CountryColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int VolgordeNummer
      {
        get
        {
          try
          {
            return (int) this[this.tableLossingsplaats.VolgordeNummerColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'VolgordeNummer' in table 'Lossingsplaats' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableLossingsplaats.VolgordeNummerColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Distance
      {
        get => (int) this[this.tableLossingsplaats.DistanceColumn];
        set => this[this.tableLossingsplaats.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int DistanceYards
      {
        get => (int) this[this.tableLossingsplaats.DistanceYardsColumn];
        set => this[this.tableLossingsplaats.DistanceYardsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RaceCode
      {
        get
        {
          try
          {
            return (string) this[this.tableLossingsplaats.RaceCodeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RaceCode' in table 'Lossingsplaats' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableLossingsplaats.RaceCodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLosplaatsNull() => this.IsNull(this.tableLossingsplaats.LosplaatsColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLosplaatsNull() => this[this.tableLossingsplaats.LosplaatsColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCodeNull() => this.IsNull(this.tableLossingsplaats.CodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCodeNull() => this[this.tableLossingsplaats.CodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLWXNull() => this.IsNull(this.tableLossingsplaats.LWXColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLWXNull() => this[this.tableLossingsplaats.LWXColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLWYNull() => this.IsNull(this.tableLossingsplaats.LWYColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLWYNull() => this[this.tableLossingsplaats.LWYColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSelectedNull() => this.IsNull(this.tableLossingsplaats.SelectedColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSelectedNull() => this[this.tableLossingsplaats.SelectedColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPlaceNull() => this.IsNull(this.tableLossingsplaats.PlaceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPlaceNull() => this[this.tableLossingsplaats.PlaceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCountryNull() => this.IsNull(this.tableLossingsplaats.CountryColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCountryNull() => this[this.tableLossingsplaats.CountryColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsVolgordeNummerNull() => this.IsNull(this.tableLossingsplaats.VolgordeNummerColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetVolgordeNummerNull() => this[this.tableLossingsplaats.VolgordeNummerColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRaceCodeNull() => this.IsNull(this.tableLossingsplaats.RaceCodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRaceCodeNull() => this[this.tableLossingsplaats.RaceCodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow[] GetDistancesRows() => this.Table.ChildRelations["Lossingsplaats_Distances"] == null ? new BCEDataSet.DistancesRow[0] : (BCEDataSet.DistancesRow[]) this.GetChildRows(this.Table.ChildRelations["Lossingsplaats_Distances"]);
    }

    public class ClubsRow : DataRow
    {
      private BCEDataSet.ClubsDataTable tableClubs;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal ClubsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableClubs = (BCEDataSet.ClubsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableClubs.IDColumn];
        set => this[this.tableClubs.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubID
      {
        get => this.IsClubIDNull() ? string.Empty : (string) this[this.tableClubs.ClubIDColumn];
        set => this[this.tableClubs.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Name
      {
        get => this.IsNameNull() ? string.Empty : (string) this[this.tableClubs.NameColumn];
        set => this[this.tableClubs.NameColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Pincode
      {
        get => this.IsPincodeNull() ? string.Empty : (string) this[this.tableClubs.PincodeColumn];
        set => this[this.tableClubs.PincodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Adres
      {
        get => this.IsAdresNull() ? string.Empty : (string) this[this.tableClubs.AdresColumn];
        set => this[this.tableClubs.AdresColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Postcode
      {
        get => this.IsPostcodeNull() ? string.Empty : (string) this[this.tableClubs.PostcodeColumn];
        set => this[this.tableClubs.PostcodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Gemeente
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.GemeenteColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Gemeente' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.GemeenteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Telefoon
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.TelefoonColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Telefoon' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.TelefoonColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string SerieNrMaster
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.SerieNrMasterColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'SerieNrMaster' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.SerieNrMasterColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Verantwoordelijke
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.VerantwoordelijkeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Verantwoordelijke' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.VerantwoordelijkeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string VerantwoordelijkeTelefoon
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.VerantwoordelijkeTelefoonColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'VerantwoordelijkeTelefoon' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.VerantwoordelijkeTelefoonColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Email
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.EmailColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Email' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.EmailColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ClubNumber
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.ClubNumberColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubNumber' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.ClubNumberColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Union
      {
        get
        {
          try
          {
            return (string) this[this.tableClubs.UnionColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Union' in table 'Clubs' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableClubs.UnionColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tableClubs.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tableClubs.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNameNull() => this.IsNull(this.tableClubs.NameColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNameNull() => this[this.tableClubs.NameColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPincodeNull() => this.IsNull(this.tableClubs.PincodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPincodeNull() => this[this.tableClubs.PincodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAdresNull() => this.IsNull(this.tableClubs.AdresColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAdresNull() => this[this.tableClubs.AdresColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPostcodeNull() => this.IsNull(this.tableClubs.PostcodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPostcodeNull() => this[this.tableClubs.PostcodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGemeenteNull() => this.IsNull(this.tableClubs.GemeenteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGemeenteNull() => this[this.tableClubs.GemeenteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTelefoonNull() => this.IsNull(this.tableClubs.TelefoonColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTelefoonNull() => this[this.tableClubs.TelefoonColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSerieNrMasterNull() => this.IsNull(this.tableClubs.SerieNrMasterColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSerieNrMasterNull() => this[this.tableClubs.SerieNrMasterColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsVerantwoordelijkeNull() => this.IsNull(this.tableClubs.VerantwoordelijkeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetVerantwoordelijkeNull() => this[this.tableClubs.VerantwoordelijkeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsVerantwoordelijkeTelefoonNull() => this.IsNull(this.tableClubs.VerantwoordelijkeTelefoonColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetVerantwoordelijkeTelefoonNull() => this[this.tableClubs.VerantwoordelijkeTelefoonColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEmailNull() => this.IsNull(this.tableClubs.EmailColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEmailNull() => this[this.tableClubs.EmailColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubNumberNull() => this.IsNull(this.tableClubs.ClubNumberColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubNumberNull() => this[this.tableClubs.ClubNumberColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsUnionNull() => this.IsNull(this.tableClubs.UnionColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetUnionNull() => this[this.tableClubs.UnionColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow[] GetAdressenRows() => this.Table.ChildRelations["Clubs_Adressen"] == null ? new BCEDataSet.AdressenRow[0] : (BCEDataSet.AdressenRow[]) this.GetChildRows(this.Table.ChildRelations["Clubs_Adressen"]);
    }

    public class AdressenRow : DataRow
    {
      private BCEDataSet.AdressenDataTable tableAdressen;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal AdressenRow(DataRowBuilder rb)
        : base(rb)
        => this.tableAdressen = (BCEDataSet.AdressenDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Id
      {
        get => (int) this[this.tableAdressen.IdColumn];
        set => this[this.tableAdressen.IdColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Licentie
      {
        get => this.IsLicentieNull() ? string.Empty : (string) this[this.tableAdressen.LicentieColumn];
        set => this[this.tableAdressen.LicentieColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Naam
      {
        get => this.IsNaamNull() ? string.Empty : (string) this[this.tableAdressen.NaamColumn];
        set => this[this.tableAdressen.NaamColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Adres
      {
        get => this.IsAdresNull() ? string.Empty : (string) this[this.tableAdressen.AdresColumn];
        set => this[this.tableAdressen.AdresColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Postcode
      {
        get => this.IsPostcodeNull() ? string.Empty : (string) this[this.tableAdressen.PostcodeColumn];
        set => this[this.tableAdressen.PostcodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Gemeente
      {
        get => this.IsGemeenteNull() ? string.Empty : (string) this[this.tableAdressen.GemeenteColumn];
        set => this[this.tableAdressen.GemeenteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Telefoon
      {
        get => this.IsTelefoonNull() ? string.Empty : (string) this[this.tableAdressen.TelefoonColumn];
        set => this[this.tableAdressen.TelefoonColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Fax
      {
        get => this.IsFaxNull() ? string.Empty : (string) this[this.tableAdressen.FaxColumn];
        set => this[this.tableAdressen.FaxColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Email
      {
        get => this.IsEmailNull() ? string.Empty : (string) this[this.tableAdressen.EmailColumn];
        set => this[this.tableAdressen.EmailColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Bankrekening
      {
        get => this.IsBankrekeningNull() ? string.Empty : (string) this[this.tableAdressen.BankrekeningColumn];
        set => this[this.tableAdressen.BankrekeningColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Laatste
      {
        get => this.IsLaatsteNull() ? string.Empty : (string) this[this.tableAdressen.LaatsteColumn];
        set => this[this.tableAdressen.LaatsteColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int KWX
      {
        get
        {
          try
          {
            return (int) this[this.tableAdressen.KWXColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'KWX' in table 'Adressen' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableAdressen.KWXColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int KWY
      {
        get
        {
          try
          {
            return (int) this[this.tableAdressen.KWYColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'KWY' in table 'Adressen' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableAdressen.KWYColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Serial
      {
        get => this.IsSerialNull() ? string.Empty : (string) this[this.tableAdressen.SerialColumn];
        set => this[this.tableAdressen.SerialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ClubID
      {
        get
        {
          try
          {
            return (int) this[this.tableAdressen.ClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'ClubID' in table 'Adressen' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableAdressen.ClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Notes
      {
        get => this.IsNotesNull() ? string.Empty : (string) this[this.tableAdressen.NotesColumn];
        set => this[this.tableAdressen.NotesColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Country
      {
        get => this.IsCountryNull() ? string.Empty : (string) this[this.tableAdressen.CountryColumn];
        set => this[this.tableAdressen.CountryColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Club1
      {
        get => this.IsClub1Null() ? string.Empty : (string) this[this.tableAdressen.Club1Column];
        set => this[this.tableAdressen.Club1Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Club2
      {
        get => this.IsClub2Null() ? string.Empty : (string) this[this.tableAdressen.Club2Column];
        set => this[this.tableAdressen.Club2Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DateTime LastSendedToBA
      {
        get
        {
          try
          {
            return (DateTime) this[this.tableAdressen.LastSendedToBAColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'LastSendedToBA' in table 'Adressen' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableAdressen.LastSendedToBAColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string NaamUnicode
      {
        get => this.IsNaamUnicodeNull() ? string.Empty : (string) this[this.tableAdressen.NaamUnicodeColumn];
        set => this[this.tableAdressen.NaamUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string GemeenteUnicode
      {
        get => this.IsGemeenteUnicodeNull() ? string.Empty : (string) this[this.tableAdressen.GemeenteUnicodeColumn];
        set => this[this.tableAdressen.GemeenteUnicodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsManual
      {
        get => (bool) this[this.tableAdressen.IsManualColumn];
        set => this[this.tableAdressen.IsManualColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow ClubsRow
      {
        get => (BCEDataSet.ClubsRow) this.GetParentRow(this.Table.ParentRelations["Clubs_Adressen"]);
        set => this.SetParentRow((DataRow) value, this.Table.ParentRelations["Clubs_Adressen"]);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLicentieNull() => this.IsNull(this.tableAdressen.LicentieColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLicentieNull() => this[this.tableAdressen.LicentieColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNaamNull() => this.IsNull(this.tableAdressen.NaamColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNaamNull() => this[this.tableAdressen.NaamColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsAdresNull() => this.IsNull(this.tableAdressen.AdresColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetAdresNull() => this[this.tableAdressen.AdresColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsPostcodeNull() => this.IsNull(this.tableAdressen.PostcodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetPostcodeNull() => this[this.tableAdressen.PostcodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGemeenteNull() => this.IsNull(this.tableAdressen.GemeenteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGemeenteNull() => this[this.tableAdressen.GemeenteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsTelefoonNull() => this.IsNull(this.tableAdressen.TelefoonColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetTelefoonNull() => this[this.tableAdressen.TelefoonColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFaxNull() => this.IsNull(this.tableAdressen.FaxColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFaxNull() => this[this.tableAdressen.FaxColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsEmailNull() => this.IsNull(this.tableAdressen.EmailColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetEmailNull() => this[this.tableAdressen.EmailColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsBankrekeningNull() => this.IsNull(this.tableAdressen.BankrekeningColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetBankrekeningNull() => this[this.tableAdressen.BankrekeningColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLaatsteNull() => this.IsNull(this.tableAdressen.LaatsteColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLaatsteNull() => this[this.tableAdressen.LaatsteColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsKWXNull() => this.IsNull(this.tableAdressen.KWXColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetKWXNull() => this[this.tableAdressen.KWXColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsKWYNull() => this.IsNull(this.tableAdressen.KWYColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetKWYNull() => this[this.tableAdressen.KWYColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSerialNull() => this.IsNull(this.tableAdressen.SerialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSerialNull() => this[this.tableAdressen.SerialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClubIDNull() => this.IsNull(this.tableAdressen.ClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClubIDNull() => this[this.tableAdressen.ClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNotesNull() => this.IsNull(this.tableAdressen.NotesColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNotesNull() => this[this.tableAdressen.NotesColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCountryNull() => this.IsNull(this.tableAdressen.CountryColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCountryNull() => this[this.tableAdressen.CountryColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClub1Null() => this.IsNull(this.tableAdressen.Club1Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClub1Null() => this[this.tableAdressen.Club1Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsClub2Null() => this.IsNull(this.tableAdressen.Club2Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetClub2Null() => this[this.tableAdressen.Club2Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLastSendedToBANull() => this.IsNull(this.tableAdressen.LastSendedToBAColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLastSendedToBANull() => this[this.tableAdressen.LastSendedToBAColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsNaamUnicodeNull() => this.IsNull(this.tableAdressen.NaamUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetNaamUnicodeNull() => this[this.tableAdressen.NaamUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsGemeenteUnicodeNull() => this.IsNull(this.tableAdressen.GemeenteUnicodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetGemeenteUnicodeNull() => this[this.tableAdressen.GemeenteUnicodeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow[] GetPigeonsRows() => this.Table.ChildRelations["Adressen_Pigeons"] == null ? new BCEDataSet.PigeonsRow[0] : (BCEDataSet.PigeonsRow[]) this.GetChildRows(this.Table.ChildRelations["Adressen_Pigeons"]);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow[] GetDistancesRows() => this.Table.ChildRelations["Adressen_Distances"] == null ? new BCEDataSet.DistancesRow[0] : (BCEDataSet.DistancesRow[]) this.GetChildRows(this.Table.ChildRelations["Adressen_Distances"]);
    }

    public class PigeonsRow : DataRow
    {
      private BCEDataSet.PigeonsDataTable tablePigeons;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal PigeonsRow(DataRowBuilder rb)
        : base(rb)
        => this.tablePigeons = (BCEDataSet.PigeonsDataTable) this.Table;

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
      public string DBRing
      {
        get => this.IsDBRingNull() ? string.Empty : (string) this[this.tablePigeons.DBRingColumn];
        set => this[this.tablePigeons.DBRingColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string ELRing
      {
        get => this.IsELRingNull() ? string.Empty : (string) this[this.tablePigeons.ELRingColumn];
        set => this[this.tablePigeons.ELRingColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool FEMALE
      {
        get
        {
          try
          {
            return (bool) this[this.tablePigeons.FEMALEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FEMALE' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.FEMALEColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string Color
      {
        get => this.IsColorNull() ? string.Empty : (string) this[this.tablePigeons.ColorColumn];
        set => this[this.tablePigeons.ColorColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Column
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.ColumnColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Column' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.ColumnColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool Sel
      {
        get
        {
          try
          {
            return (bool) this[this.tablePigeons.SelColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Sel' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.SelColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Order
      {
        get
        {
          try
          {
            return (int) this[this.tablePigeons.OrderColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Order' in table 'Pigeons' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tablePigeons.OrderColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow AdressenRow
      {
        get => (BCEDataSet.AdressenRow) this.GetParentRow(this.Table.ParentRelations["Adressen_Pigeons"]);
        set => this.SetParentRow((DataRow) value, this.Table.ParentRelations["Adressen_Pigeons"]);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tablePigeons.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tablePigeons.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDBRingNull() => this.IsNull(this.tablePigeons.DBRingColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDBRingNull() => this[this.tablePigeons.DBRingColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsELRingNull() => this.IsNull(this.tablePigeons.ELRingColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetELRingNull() => this[this.tablePigeons.ELRingColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFEMALENull() => this.IsNull(this.tablePigeons.FEMALEColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFEMALENull() => this[this.tablePigeons.FEMALEColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsColorNull() => this.IsNull(this.tablePigeons.ColorColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetColorNull() => this[this.tablePigeons.ColorColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsColumnNull() => this.IsNull(this.tablePigeons.ColumnColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetColumnNull() => this[this.tablePigeons.ColumnColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsSelNull() => this.IsNull(this.tablePigeons.SelColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetSelNull() => this[this.tablePigeons.SelColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsOrderNull() => this.IsNull(this.tablePigeons.OrderColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetOrderNull() => this[this.tablePigeons.OrderColumn] = Convert.DBNull;
    }

    public class SettingsRow : DataRow
    {
      private BCEDataSet.SettingsDataTable tableSettings;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal SettingsRow(DataRowBuilder rb)
        : base(rb)
        => this.tableSettings = (BCEDataSet.SettingsDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintClubID
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintClubIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintClubID' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintClubIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintPositie
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintPositieColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintPositie' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintPositieColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintPercentage
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintPercentageColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintPercentage' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintPercentageColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintFCIAB
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintFCIABColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFCIAB' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFCIABColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintFCICD
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintFCICDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFCICD' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFCICDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintFCIE
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintFCIEColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFCIE' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFCIEColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintImperial
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintImperialColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintImperial' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintImperialColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintFCICustom
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintFCICustomColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFCICustom' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFCICustomColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public Decimal CalculationPrintFCIPercentage
      {
        get
        {
          try
          {
            return (Decimal) this[this.tableSettings.CalculationPrintFCIPercentageColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFCIPercentage' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFCIPercentageColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintFlightTime
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintFlightTimeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintFlightTime' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintFlightTimeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintTeamNbr
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintTeamNbrColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintTeamNbr' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintTeamNbrColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintPoints100
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintPoints100Column];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintPoints100' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintPoints100Column] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintLicense
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintLicenseColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintLicense' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintLicenseColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool CalculationPrintOveralPoints
      {
        get
        {
          try
          {
            return (bool) this[this.tableSettings.CalculationPrintOveralPointsColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'CalculationPrintOveralPoints' in table 'Settings' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableSettings.CalculationPrintOveralPointsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintClubIDNull() => this.IsNull(this.tableSettings.CalculationPrintClubIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintClubIDNull() => this[this.tableSettings.CalculationPrintClubIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintPositieNull() => this.IsNull(this.tableSettings.CalculationPrintPositieColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintPositieNull() => this[this.tableSettings.CalculationPrintPositieColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintPercentageNull() => this.IsNull(this.tableSettings.CalculationPrintPercentageColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintPercentageNull() => this[this.tableSettings.CalculationPrintPercentageColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFCIABNull() => this.IsNull(this.tableSettings.CalculationPrintFCIABColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFCIABNull() => this[this.tableSettings.CalculationPrintFCIABColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFCICDNull() => this.IsNull(this.tableSettings.CalculationPrintFCICDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFCICDNull() => this[this.tableSettings.CalculationPrintFCICDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFCIENull() => this.IsNull(this.tableSettings.CalculationPrintFCIEColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFCIENull() => this[this.tableSettings.CalculationPrintFCIEColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintImperialNull() => this.IsNull(this.tableSettings.CalculationPrintImperialColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintImperialNull() => this[this.tableSettings.CalculationPrintImperialColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFCICustomNull() => this.IsNull(this.tableSettings.CalculationPrintFCICustomColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFCICustomNull() => this[this.tableSettings.CalculationPrintFCICustomColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFCIPercentageNull() => this.IsNull(this.tableSettings.CalculationPrintFCIPercentageColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFCIPercentageNull() => this[this.tableSettings.CalculationPrintFCIPercentageColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintFlightTimeNull() => this.IsNull(this.tableSettings.CalculationPrintFlightTimeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintFlightTimeNull() => this[this.tableSettings.CalculationPrintFlightTimeColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintTeamNbrNull() => this.IsNull(this.tableSettings.CalculationPrintTeamNbrColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintTeamNbrNull() => this[this.tableSettings.CalculationPrintTeamNbrColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintPoints100Null() => this.IsNull(this.tableSettings.CalculationPrintPoints100Column);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintPoints100Null() => this[this.tableSettings.CalculationPrintPoints100Column] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintLicenseNull() => this.IsNull(this.tableSettings.CalculationPrintLicenseColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintLicenseNull() => this[this.tableSettings.CalculationPrintLicenseColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsCalculationPrintOveralPointsNull() => this.IsNull(this.tableSettings.CalculationPrintOveralPointsColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetCalculationPrintOveralPointsNull() => this[this.tableSettings.CalculationPrintOveralPointsColumn] = Convert.DBNull;
    }

    public class DistancesRow : DataRow
    {
      private BCEDataSet.DistancesDataTable tableDistances;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      internal DistancesRow(DataRowBuilder rb)
        : base(rb)
        => this.tableDistances = (BCEDataSet.DistancesDataTable) this.Table;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int ID
      {
        get => (int) this[this.tableDistances.IDColumn];
        set => this[this.tableDistances.IDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int FancierID
      {
        get
        {
          try
          {
            return (int) this[this.tableDistances.FancierIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'FancierID' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.FancierIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int LosplaatsID
      {
        get
        {
          try
          {
            return (int) this[this.tableDistances.LosplaatsIDColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'LosplaatsID' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.LosplaatsIDColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int Distance
      {
        get
        {
          try
          {
            return (int) this[this.tableDistances.DistanceColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'Distance' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.DistanceColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public int DistanceYards
      {
        get
        {
          try
          {
            return (int) this[this.tableDistances.DistanceYardsColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'DistanceYards' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.DistanceYardsColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string LosplaatsNaam
      {
        get
        {
          try
          {
            return (string) this[this.tableDistances.LosplaatsNaamColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'LosplaatsNaam' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.LosplaatsNaamColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public string RaceCode
      {
        get
        {
          try
          {
            return (string) this[this.tableDistances.RaceCodeColumn];
          }
          catch (InvalidCastException ex)
          {
            throw new StrongTypingException("The value for column 'RaceCode' in table 'Distances' is DBNull.", (Exception) ex);
          }
        }
        set => this[this.tableDistances.RaceCodeColumn] = (object) value;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow AdressenRow
      {
        get => (BCEDataSet.AdressenRow) this.GetParentRow(this.Table.ParentRelations["Adressen_Distances"]);
        set => this.SetParentRow((DataRow) value, this.Table.ParentRelations["Adressen_Distances"]);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow LossingsplaatsRow
      {
        get => (BCEDataSet.LossingsplaatsRow) this.GetParentRow(this.Table.ParentRelations["Lossingsplaats_Distances"]);
        set => this.SetParentRow((DataRow) value, this.Table.ParentRelations["Lossingsplaats_Distances"]);
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsFancierIDNull() => this.IsNull(this.tableDistances.FancierIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetFancierIDNull() => this[this.tableDistances.FancierIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLosplaatsIDNull() => this.IsNull(this.tableDistances.LosplaatsIDColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLosplaatsIDNull() => this[this.tableDistances.LosplaatsIDColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceNull() => this.IsNull(this.tableDistances.DistanceColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceNull() => this[this.tableDistances.DistanceColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsDistanceYardsNull() => this.IsNull(this.tableDistances.DistanceYardsColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetDistanceYardsNull() => this[this.tableDistances.DistanceYardsColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsLosplaatsNaamNull() => this.IsNull(this.tableDistances.LosplaatsNaamColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetLosplaatsNaamNull() => this[this.tableDistances.LosplaatsNaamColumn] = Convert.DBNull;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public bool IsRaceCodeNull() => this.IsNull(this.tableDistances.RaceCodeColumn);

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public void SetRaceCodeNull() => this[this.tableDistances.RaceCodeColumn] = Convert.DBNull;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class LossingsplaatsRowChangeEvent : EventArgs
    {
      private BCEDataSet.LossingsplaatsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public LossingsplaatsRowChangeEvent(BCEDataSet.LossingsplaatsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.LossingsplaatsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class ClubsRowChangeEvent : EventArgs
    {
      private BCEDataSet.ClubsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public ClubsRowChangeEvent(BCEDataSet.ClubsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.ClubsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class AdressenRowChangeEvent : EventArgs
    {
      private BCEDataSet.AdressenRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public AdressenRowChangeEvent(BCEDataSet.AdressenRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.AdressenRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class PigeonsRowChangeEvent : EventArgs
    {
      private BCEDataSet.PigeonsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public PigeonsRowChangeEvent(BCEDataSet.PigeonsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.PigeonsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class SettingsRowChangeEvent : EventArgs
    {
      private BCEDataSet.SettingsRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public SettingsRowChangeEvent(BCEDataSet.SettingsRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.SettingsRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }

    [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
    public class DistancesRowChangeEvent : EventArgs
    {
      private BCEDataSet.DistancesRow eventRow;
      private DataRowAction eventAction;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DistancesRowChangeEvent(BCEDataSet.DistancesRow row, DataRowAction action)
      {
        this.eventRow = row;
        this.eventAction = action;
      }

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public BCEDataSet.DistancesRow Row => this.eventRow;

      [DebuggerNonUserCode]
      [GeneratedCode("System.Data.Design.TypedDataSetGenerator", "16.0.0.0")]
      public DataRowAction Action => this.eventAction;
    }
  }
}
