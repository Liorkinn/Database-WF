using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data.Common;

namespace ZarplataLab
{
    class database
    {
        MySqlConnection Connection;
        MySqlConnectionStringBuilder Connect = new MySqlConnectionStringBuilder();

        public database(string server, string user, string pass, string database)
        {
            Connect.Server = server;
            Connect.UserID = user;
            Connect.Password = pass;
            Connect.Port = 3306;
            Connect.Database = database;
            Connect.CharacterSet = "utf8";
            Connection = new MySqlConnection(Connect.ConnectionString);
        }
        public long download(string name, string surname, string otch)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO info(name, surname, otch) VALUES(?name, ?surname, ?otch)";
            command.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("?surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("?otch", MySqlDbType.VarChar).Value = otch;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public long download2(string status, string money, int fio_id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "INSERT INTO `zarplatalab`.`zarplata`(status, money, fio_id) VALUES(?status, ?money, ?fio_id)";
            
            command.Parameters.Add("?status", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("?money", MySqlDbType.VarChar).Value = money;
            command.Parameters.Add("?fio_id", MySqlDbType.Int32).Value = fio_id;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }


        public long delete(int id)
        {
            MySqlCommand command = Connection.CreateCommand();
            command.CommandText = "DELETE FROM info where id = ?id";
            command.Parameters.Add("?id", MySqlDbType.Int32).Value = id;
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
                return command.LastInsertedId;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return -1;
        }

        public List<string> see(string name, string surname, string otch)
        {
            MySqlCommand command = Connection.CreateCommand();
            List<string> aqua = new List<string>();
            command.CommandText = "SELECT ?name, ?surname, ?otch FROM zarplatalab.info";
            command.Parameters.Add("?name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("?surname", MySqlDbType.VarChar).Value = surname;
            command.Parameters.Add("?otch", MySqlDbType.VarChar).Value = otch;
            try
            {
                Connection.Open();
                DbDataReader reader = command.ExecuteReader(); 

                while (reader.Read())
                {
                    aqua.Add(reader.GetString(0));
                    aqua.Add(reader.GetString(1));
                    aqua.Add(reader.GetString(2));
                    
                }
                return aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return aqua;
        }

        public List<string> see2(string status, string money, int fio_id)
        {
            MySqlCommand command = Connection.CreateCommand();
            List<string> aqua = new List<string>();
            command.CommandText = "SELECT ?status, ?money, ?fio_id FROM zarplatalab.zarplata";
            command.Parameters.Add("?status", MySqlDbType.VarChar).Value = status;
            command.Parameters.Add("?money", MySqlDbType.VarChar).Value = money;
            command.Parameters.Add("?fio_id", MySqlDbType.Int32).Value = fio_id;
            try
            {
                Connection.Open();
                DbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    aqua.Add(reader.GetString(0));
                    aqua.Add(reader.GetString(1));
                    aqua.Add(reader.GetString(2));

                }
                return aqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
            return aqua;
        }

    }
}
