namespace ReactiveAkkaAPI.Messages
{
    public class VocalGreeting
    {
        private readonly string _greeting;

        public string Greeting => _greeting;

        public VocalGreeting(string greeting)
        {
            _greeting = greeting;
        }
    }
}
