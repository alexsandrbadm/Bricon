// Decompiled with JetBrains decompiler
// Type: BriconLib.Sounds.SoundManager
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Media;
using System.Resources;

namespace BriconLib.Sounds
{
  internal class SoundManager
  {
    public List<KeyValuePair<string, string>> GetSounds() => new List<KeyValuePair<string, string>>()
    {
      new KeyValuePair<string, string>("None", "None"),
      new KeyValuePair<string, string>("Beep", "Windows Beep"),
      new KeyValuePair<string, string>("Air_Raid_21secs", "Air Raid 21secs"),
      new KeyValuePair<string, string>("Alarm_Short_Beeps_4secs", "Alarm Short Beeps 4secs"),
      new KeyValuePair<string, string>("Boxing_Bell_1sec", "Boxing Bell 1sec"),
      new KeyValuePair<string, string>("Boxing_Multiple_Bell_3secs", "Boxing Multiple Bell 3secs"),
      new KeyValuePair<string, string>("Buzzer_2secs", "Buzzer 2secs"),
      new KeyValuePair<string, string>("Buzzer_3_Times_2secs", "Buzzer 3 Times 2secs"),
      new KeyValuePair<string, string>("Horn_1sec", "Horn 1sec"),
      new KeyValuePair<string, string>("Whistle_Shrill_1sec", "Whistle Shrill 1sec")
    };

    public void Play(string alarmSound, bool loop)
    {
      if (alarmSound == "None" || string.IsNullOrWhiteSpace(alarmSound))
        return;
      if (alarmSound == "Beep")
      {
        SystemSounds.Beep.Play();
      }
      else
      {
        SoundPlayer soundPlayer = new SoundPlayer((Stream) new ResourceManager("BriconLib.Properties.Resources", typeof (BriconLib.Properties.Resources).Assembly).GetStream(alarmSound, CultureInfo.CurrentUICulture));
        soundPlayer.Play();
        if (!loop)
          return;
        soundPlayer.PlayLooping();
      }
    }

    public void Stop() => new SoundPlayer().Stop();
  }
}
