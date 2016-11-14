using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
    class ticket : movie
    {
        ticket()
        {

        }

        private void printTicket()
        {
            // doesn't actually print a ticket
            System.Console.WriteLine("Printing Ticket...");
        }
        private void checkTicket()
        {
            //checks ticket code with DB
        }
    }

}
