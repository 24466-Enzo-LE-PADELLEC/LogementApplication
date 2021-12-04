using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogementApplication.Models
{
    abstract class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ID { get; set; }
        public string Email { get; set; }
        public List<Logement> AllLogements { get; set; }
        public List<Customer> Customers { get; set; }

        public static string Login(List<List<User>> ListOfUser)
        {
            string IDUser;

        Retry:

            Console.WriteLine("First Name ?");
            string FirstName = FirstLetterUpper(Console.ReadLine());

            Console.WriteLine("Last Name ?");
            string LastName = FirstLetterUpper(Console.ReadLine());

            Console.WriteLine("ID ?");
            string ID = Console.ReadLine();

            bool Exist = SearchID(ID, FirstName, LastName, ListOfUser);

            if (Exist == true)
            {
                Console.WriteLine("Connection...");
                IDUser = ID;
            }
            else
            {
                Console.WriteLine("This account doesn't exist.");

            Retry2:

                Console.WriteLine("0 - Exit");
                Console.WriteLine("1 - Retry");
                string Choix = Console.ReadLine();

                if (Choix == "0")
                {
                    IDUser = "0";
                }
                else if (Choix == "1")
                {
                    goto Retry;
                }
                else
                {
                    goto Retry2;
                }
            }
            return IDUser;
        }

        /// <summary>
        /// Method that puts the first letter of the word in uppercase (word -> Word)
        /// </summary>
        /// <param name="word">Word to change</param>
        /// /// <returns>Word with the first letter in uppercase</returns>
        public static string FirstLetterUpper(string word)
        {
            string mot = word.ToLower();
            string Word = (char.ToUpper(mot[0]) + mot.Substring(1));
            return Word;
        }
        public static bool SearchID(string id, string firstname, string lastname, List<List<User>> ListOfUser)
        {
            bool Exist = false;

            if (id[0] == 'c')
            {
                foreach (User user in ListOfUser[0])
                {
                    if (user.FirstName == firstname && user.LastName == lastname && user.ID == id)
                    {
                        Exist = true;
                    }
                }
            }
            else if (id[0] == 'a')
            {
                foreach (User user in ListOfUser[2])
                {
                    if (user.FirstName == firstname && user.LastName == lastname && user.ID == id)
                    {
                        Exist = true;
                    }
                }
            }
            return Exist;
        }

        /// <summary>
        /// Method that loops until an integer is entered by the user
        /// </summary>
        /// <returns>Integer</returns>
        public static int SaisieNombre()
        {
            int n;
            bool parse;
            do
            {
                parse = int.TryParse(Console.ReadLine(), out n);
            }
            while (parse == false || n <= 0);

            return n;
        }

        /// <summary>
        /// Method that creates the PIN number of a new user and links it to their account
        /// </summary>
        /// <param name="NewUser">New user added</param>
        public static void CreatePIN(User NewUser, int TypeUser)
        {
            string Length = Convert.ToString((NewUser.FirstName + NewUser.LastName).Length);

            string Alphabet = " abcdefghijklmnopqrstuvwxyz";

            string YY = "00";
            string ZZ = "00";
            for (int i = 1; i <= Alphabet.Length - 1; i++)
            {
                if (Alphabet[i] == NewUser.FirstName.ToLower()[0])
                {
                    YY = Convert.ToString(i);
                }

                if (Alphabet[i] == NewUser.LastName.ToLower()[0])
                {
                    ZZ = Convert.ToString(i);
                }
            }

            string PIN = "" + NewUser.FirstName.ToLower()[0] + NewUser.LastName.ToLower()[0] + "-" + Length + "-" + YY + "-" + ZZ;

            if (TypeUser == 0)
            {
                PIN = "c" + PIN;
            }
            else if (TypeUser == 2)
            {
                PIN = "a" + PIN;
            }
            else
            {
                Console.WriteLine("Bug Type User");
            }



            NewUser.ID = PIN;
        }
        public void ShowLogements()
        {
            foreach (Logement L in AllLogements)
            {
                L.Display();
            }
            Console.WriteLine();
        }
    }
}
