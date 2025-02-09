using System.Web.Http;

namespace WebApplication1
{
    // WebApiConfig.cs 기본 설정 예시
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 라우팅 설정
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            // WebApiConfig.cs에 추가
            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}