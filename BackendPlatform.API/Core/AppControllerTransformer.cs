using Microsoft.AspNetCore.Mvc.Routing;

namespace BackendPlatform.API.Core
{
    public class AppControllerTransformer : DynamicRouteValueTransformer
    {
        public override async ValueTask<RouteValueDictionary> TransformAsync(HttpContext httpContext, RouteValueDictionary values)
        {
            // 這邊實際上要根據請求帶入的欄位資料決定應該要呼叫的 特定系統的 Controller (以 Area 做區分)
            if (httpContext.Request.Headers.ContainsKey("Area"))
            {
                var area = httpContext.Request.Headers["Area"].ToString();
                values["area"] = area;

                Console.WriteLine($"Area: {area}, {httpContext.Request.Path}");
            }
            return await Task.FromResult(values);
        }

        //public override ValueTask<IReadOnlyList<Endpoint>> FilterAsync(HttpContext httpContext, RouteValueDictionary values, IReadOnlyList<Endpoint> endpoints)
        //{
        //    return base.FilterAsync(httpContext, values, endpoints);
        //}
    }

    //public class MyCustomConstraint : IRouteConstraint
    //{
    //    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
