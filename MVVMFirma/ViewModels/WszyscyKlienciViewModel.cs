using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class WszyscyKlienciViewModel : WszystkieViewModel<KlientForAllView>
    {
        #region Properties
        private KlientForAllView _WybranyKlient;
        public KlientForAllView WybranyKlient
        {
            get
            {
                return _WybranyKlient;
            }
            set
            {
                if (_WybranyKlient != value)
                {
                    _WybranyKlient = value;
                    Messenger.Default.Send(_WybranyKlient);
                    OnRequestClose();
                }
            }
        }
        #endregion
        #region Constructor
        public WszyscyKlienciViewModel()
        {
            base.DisplayName = "Klienci";
        }
        #endregion
        #region Helpers
        public override void load()
        {
            List = new ObservableCollection<KlientForAllView>
                (
                    from klient in hotelEntities.Klienci 
                    select new KlientForAllView
                    {
                        Nazwa = klient.Imie + " " + klient.Nazwisko,
                        Imie = klient.Imie,
                        Nazwisko = klient.Nazwisko,
                        DrugieImie = klient.DrugieImie,
                        Telefon = klient.Telefon,
                        E_mail = klient.E_mail,
                        PESEL = klient.PESEL,
                        Plec = klient.Plec,
                        Firma = klient.Firma,
                        NIP = klient.NIP,
                        REGON = klient.REGON,
                        RodzajKlientaNazwa = klient.RodzajeKlientow.Nazwa,
                        AdresMiasto = klient.Adresy.Miasto,
                        AdresKodPocztowy = klient.Adresy.KodPocztowy,
                        AdresUlica = klient.Adresy.Ulica,
                        AdresNrDomu = klient.Adresy.NumerBudynku,
                        AdresNrLokalu = klient.Adresy.NumerLokalu,
                    }
                );
        }
        #endregion Helpers
        #region Sort and Find
        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Firma", "NIP", "REGON" };
        }
        public override void Sort()
        {
            if (SortField == "Firma")
                List = new ObservableCollection<KlientForAllView>(List.OrderByDescending(item => item.Firma));
            if (SortField == "NIP")
                List = new ObservableCollection<KlientForAllView>(List.OrderByDescending(item => item.NIP));
            if (SortField == "REGON")
                List = new ObservableCollection<KlientForAllView>(List.OrderByDescending(item => item.REGON));
        }
        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Imię i nazwisko", "Imię", "Nazwisko", "Pesel", "Telefon", "E-mail",  "Firma", "NIP", "REGON" };
        }

        public override void Find()
        {
            if (FindField == "Imię i nazwisko")
            {
                string[] words = FindTextBox.Split(' ');
                if (words.Length < 2) return;
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(words[0]) && item.Nazwisko != null && item.Nazwisko.StartsWith(words[1])));
            }
            if (FindField == "Imię")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Imie != null && item.Imie.StartsWith(FindTextBox)));
            if (FindField == "Nazwisko")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Nazwisko != null && item.Nazwisko.StartsWith(FindTextBox)));
            if (FindField == "Telefon")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Telefon != null && item.Telefon.StartsWith(FindTextBox)));
            if (FindField == "E-mail")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.E_mail != null && item.E_mail.StartsWith(FindTextBox)));
            if (FindField == "Pesel")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.PESEL != null && item.PESEL.StartsWith(FindTextBox)));
            if (FindField == "Firma")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.Firma != null && item.Firma.StartsWith(FindTextBox)));
            if (FindField == "NIP")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.NIP != null && item.NIP.StartsWith(FindTextBox)));
            if (FindField == "REGON")
                List = new ObservableCollection<KlientForAllView>(List.Where(item => item.REGON != null && item.REGON.StartsWith(FindTextBox)));
        }
        #endregion
    }
}
