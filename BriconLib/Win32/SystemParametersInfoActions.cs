// Decompiled with JetBrains decompiler
// Type: BriconLib.Win32.SystemParametersInfoActions
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

namespace BriconLib.Win32
{
  public enum SystemParametersInfoActions : uint
  {
    GetBeep = 1,
    SetBeep = 2,
    GetMouse = 3,
    SetMouse = 4,
    GetBorder = 5,
    SetBorder = 6,
    GetKeyboardSpeed = 10, // 0x0000000A
    SetKeyboardSpeed = 11, // 0x0000000B
    LangDriver = 12, // 0x0000000C
    IconHorizontalSpacing = 13, // 0x0000000D
    GetScreenSaveTimeout = 14, // 0x0000000E
    SetScreenSaveTimeout = 15, // 0x0000000F
    GetScreenSaveActive = 16, // 0x00000010
    SetScreenSaveActive = 17, // 0x00000011
    GetGridGranularity = 18, // 0x00000012
    SetGridGranularity = 19, // 0x00000013
    SetDeskWallPaper = 20, // 0x00000014
    SetDeskPattern = 21, // 0x00000015
    GetKeyboardDelay = 22, // 0x00000016
    SetKeyboardDelay = 23, // 0x00000017
    IconVerticalSpacing = 24, // 0x00000018
    GetIconTitleWrap = 25, // 0x00000019
    SetIconTitleWrap = 26, // 0x0000001A
    GetMenuDropAlignment = 27, // 0x0000001B
    SetMenuDropAlignment = 28, // 0x0000001C
    SetDoubleClkWidth = 29, // 0x0000001D
    SetDoubleClkHeight = 30, // 0x0000001E
    GetIconTitleLogFont = 31, // 0x0000001F
    SetDoubleClickTime = 32, // 0x00000020
    SetMouseButtonSwap = 33, // 0x00000021
    SetIconTitleLogFont = 34, // 0x00000022
    GetFastTaskSwitch = 35, // 0x00000023
    SetFastTaskSwitch = 36, // 0x00000024
    SetDragFullWindows = 37, // 0x00000025
    GetDragFullWindows = 38, // 0x00000026
    GetNonClientMetrics = 41, // 0x00000029
    SetNonClientMetrics = 42, // 0x0000002A
    GetMinimizedMetrics = 43, // 0x0000002B
    SetMinimizedMetrics = 44, // 0x0000002C
    GetIconMetrics = 45, // 0x0000002D
    SetIconMetrics = 46, // 0x0000002E
    SetWorkArea = 47, // 0x0000002F
    GetWorkArea = 48, // 0x00000030
    SetPenWindows = 49, // 0x00000031
    GetFilterKeys = 50, // 0x00000032
    SetFilterKeys = 51, // 0x00000033
    GetToggleKeys = 52, // 0x00000034
    SetToggleKeys = 53, // 0x00000035
    GetMouseKeys = 54, // 0x00000036
    SetMouseKeys = 55, // 0x00000037
    GetShowSounds = 56, // 0x00000038
    SetShowSounds = 57, // 0x00000039
    GetStickyKeys = 58, // 0x0000003A
    SetStickyKeys = 59, // 0x0000003B
    GetAccessTimeout = 60, // 0x0000003C
    SetAccessTimeout = 61, // 0x0000003D
    GetSerialKeys = 62, // 0x0000003E
    SetSerialKeys = 63, // 0x0000003F
    GetSoundsEntry = 64, // 0x00000040
    SetSoundsEntry = 65, // 0x00000041
    GetHighContrast = 66, // 0x00000042
    SetHighContrast = 67, // 0x00000043
    GetKeyboardPref = 68, // 0x00000044
    SetKeyboardPref = 69, // 0x00000045
    GetScreenReader = 70, // 0x00000046
    SetScreenReader = 71, // 0x00000047
    GetAnimation = 72, // 0x00000048
    SetAnimation = 73, // 0x00000049
    GetFontSmoothing = 74, // 0x0000004A
    SetFontSmoothing = 75, // 0x0000004B
    SetDragWidth = 76, // 0x0000004C
    SetDragHeight = 77, // 0x0000004D
    SetHandHeld = 78, // 0x0000004E
    GetLowPowerTimeout = 79, // 0x0000004F
    GetPowerOffTimeout = 80, // 0x00000050
    SetLowPowerTimeout = 81, // 0x00000051
    SetPowerOffTimeout = 82, // 0x00000052
    GetLowPowerActive = 83, // 0x00000053
    GetPowerOffActive = 84, // 0x00000054
    SetLowPowerActive = 85, // 0x00000055
    SetPowerOffActive = 86, // 0x00000056
    SetCursors = 87, // 0x00000057
    SetIcons = 88, // 0x00000058
    GetDefaultInputLang = 89, // 0x00000059
    SetDefaultInputLang = 90, // 0x0000005A
    SetLangToggle = 91, // 0x0000005B
    GetWindwosExtension = 92, // 0x0000005C
    SetMouseTrails = 93, // 0x0000005D
    GetMouseTrails = 94, // 0x0000005E
    ScreenSaverRunning = 97, // 0x00000061
    GetMouseHoverTime = 102, // 0x00000066
  }
}
