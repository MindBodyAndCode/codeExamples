using System;
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
        public double CashReceived { get; private set; }
        public double Change { get; private set; }

        public TicketState Status { get; private set; }

        public IEnumerable<Product> Products { get; private set; }

        internal Ticket()
        {
            Status = TicketState.PENDING;
            Products = new List<Product>();
        }

        public void ApplyDiscountInAllProducts(double discount)
        {
            //TODO: Specification pattern

            if (Status != TicketState.BUILDING)
                throw new Exception("Ticket must be in BUILDING state to admint discounts");

            if (discount <= 0)
                throw new Exception(); // TODO: Throw new domain exception

            if (discount >= 1)
                throw new Exception(); // TODO: Throw new domain exception

            foreach (var product in Products)
            {
                product.ApplyDiscount(discount);
            }
        }

        public void ApplyDiscount(double discount)
        {
            //TODO: Specification pattern

            if (Status != TicketState.BUILDING)
                throw new Exception("Ticket must be in BUILDING state to admint discounts");

            if (discount <= 0)
                throw new Exception(); // TODO: Throw new domain exception

            if (discount >= 1)
                throw new Exception(); // TODO: Throw new domain exception

            GlobalDiscount = discount;
        }

        public void PayTicket(double cash)
        {
            if (Status != TicketState.PENDING)
                throw new Exception("Ticket must be in PENDING state to admin paiments");

            if (cash >= CalculatedTotalPrice)
            {
                CashReceived += cash;
                if (CashReceived >= CalculatedTotalPrice)
                {
                    Change = CashReceived - CalculatedTotalPrice;
                    Status = TicketState.PAID;
                }
            }
        }

        // TODO: ADD AND REMOVE PRODUCTS
    }
}
