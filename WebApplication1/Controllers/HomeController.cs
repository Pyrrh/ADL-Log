using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public SpoonRepository SpoonRepository { get; set; }

        public HomeController()
        {
            this.SpoonRepository = new SpoonRepository();
        }

        public ActionResult Index()
        {
            SpoonRepository.Update(new Spoon(1, "Second"));
            var spoons = SpoonRepository.GetAll();

            SpoonRepository.Update(new Spoon(0, "Cole was here"));
            var spoons2 = SpoonRepository.GetAll();

            return View();
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