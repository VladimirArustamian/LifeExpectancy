namespace LifeExpectancyAnalyzer
{
    using System.Linq;

    public class RouteConvention : Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelConvention
    {
        private readonly Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel _centralPrefix;

        public RouteConvention(Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider routeTemplateProvider)
        {
            _centralPrefix = new Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel(routeTemplateProvider);
        }

        public void Apply(Microsoft.AspNetCore.Mvc.ApplicationModels.ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var matchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel != null).ToList();
                if (matchedSelectors.Any())
                {
                    foreach (var selectorModel in matchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = Microsoft.AspNetCore.Mvc.ApplicationModels.AttributeRouteModel.CombineAttributeRouteModel(_centralPrefix,
                            selectorModel.AttributeRouteModel);
                    }
                }

                var unmatchedSelectors = controller.Selectors.Where(x => x.AttributeRouteModel == null).ToList();
                if (unmatchedSelectors.Any())
                {
                    foreach (var selectorModel in unmatchedSelectors)
                    {
                        selectorModel.AttributeRouteModel = _centralPrefix;
                    }
                }
            }
        }
    }
}
