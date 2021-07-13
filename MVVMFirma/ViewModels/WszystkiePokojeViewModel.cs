using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System.Windows.Input;
using MVVMFirma.Models.EntitiesForView;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class WszystkiePokojeViewModel : WszystkieViewModel<PokojForAllView>
    {
        #region Properties
        private PokojForAllView _WybranyPokoj;
        public PokojForAllView WybranyPokoj
        {
            get
            {
                return _WybranyPokoj;
            }
            set
            {
                if (_WybranyPokoj != value)
                {
                    _WybranyPokoj = value;
                    Messenger.Default.Send(_WybranyPokoj);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkiePokojeViewModel()
        {
            base.DisplayName = "Pokoje";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PokojForAllView>
                (
                    from pokoj in hotelEntities.Pokoje
                    select new PokojForAllView
                    {
                        IdPokoju = pokoj.IdPokoju,
                        NumerPokoju = pokoj.NumerPokoju,
                        Pietro = pokoj.Pietro,
                        Nazwa = pokoj.Nazwa,
                        Wysposazenie = pokoj.Wysposazenie,
                        Rodzaj = pokoj.Rodzaj,
                        Cena = pokoj.Cena,
                        StatusPokoju = pokoj.StatusyPokoju.Nazwa,
                        AdresPokoju = pokoj.Adresy.Miasto + ", " + pokoj.Adresy.Ulica + " " + pokoj.Adresy.NumerBudynku,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Numer pokoju", "Piętro", "Cena(rosnąco)", "Cena(malejąco)" };
        }
        public override void Sort()
        {
            if (SortField == "Piętro")
                List = new ObservableCollection<PokojForAllView>(List.OrderBy(item => item.Pietro));
            if (SortField == "Numer pokoju")
                List = new ObservableCollection<PokojForAllView>(List.OrderBy(item => item.NumerPokoju));
            if (SortField == "Cena(rosnąco)")
                List = new ObservableCollection<PokojForAllView>(List.OrderBy(item => item.Cena));
            if (SortField == "Cena(malejąco)")
                List = new ObservableCollection<PokojForAllView>(List.OrderByDescending(item => item.Cena));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Status", "Rodzaj", "Cena za dobę", "Zawiera wyposażenie" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<PokojForAllView>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Rodzaj")
                List = new ObservableCollection<PokojForAllView>(List.Where(item => item.Rodzaj != null && item.Rodzaj.StartsWith(FindTextBox)));
            if (FindField == "Status")
                List = new ObservableCollection<PokojForAllView>(List.Where(item => item.StatusPokoju != null && item.StatusPokoju.StartsWith(FindTextBox)));
            if (FindField == "Cena za dobę")
                List = new ObservableCollection<PokojForAllView>(List.Where(item => item.Cena != null && item.Cena == Convert.ToDouble(FindTextBox) ));
            if (FindField == "Zawiera wyposażenie")
                List = new ObservableCollection<PokojForAllView>(List.Where(item => item.Wysposazenie != null && item.Wysposazenie.Contains(FindTextBox) ));
        }
        #endregion
    }
}
