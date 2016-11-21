using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class movie
    {
        //private string movieName {get; set;}
        //private string movieRating { get; set; }
        //private int movieDuration { get; set; }
        //private string summary { get; set; }
        //private string cinemaName { get; set; }
        //private string movieVenue { get; set; }
        //time?

        public movie()
        {
            //display as arraylist and print all movies 
            string query = "Select Name from Movie;";
            string query2 = "Select ID from Movie;";

            SQL sql = new SQL();

            List<string> movieName = new List<string>();
            List<string> movieID = new List<string>();
            movieName = sql.Select(query);
            movieID = sql.Select(query2);

        }

        public void displayDetails() //displays all details of movie
        {

        }

        public void addMovie()
        {

        }

        public void editMovie()
        {

        }

        public void deleteMovie()
        {

        }



    }
}
