using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace laba6
{
    public class MySqlRepository : Irepository
    {
        private readonly string connectionString = "server=localhost;user=root;database=lab-3;password=Fr1784075;";
        public bool AddPositions(Positions newPositions)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string query = "INSERT INTO positions (name, salary) VALUES (@name, @salary)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", newPositions.name);
                command.Parameters.AddWithValue("@salary", newPositions.salary);

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public bool AddClients(Clients newClients)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string query = "INSERT INTO clients (name, surname, middlename, `number phone`, `passport date`) VALUES(@name, @surname, @middlename, @numberphone, @passportdate)";

                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@name", newClients.name);
                command.Parameters.AddWithValue("@surname", newClients.surname);
                command.Parameters.AddWithValue("@middlename", newClients.middlename);
                command.Parameters.AddWithValue("@numberphone", newClients.phoneNumber);
                command.Parameters.AddWithValue("@passportdate", newClients.passportDate);

                command.ExecuteNonQuery();

                connection.Close();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeletePositions(Positions newPositions)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string delete = "DELETE FROM positions WHERE id = @id";

                MySqlCommand command = new MySqlCommand(delete, connection);

                command.Parameters.AddWithValue("@id", newPositions.id);

                command.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteClients(Clients newClients)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string delete = "DELETE FROM clients WHERE id = @id";

                MySqlCommand command = new MySqlCommand(delete, connection);

                command.Parameters.AddWithValue("@id", newClients.id);

                command.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

            public IEnumerable<Positions> GetPositions()
        {
            var resultPositions = new List<Positions>();

            MySqlConnection connect = new MySqlConnection(connectionString);

            connect.Open();

            string sqlcar = "SELECT * FROM positions";

            MySqlCommand commander = new MySqlCommand(sqlcar, connect);

            MySqlDataReader readerCar = commander.ExecuteReader();

            while (readerCar.Read())
            {
                resultPositions.Add(new Positions(readerCar.GetInt32(0), readerCar.GetString(1), readerCar.GetInt32(2)));
            }
            readerCar.Close();
            connect.Close();
            return resultPositions;
        }


        public IEnumerable<Clients> GetClients()
        {
            var result = new List<Clients>();

            MySqlConnection conn = new MySqlConnection(connectionString);

            conn.Open();

            string sql = "SELECT * FROM clients";

            MySqlCommand command = new MySqlCommand(sql, conn);

            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Clients(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5)));
            }
            reader.Close();
            conn.Close();
            return result;
            
        }

        public bool UpdatePositions(Positions newPositions)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string delete = "UPDATE positions SET name = @name, salary = @salary WHERE id = @id";

                MySqlCommand command = new MySqlCommand(delete, connection);

                command.Parameters.AddWithValue("@id", newPositions.id);
                command.Parameters.AddWithValue("@name", newPositions.name);
                command.Parameters.AddWithValue("@salary", newPositions.salary);

                command.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateClients(Clients newClients)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);

                connection.Open();

                string delete = "UPDATE clients SET name = @name, surname = @surname, middlename = @middlename, `number phone` = @numberphone, `passport date` = @passportdate WHERE id = @id";

                MySqlCommand command = new MySqlCommand(delete, connection);

                command.Parameters.AddWithValue("@id", newClients.id);
                command.Parameters.AddWithValue("@name", newClients.name);
                command.Parameters.AddWithValue("@surname", newClients.surname);
                command.Parameters.AddWithValue("@middlename", newClients.middlename);
                command.Parameters.AddWithValue("@numberphone", newClients.phoneNumber);
                command.Parameters.AddWithValue("@passportdate", newClients.passportDate);

                command.ExecuteNonQuery();

                connection.Close();

                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public string PercentToName(Clients newClients)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string percent = "SELECT (SELECT COUNT(id) FROM clients WHERE name LIKE @name)/COUNT(id)*100 FROM clients";

            MySqlCommand command = new MySqlCommand(percent, connection);

            command.Parameters.AddWithValue("@name", newClients.name);

            object count = command.ExecuteScalar();

            connection.Close();

            return count.ToString();
        }

        public string AverageSalary(Positions newPositions)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            connection.Open();

            string avg = "SELECT AVG(salary) FROM positions where salary < @salary";

            MySqlCommand command = new MySqlCommand(avg, connection);

            command.Parameters.AddWithValue("@salary", newPositions.salary);

            object count = command.ExecuteScalar();

            connection.Close();

            return count.ToString();
        }
    }
}
