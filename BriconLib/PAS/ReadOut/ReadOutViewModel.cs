// Decompiled with JetBrains decompiler
// Type: BriconLib.PAS.ReadOut.ReadOutViewModel
// Assembly: BriconLib, Version=2020.5.6.1, Culture=neutral, PublicKeyToken=null
// MVID: BA6F980A-986E-4E86-A846-48EA3AD6DB56
// Assembly location: C:\Bricon\Print Manager\BriconLib.dll

using BriconLib.Annotations;
using BriconLib.Data;
using BriconLib.PAS.Basket;
using BriconLib.PAS.ReadOut.CommandHandling;
using BriconLib.PAS.ReadOut.Commands;
using BriconLib.PAS.ReadOut.PAS;
using BriconLib.PAS.Shared;
using BriconLib.PAS.Shared.Commands;
using BriconLib.Properties;
using MultiLang;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BriconLib.PAS.ReadOut
{
  public class ReadOutViewModel : IDisposable, INotifyPropertyChanged
  {
    private readonly BasketCommunicationLoop _basketCommunicationLoop = new BasketCommunicationLoop();
    private readonly ReadOutHandling _readOutHandling;
    private readonly ReadOutPigeonHandling _readOutPigeonHandling;
    private readonly StartReadOutFancierHandling _startReadOutFancierHandling;
    private readonly FinishReadOutFancierHandling _finishReadOutFancierHandling;
    private readonly bool _readoutIsFinal;
    public ReadOutWindow ReadOutWindow;

    public ObservableCollection<ListBoxItem> Log { get; set; } = new ObservableCollection<ListBoxItem>();

    public BasketContext BasketContext { get; }

    public bool ShowDebugMessage { get; set; } = true;

    public string Title { get; set; }

    public ObservableCollection<ReadOutPigeonHandling.Model> Pigeons { get; set; } = new ObservableCollection<ReadOutPigeonHandling.Model>();

    public int TotalFanciers => BCEDatabase.DataSet.Adressen.Count;

    public int TotalPigeons => BCEDatabase.DataSet.Pigeons.Count;

    public ReadOutViewModel(BasketContext basketContext, bool readoutIsFinal)
    {
      this.BasketContext = basketContext;
      this._readoutIsFinal = readoutIsFinal;
      this.BasketContext.BasketContextChanged = new Action(this.OnBasketContextChanged);
      this._basketCommunicationLoop.Start(new Func<Command, Response>(this.OnCommandReceived), true, !readoutIsFinal);
      this._readOutHandling = new ReadOutHandling(basketContext);
      this._readOutPigeonHandling = new ReadOutPigeonHandling(basketContext, new Action<ReadOutPigeonHandling.Model>(this.OnReadOutPigeon));
      this._startReadOutFancierHandling = new StartReadOutFancierHandling(basketContext, (Func<bool>) (() => true));
      this._finishReadOutFancierHandling = new FinishReadOutFancierHandling(basketContext, new Func<ApiResponseModel>(this.OnReadOutFancierFinished));
      if (!this._readoutIsFinal)
        this.Title = ml.ml_string(1385, "Tussentijds afslaan");
      else
        this.Title = ml.ml_string(1386, "Afslaan");
    }

    private Response OnCommandReceived(Command command)
    {
      this.AddToLog(command.ToString());
      Response response;
      switch (command.CMD)
      {
        case Command.CommandType.StartReadOut:
          response = this._readOutHandling.Handle(command as ReadOutCommand);
          break;
        case Command.CommandType.ReadOutPigeon:
          response = this._readOutPigeonHandling.Handle(command as ReadOutPigeonCommand);
          break;
        case Command.CommandType.StartReadOutFancier:
          response = this._startReadOutFancierHandling.Handle(command as StartReadOutFancierCommand);
          break;
        case Command.CommandType.FinishReadOutFancier:
          response = this._finishReadOutFancierHandling.Handle(command as FinishReadOutFancierCommand);
          break;
        default:
          throw new InvalidOperationException(string.Format(ml.ml_string(1364, "Command unknown: {0}"), (object) command.CMD));
      }
      this.AddToLog(response.ToString());
      return response;
    }

    private void OnReadOutPigeon(ReadOutPigeonHandling.Model model)
    {
      this.AddToLog(string.Format(ml.ml_string(1389, "Duif {0} uitgelezen via slimme antenne"), (object) model.Ring), ApiResponseModel.LogType.Info);
      this.ReadOutWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() =>
      {
        ReadOutPigeonHandling.Model model1 = this.Pigeons.LastOrDefault<ReadOutPigeonHandling.Model>((Func<ReadOutPigeonHandling.Model, bool>) (m => m.Chip == model.Chip));
        if (model1 != null)
        {
          model1.Status = model.Status;
          model1.Nbr = model.Nbr;
          this.OnPropertyChanged("Pigeons");
        }
        else
          this.Pigeons.Add(model);
      }));
    }

    private ApiResponseModel OnReadOutFancierFinished()
    {
      this.AddToLog(string.Format(ml.ml_string(1387, "Alle duiven van '{0}' uitgelezen via slimme antenne, versturen naar PAS-Live"), (object) this.BasketContext.ActiveFancierName), ApiResponseModel.LogType.Info);
      PostReadOutModel postReadOutModel = new PostReadOutModel();
      postReadOutModel.ClubCode = this.BasketContext.ClubCode;
      postReadOutModel.FancierLicense = this.BasketContext.ActiveFancierLicense;
      postReadOutModel.RaceCode = this.BasketContext.FlightCode;
      postReadOutModel.CountryId = Settings.Default.Country;
      DateTime? nullable = this.BasketContext.ReadOutInternalDateTime;
      postReadOutModel.ReadOutInternalDateTime = nullable ?? DateTime.MinValue;
      nullable = this.BasketContext.ReadOutExternalDateTime;
      postReadOutModel.ReadOutExternalDateTime = nullable ?? DateTime.MinValue;
      postReadOutModel.MasterVersion = this.BasketContext.MasterVersion;
      postReadOutModel.MasterSerial = this.BasketContext.MasterSerial;
      postReadOutModel.XtremeSerial = this.BasketContext.XtremeSerial;
      postReadOutModel.ReadOutIsFinal = this._readoutIsFinal;
      postReadOutModel.ClockedPigeons = this.Pigeons.Select<ReadOutPigeonHandling.Model, PostReadOutModel.Pigeon>((Func<ReadOutPigeonHandling.Model, PostReadOutModel.Pigeon>) (p => new PostReadOutModel.Pigeon()
      {
        ClockedTime = p.ReadOutDateTime,
        Chip = p.Chip,
        Ring = p.Ring,
        Female = p.Female,
        Status = p.Status,
        Designated = p.DesignatedInt
      })).ToList<PostReadOutModel.Pigeon>();
      PostReadOutModel model = postReadOutModel;
      if (model.ReadOutInternalDateTime == DateTime.MinValue || model.ReadOutExternalDateTime == DateTime.MinValue || (string.IsNullOrWhiteSpace(this.BasketContext.ClubCode) || string.IsNullOrWhiteSpace(this.BasketContext.FlightCode)) || string.IsNullOrWhiteSpace(this.BasketContext.ActiveFancierLicense))
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
          Message = string.Format("Data : {0} {1} ", (object) model.ReadOutInternalDateTime, (object) model.ReadOutExternalDateTime) + this.BasketContext.ClubCode + " " + this.BasketContext.FlightCode + " " + this.BasketContext.ActiveFancierLicense
        });
        this.AddToLog(response);
        return response;
      }
      this.AddToLog("Online: PasReadOutSaver");
      ApiResponseModel response1 = ReadOutService.Save(model);
      if (response1.Success)
      {
        this.AddToLog("Online: PasReadOutSaver: OK");
        this.BasketContext.ActiveFancierLicense = (string) null;
        this.BasketContext.ActiveFancierName = (string) null;
        this.BasketContext.BasketContextChanged();
        this.ReadOutWindow.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) (() => this.Pigeons.Clear()));
      }
      else
        this.AddToLog("Online: PasReadOutSaver: ERROR");
      this.AddToLog(response1);
      return response1;
    }

    private void AddToLog(string text, ApiResponseModel.LogType logType = ApiResponseModel.LogType.Debug) => LogWindowHelper.AddToLog((Window) this.ReadOutWindow, this.ReadOutWindow.ListBoxLog, this.Log, text, logType, this.ShowDebugMessage);

    private void AddToLog(ApiResponseModel response) => LogWindowHelper.AddToLog((Window) this.ReadOutWindow, this.ReadOutWindow.ListBoxLog, this.Log, response, this.ShowDebugMessage);

    public void Dispose() => this._basketCommunicationLoop.Dispose();

    private void OnBasketContextChanged() => this.OnPropertyChanged("BasketContext");

    public event PropertyChangedEventHandler PropertyChanged;

    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged == null)
        return;
      propertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
    }
  }
}
