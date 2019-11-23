using Akka.Actor;

namespace ReactiveAkkaAPI.Actors
{
    public class StashingActor : UntypedActor, IWithUnboundedStash
    {
        public IStash Stash { get; set; }

        protected override void OnReceive(object message)
        {
            throw new System.NotImplementedException();
        }
    }
}
