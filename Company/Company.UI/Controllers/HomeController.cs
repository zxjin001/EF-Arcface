using Company.BLL;
using Company.IBLL;
using Company.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Company.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBase_OrganizeService StaffService = BLLContainer.Container.Resolve<Base_OrganizeService, IBase_OrganizeService>();
      
        // GET: Home
        public ActionResult Index()
        {
            List<Base_Organize> list = StaffService.GetModels(p => true).ToList();
            return View(list);
        }
        public ActionResult Add(Base_Organize staff)
        {
            if (StaffService.Add(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Update(Base_Organize staff)
        {
            if (StaffService.Update(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
        public ActionResult Delete(string unitId)
        {
            var staff = StaffService.GetModels(p => p.OrganizeId == unitId).FirstOrDefault();
            if (StaffService.Delete(staff))
            {
                return Redirect("Index");
            }
            else
            {
                return Content("no");
            }
        }
    }
}