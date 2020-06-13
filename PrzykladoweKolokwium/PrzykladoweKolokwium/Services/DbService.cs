using PrzykladoweKolokwium.DTOs.Requests;
using PrzykladoweKolokwium.Exceptions;
using PrzykladoweKolokwium.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Service
{
    public class DbService : IDbService
    {
        private readonly s17180Context dbContext;
        public DbService(s17180Context dbContext)
        {
            this.dbContext = dbContext;
        }

        public string AddOrder(int id, AddOrderReq order)
        {

            var clientId = dbContext.Klient
              .Where(i => i.IdKlient == id)
              .First();

            if(clientId == null)
            {
                throw new AppException("CLIENT IS NOT EXISTS");
            }

            foreach (var wyrob in order.wyroby)
            {
                var res = dbContext.WyrobCokierniczy.First(e => e.Nazwa.Equals(order.wyroby));
                if (res == null)
                    throw new Exception(order.wyroby + " IS NOT EXISTS!!!!");
            }

            var zam = new Zamowienie
            {
                IdZamowienia = order.IdZamowienia,
                DataPrzyjecia = order.dataPrzyjecia,
                DataRealizacji = order.DataRealizacji,
                KlientIdKlient = id,
                PracownikIdPracownik = order.IdPracownik,
                ZamowienieWyrobCukierniczy = new List<ZamowienieWyrobCukierniczy>()

            };

            foreach(var wyrob in order.wyroby)
            {
                ZamowienieWyrobCukierniczy zam_wyr = new ZamowienieWyrobCukierniczy()
                {
                    IdWyrobuCukierniczego = dbContext.WyrobCokierniczy.First(e => e.Nazwa == wyrob.wyrob).IdWyrobuCukierniczego,
                    IdZamowienia = zam.IdZamowienia,
                    Ilosc = wyrob.ilosc,
                    Uwagi = wyrob.uwagi
                };
                zam.ZamowienieWyrobCukierniczy.Add(zam_wyr);
            }

            dbContext.Zamowienie.Add(zam);
            dbContext.SaveChanges();

            return "order is complete";      
        }

        public IEnumerable GetOrders(string name)
        {
            if (name == null || name.Equals("")) 
            {
                return dbContext.Zamowienie.ToList();
            }

            var clientId = dbContext.Klient
                .Where(n => n.Nazwisko.Equals(name))
                .Select(n => n.IdKlient)
                .First();

            if (clientId == null)
            {
                throw new AppException("CLIENT IS NOT EXISTS");
            }


            var orders = dbContext.Zamowienie
                .Where(z => z.KlientIdKlient == clientId).ToList();

            if (orders == null)
            {
                throw new AppException("ORDERS IS NOT EXISTS");
            }



            return orders;
        }

       
    }
}
