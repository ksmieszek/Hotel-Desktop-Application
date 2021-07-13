using MVVMFirma.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMFirma.Models.BusinessLogic
{
    public class UtargB : DatabaseClass//bo uzywa bazy dancyh
    {
        #region Constructor
        public UtargB(HotelEntities hotelEntities)
            : base(hotelEntities)
        {
        }
        #endregion
        #region BusinessFunction
        public decimal? UtargOkresPokoj(int IdPokoju, DateTime odDaty, DateTime doDaty)
        {
            return
                (
                    from pozycja in hotelEntities.PozycjeFaktury
                    where
                    pozycja.Uslugi.Rezerwacje.Pokoje.IdPokoju == IdPokoju &&
                    pozycja.Faktury.DataWystawienia > odDaty &&
                    pozycja.Faktury.DataWystawienia <= doDaty
                    select
                    pozycja.Uslugi.Rezerwacje.Brutto * pozycja.Ilosc
                ).Sum();
        }

        public decimal? UtargOkresPotrawa(int IdPotrawy, DateTime odDaty, DateTime doDaty)
        {
            return
                (
                    from posilek in hotelEntities.Posilki
                    where
                    posilek.Potrawy.IdPotrawy == IdPotrawy &&
                    posilek.DataZamowienia >= odDaty &&
                    posilek.DataZamowienia <= doDaty
                    select
                    posilek.IloscPotrawy

                ).Sum();
        }
        public decimal? UtargOkresNapoj(int IdRodzajuNapoju, DateTime odDaty, DateTime doDaty)
        {
            return
                (
                    from napoj in hotelEntities.Posilki
                    where
                    napoj.Napoje.RodzajeNapojow.IdRodzajuNapoju == IdRodzajuNapoju &&
                    napoj.DataZamowienia >= odDaty &&
                    napoj.DataZamowienia <= doDaty
                    select
                    napoj.IloscPotrawy * napoj.Napoje.Cena
                ).Sum();
        }
        #endregion
    }
}
