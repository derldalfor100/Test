using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;


namespace Test.Models
{
    public class BasketConn
    {
        public string connectionString = "server=localhost;database=items_for_sale;uid=root;pwd=root;SslMode=none";// the address of the database's server and more info
        private string storedProcedureName = "User_Basket";// the stored procedure name
        private string dbName = @"items_for_sale";// the @ means it will sent to the database

        public DataTable getStore()// get the store's items
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 3),
                    new MySqlParameter("@itemId", 0),
                    new MySqlParameter("@userId", 0),
                    new MySqlParameter("@amount", 0)
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
                return dt;
            }
            catch (Exception ex)
            {
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

        public DataTable getItems(int id)// get the user basket's items
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 2),
                    new MySqlParameter("@itemId", 0),
                    new MySqlParameter("@userId", id),
                    new MySqlParameter("@amount", 0)
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
                return dt;
            }
            catch (Exception ex)
            {
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

        public Boolean setItem(int item, int user, int amount)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 10),
                    new MySqlParameter("@itemId", item),
                    new MySqlParameter("@userId", user),
                    new MySqlParameter("@amount", amount)
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

        public Boolean changeItemAmount(int item, int user, int amount)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 20),
                    new MySqlParameter("@itemId", item),
                    new MySqlParameter("@userId", user),
                    new MySqlParameter("@amount", amount)
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

        public Boolean deleteItem(int item, int user)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 30),
                    new MySqlParameter("@itemId", item),
                    new MySqlParameter("@userId", user),
                    new MySqlParameter("@amount", 0)
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

        public DataTable getExist(int item, int user)// get if in the basket we have the item
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 4),
                    new MySqlParameter("@itemId", item),
                    new MySqlParameter("@userId", user),
                    new MySqlParameter("@amount", 0)
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
                return dt;
            }
            catch (Exception ex)
            {
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