namespace Starwars.Core.Services
{
    public class Service1
    {
        private Service2 _service2;

        public Service1(Service2 service2)
        {
            _service2 = service2;
        }

        public string Method1()
        {
            //var service2 = new Service2();
            return $"Hello from Service1!{_service2.Method2()}";
        }
    }
}
