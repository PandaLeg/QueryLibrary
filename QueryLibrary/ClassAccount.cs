using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace QueryLibrary
{
    class ClassAccount
    {
        Connection cn = new Connection();

        /* Хранимые процедуры являются еще одной формой выполнения запросов к базе данных.
         * По сравнению с обычными запросами которые посылаются из приложения базе данных, хранимые процедуры определяются на сервере
        */

        // Добавление
        public void AddAccount(string procedure, string connectionString, int id, string nick, string photo, string login, string password, int phone, string mail,
            DataSetDateTime dob, long countMoney, string geoInf, string typeAcc, string status)
        {
            // название хранимой процедуры
            string sqlExpression = procedure;

            using(MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpression, connection);
                // Указываем, что команда представляет хранимую процедуру
                command.CommandType = System.Data.CommandType.StoredProcedure;

                // Параметры для выполнения
                MySqlParameter idParam = new MySqlParameter
                {
                    ParameterName = "@Id",
                    Value = id,
                    MySqlDbType = MySqlDbType.Int32
            };
                // Добавляем параметр
                command.Parameters.Add(idParam);

                MySqlParameter nickParam = new MySqlParameter
                {
                    ParameterName = "@Nick",
                    Value = nick,
                    MySqlDbType = MySqlDbType.String
            };
                // Добавляем параметр
                command.Parameters.Add(nickParam);

                MySqlParameter photoParam = new MySqlParameter
                {
                    ParameterName = "@Photo",
                    Value = photo,
                    MySqlDbType = MySqlDbType.String
            };
                // Добавляем параметр
                command.Parameters.Add(photoParam);

                MySqlParameter logParam = new MySqlParameter
                {
                    ParameterName = "@Login",
                    Value = login,
                    MySqlDbType = MySqlDbType.String
            };
                // Добавляем параметр
                command.Parameters.Add(logParam);

                MySqlParameter pasParam = new MySqlParameter
                {
                    ParameterName = "@Password",
                    Value = password,
                    MySqlDbType = MySqlDbType.String
            };
                // Добавляем параметр
                command.Parameters.Add(pasParam);

                MySqlParameter phoneParam = new MySqlParameter
                {
                    ParameterName = "@Phone",
                    Value = phone,
                    MySqlDbType = MySqlDbType.Int32
                };
                // Добавляем параметр
                command.Parameters.Add(phoneParam);

                MySqlParameter mailParam = new MySqlParameter
                {
                    ParameterName = "@Mail",
                    Value = mail,
                    MySqlDbType = MySqlDbType.String
                };
                // Добавляем параметр
                command.Parameters.Add(mailParam);

                MySqlParameter dobParam = new MySqlParameter
                {
                    ParameterName = "@DateOfBirthday",
                    Value = dob,
                    MySqlDbType = MySqlDbType.Date
            };
                // Добавляем параметр
                command.Parameters.Add(dobParam);

                MySqlParameter countMoneyParam = new MySqlParameter
                {
                    ParameterName = "@CountMoney",
                    Value = countMoney,
                    MySqlDbType = MySqlDbType.Int64
            };
                // Добавляем параметр
                command.Parameters.Add(countMoneyParam);

                MySqlParameter geoInfParam = new MySqlParameter
                {
                    ParameterName = "@GeoInformation",
                    Value = geoInf,
                    MySqlDbType = MySqlDbType.String
                };
                // Добавляем параметр
                command.Parameters.Add(geoInfParam);

                MySqlParameter typeAccParam = new MySqlParameter
                {
                    ParameterName = "@TypeAccount",
                    Value = typeAcc,
                    MySqlDbType = MySqlDbType.String
                };
                // Добавляем параметр
                command.Parameters.Add(typeAccParam);

                MySqlParameter statusParam = new MySqlParameter
                {
                    ParameterName = "@Status",
                    Value = status,
                    MySqlDbType = MySqlDbType.String
                };
                // Добавляем параметр
                command.Parameters.Add(statusParam);
                
                command.ExecuteNonQuery();

            }
        }

        public void getAccount(string procedure, string connectionString )
        {
            // Можно заменить обычным запросом
            string sqlExpresion = procedure;

            using(MySqlConnection myConnection = new MySqlConnection(connectionString))
            {
                myConnection.Open();
                MySqlCommand command = new MySqlCommand(sqlExpresion, myConnection);
                // Указываем, что команда представляет хранимую процедур
                command.CommandType = System.Data.CommandType.StoredProcedure;
                //создание и чтение строк
                List<string[]> dataC = new List<string[]>();
                MySqlDataReader reader = command.ExecuteReader();

                // ???
                int T = 5000;
                while (reader.Read())
                {
                    dataC.Add(new string[T]);

                    dataC[dataC.Count - 1][0] = reader["Id"].ToString();
                    dataC[dataC.Count - 1][1] = reader["Nick"].ToString();
                    dataC[dataC.Count - 1][2] = reader["Foto"].ToString();
                    dataC[dataC.Count - 1][3] = reader["Login"].ToString();
                    dataC[dataC.Count - 1][4] = reader["Password"].ToString();
                    dataC[dataC.Count - 1][5] = reader["Phone"].ToString();
                    dataC[dataC.Count - 1][6] = reader["Mail"].ToString();
                    dataC[dataC.Count - 1][7] = reader["Dob"].ToString();
                    dataC[dataC.Count - 1][8] = reader["CountMoney"].ToString();
                    dataC[dataC.Count - 1][9] = reader["GeoInformation"].ToString();
                    dataC[dataC.Count - 1][10] = reader["TypeAccount"].ToString();
                    dataC[dataC.Count - 1][11] = reader["Status"].ToString();
                }
                reader.Close();
                myConnection.Close();


            }
        }

        // В метод передаётся 
        /*public void Account(string query, int id, string nick, string foto, string login, string password, int phone, string mail,
            DataSetDateTime dob, long countMoney, string geoInf, string typeAcc, string status)
        {
            string sql = string.Format(query);

            // Параметризированная команда
            using (MySqlCommand cmd = new MySqlCommand(sql, this.cn.connect))
            {
                MySqlParameter param = new MySqlParameter();
                param.ParameterName = "@Id";
                param.Value = id;
                param.MySqlDbType = MySqlDbType.Int32;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Nick";
                param.Value = nick;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Foto";
                param.Value = foto;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Login";
                param.Value = login;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Password";
                param.Value = password;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Phone";
                param.Value = phone;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Mail";
                param.Value = mail;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Dob";
                param.Value = dob;
                param.MySqlDbType = MySqlDbType.Date;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@CountMoney";
                param.Value = countMoney;
                param.MySqlDbType = MySqlDbType.Int64;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@GeoInformation";
                param.Value = geoInf;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@TypeAccount";
                param.Value = typeAcc;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                param = new MySqlParameter();
                param.ParameterName = "@Status";
                param.Value = status;
                param.MySqlDbType = MySqlDbType.String;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();

                // ??????
                cn.OpenConnection("");
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string[]> dataC = new List<string[]>();
                    int T = 5000;

                    if (reader.HasRows) { }

                    while (reader.Read())
                    {
                        dataC.Add(new string[T]);

                        dataC[dataC.Count - 1][0] = reader["Id"].ToString();
                        dataC[dataC.Count - 1][1] = reader["Nick"].ToString();
                        dataC[dataC.Count - 1][2] = reader["Foto"].ToString();
                        dataC[dataC.Count - 1][3] = reader["Login"].ToString();
                        dataC[dataC.Count - 1][4] = reader["Password"].ToString();
                        dataC[dataC.Count - 1][5] = reader["Phone"].ToString();
                        dataC[dataC.Count - 1][6] = reader["Mail"].ToString();
                        dataC[dataC.Count - 1][7] = reader["Dob"].ToString();
                        dataC[dataC.Count - 1][8] = reader["CountMoney"].ToString();
                        dataC[dataC.Count - 1][9] = reader["GeoInformation"].ToString();
                        dataC[dataC.Count - 1][10] = reader["TypeAccount"].ToString();
                        dataC[dataC.Count - 1][11] = reader["Status"].ToString();
                    }
                    reader.Close();
                }
                cn.CloseConnection();
                // ??????
            }
        }
        */
    }
}
