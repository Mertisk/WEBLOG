using BusinessLayer.Concrete;
using DataAccsessLayer.Concrete;
using DataAccsessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CoreDemo.ViewComponents.Writer
{
    public class WriterMessageNotification : ViewComponent
    {
        MessageManager mm = new MessageManager(new EfMessageRepository());
        public IViewComponentResult Invoke()
        {
            Context context = new Context();
            string p;

            p = "deneme@gmail.com";

            var values = mm.GetInBoxListByWriter(p);
            ViewBag.c = context.Messages.Where(x => x.Receiver == p).Count();
            return View(values);
        }

    }
}
