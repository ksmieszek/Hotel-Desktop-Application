using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;



namespace MVVMFirma.ViewModels
{
    //w klasie wszystkie viewmodel beda znajdowaly sie te elementy ktore wystepuja w kazdej klasie obslugujacej kolekcje dowolnych elementow biznesowych
    //a zatem z kalsy wszystkieview model beda dziedziczyly np. wszystkietowaryviewmodel, wszystkiefakturyviewmodel, wszystkiezamowieniaviewmodel
    public abstract class WszystkieViewModel<T> : WorkspaceViewModel
    {
        #region Fields
        //to jest pole odpowiedzialne za polaczenie z baza danych
        protected readonly HotelEntities hotelEntities;
        private BaseCommand _LoadCommand;
        private BaseCommand _AddCommand;
        private BaseCommand _UpdateCommand;
        //w tek kolekcji beda przechowywane wszystkie rekordy z bazy danych
        private ObservableCollection<T> _List;
        private BaseCommand _SortCommand;
        private BaseCommand _FindCommand;
        #endregion Fields

        #region Properties
        public ICommand LoadCommand
        {
            get
            {
                if (_LoadCommand == null)
                {
                    _LoadCommand = new BaseCommand(() => load());
                }
                return _LoadCommand;
            }
        }
        public ICommand AddCommand
        {
            get
            {
                if (_AddCommand == null)
                {
                    _AddCommand = new BaseCommand(() => add());
                }
                return _AddCommand;
            }
        }
        public ICommand UpdateCommand
        {
            get
            {
                if (_UpdateCommand == null)
                {
                    _UpdateCommand = new BaseCommand(() => load());
                }
                return _UpdateCommand;
            }
        }
        public ObservableCollection<T> List
        {
            get
            {
                if (_List == null) load();//jezeku lista jest pusta to wywolujemy metode load
                return _List;
            }
            set
            {
                _List = value;
                OnPropertyChanged(() => List);
            }
        }

        //w tej wlasciwosci zostanie zapisanie po czym sortowac
        public string SortField { get; set; }
        public List<string> SortComboboxItems
        {
            get
            {
                return GetComboboxSortList();
            }
        }
        public ICommand SortCommand
        {
            get
            {
                if (_SortCommand == null)
                    _SortCommand = new BaseCommand(() => Sort());

                return _SortCommand;
            }
        }

        // w tej wlasciwosci bedziemy przechowywac wynik wyboru po czym wyszukiwac z comboboxa
        public string FindField { get; set; }
        public List<string> FindComboboxItems
        {
            get
            {
                return GetComboboxFindList();
            }
        }
        public string FindTextBox { get; set; }
        public ICommand FindCommand
        {
            get
            {
                if (_FindCommand == null)
                    _FindCommand = new BaseCommand(() => Find());

                return _FindCommand;
            }
        }

        #endregion Properties

        #region Constructor
        public WszystkieViewModel()
        {
            hotelEntities = new HotelEntities();
        }
        #endregion Constructor
        
        #region Helpers
        public abstract void load();//metoda load pobierze z bazy wszystkie towary i przypisze je do listy
        private void add()
        {
            Messenger.Default.Send(DisplayName + "Add");
        }
        public abstract void Sort();//ta metoda bedzie okreslala jak sortowac w klasach dziedziczacych
        public abstract List<string> GetComboboxSortList();//po czym sortowac w klasach dziedziczacych
        public abstract void Find();//okresla jak wyszukiwac
        public abstract List<string> GetComboboxFindList();//po czym wyszukiwac i bedzie zdefiniowana w klasach dziedziczacych
        #endregion Helpers
    }
}
