using BackEndAssignment.Helpers;
using BackEndAssignment.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BackEndAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                var respons = new APIHub().GetRequest("2.2/questions/?page=1&pagesize=50&order=desc&sort=activity&site=stackoverflow");
                var model = JsonConvert.DeserializeObject<Questions>(respons.Result.ToString());
                return View(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult Quetion(int id)
        {
            try
            {
                var respons = new APIHub().GetRequest($"/2.2/questions/{id}?order=desc&sort=activity&site=stackoverflow");
                var model = JsonConvert.DeserializeObject<Questions>(respons.Result.ToString());
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}