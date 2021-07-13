using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszystkieStanowiskaPracownikaViewModel : WszystkieViewModel<StanowiskoPracownikaForAllView>
    {
        #region Constructor
        public WszystkieStanowiskaPracownikaViewModel()
        {
            base.DisplayName = "Stanowiska pracownika";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<StanowiskoPracownikaForAllView>
                (
                    from stanowiskoPracownika in hotelEntities.StanowiskaPracownikow 
                    select new StanowiskoPracownikaForAllView
                    {
                        DataOd = stanowiskoPracownika.DataOd,
                        DataDo = stanowiskoPracownika.DataDo,
                        PracownikNazwa = stanowiskoPracownika.Pracownicy.Imie + " " + stanowiskoPracownika.Pracownicy.Nazwisko,
                        PracownikImie = stanowiskoPracownika.Pracownicy.Imie,
                        PracownikNazwisko = stanowiskoPracownika.Pracownicy.Nazwisko,
                        PracownikLogin = stanowiskoPracownika.Pracownicy.Login,
                        PracownikPESEL = stanowiskoPracownika.Pracownicy.PESEL,
                        PracownikMiasto = stanowiskoPracownika.Pracownicy.Adresy.Miasto,
                        PracownikKodPocztowy = stanowiskoPracownika.Pracownicy.Adresy.KodPocztowy,
                        PracownikUlica = stanowiskoPracownika.Pracownicy.Adresy.Ulica,
                        PracownikNumerBudynku = stanowiskoPracownika.Pracownicy.Adresy.NumerBudynku,
                        PracownikNumerLokalu = stanowiskoPracownika.Pracownicy.Adresy.NumerLokalu,
                        StanowiskoNazwa = stanowiskoPracownika.Stanowiska.Nazwa,
                        PracownikTelefon = stanowiskoPracownika.Pracownicy.Telefon,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Data rozpoczęcia(najstarsza)", "Data rozpoczęcia(najnowsza)", "Data zakończenia(najstarsza)", "Data zakończenia(najnowsza)" };
        }
        public override void Sort()
        {
            if (SortField == "Data rozpoczęcia(najstarsza)")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.OrderBy(item => item.DataOd));
            if (SortField == "Data rozpoczęcia(najnowsza)")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.OrderByDescending(item => item.DataOd));

            if (SortField == "Data zakończenia(najstarsza)")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.OrderBy(item => item.DataOd));
            if (SortField == "Data zakończenia(najnowsza)")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.OrderByDescending(item => item.DataOd));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Stanowisko", "Imię i nazwisko", "Imię", "Nazwisko", "Login", "Telefon", "Data rozpoczęcia", "Data zakończenia", "Miasto", "Kod pocztowy", "Ulica" };
        }
        public override void Find()
        {
            if (FindField == "Stanowisko")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.StanowiskoNazwa != null && item.StanowiskoNazwa.StartsWith(FindTextBox)));
            if (FindField == "Imię")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikNazwisko != null && item.PracownikNazwisko.StartsWith(FindTextBox)));
            if (FindField == "Imię i nazwisko")
            {
                string[] words = FindTextBox.Split(' ');
                if (words.Length < 2) return;
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikImie != null && item.PracownikImie.StartsWith(words[0]) && item.PracownikNazwisko != null && item.PracownikNazwisko.StartsWith(words[1])));
            }
            if (FindField == "Login")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikLogin != null && item.PracownikLogin.StartsWith(FindTextBox)));
            if (FindField == "Telefon")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikTelefon != null && item.PracownikTelefon.StartsWith(FindTextBox)));
            if (FindField == "Miasto")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikMiasto != null && item.PracownikMiasto.StartsWith(FindTextBox)));
            if (FindField == "Kod pocztowy")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikKodPocztowy != null && item.PracownikKodPocztowy.StartsWith(FindTextBox)));
            if (FindField == "Ulica")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.PracownikUlica != null && item.PracownikUlica.StartsWith(FindTextBox)));
            if (FindField == "Data rozpoczęcia")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.DataOd != null && System.DateTime.Equals(item.DataOd, DateTime.Parse(FindTextBox))));
            if (FindField == "Data zakończenia")
                List = new ObservableCollection<StanowiskoPracownikaForAllView>(List.Where(item => item.DataDo != null && System.DateTime.Equals(item.DataDo, DateTime.Parse(FindTextBox))));
        }
        #endregion
    }
}
