using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

/**
 * ��������� ���������� � ����
 * ��������� ���������� ��� ����� +
 * ������ ���������� +
 * �������� ��������������� ���� +
 * �������� ������ "�������� n ������� �� m" +
 * �������� ����� �� ������� ���� ����� ���������
 * !���
 */

namespace KP_OOP_Boyarinova_23VP1
{
    /// <summary>
    /// �����, ����������� �������������� ������������ � UI
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// ������ � ���������� ���������� ��� �������� ��������� ������
        /// </summary>
        static string regex = @"^[A-Za-z�-��-���]+((-|'| )[A-Za-z�-��-���]+)*$";

        /// <summary>
        /// ����������� �����
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// �������, ��������� ������ � ������� �� �����
        /// </summary>
        private void changeTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //������� �������
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateData();
            dataGridView1.DataSource = dt;
            count_of_showed_labels_label.Text = "�������� " + dt.Rows.Count.ToString() + " ������� �� " + ProxyDB.getInstance().Size().ToString();
        }

        /// <summary>
        /// �������, ������� � ������� �� ����� ��������� ���������� ������/����������
        /// </summary>
        private void changeFilterTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //������� �������
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateFilterData();
            dataGridView1.DataSource = dt;
            count_of_showed_labels_label.Text = "�������� " + dt.Rows.Count.ToString() + " ������� �� " + ProxyDB.getInstance().Size().ToString();
        }

        /// <summary>
        /// �������, ���������� ��� �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("��������� �.�. 23��1 �� '�����������'", "�������� ������",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Win32.MessageBox(0, "��������� �.�. 23��1 �� '�����������'", "�������� ������", 0);
            ProxyDB.getInstance(); //������� ������ ProxyDB, � ������������ �������� ������ �� ��
            await DB.Get_all_from_DB();
            changeTable();
        }

        /// <summary>
        /// �������, ������� ���������� ��� �������� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void exit_Click(object sender, EventArgs e)
        {
            await ProxyDB.getInstance().synchronize_with_DB();
            Close();
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "������� ���� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void create_bd_Click(object sender, EventArgs e)
        {
            DB.Create_DB();
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "������� ���� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void delete_bd_Click(object sender, EventArgs e)
        {
            await DB.Delete_DB();
            ProxyDB.getInstance().Clear_table();
            changeTable();
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "�������� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                ProxyDB.getInstance().Add(new Participant(0, name, post, name_of_report, theme, section, speciality, type_of_participate));
            }
            else
            {
                type_of_participate = "���������";
                ProxyDB.getInstance().Add(new Participant(0, name, post, type_of_participate));
            }
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "������� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_record_Click(object sender, EventArgs e)
        {
            ProxyDB.getInstance().NotifyRemove += changeTable;
            int id = Convert.ToInt32(numericUpDown1.Value);
            if (!ProxyDB.getInstance().Remove(id)) MessageBox.Show("������ � ����� �������� �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("������ �������", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "�������� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void change_record_Click(object sender, EventArgs e)
        {
            ProxyDB.getInstance().NotifyUpdate += changeTable;
            int id = Convert.ToInt32(numericUpDown1.Value);
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


        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "����������� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void filter_records_Click(object sender, EventArgs e)
        {
            //���� �� ���������� ��������, ���������� ��� ������� - ������ ������ �������
            string field = comboBox5.Text, value = textBox5.Text;
            if (value == "") MessageBox.Show("������������ �������� ���� ��� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!Regex.IsMatch(value, regex) && field != "Id")
            {
                MessageBox.Show("������������ �������� ���� ��� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProxyDB.getInstance().NotifyFilter += changeFilterTable;
            ProxyDB.getInstance().Filter(field, value);
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "��������� ���� ������ � ����" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void save_into_file_Click(object sender, EventArgs e)
        {
            await DB.Export();
        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "����� ������" �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void find_button_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(numericUpDown1.Value);
            //id--;
            ProxyDB.getInstance().NotifyFilter += changeFilterTable;
            if (!ProxyDB.getInstance().Find(id)) MessageBox.Show("Id �� ����������", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// �������, ������������ ��� ������� �� ������ "������� ��� �� �����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void print_allbutton_Click(object sender, EventArgs e)
        {
            changeTable();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
