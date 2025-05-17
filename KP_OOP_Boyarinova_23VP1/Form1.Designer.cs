namespace KP_OOP_Boyarinova_23VP1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            create_bd = new Button();
            delete_bd = new Button();
            save_into_file = new Button();
            add_record = new Button();
            change_record = new Button();
            delete_record = new Button();
            sort_records = new Button();
            filter_records = new Button();
            exit = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            comboBox2 = new ComboBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            label10 = new Label();
            numericUpDown1 = new NumericUpDown();
            label11 = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            label12 = new Label();
            label13 = new Label();
            comboBox5 = new ComboBox();
            label15 = new Label();
            textBox5 = new TextBox();
            panel5 = new Panel();
            find_button = new Button();
            label16 = new Label();
            print_allbutton = new Button();
            panel6 = new Panel();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // create_bd
            // 
            create_bd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            create_bd.Location = new Point(21, 711);
            create_bd.Name = "create_bd";
            create_bd.Size = new Size(160, 49);
            create_bd.TabIndex = 0;
            create_bd.Text = "Создать базу данных";
            create_bd.UseVisualStyleBackColor = true;
            create_bd.Click += create_bd_Click;
            // 
            // delete_bd
            // 
            delete_bd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            delete_bd.Location = new Point(222, 711);
            delete_bd.Name = "delete_bd";
            delete_bd.Size = new Size(160, 49);
            delete_bd.TabIndex = 1;
            delete_bd.Text = "Удалить базу данных";
            delete_bd.UseVisualStyleBackColor = true;
            delete_bd.Click += delete_bd_Click;
            // 
            // save_into_file
            // 
            save_into_file.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            save_into_file.Location = new Point(441, 711);
            save_into_file.Name = "save_into_file";
            save_into_file.Size = new Size(160, 48);
            save_into_file.TabIndex = 2;
            save_into_file.Text = "Сохранить базу данных в файл";
            save_into_file.UseVisualStyleBackColor = true;
            save_into_file.Click += save_into_file_Click;
            // 
            // add_record
            // 
            add_record.Location = new Point(82, 424);
            add_record.Name = "add_record";
            add_record.Size = new Size(162, 46);
            add_record.TabIndex = 3;
            add_record.Text = "Добавить запись";
            add_record.UseVisualStyleBackColor = true;
            add_record.Click += add_record_Click;
            // 
            // change_record
            // 
            change_record.Anchor = AnchorStyles.Left;
            change_record.Location = new Point(70, 601);
            change_record.Name = "change_record";
            change_record.Size = new Size(165, 28);
            change_record.TabIndex = 4;
            change_record.Text = "Изменить запись";
            change_record.UseVisualStyleBackColor = true;
            change_record.Click += change_record_Click;
            // 
            // delete_record
            // 
            delete_record.Anchor = AnchorStyles.Left;
            delete_record.Location = new Point(70, 568);
            delete_record.Name = "delete_record";
            delete_record.Size = new Size(165, 27);
            delete_record.TabIndex = 5;
            delete_record.Text = "Удалить запись";
            delete_record.UseVisualStyleBackColor = true;
            delete_record.Click += delete_record_Click;
            // 
            // sort_records
            // 
            sort_records.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sort_records.Location = new Point(1014, 13);
            sort_records.Name = "sort_records";
            sort_records.Size = new Size(162, 43);
            sort_records.TabIndex = 6;
            sort_records.Text = "Сортировать записи";
            sort_records.UseVisualStyleBackColor = true;
            // 
            // filter_records
            // 
            filter_records.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            filter_records.Location = new Point(1203, 13);
            filter_records.Name = "filter_records";
            filter_records.Size = new Size(163, 43);
            filter_records.TabIndex = 7;
            filter_records.Text = "Фильтровать записи";
            filter_records.UseVisualStyleBackColor = true;
            filter_records.Click += filter_records_Click;
            // 
            // exit
            // 
            exit.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exit.Location = new Point(1288, 729);
            exit.Name = "exit";
            exit.Size = new Size(94, 29);
            exit.TabIndex = 8;
            exit.Text = "Выход";
            exit.UseVisualStyleBackColor = true;
            exit.Click += exit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 88);
            label1.Name = "label1";
            label1.Size = new Size(73, 20);
            label1.TabIndex = 9;
            label1.Text = "Фамилия";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 117);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 10;
            label2.Text = "Имя";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(20, 147);
            label3.Name = "label3";
            label3.Size = new Size(72, 20);
            label3.TabIndex = 11;
            label3.Text = "Отчество";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 180);
            label4.Name = "label4";
            label4.Size = new Size(86, 20);
            label4.TabIndex = 12;
            label4.Text = "Должность";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 217);
            label5.Name = "label5";
            label5.Size = new Size(137, 20);
            label5.TabIndex = 13;
            label5.Text = "Название доклада";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 255);
            label6.Name = "label6";
            label6.Size = new Size(74, 20);
            label6.TabIndex = 14;
            label6.Text = "Тематика";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(20, 289);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 15;
            label7.Text = "Секция";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(20, 320);
            label8.Name = "label8";
            label8.Size = new Size(116, 20);
            label8.TabIndex = 16;
            label8.Text = "Специальность";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(21, 357);
            label9.Name = "label9";
            label9.Size = new Size(92, 20);
            label9.TabIndex = 17;
            label9.Text = "Тип участия";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(156, 81);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 18;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(156, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 19;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(156, 147);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 20;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "преподаватель", "аспирант", "студент" });
            comboBox1.Location = new Point(156, 180);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(156, 214);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(125, 27);
            textBox4.TabIndex = 22;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Системное администрирование", "Шифрование", "Прикладное программное обеспечение" });
            comboBox2.Location = new Point(156, 249);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 23;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Items.AddRange(new object[] { "Программная инженерия", "Информационные системы", "Прикладная информатика" });
            comboBox3.Location = new Point(156, 283);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(151, 28);
            comboBox3.TabIndex = 24;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Items.AddRange(new object[] { "Программная инженерия", "Прикладная информатика", "Компьютерные технологии" });
            comboBox4.Location = new Point(156, 317);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(151, 28);
            comboBox4.TabIndex = 25;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(156, 351);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(104, 24);
            radioButton1.TabIndex = 26;
            radioButton1.TabStop = true;
            radioButton1.Text = "Слушатель";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(156, 381);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(129, 24);
            radioButton2.TabIndex = 27;
            radioButton2.TabStop = true;
            radioButton2.Text = "Выступающий";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label10.Location = new Point(77, 24);
            label10.Name = "label10";
            label10.Size = new Size(170, 20);
            label10.TabIndex = 28;
            label10.Text = "Создать новую запись";
            // 
            // numericUpDown1
            // 
            numericUpDown1.Anchor = AnchorStyles.Left;
            numericUpDown1.Location = new Point(70, 535);
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(162, 27);
            numericUpDown1.TabIndex = 29;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Left;
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label11.Location = new Point(54, 494);
            label11.Name = "label11";
            label11.Size = new Size(185, 20);
            label11.TabIndex = 30;
            label11.Text = "Выберите номер записи";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = SystemColors.ControlDark;
            panel1.Location = new Point(0, 695);
            panel1.Name = "panel1";
            panel1.Size = new Size(1386, 10);
            panel1.TabIndex = 31;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel2.BackColor = SystemColors.ControlDark;
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(313, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(10, 692);
            panel2.TabIndex = 32;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlDark;
            panel4.Location = new Point(3, 452);
            panel4.Name = "panel4";
            panel4.Size = new Size(709, 10);
            panel4.TabIndex = 43;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Left;
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Location = new Point(3, 476);
            panel3.Name = "panel3";
            panel3.Size = new Size(314, 10);
            panel3.TabIndex = 33;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(333, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1056, 403);
            dataGridView1.TabIndex = 34;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label12.Location = new Point(801, 22);
            label12.Name = "label12";
            label12.Size = new Size(137, 23);
            label12.TabIndex = 35;
            label12.Text = "Вывод записей";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label13.AutoSize = true;
            label13.Location = new Point(350, 517);
            label13.Name = "label13";
            label13.Size = new Size(119, 20);
            label13.TabIndex = 36;
            label13.Text = "Выберите поле:";
            // 
            // comboBox5
            // 
            comboBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            comboBox5.FormattingEnabled = true;
            comboBox5.Items.AddRange(new object[] { "Id", "Имя", "Должность", "Название доклада", "Тематика", "Секция", "Специальность", "Тип участия" });
            comboBox5.Location = new Point(350, 540);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(151, 28);
            comboBox5.TabIndex = 37;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label15.AutoSize = true;
            label15.Location = new Point(350, 582);
            label15.Name = "label15";
            label15.Size = new Size(351, 20);
            label15.TabIndex = 41;
            label15.Text = "Значение выбранного поля должно быть равно:";
            // 
            // textBox5
            // 
            textBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textBox5.Location = new Point(350, 605);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 42;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel5.BackColor = SystemColors.ControlDark;
            panel5.Location = new Point(742, 464);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 232);
            panel5.TabIndex = 43;
            // 
            // find_button
            // 
            find_button.Anchor = AnchorStyles.Left;
            find_button.Location = new Point(70, 636);
            find_button.Name = "find_button";
            find_button.Size = new Size(165, 29);
            find_button.TabIndex = 44;
            find_button.Text = "Найти запись";
            find_button.UseVisualStyleBackColor = true;
            find_button.Click += find_button_Click;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label16.Location = new Point(344, 494);
            label16.Name = "label16";
            label16.Size = new Size(184, 20);
            label16.TabIndex = 45;
            label16.Text = "Настройки фильтрации:";
            label16.Click += label16_Click;
            // 
            // print_allbutton
            // 
            print_allbutton.Location = new Point(329, 13);
            print_allbutton.Name = "print_allbutton";
            print_allbutton.Size = new Size(143, 43);
            print_allbutton.TabIndex = 46;
            print_allbutton.Text = "Вывести все";
            print_allbutton.UseVisualStyleBackColor = true;
            print_allbutton.Click += print_allbutton_Click;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.OldLace;
            panel6.Controls.Add(label10);
            panel6.Controls.Add(label16);
            panel6.Controls.Add(textBox5);
            panel6.Controls.Add(print_allbutton);
            panel6.Controls.Add(label15);
            panel6.Controls.Add(panel5);
            panel6.Controls.Add(comboBox5);
            panel6.Controls.Add(add_record);
            panel6.Controls.Add(label13);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(find_button);
            panel6.Controls.Add(label2);
            panel6.Controls.Add(label3);
            panel6.Controls.Add(save_into_file);
            panel6.Controls.Add(exit);
            panel6.Controls.Add(delete_bd);
            panel6.Controls.Add(label4);
            panel6.Controls.Add(create_bd);
            panel6.Controls.Add(label5);
            panel6.Controls.Add(label6);
            panel6.Controls.Add(dataGridView1);
            panel6.Controls.Add(label7);
            panel6.Controls.Add(label12);
            panel6.Controls.Add(label8);
            panel6.Controls.Add(label9);
            panel6.Controls.Add(textBox1);
            panel6.Controls.Add(filter_records);
            panel6.Controls.Add(panel1);
            panel6.Controls.Add(sort_records);
            panel6.Controls.Add(textBox2);
            panel6.Controls.Add(textBox3);
            panel6.Controls.Add(panel3);
            panel6.Controls.Add(label11);
            panel6.Controls.Add(numericUpDown1);
            panel6.Controls.Add(comboBox1);
            panel6.Controls.Add(panel2);
            panel6.Controls.Add(textBox4);
            panel6.Controls.Add(comboBox2);
            panel6.Controls.Add(delete_record);
            panel6.Controls.Add(comboBox3);
            panel6.Controls.Add(change_record);
            panel6.Controls.Add(comboBox4);
            panel6.Controls.Add(radioButton1);
            panel6.Controls.Add(radioButton2);
            panel6.Location = new Point(2, 12);
            panel6.Name = "panel6";
            panel6.Size = new Size(1393, 763);
            panel6.TabIndex = 47;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(1392, 772);
            Controls.Add(panel6);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "ИС \"Конференция\"";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button create_bd;
        private Button delete_bd;
        private Button save_into_file;
        private Button add_record;
        private Button change_record;
        private Button delete_record;
        private Button sort_records;
        private Button filter_records;
        private Button exit;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private TextBox textBox4;
        private ComboBox comboBox2;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Label label10;
        private NumericUpDown numericUpDown1;
        private Label label11;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dataGridView1;
        private Label label12;
        private Label label13;
        private ComboBox comboBox5;
        private Panel panel4;
        private Label label15;
        private TextBox textBox5;
        private Panel panel5;
        private Button find_button;
        private Label label16;
        private Button print_allbutton;
        private Panel panel6;
    }
}
