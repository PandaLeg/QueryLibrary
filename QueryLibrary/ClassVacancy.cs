using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassVacancy
    {
        string message = "";

        // Добавление
        public void insertVacancy(string query, string connectionString, Vacancy vacancy)
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
                        Value = vacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter idUserPlacementParam = new MySqlParameter
                    {
                        ParameterName = "@IdUserPlacement",
                        Value = vacancy.idUserPlacement,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idUserPlacementParam);

                    MySqlParameter photoParam = new MySqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = vacancy.photo,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(photoParam);

                    MySqlParameter nameVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@NameVacancy",
                        Value = vacancy.nameVacancy,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(nameVacancyParam);

                    MySqlParameter idTypeJobParam = new MySqlParameter
                    {
                        ParameterName = "@IdTypeJob",
                        Value = vacancy.idTypeJob,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idTypeJobParam);

                    MySqlParameter paymentParam = new MySqlParameter
                    {
                        ParameterName = "@Payment",
                        Value = vacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Decimal
                    };
                    // Добавляем параметр
                    command.Parameters.Add(paymentParam);

                    MySqlParameter geoInfCityParam = new MySqlParameter
                    {
                        ParameterName = "@GeoInformationCity",
                        Value = vacancy.geoInfCity,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(geoInfCityParam);

                    MySqlParameter datePlacementParam = new MySqlParameter
                    {
                        ParameterName = "@DatePlacement",
                        Value = vacancy.datePlacement,
                        MySqlDbType = MySqlDbType.DateTime
                    };
                    // Добавляем параметр
                    command.Parameters.Add(datePlacementParam);

                    MySqlParameter descriptionParam = new MySqlParameter
                    {
                        ParameterName = "@Descriptions",
                        Value = vacancy.description,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(descriptionParam);

                    MySqlParameter vacancyStateParam = new MySqlParameter
                    {
                        ParameterName = "@VacancyState",
                        Value = (VacancyState)vacancy.vacancyState
                    };

                    MySqlParameter vacancyFormedParam = new MySqlParameter
                    {
                        ParameterName = "@VacancyFormed",
                        Value = (VacancyFormed)vacancy.vacanceFormed
                    };
                    // Добавляем параметр
                    command.Parameters.Add(vacancyFormedParam);
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
        public Vacancy selectVacancy(string query, string connectionString)
        {
            string sqlExpresion = query;
            Vacancy vacancy;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                vacancy = new Vacancy();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        vacancy.idVacancy = Convert.ToInt32(reader["IdVacancy"]);
                        vacancy.idUserPlacement = Convert.ToInt32(reader["IdUserPlacement"]);
                        vacancy.photo = reader["Photo"].ToString();
                        vacancy.nameVacancy = reader["NameVacancy"].ToString();
                        vacancy.idTypeJob = Convert.ToInt32(reader["IdTypeJob"]);
                        vacancy.payment = Convert.ToDecimal(reader["Payment"]);
                        vacancy.geoInfCity = reader["GeoInformationCity"].ToString();
                        vacancy.datePlacement = Convert.ToDateTime(reader["DatePlacement"]);
                        vacancy.description = reader["Descriptions"].ToString();
                        vacancy.vacancyState = (VacancyState)reader["VacancyState"];
                        vacancy.vacanceFormed = (VacancyFormed)reader["VacanceFormed"];
                    }
                    reader.Close();
                    myConnection.Close();
                }
                catch(Exception ex)
                {
                    message = ex.Message;
                }
                return vacancy;
            }
        }

        // Изменение
        public void updateVacancy(string query, string connectionString, Vacancy vacancy)
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
                        Value = vacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter idUserPlacementParam = new MySqlParameter
                    {
                        ParameterName = "@IdUserPlacement",
                        Value = vacancy.idUserPlacement,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idUserPlacementParam);

                    MySqlParameter photoParam = new MySqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = vacancy.photo,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(photoParam);

                    MySqlParameter nameVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@NameVacancy",
                        Value = vacancy.nameVacancy,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(nameVacancyParam);

                    MySqlParameter idTypeJobParam = new MySqlParameter
                    {
                        ParameterName = "@IdTypeJob",
                        Value = vacancy.idTypeJob,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idTypeJobParam);

                    MySqlParameter paymentParam = new MySqlParameter
                    {
                        ParameterName = "@Payment",
                        Value = vacancy.idVacancy,
                        MySqlDbType = MySqlDbType.Decimal
                    };
                    // Добавляем параметр
                    command.Parameters.Add(paymentParam);

                    MySqlParameter geoInfCityParam = new MySqlParameter
                    {
                        ParameterName = "@GeoInformationCity",
                        Value = vacancy.geoInfCity,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(geoInfCityParam);

                    MySqlParameter datePlacementParam = new MySqlParameter
                    {
                        ParameterName = "@DatePlacement",
                        Value = vacancy.datePlacement,
                        MySqlDbType = MySqlDbType.DateTime
                    };
                    // Добавляем параметр
                    command.Parameters.Add(datePlacementParam);

                    MySqlParameter descriptionParam = new MySqlParameter
                    {
                        ParameterName = "@Descriptions",
                        Value = vacancy.description,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(descriptionParam);

                    MySqlParameter vacancyStateParam = new MySqlParameter
                    {
                        ParameterName = "@VacancyState",
                        Value = (VacancyState)vacancy.vacancyState
                    };

                    MySqlParameter vacancyFormedParam = new MySqlParameter
                    {
                        ParameterName = "@VacancyFormed",
                        Value = (VacancyFormed)vacancy.vacanceFormed
                    };
                    // Добавляем параметр
                    command.Parameters.Add(vacancyFormedParam);
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
        public void deleteVacancy(string query, string connectionString, Vacancy vacancy)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdVacancy", vacancy.idVacancy);
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
