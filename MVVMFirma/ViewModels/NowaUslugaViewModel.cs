using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowaUslugaViewModel : JedenViewModel<Uslugi>
    {
        #region Fields
        private BaseCommand _ShowRezerwacje;
        private BaseCommand _ShowPosilki;
        #endregion
        #region Constructor
        public NowaUslugaViewModel()
        {
            base.DisplayName = "Usługa";
            item = new Uslugi();
            Messenger.Default.Register<RezerwacjaForAllView>(this, getWybranaRezerwacja);
            Messenger.Default.Register<PosilekForAllView>(this, getWybranyPosilek);
        }
        #endregion
        #region Commands
        public ICommand ShowRezerwacje
        {
            get
            {
                if (_ShowRezerwacje == null)
                    _ShowRezerwacje = new BaseCommand(() => Messenger.Default.Send("RezerwacjeShow"));

                return _ShowRezerwacje;
            }
        }
        public ICommand ShowPosilki
        {
            get
            {
                if (_ShowPosilki == null)
                    _ShowPosilki = new BaseCommand(() => Messenger.Default.Send("PosilkiShow"));

                return _ShowPosilki;
            }
        }
        #endregion
        #region Properties
        public int IdUslugi
        {
            get
            {
                return item.IdUslugi;
            }
            set
            {
                if (item.IdUslugi != value)
                {
                    item.IdUslugi = value;
                    base.OnPropertyChanged(() => IdUslugi);
                }
            }
        }
        public string Kod
        {
            get
            {
                return item.Kod;
            }
            set
            {
                if (item.Kod != value)
                {
                    item.Kod = value;
                    base.OnPropertyChanged(() => Kod);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public int? IdPosilku
        {
            get
            {
                return item.IdPosilku;
            }
            set
            {
                if (item.IdPosilku != value)
                {
                    item.IdPosilku = value;
                    base.OnPropertyChanged(() => IdPosilku);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> PosilkiComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from posilek in hotelEntities.Posilki
                        select new ComboBoxKeyAndValue
                        {
                            Key = posilek.IdPosilku,
                            Value = posilek.IloscPotrawy + "x " + posilek.Potrawy.Nazwa + ", " + posilek.IloscNapoju + "x " + posilek.Napoje.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdRezerwacji
        {
            get
            {
                return item.IdRezerwacji;
            }
            set
            {
                if (item.IdRezerwacji != value)
                {
                    item.IdRezerwacji = value;
                    base.OnPropertyChanged(() => IdRezerwacji);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> RezerwacjeComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from rezerwacja in hotelEntities.Rezerwacje
                        select new ComboBoxKeyAndValue
                        {
                            Key = rezerwacja.IdRezerwacji,
                            Value = "Pokój: " + rezerwacja.Pokoje.NumerPokoju +  " od: " + rezerwacja.DataRozpoczecia + " do: " + rezerwacja.DataZakonczenia
                        }
                    ).ToList().AsQueryable();
            }
        }
        private string _RezerwacjaNumerPokoju;
        public string RezerwacjaNumerPokoju
        {
            get
            {
                return _RezerwacjaNumerPokoju;
            }
            set
            {
                if (_RezerwacjaNumerPokoju != value)
                {
                    _RezerwacjaNumerPokoju = value;
                    base.OnPropertyChanged(() => RezerwacjaNumerPokoju);
                }
            }
        }
        private DateTime? _DataRozpoczecia;
        public DateTime? DataRozpoczecia
        {
            get
            {
                return _DataRozpoczecia;
            }
            set
            {
                if (_DataRozpoczecia != value)
                {
                    _DataRozpoczecia = value;
                    base.OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }
        private DateTime? _DataZakonczenia;
        public DateTime? DataZakonczenia
        {
            get
            {
                return _DataZakonczenia;
            }
            set
            {
                if (_DataZakonczenia != value)
                {
                    _DataZakonczenia = value;
                    base.OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }
        private string _PotrawaNazwa;
        public string PotrawaNazwa
        {
            get
            {
                return _PotrawaNazwa;
            }
            set
            {
                if (_PotrawaNazwa != value)
                {
                    _PotrawaNazwa = value;
                    base.OnPropertyChanged(() => PotrawaNazwa);
                }
            }
        }
        private int? _IloscPotrawy;
        public int? IloscPotrawy
        {
            get
            {
                return _IloscPotrawy;
            }
            set
            {
                if (_IloscPotrawy != value)
                {
                    _IloscPotrawy = value;
                    base.OnPropertyChanged(() => IloscPotrawy);
                }
            }
        }
        private string _NapojNazwa;
        public string NapojNazwa
        {
            get
            {
                return _NapojNazwa;
            }
            set
            {
                if (_NapojNazwa != value)
                {
                    _NapojNazwa = value;
                    base.OnPropertyChanged(() => NapojNazwa);
                }
            }
        }
        private int? _IloscNapoju;
        public int? IloscNapoju
        {
            get
            {
                return _IloscNapoju;
            }
            set
            {
                if (_IloscNapoju != value)
                {
                    _IloscNapoju = value;
                    base.OnPropertyChanged(() => IloscNapoju);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranaRezerwacja(RezerwacjaForAllView rezerwacja)
        {
            IdRezerwacji = rezerwacja.IdRezerwacji;
            RezerwacjaNumerPokoju = rezerwacja.NumerPokoju.ToString();
            DataRozpoczecia = rezerwacja.DataRozpoczecia ;
            DataZakonczenia = rezerwacja.DataZakonczenia;
        }
        private void getWybranyPosilek(PosilekForAllView posilek)
        {
            IdPosilku = posilek.IdPosilku;
            PotrawaNazwa = posilek.PotrawaNazwa;
            IloscPotrawy = posilek.IloscPotrawy;
            IloscNapoju = posilek.IloscNapoju;
            NapojNazwa = posilek.NapojNazwa;
        }
        public override void Save()
        {
            hotelEntities.Uslugi.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
