using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HotelReservationWPF.ViewModel.Core
{
    public class BaseViewModel : ValidatorBase, INotifyPropertyChanged, INotifyPropertyChanging
    {
        #region Protected properties

        protected bool _isTaskRunning = false;

        #endregion

        #region Public properties

        public event PropertyChangedEventHandler? PropertyChanged = (sender, e) => { };
        public event PropertyChangingEventHandler? PropertyChanging = (sender, e) => { };
        public override bool _CanValidate { get; protected set; } = false;
        public virtual bool IsTaskRunning { get => _isTaskRunning; set { _isTaskRunning = value; OnPropertyChanged(nameof(IsTaskRunning)); } }

        #endregion

        #region Protected methods

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected void OnPropertyChanging([CallerMemberName] string? name = null)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(name));
        }

        protected void NotifyPropChanged(params string[] propsName)
        {
            foreach (string prop in propsName)
            {
                if (string.IsNullOrEmpty(prop)) continue;
                OnPropertyChanged(prop);
            }
        }

        #endregion

    }
}