using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectForPractice.Controllers
{
    public class AdminController : Controller
    {
        public static string connectionstring = ConfigurationManager.AppSettings.Get("Con").ToString();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}