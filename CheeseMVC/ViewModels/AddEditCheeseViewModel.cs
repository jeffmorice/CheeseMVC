using CheeseMVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.ViewModels
{
    public class AddEditCheeseViewModel : AddCheeseViewModel 
    {
        public int CheeseId { get; set; }

        public Cheese CheeseToEdit
        {
            get
            {
                Cheese cheese = CheeseData.GetById(CheeseId);
                return cheese;
            }
        }
    }
}
