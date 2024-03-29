﻿using HotelReservationWPF.ViewModel.Core;
using System.Windows.Controls;
using System.Windows;
using HotelReservationWPF.ViewModel.Interfaces;

namespace HotelReservationWPF.Controls
{
    public class BasePage : Page, IBasePage
    {
        #region Private Properties

        private object? viewModelObject;

        #endregion

        #region Public Properties

        public object? ViewModelObject
        {
            get => viewModelObject;
            set
            {
                viewModelObject = value;
                DataContext = viewModelObject;
            }
        }

        #endregion

        #region Dependency Properties

        #region Can Resize

        /// <summary>
        /// The resize mode of window
        /// </summary>
        public ResizeMode CanResize
        {
            get => (ResizeMode)GetValue(CanResizeProperty);
            set => SetValue(CanResizeProperty, value);
        }

        /// <summary>
        /// Registers <see cref="CanResizeProperty"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CanResizeProperty =
            DependencyProperty.Register(
                nameof(CanResize),
                typeof(ResizeMode),
                typeof(BasePage),
                new UIPropertyMetadata(
                    default(ResizeMode),
                    null,
                    CurrentPagePropertyChanged)
                );

        #endregion

        #region Window width and height

        /// <summary>
        /// The width of window
        /// </summary>
        public double WinWidth
        {
            get => (double)GetValue(WinWidthProperty);
            set => SetValue(WinWidthProperty, value);
        }

        /// <summary>
        /// The height of window
        /// </summary>
        public double WinHeight
        {
            get => (double)GetValue(WinHeightProperty);
            set => SetValue(WinHeightProperty, value);
        }

        /// <summary>
        /// Registers <see cref="WinHeightProperty"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty WinHeightProperty =
            DependencyProperty.Register(
                nameof(WinHeight),
                typeof(double),
                typeof(BasePage),
                new UIPropertyMetadata(
                    default(double),
                    null,
                    WinHeightPropertyChanged)
                );

        /// <summary>
        /// Registers <see cref="WinWidthProperty"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty WinWidthProperty =
            DependencyProperty.Register(
                nameof(WinWidth),
                typeof(double),
                typeof(BasePage),
                new UIPropertyMetadata(
                    default(double),
                    null,
                    WinWidthPropertyChanged)
                );

        #endregion

        #endregion

        #region Contructors

        public BasePage(object viewModel)
        {
            ViewModelObject = viewModel;
        }

        #endregion

        #region Property Changed Events

        private static object WinWidthPropertyChanged(DependencyObject d, object value)
        {
            if (d is BasePage bp && value is double w)
            {
                Window window = App.Current.MainWindow;
                window.Width = w;

                Rect workArea = SystemParameters.WorkArea;
                window.Left = (workArea.Width - window.Width) / 2 + workArea.Left;
                window.Top = (workArea.Height - window.Height) / 2 + workArea.Top;
            }

            return value;
        }

        private static object WinHeightPropertyChanged(DependencyObject d, object value)
        {
            if (d is BasePage bp && value is double w)
            {
                Window window = App.Current.MainWindow;
                window.Height = w;

                Rect workArea = SystemParameters.WorkArea;
                window.Left = (workArea.Width - window.Width) / 2 + workArea.Left;
                window.Top = (workArea.Height - window.Height) / 2 + workArea.Top;
            }

            return value;
        }


        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="d"></param>
        /// <param name="value"></param>
        private static object CurrentPagePropertyChanged(DependencyObject d, object value)
        {
            if (d is BasePage bp && value is ResizeMode resizeMode)
            {
                App.Current.MainWindow.ResizeMode = resizeMode;
            }

            return value;
        }

        #endregion
    }


    public class BasePage<VM> : BasePage
        where VM : BasePageViewModel
    {

        #region Public Properties

        public VM? ViewModel
        {
            get => ViewModelObject as VM;
            set
            {
                ViewModelObject = value;
            }
        }

        #endregion

        #region Contructors

        public BasePage(VM viewModel) : base(viewModel)
        {

        }

        #endregion
    }
}