using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
  class Ticket
  {
    private string ticketType;
    private int noOfTickets;
    private double ticketPrice;
    
    public Ticket()
    {
      this.ticketType = null;
      this.ticketPrice = 0.00;
      this.noOfTickets = 0;
    }
    public Ticket(string ticketType, int noOfTickets, double ticketPrice)
    {
      this.ticketType = ticketType;
      this.ticketPrice = ticketPrice;
      this.noOfTickets = noOfTickets;
    }
    
    public void buyTicket(){
      string input = null;
      string query = null;
      List<Ticket> selectedTicketList = new List<Ticket>();
      
      Showtime showtimeList = new Showtime();
      showtimeList.displayTodaysShowtimes();
      
      Console.Write("Enter showtime ID to purchase ticket: ");
      input = Console.ReadLine();
      int showtimeID = ParseInt(input);
      query = ("SELECT COUNT(*) FROM Showtime WHERE showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      
      if(sql.checkRowExists(query) > 0){
        selectedTicketList = selectTicket();
        int totalNoOfTickets = 0;
        foreach(Ticket ticket in selectedTicketList){
          totalNoOfTickets += ticket.NoOfTickets;
        }
        Console.WriteLine("Total No. of Tickets: " + totalNoOfTickets);
        showtimeList.viewSeatsLayout(showtimeID);
        string[] selectedSeats = new string[totalNoOfTickets];
        for(int i = totalNoOfTickets, j = 0; i > 0; i--, j++){
          Console.Write("Please choose the seats ID that you want (" + totalNoOfTickets + "remainings): ");
          selectedSeats[j] = Console.ReadLine();
        }
        displayTicketsInformation(selectedTicketList);
        bool online = true;
        while(online){
          Console.WriteLine("Do you want to proceed to payment? (Y/N)");
          input = Console.ReadLine();
          switch(input){
            case "Y":
              showtimeList.reserveSeats(showtimeID, selectedSeats);
              printTickets(showtimeID, selectedTicketList);
              break;
            case "N":
              showtimeList.reserveSeats(showtimeID, selectedSeats);
              Console.WriteLine("Please pay at the counter when you collect your ticket.");
              online = false;
              break;
            default:
              Console.WriteLine("Invalid Input. Enter either 'Y' or 'N'. Press any key to return to menu.");
              Console.ReadKey();
              Console.Clear();
              break;
          }
        }
      } else{
        Console.WriteLine("No showtime with the showtime ID given! Please try again later.");
      } 
    }
    public void displayTicketsInformation(List<Ticket> selectedTicketList){
      Console.WriteLine("==========================================");
      Console.WriteLine("-------------- Confirmation --------------");
      Console.WriteLine("==========================================");
      int i = 1;
      foreach(Ticket ticket in selectedTicketList){
        Console.WriteLine("\t" + i++ + ". " + ticket.TicketType + "\tx " + ticket.NoOfTickets + " = " + ticket.TicketPrice*ticket.NoOfTickets);
      }
    }
    public void printReceipt(List<Ticket> selectedTicketList){
      Console.WriteLine("==========================================");
      Console.WriteLine("------------- Ticket Receipt -------------");
      Console.WriteLine("==========================================");
      int i = 1;
      double totalAmount = 0;
      foreach(Ticket ticket in selectedTicketList){
        Console.WriteLine("\t" + i++ + ". " + ticket.TicketType + "\tx " + ticket.NoOfTickets + " = " + ticket.TicketPrice*ticket.NoOfTickets);
        totalAmount += ticket.TicketPrice * ticket.NoOfTickets;
      }
      Console.WriteLine("------------------------------------------");
      Console.WriteLine("\tTotal (include GST 6%): " + totalAmount*1.06);
      Console.WriteLine("------------------------------------------");
    }
    public void printTickets(int showtimeID, List<Ticket> selectedTicketList){
      string query = ("SELECT m.name FROM Showtime st INNER JOIN Movie m ON st.movieID = m.movieID " +
                      "WHERE st.showtimeID=" + showtimeID + ";");
      SQL sql = new SQL();
      sql.Connection.Open();
      MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
      object temp = cmd.ExecuteScalar();
      string movieName = temp.ToString();
      
      foreach(Ticket ticket in selectedTicketList){
        for(int counter = 0; counter < ticket.NoOfTickets; counter ++){
          Console.WriteLine("==========================================");
          Console.WriteLine("---------------- e-Ticket ----------------");
          Console.WriteLine("==========================================");
          Console.WriteLine("\t" + "Movie Name: " + movieName);
          Console.WriteLine("\t" + "Ticket Code: " + ticket.TicketPrice);
          Console.WriteLine("\t" + "Ticket Type: " + ticket.TicketType);
          Console.WriteLine("\t" + "Ticket Price: " + ticket.TicketPrice);
          Console.WriteLine("==========================================");
        }
      }
    }
    public List<Ticket> selectTicket(){
      List<Ticket> ticketList = new List<Ticket>();

      bool online = true;
      
      while(online){
        Console.WriteLine("=============================================");
        Console.WriteLine("---------------- Ticket Type ----------------");
        Console.WriteLine("=============================================");
        Console.WriteLine("  1. Adult ( > 18 )");
        Console.WriteLine("  2. Childen ( < 12 )");
        Console.WriteLine("  3. Student ( Provided w/ Student Card )");
        Console.WriteLine("  4. Senior ( > 60 )");
        Console.WriteLine("  5. Finish Adding Tickets");
        Console.WriteLine("---------------------------------------------");
        Console.Write("Enter Ticket Type: ");
        string input = Console.ReadLine();
        
        switch(input){
          case "1":
            Console.Write("Enter number of tickets (Adult): ");
            input = Console.ReadLine();
            Ticket adultTicket = new Ticket ("Adult", ParseInt(input), calcTicketPrice("Adult"));
            ticketList.Add(adultTicket);
            break;
          case "2":
            Console.Write("Enter number of tickets (Children): ");
            input = Console.ReadLine();
            Ticket childTicket = new Ticket ("Adult", ParseInt(input), calcTicketPrice("Adult"));
            ticketList.Add(childTicket);
            break;
          case "3":
            Console.Write("Enter number of tickets (Student): ");
            input = Console.ReadLine();
            Ticket studentTicket = new Ticket ("Adult", ParseInt(input), calcTicketPrice("Adult"));
            ticketList.Add(studentTicket);
            break;
          case "4":
            Console.Write("Enter number of tickets (Senior): ");
            input = Console.ReadLine();
            Ticket seniorTicket = new Ticket ("Adult", ParseInt(input), calcTicketPrice("Adult"));
            ticketList.Add(seniorTicket);
            break;
          case "5":
            Console.Write("--------------------------");
            Console.WriteLine("Finish adding tickets! Please Confirm the Tickets:");
            online = false;
            break;
          default:
            Console.WriteLine("Invalid Input. Enter numbers 1-4 only. Press any key to return to menu");
            Console.ReadKey();
            Console.Clear();
            break;
        }
      }
      
      return ticketList;
    }
    public double calcTicketPrice(string ticketType){
      switch(ticketType){
        case "Adult":
          return 14.00;
        case "Child":
          return 6.00;
        case "Student":
          return 8.00;
        case "Senior":
          return 7.00;
        default:
          Console.WriteLine("Invalid ticket type!");
          break;
      }
      return 0.00;
    }
    public string TicketType
    {
      get
      {
        return ticketType;
      }

      set
      {
        ticketType = value;
      }
    }

    public int NoOfTickets
    {
      get
      {
        return noOfTickets;
      }

      set
      {
        noOfTickets = value;
      }
    }

    public double TicketPrice
    {
      get
      {
        return ticketPrice;
      }

      set
      {
        ticketPrice = value;
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
