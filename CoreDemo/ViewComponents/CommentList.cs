using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commentValues = new List<UserComment>
            {
                    new UserComment
                    {
                        ID = 1,
                        Username = "Murat"
                    }, new UserComment
                    {
                        ID = 2,
                        Username = "Musa"
                    }, new UserComment
                    {
                        ID = 3,
                        Username = "Hasan"
                    }, new UserComment
                    {
                        ID = 4,
                        Username = "Ali"
                    }
                };
            return View(commentValues);
        }
    }
}
