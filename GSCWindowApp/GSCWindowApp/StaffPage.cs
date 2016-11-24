using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class staff
    {
        public staff()
        {
        }

        public void staffUI() //staff version of UI which includes payment option
        {
            bool loop = true;

            while (loop == true)
            {

                Console.WriteLine("1.Search Movie");
                Console.WriteLine("2.Reserve Movie Tickets");
                Console.WriteLine("3.Login");
                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        Console.WriteLine("Search Movie");
                        movie newCust = new movie();

                        Console.Read();
                        Console.Clear();
                        break;

                    case "2":
                        Console.WriteLine("Reserve Movie");
                        Console.Read();
                        Console.Clear();
                        break;

                    case "3":
                        Console.WriteLine("Login");
                        Console.Read();
                        Console.Clear();
                        break;

                    case "4":
                        Console.WriteLine("Payment and print");
                        Console.Read();
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine("Invalid Input. Enter numbers 1-3 only. Press any key to return to menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }

}
