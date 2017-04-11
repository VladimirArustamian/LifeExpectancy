namespace LifeExpectancyAnalyzer
{
    public static class MvcOptionsExtensions
    {
        public static void UseCentralRoutePrefix(this Microsoft.AspNetCore.Mvc.MvcOptions options, 
            Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider routeAttribute)
        {
            options.Conventions.Insert(0, new RouteConvention(routeAttribute));
        }
    }
}
