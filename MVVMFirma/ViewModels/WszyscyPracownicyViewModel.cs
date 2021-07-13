using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszyscyPracownicyViewModel : WszystkieViewModel<PracownikForAllView>
    {
        #region Constructor
        public WszyscyPracownicyViewModel()
        {
            base.DisplayName = "Pracownicy";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<PracownikForAllView>
                (
                    from pracownik in hotelEntities.Pracownicy
                    select new PracownikForAllView
                    {
                        Nazwa = pracownik.Imie + " " + pracownik.Nazwisko,
                        Imie = pracownik.Imie,
                        Nazwisko = pracownik.Nazwisko,
                        Login = pracownik.Login,
                        PESEL = pracownik.PESEL,
                        Telefon = pracownik.Telefon,
                        AdresPracownikaMiasto = pracownik.Adresy.Miasto,
                        AdresPracownikaKodPocztowy = pracownik.Adresy.KodPocztowy,
                        AdresPracownikaUlica = pracownik.Adresy.Ulica,
                        AdresPracownikaNumerBudynku = pracownik.Adresy.NumerBudynku,
                        AdresPracownikaNumerLokalu = pracownik.Adresy.NumerLokalu,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Pesel" };
        }
        public override void Sort()
        {
            if (SortField == "Pesel")
                List = new ObservableCollection<PracownikForAllView>(List.OrderBy(item => item.PESEL));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię i nazwisko", "Imię", "Nazwisko", "Pesel", "Login", "Telefon", "Miasto", "Kod pocztowy", "Ulica" };
        }
        public override void Find()
        {
            if (FindField == "Imię")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "Imię i nazwisko")
            {
                string[] words = FindTextBox.Split(' ');
                if (words.Length < 2) return;
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(words[0]) && item.Nazwisko != null && item.Nazwisko.StartsWith(words[1])));
            }
            if (FindField == "Pesel")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.PESEL != null && item.PESEL.StartsWith(FindTextBox)));
            if (FindField == "Login")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Login != null && item.Login.StartsWith(FindTextBox)));
            if (FindField == "Telefon")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.AdresPracownikaMiasto != null && item.AdresPracownikaMiasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.AdresPracownikaKodPocztowy != null && item.AdresPracownikaKodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<PracownikForAllView>(List.Where(item => item.AdresPracownikaUlica != null && item.AdresPracownikaUlica.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
