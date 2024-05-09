using CoreDemo.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class WriterController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult WriterList()
        {
            var jsonWriter = JsonConvert.SerializeObject(writers);
            return Json(jsonWriter);

        }
        public IActionResult GetWriterById(int writerId)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == writerId);

            var jsonWriter = JsonConvert.SerializeObject(findWriter);
            return Json(jsonWriter);
        }
        [HttpPost]
        public IActionResult WriterAdd(WriterClass w)
        {
            writers.Add(w);
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }
        public IActionResult WriterDelete(int id)
        {
            var findWriter = writers.FirstOrDefault(x => x.Id == id);
            writers.Remove(findWriter);
            return Json(findWriter);
        }

        public IActionResult WriterUpdate(WriterClass w)
        {
            var writer = writers.FirstOrDefault(x => x.Id == w.Id);
            writer.Name = w.Name;
            var jsonWriter = JsonConvert.SerializeObject(w);
            return Json(jsonWriter);
        }

        public static List<WriterClass> writers = new List<WriterClass> {

        new WriterClass {Id=1,Name="Mert"},
        new WriterClass {Id=2,Name="Ahmet"},
        new WriterClass {Id=3,Name="Betül"}

        };
    }
}
