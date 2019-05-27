using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassEmployeeSpecialty
    {
        string message = "";


        // Добавление
        public void insertEmployeeSpecialty(string query, string connectionString, EmployeeSpecialty employeeSpecialty)
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
                    MySqlParameter idAccountParam = new MySqlParameter
                    {
                        ParameterName = "@IdAccount",
                        Value = employeeSpecialty.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = employeeSpecialty.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    // Выполняем sql - запрос
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
        public EmployeeSpecialty selectEmployeeSpecialty(string query, string connectionString)
        {
            // Можно заменить обычным запросом
            string sqlExpresion = query;
            EmployeeSpecialty employeeSpecialty;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                employeeSpecialty = new EmployeeSpecialty();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        employeeSpecialty.idAccount = Convert.ToInt32(reader["IdAccount"]);
                        employeeSpecialty.idSpecialization = Convert.ToInt32(reader["IdSpecialization"]);
                    }

                    reader.Close();
                    myConnection.Close();

                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }                                          
                return employeeSpecialty;
            }
        }

        // Изменение
        public void updateEmployeeSpecialty(string query, string connectionString, EmployeeSpecialty employeeSpecialty)
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
                        Value = employeeSpecialty.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter idSpecializationParam = new MySqlParameter
                    {
                        ParameterName = "@IdSpecialization",
                        Value = employeeSpecialty.idSpecialization,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idSpecializationParam);

                    // Выполняем sql - запрос
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
        public void deleteEmployeeSpecialty(string query, string connectionString, EmployeeSpecialty employeeSpecialty)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdAccount", employeeSpecialty.idAccount);
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
