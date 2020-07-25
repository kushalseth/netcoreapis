using Hmsapp.Models;
using Hmsapp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hmsapp.Controllers
{
    public class AppointmentsController : Controller
    {
        IApplicationClientRepository _applicationClientRepository = new ApplicationClientRepository();
        IAppointmentRepository _appointmentRepository = new AppointmentRepository();

        // GET: Appointments
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveNewAppointments(AppointmentModel appointmentModel)
        {
            string doctorId = User.GetId();

            PatientProfileModel ppm = new PatientProfileModel {
                FirstName = appointmentModel.FirstName,
                LastName = appointmentModel.LastName,
                Email = appointmentModel.Email,               
                PhoneNumber = appointmentModel.PhoneNumber
            };

            Guid _patinetId = _applicationClientRepository.SaveClientProfile(ppm, doctorId);

            Appointments appointments = new Appointments {
                //BeforeOPDAppointmentTime = appointmentModel.BeforeOPDAppointmentTime,
                DoctorId = new Guid(doctorId),
                PatientId = _patinetId                
            };

            appointments.AfterOPDActualAppointmentTime = DateTime.Now;
            appointments.BeforeOPDAppointmentTime = DateTime.Now;

            _appointmentRepository.SaveAppointment(appointments);

            return Json(new { isTrue = true });


        }
    }
}