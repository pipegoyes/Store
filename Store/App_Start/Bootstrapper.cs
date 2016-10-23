using System.Reflection;
using System.Web.Mvc;
using Autofac;
using Store.Data;
using Store.Data.Interface;
using Store.Data.Repositories;
using Store.Data.UnitOfWork;
using Store.Service;
using Autofac.Integration.Mvc;
using Store.Mappings;

namespace Store
{
    public static class Bootstrapper
    {
        public static void Run()
        {
            SetAutoFacContainer();
            AutoMapperConfiguration.Configure();
        }

        private static void SetAutoFacContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(GadgetRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();
            // Services
            builder.RegisterAssemblyTypes(typeof(GadgetService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}