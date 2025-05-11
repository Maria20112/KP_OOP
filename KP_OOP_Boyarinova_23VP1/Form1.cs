using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KP_OOP_Boyarinova_23VP1
{
    public partial class Form1 : Form
    {
        static string regex = @"^[A-Za-z�-��-���]+((-|'| )[A-Za-z�-��-���]+)*$";
        public Form1()
        {
            InitializeComponent();
        }

        private void changeTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //������� �������
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateData();
            dataGridView1.DataSource = dt;
        }

        private void changeFilterTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //������� �������
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateFilterData();
            dataGridView1.DataSource = dt;
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("��������� �.�. 23��1 �� '�����������'", "�������� ������", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Win32.MessageBox(0, "��������� �.�. 23��1 �� '�����������'", "�������� ������", 0);
            ProxyDB.getInstance(); //������� ������ ProxyDB, � ������������ �������� ������ �� ��
            await DB.Get_all_from_DB();
            changeTable();
        }

        private async void exit_Click(object sender, EventArgs e)
        {
            await ProxyDB.getInstance().synchronize_with_DB();
            Close();
        }

        private void create_bd_Click(object sender, EventArgs e)
        {
            DB.Create_DB();
        }

        private async void delete_bd_Click(object sender, EventArgs e)
        {
            await DB.Delete_DB();
            changeTable();
        }

        private void add_record_Click(object sender, EventArgs e)
        {
            /*��������� � �������� ������*/
            //Regex.IsMatch(data, regex);
            ProxyDB.getInstance().NotifyAdd += changeTable;
            string name = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            if (!Regex.IsMatch(name, regex))
            {
                MessageBox.Show("������������ ���", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
             //   Win32.MessageBox(0, "������������ ���", "������ �����", 0);
                return;
            }
            string post = comboBox1.Text;
            if (post == "")
            {
                //Win32.MessageBox(0, "�������� ���������", "������ �����", 0);
                MessageBox.Show("�������� ���������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name_of_report = textBox4.Text;
            string type_of_participate;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("�������� ��� �������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton2.Checked)
            {
                type_of_participate = "�����������";
                if (!Regex.IsMatch(name_of_report, regex))
                {
                    MessageBox.Show("������������ �������� �������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string theme = comboBox2.Text;
                if (theme == "")
                {
                    MessageBox.Show("�������� ��������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string section = comboBox3.Text;
                if (section == "")
                {
                    MessageBox.Show("�������� ������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string speciality = comboBox4.Text;
                if (speciality == "")
                {
                    MessageBox.Show("�������� �������������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ProxyDB.getInstance().Add(new Participant(ProxyDB.getInstance().Size()+1, name, post, name_of_report, theme, section, speciality, type_of_participate));
            }
            else
            {
                type_of_participate = "���������";
                ProxyDB.getInstance().Add(new Participant(ProxyDB.getInstance().Size() + 1, name, post, type_of_participate));
            }
        }

        private void delete_record_Click(object sender, EventArgs e)
        {
            ProxyDB.getInstance().NotifyRemove += changeTable;
            int id = Convert.ToInt32(numericUpDown1.Value);
            id--;
            if (!ProxyDB.getInstance().Remove(id)) MessageBox.Show("������ � ����� �������� �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("������ �������", "������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //����������� �������� ���������
        private void change_record_Click(object sender, EventArgs e)
        {
            ProxyDB.getInstance().NotifyUpdate += changeTable;
            int id = Convert.ToInt32(numericUpDown1.Value);
            id--;
            string name = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            if (!Regex.IsMatch(name, regex))
            {
                MessageBox.Show("������������ ���", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string post = comboBox1.Text;
            if (post == "")
            {
                MessageBox.Show("�������� ���������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name_of_report = textBox4.Text;
            string type_of_participate;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("�������� ��� �������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton2.Checked)
            {
                type_of_participate = "�����������";
                if (!Regex.IsMatch(name_of_report, regex))
                {
                    MessageBox.Show("������������ �������� �������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string theme = comboBox2.Text;
                if (theme == "")
                {
                    MessageBox.Show("�������� ��������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string section = comboBox3.Text;
                if (section == "")
                {
                    MessageBox.Show("�������� ������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string speciality = comboBox4.Text;
                if (speciality == "")
                {
                    MessageBox.Show("�������� �������������", "������ �����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ProxyDB.getInstance().Change(id, new Participant(id, name, post, name_of_report, theme, section, speciality, type_of_participate))) MessageBox.Show("������ � ����� �������� �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("������ ��������", "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                type_of_participate = "���������";
                if (!ProxyDB.getInstance().Change(id, new Participant(id, name, post, type_of_participate))) MessageBox.Show("������ � ����� �������� �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("������ ��������", "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void sort_records_Click(object sender, EventArgs e)
        {
            if (DB.CheckDatabase())
            {
                ProxyDB.getInstance().NotifySort += changeTable;
                if (radioButton3.Checked)
                {
                    ProxyDB.getInstance().Sort(true);
                    return;
                }
                if (radioButton4.Checked)
                {
                    ProxyDB.getInstance().Sort(false);
                    return;
                }
                MessageBox.Show("�������� ����������� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("���� ������ � ����� ��������� �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void filter_records_Click(object sender, EventArgs e)
        {
            await ProxyDB.getInstance().synchronize_with_DB();
            //���� �� ���������� ��������, ���������� ��� ������� - ������ ������ �������
            string field, value = textBox5.Text;
            if (!Regex.IsMatch(value, regex))
            {
                MessageBox.Show("������������ �������� ���� ��� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            switch (comboBox5.Text)
            {
                case "���":
                    field = "Name";
                    break;
                case "���������":
                    field = "PostOfParticipant";
                    break;
                case "�������� �������":
                    field = "NameOfReport";
                    break;
                case "��������":
                    field = "Theme";
                    break;
                case "������":
                    field = "Section";
                    break;
                case "�������������":
                    field = "Speciality";
                    break;
                case "��� �������":
                    field = "TypeOfParticipate";
                    break;
                default:
                    MessageBox.Show("�������� ���� ��� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            ProxyDB.getInstance().NotifyFilter += changeFilterTable;
            DB.Filter(field, value);
        }

        private async void save_into_file_Click(object sender, EventArgs e)
        {
            await DB.Export();
        }
    }
}
