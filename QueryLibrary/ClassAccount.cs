using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    public class ClassAccount
    {
        string message = "";

        /* 
        */

        // Добавление
        public void insertAccount(string query, string connectionString, Account account)
        {
            // // Переменная хранящая запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {

                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);

                    // Указываем, что команда представляет хранимую процедуру
                    //command.CommandType = System.Data.CommandType.StoredProcedure;

                    // Параметры для выполнения
                    MySqlParameter idAccountParam = new MySqlParameter
                    {
                        ParameterName = "@IdAccount",
                        Value = account.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter nickParam = new MySqlParameter
                    {
                        ParameterName = "@Nick",
                        Value = account.nickName,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(nickParam);

                    MySqlParameter photoParam = new MySqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = account.photo,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(photoParam);

                    MySqlParameter logParam = new MySqlParameter
                    {
                        ParameterName = "@Login",
                        Value = account.login,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(logParam);

                    MySqlParameter pasParam = new MySqlParameter
                    {
                        ParameterName = "@Password",
                        Value = account.password,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(pasParam);

                    MySqlParameter phoneParam = new MySqlParameter
                    {
                        ParameterName = "@Phone",
                        Value = account.phoneNumber,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(phoneParam);

                    MySqlParameter mailParam = new MySqlParameter
                    {
                        ParameterName = "@Mail",
                        Value = account.email,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(mailParam);

                    MySqlParameter dobParam = new MySqlParameter
                    {
                        ParameterName = "@DateOfBirthday",
                        Value = account.birthDay,
                        MySqlDbType = MySqlDbType.Date
                    };
                    // Добавляем параметр
                    command.Parameters.Add(dobParam);

                    MySqlParameter amountOfMoneyParam = new MySqlParameter
                    {
                        ParameterName = "@AmountOfMoney",
                        Value = account.amountOfMoney,
                        MySqlDbType = MySqlDbType.Int64
                    };
                    // Добавляем параметр
                    command.Parameters.Add(amountOfMoneyParam);

                    MySqlParameter geoInfParam = new MySqlParameter
                    {
                        ParameterName = "@GeoInformation",
                        Value = account.geoInf,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(geoInfParam);

                    MySqlParameter typeAccParam = new MySqlParameter
                    {
                        ParameterName = "@TypeAccount",
                        Value = (AccType)account.accountType
                    };
                    // Добавляем параметр
                    command.Parameters.Add(typeAccParam);

                    MySqlParameter statusParam = new MySqlParameter
                    {
                        ParameterName = "@Status",
                        Value = (AccountState)account.accountState,
                    };
                    // Добавляем параметр
                    command.Parameters.Add(statusParam);
                    // Выполняем sql - запрос
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
        public Account selectAccount(string query, string connectionString)
        {
            // Переменная хранящая запрос
            string sqlExpresion = query;
            Account account;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                account = new Account();
                try { 
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpresion, connection);       
                    //создание и чтение строк
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                        account.idAccount = Convert.ToInt32(reader["IdAccount"]);
                        account.nickName = reader["Nick"].ToString();
                        account.photo = reader["Photo"].ToString();
                        account.login = reader["Login"].ToString();
                        account.password = reader["Password"].ToString();
                        account.phoneNumber = reader["Phone"].ToString();
                        account.email = reader["Mail"].ToString();
                        account.birthDay = Convert.ToDateTime(reader["Dob"]);
                        account.amountOfMoney = Convert.ToDecimal(reader["CountMoney"]);
                        account.geoInf = reader["GeoInformation"].ToString();
                        account.accountType = (AccType)reader["TypeAccount"];
                        account.accountState = (AccountState)reader["Status"];

                        reader.Close();
                        connection.Close();

                    }
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                }              
                return account;
            }
        }

        // Изменение
        public void updateAccount(string query, string connectionString, Account account)
        {
            // Переменная хранящая запрос
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
                        Value = account.idAccount,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(idAccountParam);

                    MySqlParameter nickParam = new MySqlParameter
                    {
                        ParameterName = "@Nick",
                        Value = account.nickName,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(nickParam);

                    MySqlParameter photoParam = new MySqlParameter
                    {
                        ParameterName = "@Photo",
                        Value = account.photo,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(photoParam);

                    MySqlParameter logParam = new MySqlParameter
                    {
                        ParameterName = "@Login",
                        Value = account.login,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(logParam);

                    MySqlParameter pasParam = new MySqlParameter
                    {
                        ParameterName = "@Password",
                        Value = account.password,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(pasParam);

                    MySqlParameter phoneParam = new MySqlParameter
                    {
                        ParameterName = "@Phone",
                        Value = account.phoneNumber,
                        MySqlDbType = MySqlDbType.Int32
                    };
                    // Добавляем параметр
                    command.Parameters.Add(phoneParam);

                    MySqlParameter mailParam = new MySqlParameter
                    {
                        ParameterName = "@Mail",
                        Value = account.email,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(mailParam);

                    MySqlParameter dobParam = new MySqlParameter
                    {
                        ParameterName = "@DateOfBirthday",
                        Value = account.birthDay,
                        MySqlDbType = MySqlDbType.Date
                    };
                    // Добавляем параметр
                    command.Parameters.Add(dobParam);

                    MySqlParameter amountOfMoneyParam = new MySqlParameter
                    {
                        ParameterName = "@AmountOfMoney",
                        Value = account.amountOfMoney,
                        MySqlDbType = MySqlDbType.Int64
                    };
                    // Добавляем параметр
                    command.Parameters.Add(amountOfMoneyParam);

                    MySqlParameter geoInfParam = new MySqlParameter
                    {
                        ParameterName = "@GeoInformation",
                        Value = account.geoInf,
                        MySqlDbType = MySqlDbType.String
                    };
                    // Добавляем параметр
                    command.Parameters.Add(geoInfParam);

                    MySqlParameter typeAccParam = new MySqlParameter
                    {
                        ParameterName = "@TypeAccount",
                        Value = (AccType)account.accountType
                    };
                    // Добавляем параметр
                    command.Parameters.Add(typeAccParam);

                    MySqlParameter statusParam = new MySqlParameter
                    {
                        ParameterName = "@Status",
                        Value = (AccountState)account.accountState,
                    };
                    // Добавляем параметр
                    command.Parameters.Add(statusParam);
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
        public void deleteAccount(string query, string connectionString, Account account)
        {
            // запрос
            string sqlExpression = query;
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                    // Добавить параметр @IdAcc, значение которого определяется переменной idAccount
                    command.Parameters.AddWithValue("@IdAccount", account.idAccount);
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
