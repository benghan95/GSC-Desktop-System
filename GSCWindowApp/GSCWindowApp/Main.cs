﻿using System;
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
            Admin admin = new Admin();
            //Console.WriteLine("Welcome to GSC");
            //Console.WriteLine("-------------------------------------------------");
            //Console.WriteLine("1.Search Movie");
            //Console.WriteLine("2.Reserve Movie Tickets");
            //Console.WriteLine("3.Login");
            //int menuInput = Convert.ToInt32(Console.ReadLine());
        //    bool loop = true;

        //    while (loop == true)
        //    {
        //        Console.WriteLine("Welcome to GSC");
        //        Console.WriteLine("-------------------------------------------------");
        //        Console.WriteLine("1.Search Movie");
        //        Console.WriteLine("2.Reserve Movie Tickets");
        //        Console.WriteLine("3.Login");
        //        string menuInput = Console.ReadLine();

        //        switch (menuInput)
        //        {
        //            case "1":
        //                Console.WriteLine("Search Movie");
        //                movie newCust = new movie();
        //                string mInput = newCust.display();
        //                newCust.displayDetails(mInput);
        //               // newCust.addMovie();
        //                Console.Read();
        //                Console.Clear();
        //                break;

        //            case "2":
        //                Console.WriteLine("Reserve Movie");
        //                Console.Read();
        //                Console.Clear();
        //                break;

        //            case "3":
        //                Console.WriteLine("Login");
        //                string inputID, inputPass;
        //                Console.WriteLine("Login ID:");
        //                inputID = Console.ReadLine();
        //                Console.WriteLine("Password:");
        //                inputPass = Console.ReadLine();
        //                loginStaff(inputID, inputPass);
        //                Console.Clear();
        //                break;

        //            default:
        //                Console.WriteLine("Invalid Input. Enter numbers 1-3 only. Press any key to return to menu");
        //                Console.ReadKey();
        //                Console.Clear();
        //                break;
        //        }
        //    }

            

        //   /* List<string> fromdatabase = new List<string>();
        //    SQL sql = new SQL();
        //    String derp = ("SELECT Name FROM Movie");
        //    derp += ",";
        //    derp+= ("SELECT MovieID FROM Movie");
        //    fromdatabase = sql.Select(derp);

        //    foreach (string i in fromdatabase)
        //    {
        //        Console.WriteLine("{0}", i );
        //    }*/

        //    Console.ReadKey();
        //}
        //public static void loginStaff(string inputID, string inputPass)
        //{

        //    SQL sql = new SQL();

        //    List<string> loginInfo = new List<string>();
        //    List<string> loginPass = new List<string>();
        //    List<string> loginAdmin = new List<string>();

        //    loginInfo = sql.Select("Select LoginID from Staff");
        //    loginPass = sql.Select("Select Password from Staff;");
        //    loginAdmin = sql.Select("Select isAdmin from Staff;");

        //    int count = 0;
        //    Boolean login = false;
        //    Boolean pass = false;
        //    Boolean bAdmin = false;

        //    foreach (string i in loginInfo)
        //    {
        //        if(i == inputID)
        //        {
        //            login = true;
        //        }
        //        count++;
        //    }

        //    if(login == true)
        //    {
        //        string password = loginPass.ElementAt(count-1);
        //        Console.WriteLine(password);
        //        if(password.Equals(inputPass))
        //        {
        //            pass = true;
        //        }
        //    }

        //    if(pass==true)
        //    {
        //        string admin = loginAdmin.ElementAt(count-1);
        //        Console.WriteLine(admin);
                

        //        if(admin == "True")
        //        {
        //            bAdmin = true;
        //        }
        //    }

        //    if(login == true && pass == true && bAdmin == true)
        //    {
        //        Console.WriteLine("ADMIN VIEW");
        //        admin adminlogon = new admin();
        //        Console.ReadKey();
        //    }

        //    else if(login == true && pass == true && bAdmin == false)
        //    {
        //        Console.WriteLine("STAFF VIEW");
        //        staff stafflogon = new staff();
        //        stafflogon.staffUI();
        //        Console.ReadKey();
        //    }

        }


    }
}
