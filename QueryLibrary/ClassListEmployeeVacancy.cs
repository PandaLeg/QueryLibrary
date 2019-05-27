using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassListEmployeeVacancy
    {
        string message = "";

        // Добавление
        public void insertEmployeeVacancy(string query, string connectionString, ListEmployeeVacancy listEmployee)
        {
            // название хранимой процедуры
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    // Параметры для выполнения  
                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = listEmployee.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter idEmployeeParam = new MySqlParameter
                    {
                        ParameterName = "@IdEmployee",
                        Value = listEmployee.idEmployee,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idEmployeeParam);
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
        public ListEmployeeVacancy selectEmployeeVacancy(string query, string connectionString)
        {
            string sqlExpresion = query;
            ListEmployeeVacancy listEmployee;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                listEmployee = new ListEmployeeVacancy();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        listEmployee.idVacancy = Convert.ToInt32(reader["IdVacancy"]);
                        listEmployee.idEmployee = Convert.ToInt32(reader["IdEmployee"]);
                    }

                    reader.Close();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                return listEmployee;
            }
        }

        // Изменение
        public void updateEmplyeeVacancy(string query, string connectionString, ListEmployeeVacancy listEmployee)
        {
            // название хранимой процедуры
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Указываем, что команда представляет хранимую процедуру
                    command.CommandType = System.Data.CommandType.StoredProcedure;


                    // Параметры для выполнения  
                    MySqlParameter idVacancyParam = new MySqlParameter
                    {
                        ParameterName = "@IdVacancy",
                        Value = listEmployee.idVacancy,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idVacancyParam);

                    MySqlParameter idEmployeeParam = new MySqlParameter
                    {
                        ParameterName = "@IdEmployee",
                        Value = listEmployee.idEmployee,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(idEmployeeParam);
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
        public void deleteEmployeeVacancy(string query, string connectionString, ListEmployeeVacancy listEmployee)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@IdVacancy", listEmployee.idVacancy);
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
