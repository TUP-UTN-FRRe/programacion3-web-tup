using Starwars.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starwars.Core.Services.Tests
{
    public class Service2Dummy : IService2
    {
        public string Method2()
        {
            return " ,from Service2! ,from Service4! ,from Service5! ,from Service6!";
        }
    }
}
