using PrzykladoweKolokwium.DTOs.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrzykladoweKolokwium.Service
{
    public interface IDbService
    {
        public IEnumerable GetOrders(string name);

        public string AddOrder(int id, AddOrderReq);
    }
}
