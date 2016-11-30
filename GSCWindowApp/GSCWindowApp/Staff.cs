using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
  public class Staff
  {
    public Staff()
    {
    }
    public void Initialize(){
      bool online = true;
      string option = null;

      while (online)
      {
        Console.WriteLine("=================================================");
        Console.WriteLine("---------------- GSC Staff Panel ----------------");
        Console.WriteLine("=================================================");
        Console.WriteLine("\t1. View Upcoming Showtimes");
        Console.WriteLine("\t2. Search Showtime");
        Console.WriteLine("\t3. Buy Movie Ticket");
        Console.WriteLine("\t4. Exit");
        Console.WriteLine("=================================================");
        Console.Write("Please select one option (1 - 4): ");
        
        option = Console.ReadLine();

        switch (option)
        {
          case "1":
            Console.WriteLine("------------------------------------");
            Console.WriteLine("---- 1. View Today's Showtimes ----");
            Console.WriteLine("------------------------------------");
            viewShowtimes();
            break;

          case "2":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--- 2. Search Showtime ---");
            Console.WriteLine("--------------------------");
            searchShowtimes();
            break;

          case "3":
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ 3. Buy Ticket -----");
            Console.WriteLine("--------------------------");
            buyTicket();
            break;
            
          case "4":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--------- 4. Exit --------");
            Console.WriteLine("--------------------------");
            online = false;
            break;
            
          default:
              Console.WriteLine("Invalid Input. Enter numbers 1-4 only. Press any key to return to menu");
              Console.ReadKey();
              Console.Clear();
              break;
        }
      }
    }
    private void viewShowtimes(){

            //Console.WriteLine("sampai sini dong");
      Showtime showtimeList = new Showtime();
      showtimeList.displayTodaysShowtimes();
    }
    private void searchShowtimes(){
      Showtime showtimeList = new Showtime();
      showtimeList.findMovieShowtimes();
    }
    private void buyTicket(){
      Ticket ticket = new Ticket();
      ticket.buyTicket();
    }
    public void authentication(){
      bool online = true;
      while(online){
        Console.Write("Enter username: ");
        string username = Console.ReadLine();
        
        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        
        if(password.Equals(getPassword(username))){
          Console.WriteLine("Login successful!");
          if(getIsAdmin(username)){
            Admin admin = new Admin();
            admin.Initialize();
            online = false;
          } else{
            Initialize();
            online = false;
          }
        } else{
          Console.WriteLine("Invalid Password! Please try again.");
        }
      }
    }
    public string getPassword(string username){
      string query = ("SELECT password FROM Staff WHERE username='" + username + "';");
      string password = null;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          password = temp.ToString();
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
      return password;
    }
    public bool getIsAdmin(string username){
      string query = ("SELECT isAdmin FROM Staff WHERE username='" + username + "';");
      bool isAdmin = false;
      SQL sql = new SQL();
      try
      {   
        sql.Connection.Open();
        Console.WriteLine("Connected to the database.");
        MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
        try{
          object temp = cmd.ExecuteScalar();
          isAdmin = Boolean.Parse(temp.ToString());
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
      return isAdmin;
    }
    public void addNewStaff(){
      string input = null;
      
      Console.Write("Enter Staff's username: ");
      string username = Console.ReadLine();
      
      Console.Write("Enter email of the new staff: ");
      string email = Console.ReadLine();
      
      Console.Write("Enter a password: ");
      string password = Console.ReadLine();
      
      Console.Write("Is the staff an admin? (true/false) : ");
      input = Console.ReadLine();
      
      bool isAdmin = false;
      try{
        while(!Boolean.TryParse(input, out isAdmin)){
          Console.Write("Input must be either 'true' or 'false'!");
          input = Console.ReadLine();
        }
      } catch (Exception e){
        Console.WriteLine(e);
      }

      string query = ("INSERT INTO Staff(username, email, password, isAdmin) VALUES('" + 
                       username + "', '" + email + "', '" + password + "', " + isAdmin + ");");
      SQL sql = new SQL();
      sql.Insert(query);
      Console.WriteLine("New Staff has been added");
    }
    public void displayAllStaffs(){
      string query = ("SELECT * FROM Staff;");
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
            Console.WriteLine("--------------- Staff " + counter +" ---------------");
            Console.WriteLine("Staff ID: " + reader.GetInt32(0));
            Console.WriteLine("Username: " + reader.GetString(1));
            Console.WriteLine("Email: " + reader.GetString(2));
            Console.WriteLine("Password: " + reader.GetString(3));
            Console.WriteLine("IsAdmin: " + reader.GetBoolean(4));
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
