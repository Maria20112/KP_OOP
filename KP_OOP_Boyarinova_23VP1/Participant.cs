using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KP_OOP_Boyarinova_23VP1
{
    internal class Participant
    {
        //private int Id { get; }
        public string Name { get; set; } = "";
        public string? Post { get; set; }
        public int Id { get; set; }
        public string? Name_of_report { get; set; }
        public string? Theme { get; set; }
        public string? Section { get; set; }
        public string? Speciality { get; set; }
        public string Type_of_participate { get; set; }

        public Participant() {}

        public Participant(int id, string name, string? post, string? name_of_report, string? theme, string? section, string? speciality, string type_of_participate)
        {
            Id = id;
            Name = name;
            Post = post;
            Name_of_report = name_of_report;
            Theme = theme;
            Section = section;
            Speciality = speciality;
            Type_of_participate = type_of_participate;
        }

        public Participant(int id, string name, string post,string type_of_participate)
        {
            Id = id;
            Name = name;
            Post = post;
            Type_of_participate = type_of_participate;
        }
    }
}
