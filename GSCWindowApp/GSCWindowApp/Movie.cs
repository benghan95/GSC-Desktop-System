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
    
    public string getMovieName(int movieID){
      string query = ("SELECT name FROM Movie WHERE movieID=" + movieID + ";");
      string movieName = null;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          movieName = temp.ToString();
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
      return movieName;
    }
    public string getAgeRating(int movieID){
      string query = ("SELECT ageRating FROM Movie WHERE movieID=" + movieID + ";");
      string ageRating = null;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          ageRating = temp.ToString();
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
      return ageRating;
    }
    public int getDuration(int movieID){
      string query = ("SELECT duration FROM Movie WHERE movieID=" + movieID + ";");
      int duration = 0;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          duration = Int32.Parse(temp.ToString());
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
      return duration;
    }
    public string getMovieSummary(int movieID){
      string query = ("SELECT summary FROM Movie WHERE movieID=" + movieID + ";");
      string movieSummary = null;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          movieSummary = temp.ToString();
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
      return movieSummary;
    }
    public DateTime getCreatedDate(int movieID){
      string query = ("SELECT createdDate FROM Movie WHERE movieID=" + movieID + ";");
      DateTime createdDate = DateTime.Now;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          createdDate = DateTime.Parse(temp.ToString());
          
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
      return createdDate;
    }
    public bool getAvailability(int movieID){
      string query = ("SELECT isAvailable FROM Movie WHERE movieID=" + movieID + ";");
      bool isAvailable = false;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          isAvailable = Boolean.Parse(temp.ToString());
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
      return isAvailable;
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
    public void removeMovie(){
      Console.Write("Enter the movie ID to be removed: ");
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
          sql.Connection.Close();
          int movieExists = Int32.Parse(temp.ToString());
          if(movieExists > 0){
            query = ("DELETE FROM Movie WHERE movieID=" + movieID + ";");
            sql.Delete(query);
            Console.WriteLine("Movie ID " + movieID + " has been deleted!");
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
  }
}
