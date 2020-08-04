using Hmsapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Hmsapp.Controllers
{
    public class HMSController : Controller
    {
        // GET: HMS
        public ActionResult Index()
        {

            var test = ClaimsPrincipal.Current.Claims;
            HMSIndexModel hMSIndexModel = new HMSIndexModel();
            if (User.Identity.IsAuthenticated) {
                hMSIndexModel.LoggedInName = User.Identity.Name;
            }
            return View("index", hMSIndexModel);
        }

        public ActionResult Patient()
        {
            return View();
        }

        //public ActionResult Doctor()
        //{
        //    return View();
        //}
    }
}