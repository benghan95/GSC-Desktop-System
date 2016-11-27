using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
  class Admin
  {
    public Admin()
    {
    }
    
    public void Initialize(){
      bool online = true;
      string option = null;

      while (online)
      {
        Console.WriteLine("=================================================");
        Console.WriteLine("---------------- GSC Admin Panel ----------------");
        Console.WriteLine("=================================================");
        Console.WriteLine("\t1. View Movie List");
        Console.WriteLine("\t2. Add Movie");
        Console.WriteLine("\t3. Edit Movie");
        Console.WriteLine("\t4. Remove Movie");
        Console.WriteLine("\t5. View Showtimes");
        Console.WriteLine("\t6. Add Showtime");
        Console.WriteLine("\t7. Remove Showtime");
        Console.WriteLine("\t8. View All Staff");
        Console.WriteLine("\t9. Add New Staff");
        Console.WriteLine("\t10. Exit");
        Console.WriteLine("=================================================");
        Console.Write("Please select one option (1 - 10): ");
        
        option = Console.ReadLine();

        switch (option)
        {
          case "1":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--- 1. View Movie List ---");
            Console.WriteLine("--------------------------");
            viewMovieList();
            break;

          case "2":
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ 2. Add Movie ------");
            Console.WriteLine("--------------------------");
            addMovie();
            break;

          case "3":
            Console.WriteLine("--------------------------");
            Console.WriteLine("------ 3. Edit Movie -----");
            Console.WriteLine("--------------------------");
            editMovie();
            break;

          case "4":
            Console.WriteLine("--------------------------");
            Console.WriteLine("---- 4. Remove Movie -----");
            Console.WriteLine("--------------------------");
            removeMovie();
            break;                   
          
          case "5":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--- 5. View Showtimes ----");
            Console.WriteLine("--------------------------");
            viewShowtimes();
            break; 
          
          case "6":
            Console.WriteLine("--------------------------");
            Console.WriteLine("---- 6. Add Showtime -----");
            Console.WriteLine("--------------------------");
            addShowtime();
            break; 
            
          case "7":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--- 7. Remove Showtime ---");
            Console.WriteLine("--------------------------");
            removeShowtime();
            break; 
          
          case "8":
            Console.WriteLine("--------------------------");
            Console.WriteLine("--- 8. View All Staff ----");
            Console.WriteLine("--------------------------");
            viewStaffList();
            break; 
          
          case "9":
            Console.WriteLine("--------------------------");
            Console.WriteLine("---- 9. Add New Staff ----");
            Console.WriteLine("--------------------------");
            addNewStaff();
            break; 
            
          case "10":
            Console.WriteLine("--------------------------");
            Console.WriteLine("---- 10. Exit System -----");
            Console.WriteLine("--------------------------");
            online = false;
            break;
            
          default:
              Console.WriteLine("Invalid Input. Enter numbers 1-10 only. Press any key to return to menu");
              Console.ReadKey();
              Console.Clear();
              break;
        }
      }
    }
    
    private void viewMovieList(){
      Movie movieList = new Movie();
      movieList.displayAllMovies();
    }
    
    private void addMovie(){
      Movie newMovie = new Movie();
      newMovie.addMovie();
    }
    
    private void editMovie(){
      Movie movie = new Movie();
      movie.displayAllMovies();
      movie.editMovie();
    }
    
    private void removeMovie(){
      Movie movie = new Movie();
      movie.displayAllMovies();
      movie.removeMovie();
    }
    
    private void viewShowtimes(){
      Showtime showtimeList = new Showtime();
      showtimeList.displayShowtimes();
    }
    
    private void addShowtime(){
      Showtime newShowtime = new Showtime();
      newShowtime.addShowtime();
    }
    
    private void removeShowtime(){
      Showtime showtime = new Showtime();
      showtime.displayShowtimes();
      showtime.removeShowtime();
    }
    
    private void viewStaffList(){
      Staff staffList = new Staff();
      staffList.displayAllStaffs();
    }
    
    private void addNewStaff(){
      Staff staff = new Staff();
      staff.addNewStaff();
    }
  }
}
