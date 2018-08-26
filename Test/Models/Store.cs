using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Test.Models
{
    public class Store
    {
        public string connectionString = "server=localhost;database=items_for_sale;uid=root;pwd=root;SslMode=none";// the address of the database's server and more info
        private string storedProcedureName = "Store_Manager";// the stored procedure name
        private string dbName = @"items_for_sale";// the @ means it will sent to the database

        public Boolean setItem(int id, string name, int cost, string desc)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 10),
                    new MySqlParameter("@itemId", id),
                    new MySqlParameter("@itemName", name),
                    new MySqlParameter("@cost", cost),
                    new MySqlParameter("@description", desc)
                };

                if (cnn.State == ConnectionState.Open)
                {
                    cnn.ChangeDatabase(dbName);// change to this database
                    MySqlCommand cmd = new MySqlCommand(storedProcedureName, cnn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dt);
                }
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();// close the connection
                }
            }
        }

        public Boolean updateItem(int flag, int id, string name, int cost, string desc)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", flag),
                    new MySqlParameter("@itemId", id),
                };

                if (flag == 20)
                {
                    parameters.Add(new MySqlParameter("@itemName", name));
                    parameters.Add(new MySqlParameter("@cost", 0));
                    parameters.Add(new MySqlParameter("@description", 0));
                }else if (flag == 21)
                {
                    parameters.Add(new MySqlParameter("@itemName", 0));
                    parameters.Add(new MySqlParameter("@cost", cost));
                    parameters.Add(new MySqlParameter("@description", 0));
                }
                else
                {
                    parameters.Add(new MySqlParameter("@itemName", 0));
                    parameters.Add(new MySqlParameter("@cost", 0));
                    parameters.Add(new MySqlParameter("@description", desc));
                }

                if (cnn.State == ConnectionState.Open)
                {
                    cnn.ChangeDatabase(dbName);// change to this database
                    MySqlCommand cmd = new MySqlCommand(storedProcedureName, cnn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dt);
                }
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();// close the connection
                }
            }
        }

        public Boolean deleteItem(int id)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 30),
                    new MySqlParameter("@itemId", id),
                    new MySqlParameter("@itemName", 0),
                    new MySqlParameter("@cost", 0),
                    new MySqlParameter("@description", 0)
                };

                if (cnn.State == ConnectionState.Open)
                {
                    cnn.ChangeDatabase(dbName);// change to this database
                    MySqlCommand cmd = new MySqlCommand(storedProcedureName, cnn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    if (parameters != null)
                    {
                        foreach (MySqlParameter param in parameters)
                        {
                            cmd.Parameters.Add(param);
                        }
                    }

                    MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                    adap.Fill(dt);
                }
                return true;
            }
            catch (Exception ex)
            {
                //return false;
                throw ex;
            }
            finally
            {
                if (cnn.State == ConnectionState.Open)
                {
                    cnn.Close();// close the connection
                }
            }
        }
    }
}