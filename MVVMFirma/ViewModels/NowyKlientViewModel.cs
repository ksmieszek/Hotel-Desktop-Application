using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using MVVMFirma.Models.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyKlientViewModel : JedenViewModel<Klienci>, IDataErrorInfo
    {
        #region Fields
        private BaseCommand _ShowAdresy;
        #endregion
        #region Constructor
        public NowyKlientViewModel()
            : base()
        {
            base.DisplayName = "Klient";
            item = new Klienci();
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
        #region Validation
        public string Error
        {
            get
            {
                return null;
            }
        }
        public string this[string name]
        {
            get
            {
                string komunikat = null;
                if (name == "Imie")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Imie);
                }
                if (name == "Nazwisko")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.Nazwisko);
                }
                if (name == "DrugieImie")
                {
                    komunikat = Validators.SprawdzStringSzczegolowo(this.DrugieImie);
                }
                if (name == "Firma")
                {
                    komunikat = Validators.SprawdzCzyOdDuzejLitery(this.Firma);
                }
                if (name == "PESEL")
                {
                    komunikat = Validators.SprawdzPesel(this.PESEL);
                }
                if (name == "Telefon")
                {
                    komunikat = Validators.SprawdzNumerTelefonu(this.Telefon);
                }
                if (name == "REGON")
                {
                    komunikat = Validators.RegonValidate(this.REGON);
                }
                if (name == "NIP")
                {
                    komunikat = Validators.IsValidNIP(this.NIP);
                }
                if (name == "E_mail")
                {
                    komunikat = Validators.SprawdzEmail(this.E_mail);
                }
                return komunikat;
            }
        }
        public override bool IsValid()
        {
            if (this["Imie"] == null && this["Nazwisko"] == null)
                return true;
            return false;
        }
        #endregion
        #region Properties
        public int IdKlienta
        {
            get
            {
                return item.IdKlienta;
            }
            set
            {
                if (item.IdKlienta != value)
                {
                    item.IdKlienta = value;
                    base.OnPropertyChanged(() => IdKlienta);
                }
            }
        }
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
        public string Plec
        {
            get
            {
                return item.Plec;
            }
            set
            {
                if (item.Plec != value)
                {
                    item.Plec = value;
                    base.OnPropertyChanged(() => Plec);
                }
            }
        }
        public string DrugieImie
        {
            get
            {
                return item.DrugieImie;
            }
            set
            {
                if (item.DrugieImie != value)
                {
                    item.DrugieImie = value;
                    base.OnPropertyChanged(() => DrugieImie);
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
                    item.Telefon = value.Trim().Replace("-", " "); 
                    base.OnPropertyChanged(() => Telefon);
                }
            }
        }
        public string E_mail
        {
            get
            {
                return item.E_mail;
            }
            set
            {
                if (item.E_mail != value)
                {
                    item.E_mail = value;
                    base.OnPropertyChanged(() => Firma);
                }
            }
        }
        public string NIP
        {
            get
            {
                return item.NIP;
            }
            set
            {
                if (item.NIP != value)
                {
                    item.NIP = value;
                    base.OnPropertyChanged(() => NIP);
                }
            }
        }
        public string REGON
        {
            get
            {
                return item.REGON;
            }
            set
            {
                if (item.REGON != value)
                {
                    item.REGON = value;
                    base.OnPropertyChanged(() => REGON);
                }
            }
        }
        public string Firma
        {
            get
            {
                return item.Firma;
            }
            set
            {
                if (item.Firma != value)
                {
                    item.Firma = value;
                    base.OnPropertyChanged(() => Firma);
                }
            }
        }
        public int? IdRodzaju
        {
            get
            {
                return item.IdRodzaju;
            }
            set
            {
                if (item.IdRodzaju != value)
                {
                    item.IdRodzaju = value;
                    base.OnPropertyChanged(() => IdRodzaju);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> RodzajKlientaComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from rodzaj in hotelEntities.RodzajeKlientow
                        select new ComboBoxKeyAndValue
                        {
                            Key = rodzaj.IdRodzaju,
                            Value = rodzaj.Nazwa
                        }
                    ).ToList().AsQueryable();
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
            hotelEntities.Klienci.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
