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
    public class NowaRezerwacjaViewModel : JedenViewModel<Rezerwacje>
    {
        #region Fields
        private BaseCommand _ShowPokoje;
        #endregion
        #region Constructor
        public NowaRezerwacjaViewModel()
        {
            base.DisplayName = "Rezerwacja";
            item = new Rezerwacje();
            Messenger.Default.Register<PokojForAllView>(this, getWybranyPokoj);
            DataRozpoczecia = DateTime.Now;
            DataZakonczenia = DateTime.Now.AddDays(1);
        }
        #endregion
        #region Commands
        public ICommand ShowPokoje
        {
            get
            {
                if (_ShowPokoje == null)
                    _ShowPokoje = new BaseCommand(() => Messenger.Default.Send("PokojeShow"));

                return _ShowPokoje;
            }
        }
        #endregion
        #region properties
        public int IdRezerwacji
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
        public int? IdPokoju
        {
            get
            {
                return item.IdPokoju;
            }
            set
            {
                if (item.IdPokoju != value)
                { 
                    item.IdPokoju = value;
                    base.OnPropertyChanged(() => IdPokoju);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> PokojeComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from pokoj in hotelEntities.Pokoje
                        select new ComboBoxKeyAndValue
                        {
                            Key = pokoj.IdPokoju,
                            Value = "Numer: " + pokoj.NumerPokoju + ", na piętrze: " + pokoj.Pietro + " | " + pokoj.Rodzaj + " | " + pokoj.StatusyPokoju.Nazwa + " | " + pokoj.Cena + "zł"
                        }
                    ).ToList().AsQueryable();
            }
        }
        public DateTime? DataRozpoczecia
        {
            get
            {
                return item.DataRozpoczecia;
            }
            set
            {
                if (item.DataRozpoczecia != value)
                { 
                    item.DataRozpoczecia = value;
                    base.OnPropertyChanged(() => DataRozpoczecia);
                }
            }
        }
        public DateTime? DataZakonczenia
        {
            get
            {
                return item.DataZakonczenia;
            }
            set
            {
                if (item.DataZakonczenia != value)
                { 
                    item.DataZakonczenia = value;
                    base.OnPropertyChanged(() => DataZakonczenia);
                }
            }
        }
        public double? Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                if (item.Rabat != value)
                {
                    item.Rabat = value;
                    base.OnPropertyChanged(() => Rabat);
                }
            }
        }
        public double? VAT
        {
            get
            {
                return item.VAT;
            }
            set
            {
                if (item.VAT != value)
                {
                    item.VAT = value;
                    base.OnPropertyChanged(() => VAT);
                }
            }
        }
        public decimal? Netto
        {
            get
            {
                return item.Netto;
            }
            set
            {
                if (item.Netto != value)
                {
                    item.Netto = value;
                    base.OnPropertyChanged(() => Netto);
                }
            }
        }
        public decimal? Brutto
        {
            get
            {
                return item.Brutto;
            }
            set
            {
                if (item.Brutto != value)
                {
                    item.Brutto = value;
                    base.OnPropertyChanged(() => Brutto);
                }
            }
        }
        public decimal? DoZaplaty
        {
            get
            {
                return item.DoZaplaty;
            }
            set
            {
                if (item.DoZaplaty != value)
                {
                    item.DoZaplaty = value;
                    base.OnPropertyChanged(() => DoZaplaty);
                }
            }
        }
        private string _PokojNumerPokoju;
        public string PokojNumerPokoju
        {
            get
            {
                return _PokojNumerPokoju;
            }
            set
            {
                if (_PokojNumerPokoju != value)
                {
                    _PokojNumerPokoju = value;
                    base.OnPropertyChanged(() => PokojNumerPokoju);
                }
            }
        }
        private string _PokojPietro;
        public string PokojPietro
        {
            get
            {
                return _PokojPietro;
            }
            set
            {
                if (_PokojPietro != value)
                {
                    _PokojPietro = value;
                    base.OnPropertyChanged(() => PokojPietro);
                }
            }
        }
        private string _PokojRodzaj;
        public string PokojRodzaj
        {
            get
            {
                return _PokojRodzaj;
            }
            set
            {
                if (_PokojRodzaj != value)
                {
                    _PokojRodzaj = value;
                    base.OnPropertyChanged(() => PokojRodzaj);
                }
            }
        }
        private string _PokojNazwa;
        public string PokojNazwa
        {
            get
            {
                return _PokojNazwa;
            }
            set
            {
                if (_PokojNazwa != value)
                {
                    _PokojNazwa = value;
                    base.OnPropertyChanged(() => PokojNazwa);
                }
            }
        }
        private string _PokojCena;
        public string PokojCena
        {
            get
            {
                return _PokojCena;
            }
            set
            {
                if (_PokojCena != value)
                {
                    _PokojCena = value;
                    base.OnPropertyChanged(() => PokojCena);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranyPokoj(PokojForAllView pokoj)
        {
            IdPokoju = pokoj.IdPokoju;
            PokojNumerPokoju = pokoj.NumerPokoju.ToString();
            PokojPietro = pokoj.Pietro.ToString();
            PokojRodzaj = pokoj.Rodzaj;
            PokojNazwa = pokoj.Nazwa;
            PokojCena = pokoj.Cena.ToString();
        }
        public override void Save()
        {
            hotelEntities.Rezerwacje.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
