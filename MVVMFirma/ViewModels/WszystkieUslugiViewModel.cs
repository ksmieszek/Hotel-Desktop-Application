using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieUslugiViewModel : WszystkieViewModel<UslugaForAllView>
    {
        #region Properties
        private UslugaForAllView _WybranaUsluga;
        public UslugaForAllView WybranaUsluga
        {
            get
            {
                return _WybranaUsluga;
            }
            set
            {
                if (_WybranaUsluga != value)
                {
                    _WybranaUsluga = value;
                    Messenger.Default.Send(_WybranaUsluga);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkieUslugiViewModel()
        {
            base.DisplayName = "Usługi";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<UslugaForAllView>
                (
                    from usluga in hotelEntities.Uslugi
                    select new UslugaForAllView
                    {
                        IdUslugi = usluga.IdUslugi,
                        Kod = usluga.Kod,
                        Nazwa = usluga.Nazwa,
                        NumerPokoju = usluga.Rezerwacje.Pokoje.NumerPokoju,
                        DataRozpoczecia = usluga.Rezerwacje.DataRozpoczecia,
                        DataZakonczenia = usluga.Rezerwacje.DataZakonczenia,
                        DataZamowienia = usluga.Posilki.DataZamowienia,
                        Potrawa = usluga.Posilki.Potrawy.Nazwa,
                        Napoj = usluga.Posilki.Napoje.Nazwa,
                    }
                );

        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data rozpoczęcia rezerwacji", "Data zakończenia rezerwacji", "Data zamówienia posiłku" };
        }
        public override void Sort()
        {
            if (SortField == "Data rozpoczęcia rezerwacji")
                List = new ObservableCollection<UslugaForAllView>(List.OrderByDescending(item => item.DataRozpoczecia));
            if (SortField == "Data zakończenia rezerwacji")
                List = new ObservableCollection<UslugaForAllView>(List.OrderByDescending(item => item.DataZakonczenia));
            if (SortField == "Data zamówienia posiłku")
                List = new ObservableCollection<UslugaForAllView>(List.OrderByDescending(item => item.DataZamowienia));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data rozpoczęcia rezerwacji", "Data zakończenia rezerwacji", "Data zamówienia posiłku" };
        }
        public override void Find()
        {
            if (FindField == "Data rozpoczęcia rezerwacji")
                List = new ObservableCollection<UslugaForAllView>(List.Where(item => item.DataRozpoczecia != null && System.DateTime.Equals(item.DataRozpoczecia, DateTime.Parse(FindTextBox))));
            if (FindField == "Data zakończenia rezerwacji")
                List = new ObservableCollection<UslugaForAllView>(List.Where(item => item.DataZakonczenia != null && System.DateTime.Equals(item.DataZakonczenia, DateTime.Parse(FindTextBox))));
            if (FindField == "Data zamówienia posiłku")
                List = new ObservableCollection<UslugaForAllView>(List.Where(item => item.DataZamowienia != null && System.DateTime.Equals(item.DataZamowienia, DateTime.Parse(FindTextBox))));
        }
        #endregion
    }
}
