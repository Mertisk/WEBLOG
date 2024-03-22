using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class WriterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());

        //[AllowAnonymous] bunu kaldırabilirsin app.UseAuthenticaiton ile giriş yapabiliyorsun
        [AllowAnonymous]


        public IActionResult Index()
        {
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
        [AllowAnonymous]
        public IActionResult WriterEditProfile()
        {
            var writervalues = wm.TGetById(1);

            return View(writervalues);
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult WriterEditProfile(Writer p)
        {
            wm.TUpdate(p);

            return RedirectToAction("Index", "Dashboard");

        }

    }
}

