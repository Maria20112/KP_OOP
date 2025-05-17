using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OOP_Boyarinova_23VP1
{
    /// <summary>
    /// класс, описывающий участника конференции
    /// </summary>
    internal class Participant
    {
        /// <summary>
        /// имя участника
        /// </summary>
        public string Name { get; set; } = "";
        /// <summary>
        /// должность участника
        /// </summary>
        public string? Post { get; set; }
        /// <summary>
        /// Идентификационный участника
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название доклада участника
        /// </summary>
        public string? Name_of_report { get; set; }
        /// <summary>
        /// Тематика доклада
        /// </summary>
        public string? Theme { get; set; }
        /// <summary>
        /// Секция
        /// </summary>
        public string? Section { get; set; }
        /// <summary>
        /// Специальность
        /// </summary>
        public string? Speciality { get; set; }
        /// <summary>
        /// тип участия
        /// </summary>
        public string Type_of_participate { get; set; }
        /// <summary>
        /// количество созданных когда-либо участников
        /// </summary>
        static public int count_of_people = 0;

        /// <summary>
        /// конструктор участника с типом участия "Выступающий"
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Имя</param>
        /// <param name="post">Должность</param>
        /// <param name="name_of_report">Название доклада</param>
        /// <param name="theme">Тематика</param>
        /// <param name="section">Секция</param>
        /// <param name="speciality">Специальность</param>
        /// <param name="type_of_participate">Тип участия</param>
        public Participant(int id, string name, string? post, string? name_of_report, string? theme, string? section, string? speciality, string type_of_participate)
        {
            count_of_people++;
            if (id != 0)
            {
                Id = id;
                count_of_people = Math.Max(count_of_people, id);
            }
            else Id = count_of_people;
            Name = name;
            Post = post;
            Name_of_report = name_of_report;
            Theme = theme;
            Section = section;
            Speciality = speciality;
            Type_of_participate = type_of_participate;
        }

        /// <summary>
        /// конструктор участника с типом участия "Слушатель"
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="name">Имя</param>
        /// <param name="post">Должность</param>
        /// <param name="type_of_participate">Тип участия</param>
        public Participant(int id, string name, string post,string type_of_participate)
        {
            count_of_people++;
            if (id != 0) { 
                Id = id;
                count_of_people = Math.Max(count_of_people, id);
            }
            else Id = count_of_people;
            Name = name;
            Post = post;
            Type_of_participate = type_of_participate;
        }
    }
}
