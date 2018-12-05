using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int CheeseId { get; set; }
        private static int nextId = 1;

        public string Name { get; set; }
        public string Description { get; set; }
        public CheeseType Type { get; set; }

        public Cheese(string name, string description) : this()
        {
            Name = name;
            Description = description;
        }

        public Cheese()
        {
            CheeseId = nextId;
            nextId++;
        }
    }
}
