using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class NewsLatterController : Controller
    {
        NewsLatterManager nm = new NewsLatterManager(new EfNewsLatterRepository());

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SubscribeMail(NewsLatter p)
        {



            p.MailStatus = true;

            nm.AddLatter(p);

            return PartialView();
        }
    }
}
