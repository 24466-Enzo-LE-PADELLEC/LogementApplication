using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    class Logement
    {
        public string Location { get; set; }
        public string TypeOfLogement { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public bool Disponibility { get; set; }
        public Customer Seller { get; set; }

        public void Display()
        {

        }
    }
}
