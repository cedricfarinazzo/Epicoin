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
                ViewData["Pending"] = stats.Pending;
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
                ViewData["Pending"] = "Pending";
            }

            return View();
        }

        public ActionResult Block(int id)
        {
            DataChainStats stats = null;
            Client client;
            try
            {
                client = new Client(blockchain.Epicoin.host, blockchain.Epicoin.port);
                stats = client.GetChainStats();
                if (stats == null)
                {
                    return View("~/Views/BlockChain/BlockNotFound.cshtml");
                }

                if (id >= stats.Lenght)
                {
                    return View("~/Views/BlockChain/BlockNotFound.cshtml");
                }
            }
            catch (Exception)
            {
                return View("~/Views/BlockChain/BlockNotFound.cshtml");
            }

            try
            {
                blockchain.blockchain.Block block = client.GetBlockNumber(id);
                ViewData["Index"] = block.Index.ToString();
                ViewData["HashBlock"] = block.Hashblock;
                ViewData["Date"] = DateTime.Parse(block.Timestamp.ToString()).ToLocalTime();
                ViewData["PreviousHash"] = block.PreviousHash;
                ViewData["Nonce"] = block.nonce.ToString();
                ViewData["Trans1"] = "";
                ViewData["Trans2"] = "";
                ViewData["Trans3"] = "";

                List<blockchain.blockchain.Transaction> trans = block.Data;
                for(int i = 0; i < trans.Count; i++)
                {
                    ViewData["Trans" + i.ToString()] = trans[i].ToString();
                }
                

                return View();
            }
            catch(Exception)
            {
                return View("~/Views/BlockChain/BlockNotFound.cshtml");
            }
        }

        public ActionResult BlockNotFound()
        {
            return View();
        }
    }
}