using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using PdfSharp.Charting;

namespace KP_OOP_Boyarinova_23VP1
{
    internal class ProxyDB
    {
        private static ProxyDB instance;
        private List<Participant> participants = new List<Participant>();
        private List<Participant> last_filter = new List<Participant>();
        public delegate void PersonAdd();
        public delegate void PersonRemove();
        public delegate void PersonUpdate();
        public delegate void PersonSort();
        public delegate void PersonFilter();
        public event PersonAdd? NotifyAdd;
        public event PersonRemove? NotifyRemove;
        public event PersonUpdate? NotifyUpdate;
        public event PersonSort? NotifySort;
        public event PersonFilter? NotifyFilter;

        public void Clear_last_filter()
        {
            last_filter.Clear();
        }
        public void Sort(bool type)
        {
            if (type) participants.Sort((x, y) => x.Name.CompareTo(y.Name)); //по возрастанию
            else participants.Sort((x, y) => y.Name.CompareTo(x.Name)); //по убыванию
            NotifySort?.Invoke();
        }

        public static ProxyDB getInstance()
        {
            if (instance == null)
            {
                instance = new ProxyDB();
            }
            return instance;
        }

        public void Add_filter(Participant? p)
        {
            if (p != null) last_filter.Add(p);
            NotifyFilter?.Invoke();
        }

        private bool Has_in_ProxyDB(Participant p)
        {
            foreach (Participant person in participants)
            {
                if (person.Name == p.Name && person.Post == p.Post && person.Name_of_report == p.Name_of_report &&
                    person.Theme == p.Theme && person.Section == p.Section && person.Speciality == p.Speciality &&
                    person.Type_of_participate == p.Type_of_participate) return true;
            }
            return false;
        }

        public void Add(Participant p)
        {
            if (DB.CheckDatabase())
            {
                if (!Has_in_ProxyDB(p))
                {
                    participants.Add(p);
                    NotifyAdd?.Invoke();
                }
                else MessageBox.Show("Такая строка уже существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool Remove(int id)
        {
            if (DB.CheckDatabase())
            {
                if (id >= participants.Count) return false;
                participants.Remove(participants[id]);
                NotifyRemove?.Invoke();
                return true;
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        public bool Change(int id, Participant p)
        {
            if (DB.CheckDatabase())
            {
                if (id >= participants.Count) return false;
                participants[id].Name = p.Name;
                participants[id].Post = p.Post;
                participants[id].Name_of_report = p.Name_of_report;
                participants[id].Theme = p.Theme;
                participants[id].Section = p.Section;
                participants[id].Speciality = p.Speciality;
                participants[id].Type_of_participate = p.Type_of_participate;
                NotifyUpdate?.Invoke();
                return true;
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }


        public async Task synchronize_with_DB()
        {
            if (DB.CheckDatabase())
            {
                await DB.Clear_table();
                foreach (var i in participants)
                {
                    await DB.Add_new_row(i);
                }
            }
            else MessageBox.Show("Базы данных не существует", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        ~ProxyDB()
        {
            synchronize_with_DB();
        }
        private ProxyDB() {
            //DB.Get_all_from_DB();
            //Task task = DB.Get_all_from_DB();
            //task.Start();
            //task.Wait();
        }

        public DataTable GenerateData()
        {
            DataTable dataTable = new DataTable();

            if (participants.Count > 0)
            {

                // Добавление колонок
                dataTable.Columns.Add("№ строки", typeof(int));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Должность", typeof(string));
                dataTable.Columns.Add("Название доклада", typeof(string));
                dataTable.Columns.Add("Тематика", typeof(string));
                dataTable.Columns.Add("Секция", typeof(string));
                dataTable.Columns.Add("Специальность", typeof(string));
                dataTable.Columns.Add("Тип участия", typeof(string));

                int counter = 1;
                // Добавление строк
                foreach (Participant p in participants)
                {
                    dataTable.Rows.Add(counter, p.Name, p.Post, p.Name_of_report, p.Theme,
                        p.Section, p.Speciality, p.Type_of_participate);
                    counter++;
                }
            }
            return dataTable;
        }

        public DataTable GenerateFilterData()
        {
            DataTable dataTable = new DataTable();

            if (participants.Count > 0)
            {
                // Добавление колонок
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Должность", typeof(string));
                dataTable.Columns.Add("Название доклада", typeof(string));
                dataTable.Columns.Add("Тематика", typeof(string));
                dataTable.Columns.Add("Секция", typeof(string));
                dataTable.Columns.Add("Специальность", typeof(string));
                dataTable.Columns.Add("Тип участия", typeof(string));

                int counter = 0;
                // Добавление строк
                foreach (Participant p in last_filter)
                {
                    dataTable.Rows.Add(p.Name, p.Post, p.Name_of_report, p.Theme,
                        p.Section, p.Speciality, p.Type_of_participate);
                }
            }
            return dataTable;
        }
    }
}
