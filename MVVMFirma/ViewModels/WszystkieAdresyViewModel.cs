using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieAdresyViewModel : WszystkieViewModel<AdresForAllView>
    {
        #region Properties
        private AdresForAllView _WybranyAdres;
        public AdresForAllView WybranyAdres
        {
            get
            {
                return _WybranyAdres;
            }
            set
            {
                if (_WybranyAdres != value)
                {
                    _WybranyAdres = value;
                    Messenger.Default.Send(_WybranyAdres);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszystkieAdresyViewModel()
            : base()
        {
            base.DisplayName = "Adresy";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<AdresForAllView>
                (
                    from adres in hotelEntities.Adresy 
                    select new AdresForAllView 
                    {
                        IdAdresu = adres.IdAdresu,
                        Kraj = adres.Kraj,
                        Wojewodztwo = adres.Wojewodztwo,
                        Miasto = adres.Miasto,
                        KodPocztowy = adres.KodPocztowy,
                        Ulica = adres.Ulica,
                        NumerBudynku = adres.NumerBudynku,
                        NumerLokalu = adres.NumerLokalu,
                        Fax = adres.Fax,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Miasto ulica i numer" };
        }
        public override void Sort()
        {
            if (SortField == "Miasto ulica i numer")
                List = new ObservableCollection<AdresForAllView>(List.OrderBy(item => item.Miasto).ThenBy(item => item.Ulica).ThenBy(item => item.NumerBudynku));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Kraj", "Województwo", "Kod pocztowy", "Miasto", "Ulica", "Numer budynku", "Numer lokalu", "Fax" };
        }
        public override void Find()
        {
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.KodPocztowy != null && item.KodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Kraj")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.Kraj != null && item.Kraj.StartsWith(FindTextBox)));
            if (FindField == "Województwo")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.Wojewodztwo != null && item.Wojewodztwo.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.Miasto != null && item.Miasto.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.Ulica != null && item.Ulica.StartsWith(FindTextBox)));
            if (FindField == "Numer budynku")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.NumerBudynku != null && item.NumerBudynku.StartsWith(FindTextBox)));
            if (FindField == "Numer lokalu")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.NumerLokalu != null && item.NumerLokalu.StartsWith(FindTextBox)));
            if (FindField == "Fax")
                List = new ObservableCollection<AdresForAllView>(List.Where(item => item.Fax != null && item.Fax.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
