﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HabrLessonClassLibrary.Repository;
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
            var builder = new ContainerBuilder();
            {

                //repositories
                builder.RegisterType<UserRepository>()
                       .As<IUserRepository>()
                       .PropertiesAutowired()
                       .SingleInstance();

                //controllesrs
                builder.RegisterType<HomeController>()
                       .InstancePerHttpRequest();
            }

            var container = builder.Build();
            {
                DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            }

        }
    }
}