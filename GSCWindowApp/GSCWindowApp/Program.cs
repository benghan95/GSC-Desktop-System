using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            // string[] lines = { "101,me", "201,derp", "301,help" };
            // System.IO.File.WriteAllLines(@"C:\Users\Cheh\Documents\Visual Studio 2015\test.txt", lines);

            Console.WriteLine("Welcome to GSC");
            Console.WriteLine("-------------------------------------------------\t 1.Search Movie \t  2.Reserve Movie Tickets \t 3.Login");
            int menuInput = Console.Readline():

            switch(menuInput)
            {
                case 1:
                    Console.WriteLine("Search Movie");
                    break;
                
                case 2:
                    Console.writeLine("Reserve Movie");
                    break;

                case 3:
                    int staff = IsStaff();
                    if(staff == 1)
                    {
                        Console.writeLine("HI STAFF");
                    }

                    else if (staff == 2)
                    {
                        Console.writeLine("HI ADMIN");
                    }
                    break;
            }
            

            Console.ReadKey();
        }

        public static int IsStaff()
        {
            Console.WriteLine("Please Enter user ID");
            string ID = Console.ReadLine();
            Console.WriteLine("Please Enter Password");
            string password = Console.ReadLine();
            
            int counter = 0;
            string line;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Cheh\Documents\Visual Studio 2015\test.txt");
            
            while ((line = file.ReadLine()) != null)
            {
                if (line.Contains(ID))
                {
                    char[] array = line.ToCharArray();

                    if (array[0] == '2')
                    {   
                        if (line.Contains(password))
                        {
                            return 1;
                        } 
                        
                    }

                    else if (array[0] == '3')
                    {
                        if (line.Contains(password))
                        {
                            return 2;
                        } 
                    }
                }

                counter++;
            }
            file.Close();
            return 0;
        }
    }
}
