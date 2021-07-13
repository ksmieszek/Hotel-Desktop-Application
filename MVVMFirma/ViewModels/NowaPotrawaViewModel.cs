using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.ViewModels
{
    public class NowaPotrawaViewModel : JedenViewModel<Potrawy>
    {
        #region Constructor
        public NowaPotrawaViewModel()
        {
            base.DisplayName = "Potrawa";
            item = new Potrawy();
        }
        #endregion
        #region Properties
        public int IdPotrawy
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
        public string Sklad
        {
            get
            {
                return item.Sklad;
            }
            set
            {
                if (item.Sklad != value)
                {
                    item.Sklad = value;
                    base.OnPropertyChanged(() => Sklad);
                }
            }
        }
        public decimal? Cena
        {
            get
            {
                return item.Cena;
            }
            set
            {
                if (item.Cena != value)
                {
                    item.Cena = value;
                    base.OnPropertyChanged(() => Cena);
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
        public int? IdRodzajuPotrawy
        {
            get
            {
                return item.IdRodzajuPotrawy;
            }
            set
            {
                if (item.IdRodzajuPotrawy != value)
                {
                    item.IdRodzajuPotrawy = value;
                    base.OnPropertyChanged(() => IdRodzajuPotrawy);
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
        public IQueryable<ComboBoxKeyAndValue> RodzajPotrawyComboBoxItems//uzywamy jezeli musimy rozpoznac po kilku polach
        {
            get
            {
                return
                    (
                        from rodzaj in hotelEntities.RodzajePotraw
                        select new ComboBoxKeyAndValue
                        {
                            Key = rodzaj.IdRodzajuPotrawy,
                            Value = rodzaj.Nazwa
                        }
                    ).ToList().AsQueryable();
            }
        }
        #endregion
        #region Helpers
        public override void Save()
        {
            hotelEntities.Potrawy.Add(item);
            hotelEntities.SaveChanges();
        }
        #endregion
    }
}
