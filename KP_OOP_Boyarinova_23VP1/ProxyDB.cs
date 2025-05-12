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
        private IOrderedEnumerable<Participant> last_filter;
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

        public int Size()
        {
            return participants.Count;
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
            NotifyFilter?.Invoke();
        }

        public void Filter(string field, string value)
        {
            switch (field) {
                case "Id":
                    last_filter = from p in participants
                                  where Convert.ToString(p.Id) == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Имя":
                    last_filter = from p in participants
                                  where p.Name == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Должность":
                    last_filter = from p in participants
                                  where p.Post == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Название доклада":
                    last_filter = from p in participants
                                  where p.Name_of_report == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Тематика":
                    last_filter = from p in participants
                                  where p.Theme == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Секция":
                    last_filter = from p in participants
                                  where p.Section == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Специальность":
                    last_filter = from p in participants
                                  where p.Speciality == value
                                  orderby p.Id
                                  select p;
                    break;
                case "Тип участия":
                    last_filter = from p in participants
                                  where p.Type_of_participate == value
                                  orderby p.Id
                                  select p;
                    break;
                default:
                    MessageBox.Show("Выберите поле для фильтрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
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
                if (!Find(id)) return false;
                participants.Remove(last_filter.First());
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
        private ProxyDB() {}

        public DataTable GenerateData()
        {
            DataTable dataTable = new DataTable();

            if (participants.Count > 0)
            {

                // Добавление колонок
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Должность", typeof(string));
                dataTable.Columns.Add("Название доклада", typeof(string));
                dataTable.Columns.Add("Тематика", typeof(string));
                dataTable.Columns.Add("Секция", typeof(string));
                dataTable.Columns.Add("Специальность", typeof(string));
                dataTable.Columns.Add("Тип участия", typeof(string));

                // Добавление строк
                foreach (Participant p in participants)
                {
                    dataTable.Rows.Add(p.Id, p.Name, p.Post, p.Name_of_report, p.Theme,
                        p.Section, p.Speciality, p.Type_of_participate);
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
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Имя", typeof(string));
                dataTable.Columns.Add("Должность", typeof(string));
                dataTable.Columns.Add("Название доклада", typeof(string));
                dataTable.Columns.Add("Тематика", typeof(string));
                dataTable.Columns.Add("Секция", typeof(string));
                dataTable.Columns.Add("Специальность", typeof(string));
                dataTable.Columns.Add("Тип участия", typeof(string));

                // Добавление строк
                foreach (Participant p in last_filter)
                {
                    dataTable.Rows.Add(p.Id, p.Name, p.Post, p.Name_of_report, p.Theme,
                        p.Section, p.Speciality, p.Type_of_participate);
                }
            }
            return dataTable;
        }

        public bool Find(int id)
        {
            if (id > participants.Count) return false;
            last_filter = from p in participants
                          where p.Id == id
                          orderby p.Id
                          select p;
            if (last_filter.Count() > 0)
            {
                NotifyFilter?.Invoke();
                return true;
            }
            return false;
        }
    }
}
