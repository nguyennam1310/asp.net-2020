using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class DashboardController : SessionController
    {
        // GET: Admin/Dashboard
        public ActionResult Index()
        {
            ViewBag.Element = "Hệ thống";
            ViewBag.Feature = "Bảng điều khiển";
            if (Request.Url != null) ViewBag.BaseURL = Request.Url.LocalPath;


                AttachmentContext attachment = new AttachmentContext();
                List<Entity.Attachment> documents = attachment.GetAttachments();
                PatientContext patient = new PatientContext();
                List<Entity.Patient> patients = patient.GetPatient();
                PrescriptionContext PrescriptionContext = new PrescriptionContext();
                List<Entity.Prescription> prescriptions = PrescriptionContext.GetPrescriptions();
                ItemContext itemContext = new ItemContext();

                List<Entity.Item> items = itemContext.GetItems();

                //
                ViewBag.DocumentCount = documents.Count;
                ViewBag.PatientCount = patients.Count;
                ViewBag.PrescriptionCount = prescriptions.Count;
                ViewBag.ItemCount = items.Count;

                var now = DateTime.Now;
                //
                ViewBag.DocumentTodayCount = documents.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                ViewBag.DocumentMonthCount = documents.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                ViewBag.PatientTodayCount = patients.Count(x => x.JoinDate.Day == now.Day && x.JoinDate.Month == now.Month && x.JoinDate.Year == now.Year);
                ViewBag.PatientMonthCount = patients.Count(x => x.JoinDate.Month == now.Month && x.JoinDate.Year == now.Year);

                ViewBag.PrescriptionTodayCount = prescriptions.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                ViewBag.PrescriptionMonthCount = documents.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

                ViewBag.ItemTodayCount = items.Count(x => x.ModifiedDate.Day == now.Day && x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);
                ViewBag.ItemMonthCount = items.Count(x => x.ModifiedDate.Month == now.Month && x.ModifiedDate.Year == now.Year);

            // new patient

                List<Entity.Patient> patientsNew = patient.GetPatientNew();
                ViewBag.PatientsNew = patientsNew;

            CategoryContext CategoryContext = new CategoryContext();
            List<Entity.Category> categories = CategoryContext.GetCategory();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            

            return View();
        }
    }
}