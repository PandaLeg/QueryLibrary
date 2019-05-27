using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassTopVacancy
    {
        string message = "";

        // Добавление
        public void insertTopVacancy(string query, string connectionString, TopVacancy topVacancy)
        {
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Параметры для выполнения  
                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = topVacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter lastDateParam = new MySqlParameter
                    {
                        ParameterName = "@LastDate",
                        Value = topVacancy.lastDate,
                        MySqlDbType = MySqlDbType.DateTime
                    };

                    // Добавляем параметр
                    command.Parameters.Add(lastDateParam);
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
        }

        // Вывод
        public TopVacancy selectTopVacancy(string procedure, string connectionString)
        {
            // Можно заменить обычным запросом
            string sqlExpresion = procedure;
            TopVacancy topVacancy;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                topVacancy = new TopVacancy();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        topVacancy.idVacancy = Convert.ToInt32(reader["IdVacancy"]);
                        topVacancy.lastDate = Convert.ToDateTime(reader["LastDate"]);
                    }
                    reader.Close();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                return topVacancy;
            }
        }

        // Изменение
        public void updateTopVacancy(string query, string connectionString, TopVacancy topVacancy)
        {
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Параметры для выполнения  
                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = topVacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter lastDateParam = new MySqlParameter
                    {
                        ParameterName = "@LastDate",
                        Value = topVacancy.lastDate,
                        MySqlDbType = MySqlDbType.DateTime
                    };
                    // Добавляем параметр
                    command.Parameters.Add(lastDateParam);
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
        public void deleteTopVacancy(string query, string connectionString, TopVacancy topVacancy)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdVacancy", topVacancy.idVacancy);
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
