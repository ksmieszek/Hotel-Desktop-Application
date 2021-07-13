using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using MVVMFirma.Helper;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using GalaSoft.MvvmLight.Messaging;

namespace MVVMFirma.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Fields
        //to jest kolekcja elementow menu okna lewego
        private ReadOnlyCollection<CommandViewModel> _Commands;
        //to jest kolekcja wszystkich zakladek projektu
        private ObservableCollection<WorkspaceViewModel> _Workspaces;
        #endregion

        #region Commands
        private BaseCommand _ShowRaportRestauracjiCommand;
        public ICommand ShowRaportRestauracjiCommand
        {
            get
            {
                if (_ShowRaportRestauracjiCommand == null)
                    _ShowRaportRestauracjiCommand = new BaseCommand(() => ShowRaportRestauracji());
                return _ShowRaportRestauracjiCommand;
            }
        }
        private BaseCommand _ShowRaportPotrawCommand;
        public ICommand ShowRaportPotrawCommand
        {
            get
            {
                if (_ShowRaportPotrawCommand == null)
                    _ShowRaportPotrawCommand = new BaseCommand(() => ShowRaportPotraw());
                return _ShowRaportPotrawCommand;
            }
        }
        private BaseCommand _ShowRaportRezerwacjiCommand;
        public ICommand ShowRaportRezerwacjiCommand
        {
            get
            {
                if (_ShowRaportRezerwacjiCommand == null)
                    _ShowRaportRezerwacjiCommand = new BaseCommand(() => ShowRaportRezerwacji());
                return _ShowRaportRezerwacjiCommand;
            }
        }
        private BaseCommand _ShowGrafikCommand;
        public ICommand ShowGrafikCommand
        {
            get
            {
                if (_ShowGrafikCommand == null)
                    _ShowGrafikCommand = new BaseCommand(() => ShowGrafik());
                return _ShowGrafikCommand;
            }
        }
        private BaseCommand _ShowStatystykiCommand;
        public ICommand ShowStatystykiCommand
        {
            get
            {
                if (_ShowStatystykiCommand == null)
                    _ShowStatystykiCommand = new BaseCommand(() => ShowStatystyki());
                return _ShowStatystykiCommand;
            }
        }
        private BaseCommand _ShowEmailCommand;
        public ICommand ShowEmailCommand
        {
            get
            {
                if (_ShowEmailCommand == null)
                    _ShowEmailCommand = new BaseCommand(() => ShowEmail());
                return _ShowEmailCommand;
            }
        }
        
        public ReadOnlyCollection<CommandViewModel> Commands
        {
            get
            {
                if (_Commands == null)
                {
                    List<CommandViewModel> cmds = this.CreateCommands();
                    _Commands = new ReadOnlyCollection<CommandViewModel>(cmds);
                }
                return _Commands;
            }
        }
        private BaseCommand _NewStanowiskoCommand;
        public ICommand NewStanowiskoCommand
        {
            get
            {
                if (_NewStanowiskoCommand == null)
                    _NewStanowiskoCommand = new BaseCommand(() => CreateStanowisko());
                return _NewStanowiskoCommand;
            }
        }
        private BaseCommand _NewRodzajPotrawaCommand;
        public ICommand NewRodzajPotrawaCommand
        {
            get
            {
                if (_NewRodzajPotrawaCommand == null)
                    _NewRodzajPotrawaCommand = new BaseCommand(() => CreateRodzajPotrawa());
                return _NewRodzajPotrawaCommand;
            }
        }
        private BaseCommand _NewRodzajNapojCommand;
        public ICommand NewRodzajNapojCommand
        {
            get
            {
                if (_NewRodzajNapojCommand == null)
                    _NewRodzajNapojCommand = new BaseCommand(() => CreateRodzajNapoj());
                return _NewRodzajNapojCommand;
            }
        }
        private BaseCommand _NewStatusPokojuCommand;
        public ICommand NewStatusPokojuCommand
        {
            get
            {
                if (_NewStatusPokojuCommand == null)
                    _NewStatusPokojuCommand = new BaseCommand(() => CreateStatusPokoju());
                return _NewStatusPokojuCommand;
            }
        }
        private BaseCommand _NewSposobPlatnosciCommand;
        public ICommand NewSposobPlatnosciCommand
        {
            get
            {
                if (_NewSposobPlatnosciCommand == null)
                    _NewSposobPlatnosciCommand = new BaseCommand(() => CreateSposobPlatnosci());
                return _NewSposobPlatnosciCommand;
            }
        }
        private BaseCommand _NewRodzajKlientaCommand;
        public ICommand NewRodzajKlientaCommand
        {
            get
            {
                if (_NewRodzajKlientaCommand == null)
                    _NewRodzajKlientaCommand = new BaseCommand(() => CreateRodzajKlienta());
                return _NewRodzajKlientaCommand;
            }
        }
        private BaseCommand _NewAdresCommand;
        public ICommand NewAdresCommand
        {
            get
            {
                if (_NewAdresCommand == null)
                    _NewAdresCommand = new BaseCommand(() => CreateAdres());
                return _NewAdresCommand;
            }
        }
        private BaseCommand _NewPracownikCommand;
        public ICommand NewPracownikCommand
        {
            get
            {
                if (_NewPracownikCommand == null)
                    _NewPracownikCommand = new BaseCommand(() => CreatePracownik());
                return _NewPracownikCommand;
            }
        }

        private BaseCommand _NewFakturaCommand;
        public ICommand NewFakturaCommand
        {
            get
            {
                if (_NewFakturaCommand == null)
                    _NewFakturaCommand = new BaseCommand(() => CreateFaktura());
                return _NewFakturaCommand;
            }
        }
        private BaseCommand _NewKlientCommand;
        public ICommand NewKlientCommand
        {
            get
            {
                if (_NewKlientCommand == null)
                    _NewKlientCommand = new BaseCommand(() => CreateKlient());
                return _NewKlientCommand;
            }
        }
        private BaseCommand _NewNapojCommand;
        public ICommand NewNapojCommand
        {
            get
            {
                if (_NewNapojCommand == null)
                    _NewNapojCommand = new BaseCommand(() => CreateNapoj());
                return _NewNapojCommand;
            }
        }
        private BaseCommand _NewPokojCommand;
        public ICommand NewPokojCommand
        {
            get
            {
                if (_NewPokojCommand == null)
                    _NewPokojCommand = new BaseCommand(() => CreatePokoj());
                return _NewPokojCommand;
            }
        }
        private BaseCommand _NewPosilekCommand;
        public ICommand NewPosilekCommand
        {
            get
            {
                if (_NewPosilekCommand == null)
                    _NewPosilekCommand = new BaseCommand(() => CreatePosilek());
                return _NewPosilekCommand;
            }
        }
        private BaseCommand _NewPotrawaCommand;
        public ICommand NewPotrawaCommand
        {
            get
            {
                if (_NewPotrawaCommand == null)
                    _NewPotrawaCommand = new BaseCommand(() => CreatePotrawa());
                return _NewPotrawaCommand;
            }
        }
        private BaseCommand _NewPozycjaFakturyCommand;
        public ICommand NewPozycjaFakturyCommand
        {
            get
            {
                if (_NewPozycjaFakturyCommand == null)
                    _NewPozycjaFakturyCommand = new BaseCommand(() => CreatePozycjaFaktury());
                return _NewPozycjaFakturyCommand;
            }
        }
        private BaseCommand _NewRezerwacjaCommand;
        public ICommand NewRezerwacjaCommand
        {
            get
            {
                if (_NewRezerwacjaCommand == null)
                    _NewRezerwacjaCommand = new BaseCommand(() => CreateRezerwacja());
                return _NewRezerwacjaCommand;
            }
        }
        private BaseCommand _NewStanowiskoPracownikaCommand;
        public ICommand NewStanowiskoPracownikaCommand
        {
            get
            {
                if (_NewStanowiskoPracownikaCommand == null)
                    _NewStanowiskoPracownikaCommand = new BaseCommand(() => CreateStanowiskoPracownika());
                return _NewStanowiskoPracownikaCommand;
            }
        }
        private BaseCommand _NewUslugaCommand;
        public ICommand NewUslugaCommand
        {
            get
            {
                if (_NewUslugaCommand == null)
                    _NewUslugaCommand = new BaseCommand(() => CreateUsluga());
                return _NewUslugaCommand;
            }
        }
        private BaseCommand _ShowStanowiskaCommand;
        public ICommand ShowStanowiskaCommand
        {
            get
            {
                if (_ShowStanowiskaCommand == null)
                    _ShowStanowiskaCommand = new BaseCommand(() => ShowAllStanowiska());
                return _ShowStanowiskaCommand;
            }
        }
        private BaseCommand _ShowRodzajePotrawCommand;
        public ICommand ShowRodzajePotrawCommand
        {
            get
            {
                if (_ShowRodzajePotrawCommand == null)
                    _ShowRodzajePotrawCommand = new BaseCommand(() => ShowAllRodzajePotraw());
                return _ShowRodzajePotrawCommand;
            }
        }
        private BaseCommand _ShowRodzajeNapojowCommand;
        public ICommand ShowRodzajeNapojowCommand
        {
            get
            {
                if (_ShowRodzajeNapojowCommand == null)
                    _ShowRodzajeNapojowCommand = new BaseCommand(() => ShowAllRodzajeNapojow());
                return _ShowRodzajeNapojowCommand;
            }
        }
        private BaseCommand _ShowStatusyPokojowCommand;
        public ICommand ShowStatusyPokojowCommand
        {
            get
            {
                if (_ShowStatusyPokojowCommand == null)
                    _ShowStatusyPokojowCommand = new BaseCommand(() => ShowAllStatusyPokojow());
                return _ShowStatusyPokojowCommand;
            }
        }
        private BaseCommand _ShowSposobyPlatnosciCommand;
        public ICommand ShowSposobyPlatnosciCommand
        {
            get
            {
                if (_ShowSposobyPlatnosciCommand == null)
                    _ShowSposobyPlatnosciCommand = new BaseCommand(() => ShowAllSposobyPlatnosci());
                return _ShowSposobyPlatnosciCommand;
            }
        }
        private BaseCommand _ShowRodzajeKlientowCommand;
        public ICommand ShowRodzajeKlientowCommand
        {
            get
            {
                if (_ShowRodzajeKlientowCommand == null)
                    _ShowRodzajeKlientowCommand = new BaseCommand(() => ShowAllRodzajeKlientow());
                return _ShowRodzajeKlientowCommand;
            }
        }
        private BaseCommand _ShowPracownicyCommand;
        public ICommand ShowPracownicyCommand
        {
            get
            {
                if (_ShowPracownicyCommand == null)
                    _ShowPracownicyCommand = new BaseCommand(() => ShowAllPracownicy());
                return _ShowPracownicyCommand;
            }
        }

        private BaseCommand _ShowAdresyCommand;
        public ICommand ShowAdresyCommand
        {
            get
            {
                if (_ShowAdresyCommand == null)
                    _ShowAdresyCommand = new BaseCommand(() => ShowAllAdresy());
                return _ShowAdresyCommand;
            }
        }
        private BaseCommand _ShowFakturyCommand;
        public ICommand ShowFakturyCommand
        {
            get
            {
                if (_ShowFakturyCommand == null)
                    _ShowFakturyCommand = new BaseCommand(() => ShowAllFaktury());
                return _ShowFakturyCommand;
            }
        }
        private BaseCommand _ShowKlienciCommand;
        public ICommand ShowKlienciCommand
        {
            get
            {
                if (_ShowKlienciCommand == null)
                    _ShowKlienciCommand = new BaseCommand(() => ShowAllKlienci());
                return _ShowKlienciCommand;
            }
        }
        private BaseCommand _ShowNapojeCommand;
        public ICommand ShowNapojeCommand
        {
            get
            {
                if (_ShowNapojeCommand == null)
                    _ShowNapojeCommand = new BaseCommand(() => ShowAllNapoje());
                return _ShowNapojeCommand;
            }
        }
        private BaseCommand _ShowPokojeCommand;
        public ICommand ShowPokojeCommand
        {
            get
            {
                if (_ShowPokojeCommand == null)
                    _ShowPokojeCommand = new BaseCommand(() => ShowAllPokoje());
                return _ShowPokojeCommand;
            }
        }
        private BaseCommand _ShowPosilkiCommand;
        public ICommand ShowPosilkiCommand
        {
            get
            {
                if (_ShowPosilkiCommand == null)
                    _ShowPosilkiCommand = new BaseCommand(() => ShowPosilki());
                return _ShowPosilkiCommand;
            }
        }
        private BaseCommand _ShowPotrawyCommand;
        public ICommand ShowPotrawyCommand
        {
            get
            {
                if (_ShowPotrawyCommand == null)
                    _ShowPotrawyCommand = new BaseCommand(() => ShowAllPotrawy());
                return _ShowPotrawyCommand;
            }
        }
        private BaseCommand _ShowPozycjeFakturyCommand;
        public ICommand ShowPozycjeFakturyCommand
        {
            get
            {
                if (_ShowPozycjeFakturyCommand == null)
                    _ShowPozycjeFakturyCommand = new BaseCommand(() => ShowAllPozycjeFaktury());
                return _ShowPozycjeFakturyCommand;
            }
        }
        private BaseCommand _ShowRezerwacjeCommand;
        public ICommand ShowRezerwacjeCommand
        {
            get
            {
                if (_ShowRezerwacjeCommand == null)
                    _ShowRezerwacjeCommand = new BaseCommand(() => ShowAllRezerwacje());
                return _ShowRezerwacjeCommand;
            }
        }
        private BaseCommand _ShowStanowiskaPracownikaCommand;
        public ICommand ShowStanowiskaPracownikaCommand
        {
            get
            {
                if (_ShowStanowiskaPracownikaCommand == null)
                    _ShowStanowiskaPracownikaCommand = new BaseCommand(() => ShowAllStanowiskaPracownika());
                return _ShowStanowiskaPracownikaCommand;
            }
        }
        private BaseCommand _ShowUslugiCommand;
        public ICommand ShowUslugiCommand
        {
            get
            {
                if (_ShowUslugiCommand == null)
                    _ShowUslugiCommand = new BaseCommand(() => ShowAllUslugi());
                return _ShowUslugiCommand;
            }
        }
        
        private List<CommandViewModel> CreateCommands()
        {
            //to jest wlaczenie przy pomocy messengera nasluchiwania na komunikat typu string
            Messenger.Default.Register<string>(this, open);

            return new List<CommandViewModel>
            {

               new CommandViewModel(
                    "Rezerwacje",
                    new BaseCommand(() => this.ShowAllRezerwacje())),

               new CommandViewModel(
                    "Nowy klient",
                    new BaseCommand(() => this.CreateKlient())),

               new CommandViewModel(
                    "Nowy adres",
                    new BaseCommand(() => this.CreateAdres())),

               new CommandViewModel(
                    "Dodaj posiłek",
                    new BaseCommand(() => this.CreatePosilek())),

               new CommandViewModel(
                    "Nowa faktura",
                    new BaseCommand(() => this.CreateFaktura())),
               
            };
        }
        #endregion

        #region Workspaces
        public ObservableCollection<WorkspaceViewModel> Workspaces
        {
            get
            {
                if (_Workspaces == null)
                {
                    _Workspaces = new ObservableCollection<WorkspaceViewModel>();
                    _Workspaces.CollectionChanged += this.OnWorkspacesChanged;
                }
                return _Workspaces;
            }
        }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += this.OnWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= this.OnWorkspaceRequestClose;
        }
        private void OnWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel workspace = sender as WorkspaceViewModel;
            //workspace.Dispos();
            this.Workspaces.Remove(workspace);
        }

        #endregion // Workspaces

        #region Private Helpers
        private void open(string name)
        {
            if (name == "FakturyAdd")
                this.CreateView(new NowaFakturaViewModel());
            if (name == "KlienciAdd")
                this.CreateView(new NowyKlientViewModel());
            if (name == "PokojeAdd")
                this.CreateView(new NowyPokojViewModel());
            if (name == "NapojeAdd")
                this.CreateView(new NowyNapojViewModel());
            if (name == "PosiłkiAdd")
                this.CreateView(new NowyPosilekViewModel());
            if (name == "PotrawyAdd")
                this.CreateView(new NowaPotrawaViewModel());
            if (name == "Pozycje fakturyAdd")
                this.CreateView(new NowaPozycjaFakturyViewModel());
            if (name == "RezerwacjeAdd")
                this.CreateView(new NowaRezerwacjaViewModel());
            if (name == "Stanowiska pracownikaAdd")
                this.CreateView(new NoweStanowiskoPracownikaViewModel());
            if (name == "UsługiAdd")
                this.CreateView(new NowaUslugaViewModel());
            if (name == "AdresyAdd")
                this.CreateView(new NowyAdresViewModel());
            if (name == "StanowiskaAdd")
                this.CreateView(new NoweStanowiskoViewModel());
            if (name == "Rodzaje potrawAdd")
                this.CreateView(new NowyRodzajPotrawViewModel());
            if (name == "Rodzaje napojówAdd")
                this.CreateView(new NowyRodzajNapojowViewModel());
            if (name == "Statusy pokojówAdd")
                this.CreateView(new NowyStatusPokojuViewModel());
            if (name == "Rodzaje płatnościAdd")
                this.CreateView(new NowySposobPlatnosciViewModel());
            if (name == "Rodzaje klientówAdd")
                this.CreateView(new NowyRodzajKlientowViewModel());
            if (name == "PracownicyAdd")
                this.CreateView(new NowyPracownikViewModel());
            if (name == "AdresyShow")
                this.ShowAllAdresy();
            if (name == "PokojeShow")
                this.ShowAllPokoje();
            if (name == "PotrawyShow")
                this.ShowAllPotrawy();
            if (name == "NapojeShow")
                this.ShowAllNapoje();
            if (name == "RezerwacjeShow")
                this.ShowAllRezerwacje();
            if (name == "PosilkiShow")
                this.ShowPosilki();
            if (name == "KlienciShow")
                this.ShowAllKlienci();
            if (name == "FakturyShow")
                this.ShowAllFaktury();
            if (name == "UslugiShow")
                this.ShowAllUslugi();
        }
        private void CreateView(WorkspaceViewModel workspace)
        {
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRezerwacja()
        {
            NowaRezerwacjaViewModel workspace = new NowaRezerwacjaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePokoj()
        {
            NowyPokojViewModel workspace = new NowyPokojViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateKlient()
        {
            NowyKlientViewModel workspace = new NowyKlientViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateNapoj()
        {
            NowyNapojViewModel workspace = new NowyNapojViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePosilek()
        {
            NowyPosilekViewModel workspace = new NowyPosilekViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePotrawa()
        {
            NowaPotrawaViewModel workspace = new NowaPotrawaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePozycjaFaktury()
        {
            NowaPozycjaFakturyViewModel workspace = new NowaPozycjaFakturyViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateStanowiskoPracownika()
        {
            NoweStanowiskoPracownikaViewModel workspace = new NoweStanowiskoPracownikaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateUsluga()
        {
            NowaUslugaViewModel workspace = new NowaUslugaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowRaportRestauracji()
        {
            RaportRestauracjiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is RaportRestauracjiViewModel)
                as RaportRestauracjiViewModel;
            if (workspace == null)
            {
                workspace = new RaportRestauracjiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowRaportPotraw()
        {
            RaportPotrawViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is RaportPotrawViewModel)
                as RaportPotrawViewModel;
            if (workspace == null)
            {
                workspace = new RaportPotrawViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowRaportRezerwacji()
        {
            RaportRezerwacjiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is RaportRezerwacjiViewModel)
                as RaportRezerwacjiViewModel;
            if (workspace == null)
            {
                workspace = new RaportRezerwacjiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowGrafik()
        {
            GrafikViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is GrafikViewModel)
                as GrafikViewModel;
            if (workspace == null)
            {
                workspace = new GrafikViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowStatystyki()
        {
            StatystykiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is StatystykiViewModel)
                as StatystykiViewModel;
            if (workspace == null)
            {
                workspace = new StatystykiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowEmail()
        {
            EmailViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is EmailViewModel)
                as EmailViewModel;
            if (workspace == null)
            {
                workspace = new EmailViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(this.Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(this.Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }
        private void CreateStanowisko()
        {
            NoweStanowiskoViewModel workspace = new NoweStanowiskoViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRodzajNapoj()
        {
            NowyRodzajNapojowViewModel workspace = new NowyRodzajNapojowViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRodzajPotrawa()
        {
            NowyRodzajPotrawViewModel workspace = new NowyRodzajPotrawViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateStatusPokoju()
        {
            NowyStatusPokojuViewModel workspace = new NowyStatusPokojuViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateSposobPlatnosci()
        {
            NowySposobPlatnosciViewModel workspace = new NowySposobPlatnosciViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateRodzajKlienta()
        {
            NowyRodzajKlientowViewModel workspace = new NowyRodzajKlientowViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateAdres()
        {
            NowyAdresViewModel workspace = new NowyAdresViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreatePracownik()
        {
            NowyPracownikViewModel workspace = new NowyPracownikViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void CreateFaktura()
        {
            NowaFakturaViewModel workspace = new NowaFakturaViewModel();
            this.Workspaces.Add(workspace);
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStatusyPokojow()
        {
            WszystkieStatusyPokojuViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStatusyPokojuViewModel)
                as WszystkieStatusyPokojuViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStatusyPokojuViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajeNapojow()
        {
            WszystkieRodzajeNapojowViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeNapojowViewModel)
                as WszystkieRodzajeNapojowViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeNapojowViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajePotraw()
        {
            WszystkieRodzajePotrawViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajePotrawViewModel)
                as WszystkieRodzajePotrawViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajePotrawViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllSposobyPlatnosci()
        {
            WszystkieSposobyPlatnosciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieSposobyPlatnosciViewModel)
                as WszystkieSposobyPlatnosciViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieSposobyPlatnosciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRodzajeKlientow()
        {
            WszystkieRodzajeKlientowViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRodzajeKlientowViewModel)
                as WszystkieRodzajeKlientowViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRodzajeKlientowViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStanowiska()
        {
            WszystkieStanowiskaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStanowiskaViewModel)
                as WszystkieStanowiskaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStanowiskaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPracownicy()
        {
            WszyscyPracownicyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyPracownicyViewModel)
                as WszyscyPracownicyViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyPracownicyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllAdresy()
        {
            WszystkieAdresyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieAdresyViewModel)
                as WszystkieAdresyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieAdresyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllFaktury()
        {
            WszystkieFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieFakturyViewModel)
                as WszystkieFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllKlienci()
        {
            WszyscyKlienciViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszyscyKlienciViewModel)
                as WszyscyKlienciViewModel;
            if (workspace == null)
            {
                workspace = new WszyscyKlienciViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllNapoje()
        {
            WszystkieNapojeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieNapojeViewModel)
                as WszystkieNapojeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieNapojeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPokoje()
        {
            WszystkiePokojeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePokojeViewModel)
                as WszystkiePokojeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePokojeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowPosilki()
        {
            WszystkiePosilkiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePosilkiViewModel)
                as WszystkiePosilkiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePosilkiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPotrawy()
        {
            WszystkiePotrawyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePotrawyViewModel)
                as WszystkiePotrawyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePotrawyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllPozycjeFaktury()
        {
            WszystkiePozycjeFakturyViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkiePozycjeFakturyViewModel)
                as WszystkiePozycjeFakturyViewModel;
            if (workspace == null)
            {
                workspace = new WszystkiePozycjeFakturyViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllRezerwacje()
        {
            WszystkieRezerwacjeViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieRezerwacjeViewModel)
                as WszystkieRezerwacjeViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieRezerwacjeViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllStanowiskaPracownika()
        {
            WszystkieStanowiskaPracownikaViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieStanowiskaPracownikaViewModel)
                as WszystkieStanowiskaPracownikaViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieStanowiskaPracownikaViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        private void ShowAllUslugi()
        {
            WszystkieUslugiViewModel workspace =
                this.Workspaces.FirstOrDefault(vm => vm is WszystkieUslugiViewModel)
                as WszystkieUslugiViewModel;
            if (workspace == null)
            {
                workspace = new WszystkieUslugiViewModel();
                this.Workspaces.Add(workspace);
            }
            this.SetActiveWorkspace(workspace);
        }
        #endregion
    }
}
