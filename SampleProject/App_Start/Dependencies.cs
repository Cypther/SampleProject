using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using SampleProject.Context;
using SampleProject.Repository;
using SampleProject.Service;

namespace SampleProject.App_Start
{
    public class Dependencies
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(Dependencies).Assembly);
            builder.RegisterType<SampleContext>().InstancePerRequest();
            builder.RegisterType<VehicleService>().InstancePerRequest();
            builder.RegisterType<VehicleRepository>().InstancePerRequest();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}