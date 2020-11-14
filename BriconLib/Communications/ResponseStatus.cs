// Decompiled with JetBrains decompiler
// Type: BriconLib.Communications.ResponseStatus
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Communications
{
  public enum ResponseStatus
  {
    OK = 0,
    NoFancierData = 1,
    InvalidDataFormat = 2,
    FlightAlreadyBasketed = 3,
    FlightDataNotDeleted = 4,
    NoRecordThatCompliesTheRequest = 5,
    SynchronisationFailed = 6,
    TimerAlreadySynchronised = 7,
    NoPigeonTable = 8,
    UnknownPigeonID = 9,
    PigeonAlreadyBasketed = 10, // 0x0000000A
    ELRingAlreadyPresent = 11, // 0x0000000B
    OutOfRange = 12, // 0x0000000C
    NoTimerDataPresent = 13, // 0x0000000D
    FlightNotBasketed = 14, // 0x0000000E
    InvalidPincode = 15, // 0x0000000F
    SecretCodeNotChanged = 16, // 0x00000010
    UnknownCommand = 17, // 0x00000011
    PigeonAlreadyBasketedAnnulationImpossible = 18, // 0x00000012
    NoVersionData = 19, // 0x00000013
    BasketTimeOverlapped = 20, // 0x00000014
    ChecksumError = 32, // 0x00000020
    NoRingRead = 49, // 0x00000031
    ActualBaudrateNotChanged = 112, // 0x00000070
    SwitchAfterResponceTo9600 = 113, // 0x00000071
    SwitchAfterResponceTo38400 = 114, // 0x00000072
    StorageNotAllowed = 116, // 0x00000074
    IllegalParameters = 126, // 0x0000007E
    IllegalUpdateCommand = 127, // 0x0000007F
    UserAbort = 221, // 0x000000DD
    PCCommStopped = 250, // 0x000000FA
    PCInvalidByteReceived = 251, // 0x000000FB
    PCChecksumError = 252, // 0x000000FC
    PCTimeOut = 253, // 0x000000FD
    PCError = 254, // 0x000000FE
    None = 255, // 0x000000FF
  }
}
