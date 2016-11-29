using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSCWindowApp
{
  class MainClass{
    public static void Main(String[] args){
      bool online = true;
      while(online){
        Console.WriteLine("==================================================");
        Console.WriteLine("----- Welcome to GSC Cinema Ticketing System -----");
        Console.WriteLine("==================================================");
        Staff staff = new Staff();
        staff.authentication();
        online = false;
      }
    }
  }
}
