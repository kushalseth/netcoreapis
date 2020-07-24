using Hmsapp.Models;
using Hmsapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hmsapp.Controllers
{
    public class PatientController : Controller
    {
        IApplicationClientRepository _applicationClientRepository =
new ApplicationClientRepository();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveNewPatient(PatientProfileModel ppm) {
            string doctorId = User.GetId();

            Guid clientId = _applicationClientRepository.SaveClientProfile(ppm, doctorId);

            bool isSaved = clientId != Guid.Empty ? true : false;
            return Json(new { result = isSaved });

        }
    }
}