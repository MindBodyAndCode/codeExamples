using TicketManagement.Domain.SeedWork;

namespace TicketManagement.Domain.Aggregates.TicketAggregate
{
    public class TicketState : Enumeration
    {
        public static TicketState BUILDING = new TicketState(0, "Construyendo");
        public static TicketState PENDING = new TicketState(1, "Pendiente");
        public static TicketState PAID = new TicketState(2, "Pagado");
        public static TicketState CANCELLED = new TicketState(3, "Cancelado");

        private TicketState(int id, string name) : base(id, name)
        {
        }
    }
}
