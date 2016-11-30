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
    public void reserveSeats(int showtimeID, string[] selectedSeats, List<Ticket> ticketList){

            Console.WriteLine("The size of ticket list after moving is " + ticketList.Count);
            string query = ("SELECT seatsLayout FROM Showtime WHERE showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      try{
        sql.Connection.Open();
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        MySqlDataReader reader = cmd.ExecuteReader();
        string seatsLayout = null;
        while(reader.Read()){
          seatsLayout = reader.GetString(0);
        }
                sql.Connection.Close();

                int i = 0;
        int tickCode = 0;
        foreach (Ticket tick in ticketList)
                {
                    Console.WriteLine("lol");
                }
        foreach (Ticket tick in ticketList)
        {
             seatsLayout = seatsLayout.Replace((selectedSeats[i] + " "), "");
             query = ("INSERT INTO Ticket (seatNo, ticketPrice, ticketType, showtimeID) " +
                          "VALUES('" + selectedSeats[i] + "', " + (double)tick.TicketPrice +
                          ", '" + tick.TicketType + "', " + showtimeID + ");");
                    Console.WriteLine(query);
             sql.Insert(query);
                query = ("SELECT ticketID from Ticket \nWHERE seatNo='" +
                                selectedSeats[i] + "' \nAND showtimeID=" + showtimeID + ";");
                    Console.WriteLine(query);
                    MySqlCommand anotherCmd = new MySqlCommand(query, sql.Connection);
                    sql.Connection.Open();
                    reader = anotherCmd.ExecuteReader();
                    reader.Read();
                    tickCode = reader.GetInt32(0);
                    sql.Connection.Close();
                    tick.TicketCode = tickCode;
                    Console.WriteLine("ticket code is: " + tick.TicketCode);
                    i++;
        }
                
                seatsLayout = seatsLayout.Replace("\n", " ");
                seatsLayout = seatsLayout.Replace("  ", " ");
                
        query = ("UPDATE Showtime SET seatsLayout='" + seatsLayout + "' WHERE showtimeID=" + showtimeID + ";");
        sql.Update(query);
        query = ("UPDATE Showtime SET ticketsAvailable = ticketsAvailable - " + selectedSeats.Length + " WHERE showtimeID=" + showtimeID + ";");
        sql.Update(query);

       
                Console.WriteLine("The seats have been reserved!");
      } catch(Exception e){
        Console.WriteLine(e);
      }
    }
    public void viewSeatsLayout(int showtimeID){
      string query = ("SELECT seatsLayout FROM Showtime WHERE showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        MySqlDataReader reader = cmd.ExecuteReader();
        while(reader.Read()){
          Console.WriteLine("------------------------------------------------------------");
          Console.WriteLine("\tSeats Layout of Showtime ID: " + showtimeID);
          Console.WriteLine("------------------------------------------------------------");
          Console.WriteLine("========================================================");
          Console.WriteLine("------------------------ SCREEN ------------------------");
          Console.WriteLine("========================================================");
          Console.WriteLine(reader.GetString(0));
          Console.WriteLine("------------------------------------------------------------");
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
      } catch(Exception e){
        Console.WriteLine(e);
      }
    }
    public void addShowtime(){
      string input = null;
      string query = null;
      
      Movie movieList = new Movie();
      movieList.displayAllMovies();
      
      Console.Write("Enter movie ID to add showtime: ");
      input = Console.ReadLine();
      int movieID = ParseInt(input);
      
      query = ("SELECT COUNT(*) FROM Movie WHERE movieID=" + movieID + ";");
      SQL sql = new SQL();
      if(sql.checkRowExists(query) > 0){
        Console.Write("Enter Showtime's Start DateTime (eg. 2016-09-25T13:00:00): ");
        input = Console.ReadLine();
        DateTime startDateTime = ParseDateTime(input);
        
        Hall hallList = new Hall();
        hallList.viewHallList();
        Console.Write("Select a hall of the showtime with Hall ID: ");
        input = Console.ReadLine();
        int hallID = ParseInt(input);
        
        query = ("SELECT COUNT(*) FROM Hall WHERE hallID=" + hallID + ";");
        
        if(sql.checkRowExists(query) > 0){
          query = ("INSERT INTO Showtime(startDateTime, endDateTime, ticketsAvailable, seatsLayout, movieID, hallID) VALUES('" + 
                         startDateTime.ToString("s") + "', '" + startDateTime.AddMinutes(movieList.getDuration(movieID)).ToString("s") + "', " + 
                         hallList.getCapacity(hallID) + ", '" + hallList.generateSeatsLayout(hallID) + "', " + movieID + ", " + hallID + ");");
          sql.Insert(query);
          Console.WriteLine("Showtime has been added");
        } else{
          Console.WriteLine("Hall does not exist!");
        }
      } else{
        Console.WriteLine("No such movie ID! Please try again later.");
      }
    }
    public void findMovieShowtimes(){
      string input = null;
      DateTime currentDateTime = new DateTime();
      currentDateTime = DateTime.Now.AddMinutes(-45);
      DateTime tomorrowDateTime = new DateTime();
      tomorrowDateTime = DateTime.Now.AddDays(2);
      
      Console.Write("Enter the Movie Name to View Showtimes: ");
      input = Console.ReadLine();
      
      string query = ("SELECT COUNT(*) FROM Movie WHERE name LIKE '%" + input + "%';");
      SQL sql = new SQL();
      if(sql.checkRowExists(query) > 0){
                Console.WriteLine("ada bang ada");
        query = ("SELECT movieID FROM Movie WHERE name LIKE '%" + input + "%';");
        try{
          sql.Connection.Open();
          MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
          object temp = cmd.ExecuteScalar();
          int movieID = Int32.Parse(temp.ToString());
          query = ("SELECT name FROM Movie WHERE movieID=" + movieID + ";");
          cmd = new MySqlCommand(query, sql.Connection);
          temp = cmd.ExecuteScalar();
          sql.Connection.Close();
          string movieName = temp.ToString();
          query = ("SELECT COUNT(*) FROM Showtime WHERE movieID=" + movieID + ";");
          if(sql.checkRowExists(query) > 0){
            Console.WriteLine("Movie Name: " + movieName);
            Console.WriteLine("Available Showtimes: ");
            query = ("SELECT st.startDateTime FROM Showtime st INNER JOIN Movie m ON st.movieID = m.movieID " +
                      "WHERE st.movieID=" + movieID + 
                      " AND st.endDateTime <= '" + tomorrowDateTime.ToString("s") + "' ORDER BY st.startDateTime ASC;");
            sql.Connection.Open();
            cmd = new MySqlCommand(query, sql.Connection);
            MySqlDataReader reader = cmd.ExecuteReader();
            int counter = 1;
            while(reader.Read()){
              Console.WriteLine(counter + ". " + reader.GetDateTime(0).ToString("HH:mm", CultureInfo.InvariantCulture));
              counter++;
            }
            sql.Connection.Close();
          } else{
            Console.WriteLine("No showtime available for the movie " + movieName);
          }
        } catch(Exception e){
          Console.WriteLine(e);
        }
        
      } else{
        Console.WriteLine("There is no movie that contains the keyword provided.");
      }
    }
    public void displayTodaysShowtimes(){
      DateTime currentDateTime = new DateTime();
      currentDateTime = DateTime.Now.AddMinutes(-45);
      DateTime tomorrowDateTime = new DateTime();
      tomorrowDateTime = DateTime.Now.AddDays(2);
            //Console.WriteLine("sampai sini juga dong");

            string query = ("SELECT st.showtimeID, m.name, st.startDateTime FROM Showtime st INNER JOIN Movie m ON st.movieID = m.movieID " +
                   
                      " WHERE st.endDateTime <= '" + tomorrowDateTime.ToString("s") + "' ORDER BY st.movieID ASC, st.startDateTime ASC;");
                    
        SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          MySqlDataReader reader = cmd.ExecuteReader();
          int counter = 1;
          while(reader.Read()){
            Console.WriteLine("--------------- Showtime " + counter +" ---------------");
            Console.WriteLine("Showtime ID : " + reader.GetInt32(0));
            Console.WriteLine("Movie Name  :  " + reader.GetString(1));
            Console.WriteLine("Time        : " + reader.GetDateTime(2).ToString("HH:mm", CultureInfo.InvariantCulture));
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
    public void displayShowtimes(){
      string query = ("SELECT * FROM Showtime;");
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
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
            Console.WriteLine("Movie ID: " + reader.GetInt32(5));
            Console.WriteLine("Hall ID: " + reader.GetInt32(6));
            Console.WriteLine("");
            counter++;
          }
          sql.Connection.Close();
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
    public void removeShowtime(){
      Console.Write("Enter the showtime ID to be removed: ");
      string input = Console.ReadLine();
      int showtimeID = ParseInt(input);
      
      string query = ("SELECT COUNT(*) FROM Showtime WHERE showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      if(sql.checkRowExists(query) > 0){
        query = ("DELETE FROM Showtime WHERE showtimeID=" + showtimeID + ";");
        sql.Delete(query);
        Console.WriteLine("Showtime ID " + showtimeID + " has been deleted!");
      } else{
        Console.WriteLine("No such showtime ID! Please try again later.");
      }
    }
    private int ParseInt(string input){
      int value = 0;
      try{
        while(!Int32.TryParse(input, out value)){
          Console.Write("Input must be an integer! Please re-enter a valid integer: ");
          input = Console.ReadLine();
        }
      } catch (Exception e){
        Console.WriteLine(e);
      }
      
      return value;
    }
    private DateTime ParseDateTime(string input){
      DateTime value = new DateTime();
      try{
        while(!DateTime.TryParse(input, out value)){
          Console.WriteLine("Input must be a DateTime format! Please follow the format given.");
          Console.Write("Please re-enter a valid DateTime by following the format <2016-09-25T13:00:00>: ");
          input = Console.ReadLine();
        }
      } catch (Exception e){
        Console.WriteLine(e);
      }
      return value;
    }
  }
}
