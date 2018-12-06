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
            AddEditCheeseViewModel addEditCheeseViewModel = new AddEditCheeseViewModel
            {
                CheeseId = cheeseId
            };

            //Cheese cheeseToEdit = GetById(cheeseId);

            return View(addEditCheeseViewModel);
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
                    Description = addCheeseViewModel.Description,
                    Type = addCheeseViewModel.Type,
                    Rating = addCheeseViewModel.Rating
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
        public IActionResult Edit(AddEditCheeseViewModel addEditCheeseViewModel)
        {
            if (ModelState.IsValid)
            {
                Cheese cheeseToEdit = CheeseData.GetById(addEditCheeseViewModel.CheeseToEdit.CheeseId);
                cheeseToEdit.Name = addEditCheeseViewModel.Name;
                cheeseToEdit.Description = addEditCheeseViewModel.Description;
                cheeseToEdit.Type = addEditCheeseViewModel.Type;
                cheeseToEdit.Rating = addEditCheeseViewModel.Rating;

                return Redirect("/cheese");
            }

            return View(addEditCheeseViewModel);
        }
    }
}