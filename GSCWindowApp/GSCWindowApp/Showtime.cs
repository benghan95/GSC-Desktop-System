using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
  class Showtime
  {
    public Showtime(){
    }
    public void addShowtime(){
      string input = null;
      string query = null;
      
      Movie movieList = new Movie();
      movieList.displayAllMovies();
      
      Console.Write("Enter movie ID to add showtime: ");
      input = Console.ReadLine();

      int movieID = 0;
      try{
        while(!Int32.TryParse(input, out movieID)){
          Console.Write("Movie ID must be an integer!");
          input = Console.ReadLine();
        }
      } catch (Exception e){
        Console.WriteLine(e);
      }
      query = ("SELECT COUNT(*) FROM Movie WHERE movieID=" + movieID + ";");
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
            Console.Write("Enter Showtime's Start DateTime (eg. 2016-09-25T13:00:00): ");
            input = Console.ReadLine();
            DateTime startDateTime = DateTime.Now;
            try{
              while(!DateTime.TryParse(input, out startDateTime)){
                Console.Write("Start DateTime must be a DateTime input! Please follow the format given.");
                Console.Write("Enter Showtime's Start DateTime (eg. 2016-09-25T13:00:00): ");
                input = Console.ReadLine();
              }
            } catch (Exception e){
              Console.WriteLine(e);
            }
            
            Hall hallList = new Hall();
            hallList.viewHallList();
            Console.Write("Select a hall of the showtime with Hall ID: ");
            input = Console.ReadLine();
    
            int hallID = 0;
            try{
              while(!Int32.TryParse(input, out hallID)){
                Console.Write("Hall ID must be an integer!");
                input = Console.ReadLine();
              }
            } catch (Exception e){
              Console.WriteLine(e);
            }
            
            query = ("SELECT COUNT(*) FROM Hall WHERE hallID=" + hallID + ";");
            
            cmd = new MySqlCommand(query, sql.Connection);
            try{
              temp = cmd.ExecuteScalar();
              sql.Connection.Close();
              int hallExists = Int32.Parse(temp.ToString());
              if(hallExists > 0){
                query = ("INSERT INTO Showtime(startDateTime, endDateTime, ticketsAvailable, movieID, hallID) VALUES('" + 
                             startDateTime.ToString("s") + "', '" + startDateTime.AddMinutes(movieList.getDuration(movieID)).ToString("s") + "', " + 
                             hallList.getCapacity(hallID) + ", " + movieID + ", " + hallID + ");");
                sql.Insert(query);
                Console.WriteLine("Showtime has been added");
              } else{
                Console.WriteLine("Hall does not exist!");
              }
            } catch (Exception e){
              Console.WriteLine(e);
            }
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
    public void displayShowtimes(){
      string query = ("SELECT * FROM Showtime;");
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
            Console.WriteLine("--------------- Showtime " + counter +" ---------------");
            Console.WriteLine("Showtime ID: " + reader.GetInt32(0));
            Console.WriteLine("Start DateTime: " + reader.GetDateTime(1).ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            Console.WriteLine("End DateTime: " + reader.GetDateTime(2).ToString("dd MMM yyyy HH:mm:ss", CultureInfo.InvariantCulture));
            Console.WriteLine("Tickets Available: " + reader.GetInt32(3));
            Console.WriteLine("Movie ID: " + reader.GetInt32(4));
            Console.WriteLine("Hall ID: " + reader.GetInt32(5));
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
    public void removeShowtime(){
      Console.Write("Enter the showtime ID to be removed: ");
      string input = Console.ReadLine();
      int showtimeID = 0;
      try{
        while(!Int32.TryParse(input, out showtimeID)){
          Console.Write("Showtime ID must be an integer!");
          input = Console.ReadLine();
        }
      } catch (Exception e){
        Console.WriteLine(e);
      }
      string query = ("SELECT COUNT(*) FROM Showtime WHERE showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          sql.Connection.Close();
          int showtimeExists = Int32.Parse(temp.ToString());
          if(showtimeExists > 0){
            query = ("DELETE FROM Showtime WHERE showtimeID=" + showtimeID + ";");
            sql.Delete(query);
            Console.WriteLine("Showtime ID " + showtimeID + " has been deleted!");
          } else{
            Console.WriteLine("No such showtime ID! Please try again later.");
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
  }
}
