using Newtonsoft.Json;
using System.Web.Mvc;

namespace Hmsapp
{
    internal class CustomHandleErrorAttribute : HandleErrorAttribute
    {

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }


        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.ExceptionHandled = true;



            if (IsAjax(filterContext))
            {
                filterContext.ExceptionHandled = true;
                filterContext.Result = new JsonResult
                {
                    
                    Data = JsonConvert.SerializeObject(new { result = new { Succeeded = false }, Exception = filterContext.Exception }),
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            base.OnException(filterContext);
        }
    }
}