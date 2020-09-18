using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TAMS.DAL;

namespace TAMS.Areas.Admin.Controllers
{
    public class StatisticalController : SessionController
    {
        // GET: Admin/Statistical
        public ActionResult Index()
        {
            

                CategoryContext CategoryContext = new CategoryContext();
                List<Entity.Category> categories = CategoryContext.GetCategory();
                ViewBag.Categories = new SelectList(categories, "Id", "Name");
                return View();
            
        }

        [HttpPost]
        public JsonResult GetRegByYear(int year)
        {
            
                
            PatientContext PatientContext = new PatientContext();
            List<Entity.Patient> patients = PatientContext.GetPatient();
            var date = new DateTime(year, 1, 1);
                var months = Enumerable.Range(0, 11)
                    .Select(x => new
                    {
                        month = date.AddMonths(x).Month,
                        year = date.AddMonths(x).Year
                    }).ToList();

                var dataPerYearAndMonth =
                    months.GroupJoin(patients,
                        m => new { m.month, m.year },
                        patient => new
                        {
                            month = patient.JoinDate.Month,
                            year = patient.JoinDate.Year
                        },
                        (p, g) => new
                        {
                            month = "Tháng " + p.month,
                            p.year,
                            count = g.Count()
                        });

                return
                    Json(new
                    {
                        status = true,
                        mess = "Thành công ",
                        data = dataPerYearAndMonth.ToList()
                    });
            
        }

        [HttpPost]
        public JsonResult GetItemByCategory(int? categoryId)
        {
            if (!categoryId.HasValue)
            {
                return
                    Json(new
                    {
                        status = false,
                        mess = "Danh mục không tồn tại"
                    });
            }
            ItemContext itemContext = new ItemContext();

            List<Entity.Item> items = itemContext.GetItem((int)categoryId);

            var amountItem = items.Count;

                

                var hireCount = itemContext.Count1((int)categoryId);
                var availabilityCount = itemContext.Count2((int)categoryId);
                var expiredCount = itemContext.Count3((int)categoryId);
                var unavailableCount = itemContext.Count4((int)categoryId);
                var maintenanceCount = itemContext.Count5((int)categoryId);

                var availabilityItem = amountItem - hireCount - expiredCount - unavailableCount - maintenanceCount;

                return
                    Json(new
                    {
                        status = true,
                        mess = "Thành công ",
                        data = new[]
                        {
                            new
                            {
                                label = "Đã sử dụng", value = hireCount
                            },
                            new
                            {
                                label = "Khả dụng", value = availabilityItem
                            },
                            new
                            {
                                label = "Không khả dụng", value = unavailableCount
                            },
                            new
                            {
                                label = "Bảo trì", value = maintenanceCount
                            },
                            new
                            {
                                label = "Hết Hạn", value = expiredCount
                            }
                        }
                    });
            
        }
    }
}