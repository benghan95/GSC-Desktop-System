using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class Movie
    {
        private string name { get; set;}
        private string rating { get; set; }
        private int duration { get; set; }
        private string summary { get; set; }
        private DateTime createdDate { get; set; }
        private DateTime endDate { get; set; }
        
        public Movie()
        {
          name = null;
          rating = null;
          duration = 0;
          summary = null;
          createdDate = DateTime.Now;
          endDate = DateTime.Now;
        }
        public void addMovie(){
          string input = null;
          
          Console.Write("Enter Movie's name: ");
          string movieName = Console.ReadLine();
          
          Console.Write("Enter Age Rating of the movie: ");
          string movieRating = Console.ReadLine();
          
          Console.Write("Enter Duration of the movie: ");
          input = Console.ReadLine();
          
          int movieDuration = 0;
          try{
            while(!Int32.TryParse(input, out movieDuration)){
              Console.Write("Duration must be an integer!");
              input = Console.ReadLine();
            }
          } catch (Exception e){
            Console.WriteLine(e);
          }
          
          Console.WriteLine("Enter Summary of the movie");
          string movieSummary = Console.ReadLine();
          
          Console.WriteLine("Enter Starting Date of the movie");
          input = Console.ReadLine();
          DateTime startingDate = DateTime.Now;
          try{
            while(!DateTime.TryParse(input, out startingDate)){
              Console.Write("Please enter a valid date format!");
              input = Console.ReadLine();
            }
          } catch (Exception e){
            Console.WriteLine(e);
          }
          
          Console.WriteLine("Enter Ending Date of the movie");
          input = Console.ReadLine();
          DateTime endingDate = DateTime.Now;
          try{
            while(!DateTime.TryParse(input, out endingDate)){
              Console.Write("Please enter a valid date format!");
              input = Console.ReadLine();
            }
          } catch (Exception e){
            Console.WriteLine(e);
          }

          string query = ("INSERT INTO Movie(Name, Rating, Duration, Summary, StartingDate, EndingDate, CreatedDate) VALUES('" + 
                           movieName + "', '" + movieRating + "', " + movieDuration + ", '" +
                           movieSummary + "', " + startingDate + ", " + endingDate + ", " + DateTime.Now + ");");
          Console.WriteLine("Query: " + query);
          SQL sql = new SQL();
          sql.Insert(query);
          Console.WriteLine("Movie has been added");
        }
        public void displayMovie(string movieName){
          string query = ("SELECT * FROM Movie WHERE Name=" + movieName);
          SQL sql = new SQL();
          try
          {   
            sql.Connection.Open();
            Console.WriteLine("Connected to the database");
            MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
            try{
              MySqlDataReader reader = cmd.ExecuteReader();
              while(reader.Read()){
                Console.WriteLine("Movie ID: " + reader.GetInt32(0));
                Console.WriteLine("Movie Name: " + reader.GetString(1));
                Console.WriteLine("Movie Rating: " + reader.GetString(2));
                Console.WriteLine("Movie Duration: " + reader.GetInt32(3));
                Console.WriteLine("Movie Summary: " + reader.GetString(4));
                Console.WriteLine("Created Date: " + reader.GetDateTime(5).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
                Console.WriteLine("End Date: " + reader.GetDateTime(6).ToString("dd MMM yyyy", CultureInfo.InvariantCulture));
              }
            } catch(Exception e){
              Console.WriteLine(e);
            }
            sql.Connection.Close();
          }
          catch (MySqlException e)
          {
            switch (e.Number)
            {
              case 0:
                Console.WriteLine("Cannot connect to server. Please contact administrator!");
                Console.WriteLine(e);
                break;

              case 1045:
                Console.WriteLine("Invalid username/password, please try again");
                Console.WriteLine(e);
                break;
            }
          }
        }
        public void editMovie(){
          
        }
        public string displayAllMovies()
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
            string[] arr1 = { "Name","Rating", "Duration", "Summary", "CreatedDate", "EndDate"};
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

            //string query = ("Select Number from TicketHistory where MovieID = '" + mInput + ' and Sid = '2';");
            string query2 = ("Select MovieID from Movie;");

            SQL sql = new SQL();

            List<string> movieName = new List<string>();
            List<string> movieID = new List<string>();
            //movieName = sql.Select(query);
            movieID = sql.Select(query2);
        }

        public void editVenue()
        {
            string mID = display();
            string updateVenue = ("Update Movie SET Venue = 1 where MovieID = '3';");
        }

        public void deleteMovie()
        {
           string mID = display();
            string delete = ("");

        }



    }
}
