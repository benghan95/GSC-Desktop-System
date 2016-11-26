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
        public Movie()
        {
        }
        public void addMovie(){
          string input = null;
          
          Console.Write("Enter Movie's name: ");
          string movieName = Console.ReadLine();
          
          Console.Write("Enter Age Rating of the movie: ");
          string ageRating = Console.ReadLine();
          
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
          
          Console.WriteLine("Enter Summary of the movie: ");
          string movieSummary = Console.ReadLine();
          
          //Console.WriteLine("Enter Created Date of the movie");
          //input = Console.ReadLine();
          //DateTime startingDate = DateTime.Now;
          //try{
          //  while(!DateTime.TryParse(input, out startingDate)){
          //    Console.Write("Please enter a valid date format!");
          //    input = Console.ReadLine();
          //  }
          //} catch (Exception e){
          //  Console.WriteLine(e);
          //}
          
          //Console.WriteLine("Enter Ending Date of the movie");
          //input = Console.ReadLine();
          //DateTime endingDate = DateTime.Now;
          //try{
          //  while(!DateTime.TryParse(input, out endingDate)){
          //    Console.Write("Please enter a valid date format!");
          //    input = Console.ReadLine();
          //  }
          //} catch (Exception e){
          //  Console.WriteLine(e);
          //}

          string query = ("INSERT INTO Movie(name, ageRating, duration, summary, createdDate, isAvailable) VALUES('" + 
                           movieName + "', '" + ageRating + "', " + movieDuration + ", '" +
                           movieSummary + "', '" + DateTime.Now.ToString("s") + "', true);");
          Console.WriteLine("Query: " + query);
          SQL sql = new SQL();
          sql.Insert(query);
          Console.WriteLine("Movie has been added");
        }
        public void displayMovie(string movieName){
          string query = ("SELECT * FROM Movie WHERE Name=" + movieName + ";");
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
                Console.WriteLine("Movie Age Rating: " + reader.GetString(2));
                Console.WriteLine("Movie Duration: " + reader.GetInt32(3));
                Console.WriteLine("Movie Summary: " + reader.GetString(4));
                Console.WriteLine("Created Date: " + reader.GetDateTime(5).ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                Console.WriteLine("Availability: " + reader.GetBoolean(6));
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
          Console.Write("Enter the movie ID to edit: ");
          string input = Console.ReadLine();
          int movieID = 0;
          try{
            while(!Int32.TryParse(input, out movieID)){
              Console.Write("Movie ID must be an integer!");
              input = Console.ReadLine();
            }
          } catch (Exception e){
            Console.WriteLine(e);
          }
          string query = ("SELECT COUNT(*) FROM Movie WHERE movieID=" + movieID + ";");
          SQL sql = new SQL();
          try
          {   
            sql.Connection.Open();
            Console.WriteLine("Connected to the database.");
            MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
            try{
              object temp = cmd.ExecuteScalar();
              int movieExists = Int32.Parse(temp.ToString());
              if(movieExists > 0){
                query = ("SELECT * FROM Movie WHERE movieID=" + movieID + ";");
                cmd = new MySqlCommand(query, sql.Connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read()){
                  Console.WriteLine("---------------------------------------");
                  Console.WriteLine("\tMovie ID: " + reader.GetInt32(0));
                  Console.WriteLine("---------------------------------------");
                  Console.WriteLine("Movie Name: " + reader.GetString(1));
                  Console.WriteLine("Movie Age Rating: " + reader.GetString(2));
                  Console.WriteLine("Movie Duration: " + reader.GetInt32(3));
                  Console.WriteLine("Movie Summary: " + reader.GetString(4));
                  Console.WriteLine("Created Date: " + reader.GetDateTime(5).ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                  Console.WriteLine("Availability: " + reader.GetBoolean(6));
                  Console.WriteLine("---------------------------------------");
                }
                sql.Connection.Close();
                Console.WriteLine("Enter the attribute that you want to edit: ");
                Console.WriteLine("(name/ageRating/duration/summary/createdDate/isAvailable)");
                input = Console.ReadLine();
                Console.Write("Enter the new value: ");
                string newValue = Console.ReadLine();
                sql.UpdateById("Movie", "movieID", movieID, input, newValue);
              } else{
                Console.WriteLine("No such movie ID! Please try again later.");
              }
            } catch(Exception e){
              Console.WriteLine(e);
            }
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
        public void displayAllMovies(){
          string query = ("SELECT * FROM Movie;");
          SQL sql = new SQL();
          try
          {   
            sql.Connection.Open();
            Console.WriteLine("Connected to the database");
            MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
            try{
              MySqlDataReader reader = cmd.ExecuteReader();
              int counter = 1;
              while(reader.Read()){
                Console.WriteLine("--------------- Movie " + counter +" ---------------");
                Console.WriteLine("Movie ID: " + reader.GetInt32(0));
                Console.WriteLine("Movie Name: " + reader.GetString(1));
                Console.WriteLine("Movie Age Rating: " + reader.GetString(2));
                Console.WriteLine("Movie Duration: " + reader.GetInt32(3));
                Console.WriteLine("Movie Summary: " + reader.GetString(4));
                Console.WriteLine("Created Date: " + reader.GetDateTime(5).ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
                Console.WriteLine("Availability: " + reader.GetBoolean(6));
                Console.WriteLine("");
                counter++;
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
        //public void Reserve(string mInput)
        //{
        //    Console.WriteLine("How many Adult ticket - RM4.00");
        //    int adultTicket = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("How many Child ticket - RM3.00");
        //    int childTicket = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("How many Student ticket - RM2.00");
        //    int studentTicket = Convert.ToInt32(Console.ReadLine());
        //    Console.WriteLine("How many Senior Citizen ticket - RM1.00");
        //    int seniorTicket = Convert.ToInt32(Console.ReadLine());

        //    int totalPrice = (adultTicket * 4) + (childTicket*3) + (studentTicket*2) +(seniorTicket*1);
        //    int totalNum = (adultTicket + childTicket + studentTicket + seniorTicket);

        //    //string query = ("Select Number from TicketHistory where MovieID = '" + mInput + ' and Sid = '2';");
        //    string query2 = ("Select MovieID from Movie;");

        //    SQL sql = new SQL();

        //    List<string> movieName = new List<string>();
        //    List<string> movieID = new List<string>();
        //    //movieName = sql.Select(query);
        //    movieID = sql.Select(query2);
        //}

        //public void editVenue()
        //{
        //    string mID = display();
        //    string updateVenue = ("Update Movie SET Venue = 1 where MovieID = '3';");
        //}

        //public void deleteMovie()
        //{
        //   string mID = display();
        //    string delete = ("");

        //}
    }
}
