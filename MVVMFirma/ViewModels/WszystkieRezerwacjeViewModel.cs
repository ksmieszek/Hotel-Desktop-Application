using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieRezerwacjeViewModel : WszystkieViewModel<RezerwacjaForAllView>
    {
        #region Properties
        private RezerwacjaForAllView _WybranaRezerwacja;
        public RezerwacjaForAllView WybranaRezerwacja
        {
            get
            {
                return _WybranaRezerwacja;
            }
            set
            {
                if (_WybranaRezerwacja != value)
                {
                    _WybranaRezerwacja = value;
                    Messenger.Default.Send(_WybranaRezerwacja);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkieRezerwacjeViewModel()
        {
            base.DisplayName = "Rezerwacje";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<RezerwacjaForAllView>
                (
                    from rezerwacja in hotelEntities.Rezerwacje
                    select new RezerwacjaForAllView
                    {
                        Netto = rezerwacja.Netto,
                        Rabat = rezerwacja.Rabat,
                        VAT = rezerwacja.VAT,
                        Brutto = rezerwacja.Brutto,
                        DataRozpoczecia = rezerwacja.DataRozpoczecia,
                        DataZakonczenia = rezerwacja.DataZakonczenia,
                        NumerPokoju = rezerwacja.Pokoje.NumerPokoju,
                        Pietro = rezerwacja.Pokoje.Pietro,
                        Wyposazenie = rezerwacja.Pokoje.Wysposazenie,
                        TypPokoju = rezerwacja.Pokoje.Rodzaj,
                        AdresPokoju = rezerwacja.Pokoje.Adresy.Miasto + ", " + rezerwacja.Pokoje.Adresy.Ulica + " " + rezerwacja.Pokoje.Adresy.NumerBudynku,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data rozpoczęcia(najstarsza)", "Data rozpoczęcia(najnowsza)", "Data zakończenia(najstarsza)", "Data zakończenia(najnowsza)", "Cena(rosnąco)", "Cena(malejąco)" };
        }
        public override void Sort()
        {
            if (SortField == "Cena(rosnąco)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(item => item.Brutto));
            if (SortField == "Cena(malejąco)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderByDescending(item => item.Brutto));

            if (SortField == "Data rozpoczęcia(najstarsza)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(item => item.DataRozpoczecia));
            if (SortField == "Data rozpoczęcia(najnowsza)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderByDescending(item => item.DataRozpoczecia));

            if (SortField == "Data zakończenia(najstarsza)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderBy(item => item.DataZakonczenia));
            if (SortField == "Data zakończenia(najnowsza)")
                List = new ObservableCollection<RezerwacjaForAllView>(List.OrderByDescending(item => item.DataZakonczenia));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Data rozpoczęcia", "Data zakończenia" };
        }
        public override void Find()
        {
            if (FindField == "Data rozpoczęcia")
                List = new ObservableCollection<RezerwacjaForAllView>(List.Where(item => item.DataRozpoczecia != null && System.DateTime.Equals(item.DataRozpoczecia, DateTime.Parse(FindTextBox))));
            if (FindField == "Data zakończenia")
                List = new ObservableCollection<RezerwacjaForAllView>(List.Where(item => item.DataZakonczenia != null && System.DateTime.Equals(item.DataZakonczenia, DateTime.Parse(FindTextBox))));
        }
        #endregion
    }
}
