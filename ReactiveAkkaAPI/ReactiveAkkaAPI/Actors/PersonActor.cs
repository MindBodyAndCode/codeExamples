using Akka.Actor;
using ReactiveAkkaAPI.Messages;
using System;

namespace ReactiveAkkaAPI.Actors
{

    public class PersonActor : ReceiveActor
    {
        private int _peopleMeet = 0;

        public PersonActor()
        {
            Receive<VocalGreeting>(x =>
            {
                _peopleMeet++;
                Console.WriteLine("I´ve met {0} people today", _peopleMeet);
            });

            Receive<Wave>(x =>
            {
                Context.Sender.Tell(new VocalGreeting("Hello!"));
                Context.Sender.Tell(new Wave());
            });
        }

        // Redefine Custom SupervisionStrategy (One for One with restarting by Default)
        protected override SupervisorStrategy SupervisorStrategy()
        {
            return new OneForOneStrategy(
                maxNrOfRetries: 10,
                withinTimeRange: TimeSpan.FromMinutes(1.0),
                decider: Decider.From(exception =>
                {
                    if (exception is ArithmeticException)
                        return Directive.Restart; // Reinicia al actor (e hijos) en caso de esta excepción
                    else
                        return Directive.Resume; // Para todas las demás excepciones las ignora
                })
            );

        }
    }

}


