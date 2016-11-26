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
                Console.WriteLine("\t4. Cancel Movie");
                Console.WriteLine("\t5. Add Showtime");
                Console.WriteLine("\t6. Edit Showtime");
                Console.WriteLine("\t7. Remove Showtime");
                Console.WriteLine("\t8. Add New Staff");
                Console.WriteLine("\t9. Exit");
                Console.WriteLine("=================================================");
                Console.Write("\tPlease select one option (1 - 9): ");
                
                option = Console.ReadLine();

                switch (option)
                {
                  case "1":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("--- 1. View Movie List ---");
                    Console.WriteLine("--------------------------");
                    viewMovieList();
                    Console.WriteLine("==========================");
                    break;

                  case "2":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("------ 2. Add Movie ------");
                    Console.WriteLine("--------------------------");
                    addMovie();
                    Console.WriteLine("==========================");
                    break;

                  case "3":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("------ 3. Edit Movie -----");
                    Console.WriteLine("--------------------------");
                    editMovie();
                    Console.WriteLine("==========================");
                    break;

                  case "4":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("---- 4. Delete Movie -----");
                    Console.WriteLine("--------------------------");
                    cancelMovie();
                    Console.WriteLine("==========================");
                    break;                   
                  
                  case "5":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("---- 5. Add Showtime -----");
                    Console.WriteLine("--------------------------");
                    addShowtime();
                    Console.WriteLine("==========================");
                    break; 
                  
                  case "6":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("---- 6. Edit Showtime -----");
                    Console.WriteLine("--------------------------");
                    editShowtime();
                    Console.WriteLine("==========================");
                    break; 
                    
                  case "7":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("--- 7. Remove Showtime ---");
                    Console.WriteLine("--------------------------");
                    removeShowtime();
                    Console.WriteLine("==========================");
                    break; 
                  
                  case "8":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("---- 8. Add New Staff ----");
                    Console.WriteLine("--------------------------");
                    addNewStaff();
                    Console.WriteLine("==========================");
                    break; 
                  
                  case "9":
                    Console.WriteLine("--------------------------");
                    Console.WriteLine("----- 9. Exit System -----");
                    Console.WriteLine("--------------------------");
                    online = false;
                    Console.WriteLine("==========================");
                    break;
                    
                  default:
                      Console.WriteLine("Invalid Input. Enter numbers 1-9 only. Press any key to return to menu");
                      Console.ReadKey();
                      Console.Clear();
                      break;
                }
            }
        }
        
        private void viewMovieList(){
          Movie newMovie = new Movie();
          newMovie.addMovie();
        }
        
        private void addMovie(){
          Movie newMovie = new Movie();
          newMovie.addMovie();
        }
        
        private void editMovie(){
          Movie movie = new Movie();
          movie.editMovie();
        }
    }
}
