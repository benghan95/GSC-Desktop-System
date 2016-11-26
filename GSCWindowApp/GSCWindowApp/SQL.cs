using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GSCWindowApp
{
    class SQL
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public SQL()
        {
          Initialize();
        }

        //Initialize values
        private void Initialize()
        {
          server = "localhost";
          database = "gsc";
          uid = "root";
          password = "1234";
          string connectionString;
          connectionString = "SERVER=" + server + ";" + "DATABASE=" +
          database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
          connection = new MySqlConnection(connectionString);
        }
        
        public MySqlConnection Connection
        {
          get
          {
            return connection;
          }
    
          set
          {
            connection = value;
          }
        }
        
        private bool OpenConnection()
        {
          try
          {   
              connection.Open();
              Console.WriteLine("Connected to the database");
              return true;
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
            return false;
          }
        }
        private bool CloseConnection()
        {
          try
          {
            connection.Close();
            return true;
          }
          catch (MySqlException e)
          {
            Console.WriteLine(e.Message);
            return false;
          }
        }
        public void Select(string query, int counter)
        {
          if (this.OpenConnection() == true)
          {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            string[] array = new string[counter];
            try{
              MySqlDataReader reader = cmd.ExecuteReader();
              while(reader.Read()){
                for(int i = 0; i < counter; i ++){
                  array[i] = reader.GetString(i);
                }
              }
            } catch(Exception e){
              Console.WriteLine(e);
            }
            this.CloseConnection();
          }
        }
        public void Select(string query)
        {
            int d = 1;
            query = ("DELETE FROM Staff WHERE LoginID = " + d);

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        public void Insert(string query)
        {
          if (this.OpenConnection() == true)
          {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            try{
              if(cmd.ExecuteNonQuery() == 1){
                Console.WriteLine("Added into the database!");
              } else{
                Console.WriteLine("Unable to insert into database.");
              }
            } catch (Exception e){
              Console.WriteLine(e);
            }
            this.CloseConnection();
          }
        }

            

            public void Update()
            {
                string query = "UPDATE table info SET name='Joe', age='22' WHERE name='John Smith'";

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = connection;
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            public List<string> Select(string query)
            {
                //string query = ("SELECT Name FROM Movie");

                List<string> list = new List<string>();


                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // Console.WriteLine("" + dataReader.GetString(0));
                        list.Add(dataReader.GetString(0));
                    }

                    dataReader.Close();
                    this.CloseConnection();

                    return list;
                }

                else
                {
                    return list;
                }
            }

            public List<int> SelectInt(string query)
            {
                //string query = ("SELECT Name FROM Movie");

                List<int> list = new List<int>();


                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        // Console.WriteLine("" + dataReader.GetString(0));
                        list.Add(dataReader.GetInt32(0));
                    }

                    dataReader.Close();
                    this.CloseConnection();

                    return list;
                }

                else
                {
                    return list;
                }
            }
        }
    }

