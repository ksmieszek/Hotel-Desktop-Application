using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMFirma.Models.Entities;
using System.Collections.ObjectModel;

namespace MVVMFirma.ViewModels
{
    class WszystkieSposobyPlatnosciViewModel : WszystkieViewModel<SposobyPlatnosci>
    {
        #region Constructor
        public WszystkieSposobyPlatnosciViewModel()
            : base()
        {
            base.DisplayName = "Rodzaje płatności";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<SposobyPlatnosci>(hotelEntities.SposobyPlatnosci);
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void Sort()
        {
            if (SortField == "Nazwa")
                List = new ObservableCollection<SposobyPlatnosci>(List.OrderBy(item => item.Nazwa));
            if (SortField == "Opis")
                List = new ObservableCollection<SposobyPlatnosci>(List.OrderBy(item => item.Opis));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa", "Opis" };
        }
        public override void Find()
        {
            if (FindField == "Nazwa")
                List = new ObservableCollection<SposobyPlatnosci>(List.Where(item => item.Nazwa != null && item.Nazwa.StartsWith(FindTextBox)));
            if (FindField == "Opis")
                List = new ObservableCollection<SposobyPlatnosci>(List.Where(item => item.Opis != null && item.Opis.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
