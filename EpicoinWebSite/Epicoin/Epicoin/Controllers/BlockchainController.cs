using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using blockchain.net.client;
using blockchain.datacontainer;

namespace Epicoin.Controllers
{
    public class BlockchainController : Controller
    {
        // GET: Blockchain
        public ActionResult Index()
        {
            DataChainStats stats = null;
            try
            {
                Client c = new Client(blockchain.Epicoin.host, blockchain.Epicoin.port);
                stats = c.GetChainStats();
            }
            catch (Exception)
            {
                stats = null;
            }

            if (stats != null)
            {
                ViewData["Difficulty"] = stats.Difficulty.ToString() ;
                ViewData["valid"] = stats.Valid.ToString();
                ViewData["Name"] = stats.Name;
                ViewData["Lenght"] = stats.Lenght.ToString() + " Blocks";
                ViewData["LastIndex"] = stats.LastIndex.ToString();
                ViewData["LastBlockHash"] = stats.LastBlockHash;
                ViewData["TotalEpicoin"] = (((stats.Lenght - 1) * 10) + 542).ToString();
            }
            else
            {
                ViewData["Difficulty"] = "Offline";
                ViewData["valid"] = "Offline";
                ViewData["Name"] = "Offline";
                ViewData["Lenght"] = "Offline";
                ViewData["LastIndex"] = "Offline";
                ViewData["LastBlockHash"] = "Offline";
                ViewData["TotalEpicoin"] = "Offline";
            }

            return View();
        }
    }
}