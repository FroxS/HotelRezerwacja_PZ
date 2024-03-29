﻿using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelReservationWPF.ViewModel.Core
{
    public class RelayCommand<T> : ICommand
    {
        #region Private Properties

        protected readonly Predicate<T> _canExecute;
        protected readonly Action<T> _execute;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action<T>? execute) : this(execute, null)
        {
            _execute = execute;
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }
            _execute = execute;
            _canExecute = canExecute;
        }

        public virtual bool CanExecute(object? parameter) => _canExecute == null || _canExecute((T)parameter);

        public virtual void Execute(object? parameter) => _execute((T)parameter);

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }

    public class RelayCommand : RelayCommand<object>
    {

        public RelayCommand(Action<object> execute, Predicate<object> canExecute) : base(execute, canExecute)
        {
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {

        }
    }

    public class AsyncRelayCommand : ICommand
    {
        #region Private Properties

        private readonly Action<Exception>? _onException;

        private bool _isExecuting;

        private readonly Func<object, Task> _callback;

        #endregion

        #region Public properties

        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        public AsyncRelayCommand(Func<object,Task> callback, Action<Exception>? onException = null)
        {
            _onException = onException;
            _callback = callback;
        }

        #endregion

        #region Private methods

        protected async Task ExecuteAsync(object parameter)
        {
            await _callback(parameter);
        }

        #endregion

        #region Public methods

        public bool CanExecute(object parameter) => !IsExecuting;

        public async void Execute(object parameter)
        {
            IsExecuting = true;
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);
            }

            IsExecuting = false;
        }

        #endregion

    }

    public class AsyncRelayCommand<T> : ICommand
    {
        #region Private Properties

        protected readonly Predicate<T>? _canExecute;

        private readonly Action<Exception>? _onException;

        private bool _isExecuting;

        private readonly Func<T, Task> _callback;

        #endregion

        #region Public properties

        public bool IsExecuting
        {
            get => _isExecuting;
            set
            {
                _isExecuting = value;
                CanExecuteChanged?.Invoke(this, new EventArgs());
            }
        }

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        public AsyncRelayCommand(Func<T, Task> callback, Predicate<T>? canExecute = null, Action<Exception>? onException = null)
        {
            _onException = onException;
            _callback = callback;
        }

        #endregion

        #region Private methods

        protected async Task ExecuteAsync(object parameter)
        {
            if (parameter is T par)
            {
                await _callback(par);
            }
            else
            {
                await _callback(default(T));
            }
        }

        #endregion

        #region Public methods

        public bool CanExecute(object parameter) => !IsExecuting;

        public async void Execute(object parameter)
        {
            IsExecuting = true;

            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception ex)
            {
                _onException?.Invoke(ex);
            }

            IsExecuting = false;
        }

        #endregion

    }
}