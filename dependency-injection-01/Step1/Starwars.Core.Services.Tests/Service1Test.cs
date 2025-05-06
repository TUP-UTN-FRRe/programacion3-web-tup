using Microsoft.Extensions.DependencyInjection;
using System;

namespace Starwars.Core.Services.Tests
{
    public class Service1Test
    {
        [Fact]
        public void Method1_Test()
        {
            var service1 = new Service1();

            var result = service1.Method1();

            Assert.NotNull(result);
            Assert.Equal("Hello from Service1! ,from Service2! ,from Service4!", result);
        }
    }
}
