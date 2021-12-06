using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    class Administrator : User
    {
        /// <summary>
        /// Allow to create a user (admin or customer)
        /// </summary>
        /// <param name="ListOfUser">List of List of User.</param>
        public void CreateUser(List<List<User>> ListOfUser)
        {
            int Choice = 100;

            while (Choice > 0)
            {
                Console.WriteLine("CREATE A USER :");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.WriteLine("1 - Add Customer");
                Console.WriteLine();
                Console.WriteLine("2 - Add Administrator");
                Console.WriteLine();
                Choice = SaisieNombre();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        break;
                    case 1:
                        Console.WriteLine("First Name ?");
                        string FirstNameCustomer = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameCustomer = FirstLetterUpper(Console.ReadLine());

                        //Console.WriteLine("ID ?");
                        //string IDCustomer = Console.ReadLine().ToLower();

                        Console.WriteLine("Email ?");
                        string EmailCustomer = Console.ReadLine().ToLower();

                        Console.WriteLine("Phone number ?");
                        string PhoneNumberCustomer = Console.ReadLine();

                        Console.WriteLine("Money ?");
                        int MoneyCustomer = SaisieNombre();

                        Customer customer = new Customer() { FirstName = FirstNameCustomer, LastName = LastNameCustomer, Email = EmailCustomer, Phone = PhoneNumberCustomer, Money = MoneyCustomer, Transactions = new List<string> { }, MyLogements = new List<Logement> { }, AllLogements = new List<Logement> { } };
                        CreatePIN(customer, 0);

                        ListOfUser[0].Add(customer);
                        Console.WriteLine("Customer added");

                        Console.WriteLine();
                        break;
                    case 2:
                        Console.WriteLine("First Name ?");
                        string FirstNameAdmin = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameAdmin = FirstLetterUpper(Console.ReadLine());

                        //Console.WriteLine("ID ?");
                        //string IDAdmin = Console.ReadLine().ToLower();

                        Console.WriteLine("Email ?");
                        string EmailAdmin = Console.ReadLine().ToLower();

                        Administrator administrator = new Administrator() { FirstName = FirstNameAdmin, LastName = LastNameAdmin, Email = EmailAdmin, AllLogements = new List<Logement> { } };
                        CreatePIN(administrator, 2);
                        ListOfUser[2].Add(administrator);
                        Console.WriteLine("Administrator added");

                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This number is not affected");
                        Console.WriteLine("Please choose between indicated ones");
                        break;
                }
            }
            //return ListOfUser;
        }

        /// <summary>
        /// Allow to show all the users
        /// </summary>
        /// <param name="ListOfUser">List of List of User.</param>
        /// <param name="TypeOfUser">Type of user (admin or customer)</param>
        public void ShowUsers(List<List<User>> ListOfUser, int TypeOfUser)
        {
            Console.WriteLine($"\t{String.Format("{0,-15}", "ID")}\t{String.Format("{0,-15}", "First Name")}\t{String.Format("{0,-15}", "Last Name")}\t{String.Format("{0,-15}", "Email")}");

            if (0 <= TypeOfUser && TypeOfUser <= 2)
            {
                foreach (User Client in ListOfUser[TypeOfUser]) //Changer le User pour mettre Client ou Faculty ou Admin pour avoir les .QuelqueChose qui conviennent
                {
                    Console.WriteLine($"\t{String.Format("{0,-15}", Client.ID)}\t{String.Format("{0,-15}", Client.FirstName)}\t{String.Format("{0,-15}", Client.LastName)}\t{String.Format("{0,-15}", Client.Email)}");
                }
            }
            else
            {
                foreach (List<User> ListUser in ListOfUser)
                {
                    foreach (User Client in ListUser)
                    {
                        Console.WriteLine($"\t{String.Format("{0,-15}", Client.ID)}\t{String.Format("{0,-15}", Client.FirstName)}\t{String.Format("{0,-15}", Client.LastName)}\t{String.Format("{0,-15}", Client.Email)}");
                    }
                }
            }
        }

        /// <summary>
        /// Allow to modify a user.
        /// </summary>
        /// <param name="ListOfUser">List of List of User.</param>
        public void ModifyUser(List<List<User>> ListOfUser)
        {
            int Choice = 100;

            while (Choice > 0)
            {
                Console.WriteLine("MODIFY A USER :");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.WriteLine("1 - Modify Customer");
                Console.WriteLine();
                Console.WriteLine("2 - Modify Administrator");
                Console.WriteLine();
                Choice = SaisieNombre();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        break;
                    case 1:
                    #region Modify Customer
                    Retry:

                        ShowUsers(ListOfUser, 0);

                        Console.WriteLine("First Name ?");
                        string FirstNameCustomer = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameCustomer = FirstLetterUpper(Console.ReadLine());

                        Customer ConnectedCustomer = new Customer();
                        bool Exist = false;

                        foreach (Customer customer in ListOfUser[0])
                        {
                            if (customer.FirstName == FirstNameCustomer && customer.LastName == LastNameCustomer)
                            {
                                ConnectedCustomer = customer;
                                Exist = true;
                            }
                        }

                        if (Exist == false)
                        {
                            Console.WriteLine("No user found");
                            Console.WriteLine("Please retry");
                            goto Retry;
                        }

                        ConnectedCustomer.ModifyCustomer(ConnectedCustomer, true);

                        Console.WriteLine();
                        #endregion
                        break;

                    case 2:
                    #region Modify Administrator

                    Retry2:

                        ShowUsers(ListOfUser, 2);

                        Console.WriteLine("First Name ?");
                        string FirstNameAdmin = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameAdmin = FirstLetterUpper(Console.ReadLine());

                        Administrator ConnectedAdmin = new Administrator();
                        bool Exist3 = false;

                        foreach (Administrator administrator in ListOfUser[2])
                        {
                            if (administrator.FirstName == FirstNameAdmin && administrator.LastName == LastNameAdmin)
                            {
                                ConnectedAdmin = administrator;
                                Exist3 = true;
                            }
                        }

                        if (Exist3 == false)
                        {
                            Console.WriteLine("No user found");
                            Console.WriteLine("Please retry");
                            goto Retry2;
                        }

                    NewChange3:

                        Console.WriteLine($"\t{String.Format("{0,-15}", "ID")}\t{String.Format("{0,-15}", "First Name")}\t{String.Format("{0,-15}", "Last Name")}\t{String.Format("{0,-15}", "Email")}");

                        Console.WriteLine($"\t{String.Format("{0,-15}", ConnectedAdmin.ID)}\t{String.Format("{0,-15}", ConnectedAdmin.FirstName)}\t{String.Format("{0,-15}", ConnectedAdmin.LastName)}\t{String.Format("{0,-15}", ConnectedAdmin.Email)}");

                        Console.WriteLine("What do you want to change ?");
                        Console.WriteLine("=============================");
                        Console.WriteLine("0 - Exit");
                        Console.WriteLine("1 - First Name");
                        Console.WriteLine("2 - Last Name");
                        Console.WriteLine("3 - Email");
                        string Choix3 = Console.ReadLine();

                        if (Choix3 == "0")
                        {
                            Console.WriteLine("Exit...");
                        }
                        else if (Choix3 == "1")
                        {
                            Console.WriteLine("Enter the new first name");
                            string NewFirstName = FirstLetterUpper(Console.ReadLine());
                            ConnectedAdmin.FirstName = NewFirstName;
                            goto NewChange3;
                        }
                        else if (Choix3 == "2")
                        {
                            Console.WriteLine("Enter the new last name");
                            string NewLastName = FirstLetterUpper(Console.ReadLine());
                            ConnectedAdmin.LastName = NewLastName;
                            goto NewChange3;
                        }
                        else if (Choix3 == "3")
                        {
                            Console.WriteLine("Enter the new email");
                            string NewEmail = Console.ReadLine();
                            ConnectedAdmin.Email = NewEmail;
                            goto NewChange3;
                        }
                        else
                        {
                            Console.WriteLine("Please select a correct number");
                            goto NewChange3;
                        }

                        //LE NOM A CHANGE DONC L'ID DOIT AUSSI CHANGER

                        Console.WriteLine();
                        break;
                    #endregion
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This number is not affected");
                        Console.WriteLine("Please choose between indicated ones");
                        break;

                }
            }
            //return ListOfUser;
        }

        /// <summary>
        /// Allow to delete a user
        /// </summary>
        /// <param name="ListOfUser">List of List of User.</param>
        /// <returns></returns>
        public List<List<User>> DeleteUser(List<List<User>> ListOfUser)
        {
            int Choice = 100;

            while (Choice > 0)
            {
                Console.WriteLine("DELETE A USER :");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.WriteLine("1 - Delete Customer");
                Console.WriteLine();
                Console.WriteLine("2 - Delete Administrator");
                Console.WriteLine();
                Choice = SaisieNombre();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Exit...");
                        break;
                    case 1:
                    #region Delete Customer

                    Retry:

                        ShowUsers(ListOfUser, 0);

                        Console.WriteLine("Who do you want to delete");

                        Console.WriteLine("First Name ?");
                        string FirstNameCustomer = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameCustomer = FirstLetterUpper(Console.ReadLine());

                        Customer ConnectedCustomer = new Customer();
                        bool Exist = false;

                        foreach (Customer customer in ListOfUser[0])
                        {
                            if (customer.FirstName == FirstNameCustomer && customer.LastName == LastNameCustomer)
                            {
                                ConnectedCustomer = customer;
                                Exist = true;
                            }
                        }

                        if (Exist == false)
                        {
                            Console.WriteLine("No user found");
                            Console.WriteLine("Please retry");
                            goto Retry;
                        }

                        ListOfUser[0].Remove(ConnectedCustomer);
                        Console.WriteLine("Customer deleted");
                        ShowUsers(ListOfUser, 0);

                        #endregion
                        break;
                    case 2:
                    #region Delete Administrator

                    Retry3:

                        ShowUsers(ListOfUser, 2);

                        Console.WriteLine("Who do you want to delete");

                        Console.WriteLine("First Name ?");
                        string FirstNameAdmin = FirstLetterUpper(Console.ReadLine());

                        Console.WriteLine("Last Name ?");
                        string LastNameAdmin = FirstLetterUpper(Console.ReadLine());

                        Administrator ConnectedAdmin = new Administrator();
                        bool Exist3 = false;

                        foreach (Administrator administrator in ListOfUser[2])
                        {
                            if (administrator.FirstName == FirstNameAdmin && administrator.LastName == LastNameAdmin)
                            {
                                ConnectedAdmin = administrator;
                                Exist3 = true;
                            }
                        }

                        if (Exist3 == false)
                        {
                            Console.WriteLine("No user found");
                            Console.WriteLine("Please retry");
                            goto Retry3;
                        }

                        ListOfUser[2].Remove(ConnectedAdmin);
                        Console.WriteLine("Administrator deleted");
                        ShowUsers(ListOfUser, 2);

                        #endregion
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This number is not affected");
                        Console.WriteLine("Please choose between indicated ones");
                        break;

                }
            }
            return ListOfUser;
        }

        /// <summary>
        /// Allow to delete a logement
        /// </summary>
        public void DeleteLogement()
        {
            if (AllLogements != null || AllLogements.Count != 0)
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

                foreach (Logement logement in AllLogements)
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
        /// Allow to modify a logement
        /// </summary>
        public void ModifyLogement()
        {
            if (AllLogements != null || AllLogements.Count != 0)
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

                foreach (Logement logement in AllLogements)
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

                Console.WriteLine($"\t{String.Format("{0,-15}", "Location")}\t{String.Format("{0,-15}", "Type Of Logement")}\t{String.Format("{0,-15}", "Price")}\t{String.Format("{0,-15}", "Area")}\t{String.Format("{0,-15}", "Disponibility")}");

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
    }
}
