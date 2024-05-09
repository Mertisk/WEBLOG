using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        Context c = new Context();


        //[AllowAnonymous] bunu kaldırabilirsin app.UseAuthenticaiton ile giriş yapabiliyorsun
        [AllowAnonymous]
        //[Authorize]


        public IActionResult Index()
        {
            var userMail = User.Identity.Name;
            ViewBag.v1 = userMail;


            var writerName = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.v2 = writerName;



            return View();
        }


        [AllowAnonymous]
        public IActionResult Test()
        {
            return View();
        }

        [AllowAnonymous]
        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        [AllowAnonymous]
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }
        [HttpGet]

        public IActionResult WriterEditProfile()
        {

            var userMail = User.Identity.Name;
            var writerID = c.Writers.Where(x => x.WriterMail == userMail).Select(y => y.WriterID).FirstOrDefault();
            var writervalues = wm.TGetById(writerID);

            return View(writervalues);
        }
        [HttpPost]

        public IActionResult WriterEditProfile(Writer p)
        {
            wm.TUpdate(p);

            return RedirectToAction("Index", "Dashboard");

        }

    }
}

