using TicketManagement.Domain.SeedWork;

namespace TicketManagement.Domain.Aggregates.TicketAggregate
{
    public class Product : Entity<int>
    {

        public string Name { get; private set; }

        public double Price { get; private set; }
        public double Discount { get; private set; }
        public double FinalPrice => Discount > 0 && Discount < 1 ? Discount * Price : Price;

        public void ApplyDiscount(double discount)
        {
            Discount = discount;
        }

    }
}
