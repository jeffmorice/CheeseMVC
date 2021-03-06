﻿using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddCheeseViewModel
    {
        [Required]
        [Display(Name = "Cheese Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must give your cheese a description.")]
        public string Description { get; set; }
        
        public CheeseType Type { get; set; }

        public List<SelectListItem> CheeseTypes { get; set; }

        [Required(ErrorMessage ="Cheeses must be rated on a scale of 1 to 5.")]
        [Range(1, 5)]
        public int Rating { get; set; }

        public AddCheeseViewModel()
        {
            CheeseTypes = new List<SelectListItem>();

            // loop through enum instead
            // <option value="0">Hard</option>
            CheeseTypes.Add(new SelectListItem {
                Value = ((int) CheeseType.Hard).ToString(),
                Text = CheeseType.Hard.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Soft).ToString(),
                Text = CheeseType.Soft.ToString()
            });

            CheeseTypes.Add(new SelectListItem
            {
                Value = ((int)CheeseType.Fake).ToString(),
                Text = CheeseType.Fake.ToString()
            });
        }

        public Cheese CreateCheese(AddCheeseViewModel addCheeseViewModel)
        {
            Cheese newCheese = new Cheese
            {
                Name = addCheeseViewModel.Name,
                Description = addCheeseViewModel.Description,
                Type = addCheeseViewModel.Type,
                Rating = addCheeseViewModel.Rating
            };

            return newCheese;
        }
    }
}
