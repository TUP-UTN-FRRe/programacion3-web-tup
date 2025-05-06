using Microsoft.Extensions.DependencyInjection;
using System;

namespace Starwars.Core.Services.Tests
{
    public class Service1Test
    {
        [Fact]
        public void Method1_Test()
        {
            var service4 = new Service4();
            var service2 = new Service2(service4);

            var service1 = new Service1(service2);

            var result = service1.Method1();

            Assert.NotNull(result);
            Assert.Equal("Hello from Service1! ,from Service2! ,from Service4!", result);
        }
    }
}
