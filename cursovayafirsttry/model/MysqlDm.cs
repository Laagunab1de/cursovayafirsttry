﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using cursovayafirsttry.DTO;
using cursovayafirsttry.Vm;
using cursovayafirsttry.Pages;
using MySql.Data.MySqlClient;

namespace cursovayafirsttry.model
{
    public class MySqlDB
    {
        private MySqlDB() { }
        static MySqlDB db;
        public static MySqlDB GetDB()
        {
            if (db == null)
                db = new MySqlDB();
            return db;
        }

        internal MySqlConnection sqlConnection = null;

        internal void InitConnection()
        {
               //InitConnection(Properties.Settings.Default.server, Properties.Settings.Default.user,
               //Properties.Settings.Default.db, Properties.Settings.Default.pass);
        }

        internal void InitConnection(string db)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.UserID = "Prepod";
            builder.Password = "1234";
            builder.Database = "kursovaya";
            builder.Server = "localhost";
            builder.CharacterSet = "utf8";
            builder.ConnectionTimeout = 5;

            sqlConnection = new MySqlConnection(builder.GetConnectionString(true));
        }

        //internal bool OpenConnection()
        //{
        //    try
        //    {
        //        if (sqlConnection == null)
        //            InitConnection();
        //        sqlConnection.Open();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        System.Windows.MessageBox.Show(e.Message);
        //    }
        //    return false;
        //}

        //internal void CloseConnection()
        //{
        //    try 
        //    {
        //        sqlConnection.Close(); // закрытие соединения
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //    }
        //}

        //internal void ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        //{
        //    if (OpenConnection())
        //    {
        //        using (MySqlCommand mc = new MySqlCommand(query, sqlConnection))
        //        {
        //            if (parameters != null)
        //                mc.Parameters.AddRange(parameters);
        //            mc.ExecuteNonQuery();
        //        }
        //        CloseConnection();
        //    }
        //}

        //internal int GetNextID(string table)
        //{
        //    string column = "Auto_increment";
        //    return GetTableInfo(table, column);
        //}
        
        //internal int GetRowsCount(string table)
        //{
        //    string column = "Rows";
        //    return GetTableInfo(table, column);
        //}

        //private int GetTableInfo(string table, string column)
        //{
        //    int result = 0;
        //    //SHOW TABLE STATUS WHERE `Name` = 'group'
        //    if (OpenConnection())
        //    {
        //        using (MySqlCommand mc = new MySqlCommand($"SHOW TABLE STATUS WHERE `Name` = '{table}'", sqlConnection))
        //        using (MySqlDataReader dr = mc.ExecuteReader())
        //        {
        //            dr.Read();
        //            result = dr.GetInt32(column);
        //        }
        //        CloseConnection();
        //    }
        //    return result;
        //}
    }
}
