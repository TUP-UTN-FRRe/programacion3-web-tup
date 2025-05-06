namespace Starwars.Core.Services
{
    public class Service2
    {
        public Service2()
        {
        }

        public string Method2()
        {
            var service4 = new Service4();
            return $" ,from Service2!{service4.Method4()}";
        }
    }
}
