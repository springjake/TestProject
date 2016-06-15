using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Note.Controllers
{
    public class NoteController : Controller
    {
        //
        // GET: /Note/

        public ActionResult Index()
        {
            string content = string.Empty;
            try
            {
                content = System.IO.File.ReadAllText( Server.MapPath(@"\Note\note.txt"));

            }
            catch (Exception ex)
            {
                content = "出错啦，重新刷新一下页面";
            }
            ViewBag.content = content;
            return View();
        }

        public ActionResult Edit(Content content)
        {
            string c = content.NoteContent;
            
            System.IO.File.WriteAllText(Server.MapPath(@"\Note\note.txt"), c);
            ViewBag.content = c;
            return View("Index");
        }
    }

    public class Content
    {
        public string NoteContent { get; set; }
    }
}
