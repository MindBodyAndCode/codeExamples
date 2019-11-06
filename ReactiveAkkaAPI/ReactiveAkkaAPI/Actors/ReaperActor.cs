using Akka.Actor;
using System.Collections.Generic;

namespace ReactiveAkkaAPI.Actors
{
    // Implementation of Reaper Pattern
    public class ReaperActor : ReceiveActor
    {
        private readonly HashSet<IActorRef> _watchedActors;

        public ReaperActor(HashSet<IActorRef> watchedActors)
        {
            _watchedActors = watchedActors;

            Receive<Terminated>(terminated =>
            {
                // Elimina la referncia del actor observado (Ya nos ha mandado el mensaje Terminated)
                _watchedActors.Remove(terminated.ActorRef);
                if (_watchedActors.Count == 0) // Cuando ya tiene más actores a los que esperar el mensaje
                {                               // Podemos asegurar que el trabajo puede ser finalizado 
                    Context.System.Terminate(); // De forma segura
                }
            });
        }

        protected override void PreStart()
        {
            // Stay watching for receive Terminated message from all actors subscribed
            foreach (var actor in _watchedActors)
            {
                Context.Watch(actor);
            }
        }


    }
}
