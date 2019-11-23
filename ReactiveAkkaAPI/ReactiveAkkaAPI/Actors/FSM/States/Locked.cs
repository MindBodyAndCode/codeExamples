namespace ReactiveAkkaAPI.Actors.FSM.States
{
    public class Locked : ITurnstileState
    {
        public static readonly Locked Instance = new Locked();
    }
}
