namespace Starwars.Core.Services
{
    public class Service2
    {
        private Service4 _service4;
        private Service5 _service5;
        private Service6 _service6;

        public Service2(Service4 service4,
                        Service5 service5,
                        Service6 service6)
        {
            _service4 = service4;
            _service5 = service5;
            _service6 = service6;
        }

        //public string Method2()
        //{
        //    //var service4 = new Service4();
        //    return $" ,from Service2!{_service4.Method4()}";
        //}

        public string Method2()
        {
            //var service4 = new Service4();
            return $" ,from Service2!{_service4.Method4()}{_service5.Method5()}{_service6.Method6()}";
        }
    }
}
