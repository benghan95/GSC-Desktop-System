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

        private bool OpenConnection()
            {
                try
                {
                connection.Open();
                    //Console.WriteLine("YAYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
                    return true;
                }
                catch (MySqlException ex)
                {

                    switch (ex.Number)
                    {
                        case 0:
                            Console.WriteLine("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            Console.WriteLine("Invalid username/password, please try again");
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
                catch (MySqlException ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            public void Delete()
            {
                int d = 1;
                string query = ("DELETE FROM Staff WHERE LoginID = " + d);

                if (this.OpenConnection() == true)
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    this.CloseConnection();
                }
            }

            public void Insert()
            {
                string query = ("INSERT INTO Movie (Name,Rating,Duration,Summary,Venue,Cinema,date,time) VALUES('Beep','PG-13', 95, 'BEEP BEEP', 'Midvalley', 5, '2016-11-21', '22:00:00')");

                if (this.OpenConnection() == true)
                {

                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
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

