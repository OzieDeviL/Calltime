using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Calltime.Web.Services.Interfaces;
using Calltime.Web.Services;
using System.Web.Http;
using Calltime.Web;
using Calltime.Web.Core.Injection;
using Calltime.Web.Domain;
using Calltime.Web.Models.Requests;
using Calltime.Web.Models.Responses;
using System.Collections.Generic;

namespace Calltime.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            //container.RegisterType<IProductionService, ProductionService>();
            container.RegisterType(typeof(ICrudService<,>), typeof(ProductionService), "ProductionSvc")
                .RegisterType<IDomain, ProductionBase>("ProductionDomain")
                .RegisterType(typeof(ItemsResponse<>), typeof(ItemsResponse<ProductionBase>),"ProductionResponse")
                .RegisterType<IRequestModel, ProductionPostPutRequest>("ProductionRequest")
                .RegisterType(typeof(List<>), typeof(List<ProductionBase>), "ProductionDomainList");

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}