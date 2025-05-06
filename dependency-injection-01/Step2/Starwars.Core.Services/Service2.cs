namespace Starwars.Core.Services
{
    public class Service2
    {
        private Service4 _service4;

        public Service2(Service4 service4)
        {
            _service4 = service4;
        }

        public string Method2()
        {
            //var service4 = new Service4();
            return $" ,from Service2!{_service4.Method4()}";
        }
    }
}
