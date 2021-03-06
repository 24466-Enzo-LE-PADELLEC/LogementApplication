using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    //LE PADELLEC Enzo 24466
    class Customer : User
    {
        public int Money { get; set; }
        public string Phone { get; set; }
        public List<string> Transactions { get; set; }

        /// <summary>
        /// Allow to modify the profile of the current customer
        /// </summary>
        /// <param name="ConnectedCustomer">It's the connected customer</param>
        /// <param name="ModifAdmin">It allow to know if it's an admin or the customer who modifies the profile</param>
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

        /// <summary>
        /// Allow to add a logement on the application
        /// </summary>
        /// <param name="CurrentCustomer">It's the connected customer</param>
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

        /// <summary>
        /// Allow the customer to delete one of his logement from the application
        /// </summary>
        public void DeleteLogement()
        {
            if (MyLogements != null || MyLogements.Count != 0)
            {
            Retry:
                ShowLogements();
                Console.WriteLine("What is the ID of the seller?");
                string ID = Console.ReadLine();
                Console.WriteLine("What is the Location of the accommodation?");
                string Location = FirstLetterUpper(Console.ReadLine());
                Console.WriteLine("What is the size of the accommodation?");
                int Area = SaisieNombre();

                Customer seller = new Customer();
                Logement CurrentLog = new Logement();
                bool Exist = false;

                foreach (Logement logement in MyLogements)
                {
                    if (logement.Seller.ID == ID && logement.Location == Location && logement.Area == Area)
                    {
                        CurrentLog = logement;
                        seller = logement.Seller;
                        Exist = true;
                    }
                }

                if (Exist == false)
                {
                    Console.WriteLine("No logement found");
                    Console.WriteLine("Please retry");
                    goto Retry;
                }
                seller.MyLogements.Remove(CurrentLog);
                AllLogements.Remove(CurrentLog);
            }
            else
            {
                Console.WriteLine("No logement found.");
            }
        }

        /// <summary>
        /// Allow the customer to modify one of his logement from the application
        /// </summary>
        public void ModifyLogement()
        {
            if (MyLogements != null || MyLogements.Count != 0)
            {
            Retry:
                ShowLogements();
                Console.WriteLine("What is the ID of the seller?");
                string ID = Console.ReadLine();
                Console.WriteLine("What is the Location of the accommodation?");
                string Location = FirstLetterUpper(Console.ReadLine());
                Console.WriteLine("What is the size of the accommodation?");
                int Area = SaisieNombre();

                Customer seller = new Customer();
                Logement CurrentLog = new Logement();
                bool Exist = false;

                foreach (Logement logement in MyLogements)
                {
                    if (logement.Seller.ID == ID && logement.Location == Location && logement.Area == Area)
                    {
                        CurrentLog = logement;
                        seller = logement.Seller;
                        Exist = true;
                    }
                }

                if (Exist == false)
                {
                    Console.WriteLine("No logement found");
                    Console.WriteLine("Please retry");
                    goto Retry;
                }

            NewChange:

                Console.WriteLine($"\t{String.Format("{0,-15}", "Location")}\t{String.Format("{0,-15}", "Type Of Logement")}\t{String.Format("{0,-20}", "Price")}\t{String.Format("{0,-15}", "Area")}\t{String.Format("{0,-15}", "Disponibility")}");

                Console.WriteLine($"\t{String.Format("{0,-15}", CurrentLog.Location)}\t{String.Format("{0,-15}", CurrentLog.TypeOfLogement)}\t{String.Format("{0,-15}", CurrentLog.Price)}\t{String.Format("{0,-15}", CurrentLog.Area)}" +
                    $"\t{String.Format("{0,-15}", CurrentLog.Disponibility)}");

                Console.WriteLine("What do you want to change ?");
                Console.WriteLine("=============================");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Location");
                Console.WriteLine("2 - Type Of Logement");
                Console.WriteLine("3 - Price");
                Console.WriteLine("4 - Area");
                Console.WriteLine("5 - Disponibility");

                string Choix = Console.ReadLine();

                if (Choix == "0")
                {
                    Console.WriteLine("Exit...");
                }
                else if (Choix == "1")
                {
                    Console.WriteLine("Enter the new location");
                    string NewLocation = FirstLetterUpper(Console.ReadLine());
                    CurrentLog.Location = NewLocation;
                    goto NewChange;
                }
                else if (Choix == "2")
                {
                    Console.WriteLine("Enter the new type of logement");
                    string NewTOL = FirstLetterUpper(Console.ReadLine());
                    CurrentLog.TypeOfLogement = NewTOL;
                    goto NewChange;
                }
                else if (Choix == "3")
                {
                    Console.WriteLine("Enter the new price");
                    int NewPrice = SaisieNombre();
                    CurrentLog.Price = NewPrice;
                    goto NewChange;
                }
                else if (Choix == "4")
                {
                    Console.WriteLine("Enter the new area");
                    int NewArea = SaisieNombre();
                    CurrentLog.Area = NewArea;
                    goto NewChange;
                }
                else if (Choix == "5")
                {
                    Console.WriteLine("Are you sure to want to change the disponibility of this accomodation ? If yes enter '1'. Else enter an another number.");
                    int change = SaisieNombre();
                    if (change == 1)
                    {
                        if (CurrentLog.Disponibility == true)
                        {
                            CurrentLog.Disponibility = false;
                        }
                        else
                        {
                            CurrentLog.Disponibility = true;
                        }
                    }
                    goto NewChange;
                }
                else
                {
                    Console.WriteLine("Please select a correct number");
                    goto NewChange;
                }
            }
            else
            {
                Console.WriteLine("No logement found.");
            }
        }

        /// <summary>
        /// Allow the use to buy a logement on the application
        /// </summary>
        /// <param name="ConnectedCustomer">It's the connected customer</param>
        public void BuyLogement(Customer ConnectedCustomer)
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
                Console.WriteLine("If you want to exit enter '0', if you want to retry press an another key.");
                string exit = Console.ReadLine();
                if (exit == "0")
                {
                    goto Exit;
                }
                Console.WriteLine("So please retry");
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
                CurrentLog.Seller = ConnectedCustomer;
                Console.WriteLine("Congrats for your purchase.");
            }
        Exit:
            Console.WriteLine();
        }

        //public void ChangeStateOfLogement(int entier) //uselles but exists
        //{
        //    if (entier == 0)
        //    {
        //        Retry:
        //        Console.WriteLine("What is the location of the home you want to offer for sale?");
        //        string location = FirstLetterUpper(Console.ReadLine());
        //        Console.WriteLine("What is the area of the home you want to offer for sale?");
        //        int area = SaisieNombre();

        //        Logement CurrentLog = new Logement();
        //        bool Exist = false;

        //        foreach (Logement logement in AllLogements)
        //        {
        //            if (logement.Location == location && logement.Area == area)
        //            {
        //                CurrentLog = logement;
        //                Exist = true;
        //            }
        //        }

        //        if (Exist == false)
        //        {
        //            Console.WriteLine("No logement found");
        //            Console.WriteLine("Please retry");
        //            goto Retry;
        //        }
        //        else
        //        {
        //            CurrentLog.Disponibility = true;
        //        }

        //    }
        //    if (entier == 1)
        //    {
        //    Retry:
        //        Console.WriteLine("What is the location of the home you want to remove from the sale?");
        //        string location = FirstLetterUpper(Console.ReadLine());
        //        Console.WriteLine("What is the area of the home you want to remove from the sale?");
        //        int area = SaisieNombre();

        //        Logement CurrentLog = new Logement();
        //        bool Exist = false;

        //        foreach (Logement logement in AllLogements)
        //        {
        //            if (logement.Location == location && logement.Area == area)
        //            {
        //                CurrentLog = logement;
        //                Exist = true;
        //            }
        //        }

        //        if (Exist == false)
        //        {
        //            Console.WriteLine("No logement found");
        //            Console.WriteLine("Please retry");
        //            goto Retry;
        //        }
        //        else
        //        {
        //            CurrentLog.Disponibility = false;
        //        }
        //    }
        //}

        /// <summary>
        /// Allow the customer to add money on the application
        /// </summary>
        public void AddMoney()
        {
            Console.WriteLine("How much money would you like to add to your account?");
            int Add = SaisieNombre();
            Money += Add;
            Console.WriteLine("Money Added succesfully.");
            Console.WriteLine($"You currently have {Money} on your account");
        }

        /// <summary>
        /// llow the customer to withdraw money from the application
        /// </summary>
        public void WithdrawMoney()
        {
        Retry:
            Console.WriteLine("How much money do you want to withdraw from your account?");
            int Withdraw = SaisieNombre();
            if (Withdraw <= Money)
            {
                Money -= Withdraw;
                Console.WriteLine("Withdrawal successfully completed.");
                Console.WriteLine($"You currently have {Money} on your account");
            }
            else
            {
                Console.WriteLine($"You don't have enough money on your account. You currently have {Money} euros on your account.");
                Console.WriteLine("Please retry");
                goto Retry;
            }
        }

        /// <summary>
        /// Allow the customer to see all of his logements
        /// </summary>
        public void ShowMyLogements()
        {
            foreach (Logement L in MyLogements)
            {
                L.Display();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Allow the customer to see his profile
        /// </summary>
        public void ShowProfile()
        {
            Console.WriteLine($"\t{String.Format("{0,-15}", "ID")}\t{String.Format("{0,-15}", "First Name")}\t{String.Format("{0,-15}", "Last Name")}\t{String.Format("{0,-15}", "Email")}\t{String.Format("{0,-15}", "Phone")}\t{String.Format("{0,-15}", "Money")}");

            Console.WriteLine($"\t{String.Format("{0,-15}", ID)}\t{String.Format("{0,-15}", FirstName)}\t{String.Format("{0,-15}", LastName)}\t{String.Format("{0,-15}", Email)}" +
                $"\t{String.Format("{0,-15}", Phone)}\t{String.Format("{0,-15}", Money)}");
            Console.WriteLine();
        }

        /// <summary>
        /// Allow the customer to see his Transactons
        /// </summary>
        public void ShowMyTransactions()
        {
            Console.WriteLine("YOUR TRANSACTIONS");
            Console.WriteLine();

            foreach(string transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
            Console.WriteLine();
        }
    }
}
