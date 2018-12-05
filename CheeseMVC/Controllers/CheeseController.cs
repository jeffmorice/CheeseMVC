using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CheeseMVC.Models;
using CheeseMVC.ViewModels;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
        public IActionResult Index()
        {
           List<Cheese> cheeses = CheeseData.GetAll();

            return View(cheeses);
        }

        public IActionResult Add()
        {
            AddCheeseViewModel addCheeseViewModel = new AddCheeseViewModel();
            return View(addCheeseViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.cheeses = CheeseData.GetAll();
            return View();
        }

        public IActionResult Edit(int cheeseId)
        {
            //ViewBag.cheeses = CheeseData.GetAll();
            ViewBag.editCheese = CheeseData.GetById(cheeseId);
            return View();
        }

        [HttpPost]
        // Model binding: you can pass form data through to an object's constructor and if the input names match the the parameters in the constructor, the framework will automatically create a new object of that type. I prefer the explicit workflow as it allows me to visually track what parameters are being passed, stage by stage.
        public IActionResult Add(AddCheeseViewModel addCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese newCheese = new Cheese
                {
                    Name = addCheeseViewModel.Name,
                    Description = addCheeseViewModel.Description
                };

                //add the new cheese to my existing cheeses
                CheeseData.Add(newCheese);
                return Redirect("/cheese");
            }

            return View(addCheeseViewModel);
            
        }

        [HttpPost]
        public IActionResult Remove(int[] selected)
        {
            //remove the selected cheeses from my existing cheeses
            foreach(int cheeseId in selected)
            {
                CheeseData.Remove(cheeseId);
            }

            return Redirect("/cheese");
        }

        [HttpPost]
        [Route("/cheese/edit")]
        public IActionResult EditCheese(int cheeseId, string name, string description)
        {
            Cheese cheeseToEdit = CheeseData.GetById(cheeseId);
            cheeseToEdit.Name = name;
            cheeseToEdit.Description = description;
            return Redirect("/cheese");
        }
    }
}