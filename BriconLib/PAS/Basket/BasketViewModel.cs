// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.Basket.BasketViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Annotations;
using BriconLib.Basket;
using BriconLib.Data;
using BriconLib.PAS.Basket.CommandHandling;
using BriconLib.PAS.Basket.Commands;
using BriconLib.PAS.Basket.PAS;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using BriconLib.Properties;
using CoreLib.Helpers;
using MultiLang;
using PAS.Bce.Basket;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BriconLib.PAS.Basket
{
  public class BasketViewModel : IDisposable, INotifyPropertyChanged
  {
    private readonly BasketCommunicationLoop _basketCommunicationLoop = new BasketCommunicationLoop();
    private readonly GetFlightHandling _getFlightHandling;
    private readonly StartBasketFancierHandling _startBasketFancierHandling;
    private readonly FinishBasketFancierHandling _finishBasketFancierHandling;
    private readonly BasketPigeonHandling _basketPigeonHandling;
    private readonly CancelPigeonHandling _cancelPigeonHandling;
    private readonly EmergencyLinkHandling _emergencyLinkHandling;
    public BasketWindow BasketWindow;

    public bool ShowDebugMessage { get; set; } = true;

    public ObservableCollection<ListBoxItem> Log { get; set; } = new ObservableCollection<ListBoxItem>();

    public ObservableCollection<BasketPigeonHandling.Model> Pigeons { get; set; } = new ObservableCollection<BasketPigeonHandling.Model>();

    public BasketContext BasketContext { get; }

    public int TotalFanciers => BCEDatabase.DataSet.Adressen.Count;

    public int TotalPigeons => BCEDatabase.DataSet.Pigeons.Count;

    public BasketViewModel(BasketContext basketContext)
    {
      this.BasketContext = basketContext;
      this.BasketContext.BasketContextChanged = new Action(this.OnBasketContextChanged);
      this._basketCommunicationLoop.Start(new Func<Command, Response>(this.OnCommandReceived), false, false);
      this._getFlightHandling = new GetFlightHandling(this.BasketContext, new Action(this.OnFlightStarted));
      this._startBasketFancierHandling = new StartBasketFancierHandling(this.BasketContext, new Func<string, ApiResponseModel>(this.OnBasketFancierStarted));
      this._finishBasketFancierHandling = new FinishBasketFancierHandling(this.BasketContext, new Func<ApiResponseModel>(this.OnBasketFancierFinished));
      this._basketPigeonHandling = new BasketPigeonHandling(this.BasketContext, new Action<BasketPigeonHandling.Model>(this.OnBasketPigeon));
      this._emergencyLinkHandling = new EmergencyLinkHandling(this.BasketContext, new Func<CreateRingModel, ApiResponseModel>(this.OnEmergencyLink));
      this._cancelPigeonHandling = new CancelPigeonHandling(this.BasketContext, new Action<CancelPigeonHandling.Model>(this.OnCancelPigeon));
      this.LoadState();
    }

    private Response OnCommandReceived(Command command)
    {
      this.AddToLog(command.ToString());
      Response response;
      switch (command.CMD)
      {
        case Command.CommandType.GetFlight:
          response = this._getFlightHandling.Handle(command as GetFlightCommand);
          break;
        case Command.CommandType.StartBasketFancier:
          response = this._startBasketFancierHandling.Handle(command as StartBasketFancierCommand);
          break;
        case Command.CommandType.BasketPigeon:
          response = this._basketPigeonHandling.Handle(command as BasketPigeonCommand);
          break;
        case Command.CommandType.FinishBasketFancier:
          response = this._finishBasketFancierHandling.Handle(command as FinishBasketFancierCommand);
          break;
        case Command.CommandType.EmergencyLink:
          response = this._emergencyLinkHandling.Handle(command as EmergencyLinkCommand);
          break;
        case Command.CommandType.CancelPigeon:
          response = this._cancelPigeonHandling.Handle(command as CancelPigeonCommand);
          break;
        default:
          throw new InvalidOperationException(string.Format(ml.ml_string(1364, "Command unknown: {0}"), (object) command.CMD));
      }
      this.AddToLog(response.ToString());
      return response;
    }

    public void Dispose() => this._basketCommunicationLoop.Dispose();

    private void OnBasketContextChanged() => this.OnPropertyChanged("BasketContext");

    private void OnFlightStarted()
    {
      this.AddToLog(string.Format(ml.ml_string(1365, "Inkorfsessie voor wedstrijd gestart door slimme antenne")), ApiResponseModel.LogType.Info);
      this.AddToLog(string.Format(ml.ml_string(1366, "Zie antenne voor verdere instructies")), ApiResponseModel.LogType.Info);
    }

    private ApiResponseModel OnBasketFancierStarted(string fancierLicense)
    {
      this.AddToLog(string.Format(ml.ml_string(1367, "Inkorfsessie van '{0}' gestart"), (object) this.BasketContext.ActiveFancierName), ApiResponseModel.LogType.Info);
      this.ClearState();
      if (fancierLicense == this.BasketContext.ActiveFancierLicense && this.Pigeons.Count > 0)
      {
        this.AddToLog("Same fancier, pigeons are from state instead of PAS");
        return new ApiResponseModel() { Success = true };
      }
      GetBasketParameters parameters = new GetBasketParameters()
      {
        ClubCode = this.BasketContext.ClubCode,
        FancierLicense = fancierLicense,
        RaceCode = this.BasketContext.FlightCode,
        CountryId = Settings.Default.Country
      };
      this.AddToLog("Online: PasBasketDataLoader.Load started");
      GetBasketModel response = GetBasketService.Get(parameters);
      this.BasketWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        this.Pigeons.Clear();
        foreach (GetBasketModel.Pigeon pigeon in response.Pigeons)
          this.Pigeons.Add(new BasketPigeonHandling.Model()
          {
            BasketDateTime = pigeon.BasketDateTime,
            Basket = pigeon.Basket,
            Chip = pigeon.Chip,
            DesignatedInt = pigeon.Designated,
            Female = pigeon.Female,
            Ring = pigeon.Ring,
            CancelDateTime = pigeon.CancelDateTime
          });
        this.CorrectNumbers();
        this.BasketContext.BasketContextChanged();
      }));
      if (response.Success)
        this.AddToLog("Online: PasBasketDataLoader.Load: OK");
      else
        this.AddToLog("Online: PasBasketDataLoader.Load: ERROR");
      this.AddToLog((ApiResponseModel) response);
      return (ApiResponseModel) response;
    }

    private ApiResponseModel OnBasketFancierFinished()
    {
      List<BasketPigeonHandling.Model> toDelete = new List<BasketPigeonHandling.Model>();
      if (this.BasketContext.FancierAgreed)
      {
        toDelete = this.Pigeons.Where<BasketPigeonHandling.Model>((Func<BasketPigeonHandling.Model, bool>) (p => p.DesignatedInt.HasValue && !p.BasketDateTime.HasValue)).ToList<BasketPigeonHandling.Model>();
        this.AddToLog(string.Format(ml.ml_string(1372, "Liefhebber akkoord: Wissen {0} voorbenoemde die niet ingekorfd zijn"), (object) toDelete.Count), ApiResponseModel.LogType.Info);
      }
      this.BasketWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        foreach (BasketPigeonHandling.Model model in toDelete)
          this.Pigeons.Remove(model);
        this.CorrectNumbers();
      }));
      Thread.Sleep(1000);
      this.AddToLog(string.Format(ml.ml_string(1373, "Inkorfsessie van '{0}' voltooid, versturen naar PAS-Live"), (object) this.BasketContext.ActiveFancierName), ApiResponseModel.LogType.Info);
      PostBasketModel postBasketModel = new PostBasketModel();
      postBasketModel.ClubCode = this.BasketContext.ClubCode;
      postBasketModel.FancierLicense = this.BasketContext.ActiveFancierLicense;
      postBasketModel.RaceCode = this.BasketContext.FlightCode;
      postBasketModel.CountryId = Settings.Default.Country;
      DateTime? nullable = this.BasketContext.BasketInternalDateTime;
      postBasketModel.BasketInternalDateTime = nullable ?? DateTime.MinValue;
      nullable = this.BasketContext.BasketExternalDateTime;
      postBasketModel.BasketExternalDateTime = nullable ?? DateTime.MinValue;
      nullable = this.BasketContext.BasketStartServerDateTime;
      postBasketModel.BasketStartServerDateTime = nullable ?? DateTime.MinValue;
      postBasketModel.MasterVersion = this.BasketContext.MasterVersion;
      postBasketModel.MasterSerial = this.BasketContext.MasterSerial;
      postBasketModel.XtremeSerial = this.BasketContext.XtremeSerial;
      postBasketModel.FancierAgreed = this.BasketContext.FancierAgreed;
      postBasketModel.BasketStopServerDateTime = NtpClient.GetNetworkTimeCached();
      postBasketModel.BaskettedPigeons = this.Pigeons.Select<BasketPigeonHandling.Model, PostBasketModel.Pigeon>((Func<BasketPigeonHandling.Model, PostBasketModel.Pigeon>) (p => new PostBasketModel.Pigeon()
      {
        BasketDateTime = p.BasketDateTime,
        CancelDateTime = p.CancelDateTime,
        Chip = p.Chip,
        Code = p.Code,
        Female = p.Female,
        Designated = p.DesignatedInt,
        Basket = p.Basket,
        Ring = p.Ring
      })).ToList<PostBasketModel.Pigeon>();
      PostBasketModel model1 = postBasketModel;
      if (model1.BasketInternalDateTime == DateTime.MinValue || model1.BasketExternalDateTime == DateTime.MinValue || (model1.BasketStartServerDateTime == DateTime.MinValue || model1.BasketStopServerDateTime == DateTime.MinValue) || (string.IsNullOrWhiteSpace(this.BasketContext.ClubCode) || string.IsNullOrWhiteSpace(this.BasketContext.FlightCode) || string.IsNullOrWhiteSpace(this.BasketContext.ActiveFancierLicense)))
      {
        ApiResponseModel response = new ApiResponseModel()
        {
          Success = false,
          ShortErrorMessage = ml.ml_string(1374, "Error in BCE")
        };
        response.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          LogType = ApiResponseModel.LogType.FatalError,
          Message = ml.ml_string(1375, "Not all data present, can't send to the cloud")
        });
        response.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          LogType = ApiResponseModel.LogType.FatalError,
          Message = string.Format("Data : {0} {1} {2} {3}", (object) model1.BasketInternalDateTime, (object) model1.BasketExternalDateTime, (object) model1.BasketStopServerDateTime, (object) model1.BasketStartServerDateTime) + this.BasketContext.ClubCode + " " + this.BasketContext.FlightCode + " " + this.BasketContext.ActiveFancierLicense
        });
        this.AddToLog(response);
        return response;
      }
      this.AddToLog(string.Format("Online: PostBasketService with {0} pigeons", (object) model1.BaskettedPigeons.Count));
      ApiResponseModel response1 = PostBasketService.Save(model1);
      if (response1.Success)
      {
        this.AddToLog("Online: PostBasketService: OK");
        this.BasketContext.ActiveFancierLicense = (string) null;
        this.BasketContext.ActiveFancierName = (string) null;
        this.BasketContext.BasketContextChanged();
        this.ClearState();
        this.BasketWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() => this.Pigeons.Clear()));
      }
      else
        this.AddToLog("Online: PostBasketService: ERROR");
      this.AddToLog(response1);
      return response1;
    }

    private void CorrectNumbers()
    {
      int num1 = 0;
      foreach (BasketPigeonHandling.Model model in this.Pigeons.OrderBy<BasketPigeonHandling.Model, DateTime?>((Func<BasketPigeonHandling.Model, DateTime?>) (p => p.BasketDateTime)).Where<BasketPigeonHandling.Model>((Func<BasketPigeonHandling.Model, bool>) (p =>
      {
        if (!p.BasketDateTime.HasValue)
          return false;
        DateTime? basketDateTime = p.BasketDateTime;
        DateTime dateTime = p.CancelDateTime ?? DateTime.MinValue;
        return basketDateTime.HasValue && basketDateTime.GetValueOrDefault() > dateTime;
      })))
        model.Nbr = (++num1).ToString();
      this.BasketContext.BasketCount = num1;
      int num2 = 1;
      this.BasketContext.MaxDesignated = 0;
      foreach (BasketPigeonHandling.Model model in (IEnumerable<BasketPigeonHandling.Model>) this.Pigeons.OrderBy<BasketPigeonHandling.Model, int?>((Func<BasketPigeonHandling.Model, int?>) (p => p.DesignatedInt)).ThenBy<BasketPigeonHandling.Model, DateTime?>((Func<BasketPigeonHandling.Model, DateTime?>) (p => p.BasketDateTime)))
      {
        int? designatedInt = model.DesignatedInt;
        if (designatedInt.HasValue)
        {
          model.DesignatedInt = new int?(num2++);
          BasketContext basketContext = this.BasketContext;
          designatedInt = model.DesignatedInt;
          int num3 = designatedInt.Value;
          basketContext.MaxDesignated = num3;
        }
      }
      List<BasketPigeonHandling.Model> list = this.Pigeons.ToList<BasketPigeonHandling.Model>();
      this.Pigeons.Clear();
      foreach (BasketPigeonHandling.Model model in list)
        this.Pigeons.Add(model);
      this.OnBasketContextChanged();
    }

    private void OnBasketPigeon(BasketPigeonHandling.Model model)
    {
      this.AddToLog(string.Format(ml.ml_string(1376, "Duif {0} ingekorfd "), (object) model.Ring), ApiResponseModel.LogType.Info);
      this.BasketWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        BasketPigeonHandling.Model model1 = this.Pigeons.LastOrDefault<BasketPigeonHandling.Model>((Func<BasketPigeonHandling.Model, bool>) (m => m.Chip == model.Chip));
        if (model1 != null)
        {
          DateTime? nullable = model1.CancelDateTime;
          int? designatedInt;
          if (!nullable.HasValue)
          {
            designatedInt = model1.DesignatedInt;
            if (designatedInt.HasValue)
            {
              nullable = model1.BasketDateTime;
              if (nullable.HasValue)
                goto label_7;
            }
            else
              goto label_7;
          }
          designatedInt = model1.DesignatedInt;
          if (!designatedInt.HasValue)
            model1.DesignatedInt = model.DesignatedInt;
          model1.BasketDateTime = model.BasketDateTime;
          ++this.BasketContext.BasketCount;
          this.BasketContext.BasketContextChanged();
label_7:
          model1.Nbr = model.Nbr;
          model1.Code = model.Code;
        }
        else
        {
          this.Pigeons.Add(model);
          ++this.BasketContext.BasketCount;
          this.BasketContext.BasketContextChanged();
        }
        this.CorrectNumbers();
        this.SaveState();
      }));
    }

    private void OnCancelPigeon(CancelPigeonHandling.Model model)
    {
      BasketPigeonHandling.Model pigeon = this.Pigeons.LastOrDefault<BasketPigeonHandling.Model>((Func<BasketPigeonHandling.Model, bool>) (m => m.Chip == model.Chip));
      if (pigeon != null && pigeon.BasketDateTime.HasValue)
      {
        this.AddToLog(string.Format(ml.ml_string(1377, "Duif met chip {0} geannulleerd "), (object) model.Chip), ApiResponseModel.LogType.Warning);
        this.BasketWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
        {
          pigeon.CancelDateTime = new DateTime?(model.CancelDateTime);
          pigeon.Nbr = "";
          pigeon.DesignatedInt = new int?();
          --this.BasketContext.BasketCount;
          this.BasketContext.BasketContextChanged();
          this.CorrectNumbers();
          this.SaveState();
        }));
      }
      else
        this.AddToLog(string.Format(ml.ml_string(1378, "Geen duif met chip {0} gevonden om te annuleren"), (object) model.Chip), ApiResponseModel.LogType.Error);
    }

    private ApiResponseModel OnEmergencyLink(CreateRingModel model)
    {
      this.AddToLog(string.Format(ml.ml_string(1379, "Duif met chip {0} herkoppelen aan {1}"), (object) model.Ring, (object) model.ChipCode), ApiResponseModel.LogType.Warning);
      if (this.Pigeons.FirstOrDefault<BasketPigeonHandling.Model>((Func<BasketPigeonHandling.Model, bool>) (p => p.Ring == model.Ring)) != null)
      {
        string str = string.Format(ml.ml_string(1380, "Ring {0} is reeds ingekorfd, deze kan niet herkoppeld worden"), (object) model.Ring);
        ApiResponseModel response = new ApiResponseModel()
        {
          Success = false
        };
        response.LogMessages.Add(new ApiResponseModel.LogMessage()
        {
          LogType = ApiResponseModel.LogType.Error,
          Message = str
        });
        this.AddToLog(response);
        return response;
      }
      this.AddToLog("Online: OnEmergencyLink");
      ApiResponseModel response1 = CreateRingService.Save(model);
      if (response1.Success)
        this.AddToLog("Online: OnEmergencyLink: OK");
      else
        this.AddToLog("Online: OnEmergencyLink: ERROR");
      this.AddToLog(response1);
      return response1;
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }

    private void LoadState()
    {
      if (!File.Exists("basketstate.txt"))
        return;
      string[] strArray1 = File.ReadAllLines("basketstate.txt");
      if (strArray1.Length == 0 || !strArray1[0].StartsWith("V4"))
        return;
      foreach (string str in strArray1)
      {
        char[] chArray = new char[1]{ '|' };
        string[] strArray2 = str.Split(chArray);
        if (strArray2[0].StartsWith("V4"))
        {
          this.BasketContext.BasketCount = Convert.ToInt32(strArray2[1]);
          this.BasketContext.ClubCode = strArray2[2];
          this.BasketContext.FlightCode = strArray2[3];
          this.BasketContext.ActiveFancierLicense = strArray2[4];
          this.BasketContext.ActiveFancierName = strArray2[5];
          this.BasketContext.BasketInternalDateTime = string.IsNullOrWhiteSpace(strArray2[6]) ? new DateTime?() : new DateTime?(Convert.ToDateTime(strArray2[6], (IFormatProvider) CultureInfo.InvariantCulture));
          this.BasketContext.BasketExternalDateTime = string.IsNullOrWhiteSpace(strArray2[7]) ? new DateTime?() : new DateTime?(Convert.ToDateTime(strArray2[7], (IFormatProvider) CultureInfo.InvariantCulture));
          this.BasketContext.BasketStartServerDateTime = string.IsNullOrWhiteSpace(strArray2[8]) ? new DateTime?() : new DateTime?(Convert.ToDateTime(strArray2[8], (IFormatProvider) CultureInfo.InvariantCulture));
          this.BasketContext.MasterSerial = strArray2[9];
          this.BasketContext.MasterVersion = strArray2[10];
          this.BasketContext.XtremeSerial = strArray2[11];
        }
        else
          this.Pigeons.Add(new BasketPigeonHandling.Model()
          {
            Basket = strArray2[0],
            BasketDateTime = string.IsNullOrWhiteSpace(strArray2[1]) ? new DateTime?() : new DateTime?(Convert.ToDateTime(strArray2[1], (IFormatProvider) CultureInfo.InvariantCulture)),
            Chip = strArray2[2],
            Code = strArray2[3],
            DesignatedInt = string.IsNullOrWhiteSpace(strArray2[4]) ? new int?() : new int?(Convert.ToInt32(strArray2[4])),
            Nbr = strArray2[5],
            Ring = strArray2[6],
            Female = string.IsNullOrWhiteSpace(strArray2[7]) ? new bool?() : new bool?(Convert.ToBoolean(strArray2[7])),
            CancelDateTime = string.IsNullOrWhiteSpace(strArray2[8]) ? new DateTime?() : new DateTime?(Convert.ToDateTime(strArray2[8], (IFormatProvider) CultureInfo.InvariantCulture))
          });
      }
    }

    private void SaveState()
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = stringBuilder1;
      object[] objArray = new object[12]
      {
        (object) "V4",
        (object) this.BasketContext.BasketCount,
        (object) this.BasketContext.ClubCode,
        (object) this.BasketContext.FlightCode,
        (object) this.BasketContext.ActiveFancierLicense,
        (object) this.BasketContext.ActiveFancierName,
        null,
        null,
        null,
        null,
        null,
        null
      };
      DateTime? nullable = this.BasketContext.BasketInternalDateTime;
      ref DateTime? local1 = ref nullable;
      DateTime valueOrDefault;
      string str1;
      if (!local1.HasValue)
      {
        str1 = (string) null;
      }
      else
      {
        valueOrDefault = local1.GetValueOrDefault();
        str1 = valueOrDefault.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      objArray[6] = (object) str1;
      nullable = this.BasketContext.BasketExternalDateTime;
      ref DateTime? local2 = ref nullable;
      string str2;
      if (!local2.HasValue)
      {
        str2 = (string) null;
      }
      else
      {
        valueOrDefault = local2.GetValueOrDefault();
        str2 = valueOrDefault.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      objArray[7] = (object) str2;
      nullable = this.BasketContext.BasketStartServerDateTime;
      ref DateTime? local3 = ref nullable;
      string str3;
      if (!local3.HasValue)
      {
        str3 = (string) null;
      }
      else
      {
        valueOrDefault = local3.GetValueOrDefault();
        str3 = valueOrDefault.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      }
      objArray[8] = (object) str3;
      objArray[9] = (object) this.BasketContext.MasterSerial;
      objArray[10] = (object) this.BasketContext.MasterVersion;
      objArray[11] = (object) this.BasketContext.XtremeSerial;
      string str4 = string.Join("|", objArray);
      stringBuilder2.AppendLine(str4);
      foreach (BasketPigeonHandling.Model pigeon in (Collection<BasketPigeonHandling.Model>) this.Pigeons)
      {
        StringBuilder stringBuilder3 = stringBuilder1;
        string[] strArray = new string[9];
        strArray[0] = pigeon.Basket;
        nullable = pigeon.BasketDateTime;
        ref DateTime? local4 = ref nullable;
        string str5;
        if (!local4.HasValue)
        {
          str5 = (string) null;
        }
        else
        {
          valueOrDefault = local4.GetValueOrDefault();
          str5 = valueOrDefault.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        strArray[1] = str5;
        strArray[2] = pigeon.Chip;
        strArray[3] = pigeon.Code;
        strArray[4] = pigeon.DesignatedInt.ToString();
        strArray[5] = pigeon.Nbr;
        strArray[6] = pigeon.Ring;
        strArray[7] = pigeon.Female.ToString();
        nullable = pigeon.CancelDateTime;
        ref DateTime? local5 = ref nullable;
        string str6;
        if (!local5.HasValue)
        {
          str6 = (string) null;
        }
        else
        {
          valueOrDefault = local5.GetValueOrDefault();
          str6 = valueOrDefault.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        }
        strArray[8] = str6;
        string str7 = string.Join("|", strArray);
        stringBuilder3.AppendLine(str7);
      }
      File.WriteAllText("basketstate.txt", stringBuilder1.ToString());
    }

    private void AddToLog(string text, ApiResponseModel.LogType logType = ApiResponseModel.LogType.Debug) => LogWindowHelper.AddToLog((Window) this.BasketWindow, this.BasketWindow.ListBoxLog, this.Log, text, logType, this.ShowDebugMessage);

    private void AddToLog(ApiResponseModel response) => LogWindowHelper.AddToLog((Window) this.BasketWindow, this.BasketWindow.ListBoxLog, this.Log, response, this.ShowDebugMessage);

    private void ClearState() => File.WriteAllText("basketstate.txt", "");
  }
}
