using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogementApplication.Models;

namespace LogementApplication
{
    class Program
    {
        /// <summary>
        /// Launches the application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            List<List<User>> ListOfUser = CreationListOfUser();

            #region MENU
            int Choice = 100;

            while (Choice > 0)
            {
                Console.WriteLine("Welcome in Logement Application (by 24466 Enzo Le Padellec)");
                Console.WriteLine("-----------------------");
                Console.WriteLine("Please connect you :");
                Console.WriteLine("--------------------");

                string IDConnectedUser = User.Login(ListOfUser);
                string TypeOfUser = (IDConnectedUser[0] + "").ToLower();

                if (TypeOfUser == "c")
                {
                    Choice = 1;
                }
                else if (TypeOfUser == "a")
                {
                    Choice = 2;
                }

                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Closing program.cs");
                        break;
                    case 1:
                        CustomertMenu(IDConnectedUser, ListOfUser[0]);
                        Console.WriteLine();
                        break;
                    case 2:
                        AdminMenu(IDConnectedUser, ListOfUser);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Problem with your ID");
                        Console.WriteLine("Please contact an administrator");
                        break;

                }
            }
            Console.ReadKey();
            #endregion  
        }

        /// <summary>
        /// allow to obtain an integer when we need to have one
        /// </summary>
        /// <returns>an integer.</returns>
        public static int SaisirNbre()
        {
            int n = 0;
            bool parseOk;
            do
            {
                Console.WriteLine();
                Console.WriteLine("What do you want to do ?");
                parseOk = int.TryParse(Console.ReadLine(), out n);
            }
            while (n < 0 || parseOk == false);

            return n;
        }

        /// <summary>
        /// Menu of the application when you are a customer
        /// </summary>
        /// <param name="ID">ID of the customer, usefull to find the customer among the all customers</param>
        /// <param name="ListOfCustomer">List of the customers</param>
        public static void CustomertMenu(string ID, List<User> ListOfCustomer)
        {
            Customer ConnectedCustomer = new Customer() { FirstName = "Bernard le calamard" };

            foreach (Customer customer in ListOfCustomer)
            {
                if (customer.ID == ID)
                {
                    ConnectedCustomer = customer;
                }
            }

            int Choice = 100;
            ConnectedCustomer.AllLoggements(ListOfCustomer);

            while (Choice > 0)
            {
                Console.WriteLine("CUSTOMER MENU :");
                Console.WriteLine();
                Console.WriteLine("Hello " + ConnectedCustomer.FirstName);
                Console.WriteLine();
                Console.WriteLine("0 - Log out");
                Console.WriteLine();
                Console.WriteLine("1 - Add a logement");
                Console.WriteLine();
                Console.WriteLine("2 - Modify one of my logements");
                Console.WriteLine();
                Console.WriteLine("3 - Delete one of my logements");
                Console.WriteLine();
                Console.WriteLine("4 - Add Money");
                Console.WriteLine();
                Console.WriteLine("5 - Withdraw Money");
                Console.WriteLine();
                Console.WriteLine("6 - Show my logements");
                Console.WriteLine();
                Console.WriteLine("7 - Show all the logements");
                Console.WriteLine();
                Console.WriteLine("8 - Buy a logement");
                Console.WriteLine();
                Console.WriteLine("9 - See my Transactions");
                Console.WriteLine();
                Console.WriteLine("10 - Profile");
                Console.WriteLine();
                Console.WriteLine("11 - Modify my profile");
                Console.WriteLine();
                Choice = SaisirNbre();

                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Log out...");
                        break;
                    case 1:
                        ConnectedCustomer.AddLogement(ConnectedCustomer);
                        Console.WriteLine();
                        break;
                    case 2:
                        ConnectedCustomer.ModifyLogement();
                        Console.WriteLine();
                        break;
                    case 3:
                        ConnectedCustomer.DeleteLogement();
                        Console.WriteLine();
                        break;
                    case 4:
                        ConnectedCustomer.AddMoney();
                        Console.WriteLine();
                        break;
                    case 5:
                        ConnectedCustomer.WithdrawMoney();
                        Console.WriteLine();
                        break;
                    case 6:
                        ConnectedCustomer.ShowMyLogements();
                        Console.WriteLine();
                        break;
                    case 7:
                        ConnectedCustomer.ShowLogements();
                        Console.WriteLine();
                        break;
                    case 8:
                        ConnectedCustomer.BuyLogement(ConnectedCustomer);
                        Console.WriteLine();
                        break;
                    case 9:
                        ConnectedCustomer.ShowMyTransactions();
                        Console.WriteLine();
                        break;
                    case 10 :
                        ConnectedCustomer.ShowProfile();
                        Console.WriteLine();
                        break;
                    case 11:
                        ConnectedCustomer.ModifyCustomer(ConnectedCustomer, false);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This number is not affected");
                        Console.WriteLine("Please choose between indicated ones");
                        break;
                }
            }
        }

        public static void AdminMenu(string ID, List<List<User>> ListOfUser)
        {
            Administrator ConnectedAdmin = new Administrator() { FirstName = "Bernard le calamard" };

            foreach (Administrator admin in ListOfUser[2])
            {
                if (admin.ID == ID)
                {
                    ConnectedAdmin = admin;
                }
            }

            int Choice = 100;
            ConnectedAdmin.AllLoggements(ListOfUser[0]);

            while (Choice > 0)
            {
                Console.WriteLine("ADMINISTRATOR MENU :");
                Console.WriteLine();
                Console.WriteLine("Hello " + ConnectedAdmin.FirstName);
                Console.WriteLine();
                Console.WriteLine("0 - Log out");
                Console.WriteLine();
                Console.WriteLine("1 - Delete Logement");
                Console.WriteLine();
                Console.WriteLine("2 - Modify Logement");
                Console.WriteLine();
                Console.WriteLine("3 - Add User");
                Console.WriteLine();
                Console.WriteLine("4 - Modify User");
                Console.WriteLine();
                Console.WriteLine("5 - Delete User");
                Console.WriteLine();
                Console.WriteLine("6 - Show Users");
                Console.WriteLine();
                Choice = SaisirNbre();
                switch (Choice)
                {
                    case 0:
                        Console.WriteLine("Log out...");
                        break;
                    case 1:
                        ConnectedAdmin.DeleteLogement();
                        Console.WriteLine();
                        break;
                    case 2:
                        ConnectedAdmin.ModifyLogement();
                        Console.WriteLine();
                        break;
                    case 3:
                        ConnectedAdmin.CreateUser(ListOfUser);
                        Console.WriteLine();
                        break;
                    case 4:
                        ConnectedAdmin.ModifyUser(ListOfUser); //MODIFER LES ID
                        Console.WriteLine();
                        break;
                    case 5:
                        ListOfUser = ConnectedAdmin.DeleteUser(ListOfUser);
                        Console.WriteLine();
                        break;
                    case 6:
                        ConnectedAdmin.ShowUsers(ListOfUser, 3);
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("This number is not affected");
                        Console.WriteLine("Please choose between indicated ones");
                        break;
                }
            }
        }

        /// <summary>
        /// Useful to initialize the application
        /// </summary>
        /// <returns>List of List of User.</returns>
        public static List<List<User>> CreationListOfUser()
        {
            List<List<User>> ListOfUser = new List<List<User>>();
            List<User> ListOfCustomer = new List<User>();
            List<User> Empty = new List<User>();
            List<User> ListOfAdministrator = new List<User>();

            Customer Alpha = new Customer() { FirstName = "Joe", LastName = "Smith", ID = "c", Money = 1400, Transactions = new List<string> { }, MyLogements = new List<Logement> { }, AllLogements = new List<Logement> { } };
            Administrator Charlie = new Administrator() { FirstName = "Charlie", LastName = "Smith", ID = "a", AllLogements = new List<Logement> { } };

            Logement L1 = new Logement { Location = "Dublin", TypeOfLogement = "House", Disponibility = false, Seller = Alpha, Area = 20, Price = 40000 };
            Alpha.MyLogements.Add(L1);

            ListOfCustomer.Add(Alpha);
            ListOfAdministrator.Add(Charlie);

            ListOfUser.Add(ListOfCustomer);
            ListOfUser.Add(Empty);
            ListOfUser.Add(ListOfAdministrator);

            Charlie.AllLoggements(ListOfCustomer);
            Alpha.AllLoggements(ListOfCustomer);

            return ListOfUser;
        }
    }
}
