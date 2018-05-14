using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blockchain.net.client;

namespace Epicoin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Terms()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Status()
        {
            string status;
            try
            {
                Client c = new Client(blockchain.Epicoin.host, blockchain.Epicoin.port);
                status = "Online";
            }
            catch(Exception)
            {
                status = "Offline";
            }
            ViewData["status"] = status;
            return View();
        }
    }
}