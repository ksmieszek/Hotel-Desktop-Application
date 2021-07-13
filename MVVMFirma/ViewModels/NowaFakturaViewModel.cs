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
    public class NowaFakturaViewModel : JedenViewModel<Faktury>
    {
        #region Fields
        private BaseCommand _ShowKlienci;
        #endregion
        #region Constructor
        public NowaFakturaViewModel()
        {
            base.DisplayName = "Faktura";
            item = new Faktury();
            DataWystawienia = DateTime.Now;
            DataSprzedazy = DateTime.Now;
            TerminPlatnosci = DateTime.Now.AddDays(7);
            IdPracownika = 1;
            Messenger.Default.Register<KlientForAllView>(this, getWybranyKlient);
        }
        #endregion
        #region Commands
        public ICommand ShowKlienci
        {
            get
            {
                if (_ShowKlienci == null)
                    _ShowKlienci = new BaseCommand(() => Messenger.Default.Send("KlienciShow"));

                return _ShowKlienci;
            }
        }
        #endregion
        #region Properties
        public int IdFaktury
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
        public string Numer
        {
            get
            {
                return item.Numer;
            }
            set
            {
                if (item.Numer != value)
                {
                    item.Numer = value;
                    base.OnPropertyChanged(() => Numer);
                }
            }
        }
        public DateTime? DataWystawienia
        {
            get
            {
                return item.DataWystawienia;
            }
            set
            {
                if (item.DataWystawienia != value)
                {
                    item.DataWystawienia = value;
                    base.OnPropertyChanged(() => DataWystawienia);
                }
            }
        }
        public DateTime? DataSprzedazy
        {
            get
            {
                return item.DataSprzedazy;
            }
            set
            {
                if (item.DataSprzedazy != value)
                {
                    item.DataSprzedazy = value;
                    base.OnPropertyChanged(() => DataSprzedazy);
                }
            }
        }
        public int? IdKlienta
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
        public IQueryable<ComboBoxKeyAndValue> KlienciComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from klient in hotelEntities.Klienci
                        select new ComboBoxKeyAndValue
                        {
                            Key = klient.IdKlienta,
                            Value = klient.RodzajeKlientow.Nazwa + " " + klient.Firma + "" + klient.Imie + " " + klient.Nazwisko + " " + klient.Adresy.Miasto
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboBoxKeyAndValue> SposobyPlatnosciComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from sposob in hotelEntities.SposobyPlatnosci
                        select new ComboBoxKeyAndValue
                        {
                            Key = sposob.IdSposobuPlatnosci,
                            Value = sposob.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public DateTime? TerminPlatnosci
        {
            get
            {
                return item.TerminPlatnosci;
            }
            set
            {
                if (item.TerminPlatnosci != value)
                { 
                    item.TerminPlatnosci = value;
                    base.OnPropertyChanged(() => TerminPlatnosci);
                }
            }
        }
        public int? IdSposobuPlatnosci
        {
            get
            {
                return item.IdSposobuPlatnosci;
            }
            set
            {
                if (item.IdSposobuPlatnosci != value)
                { 
                    item.IdSposobuPlatnosci = value;
                    base.OnPropertyChanged(() => IdSposobuPlatnosci);
                }
            }
        }
        public int? IdPracownika
        {
            get
            {
                return item.IdPracownika;
            }
            set
            {
                if (item.IdPracownika != value)
                { 
                    item.IdPracownika = value;
                    base.OnPropertyChanged(() => IdPracownika);
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
        public decimal? Zaplacono
        {
            get
            {
                return item.Zaplacono;
            }
            set
            {
                if (item.Zaplacono != value)
                { 
                    item.Zaplacono = value;
                    base.OnPropertyChanged(() => Zaplacono);
                }
            }
        }
        private string _KlientNazwa;
        public string KlientNazwa
        {
            get
            {
                return _KlientNazwa;
            }
            set
            {
                if (_KlientNazwa != value)
                {
                    _KlientNazwa = value;
                    base.OnPropertyChanged(() => KlientNazwa);
                }
            }
        }
        private string _KlientMiasto;
        public string KlientMiasto
        {
            get
            {
                return _KlientMiasto;
            }
            set
            {
                if (_KlientMiasto != value)
                {
                    _KlientMiasto = value;
                    base.OnPropertyChanged(() => KlientMiasto);
                }
            }
        }
        private string _KlientRodzaj;
        public string KlientRodzaj
        {
            get
            {
                return _KlientRodzaj;
            }
            set
            {
                if (_KlientRodzaj != value)
                {
                    _KlientRodzaj = value;
                    base.OnPropertyChanged(() => KlientRodzaj);
                }
            }
        }
        private string _KlientFirma;
        public string KlientFirma
        {
            get
            {
                return _KlientFirma;
            }
            set
            {
                if (_KlientFirma != value)
                {
                    _KlientFirma = value;
                    base.OnPropertyChanged(() => KlientFirma);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranyKlient(KlientForAllView klient)
        {
            IdKlienta = klient.IdKlienta;
            KlientNazwa = klient.Nazwa;
            KlientRodzaj = klient.RodzajKlientaNazwa;
            KlientMiasto = klient.AdresMiasto;
            KlientFirma = klient.Firma;
        }
        public override void Save()
        {
            item.IdPracownika = 1;
            hotelEntities.Faktury.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
