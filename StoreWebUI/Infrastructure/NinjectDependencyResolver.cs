using BusinessLogicDomain.Abstract;
using BusinessLogicDomain.Concrete.Processor;
using BusinessLogicDomain.Concrete.Repository;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreWebUI.Infrastructure
{
    /// <summary>
    /// Класс NinjectDependencyResolver отвечает за настройку контейнеров Dependency Injection
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        /// <summary>
        /// Метод AddBindings осуществляет привязку к хранилищу книг EFBookRepository
        /// </summary>
        private void AddBindings()
        {
            kernel.Bind<IBookRepository>().To<EFBookRepository>();

            EmailSetting emailSetting = new EmailSetting
            {
                WriteAsFile = Boolean.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSetting);
        }
            
            
        
        public object GetService(Type serviceType) => kernel.TryGet(serviceType);

        public IEnumerable<Object> GetServices(Type serviceType) => kernel.GetAll(serviceType);
    }
}