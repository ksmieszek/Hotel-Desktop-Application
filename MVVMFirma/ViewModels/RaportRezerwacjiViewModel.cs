using MVVMFirma.Models.Entities;
using MVVMFirma.Helper;
using MVVMFirma.Models.BusinessLogic;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class RaportRezerwacjiViewModel : WorkspaceViewModel
    {
        #region Konstruktor
        public RaportRezerwacjiViewModel()
        {
            base.DisplayName = "Raport rezerwacji";
            hotelEntities = new HotelEntities();
            DataRozpoczecia = DateTime.Now.AddDays(-30);
            DataZakonczenia = DateTime.Now;
        }
        #endregion
        #region FieldsAndProperties
        private HotelEntities hotelEntities;
        private DateTime _DataRozpoczecia;
        public DateTime DataRozpoczecia
        {
            get
            {
                return _DataRozpoczecia;
            }
            set
            {
                if (value != _DataRozpoczecia)
                {
                    _DataRozpoczecia = value;
                    OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }
        private DateTime _DataZakonczenia;
        public DateTime DataZakonczenia
        {
            get
            {
                return _DataZakonczenia;
            }
            set
            {
                if (value != _DataZakonczenia)
                {
                    _DataZakonczenia = value;
                    OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }
        private int _IdPokoju;
        public int IdPokoju
        {
            get
            {
                return _IdPokoju;
            }
            set
            {
                if (value != _IdPokoju)
                {
                    _IdPokoju = value;
                    OnPropertyChanged(() => IdPokoju);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> PokojeComboBoxItems
        {
            get
            {
                return new RezerwacjaB(hotelEntities).GetPokojeComboBoxItems();
            }
        }
        private decimal? _Utarg;
        public decimal? Utarg
        {
            get
            {
                return _Utarg;
            }
            set
            {
                if (value != _Utarg)
                {
                    _Utarg = value;
                    OnPropertyChanged(() => Utarg);
                }
            }
        }
        #endregion
        #region Commands
        private BaseCommand _ObliczCommand;
        public ICommand ObliczCommand
        {
            get
            {
                if (_ObliczCommand == null)
                    _ObliczCommand = new BaseCommand(() => obliczUtargClick());

                return _ObliczCommand;
            }
        }
        #endregion
        #region Helpers
        private void obliczUtargClick()
        {
            Utarg = new UtargB(hotelEntities).UtargOkresPokoj(IdPokoju, DataRozpoczecia, DataZakonczenia);
        }
        #endregion
    }
}
