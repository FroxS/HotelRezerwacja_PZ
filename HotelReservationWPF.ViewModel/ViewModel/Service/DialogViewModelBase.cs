﻿using System.Windows.Input;
using HotelReservationWPF.ViewModel.Core;
using HotelReservationWPF.ViewModel.Interfaces;

namespace HotelReservationWPF.ViewModel.Service
{
    public abstract class DialogViewModelBase<T> : BaseViewModel
    {
        #region Public properties

        public string Title { get; set; }
        public string Message { get; set; }
        public T DialogResult { get; set; }

        #endregion

        #region Commands

        public abstract ICommand OKCommand { get; protected set; }
        public ICommand ExitCommand { get; protected set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public DialogViewModelBase(string title) : this(title, string.Empty) { }
        public DialogViewModelBase(string title, string message)
        {
            Title = title;
            Message = message;
            ExitCommand = new RelayCommand<IDialogWindow>(o => exit(o));
        }

        #endregion

        #region Private methods

        private void exit(IDialogWindow window)
        {
            window.DialogResult = false;
        }

        #endregion

        #region Public methods

        public void CloseDialogWithResult(IDialogWindow dialog, T result)
        {
            DialogResult = result;
            if (dialog != null)
            {
                dialog.DialogResult = true;
            }
        }

        #endregion
    }
}