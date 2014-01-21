using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HabrLessonClassLibrary.Repository;
using HabrLessonClassLibrary.Services;
using HabrLessonClassLibrary.Repository.Sql;
using Autofac;
using Autofac.Integration.Mvc;
using HabrLessonWebApplication.Controllers;
using System.Web.Mvc;
namespace HabrLessonWebApplication.App_Start
{
   

    public static class DependencyConfig
    {
        public static void Configure()
        {
           // var context = new HabrLessonClassLibrary.Repository.Sql.Persistent.HabrLessonDb();


            var builder = new ContainerBuilder();
            {
                //builder.Register(new HabrLessonClassLibrary.Repository.Sql.Persistent.HabrLessonDb())

                //repositories
                builder.RegisterType<UserRepository>()
                       .As<IUserRepository>()
                       .SingleInstance();

                //services
                builder.RegisterType<GoogleAuthenticationService>()
                       .As<IAuthenticationService>();

                //controllesrs
                builder.RegisterType<HomeController>()
                       .InstancePerHttpRequest();

                builder.RegisterType<GoogleController>()
                       .InstancePerHttpRequest();
            }

            var container = builder.Build();
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }

        }
    }
}