using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using HotelReservationWPF.ViewModel.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Win32;

namespace HotelReservationWPF.ViewModel.Page
{
    public abstract class BasePageWithItemsViewModel : BasePageViewModel
    {
        #region Private properties

        private ICollectionView _collection;
        protected string _search;
        
        #endregion

        #region Public properties

        public ICollectionView Collection 
        { 
            get => _collection;
            set 
            { 
                _collection = value;
                OnPropertyChanged(nameof(Collection));
            }
        }

        public string Search
        {
            get => _search;
            set
            {
                _search = value;
                Collection.Filter += Filter;
                OnPropertyChanged(nameof(Search));
            }
        }

        #endregion

        #region Commands



        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePageWithItemsViewModel(IServiceProvider service) : base(service)
        {
            
        }

        #endregion

        #region Public methods



        #endregion

        #region Protected methods

        protected virtual bool Filter(object emp) => true;

        protected void RefeshCollection()
        {
            Collection?.Refresh();
        }

        #endregion
    }
}