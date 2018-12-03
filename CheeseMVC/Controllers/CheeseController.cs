using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public IActionResult Index()
        {
           ViewBag.cheeses = CheeseData.GetAll();

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        [HttpPost]
        [Route("/cheese/add")]
        // Model binding: you can pass form data through to an object's constructor and if the input names match the the parameters in the constructor, the framework will automatically create a new object of that type. I prefer the explicit workflow as it allows me to visually track what parameters are being passed, stage by stage.
        public IActionResult NewCheese(Cheese newCheese)
        {
            //add the new cheese to my existing cheeses
            CheeseData.Add(newCheese);
            return Redirect("/cheese");
        }

        [HttpPost]
        [Route("/cheese/remove")]
        public IActionResult RemoveCheese(int[] selected)
        {
            //remove the selected cheeses from my existing cheeses
            foreach(int cheeseId in selected)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/cheese");
        }
    }
}