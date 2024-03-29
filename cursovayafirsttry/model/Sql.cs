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
using cursovayafirsttry.Tools;

namespace cursovayafirsttry.model
{
    public class SqlModel
    {
        private SqlModel() { }
        static SqlModel sqlModel;
        public static SqlModel GetInstance()
        {
            if (sqlModel == null)
                sqlModel = new SqlModel();
            return sqlModel;
        }

        internal int SelectCountEnrollesInDisciplines(Discipline Discipline)
        {
            int result = 0;
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT count(*) FROM student WHERE group_id = " + Discipline.ID;
            //if (mySqlDB.OpenConnection())
            //{
            //    using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
            //    using (MySqlDataReader dr = mc.ExecuteReader())
            //    {
            //        if (dr.Read())
            //        {
            //            result = dr.GetInt32(0);
            //        }
            //    }
            //    mySqlDB.CloseConnection();
            //}
            return result;
        }

        internal List<Enrolle> SelectEnrollesByDiscipline(Discipline selectedDiscipline)
        {
            int id = selectedDiscipline?.ID ?? 0;
            var Enrolles = new List<Enrolle>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `student` WHERE group_id = {id}";
            //if (mySqlDB.OpenConnection())
            //{
            //    using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
            //    using (MySqlDataReader dr = mc.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            Enrolles.Add(new Enrolle
            //            {
            //                ID = dr.GetInt32("id"),
            //                FirstName = dr.GetString("firstName"),
            //                surname = dr.GetString("lastName"),
            //                patronymic = dr.GetString("patronymicName"),
            //                DisciplineId = dr.GetInt32("group_id"),
            //                Birthday = dr.GetDateTime("birthday")
            //            });
            //        }
            //    }
            //    mySqlDB.CloseConnection();
            //}
            return Enrolles;
        }

        internal List<Discipline> SelectDisciplines()
        {
            var mySqlDB = MySqlDB.GetDB();
            var result = new List<Discipline>();
            string sql = "select id, title, prepod_id from discipline";
            //if (mySqlDB.OpenConnection())
            //{
            //    using (MySqlCommand mc = new MySqlCommand(sql, mySqlDB.sqlConnection))
            //    using (MySqlDataReader dr = mc.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            result.Add(new Discipline
            //            {
            //                ID = dr.GetInt32("id"),
            //                Title = dr.GetString("title"),                          
            //            });
            //        }
            //    }
            //    mySqlDB.CloseConnection();
            //}
            return result;
        }

        //INSERT INTO `group` set title='1125', year = 2018;
        // возвращает ID добавленной записи
        //public int Insert<T>(T value)
        //{
        //    string table;
        //    List<(string, object)> values;
        //    GetMetaData(value, out table, out values);
        //    var query = CreateInsertQuery(table, values);
        //    var db = MySqlDB.GetDB();
        //    // лучше эти 2 запроса объединить в один с помощью транзакции
        //    int id = db.GetNextID(table);
        //    db.ExecuteNonQuery(query.Item1, query.Item2);
        //    return id;
        //}
        //// обновляет объект в бд по его id
        //public void Update<T>(T value) where T : BaseDTO
        //{
        //    string table;
        //    List<(string, object)> values;
        //    GetMetaData(value, out table, out values);
        //    var query = CreateUpdateQuery(table, values, value.ID);
        //    var db = MySqlDB.GetDB();
        //    db.ExecuteNonQuery(query.Item1, query.Item2);
        //}

        //public void Delete<T>(T value) where T : BaseDTO
        //{
        //    var type = value.GetType();
        //    string table = GetTableName(type);
        //    var db = MySqlDB.GetDB();
        //    string query = $"delete from `{table}` where id = {value.ID}";
        //    db.ExecuteNonQuery(query);
        //}

        //public int GetNumRows(Type type)
        //{
        //    string table = GetTableName(type);
        //    return MySqlDB.GetDB().GetRowsCount(table);
        //}

        private static string GetTableName(Type type)
        {
            var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
            return ((TableAttribute)tableAtrributes.First()).Table;
        }

        public List<Discipline> SelectDisciplinesRange(int skip, int count)
        {
            var Disciplines = new List<Discipline>();
            var mySqlDB = MySqlDB.GetDB();
            string query = $"SELECT * FROM `group` LIMIT {skip},{count}";
            //if (mySqlDB.OpenConnection())
            //{
            //    using (MySqlCommand mc = new MySqlCommand(query, mySqlDB.sqlConnection))
            //    using (MySqlDataReader dr = mc.ExecuteReader())
            //    {
            //        while (dr.Read())
            //        {
            //            Disciplines.Add(new Discipline
            //            {
            //                ID = dr.GetInt32("id"),
            //                Title = dr.GetString("title"),                          
            //            });
            //        }
            //    }
            //    mySqlDB.CloseConnection();
            //}
            return Disciplines;
        }

        //private static (string, MySqlParameter[]) CreateInsertQuery(string table, List<(string, object)> values)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append($"INSERT INTO `{table}` set ");
        //    List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
        //    return (stringBuilder.ToString(), parameters.ToArray());
        //}

        //private static (string, MySqlParameter[]) CreateUpdateQuery(string table, List<(string, object)> values, int id)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.Append($"UPDATE `{table}` set ");
        //    List<MySqlParameter> parameters = InitParameters(values, stringBuilder);
        //    stringBuilder.Append($" WHERE id = {id}");
        //    return (stringBuilder.ToString(), parameters.ToArray());
        //}

        //private static List<MySqlParameter> InitParameters(List<(string, object)> values, StringBuilder stringBuilder)
        //{
        //    var parameters = new List<MySqlParameter>();
        //    int count = 1;
        //    var rows = values.Select(s =>
        //    {
        //        parameters.Add(new MySqlParameter($"p{count}", s.Item2));
        //        return $"{s.Item1} = @p{count++}";
        //    });
        //    stringBuilder.Append(string.Join(',', rows));
        //    return parameters;
        //}

        //private static void GetMetaData<T>(T value, out string table, out List<(string, object)> values)
        //{
        //    var type = value.GetType();
        //    var tableAtrributes = type.GetCustomAttributes(typeof(TableAttribute), false);
        //    table = ((TableAttribute)tableAtrributes.First()).Table;
        //    values = new List<(string, object)>();
        //    var props = type.GetProperties();
        //    foreach (var prop in props)
        //    {
        //        var columnAttributes = prop.GetCustomAttributes(typeof(ColumnAttribute), false);
        //        if (columnAttributes.Length > 0)
        //        {
        //            string column = ((ColumnAttribute)columnAttributes.First()).Column;
        //            values.Add(new(column, prop.GetValue(value)));
        //        }
        //    }
        //}
    }
}
