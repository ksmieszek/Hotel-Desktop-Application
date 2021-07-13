using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;

namespace MVVMFirma.ViewModels
{
    public class NowyPracownikViewModel : JedenViewModel<Pracownicy>
    {
        #region Fields
        private BaseCommand _ShowAdresy;
        #endregion
        #region Constructor
        public NowyPracownikViewModel()
            : base()
        {
            base.DisplayName = "Nowy pracownik";
            item = new Pracownicy();
            Messenger.Default.Register<AdresForAllView>(this, getWybranyAdres);
        }
        #endregion
        #region Commands
        public ICommand ShowAdresy
        {
            get
            {
                if (_ShowAdresy == null)
                    _ShowAdresy = new BaseCommand(() => Messenger.Default.Send("AdresyShow"));

                return _ShowAdresy;
            }
        }
        #endregion
        #region Properties
        public string Imie
        {
            get
            {
                return item.Imie;
            }
            set
            {
                if (item.Imie != value)
                {
                    item.Imie = value;
                    base.OnPropertyChanged(() => Imie);
                }
            }
        }
        public string Nazwisko
        {
            get
            {
                return item.Nazwisko;
            }
            set
            {
                if (item.Nazwisko != value)
                {
                    item.Nazwisko = value;
                    base.OnPropertyChanged(() => Nazwisko);
                }
            }
        }
        public string Login
        {
            get
            {
                return item.Login;
            }
            set
            {
                if (item.Login != value)
                {
                    item.Login = value;
                    base.OnPropertyChanged(() => Login);
                }
            }
        }
        public string Haslo
        {
            get
            {
                return item.Haslo;
            }
            set
            {
                if (item.Haslo != value)
                {
                    item.Haslo = value;
                    base.OnPropertyChanged(() => Haslo);
                }
            }
        }
        public string PESEL
        {
            get
            {
                return item.PESEL;
            }
            set
            {
                if (item.PESEL != value)
                {
                    item.PESEL = value;
                    base.OnPropertyChanged(() => PESEL);
                }
            }
        }
        public string Telefon
        {
            get
            {
                return item.Telefon;
            }
            set
            {
                if (item.Telefon != value)
                {
                    item.Telefon = value;
                    base.OnPropertyChanged(() => Telefon);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> AdresComboBoxItems
        {
            get
            {
                return
                    (
                        from adres in hotelEntities.Adresy
                        select new ComboBoxKeyAndValue
                        {
                            Key = adres.IdAdresu,
                            Value = adres.Miasto + " ulica " + adres.Ulica + " " + adres.NumerBudynku
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdAdresu
        {
            get
            {
                return item.IdAdresu;
            }
            set
            {
                if (item.IdAdresu != value)
                {
                    item.IdAdresu = value;
                    base.OnPropertyChanged(() => IdAdresu);
                }
            }
        }
        private string _AdresMiasto;
        public string AdresMiasto
        {
            get
            {
                return _AdresMiasto;
            }
            set
            {
                if (_AdresMiasto != value)
                {
                    _AdresMiasto = value;
                    base.OnPropertyChanged(() => AdresMiasto);
                }
            }
        }
        private string _AdresKodPocztowy;
        public string AdresKodPocztowy
        {
            get
            {
                return _AdresKodPocztowy;
            }
            set
            {
                if (_AdresKodPocztowy != value)
                {
                    _AdresKodPocztowy = value;
                    base.OnPropertyChanged(() => AdresKodPocztowy);
                }
            }
        }
        private string _AdresUlica;
        public string AdresUlica
        {
            get
            {
                return _AdresUlica;
            }
            set
            {
                if (_AdresUlica != value)
                {
                    _AdresUlica = value;
                    base.OnPropertyChanged(() => AdresUlica);
                }
            }
        }
        private string _AdresNumerBudynku;
        public string AdresNumerBudynku
        {
            get
            {
                return _AdresNumerBudynku;
            }
            set
            {
                if (_AdresNumerBudynku != value)
                {
                    _AdresNumerBudynku = value;
                    base.OnPropertyChanged(() => AdresNumerBudynku);
                }
            }
        }
        private string _AdresNumerLokalu;
        public string AdresNumerLokalu
        {
            get
            {
                return _AdresNumerLokalu;
            }
            set
            {
                if (_AdresNumerLokalu != value)
                {
                    _AdresNumerLokalu = value;
                    base.OnPropertyChanged(() => AdresNumerLokalu);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranyAdres(AdresForAllView adres)
        {
            IdAdresu = adres.IdAdresu;
            AdresMiasto = adres.Miasto;
            AdresKodPocztowy = adres.KodPocztowy;
            AdresUlica = adres.Ulica;
            AdresNumerBudynku = adres.NumerBudynku;
            AdresNumerLokalu = adres.NumerLokalu;
        }
        public override void Save()
        {
            hotelEntities.Pracownicy.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
