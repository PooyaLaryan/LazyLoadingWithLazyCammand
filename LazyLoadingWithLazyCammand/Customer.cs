using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoadingWithLazyCammand
{
    internal class Customer
    {
        private readonly Lazy<IEnumerable<Order>> _orders;

        public Customer()
        {
            _orders = new Lazy<IEnumerable<Order>>(LoadOrders);
        }

        private IEnumerable<Order> LoadOrders()
        {
            List<Order> orders = new List<Order>();
            Parallel.ForEach(Enumerable.Range(0, 5), x => {
                orders.Add(new Order
                {
                    Id = x
                });
            });

            return orders;
        }

        public bool IsValueCreated => _orders.IsValueCreated;
        public IEnumerable<Order> GetOrders => _orders.Value;   
    }

    internal class Order
    {
        public int Id { get; set; }
    }
}
