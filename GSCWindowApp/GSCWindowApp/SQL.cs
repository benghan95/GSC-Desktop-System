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
    private string username;
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
      database = "GSC";
      username = "root";
      password = "admin123";
      string connectionString;
      connectionString = "SERVER=" + server + "; " + "DATABASE=" + database + "; " + 
                         "UID=" + username + "; " + "PASSWORD=" + password + ";";
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
    public void UpdateById(string tableName, string primaryKey, int id, string attribute, string newValue){
      string query = "UPDATE " + tableName + " SET " + attribute + "='" + newValue + "' WHERE " + primaryKey + "=" + id;
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          if(cmd.ExecuteNonQuery() == 1){
            Console.WriteLine("Updated table row of the database!");
          } else{
            Console.WriteLine("Unable to update the database.");
          }
        } catch (Exception e){
          Console.WriteLine(e);
        }
        this.CloseConnection();
      }
    }
    public void Update(string query)
    {
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          if(cmd.ExecuteNonQuery() == 1){
            Console.WriteLine("Updated data from he database!");
          } else{
            Console.WriteLine("Unable to update the data in the database.");
          }
        } catch (Exception e){
          Console.WriteLine(e);
        }
        this.CloseConnection();
      }
    }
    public void Delete(string query)
    {
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          if(cmd.ExecuteNonQuery() == 1){
            Console.WriteLine("Deleted data from he database!");
          } else{
            Console.WriteLine("Unable to delete the data in the database.");
          }
        } catch (Exception e){
          Console.WriteLine(e);
        }
        this.CloseConnection();
      }
    }
    public int checkRowExists(string query){
      int rowExists = 0;
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          object temp = cmd.ExecuteScalar();
          this.CloseConnection();
          rowExists = Int32.Parse(temp.ToString());
          if(rowExists > 0){
            return rowExists;
          }
        } catch (Exception e){
          Console.WriteLine(e);
        }
      }
      return rowExists;
    }
    public string getStringColumn(string query){
      string value = null;
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          object temp = cmd.ExecuteScalar();
          this.CloseConnection();
          value = temp.ToString();
        } catch (Exception e){
          Console.WriteLine(e);
        }
      }
      return value;
    }
    public int getIntColumn(string query){
      int value = 0;
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          object temp = cmd.ExecuteScalar();
          this.CloseConnection();
          value = Int32.Parse(temp.ToString());
        } catch (Exception e){
          Console.WriteLine(e);
        }
      }
      return value;
    }
    public DateTime getDateTimeColumn(string query){
      DateTime value = new DateTime();
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          object temp = cmd.ExecuteScalar();
          this.CloseConnection();
          value = DateTime.Parse(temp.ToString());
        } catch (Exception e){
          Console.WriteLine(e);
        }
      }
      return value;
    }
    public bool getBooleanColumn(string query){
      bool value = false;
      if (this.OpenConnection() == true)
      {
        MySqlCommand cmd = new MySqlCommand(query, connection);
        try{
          object temp = cmd.ExecuteScalar();
          this.CloseConnection();
          value = Boolean.Parse(temp.ToString());
        } catch (Exception e){
          Console.WriteLine(e);
        }
      }
      return value;
    }
  }
}

