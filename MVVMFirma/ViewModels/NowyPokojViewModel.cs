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
    public class NowyPokojViewModel : JedenViewModel<Pokoje>
    {
        #region Fields
        private BaseCommand _ShowAdresy;
        #endregion
        #region Constructor
        public NowyPokojViewModel()
        {
            base.DisplayName = "Pokój";
            item = new Pokoje();
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
        public int IdPokoju
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
        public int? IdStatusu
        {
            get
            {
                return item.IdStatusu;
            }
            set
            {
                if (item.IdStatusu != value)
                {
                    item.IdStatusu = value;
                    base.OnPropertyChanged(() => IdStatusu);
                }
            }
        }
        public int? NumerPokoju
        {
            get
            {
                return item.NumerPokoju;
            }
            set
            {
                if (item.NumerPokoju != value)
                {
                    item.NumerPokoju = value;
                    base.OnPropertyChanged(() => NumerPokoju);
                }
            }
        }
        public int? Pietro
        {
            get
            {
                return item.Pietro;
            }
            set
            {
                if (item.Pietro != value)
                {
                    item.Pietro = value;
                    base.OnPropertyChanged(() => Pietro);
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
        public string Wysposazenie
        {
            get
            {
                return item.Wysposazenie;
            }
            set
            {
                if (item.Wysposazenie != value)
                {
                    item.Wysposazenie = value;
                    base.OnPropertyChanged(() => Wysposazenie);
                }
            }
        }
        public string Rodzaj
        {
            get
            {
                return item.Rodzaj;
            }
            set
            {
                if (item.Rodzaj != value)
                {
                    item.Rodzaj = value;
                    base.OnPropertyChanged(() => Rodzaj);
                }
            }
        }
        public double? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> StatusComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from status in hotelEntities.StatusyPokoju
                        select new ComboBoxKeyAndValue
                        {
                            Key = status.IdStatusu,
                            Value = status.Nazwa
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
        //ta metoda jest wywolywana przez komende showadresy ktora jest podpieta pod przycisk adresy
        private void getWybranyAdres(AdresForAllView adres)
        {
            //uzupelniamy dane adresowe w pokojach na bazie danych adresu ktora przyjdzie z okna ze wszystkimi adresami
            IdAdresu = adres.IdAdresu;
            AdresMiasto = adres.Miasto;
            AdresKodPocztowy = adres.KodPocztowy;
            AdresUlica = adres.Ulica;
            AdresNumerBudynku = adres.NumerBudynku;
            AdresNumerLokalu = adres.NumerLokalu;
        }
        public override void Save()
        {
            hotelEntities.Pokoje.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
