using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassReviews
    {
        string message = "";

        // Добавление
        public void addReviews(string query, string connectionString, Reviews reviews)
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
                    MySqlParameter idUserParam = new MySqlParameter
                    {
                        ParameterName = "@IdUser",
                        Value = reviews.idUser,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idUserParam);

                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = reviews.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    MySqlParameter descriptionParam = new MySqlParameter
                    {
                        ParameterName = "@Description",
                        Value = reviews.description,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(descriptionParam);

                    MySqlParameter assessmentParam = new MySqlParameter
                    {
                        ParameterName = "@Assessment",
                        Value = reviews.assessment,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(assessmentParam);

                    MySqlParameter typeJobParam = new MySqlParameter
                    {
                        ParameterName = "@TypeJob",
                        Value = reviews.typeJob,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(typeJobParam);
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
        public Reviews selectReviews(string query, string connectionString)
        {
            string sqlExpresion = query;
            Reviews reviews;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                reviews = new Reviews();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        reviews.idUser = Convert.ToInt32(reader["IdUser"]);
                        reviews.idSpecialization = Convert.ToInt32(reader["IdSpecialization"]);
                        reviews.description = reader["Description"].ToString();
                        reviews.assessment = Convert.ToInt32(reader["Assessment"]);
                        reviews.typeJob = reader["TypeJob"].ToString();
                    }
                    reader.Close();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                return reviews;
            }
        }

        // Изменение
        public void updateReviews(string query, string connectionString, Reviews reviews)
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
                    MySqlParameter idUserParam = new MySqlParameter
                    {
                        ParameterName = "@IdUser",
                        Value = reviews.idUser,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idUserParam);

                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = reviews.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    MySqlParameter descriptionParam = new MySqlParameter
                    {
                        ParameterName = "@Description",
                        Value = reviews.description,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(descriptionParam);

                    MySqlParameter assessmentParam = new MySqlParameter
                    {
                        ParameterName = "@Assessment",
                        Value = reviews.assessment,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(assessmentParam);

                    MySqlParameter typeJobParam = new MySqlParameter
                    {
                        ParameterName = "@TypeJob",
                        Value = reviews.typeJob,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(typeJobParam);
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
        public void deleteReviews(string query, string connectionString, Reviews reviews)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdUser;", reviews.idUser);
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
