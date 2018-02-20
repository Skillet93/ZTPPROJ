using System.Web.Http;

namespace CarPresentation
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "CarSearchApi",
                "api/{controller}/model/{model}/lang/{lang}",
                new
                {
                    model = RouteParameter.Optional,
                    lang = RouteParameter.Optional,
                }
            );
        }
    }
}