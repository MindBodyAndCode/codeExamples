using System.Collections.Generic;
using System.Linq;
using TicketManagement.Domain.SeedWork;

namespace TicketManagement.Domain.Aggregates.TicketAggregate
{
    public class Ticket : Entity<int>, IAggregateRoot
    {
        public int TicketNumber { get; private set; }

        public double CalculatedTotalPrice => GlobalDiscount > 0 && GlobalDiscount < 1 ? Products.Sum(p => p.FinalPrice) * GlobalDiscount : Products.Sum(p => p.FinalPrice);
        public double GlobalDiscount { get; private set; }
        public double TotalPrice { get; private set; }

        public TicketState Status { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        internal Ticket()
        {
            Products = new List<Product>();
        }

        public void ApplyDiscountInAllProducts(double discount)
        {
            if (discount <= 0)
                throw new System.Exception(); // TODO: Throw new domain exception

            if (discount >= 1)
                throw new System.Exception(); // TODO: Throw new domain exception

            foreach (var product in Products)
            {
                product.ApplyDiscount(discount);
            }
        }

        public void ApplyDiscount(double discount)
        {
            if (discount <= 0)
                throw new System.Exception(); // TODO: Throw new domain exception

            if (discount >= 1)
                throw new System.Exception(); // TODO: Throw new domain exception

            GlobalDiscount = discount;
        }

        // TODO: ADD AND REMOVE PRODUCTS
    }
}
