using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web.Http;
using MovieStore.WebApi.Controllers;
namespace MovieStore.WebApi.App_Start
{
    public class Bootstrapper
    {

        public static void Run()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.Register<MovieController>(
                c => new MovieController(Mapper.Engine));
            builder.Register<GenreController>(
               c => new GenreController(Mapper.Engine));
            builder.Register<MPAAController>(
                c => new MPAAController(Mapper.Engine));

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            ConfigureAutoMapper();
        }

        private static void ConfigureAutoMapper()
        {
            AutoMapperBootstrapper.Run();
        }
    }
}