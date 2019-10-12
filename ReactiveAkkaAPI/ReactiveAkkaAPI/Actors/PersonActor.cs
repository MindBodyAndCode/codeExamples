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


    }

}


