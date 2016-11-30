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
        private int ticketCode;
    
    public Ticket()
    {
      this.ticketType = null;
      this.ticketPrice = 0.00;
      this.noOfTickets = 0;
            this.ticketCode = 0;
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
        int totalNoOfTickets = selectedTicketList.Count;
        Console.WriteLine("Total No. of Tickets: " + totalNoOfTickets);
        showtimeList.viewSeatsLayout(showtimeID);
        string[] selectedSeats = new string[totalNoOfTickets];
        for(int i = totalNoOfTickets, j = 0; i > 0; i--, j++){
          Console.Write("Please choose the seats ID that you want (" + i + "remainings): ");
                    
          selectedSeats[j] = Console.ReadLine();
        }
        displayTicketsInformation(selectedTicketList);
        bool online = true;
        while(online){
          Console.WriteLine("Do you want to proceed to payment? (Y/N)");
          input = Console.ReadLine();
          switch(input){
            case "Y":

                            Console.WriteLine("The size of ticket list is " + selectedTicketList.Count);
                showtimeList.reserveSeats(showtimeID, selectedSeats, selectedTicketList);
                printTickets(showtimeID, selectedTicketList);
                printReceipt(selectedTicketList);
                online = false;
            
              break;
            case "N":
              showtimeList.reserveSeats(showtimeID, selectedSeats, selectedTicketList);
              Console.WriteLine("Please pay at the counter when you collect your ticket.");
                            Console.WriteLine("Your ticket details:");
                            printTickets(showtimeID, selectedTicketList);
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
        public void printTickets(int showtimeID, List<Ticket> selectedTicketList)
        {
            string query = ("SELECT m.name FROM Showtime st INNER JOIN Movie m ON st.movieID = m.movieID " +
                            "WHERE st.showtimeID=" + showtimeID + ";");
            SQL sql = new SQL();
            sql.Connection.Open();
            MySqlCommand cmd = new MySqlCommand(query, sql.Connection);
            object temp = cmd.ExecuteScalar();
            string movieName = temp.ToString();

            foreach (Ticket ticket in selectedTicketList)
            {

                Console.WriteLine("==========================================");
                Console.WriteLine("---------------- e-Ticket ----------------");
                Console.WriteLine("==========================================");
                Console.WriteLine("\t" + "Movie Name: " + movieName);
                Console.WriteLine("\t" + "Ticket Code: " + ticket.TicketCode);
                Console.WriteLine("\t" + "Ticket Type: " + ticket.TicketType);
                Console.WriteLine("\t" + "Ticket Price: " + ticket.TicketPrice);
                Console.WriteLine("==========================================");

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
            int tixAdult = Int32.Parse(Console.ReadLine());
            for(int i=0; i < tixAdult; i++)
            {
                Ticket adultTicket = new Ticket("Adult", 1, calcTicketPrice("Adult"));
                ticketList.Add(adultTicket);
            }   
            break;
          case "2":
            Console.Write("Enter number of tickets (Children): ");
            int tixChild = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < tixChild; i++)
            {
                Ticket childTicket = new Ticket("Child", 1, calcTicketPrice("Child"));
                ticketList.Add(childTicket);
            }
                        
            break;
          case "3":
            Console.Write("Enter number of tickets (Student): ");
            int tixStudent = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < tixStudent; i++)
            {
                Ticket studentTicket = new Ticket("Student", 1, calcTicketPrice("Student"));
                ticketList.Add(studentTicket);
            }
            break;
          case "4":
            Console.Write("Enter number of tickets (Senior): ");
                        int tixSenior = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < tixSenior; i++)
                        {
                            Ticket seniorTicket = new Ticket("Senior", 1, calcTicketPrice("Senior"));
                            ticketList.Add(seniorTicket);
                        }
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

        public int TicketCode
        {
            get
            {
                return ticketCode;
            }

            set
            {
                ticketCode = value;
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
