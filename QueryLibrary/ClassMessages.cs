using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassMessages
    {
        string message = "";

        // Добавление
        public void insertMessages(string query, string connectionString, Messages messages)
        {
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    // Параметры для выполнения  
                    MySqlParameter senderParam = new MySqlParameter
                    {
                        ParameterName = "@Sender",
                        Value = messages.sender,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(senderParam);

                    MySqlParameter recipientParam = new MySqlParameter
                    {
                        ParameterName = "@Recipient",
                        Value = messages.recipient,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(recipientParam);

                    MySqlParameter textParam = new MySqlParameter
                    {
                        ParameterName = "@Text",
                        Value = messages.text,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(textParam);

                    MySqlParameter dateTimeParam = new MySqlParameter
                    {
                        ParameterName = "@DateTime",
                        Value = messages.dateTime,
                        MySqlDbType = MySqlDbType.DateTime
                    };

                    // Добавляем параметр
                    command.Parameters.Add(dateTimeParam);
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
        public Messages selectMessages(string query, string connectionString)
        {
            string sqlExpresion = query;
            Messages messages;

            using (MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                messages = new Messages();
                try
                {
                    myConnection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {

                        messages.sender = Convert.ToInt32(reader["Sender"]);
                        messages.recipient = Convert.ToInt32(reader["Recipient"]);
                        messages.text = reader["Text"].ToString();
                        messages.dateTime = Convert.ToDateTime(reader["DateTime"]);
                    }
                    reader.Close();
                    myConnection.Close();
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }
                return messages;
            }
        }

        // Изменение
        public void updateMessages(string query, string connectionString, Messages messages)
        {
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    // Параметры для выполнения  
                    MySqlParameter senderParam = new MySqlParameter
                    {
                        ParameterName = "@Sender",
                        Value = messages.sender,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(senderParam);

                    MySqlParameter recipientParam = new MySqlParameter
                    {
                        ParameterName = "@Recipient",
                        Value = messages.recipient,
                        MySqlDbType = MySqlDbType.Int32
                    };

                    // Добавляем параметр
                    command.Parameters.Add(recipientParam);

                    MySqlParameter textParam = new MySqlParameter
                    {
                        ParameterName = "@Text",
                        Value = messages.text,
                        MySqlDbType = MySqlDbType.String
                    };

                    // Добавляем параметр
                    command.Parameters.Add(textParam);

                    MySqlParameter dateTimeParam = new MySqlParameter
                    {
                        ParameterName = "@DateTime",
                        Value = messages.dateTime,
                        MySqlDbType = MySqlDbType.DateTime
                    };

                    // Добавляем параметр
                    command.Parameters.Add(dateTimeParam);
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
        public void deleteMessages(string query, string connectionString, Messages messages)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    command.Parameters.AddWithValue("@Sender", messages.sender);
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
