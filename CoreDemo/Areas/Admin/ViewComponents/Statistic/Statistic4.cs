using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Areas.Admin.ViewComponents.Statistic
{
    public class Statistic4 : ViewComponent
    {
        AdminManager am = new AdminManager(new EfAdminRepository());
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            var values = am.TGetById(1);

            ViewBag.v1 = c.Admins.Where(x => x.AdminID == 1).Select(y => y.Name).FirstOrDefault();



            return View(values);
        }
    }
}
