using Microsoft.Extensions.DependencyInjection;
using Starwars.Core.Services.Interfaces;
using System;

namespace Starwars.Core.Services.Tests
{
    public class Service1Test
    {
        [Fact]
        public void Method1_Test()
        {

            IServiceCollection services = new ServiceCollection();

            services.AddTransient<Service1>();
            //services.AddTransient<IService2, Service2>();
            services.AddTransient<IService2, Service2Dummy>();
            services.AddTransient<Service4>();
            services.AddTransient<Service5>();
            services.AddTransient<Service6>();

            var serviceProvider = services.BuildServiceProvider();

            //var service4 = new Service4();
            //var service2 = new Service2(service4);
            //var service1 = new Service1(service2);

            var service1 = serviceProvider.GetService<Service1>();

            var result = service1.Method1();

            Assert.NotNull(result);
            Assert.Equal("Hello from Service1! ,from Service2! ,from Service4! ,from Service5! ,from Service6!", result);
        }



    }
}
