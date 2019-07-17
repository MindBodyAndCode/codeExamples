using TicketManagement.Domain.SeedWork;

namespace TicketManagement.Domain.Aggregates.TicketAggregate
{
    public class TicketState : Enumeration
    {
        public static TicketState PENDING = new TicketState(0, "Pendiente");
        public static TicketState PAID = new TicketState(1, "Pagado");
        public static TicketState CANCELLED = new TicketState(2, "Cancelado");

        private TicketState(int id, string name) : base(id, name)
        {
        }
    }
}
