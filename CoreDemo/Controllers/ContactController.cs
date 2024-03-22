using BusinessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CoreDemo.Controllers
{
    public class ContactController : Controller
    {
        ContactManager cm = new ContactManager(new EfContactRepository());
        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        public IActionResult Index(Contact p)
        {
            p.ContactStatus = true;
            p.ContactDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            cm.ContactAdd(p);

            return RedirectToAction("Index", "Blog");
        }
    }
}
