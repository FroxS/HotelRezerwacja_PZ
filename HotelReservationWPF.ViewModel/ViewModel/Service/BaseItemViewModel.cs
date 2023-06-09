using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelReservation.Core.Exeptions;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

namespace HotelReservationWPF.ViewModel.Service
{
    public abstract class BaseItemViewModel<Entity> : BaseViewModel
    {
        #region Private properties

        protected readonly IServiceProvider _service;
        protected string _title = "Pokój";

        #endregion

        #region Public properties

        public Entity Item { get; }

        public string Title
        {
            get => _title;
            set
            {
                _title= value;
                OnPropertyChanged(nameof(Title));
            }
        }

        #endregion

        #region Commands

        public ICommand SaveCommand { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseItemViewModel(Entity item, IServiceProvider service)
        {
            Item = item;
            _service = service;
            SaveCommand = new AsyncRelayCommand((o) => SaveAsync(), (o) => { OnSaveExpetion(o); });
            LoadAsync();
        }

        #endregion

        #region Public methods

        public virtual async Task LoadAsync()
        {
            await Task.Delay(0);
        }

        public abstract Task SaveAsync();

        #endregion

        #region Private methods

        protected bool CanEditRows() => _service.GetService<IHotelReservationApp>().CanEditRows();
        protected string GetApplicationPath() => _service.GetService<IHotelReservationApp>().GetApplicationPath();

        protected virtual string[] GetImagesDialog()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (op.ShowDialog() == true)
            {
                return op.FileNames;
            }
            return null;
        }

        protected void ShowMessage(string message)
        {
            _service.GetService<IHotelReservationApp>().DialogService.ShowAlert(message);
        }

        protected virtual void OnSaveExpetion(Exception exception)
        {
            try
            {
                throw exception;
            }
            catch (ErrorModelExeption ex)
            {
                foreach(var message in ex.GetData())
                {
                    ShowMessage($"{message.Key}: {message.Value}");
                }
                
            }
            catch (System.Exception ex)
            {
                ShowMessage("Bład podczas zapisywania");
            }


        }

        #endregion
    }
}