using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    class Administrator : User
    {
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

                        Customer customer = new Customer() { FirstName = FirstNameCustomer, LastName = LastNameCustomer, Email = EmailCustomer, Phone = PhoneNumberCustomer, Money = MoneyCustomer };
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

                        Administrator administrator = new Administrator() { FirstName = FirstNameAdmin, LastName = LastNameAdmin, Email = EmailAdmin };
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

                        ConnectedCustomer.ModifyCustomer(true);

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
    
        public List<List<User>> DeleteUser(List<List<User>> ListOfUser)
        {
            int Choice = 100;

            while (Choice > 0)
            {
                Console.WriteLine("DELETE A USER :");
                Console.WriteLine();
                Console.WriteLine("0 - Exit");
                Console.WriteLine();
                Console.WriteLine("1 - Delete Student");
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
                    #region Delete Student

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
        public void DeleteLogement()
        {

        }
        public void ModifyLogement()
        {

        }
        public void AddMoney(List<List<User>> ListOfUser)
        {

        }
        public void WithdrawMoney(List<List<User>> ListOfUser)
        {

        }

    }
}
