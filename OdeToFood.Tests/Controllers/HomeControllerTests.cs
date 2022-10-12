using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OdeToFood.Controllers;
using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Controllers.Tests
{
    [TestClass()]
    
    public class HomeControllerTests
    {
        private static ILogger<HomeController> _logger;

        public HomeControllerTests()
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>();
            _logger = factory.CreateLogger<HomeController>();
        }

        [TestMethod()]
        
        public void AboutTest()
        {
            //HomeController controller = new HomeController(_logger);

            //ViewResult result = controller.About() as ViewResult;

            //Assert.IsNotNull(result.Model);
            //AboutModel aboutModel = result.Model as AboutModel;
            //Assert.AreEqual("Sennah",aboutModel.Name);
        }
        
}
    
}