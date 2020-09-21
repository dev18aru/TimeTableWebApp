using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.WebApi;
using FluentValidation;
using AssignmentSchool.Data;
using Unity.Lifetime;
using Unity.Injection;
using System.Net.Http.Headers;

namespace AssignmentSchool
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            RegisterIoC(config);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //Change from default api xml response to json response
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }

        private static void RegisterIoC(HttpConfiguration config)
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            config.DependencyResolver = new UnityDependencyResolver(container);

            // To do: Register Auto Mapper here 
            
        }
        private static void RegisterTypes(UnityContainer container)
        {           
            container.RegisterType<IClassRepository, ClassRepository>(new HierarchicalLifetimeManager(), new InjectionConstructor());            
        }
    }
}
