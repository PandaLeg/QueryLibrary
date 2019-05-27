using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassSpecialization
    {
        string message = "";

        // Добавление
        public void insertSpecialization(string query, string connectionString, Specialization specialization)
        {
            // название хранимой процедуры
            string sqlExpression = query;
            try {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Параметры для выполнения  
                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = specialization.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    MySqlParameter nameParam = new MySqlParameter
                    {
                        ParameterName = "@Name",
                        Value = specialization.name,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(nameParam);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception ex)
            {
                message = ex.Message;
            }
        }

        // Вывод
        public Specialization selectSpecialization(string query, string connectionString)
        {
            // Можно заменить обычным запросом
            string sqlExpresion = query;
            Specialization specialization;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                specialization = new Specialization();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        specialization.idSpecialization = Convert.ToInt32(reader["IdSpecialization"]);
                        specialization.name = reader["Name"].ToString();
                    }
                    reader.Close();
                    myConnection.Close();
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                }
                return specialization;
            }
        }

        // Изменение
        public void updateSpecialization(string query, string connectionString, Specialization specialization)
        {
            // название хранимой процедуры
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Параметры для выполнения  
                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = specialization.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    MySqlParameter nameParam = new MySqlParameter
                    {
                        ParameterName = "@Name",
                        Value = specialization.name,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(nameParam);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        // Удаление
        public void deleteSpecialization(string query, string connectionString, Specialization specialization)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdSpecialization", specialization.idSpecialization);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

    }
}
