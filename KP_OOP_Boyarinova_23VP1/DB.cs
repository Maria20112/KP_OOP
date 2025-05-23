﻿using iTextSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel; 
using System.Data; 
using System.Diagnostics; 
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using static System.Collections.Specialized.BitVector32;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.DirectoryServices.ActiveDirectory;
using System.Reflection.Metadata;

namespace KP_OOP_Boyarinova_23VP1
{
    /// <summary>
    /// статический класс, содержащий функции, которые обеспечивают взаимодействие программы с БД
    /// </summary>
    internal static class DB
    {
        /// <summary>
        /// строка подключения к master
        /// </summary>
        private static string generalConnectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;TrustServerCertificate=True;";
        /// <summary>
        /// строка подключения к БД
        /// </summary>
        private static string databaseConnectionString = "Server=localhost\\SQLEXPRESS;Database=conferencedb;Trusted_Connection=True;TrustServerCertificate=True;";

        /// <summary>
        /// функция, создает БД
        /// </summary>
        /// <returns></returns>
        public static async Task Create_DB()
        {
            if (!CheckDatabase())
            {
                using (SqlConnection connection = new SqlConnection(generalConnectionString))
                {
                    await connection.OpenAsync();   // открываем подключение
                    SqlCommand command = new SqlCommand();
                    command.CommandText = "USE master";
                    // определяем используемое подключение
                    command.Connection = connection;
                    // выполняем команду
                    await command.ExecuteNonQueryAsync();
                    // определяем выполняемую команду
                    command.CommandText = "CREATE DATABASE conferencedb";
                    // определяем используемое подключение
                    command.Connection = connection;
                    // выполняем команду
                    await command.ExecuteNonQueryAsync();
                    MessageBox.Show("База данных создана", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command1 = new SqlCommand();
                    command1.CommandText = "CREATE TABLE Users (Id INT PRIMARY KEY,Name VARCHAR(100) NOT NULL, PostOfParticipant VARCHAR(100), NameOfReport VARCHAR(100), Theme VARCHAR(100), Section VARCHAR(100), Speciality VARCHAR(100), TypeOfParticipate VARCHAR(100))";
                    command1.Connection = connection;
                    await command1.ExecuteNonQueryAsync();
                    MessageBox.Show("Таблица Users создана", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("База данных уже существует", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// функция, очищает таблицу БД
        /// </summary>
        /// <returns></returns>
        public static async Task Clear_table()
        {
            using (SqlConnection connection = new SqlConnection(databaseConnectionString))
            {
                await connection.OpenAsync();   // открываем подключение
                SqlCommand command = new SqlCommand();
                // определяем выполняемую команду
                command.CommandText = "TRUNCATE TABLE Users";
                // определяем используемое подключение
                command.Connection = connection;
                // выполняем команду
                await command.ExecuteNonQueryAsync();
            }
        }
        /// <summary>
        /// функция, удаляет БД
        /// </summary>
        /// <returns></returns>
        public static async Task Delete_DB()
        {
            try
            {
                if (CheckDatabase())
                {
                    using (SqlConnection connection = new SqlConnection(generalConnectionString))
                    {
                        await connection.OpenAsync();   // открываем подключение
                        SqlCommand command = new SqlCommand();
                        command.CommandText = "USE master";
                        // определяем используемое подключение
                        command.Connection = connection;
                        // выполняем команду
                        await command.ExecuteNonQueryAsync();
                        command.CommandText = "ALTER DATABASE conferencedb SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                        // определяем используемое подключение
                        command.Connection = connection;
                        // выполняем команду
                        await command.ExecuteNonQueryAsync();
                        // определяем выполняемую команду
                        command.CommandText = "DROP DATABASE conferencedb";
                        // определяем используемое подключение
                        command.Connection = connection;
                        // выполняем команду
                        await command.ExecuteNonQueryAsync();
                        MessageBox.Show("База данных удалена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// функция, проверяет наличие БД
        /// </summary>
        /// <returns></returns>
        public static bool CheckDatabase()
        {
            string cmdText = @"if Exists(select 1 from master.dbo.sysdatabases where name=@db) 
                       select 1 else select 0";
            using (SqlConnection sqlConnection = new SqlConnection(generalConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCmd = new SqlCommand(cmdText, sqlConnection))
                {
                    sqlCmd.Parameters.Add("@db", SqlDbType.NVarChar).Value = "conferencedb";
                    int nRet = Convert.ToInt32(sqlCmd.ExecuteScalar());
                    return (nRet > 0);
                }
            }
        }

        /// <summary>
        /// функция, добавляет новую строку в БД
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public static async Task Add_new_row(Participant p)
        {
            try
            {
                //if ()
                //string sqlExpression = $"INSERT INTO Users (Name) VALUES ('{p.Name}')";
                string sqlExpression = $"INSERT INTO Users (Id, Name, PostOfParticipant, NameOfReport, Theme, Section, Speciality, TypeOfParticipate) VALUES ('{p.Id}', '{p.Name}', '{p.Post}', '{p.Name_of_report}', '{p.Theme}', '{p.Section}', '{p.Speciality}', '{p.Type_of_participate}')";

                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    await connection.OpenAsync();

                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    int number = await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// функция, получает информацию из БД
        /// </summary>
        /// <returns></returns>
        public static async Task Get_all_from_DB()
        {
            if (CheckDatabase())
            {
                string sqlExpression = "SELECT * FROM Users";

                using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                {
                    await connection.OpenAsync();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.HasRows) // если есть данные
                        {
                            while (await reader.ReadAsync()) // построчно считываем данные
                            {
                                ProxyDB.getInstance().Add(new Participant(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3),
                                    reader.GetString(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
                            }
                        }
                    }
                }
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// функция, сохраняет БД в отдельный файл (pdf)
        /// </summary>
        /// <returns></returns>
        public static async Task Export()
        {
            if (CheckDatabase()) { 
                await ProxyDB.getInstance().synchronize_with_DB();

                try
                {
                    using (SqlConnection connection = new SqlConnection(databaseConnectionString))
                    {
                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        DataSet ds = new DataSet();
                        //int i = 0;
                        string sql = "SELECT * FROM Users";
                        int yPoint = 0;
                        string pubname = null;
                        string city = null;
                        string state = null;
                        connection.Open();
                        command = new SqlCommand(sql, connection);
                        adapter.SelectCommand = command;
                        adapter.Fill(ds);
                        connection.Close();

                        //Объект документа пдф
                        iTextSharp.text.Document doc = new iTextSharp.text.Document();

                        //Создаем объект записи пдф-документа в файл
                        PdfWriter.GetInstance(doc, new FileStream("pdfTables.pdf", FileMode.Create));

                        //Открываем документ
                        doc.Open();
                        BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                        iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, iTextSharp.text.Font.DEFAULTSIZE, iTextSharp.text.Font.NORMAL);

                        //Обход по всем таблицам датасета (хотя в данном случае мы можем опустить
                        //Так как в нашей бд только одна таблица)
                        for (int i = 0; i < ds.Tables.Count; i++)
                        {
                            //Создаем объект таблицы и передаем в нее число столбцов таблицы из нашего датасета
                            PdfPTable table = new PdfPTable(ds.Tables[i].Columns.Count);

                            //Добавим в таблицу общий заголовок
                            PdfPCell cell = new PdfPCell(new Phrase("БД Conference, таблица " + (i + 1), font));

                            cell.Colspan = ds.Tables[i].Columns.Count;
                            cell.HorizontalAlignment = 1;
                            //Убираем границу первой ячейки, чтобы балы как заголовок
                            cell.Border = 0;
                            table.AddCell(cell);

                            //Сначала добавляем заголовки таблицы
                            for (int j = 0; j < ds.Tables[i].Columns.Count; j++)
                            {
                                cell = new PdfPCell(new Phrase(new Phrase(ds.Tables[i].Columns[j].ColumnName, font)));
                                //Фоновый цвет (необязательно, просто сделаем по красивее)
                                cell.BackgroundColor = iTextSharp.text.BaseColor.LIGHT_GRAY;
                                table.AddCell(cell);
                            }

                            //Добавляем все остальные ячейки
                            for (int j = 0; j < ds.Tables[i].Rows.Count; j++)
                            {
                                for (int k = 0; k < ds.Tables[i].Columns.Count; k++)
                                {
                                    table.AddCell(new Phrase(ds.Tables[i].Rows[j][k].ToString(), font));
                                }
                            }
                            //Добавляем таблицу в документ
                            doc.Add(table);
                        }
                        //Закрываем документ
                        doc.Close();

                        MessageBox.Show("Pdf-документ сохранен");
                    }
                }
                catch (Exception ex)
                {
                        MessageBox.Show(ex.ToString());
                }
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
