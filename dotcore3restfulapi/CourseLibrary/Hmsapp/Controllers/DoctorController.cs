using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Hmsapp.Models;
using Hmsapp.Repositories;

namespace Hmsapp.Controllers
{

    [Authorize]
    public class DoctorController : BaseController
    {

        IApplicationOperatorRepository _applicationOperatorRepository = 
                                                            new ApplicationOperatorRepository();
        IApplicationClientRepository _applicationClientRepository =
                                                            new ApplicationClientRepository();
        ILocationRepository _locationRepository = new LocationRepository();
        IPracticeTimmingRepository _practiceTimmingRepository =
                                                new PracticeTimmingRepository();
        IPracticeTimmingDayRepository _practiceTimmingDayRepository =
                                        new PracticeTimmingDayRepository();

        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DoctorProfile()
        {

            var user = _applicationOperatorRepository.GetDoctorDetails(User.GetId());

            DoctorProfileModel dpVM = new DoctorProfileModel();

            if (user != null)
            {
                dpVM = new DoctorProfileModel
                {
                    Email = user.Email,
                    FirstName = user.ApplicationClients != null ? user.ApplicationClients.FirstName : string.Empty,
                    LastName = user.ApplicationClients != null ? user.ApplicationClients.LastName : string.Empty,
                    PhoneNumber = user.PhoneNumber
                    //FirstName = user.
                };

            }
            return View("DoctorProfile", dpVM);
        }

        public ActionResult EditProfile()
        {
            var user = _applicationOperatorRepository.GetDoctorDetails(User.GetId());

            DoctorProfileModel dpVM = new DoctorProfileModel();

            if (user != null)
            {
                dpVM = new DoctorProfileModel
                {
                    Email = user.Email,
                    FirstName = user.ApplicationClients != null ? user.ApplicationClients.FirstName : string.Empty,
                    LastName = user.ApplicationClients != null ? user.ApplicationClients.LastName : string.Empty,
                    PhoneNumber = user.PhoneNumber
                    //FirstName = user.
                };

            }
            return View("EditProfile", dpVM);
        }

        [HttpPost]
        public bool SaveProfile(DoctorProfileModel dpm)
        {
            string userId = User.GetId();

            bool result = _applicationOperatorRepository.SaveDoctorProfile(dpm, userId);

            return result;
        }


        public ActionResult DoctorPatients()
        {
            string doctorId = User.GetId();
            DoctorPatients dp = new Models.DoctorPatients();
            dp.PatientsList = _applicationClientRepository.GetListOfPatientsForDoctor(doctorId);

            return View("DoctorPatients", dp);
        }

        public ActionResult DoctorSchedule()
        {
            return PartialView("DoctorSchedule");

        }

        public ActionResult SaveDoctorPracticeSchedule(PracticeTimmingsVM ptvm)
        {
            Location location = new Location()
            {
                Address = ptvm.Address,
                City = ptvm.City,
                Sate = ptvm.State,
                PhoneNumber = ptvm.PhoneNumber,
                PinCode = ptvm.PinCode
            };

            int locationId = _locationRepository.SaveDoctorPracticeSchedule(location);

            if (ptvm.PracticeSession != null && ptvm.PracticeSession.Count > 0)
            {
                for (int i = 0; i < ptvm.PracticeSession.Count; i++)
                {
                    var contxt = ptvm.PracticeSession[i];
                    PracticeTimming practiceTimming = new PracticeTimming
                    {
                        DoctorId = new Guid(User.GetId()),
                        LocationId = locationId,
                        Duration = DateTime.Now, // ptvm.Duration,
                        SessionStartTime = DateTime.Now, //contxt.SessionStartTime,
                        SessionEndTime = DateTime.Now //contxt.SessionEndTime                        
                    };
                    Guid practiceTimmingId = _practiceTimmingRepository.SavePracticeTimming(practiceTimming);

                    List<string> days = contxt.Days.ToList<string>();

                    for (var j = 0; j < days.Count; j++) {
                        string context = days[j];

                        PracticeTimmingDay practiceTimmingDay = new PracticeTimmingDay
                        {
                            DayId = Utility.GetdayId(context),
                            PracticeTimmingsId = practiceTimmingId
                        };
                        _practiceTimmingDayRepository.SavePracticeTimmingDayRepository(practiceTimmingDay);
                    }
                }
            }

            return Json(new { result = true });
        }

    }
}