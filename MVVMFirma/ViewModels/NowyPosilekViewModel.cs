using GalaSoft.MvvmLight.Messaging;
using MVVMFirma.Helper;
using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace MVVMFirma.ViewModels
{
    public class NowyPosilekViewModel : JedenViewModel<Posilki>
    {
        #region Fields
        private BaseCommand _ShowPotrawy;
        private BaseCommand _ShowNapoje;
        #endregion
        #region Constructor
        public NowyPosilekViewModel()
        {
            base.DisplayName = "Posilek";
            item = new Posilki();
            DataZamowienia = DateTime.Now;
            Messenger.Default.Register<PotrawyForAllView>(this, getWybranaPotrawa);
            Messenger.Default.Register<NapojForAllView>(this, getWybranyNapoj);
        }
        #endregion
        #region Commands
        public ICommand ShowPotrawy
        {
            get
            {
                if (_ShowPotrawy == null)
                    _ShowPotrawy = new BaseCommand(() => Messenger.Default.Send("PotrawyShow"));

                return _ShowPotrawy;
            }
        }
        public ICommand ShowNapoje
        {
            get
            {
                if (_ShowNapoje == null)
                    _ShowNapoje = new BaseCommand(() => Messenger.Default.Send("NapojeShow"));

                return _ShowNapoje;
            }
        }
        #endregion
        #region Properties
        public int IdPosilku
        {
            get
            {
                return item.IdPosilku;
            }
            set
            {
                if (item.IdPosilku != value)
                {
                    item.IdPosilku = value;
                    base.OnPropertyChanged(() => IdPosilku);
                }
            }
        }
        public decimal? Brutto
        {
            get
            {
                return item.Brutto;
            }
            set
            {
                if (item.Brutto != value)
                {
                    item.Brutto = value;
                    base.OnPropertyChanged(() => Brutto);
                }
            }
        }
        public int? IloscPotrawy
        {
            get
            {
                return item.IloscPotrawy;
            }
            set
            {
                if (item.IloscPotrawy != value)
                {
                    item.IloscPotrawy = value;
                    base.OnPropertyChanged(() => IloscPotrawy);
                }
            }
        }
        public int? IloscNapoju
        {
            get
            {
                return item.IloscNapoju;
            }
            set
            {
                if (item.IloscNapoju != value)
                {
                    item.IloscNapoju = value;
                    base.OnPropertyChanged(() => IloscNapoju);
                }
            }
        }
        public double? Rabat
        {
            get
            {
                return item.Rabat;
            }
            set
            {
                if (item.IloscNapoju != value)
                {
                    item.Rabat = double.Parse(item.IloscNapoju.ToString());
                    base.OnPropertyChanged(() => IloscNapoju);
                }
            }
        }
        public double? VAT
        {
            get
            {
                return item.VAT;
            }
            set
            {
                if (item.VAT != value)
                {
                    item.VAT = value;
                    base.OnPropertyChanged(() => VAT);
                }
            }
        }
        public string Opis
        {
            get
            {
                return item.Opis;
            }
            set
            {
                if (item.Opis != value)
                {
                    item.Opis = value;
                    base.OnPropertyChanged(() => Opis);
                }
            }
        }
        public string Nazwa
        {
            get
            {
                return item.Nazwa;
            }
            set
            {
                if (item.Nazwa != value)
                {
                    item.Nazwa = value;
                    base.OnPropertyChanged(() => Nazwa);
                }
            }
        }
        public DateTime? DataZamowienia
        {
            get
            {
                return item.DataZamowienia;
            }
            set
            {
                if (item.DataZamowienia != value)
                {
                    item.DataZamowienia = value;
                    base.OnPropertyChanged(() => DataZamowienia);
                }
            }
        }
        public IQueryable<ComboBoxKeyAndValue> PotrawaComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from potrawa in hotelEntities.Potrawy
                        select new ComboBoxKeyAndValue
                        {
                            Key = potrawa.IdPotrawy,
                            Value = potrawa.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public IQueryable<ComboBoxKeyAndValue> NapojComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from napoj in hotelEntities.Napoje
                        select new ComboBoxKeyAndValue
                        {
                            Key = napoj.IdNapoju,
                            Value = napoj.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        public int? IdPotrawy
        {
            get
            {
                return item.IdPotrawy;
            }
            set
            {
                if (item.IdPotrawy != value)
                {
                    item.IdPotrawy = value;
                    base.OnPropertyChanged(() => IdPotrawy);
                }
            }
        }
        public int? IdNapoju
        {
            get
            {
                return item.IdNapoju;
            }
            set
            {
                if (item.IdNapoju != value)
                {
                    item.IdNapoju = value;
                    base.OnPropertyChanged(() => IdNapoju);
                }
            }
        }
        private string _PotrawaNazwa;
        public string PotrawaNazwa
        {
            get
            {
                return _PotrawaNazwa;
            }
            set
            {
                if (_PotrawaNazwa != value)
                {
                    _PotrawaNazwa = value;
                    base.OnPropertyChanged(() => PotrawaNazwa);
                }
            }
        }
        private string _NapojNazwa;
        public string NapojNazwa
        {
            get
            {
                return _NapojNazwa;
            }
            set
            {
                if (_NapojNazwa != value)
                {
                    _NapojNazwa = value;
                    base.OnPropertyChanged(() => NapojNazwa);
                }
            }
        }
        private string _NapojCena;
        public string NapojCena
        {
            get
            {
                return _NapojCena;
            }
            set
            {
                if (_NapojCena != value)
                {
                    _NapojCena = value;
                    base.OnPropertyChanged(() => NapojCena);
                }
            }
        }
        private string _PotrawaCena;
        public string PotrawaCena
        {
            get
            {
                return _PotrawaCena;
            }
            set
            {
                if (_PotrawaCena != value)
                {
                    _PotrawaCena = value;
                    base.OnPropertyChanged(() => PotrawaCena);
                }
            }
        }
        #endregion
        #region Helpers
        private void getWybranaPotrawa(PotrawyForAllView potrawa)
        {
            IdPotrawy = potrawa.IdPotrawy;
            PotrawaNazwa = potrawa.Nazwa;
            PotrawaCena = potrawa.Cena.ToString();
        }
        private void getWybranyNapoj(NapojForAllView napoj)
        {
            IdNapoju = napoj.IdNapoju;
            NapojNazwa = napoj.Nazwa;
            NapojCena = napoj.Cena.ToString();
        }
        public override void Save()
        {
            hotelEntities.Posilki.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
