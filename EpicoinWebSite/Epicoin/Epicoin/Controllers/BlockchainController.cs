using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epicoin.Controllers
{
    public class BlockchainController : Controller
    {
        // GET: Blockchain
        public ActionResult Index()
        {
            return View();
        }
    }
}