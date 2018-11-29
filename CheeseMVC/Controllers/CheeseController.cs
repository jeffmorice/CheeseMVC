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
        static private List<Cheese> Cheeses = new List<Cheese>();

        public IActionResult Index()
        {
           ViewBag.cheeses = Cheeses;

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = Cheeses;
            return View();
        }

        [HttpPost]
        [Route("/cheese/add")]
        public IActionResult NewCheese(string name, string description)
        {
            //add the new cheese to my existing cheeses
            Cheeses.Add(new Cheese(name, description));
            return Redirect("/cheese");
        }

        [HttpPost]
        [Route("/cheese/remove")]
        public IActionResult RemoveCheese(string[] selected)
        {
            //remove the selected cheeses from my existing cheeses
            foreach(string selection in selected)
            {
                Cheese toBeRemoved = null;

                foreach (Cheese cheese in Cheeses)
                {
                    if (selection == cheese.Name)
                    {
                        toBeRemoved = cheese;
                    }
                }

                Cheeses.Remove(toBeRemoved);
            }

            return Redirect("/cheese");
        }
    }
}