using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class admin: login
    {
        admin()
        {
            bool loop = true;

            while (loop == true)
            {
                Console.WriteLine("GSC Admin Panel");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("1. Add Movie");
                Console.WriteLine("2. Edit Movie");
                Console.WriteLine("3. Cancel Movie");
                Console.WriteLine("4. New Staff");
                string menuInput = Console.ReadLine();

                switch (menuInput)
                {
                    case "1":
                        Console.WriteLine("Add Movie");
                        break;

                    case "2":
                        Console.WriteLine("Edit Movie");
                        break;

                    case "3":
                        Console.WriteLine("Cancel Movie");
                        break;

                    case "4":
                        Console.WriteLine("New Staff");
                        break;                    

                    default:
                        Console.WriteLine("Invalid Input. Enter numbers 1-4 only. Press any key to return to menu");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
