namespace Starwars.Core.Services
{
    public class Service1
    {
        public Service1()
        {
        }

        public string Method1()
        {
            var service2 = new Service2();
            return $"Hello from Service1!{service2.Method2()}";
        }
    }
}
