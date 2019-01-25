using System;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace EkilibrateUI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class SessionExpireFilterAttribute : ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    HttpContext ctx = HttpContext.Current;
            
        //    // check if session is supported
        //    CurrentCustomer objCurrentCustomer = new CurrentCustomer();
        //    objCurrentCustomer = ((CurrentCustomer)SessionStore.GetSessionValue(SessionStore.Customer));
        //    if (objCurrentCustomer == null)
        //    {
        //        // check if a new session id was generated
        //        filterContext.Result = new RedirectResult("~/Users/Login");
        //        return;
        //    }

        //    base.OnActionExecuting(filterContext);
        //}
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class MultipleButtonAttribute : ActionNameSelectorAttribute
    {
        public string Name { get; set; }
        public string Argument { get; set; }

        public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
        {
            var isValidName = false;
            var keyValue = string.Format("{0}:{1}", Name, Argument);
            var value = controllerContext.Controller.ValueProvider.GetValue(keyValue);

            if (value != null)
            {
                controllerContext.Controller.ControllerContext.RouteData.Values[Name] = Argument;
                isValidName = true;
            }

            return isValidName;
        }
    }
}
