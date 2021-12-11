using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    //LE PADELLEC Enzo 24466
    class Logement
    {
        public string Location { get; set; }
        public string TypeOfLogement { get; set; }
        public int Price { get; set; }
        public int Area { get; set; }
        public bool Disponibility { get; set; }
        public Customer Seller { get; set; }

        /// <summary>
        /// Allow to display the characteristics of a logement
        /// </summary>
        public void Display()
        {
            Console.WriteLine("Informations about the Logement :");
            Console.WriteLine($"\t{String.Format("{0,-15}", "Location")}\t{String.Format("{0,-15}", "Type of Logement")}\t{String.Format("{0,-15}", "Price")}\t{String.Format("{0,-15}", "Area")}\t{String.Format("{0,-15}", "Disponibility")}");

            Console.WriteLine($"\t{String.Format("{0,-15}",Location)}\t{String.Format("{0,-20}", TypeOfLogement)}\t{String.Format("{0,-20}", Price)}\t{String.Format("{0,-15}", Area)}\t{String.Format("{0,-15}", Disponibility)}");

            Console.WriteLine();
            Console.WriteLine("Seller's informations :");

            Console.WriteLine($"\t{String.Format("{0,-15}", "ID")}\t{String.Format("{0,-15}", "First Name")}\t{String.Format("{0,-15}", "Last Name")}\t{String.Format("{0,-15}", "Email")}");

            Console.WriteLine($"\t{String.Format("{0,-15}", Seller.ID)}\t{String.Format("{0,-15}", Seller.FirstName)}\t{String.Format("{0,-15}", Seller.LastName)}\t{String.Format("{0,-15}", Seller.Email)}");
            Console.WriteLine();
        }
    }
}
