// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.CommunicationState
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Collections.Generic;
using System.Threading;

namespace BriconLib.Communications
{
  public class CommunicationState
  {
    private static CommunicationState _communicationState = new CommunicationState();
    public int MasterVersionNumber;
    public int[] FancierVersionNumbers = new int[6];
    private bool _autoLoad;
    private bool _masterFound;
    private string _masterVersion;
    private byte _BAAddress = byte.MaxValue;
    private string _BAVersion;
    private string _previousBAVersion;
    private bool _waitingToConnectMaster;
    private bool _waitingToConnectBA;
    private bool _readingRing;
    private List<Command> _commands = new List<Command>();
    private List<Command> _completedCommands = new List<Command>();
    private List<Command> _commandsWithFeedBack = new List<Command>();
    private bool _modified;

    public static CommunicationState Instance
    {
      get => CommunicationState._communicationState;
      set => CommunicationState._communicationState = value;
    }

    public bool MasterFound
    {
      get => this._masterFound;
      set
      {
        if (this._masterFound == value)
          return;
        this._masterFound = value;
        this._modified = true;
      }
    }

    public string MasterVersion
    {
      get => this._masterVersion;
      set => this._masterVersion = value;
    }

    public bool BAFound => this._BAAddress != byte.MaxValue;

    public bool IsSpeedyXtreme => this.BAVersion.ToUpper().Contains("SPX");

    public bool IsSpeedy => this.BAVersion.ToUpper().Contains("SPD") || this.BAVersion.ToUpper().Contains("SPEED") || this.BAVersion.ToUpper().Contains("CMB");

    public bool IsExtreme => this.BAVersion.ToUpper().Contains("EXTREME") || this.BAVersion.ToUpper().Contains("BRX");

    public byte BAAddress
    {
      get => this._BAAddress;
      set
      {
        if ((int) this._BAAddress == (int) value)
          return;
        this._BAAddress = value;
        this._modified = true;
      }
    }

    public string BAVersion
    {
      get => this._BAVersion;
      set => this._BAVersion = value;
    }

    public string PreviousBAVersion
    {
      get => this._previousBAVersion;
      set
      {
        this._previousBAVersion = value;
        this._modified = true;
      }
    }

    public bool WaitingToConnectMaster
    {
      get => this._waitingToConnectMaster && !this._readingRing;
      set
      {
        if (this._waitingToConnectMaster == value)
          return;
        this._waitingToConnectMaster = value;
        this._modified = true;
      }
    }

    public bool WaitingToConnectBA
    {
      get => this._waitingToConnectBA;
      set
      {
        if (this._waitingToConnectBA == value)
          return;
        this._waitingToConnectBA = value;
        this._modified = true;
      }
    }

    public bool ReadingRing
    {
      get => this._readingRing;
      set
      {
        if (this._readingRing == value)
          return;
        this._readingRing = value;
        this._modified = true;
      }
    }

    public void AddCommand(Command cmd)
    {
      this._modified = true;
      Thread.BeginCriticalRegion();
      this._commands.Add(cmd);
      Thread.EndCriticalRegion();
    }

    public void InsertCommand(Command cmd)
    {
      this._modified = true;
      Thread.BeginCriticalRegion();
      this._commands.Insert(0, cmd);
      Thread.EndCriticalRegion();
    }

    public List<Command> GetAndClearCommands()
    {
      Thread.BeginCriticalRegion();
      List<Command> commands = this._commands;
      this._commands = new List<Command>();
      Thread.EndCriticalRegion();
      return commands;
    }

    public void AddCompletedCommand(Command cmd)
    {
      this._modified = true;
      Thread.BeginCriticalRegion();
      this._completedCommands.Add(cmd);
      Thread.EndCriticalRegion();
    }

    public List<Command> GetAndClearCompletedCommands()
    {
      Thread.BeginCriticalRegion();
      List<Command> completedCommands = this._completedCommands;
      this._completedCommands = new List<Command>();
      Thread.EndCriticalRegion();
      return completedCommands;
    }

    public void AddCommandWithFeedBack(Command cmd)
    {
      this._modified = true;
      Thread.BeginCriticalRegion();
      this._commandsWithFeedBack.Add(cmd);
      Thread.EndCriticalRegion();
    }

    public List<Command> GetAndClearCommandWithFeedBack()
    {
      Thread.BeginCriticalRegion();
      List<Command> commandsWithFeedBack = this._commandsWithFeedBack;
      this._commandsWithFeedBack = new List<Command>();
      Thread.EndCriticalRegion();
      return commandsWithFeedBack;
    }

    public bool Modified
    {
      get => this._modified;
      set => this._modified = value;
    }

    public bool AutoLoad
    {
      get => this._autoLoad;
      set => this._autoLoad = value;
    }
  }
}
