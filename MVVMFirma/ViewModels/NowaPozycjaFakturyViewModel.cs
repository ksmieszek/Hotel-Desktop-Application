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
    public class NowaPozycjaFakturyViewModel : JedenViewModel<PozycjeFaktury>
    {
        #region Fields
        private BaseCommand _ShowFaktury;
        private BaseCommand _ShowUslugi;
        #endregion
        #region Constructor
        public NowaPozycjaFakturyViewModel()
        {
            base.DisplayName = "Pozycje faktury";
            item = new PozycjeFaktury();
            Messenger.Default.Register<FakturaForAllView>(this, getWybranaFaktura);
            Messenger.Default.Register<UslugaForAllView>(this, getWybranaUsluga);
        }
        #endregion
        #region Commands
        public ICommand ShowFaktury
        {
            get
            {
                if (_ShowFaktury == null)
                    _ShowFaktury = new BaseCommand(() => Messenger.Default.Send("FakturyShow"));

                return _ShowFaktury;
            }
        }
        public ICommand ShowUslugi
        {
            get
            {
                if (_ShowUslugi == null)
                    _ShowUslugi = new BaseCommand(() => Messenger.Default.Send("UslugiShow"));

                return _ShowUslugi;
            }
        }
        #endregion
        #region Properties
        public int IdPozycjiFaktury
        {
            get
            {
                return item.IdPozycjiFaktury;
            }
            set
            {
                if (item.IdPozycjiFaktury != value)
                {
                    item.IdPozycjiFaktury = value;
                    base.OnPropertyChanged(() => IdPozycjiFaktury);
                }
            }
        }
        public int? IdFaktury
        {
            get
            {
                return item.IdFaktury;
            }
            set
            {
                if (item.IdFaktury != value)
                {
                    item.IdFaktury = value;
                    base.OnPropertyChanged(() => IdFaktury);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> FakturyComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from faktura in hotelEntities.Faktury
                        select new ComboBoxKeyAndValue
                        {
                            Key = faktura.IdFaktury,
                            Value = "Numer: " +  faktura.Numer + " - data wystawienia: " + faktura.DataWystawienia
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdUslugi
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
        public IQueryable<ComboBoxKeyAndValue> UslugiComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from usluga in hotelEntities.Uslugi
                        select new ComboBoxKeyAndValue
                        {
                            Key = usluga.IdUslugi,
                            Value = "Kod: " + usluga.Kod + " - usługa: " + usluga.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public decimal? Cena
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
        public int? Ilosc
        {
            get
            {
                return item.Ilosc;
            }
            set
            {
                if (item.Ilosc != value)
                {
                    item.Ilosc = value;
                    base.OnPropertyChanged(() => Ilosc);
                }
            }
        }
        public decimal? Rabat
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
        private string _FakturaNumer;
        public string FakturaNumer
        {
            get
            {
                return _FakturaNumer;
            }
            set
            {
                if (_FakturaNumer != value)
                {
                    _FakturaNumer = value;
                    base.OnPropertyChanged(() => FakturaNumer);
                }
            }
        }
        private DateTime? _FakturaDataWystawienia;
        public DateTime? FakturaDataWystawienia
        {
            get
            {
                return _FakturaDataWystawienia;
            }
            set
            {
                if (_FakturaDataWystawienia != value)
                {
                    _FakturaDataWystawienia = value;
                    base.OnPropertyChanged(() => FakturaDataWystawienia);
                }
            }
        }
        private string _UslugaKod;
        public string UslugaKod
        {
            get
            {
                return _UslugaKod;
            }
            set
            {
                if (_UslugaKod != value)
                {
                    _UslugaKod = value;
                    base.OnPropertyChanged(() => UslugaKod);
                }
            }
        }
        private string _UslugaNazwa;
        public string UslugaNazwa
        {
            get
            {
                return _UslugaNazwa;
            }
            set
            {
                if (_UslugaNazwa != value)
                {
                    _UslugaNazwa = value;
                    base.OnPropertyChanged(() => UslugaNazwa);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranaFaktura(FakturaForAllView faktura)
        {
            IdFaktury = faktura.IdFaktury;
            FakturaNumer = faktura.Numer;
            FakturaDataWystawienia = faktura.DataWystawienia;
        }
        private void getWybranaUsluga(UslugaForAllView usluga)
        {
            IdUslugi = usluga.IdUslugi;
            UslugaKod = usluga.Kod;
            UslugaNazwa = usluga.Nazwa;
        }
        public override void Save()
        {
            hotelEntities.PozycjeFaktury.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
