using Northwind.BLL.DTOs;
using Northwind.BLL.Repositories;
using Northwind.DAL.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.BLL.Services
{
    public class OrderService : IOrderRepository
    {
        private readonly NorthwindContext _northwindContext;

        public OrderService(NorthwindContext northwindContext) 
        {
            _northwindContext = northwindContext;
        }

        public List<OrderDTO> GetOrders()
        {
            // Sql = select ShipCountry,COUNT(ShipCountry) from Orders group by ShipCountry order by 2 desc
            // Linq to Entity
            var orders = _northwindContext.Orders
                .GroupBy(x => x.ShipCountry)
                .Select(y => new OrderDTO
                {
                    ShipCountry = y.Key,
                    OrderCount = y.Count()
                })
                .OrderByDescending(z => z.OrderCount).ToList();

            return orders;
        }
    }
}