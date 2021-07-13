using MVVMFirma.Models.Entities;
using MVVMFirma.Models.EntitiesForView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class RezerwacjaB : DatabaseClass//dziedziczy po databaseclass bo bedzie uzywala bazy danych
    {
        #region Constructor
        public RezerwacjaB(HotelEntities hotelEntities)
            : base(hotelEntities)
        {
        }
        #endregion
        #region ViewFunction
        public IQueryable<ComboBoxKeyAndValue> GetPokojeComboBoxItems()
        {
            return
                (
                    from rezerwacja in hotelEntities.Rezerwacje
                    select new ComboBoxKeyAndValue
                    {
                        Key = rezerwacja.Pokoje.IdPokoju,
                        Value = "Numer pokoju: " + rezerwacja.Pokoje.NumerPokoju.ToString() +" ("+ rezerwacja.Pokoje.Rodzaj +") - " + rezerwacja.Brutto + "zł za dobę", 
                    }
                ).ToList().AsQueryable();
        }
        #endregion
    }
}
