using Akka.Actor;
using ReactiveAkkaAPI.Messages;

namespace ReactiveAkkaAPI.Actors
{
    // Representation of a FSM (Finite State Machine) using actors model.
    // OJO! Existe otra forma más elegante de hacer una FSM. Se encuentra en la carpeta FSM
    public class TurnstileActor : ReceiveActor
    {
        public TurnstileActor()
        {
            Become(Locked); // DEFAULT STATE
        }

        void Locked() // LOCKED STATE
        {
            // Do some logic...
            Receive<TicketValidatedMessage>(msg => Become(UnLocked)); // Cambio de estado
            Receive<BarrierPushedMessage>(msg => { }); // Ignore
        }

        void UnLocked() // UNLOCKED STATE
        {
            // Do some logic...
            Receive<TicketValidatedMessage>(msg => { }); // Ignore
            Receive<BarrierPushedMessage>(msg => Become(Locked)); // Cambio de estado
        }

    }
}
