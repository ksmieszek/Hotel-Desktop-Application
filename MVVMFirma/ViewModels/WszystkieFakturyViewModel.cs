using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieFakturyViewModel : WszystkieViewModel<FakturaForAllView>
    {
        #region Properties
        private FakturaForAllView _WybranaFaktura;
        public FakturaForAllView WybranaFaktura
        {
            get
            {
                return _WybranaFaktura;
            }
            set
            {
                if (_WybranaFaktura != value)
                {
                    _WybranaFaktura = value;
                    Messenger.Default.Send(_WybranaFaktura);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Konstruktor
        public WszystkieFakturyViewModel()
        {
            base.DisplayName = "Faktury";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<FakturaForAllView>
                (
                    from faktura in hotelEntities.Faktury
                    select new FakturaForAllView
                    {
                        IdFaktury = faktura.IdFaktury,
                        Numer = faktura.Numer,
                        DataWystawienia = faktura.DataWystawienia,
                        DataSprzedazy = faktura.DataSprzedazy,
                        KlientNazwa = faktura.Klienci.Imie + " " + faktura.Klienci.Nazwisko,
                        KlientFirma = faktura.Klienci.Firma,
                        KlientRodzaj = faktura.Klienci.RodzajeKlientow.Nazwa,
                        KlientMiasto = faktura.Klienci.Adresy.Miasto,
                        KlientTelefon = faktura.Klienci.Telefon,
                        TerminPlatnosci = faktura.TerminPlatnosci,
                        SposobPlatnosciNazwa = faktura.SposobyPlatnosci.Nazwa,
                        DoZaplaty = faktura.DoZaplaty,
                        Zaplacono = faktura.Zaplacono,
                        KlientNIP = faktura.Klienci.NIP,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data wystawienia(najstarsza)", "Data wystawienia(najnowsza)", "Data sprzedaży(najstarsza)", "Data sprzedaży(najnowsza)", "Termin płatności(najstarsza)", "Termin płatności(najnowsza)", "Zapłacono rosnąco", "Zapłacono malejąco" };
        }
        public override void Sort()
        {
            if (SortField == "Data wystawienia(najstarsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.DataSprzedazy));
            if (SortField == "Data wystawienia(najnowsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderByDescending(item => item.DataSprzedazy));
            if (SortField == "Termin płatności(najstarsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.TerminPlatnosci));
            if (SortField == "Termin płatności(najnowsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderByDescending(item => item.TerminPlatnosci));
            if (SortField == "Data sprzedaży(najstarsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.DataWystawienia));
            if (SortField == "Data sprzedaży(najnowsza)")
                List = new ObservableCollection<FakturaForAllView>(List.OrderByDescending(item => item.DataWystawienia));
            if (SortField == "Zapłacono rosnąco")
                List = new ObservableCollection<FakturaForAllView>(List.OrderBy(item => item.Zaplacono));
            if (SortField == "Zapłacono malejąco")
                List = new ObservableCollection<FakturaForAllView>(List.OrderByDescending(item => item.Zaplacono));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Numer", "Data wystawienia", "Data sprzedaży", "Termin płatności" };
        }
        public override void Find()
        {
            if (FindField == "Numer")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.Numer != null && item.Numer.StartsWith(FindTextBox)));
            if (FindField == "Data wystawienia")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.DataWystawienia != null && System.DateTime.Equals(item.DataWystawienia, DateTime.Parse(FindTextBox))));
            if (FindField == "Data sprzedaży")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.DataSprzedazy != null && System.DateTime.Equals(item.DataSprzedazy, DateTime.Parse(FindTextBox))));
            if (FindField == "Termin płatności")
                List = new ObservableCollection<FakturaForAllView>(List.Where(item => item.TerminPlatnosci != null && System.DateTime.Equals(item.TerminPlatnosci, DateTime.Parse(FindTextBox))));
        }
        #endregion
    }
}
