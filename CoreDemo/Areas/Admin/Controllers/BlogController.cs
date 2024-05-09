using ClosedXML.Excel;
using CoreDemo.Areas.Admin.Models;
using DataAccsessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CoreDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        public IActionResult ExportStaticExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //sayfa adı blog listesi ==sayfa ismi yani
                worksheet.Cell(1, 1).Value = "Blog ID"; //1.satır 1.sütün
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır 2.sütün

                int BlogRowCount = 2; //başlangıç değeri çünkü yazacakların 2.satırdan başlar (1.satır başlık zaten)
                foreach (var item in GetBlogList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);//   Stream'den gelen değerler ile farklı kaydet
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");


                }


            }
            //return View(); return File yapıyoruz zaten View() e gerek yok!!
        }
        public List<BlogModel> GetBlogList()
        {
            List<BlogModel> blogList = new List<BlogModel>
            {
                new BlogModel
                {
                    ID = 1,BlogName="C# ile Programlamaya Giriş"
                },
                new BlogModel { ID = 2,BlogName="Tesla Firmasının Araçları "},
                new BlogModel { ID = 3,BlogName="2024 Olimpiyatları "}
            };

            return blogList;
        }
        public IActionResult BlogListExcel()
        {
            return View();
        }

        public IActionResult ExportDynamicExcelBlogList()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Blog Listesi"); //sayfa adı blog listesi ==sayfa ismi yani
                worksheet.Cell(1, 1).Value = "Blog ID"; //1.satır 1.sütün
                worksheet.Cell(1, 2).Value = "Blog Adı"; //1.satır 2.sütün

                int BlogRowCount = 2; //başlangıç değeri çünkü yazacakların 2.satırdan başlar (1.satır başlık zaten)
                foreach (var item in GetTitleList())
                {
                    worksheet.Cell(BlogRowCount, 1).Value = item.ID;
                    worksheet.Cell(BlogRowCount, 2).Value = item.BlogName;
                    BlogRowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);//   Stream'den gelen değerler ile farklı kaydet
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Calisma1.xlsx");

                }

            }
        }
        public List<BlogModel2> GetTitleList()
        {

            List<BlogModel2> bloglist = new List<BlogModel2>();

            using (var c = new Context())
            {
                bloglist = c.Blogs.Select(x => new BlogModel2
                {
                    ID = x.BlogID,
                    BlogName = x.BlogTitle
                }).ToList();
            }

            return bloglist;
        }
        public IActionResult BlogTitleListExcel()
        {
            return View();
        }
    }
}
