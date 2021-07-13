using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public abstract class JedenViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        protected HotelEntities hotelEntities;
        protected T item;
        private BaseCommand _SaveCommand;
        private BaseCommand _CancelCommand;
        #endregion

        #region Constructor
        public JedenViewModel()
            : base()
        {
            hotelEntities = new HotelEntities();
        }
        #endregion

        #region Command
        public ICommand SaveCommand
        {
            get
            {
                if (_SaveCommand == null)
                {
                    _SaveCommand = new BaseCommand(() => saveAndClose());
                }
                return _SaveCommand;
            }
        }
        public ICommand CancelCommand
        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new BaseCommand(() => cancelAndClose());
                }
                return _CancelCommand;
            }
        }
        #endregion

        #region Validation
        public virtual bool IsValid()
        {
            return true;
        }
        #endregion

        #region Helpers
        public abstract void Save();

        private void saveAndClose()
        {
            if (IsValid())
            {
                Save();
                base.OnRequestClose();
            }
            else
            {
                ShowMessageBox("Wpisz prawidłowe dane w formularzu");
            }
        }
        private void cancelAndClose()
        {
            base.OnRequestClose();
        }
        #endregion
    }
}
