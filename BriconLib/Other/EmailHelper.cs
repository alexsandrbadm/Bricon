// Decompiled with JetBrains decompiler
// Type: BriconLib.Other.EmailHelper
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Properties;
using MultiLang;
using System;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace BriconLib.Other
{
  internal class EmailHelper
  {
    public static SmtpClient GetSmtpClient()
    {
      SmtpClient smtpClient = new SmtpClient(Settings.Default.OutMailServer, Convert.ToInt32(Settings.Default.EmailServerPort));
      smtpClient.EnableSsl = Settings.Default.EmailUseSSL;
      if (!string.IsNullOrWhiteSpace(Settings.Default.EmailUser) && !string.IsNullOrWhiteSpace(Settings.Default.EmailPWD))
      {
        NetworkCredential networkCredential = new NetworkCredential(Settings.Default.EmailUser, Settings.Default.EmailPWD);
        smtpClient.Credentials = (ICredentialsByHost) networkCredential;
      }
      return smtpClient;
    }

    public static MailAddress GetFromAddress() => new MailAddress(Settings.Default.EmailFromAddress, Settings.Default.EmailFromName);

    public static void SendTestmail()
    {
      try
      {
        if (Settings.Default.EmailAddress == "")
        {
          int num1 = (int) MessageBox.Show(ml.ml_string(1356, "Please fill in the emailaddress to send the notifications to"));
        }
        else
        {
          EmailHelper.GetSmtpClient().Send(new MailMessage(EmailHelper.GetFromAddress(), new MailAddress(Settings.Default.EmailAddress))
          {
            Subject = ml.ml_string(1357, "Test message from Bricon software")
          });
          int num2 = (int) MessageBox.Show(ml.ml_string(1358, "Message sended to ") + Settings.Default.EmailAddress);
        }
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(ex.ToString());
      }
    }
  }
}
