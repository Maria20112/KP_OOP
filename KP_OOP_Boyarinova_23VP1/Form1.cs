using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

/**
 * поправить сохранение в файл
 * выровнять текстбоксы для ввода +
 * убрать сортировку +
 * добавить масштабирование окна +
 * добавить запись "Выведено n записей из m" +
 * добавить ярлык на рабочий стол после установки
 * !гит
 */

namespace KP_OOP_Boyarinova_23VP1
{
    /// <summary>
    /// класс, описывающий взаимодействие пользователя с UI
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// строка с регулярным выражением для проверки введенных данных
        /// </summary>
        static string regex = @"^[A-Za-zА-Яа-яЁё]+((-|'| )[A-Za-zА-Яа-яЁё]+)*$";

        /// <summary>
        /// Конструктор формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// делегат, обновляет данные в таблице на форме
        /// </summary>
        private void changeTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //очищаем таблицу
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateData();
            dataGridView1.DataSource = dt;
            count_of_showed_labels_label.Text = "Выведено " + dt.Rows.Count.ToString() + " записей из " + ProxyDB.getInstance().Size().ToString();
        }

        /// <summary>
        /// делегат, выводит в таблицу на форму результат последнего поиска/фильтрации
        /// </summary>
        private void changeFilterTable()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear(); //очищаем таблицу
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();
            DataTable dt = ProxyDB.getInstance().GenerateFilterData();
            dataGridView1.DataSource = dt;
            count_of_showed_labels_label.Text = "Выведено " + dt.Rows.Count.ToString() + " записей из " + ProxyDB.getInstance().Size().ToString();
        }

        /// <summary>
        /// фнукция, вызывается при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Бояринова М.Г. 23ВП1 ИС 'Конференция'", "Курсовой проект",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Win32.MessageBox(0, "Бояринова М.Г. 23ВП1 ИС 'Конференция'", "Курсовой проект", 0);
            ProxyDB.getInstance(); //создаем объект ProxyDB, в конструкторе получаем данные из бд
            await DB.Get_all_from_DB();
            changeTable();
        }

        /// <summary>
        /// функция, которая вызывается при загрузке формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void exit_Click(object sender, EventArgs e)
        {
            await ProxyDB.getInstance().synchronize_with_DB();
            Close();
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Создать базу данных" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void create_bd_Click(object sender, EventArgs e)
        {
            DB.Create_DB();
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Удалить базу данных" на форме
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
        /// функция, вызывающаяся при нажатии на кнопку "Добавить запись" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_record_Click(object sender, EventArgs e)
        {
            /*получение и проверка данных*/
            //Regex.IsMatch(data, regex);
            ProxyDB.getInstance().NotifyAdd += changeTable;
            string name = textBox1.Text + " " + textBox2.Text + " " + textBox3.Text;
            if (!Regex.IsMatch(name, regex))
            {
                MessageBox.Show("Некорректное имя", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //   Win32.MessageBox(0, "Некорректное имя", "Ошибка ввода", 0);
                return;
            }
            string post = comboBox1.Text;
            if (post == "")
            {
                //Win32.MessageBox(0, "Выберите должность", "Ошибка ввода", 0);
                MessageBox.Show("Выберите должность", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name_of_report = textBox4.Text;
            string type_of_participate;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите тип участия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton2.Checked)
            {
                type_of_participate = "выступающий";
                if (!Regex.IsMatch(name_of_report, regex))
                {
                    MessageBox.Show("Некорректное название доклада", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string theme = comboBox2.Text;
                if (theme == "")
                {
                    MessageBox.Show("Выберите тематику", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string section = comboBox3.Text;
                if (section == "")
                {
                    MessageBox.Show("Выберите секцию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string speciality = comboBox4.Text;
                if (speciality == "")
                {
                    MessageBox.Show("Выберите специальность", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ProxyDB.getInstance().Add(new Participant(0, name, post, name_of_report, theme, section, speciality, type_of_participate));
            }
            else
            {
                type_of_participate = "слушатель";
                ProxyDB.getInstance().Add(new Participant(0, name, post, type_of_participate));
            }
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Удалить запись" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delete_record_Click(object sender, EventArgs e)
        {
            ProxyDB.getInstance().NotifyRemove += changeTable;
            int id = Convert.ToInt32(numericUpDown1.Value);
            if (!ProxyDB.getInstance().Remove(id)) MessageBox.Show("Строки с таким индексом не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else MessageBox.Show("Строка удалена", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Изменить запись" на форме
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
                MessageBox.Show("Некорректное имя", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string post = comboBox1.Text;
            if (post == "")
            {
                MessageBox.Show("Выберите должность", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string name_of_report = textBox4.Text;
            string type_of_participate;
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Выберите тип участия", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (radioButton2.Checked)
            {
                type_of_participate = "выступающий";
                if (!Regex.IsMatch(name_of_report, regex))
                {
                    MessageBox.Show("Некорректное название доклада", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string theme = comboBox2.Text;
                if (theme == "")
                {
                    MessageBox.Show("Выберите тематику", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string section = comboBox3.Text;
                if (section == "")
                {
                    MessageBox.Show("Выберите секцию", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string speciality = comboBox4.Text;
                if (speciality == "")
                {
                    MessageBox.Show("Выберите специальность", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!ProxyDB.getInstance().Change(id, new Participant(id, name, post, name_of_report, theme, section, speciality, type_of_participate))) MessageBox.Show("Строки с таким индексом не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Строка изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
            else
            {
                type_of_participate = "слушатель";
                if (!ProxyDB.getInstance().Change(id, new Participant(id, name, post, type_of_participate))) MessageBox.Show("Строки с таким индексом не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else MessageBox.Show("Строка изменена", "", MessageBoxButtons.OK, MessageBoxIcon.Information); ;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Фильтровать записи" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void filter_records_Click(object sender, EventArgs e)
        {
            //если не существует объектов, подходящих под условие - просто пустая таблица
            string field = comboBox5.Text, value = textBox5.Text;
            if (value == "") MessageBox.Show("Некорректное значение поля для фильтрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (!Regex.IsMatch(value, regex) && field != "Id")
            {
                MessageBox.Show("Некорректное значение поля для фильтрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProxyDB.getInstance().NotifyFilter += changeFilterTable;
            ProxyDB.getInstance().Filter(field, value);
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Сохранить базу данных в файл" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void save_into_file_Click(object sender, EventArgs e)
        {
            await DB.Export();
        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Найти запись" на форме
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void find_button_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(numericUpDown1.Value);
            //id--;
            ProxyDB.getInstance().NotifyFilter += changeFilterTable;
            if (!ProxyDB.getInstance().Find(id)) MessageBox.Show("Id не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// функция, вызывающаяся при нажатии на кнопку "Вывести все на форме
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
