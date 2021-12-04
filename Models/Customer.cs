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
        public List<Logement> MyLogements { get; set; }
        public void ModifyCustomer(Customer ConnectedCustomer, bool ModifAdmin)
        {
            bool ChangeID = false;

        NewChange:

            Console.WriteLine($"\t{String.Format("{0,-15}", "ID")}\t{String.Format("{0,-15}", "First Name")}\t{String.Format("{0,-15}", "Last Name")}\t{String.Format("{0,-15}", "Email")}\t{String.Format("{0,-15}", "Phone")}\t{String.Format("{0,-15}", "Money")}");

            Console.WriteLine($"\t{String.Format("{0,-15}", ID)}\t{String.Format("{0,-15}", FirstName)}\t{String.Format("{0,-15}", LastName)}\t{String.Format("{0,-15}", Email)}" +
                $"\t{String.Format("{0,-15}", Phone)}\t{String.Format("{0,-15}", Money)}");

            Console.WriteLine("What do you want to change ?");
            Console.WriteLine("=============================");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - First Name");
            Console.WriteLine("2 - Last Name");
            Console.WriteLine("3 - Email");
            Console.WriteLine("4 - Phone");
            if (ModifAdmin == true)
            {
                Console.WriteLine("5 - Money");
            }

            string Choix = Console.ReadLine();

            if (Choix == "0")
            {
                Console.WriteLine("Exit...");
            }
            else if (Choix == "1")
            {
                Console.WriteLine("Enter the new first name");
                string NewFirstName = FirstLetterUpper(Console.ReadLine());
                ConnectedCustomer.FirstName = NewFirstName;
                ChangeID = true;
                goto NewChange;
            }
            else if (Choix == "2")
            {
                Console.WriteLine("Enter the new last name");
                string NewLastName = FirstLetterUpper(Console.ReadLine());
                ConnectedCustomer.LastName = NewLastName;
                ChangeID = true;
                goto NewChange;
            }
            else if (Choix == "3")
            {
                Console.WriteLine("Enter the new email");
                string NewEmail = Console.ReadLine();
                ConnectedCustomer.Email = NewEmail;
                goto NewChange;
            }
            else if (Choix == "4")
            {
                Console.WriteLine("Enter the new phone number");
                string NewPhone = Console.ReadLine();
                ConnectedCustomer.Phone = NewPhone;
                goto NewChange;
            }
            else if (Choix == "5" && ModifAdmin == true)
            {
                Console.WriteLine("Enter the new budget/money");
                int NewMoney = SaisieNombre();
                ConnectedCustomer.Money = NewMoney;
                goto NewChange;
            }
            else if (Choix == "5" && ModifAdmin == false)
            {
                Console.WriteLine("You can't modify that");
                goto NewChange;
            }
            else
            {
                Console.WriteLine("Please select a correct number");
                goto NewChange;
            }

            if (ChangeID == true)
            {
                User.CreatePIN(ConnectedCustomer, 0);
                Console.WriteLine("Your new ID is : " + ID);
            }
        }


        public void AddLogement(Customer CurrentCustomer)
        {

            Console.WriteLine("Where is your property located? (adress)");
            string location = FirstLetterUpper(Console.ReadLine());
            Console.WriteLine("What type of housing do you have (house, apartment, ...)?");
            string typeofLogement = FirstLetterUpper(Console.ReadLine());
            int price = 0;
            Console.WriteLine("At what price do you want to sell your property?");
            price = SaisieNombre();

            Console.WriteLine("What is the surface area (in m²) of this accommodation?");
            int area = SaisieNombre();
            bool Dispo = false;

        Retry:
            Console.WriteLine("Do you want to sell this accommodation? Answer 'y' or 'n' please.");
            string Disp = Console.ReadLine().ToLower();

            if (Disp != "y" && Disp != "n")
            {
                goto Retry;
            }
            if (Disp == "y")
            {
                Dispo = true;
            }

            Logement L1 = new Logement { Location = location, TypeOfLogement = typeofLogement, Price = price, Area = area, Disponibility = Dispo, Seller = CurrentCustomer };
            MyLogements.Add(L1);
            AllLogements.Add(L1);
        }

        public void DeleteLogement(Logement CurrentLog, bool oui)
        {

        }
        public void ModifyLogement(Logement CurrentLog, bool oui)
        {

        }
        public void BuyLogement()
        {
        Retry:
            ShowLogements();
            Console.WriteLine("Where is the property you wish to buy located?");
            string Location = FirstLetterUpper(Console.ReadLine());
            Console.WriteLine("What is the size of the home you wish to purchase? (in m²)");
            int Area = SaisieNombre();
            Console.WriteLine("What is the ID of the seller?");
            string ID = Console.ReadLine();

            Logement CurrentLog = new Logement();
            bool Exist = false;

            foreach (Logement logement in AllLogements)
            {
                if (logement.Location == Location && logement.Area == Area && logement.Seller.ID == ID)
                {
                    CurrentLog = logement;
                    Exist = true;
                }
            }

            if (Exist == false)
            {
                Console.WriteLine("No logement found");
                Console.WriteLine("Please retry");
                goto Retry;
            }

            if (Money < CurrentLog.Price)
            {
                Console.WriteLine("You don't have enough money.");
            }
            else
            {
                Money = Money - CurrentLog.Price;
                CurrentLog.Seller.Money += CurrentLog.Price;
                Transactions.Add($"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} : {FirstName} bought an accommodation from {CurrentLog.Seller.FirstName} located in {CurrentLog.Location} for {CurrentLog.Price} euros.");
                CurrentLog.Seller.Transactions.Add($"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year} : {CurrentLog.Seller.FirstName} sold an accommodation to {FirstName} located in {CurrentLog.Location} for {CurrentLog.Price} euros.");
                CurrentLog.Disponibility = false;
                CurrentLog.Seller.MyLogements.Remove(CurrentLog);
                MyLogements.Add(CurrentLog);
            }
        }
        public void ChangeStateOfLogement(int entier)
        {
            if (entier == 0)
            {
                Retry:
                Console.WriteLine("What is the location of the home you want to offer for sale?");
                string location = FirstLetterUpper(Console.ReadLine());
                Console.WriteLine("What is the area of the home you want to offer for sale?");
                int area = SaisieNombre();

                Logement CurrentLog = new Logement();
                bool Exist = false;

                foreach (Logement logement in AllLogements)
                {
                    if (logement.Location == location && logement.Area == area)
                    {
                        CurrentLog = logement;
                        Exist = true;
                    }
                }

                if (Exist == false)
                {
                    Console.WriteLine("No logement found");
                    Console.WriteLine("Please retry");
                    goto Retry;
                }
                else
                {
                    CurrentLog.Disponibility = true;
                }

            }
            if (entier == 1)
            {
            Retry:
                Console.WriteLine("What is the location of the home you want to remove from the sale?");
                string location = FirstLetterUpper(Console.ReadLine());
                Console.WriteLine("What is the area of the home you want to remove from the sale?");
                int area = SaisieNombre();

                Logement CurrentLog = new Logement();
                bool Exist = false;

                foreach (Logement logement in AllLogements)
                {
                    if (logement.Location == location && logement.Area == area)
                    {
                        CurrentLog = logement;
                        Exist = true;
                    }
                }

                if (Exist == false)
                {
                    Console.WriteLine("No logement found");
                    Console.WriteLine("Please retry");
                    goto Retry;
                }
                else
                {
                    CurrentLog.Disponibility = false;
                }
            }
        }

        public void AddMoney()
        {
            Console.WriteLine("How much money would you like to add to your account?");
            int Add = SaisieNombre();
            Money += Add;
            Console.WriteLine("Money Added succesfully.");
        }
        public void WithdrawMoney()
        {
        Retry:
            Console.WriteLine("How much money do you want to withdraw from your account?");
            int Withdraw = SaisieNombre();
            if (Withdraw <= Money)
            {
                Money -= Withdraw;
                Console.WriteLine("Withdrawal successfully completed.");
            }
            else
            {
                Console.WriteLine($"You don't have enough money on your account. Currently you harve {Money} euros on your account.");
                Console.WriteLine("Please retry");
                goto Retry;
            }
        }

        public void ShowMyLogements()
        {
            foreach (Logement L in MyLogements)
            {
                L.Display();
            }
            Console.WriteLine();
        }
    }
}
