using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassFavorites
    {
        string message = "";

        // Добавление
        public void insertFavorites(string query, string connectionString, Favorites favorites)
        {

            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    // Параметры для выполнения  
                    MySqlParameter idAccountParam = new MySqlParameter
                    {
                        ParameterName = "@IdAccount",
                        Value = favorites.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = favorites.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);
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
        public Favorites selectFavorites(string query, string connectionString)
        {
            string sqlExpresion = query;
            Favorites favorites;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                favorites = new Favorites();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        favorites.idAccount = Convert.ToInt32(reader["IdVacancy"]);
                        favorites.idVacancy = Convert.ToInt32(reader["IdUserPlacement"]);
                    }

                    reader.Close();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                return favorites;
            }
        }

        // Изменение
        public void updateFavorites(string query, string connectionString, Favorites favorites)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    // Параметры для выполнения  
                    MySqlParameter idAccountParam = new MySqlParameter
                    {
                        ParameterName = "@IdAccount",
                        Value = favorites.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = favorites.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);
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
        public void deleteFavorites(string query, string connectionString, Favorites favorites)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdAccount", favorites.idAccount);
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
