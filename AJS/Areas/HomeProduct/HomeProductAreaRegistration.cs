using System.Web.Mvc;

namespace AJS.Areas.HomeProduct
{
    public class HomeProductAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "HomeProduct";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "HomeProduct_default",
                "HomeProduct/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}