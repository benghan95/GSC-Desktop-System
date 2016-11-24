using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class movie
    {
        //private string movieName {get; set;}
        //private string movieRating { get; set; }
        //private int movieDuration { get; set; }
        //private string summary { get; set; }
        //private string cinemaName { get; set; }
        //private string movieVenue { get; set; }
        //time?

        public movie()
        {
            
        }

        public string display()
        {
            //display as arraylist and print all movies 
            string query = ("Select Name from Movie;");
            string query2 =("Select MovieID from Movie;");

            SQL sql = new SQL();

            List<string> movieName = new List<string>();
            List<string> movieID = new List<string>();
            movieName = sql.Select(query);
            movieID = sql.Select(query2);

            int j = 1;
            foreach (string i in movieName)
            {
                
                Console.WriteLine(j+ ".{0}", i);
                j++;
            }

            Console.WriteLine("Select Movie:");
            int x = Convert.ToInt32(Console.ReadLine());
            string mInput = movieID.ElementAt(x-1);
            Console.WriteLine(mInput);
                return mInput;
        }

        public void displayDetails(string mInput) //displays all details of movie
        {
            string[] arr1 = { "Name","Rating", "Duration", "Summary","Cinema", "date", "time" };
            SQL sql = new SQL();
            List<string> details = new List<string>();
            foreach (string i in arr1)
            {
                String query = ("Select " + i + " from Movie where MovieID = " + mInput + " ;");
                //Console.WriteLine(query);
                details = sql.Select(query);
                foreach (string j in details)
                {
                    Console.WriteLine(i + ".{0}", j);
                    
                }
            }

        }

        public void Reserve(string mInput)
        {
            Console.WriteLine("How many Adult ticket - RM4.00");
            int adultTicket = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many Child ticket - RM3.00");
            int childTicket = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many Student ticket - RM2.00");
            int studentTicket = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many Senior Citizen ticket - RM1.00");
            int seniorTicket = Convert.ToInt32(Console.ReadLine());

            int totalPrice = (adultTicket * 4) + (childTicket*3) + (studentTicket*2) +(seniorTicket*1);
            int totalNum = (adultTicket + childTicket + studentTicket + seniorTicket);

            string query = ("Select Number from TicketHistory where MovieID = '" + mInput + ' and Sid = '2';");
            string query2 = ("Select MovieID from Movie;");

            SQL sql = new SQL();

            List<string> movieName = new List<string>();
            List<string> movieID = new List<string>();
            movieName = sql.Select(query);
            movieID = sql.Select(query2);
        }

        public void addMovie()
        {
            Console.WriteLine("Enter Movie name");
            string Mname = Console.ReadLine();
            Console.WriteLine("Enter Age Rating");
            string MRating = Console.ReadLine();
            Console.WriteLine("Enter Duration of Movie");
            string MDuration = Console.ReadLine();
            Console.WriteLine("Enter Summary of Movie");
            string MSummary = Console.ReadLine();

            string query = ("INSERT INTO Movie(Name, Rating, Duration, Summary) VALUES('" + Mname + "', '" + MRating +"', " + MDuration + ", '" +MSummary + "');");
            //Console.WriteLine(query);
            SQL sql = new SQL();
            sql.Insert(query);
            Console.WriteLine("Movie has been added");
        }

        public void editVenue()
        {
            string mID = display();
            string updateVenue = ("Update Movie SET Venue = 1 where MovieID = '3';")
        }

        public void deleteMovie()
        {
           string mID = display();
            string delete = ("")

        }



    }
}
