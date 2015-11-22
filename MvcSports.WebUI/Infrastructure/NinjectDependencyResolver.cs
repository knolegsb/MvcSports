using Moq;
using MvcSports.Domain.Abstract;
using MvcSports.Domain.Concrete;
using MvcSports.Domain.Entities;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace MvcSports.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            //Mock<IProductRepository> mock = new Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //{
            //    new Product { Name="Football", Price=25 },
            //    new Product { Name="Surf board", Price=179 },
            //    new Product { Name="Running shoes", Price=95 }
            //});

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}