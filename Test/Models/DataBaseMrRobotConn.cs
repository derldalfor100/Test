using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace Test.Models
{
    public class DataBaseMrRobotConn
    {
        public string connectionString = "server=localhost;database=items_for_sale;uid=root;pwd=root;SslMode=none";// the address of the database's server and more info
        private string storedProcedureName = "User_Manager";// the stored procedure name
        private string dbName = @"items_for_sale";// the @ means it will sent to the database

        public DataTable getData()
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 1),
                    new MySqlParameter("@userName", 0),
                    new MySqlParameter("@userId", 0)
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

        public Boolean setData(String name, int id)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 10),
                    new MySqlParameter("@userName", name),
                    new MySqlParameter("@userId", id + 1)
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

        public DataTable getCount()// get the max id from the users
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 100),
                    new MySqlParameter("@userName", 0),
                    new MySqlParameter("@userId", 0)
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

        public DataTable getID(String name)// get the max id from the users
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 2),
                    new MySqlParameter("@userName", name),
                    new MySqlParameter("@userId", 0)
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

        public Boolean deleteData(int id)
        {
            MySqlConnection cnn = new MySqlConnection(connectionString);
            try
            {
                cnn.Open(); // open the connection
                DataTable dt = new DataTable();

                List<MySqlParameter> parameters = new List<MySqlParameter>()
                {
                    new MySqlParameter("@operation", 30),
                    new MySqlParameter("@userName", 0),
                    new MySqlParameter("@userId", id)
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