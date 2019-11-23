using Akka.Actor;
using ReactiveAkkaAPI.Actors.FSM.Data;
using ReactiveAkkaAPI.Actors.FSM.States;
using ReactiveAkkaAPI.Messages;
using System;

namespace ReactiveAkkaAPI.Actors.FSM
{
    public class TurnstileStateMachine : FSM<ITurnstileState, ITurnstileData>
    {
        public TurnstileStateMachine()
        {
            // Configurar el estado inicial de la FSM
            StartWith(Locked.Instance, new TurnstileData());

            // Si estando la FSM en estado 'Locked' recive un mensaje
            When(Locked.Instance, @event =>
            {
                // Si el mensaje es de Tipo 'TicketValidatedMessage'
                if (@event.FsmEvent is TicketValidatedMessage)
                {
                    Console.WriteLine("Ticket was validated"); // Recomendable aquí no ejecutar las acciones. 
                    // (Mejor en transiciones de estado OnTransition())
                    return GoTo(Unlocked.Instance); // Cambiamos el estado de la FSM a 'UnLocked'
                }

                // Para cualquier otro mensaje, mantiene el estado actual
                return Stay();
            });

            // Si estando la FSM en estado 'Unlockd' recive un mensaje 
            When(Unlocked.Instance, @event =>
            {
                // Si el mensaje es de tipo 'BarrierPushedMessage' ó 
                //  StateTimeout (Mensaje por defecto autoenviado cuando se configura un timeout)
                if (@event.FsmEvent is BarrierPushedMessage ||
                    @event.FsmEvent is StateTimeout)
                {
                    Console.WriteLine("User pushed barrier"); // Recomendable aquí no ejecutar las acciones. 
                    // (Mejor en transiciones de estado OnTransition())
                    return GoTo(Locked.Instance); // Cambiamos el estado de la FSM a 'Locked'
                }
                // Para cualquier otro mensaje, mantiene el estado actual
                return Stay();

            }, TimeSpan.FromSeconds(10.0)); // Configurado con un timeout (Evitar el estado infinito)

            OnTransition(OnTransition); // Confiuración de acciones en transición entre estados

            Initialize(); // Inicializa el actor, puede recibir mensajes en éste punto
        }

        private void OnTransition(ITurnstileState prevState, ITurnstileState newState)
        {
            if (prevState is Locked && newState is Unlocked)
            {
                // Acción de UnLock!!
            }
            else if (prevState is Unlocked && newState is Locked)
            {
                // Acción de Lock!!
            }
        }
    }
}
