using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models
{
    public class CheeseData
    {
        static private List<Cheese> cheeses = new List<Cheese>();

        // Get all
        public static List<Cheese> GetAll()
        {
            return cheeses;
        }

        // add
        public static void Add(Cheese newCheese)
        {
            cheeses.Add(newCheese);
        }

        // remove
        public static void Remove(int id)
        {
            Cheese cheeseToRemove = GetById(id);
            cheeses.Remove(cheeseToRemove);
        }

        // get by id
        private static Cheese GetById(int id)
        {
            return cheeses.Single(x => x.CheeseId == id);
            
        }
    }
}
