using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    class Customer : User
    {
        public int Money { get; set; }
        public string Phone { get; set; }
        public List<string> Transactions { get; set; }
        public List<Logement> SalesProposal { get; set; }
        public void ModifyCustomer(bool oui)
        {

        }
        public void AddLogement(Customer CurrentCustomer)
        {
            string sentorrent = "0";
            while (sentorrent != "sell" || sentorrent != "rent")
            {
                Console.WriteLine("Do you want to sell or rent your property? Answer 'sell' or 'rent' ");
                sentorrent = Console.ReadLine().ToLower();
            }
            Console.WriteLine("Where is your property located? (adress)");
            string location = FirstLetterUpper(Console.ReadLine());
            Console.WriteLine("What type of housing do you have (house, apartment, ...)?");
            string typeofLogement = FirstLetterUpper(Console.ReadLine());
            int price = 0;
            if(sentorrent == "sell")
            {
                Console.WriteLine("At what price do you want to sell your property?");
                price = SaisieNombre();
            }
            else
            {
                Console.WriteLine("What rent do you want for your rental?");
                price = SaisieNombre();
            }
            Console.WriteLine("What is the surface area (in m²) of this accommodation?");
            int area = SaisieNombre();
            Logement L1 = new Logement { Location = location, TypeOfLogement = typeofLogement, SellorRend = sentorrent, Price = price, Area = area, Disponibility = true, Seller = CurrentCustomer };
            SalesProposal.Add(L1);
            AllLogements.Add(L1);
            Customers.Add(CurrentCustomer);
        }
        public void DeleteLogement(bool oui)
        {

        }
        public void ModifyLogement(bool oui)
        {

        }
        public void BuyLogement()
        {
            ShowLogements();
            Console.WriteLine("Where is the property you wish to buy located?");
            string Location = FirstLetterUpper(Console.ReadLine());
            Console.WriteLine("What is the size of the home you wish to purchase?");
            int Area = SaisieNombre();
            Console.WriteLine("What is the ID of the seller?");
            string ID = Console.ReadLine();
        }
        public void RentLogement()
        {

        }

        public void AddMoney()
        {

        }
        public void WithdrawMoney()
        {

        }
        
        public void ShowMyLogementsProposition()
        {
            foreach (Logement L in SalesProposal)
            {
                L.Display();
            }
            Console.WriteLine();
        }
    }
}
