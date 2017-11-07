using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sql
{
    public partial class Form2 : Form
    {
        //Вход для админа
        Panel panel = new Panel();
        Panel subpanel = new Panel();
        MenuStrip menu = new MenuStrip();
        ToolStripMenuItem Вызовы;
        ToolStripMenuItem Сотрудники;
        ToolStripMenuItem Должности;
        ToolStripMenuItem Автомобили;
        ToolStripMenuItem Тарифы_и_услуги;
        ToolStripMenuItem Тарифы;
        ToolStripMenuItem Услуги;
        ToolStripMenuItem УчетныеЗаписи;
        ToolStripMenuItem Архив;
        ToolStripLabel dateLabel;
        ToolStripLabel timeLabel;
        ToolStripLabel infoLabel1;
        ToolStripLabel infoLabel2;
        StatusStrip statusStrip;
        Timer timer;
        Label lb0;
        Label lb1;
        Label lb2;
        Label lb3;
        Label lb4;
        Label lb5;
        Label lb6;
        Label lb7;
        Label lb8;
        Label lb9;
        Label lb10;
        Label lb11;
        Label lb12;
        Label lb13;
        TextBox tb0;
        TextBox tb1;
        TextBox tb2;
        TextBox tb3;
        TextBox tb4;
        TextBox tb5;
        TextBox tb6;
        TextBox tb7;
        TextBox tb8;
        TextBox tb9;
        TextBox tb10;
        TextBox tb11;
        TextBox tb12;
        TextBox tb13;
        Button b1;
        Button b2;
        Button b3;
        Button b4;
        Button b5;
        DataGrid dg1;
        DateTimePicker dtp1;
        DateTimePicker dtp2;
        ComboBox cb1;
        Form form;

        Button exit = new Button() 
        {
            Text = "Выход",
            AutoSize = true
        };

        public Form2()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel.AutoSize = true;
            panel.Location = new Point(0, 30);
            panel.Size = new Size(this.Width, this.Height - 50);
            this.Controls.Add(panel);

            this.Controls.Add(menu);
            menu.Focus();

            Вызовы = new ToolStripMenuItem("Вызовы");
            Вызовы.Click += new EventHandler(Вызовы_Click);
            menu.Items.Add(Вызовы);

            Сотрудники = new ToolStripMenuItem("Сотрудники");
            Сотрудники.Click += new EventHandler(Сотрудники_Click);
            menu.Items.Add(Сотрудники);

            Должности = new ToolStripMenuItem("Должности");
            Должности.Click += new EventHandler(Должности_Click);
            menu.Items.Add(Должности);

            Автомобили = new ToolStripMenuItem("Автомобили");
            Автомобили.Click += new EventHandler(Автомобили_Click);
            menu.Items.Add(Автомобили);

            Тарифы_и_услуги = new ToolStripMenuItem("Тарифы и услуги");
            menu.Items.Add(Тарифы_и_услуги);

            Тарифы = new ToolStripMenuItem("Тарифы");
            Тарифы.Click += new EventHandler(Тарифы_Click);
            Тарифы_и_услуги.DropDownItems.Add(Тарифы);

            Услуги = new ToolStripMenuItem("Услуги");
            Услуги.Click += new EventHandler(Услуги_Click);
            Тарифы_и_услуги.DropDownItems.Add(Услуги);

            УчетныеЗаписи = new ToolStripMenuItem("УчетныеЗаписи");
            УчетныеЗаписи.Click += new EventHandler(УчетныеЗаписи_Click);
            menu.Items.Add(УчетныеЗаписи);

            Архив = new ToolStripMenuItem("Архив");
            Архив.Click += new EventHandler(Архив_Click);
            menu.Items.Add(Архив);

            exit.Location = new Point(this.Width - 180, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            infoLabel1 = new ToolStripLabel();
            infoLabel1.Text = "Текущие дата и время:";

            infoLabel2 = new ToolStripLabel();
            infoLabel2.Text = "         Уровень доступа: Администратор";

            statusStrip = new StatusStrip();
            statusStrip.Items.Add(infoLabel1);

            dateLabel = new ToolStripLabel();
            statusStrip.Items.Add(dateLabel);

            timeLabel = new ToolStripLabel();
            statusStrip.Items.Add(timeLabel);

            statusStrip.Items.Add(infoLabel2);
            this.Controls.Add(statusStrip);

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            dateLabel.Text = DateTime.Now.ToLongDateString();
            timeLabel.Text = DateTime.Now.ToLongTimeString();
        }
        void Вызовы_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            lb1 = new Label();
            lb1.Text = "Код оператора:";
            lb1.AutoSize = true;
            lb1.Location = new Point(50, 30);
            panel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Width + lb1.Location.X + 5, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(50, 25);
            panel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Укажите период:";
            lb2.AutoSize = true;
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + 35);
            panel.Controls.Add(lb2);

            cb1 = new ComboBox();
            cb1.Location = new Point(lb2.Width + lb2.Location.X + 5, lb2.Location.Y - 2);
            cb1.Size = new System.Drawing.Size(80, 25);
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;//Текущая(дефолтная), До, После
            cb1.Items.Add("Текущая");
            cb1.Items.Add("До");
            cb1.Items.Add("После");
            cb1.SelectedIndex = 0;
            panel.Controls.Add(cb1);

            lb3 = new Label();
            lb3.Text = "Укажите дату:";
            lb3.AutoSize = true;
            lb3.Location = new Point(tb1.Location.X + tb1.Width + 40, lb1.Location.Y - 2);
            panel.Controls.Add(lb3);

            dtp1 = new DateTimePicker();
            dtp1.Format = DateTimePickerFormat.Short;
            dtp1.Location = new Point(lb3.Width + lb3.Location.X, lb1.Location.Y - 3);
            dtp1.Size = new System.Drawing.Size(100, 30);
            panel.Controls.Add(dtp1);

            dg1 = new DataGrid();
            dg1.Location = new Point(lb2.Location.X, lb2.Height + lb2.Location.Y + 15);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            b1 = new Button();
            b1.Text = "Найти заказы";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Вызовы_Поиск_Click);
        }
        void Вызовы_Поиск_Click(object sender, EventArgs e)
        {
            int i = 0;
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            if(cb1.SelectedIndex == 0)
            {
                if (tb1.Text == "")
                {
                    string sql = "select * from Вызовы where Дата = @Дата";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
                else
                {
                    string sql = "select * from Вызовы where Дата = @Дата and Код_сотрудника_оператора = @Код_сотрудника_оператора";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    try
                    {
                        i = Convert.ToInt32(tb1.Text);
                    }
                    catch (FormatException ee)
                    {
                        MessageBox.Show("Введенное значение не является целым числом.");
                    }
                    catch (OverflowException ee)
                    {
                        MessageBox.Show("Введенное число не удовлетворяет типу Int32.");
                    }
                   
                    cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника_оператора", SqlDbType.Int));
                    cmdOrderID.Parameters["@Код_сотрудника_оператора"].Value = i;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
            }
            if (cb1.SelectedIndex == 1)
            {
                if (tb1.Text == "")
                {
                    string sql = "select * from Вызовы where Дата < @Дата";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
                else
                {
                    string sql = "select * from Вызовы where Дата < @Дата and Код_сотрудника_оператора = @Код_сотрудника_оператора";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    try
                    {
                        i = Convert.ToInt32(tb1.Text);
                    }
                    catch (FormatException ee)
                    {
                        MessageBox.Show("Введенное значение не является целым числом.");
                    }
                    catch (OverflowException ee)
                    {
                        MessageBox.Show("Введенное число не удовлетворяет типу Int32.");
                    }

                    cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника_оператора", SqlDbType.Int));
                    cmdOrderID.Parameters["@Код_сотрудника_оператора"].Value = i;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
            }
            if (cb1.SelectedIndex == 2)
            {
                if (tb1.Text == "")
                {
                    string sql = "select * from Вызовы where Дата > @Дата";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
                else
                {
                    string sql = "select * from Вызовы where Дата > @Дата and Код_сотрудника_оператора = @Код_сотрудника_оператора";
                    SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                    cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
                    cmdOrderID.Parameters["@Дата"].Value = dtp1.Value;
                    try
                    {
                        i = Convert.ToInt32(tb1.Text);
                    }
                    catch (FormatException ee)
                    {
                        MessageBox.Show("Введенное значение не является целым числом.");
                    }
                    catch (OverflowException ee)
                    {
                        MessageBox.Show("Введенное число не удовлетворяет типу Int32.");
                    }

                    cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника_оператора", SqlDbType.Int));
                    cmdOrderID.Parameters["@Код_сотрудника_оператора"].Value = i;
                    conn.Open();
                    SqlDataReader rdr = cmdOrderID.ExecuteReader();
                    DataTable dataTable = new DataTable();
                    dataTable.Load(rdr);
                    this.dg1.DataSource = dataTable;
                    rdr.Close();
                    conn.Close();
                }
            }
        }
        void Сотрудники_Click(object sender, EventArgs e)
        {
            //Триггер при удалении записи создавал ее копию в таблице Архив
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            string sql = "select * from Сотрудники";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Сотрудники_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Сотрудники_Изменить_Click);

            b3 = new Button();
            b3.Text = "Удалить";
            b3.AutoSize = true;
            b3.Location = new Point(dg1.Location.X + 250, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b3);
            b3.Click += new EventHandler(Сотрудники_Удалить_Click);
        }
        void Сотрудники_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb1 = new Label();
            lb1.Text = "ФИО";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Возраст";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Пол";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            cb1 = new ComboBox();
            cb1.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            cb1.Size = new System.Drawing.Size(80, 25);
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;//Мужской(дефолтная), Женский
            cb1.Items.Add("Мужской");
            cb1.Items.Add("Женский");
            cb1.SelectedIndex = 0;
            subpanel.Controls.Add(cb1);

            lb4 = new Label();
            lb4.Text = "Адрес";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            subpanel.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Телефон";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            subpanel.Controls.Add(lb5);

            tb5 = new TextBox();
            tb5.Location = new Point(lb5.Location.X + lb5.Width + 20, lb5.Location.Y - 2);
            tb5.Size = new System.Drawing.Size(100, 20);
            subpanel.Controls.Add(tb5);

            lb6 = new Label();
            lb6.Text = "Паспортные данные";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            subpanel.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb6);

            lb7 = new Label();
            lb7.Text = "Код должности";
            lb7.Location = new Point(lb6.Location.X, lb6.Location.Y + lb6.Height + 15);
            lb7.AutoSize = true;
            subpanel.Controls.Add(lb7);

            tb7 = new TextBox();
            tb7.Location = new Point(lb7.Location.X + lb7.Width + 20, lb7.Location.Y - 2);
            tb7.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb7);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb7.Location.X + 200, lb7.Location.Y + lb7.Height + 35);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_Сотрудники_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_Сотрудники_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Сотрудники (ФИО, Возраст, Пол, Адрес, Телефон, Паспортные_данные, Код_Должности) values (@ФИО, @Возраст, @Пол, @Адрес, @Телефон, @Паспортные_данные, @Код_Должности)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@ФИО", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@ФИО"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Возраст", SqlDbType.Int));
            i = Convert.ToInt32(tb2.Text);
            cmdOrderID.Parameters["@Возраст"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пол", SqlDbType.NVarChar));
            if (cb1.SelectedIndex == 0)
            {
                string s = "Мужской";
                cmdOrderID.Parameters["@Пол"].Value = s;
            }
            if (cb1.SelectedIndex == 1)
            {
                string s = "Женский";
                cmdOrderID.Parameters["@Пол"].Value = s;
            }
            cmdOrderID.Parameters.Add(new SqlParameter("@Адрес", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Адрес"].Value = tb4.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Телефон", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Телефон"].Value = tb5.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Паспортные_данные", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Паспортные_данные"].Value = tb6.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_Должности", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Код_Должности"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Сотрудники";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Сотрудники_Изменить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Введите старый код сотрудника";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "ФИО";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Возраст";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Пол";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            cb1 = new ComboBox();
            cb1.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            cb1.Size = new System.Drawing.Size(80, 25);
            cb1.DropDownStyle = ComboBoxStyle.DropDownList;//Мужской(дефолтная), Женский
            cb1.Items.Add("Мужской");
            cb1.Items.Add("Женский");
            cb1.SelectedIndex = 0;
            subpanel.Controls.Add(cb1);

            lb4 = new Label();
            lb4.Text = "Адрес";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            subpanel.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Телефон";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            subpanel.Controls.Add(lb5);

            tb5 = new TextBox();
            tb5.Location = new Point(lb5.Location.X + lb5.Width + 20, lb5.Location.Y - 2);
            tb5.Size = new System.Drawing.Size(100, 20);
            subpanel.Controls.Add(tb5);

            lb6 = new Label();
            lb6.Text = "Паспортные данные";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            subpanel.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb6);

            lb7 = new Label();
            lb7.Text = "Код должности";
            lb7.Location = new Point(lb6.Location.X, lb6.Location.Y + lb6.Height + 15);
            lb7.AutoSize = true;
            subpanel.Controls.Add(lb7);

            tb7 = new TextBox();
            tb7.Location = new Point(lb7.Location.X + lb7.Width + 20, lb7.Location.Y - 2);
            tb7.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb7);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb7.Location.X + 200, lb7.Location.Y + lb7.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Изменить_Сотрудники_Click);
            b4.Focus();
        }
        void Выполнить_Изменить_Сотрудники_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "update Сотрудники set ФИО = @ФИО, Возраст = @Возраст, Пол = @Пол, Адрес = @Адрес, Телефон = @Телефон, Паспортные_данные = @Паспортные_данные, Код_Должности = @Код_Должности where Код_сотрудника = @Код_сотрудника";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_сотрудника"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@ФИО", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@ФИО"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Возраст", SqlDbType.Int));
            i = Convert.ToInt32(tb2.Text);
            cmdOrderID.Parameters["@Возраст"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пол", SqlDbType.NVarChar));
            if (cb1.SelectedIndex == 0)
            {
                string s = "Мужской";
                cmdOrderID.Parameters["@Пол"].Value = s;
            }
            if (cb1.SelectedIndex == 1)
            {
                string s = "Женский";
                cmdOrderID.Parameters["@Пол"].Value = s;
            }
            cmdOrderID.Parameters.Add(new SqlParameter("@Адрес", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Адрес"].Value = tb4.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Телефон", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Телефон"].Value = tb5.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Паспортные_данные", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Паспортные_данные"].Value = tb6.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_Должности", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Код_Должности"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Сотрудники";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Сотрудники_Удалить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 100);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Код должности";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb0.Location.X + 200, lb0.Location.Y + lb0.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Удалить_Сотрудники_Click);
            b4.Focus();
        }
        void Выполнить_Удалить_Сотрудники_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";

            string sqlExpression = "Удаление";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter idParam = new SqlParameter
            {
                ParameterName = "@id",
                Value = tb0.Text
            };
            command.Parameters.Add(idParam);
            command.ExecuteNonQuery();
            connection.Close();

            int i = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from Сотрудники where Код_сотрудника = @Код_сотрудника";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_сотрудника"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            dg1.DataSource = null;
            string sql1 = "select * from Сотрудники";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Должности_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet dolznosti = new DataSet();
            DataTable dolz = dolznosti.Tables.Add("Должности");
            SqlCommand cm = new SqlCommand("SELECT * FROM Должности", cn);
            SqlDataAdapter dolzAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            dolzAdapter.Fill(dolz);
            dg1.DataSource = dolz.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Должности_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + b1.Size.Width + 100, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Должности_Изменить_Click);
        }
        void Должности_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Код должности";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "Наименование_должности";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Оклад";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Обязанности";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Требования";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            subpanel.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb4);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb4.Location.X + 200, lb4.Location.Y + lb4.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавить_Должности_Click);
            b4.Focus();
        }
        void Выполнить_Добавить_Должности_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Должности (Код_должности, Наименование_должности, Оклад, Обязанности, Требования) values (@Код_должности, @Наименование_должности, @Оклад, @Обязанности, @Требования)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_должности", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_должности"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование_должности", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование_должности"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Оклад", SqlDbType.Int));
            i = Convert.ToInt32(tb2.Text);
            cmdOrderID.Parameters["@Оклад"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Обязанности", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Обязанности"].Value = tb3.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Требования", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Требования"].Value = tb4.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Должности";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Должности_Изменить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Введите старый код должности";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "Наименование_должности";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Оклад";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Обязанности";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Требования";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            subpanel.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb4);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb4.Location.X + 200, lb4.Location.Y + lb4.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Изменить_Должности_Click);
            b4.Focus();
        }
        void Выполнить_Изменить_Должности_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "update Должности set Наименование_должности = @Наименование_должности, Оклад = @Оклад, Обязанности = @Обязанности, Требования = @Требования where Код_должности = @Код_должности";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_должности", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_должности"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование_должности", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование_должности"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Оклад", SqlDbType.Int));
            i = Convert.ToInt32(tb2.Text);
            cmdOrderID.Parameters["@Оклад"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Обязанности", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Обязанности"].Value = tb3.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Требования", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Требования"].Value = tb4.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Должности";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Автомобили_Click(object sender, EventArgs e)
        {
            //ВЬЮВЕР из таблиц Автомобили и ТипАвто, при изменении предлогать полное изменение или краткое
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet avtomobili = new DataSet();
            DataTable avto = avtomobili.Tables.Add("Автомобили");
            SqlCommand cm = new SqlCommand("SELECT Автомобили.Регистрационный_номер, Автомобили.Код_автомобиля, Автомобили.Номер_кузова, Автомобили.Номер_двигателя, Автомобили.Год_выпуска, Автомобили.Пробег, Автомобили.[Код _сотрудника_шофёра], Автомобили.Дата_последнего_ТО, Автомобили.Состояние_автомобиля, ТипАвто.Код_марки, ТипАвто.Наименование, ТипАвто.Обьем_двигателя, ТипАвто.Тип_двигателя, ТипАвто.Себестоимость_1км_пробега, ТипАвто.Специфика FROM Автомобили INNER JOIN ТипАвто ON Автомобили.Код_марки = ТипАвто.Код_марки", cn);
            SqlDataAdapter avtoAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            avtoAdapter.Fill(avto);
            dg1.DataSource = avto.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Автомобили_Добавить_Click);

            b2 = new Button();
            b2.Text = "Удалить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Автомобили_Удалить_Click);        
        }
        void Автомобили_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            b4 = new Button();
            b4.Text = "Ввести частичные данные";
            b4.Location = new Point(50, 40);
            b4.AutoSize = true;
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Автомобили_Добавить_Частично_Click);

            b5 = new Button();
            b5.Text = "Ввести полные данные";
            b5.AutoSize = true;
            b5.Location = new Point(b4.Location.X + 250, 40);
            subpanel.Controls.Add(b5);
            b5.Click += new EventHandler(Автомобили_Добавить_Полное_Click);
            b5.Focus();
        }
        void Автомобили_Добавить_Частично_Click(object sender, EventArgs e)
        {
            form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.AutoScroll = true;
            form.Size = new System.Drawing.Size(640, 480);
            form.ShowInTaskbar = false;
            form.Show();

            lb1 = new Label();
            lb1.Text = "Марка";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            form.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Регистрационный номер";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            form.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Номер кузова";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            form.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Номер двигателя";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            form.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Год выпуска";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            form.Controls.Add(lb5);

            dtp1 = new DateTimePicker();
            dtp1.Format = DateTimePickerFormat.Short;
            dtp1.Location = new Point(lb5.Width + lb5.Location.X, lb5.Location.Y - 3);
            dtp1.Size = new System.Drawing.Size(100, 30);
            form.Controls.Add(dtp1);

            lb6 = new Label();
            lb6.Text = "Пробег";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            form.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb6);

            lb7 = new Label();
            lb7.Text = "Код шофёра";
            lb7.Location = new Point(lb6.Location.X, lb6.Location.Y + lb6.Height + 15);
            lb7.AutoSize = true;
            form.Controls.Add(lb7);

            tb7 = new TextBox();
            tb7.Location = new Point(lb7.Location.X + lb7.Width + 20, lb7.Location.Y - 2);
            tb7.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb7);
            
            lb8 = new Label();
            lb8.Text = "Состояние";
            lb8.Location = new Point(lb7.Location.X, lb7.Location.Y + lb7.Height + 15);
            lb8.AutoSize = true;
            form.Controls.Add(lb8);

            tb8 = new TextBox();
            tb8.Location = new Point(lb8.Location.X + lb8.Width + 20, lb8.Location.Y - 2);
            tb8.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb8);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb8.Location.X + 200, lb8.Location.Y + lb8.Height + 35);
            form.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_Автомобили_Частично_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_Автомобили_Частично_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Автомобили (Регистрационный_номер, Номер_кузова, Номер_двигателя, Год_выпуска, Пробег, [Код _сотрудника_шофёра], Состояние_автомобиля) values (@Регистрационный_номер, @Номер_кузова, @Номер_двигателя, @Год_выпуска, @Пробег, @Код_шофёра, @Состояние_автомобиля) insert into ТипАвто(Наименование) values (@Наименование)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Регистрационный_номер", SqlDbType.Int));
            i = Convert.ToInt32(tb2.Text);
            cmdOrderID.Parameters["@Регистрационный_номер"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Номер_кузова", SqlDbType.Int));
            i = Convert.ToInt32(tb3.Text);
            cmdOrderID.Parameters["@Номер_кузова"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Номер_двигателя", SqlDbType.Int));
            i = Convert.ToInt32(tb4.Text);
            cmdOrderID.Parameters["@Номер_двигателя"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Год_выпуска", SqlDbType.Date));
            cmdOrderID.Parameters["@Год_выпуска"].Value = dtp1.Value;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пробег", SqlDbType.Int));
            i = Convert.ToInt32(tb6.Text);
            cmdOrderID.Parameters["@Пробег"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_шофёра", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Код_шофёра"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Состояние_автомобиля", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Состояние_автомобиля"].Value = tb8.Text;
            
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;
            form.Close();

            string sql1 = "SELECT Автомобили.Регистрационный_номер, Автомобили.Код_автомобиля, Автомобили.Номер_кузова, Автомобили.Номер_двигателя, Автомобили.Год_выпуска, Автомобили.Пробег, Автомобили.[Код _сотрудника_шофёра], Автомобили.Дата_последнего_ТО, Автомобили.Состояние_автомобиля, ТипАвто.Код_марки, ТипАвто.Наименование, ТипАвто.Обьем_двигателя, ТипАвто.Тип_двигателя, ТипАвто.Себестоимость_1км_пробега, ТипАвто.Специфика FROM Автомобили INNER JOIN ТипАвто ON Автомобили.Код_марки = ТипАвто.Код_марки";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Автомобили_Добавить_Полное_Click(object sender, EventArgs e)
        {
            form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.AutoScroll = true;
            form.Size = new System.Drawing.Size(640, 480);
            form.ShowInTaskbar = false;
            form.Show();

            lb1 = new Label();
            lb1.Text = "Марка";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            form.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Обьем двигателя";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            form.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Тип двигателя";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            form.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Себестоимость 1км пробега";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            form.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Специфика";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            form.Controls.Add(lb5);

            tb5 = new TextBox();
            tb5.Location = new Point(lb5.Location.X + lb5.Width + 20, lb5.Location.Y - 2);
            tb5.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb5);

            lb6 = new Label();
            lb6.Text = "Регистрационный номер";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            form.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb6);
            
            lb7 = new Label();
            lb7.Text = "Номер кузова";
            lb7.Location = new Point(lb6.Location.X, lb6.Location.Y + lb6.Height + 15);
            lb7.AutoSize = true;
            form.Controls.Add(lb7);

            tb7 = new TextBox();
            tb7.Location = new Point(lb7.Location.X + lb7.Width + 20, lb7.Location.Y - 2);
            tb7.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb7);

            lb8 = new Label();
            lb8.Text = "Номер двигателя";
            lb8.Location = new Point(lb7.Location.X, lb7.Location.Y + lb7.Height + 15);
            lb8.AutoSize = true;
            form.Controls.Add(lb8);

            tb8 = new TextBox();
            tb8.Location = new Point(lb8.Location.X + lb8.Width + 20, lb8.Location.Y - 2);
            tb8.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb8);

            lb9 = new Label();
            lb9.Text = "Год выпуска";
            lb9.Location = new Point(lb8.Location.X, lb8.Location.Y + lb8.Height + 15);
            lb9.AutoSize = true;
            form.Controls.Add(lb9);

            dtp1 = new DateTimePicker();
            dtp1.Format = DateTimePickerFormat.Short;
            dtp1.Location = new Point(lb9.Width + lb9.Location.X, lb9.Location.Y - 3);
            dtp1.Size = new System.Drawing.Size(100, 30);
            form.Controls.Add(dtp1);

            lb10 = new Label();
            lb10.Text = "Пробег";
            lb10.Location = new Point(lb9.Location.X, lb9.Location.Y + lb9.Height + 15);
            lb10.AutoSize = true;
            form.Controls.Add(lb10);

            tb10 = new TextBox();
            tb10.Location = new Point(lb10.Location.X + lb10.Width + 20, lb10.Location.Y - 2);
            tb10.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb10);

            lb11 = new Label();
            lb11.Text = "Код шофёра";
            lb11.Location = new Point(lb10.Location.X, lb10.Location.Y + lb10.Height + 15);
            lb11.AutoSize = true;
            form.Controls.Add(lb11);

            tb11 = new TextBox();
            tb11.Location = new Point(lb10.Location.X + lb10.Width + 20, lb10.Location.Y - 2);
            tb11.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb11);

            lb12 = new Label();
            lb12.Text = "Дата последнего ТО";
            lb12.Location = new Point(lb11.Location.X, lb11.Location.Y + lb11.Height + 15);
            lb12.AutoSize = true;
            form.Controls.Add(lb12);

            dtp1 = new DateTimePicker();
            dtp1.Format = DateTimePickerFormat.Short;
            dtp1.Location = new Point(lb12.Width + lb12.Location.X, lb12.Location.Y - 3);
            dtp1.Size = new System.Drawing.Size(100, 30);
            form.Controls.Add(dtp1);

            lb13 = new Label();
            lb13.Text = "Состояние автомобиля";
            lb13.Location = new Point(lb12.Location.X, lb12.Location.Y + lb12.Height + 15);
            lb13.AutoSize = true;
            form.Controls.Add(lb13);

            tb13 = new TextBox();
            tb13.Location = new Point(lb13.Location.X + lb13.Width + 20, lb13.Location.Y - 2);
            tb13.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb13);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb13.Location.X + 200, lb13.Location.Y + lb13.Height + 35);
            form.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_Автомобили_Полное_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_Автомобили_Полное_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Автомобили (Регистрационный_номер, Номер_кузова, Номер_двигателя, Год_выпуска, Пробег, [Код _сотрудника_шофёра], Дата_последнего_ТО, Состояние_автомобиля) values (@Регистрационный_номер, @Номер_кузова, @Номер_двигателя, @Год_выпуска, @Пробег, @Код_шофёра, @Дата_последнего_ТО, @Состояние_автомобиля) insert into ТипАвто(Наименование, Обьем_двигателя, Тип_двигателя, Себестоимость_1км_пробега, Специфика) values (@Наименование, @Обьем_двигателя, @Тип_двигателя, @Себестоимость_1км_пробега, @Специфика)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            double k = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Обьем_двигателя", SqlDbType.Float));
            k = Convert.ToDouble(tb2.Text);
            cmdOrderID.Parameters["@Обьем_двигателя"].Value = k;
            cmdOrderID.Parameters.Add(new SqlParameter("@Тип_двигателя", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Тип_двигателя"].Value = tb3.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Себестоимость_1км_пробега", SqlDbType.Float));
            k = Convert.ToDouble(tb4.Text);
            cmdOrderID.Parameters["@Себестоимость_1км_пробега"].Value = k;
            cmdOrderID.Parameters.Add(new SqlParameter("@Специфика", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Специфика"].Value = tb5.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Регистрационный_номер", SqlDbType.Int));
            i = Convert.ToInt32(tb6.Text);
            cmdOrderID.Parameters["@Регистрационный_номер"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Номер_кузова", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Номер_кузова"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Номер_двигателя", SqlDbType.Int));
            i = Convert.ToInt32(tb8.Text);
            cmdOrderID.Parameters["@Номер_двигателя"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Год_выпуска", SqlDbType.Date));
            cmdOrderID.Parameters["@Год_выпуска"].Value = dtp1.Value;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пробег", SqlDbType.Int));
            i = Convert.ToInt32(tb10.Text);
            cmdOrderID.Parameters["@Пробег"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_шофёра", SqlDbType.Int));
            i = Convert.ToInt32(tb11.Text);
            cmdOrderID.Parameters["@Код_шофёра"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Дата_последнего_ТО", SqlDbType.Date));
            cmdOrderID.Parameters["@Дата_последнего_ТО"].Value = dtp2.Value;
            cmdOrderID.Parameters.Add(new SqlParameter("@Состояние_автомобиля", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Состояние_автомобиля"].Value = tb13.Text;

            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;
            form.Close();

            string sql1 = "SELECT Автомобили.Регистрационный_номер, Автомобили.Код_автомобиля, Автомобили.Номер_кузова, Автомобили.Номер_двигателя, Автомобили.Год_выпуска, Автомобили.Пробег, Автомобили.[Код _сотрудника_шофёра], Автомобили.Дата_последнего_ТО, Автомобили.Состояние_автомобиля, ТипАвто.Код_марки, ТипАвто.Наименование, ТипАвто.Обьем_двигателя, ТипАвто.Тип_двигателя, ТипАвто.Себестоимость_1км_пробега, ТипАвто.Специфика FROM Автомобили INNER JOIN ТипАвто ON Автомобили.Код_марки = ТипАвто.Код_марки";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Автомобили_Удалить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();

            form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.Size = new System.Drawing.Size(480, 320);
            form.ShowInTaskbar = false;
            form.Show();

            lb0 = new Label();
            lb0.Text = "Код автомобиля";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            form.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb0);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb0.Location.X + 200, lb0.Location.Y + lb0.Height + 15);
            form.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Удалить_Автомобили_Click);
            b4.Focus();
        }
        void Выполнить_Удалить_Автомобили_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";

            int i = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from Автомобили where Код_автомобиля = @Код_автомобиля";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_автомобиля", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_автомобиля"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            form.Close();
            dg1.DataSource = null;
            string sql1 = "SELECT Автомобили.Регистрационный_номер, Автомобили.Код_автомобиля, Автомобили.Номер_кузова, Автомобили.Номер_двигателя, Автомобили.Год_выпуска, Автомобили.Пробег, Автомобили.[Код _сотрудника_шофёра], Автомобили.Дата_последнего_ТО, Автомобили.Состояние_автомобиля, ТипАвто.Код_марки, ТипАвто.Наименование, ТипАвто.Обьем_двигателя, ТипАвто.Тип_двигателя, ТипАвто.Себестоимость_1км_пробега, ТипАвто.Специфика FROM Автомобили INNER JOIN ТипАвто ON Автомобили.Код_марки = ТипАвто.Код_марки";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Тарифы_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet tarifi = new DataSet();
            DataTable tar = tarifi.Tables.Add("Тарифы");
            SqlCommand cm = new SqlCommand("SELECT * FROM Тарифы", cn);
            SqlDataAdapter tarifAdapter = new SqlDataAdapter(cm);
            try
            {
                //cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            tarifAdapter.Fill(tar);
            dg1.DataSource = tar.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Тарифы_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Тарифы_Изменить_Click);

            b3 = new Button();
            b3.Text = "Удалить";
            b3.AutoSize = true;
            b3.Location = new Point(dg1.Location.X + 250, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b3);
            b3.Click += new EventHandler(Тарифы_Удалить_Click);
        }
        void Тарифы_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb1 = new Label();
            lb1.Text = "Наименование";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Описание";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(80, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Стоимость";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(40, 25);
            subpanel.Controls.Add(tb3);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb3.Location.X + 200, lb3.Location.Y + lb3.Height + 35);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_Тарифы_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_Тарифы_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Тарифы (Наименование, Описание, Стоимость) values (@Наименование, @Описание, @Стоимость)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            decimal i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Описание", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Описание"].Value = tb2.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
            i = Convert.ToDecimal(tb3.Text);
            cmdOrderID.Parameters["@Стоимость"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Тарифы";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Тарифы_Изменить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Введите старый код тарифа";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "Наименование";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Описание";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(80, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Стоимость";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb3);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb3.Location.X + 200, lb3.Location.Y + lb3.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Изменить_Тарифы_Click);
            b4.Focus();
        }
        void Выполнить_Изменить_Тарифы_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            if (tb2.Text == "")
            {
                conn.Open();
                string sql = "update Тарифы set Наименование = @Наименование, Стоимость = @Стоимость where Код_тарифа = @Код_тарифа";
                SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                int i = 0;
                decimal ii = 0;
                cmdOrderID.Parameters.Add(new SqlParameter("@Код_тарифа", SqlDbType.Int));
                i = Convert.ToInt32(tb0.Text);
                cmdOrderID.Parameters["@Код_тарифа"].Value = tb0.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
                ii = Convert.ToDecimal(tb3.Text);
                cmdOrderID.Parameters["@Стоимость"].Value = ii;
                int j = cmdOrderID.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                string sql = "update Тарифы set Наименование = @Наименование, Описание = @Описание, Стоимость = @Стоимость where Код_тарифа = @Код_тарифа";
                SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                int i = 0;
                decimal ii = 0;
                cmdOrderID.Parameters.Add(new SqlParameter("@Код_тарифа", SqlDbType.Int));
                i = Convert.ToInt32(tb0.Text);
                cmdOrderID.Parameters["@Код_тарифа"].Value = tb0.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Описание", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Описание"].Value = tb2.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
                ii = Convert.ToDecimal(tb3.Text);
                cmdOrderID.Parameters["@Стоимость"].Value = ii;
                int j = cmdOrderID.ExecuteNonQuery();
                conn.Close();
            }

            dg1.DataSource = null;

            string sql1 = "select * from Тарифы";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Тарифы_Удалить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 100);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Код тарифа";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb0.Location.X + 200, lb0.Location.Y + lb0.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Удалить_Тарифы_Click);
            b4.Focus();
        }
        void Выполнить_Удалить_Тарифы_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";

            int i = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from Тарифы where Код_тарифа = @Код_тарифа";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_тарифа", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_тарифа"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            dg1.DataSource = null;
            string sql1 = "select * from Тарифы";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Услуги_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet uslugi = new DataSet();
            DataTable usl = uslugi.Tables.Add("Услуги");
            SqlCommand cm = new SqlCommand("SELECT * FROM Услуги", cn);
            SqlDataAdapter uslugiAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            uslugiAdapter.Fill(usl);
            dg1.DataSource = usl.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Услуги_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Услуги_Изменить_Click);

            b3 = new Button();
            b3.Text = "Удалить";
            b3.AutoSize = true;
            b3.Location = new Point(dg1.Location.X + 250, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b3);
            b3.Click += new EventHandler(Услуги_Удалить_Click);
        }
        void Услуги_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb1 = new Label();
            lb1.Text = "Наименование";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Описание";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(80, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Стоимость";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(40, 25);
            subpanel.Controls.Add(tb3);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb3.Location.X + 200, lb3.Location.Y + lb3.Height + 35);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_Услуги_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_Услуги_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Услуги (Наименование, Описание_услуги, Стоимость) values (@Наименование, @Описание_услуги, @Стоимость)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            decimal i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Описание_услуги", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Описание_услуги"].Value = tb2.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
            i = Convert.ToDecimal(tb3.Text);
            cmdOrderID.Parameters["@Стоимость"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from Услуги";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Услуги_Изменить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Введите страый код услуги";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "Наименование";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Описание";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(80, 20);
            subpanel.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Стоимость";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            subpanel.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb3);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb3.Location.X + 200, lb3.Location.Y + lb3.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Изменить_Услуги_Click);
            b4.Focus();
        }
        void Выполнить_Изменить_Услуги_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            if (tb2.Text == "")
            {
                conn.Open();
                string sql = "update Услуги set Наименование = @Наименование, Стоимость = @Стоимость where Код_услуги = @Код_услуги";
                SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                int i = 0;
                decimal ii = 0;
                cmdOrderID.Parameters.Add(new SqlParameter("@Код_услуги", SqlDbType.Int));
                i = Convert.ToInt32(tb0.Text);
                cmdOrderID.Parameters["@Код_услуги"].Value = tb0.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
                ii = Convert.ToDecimal(tb3.Text);
                cmdOrderID.Parameters["@Стоимость"].Value = ii;
                int j = cmdOrderID.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                conn.Open();
                string sql = "update Услуги set Наименование = @Наименование, Описание_услуги = @Описание_услуги, Стоимость = @Стоимость where Код_услуги = @Код_услуги";
                SqlCommand cmdOrderID = new SqlCommand(sql, conn);
                int i = 0;
                decimal ii = 0;
                cmdOrderID.Parameters.Add(new SqlParameter("@Код_услуги", SqlDbType.Int));
                i = Convert.ToInt32(tb0.Text);
                cmdOrderID.Parameters["@Код_услуги"].Value = tb0.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Наименование", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Наименование"].Value = tb1.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Описание_услуги", SqlDbType.NVarChar));
                cmdOrderID.Parameters["@Описание_услуги"].Value = tb2.Text;
                cmdOrderID.Parameters.Add(new SqlParameter("@Стоимость", SqlDbType.Decimal));
                ii = Convert.ToDecimal(tb3.Text);
                cmdOrderID.Parameters["@Стоимость"].Value = ii;
                int j = cmdOrderID.ExecuteNonQuery();
                conn.Close();
            }
            
            dg1.DataSource = null;

            string sql1 = "select * from Услуги";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Услуги_Удалить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 100);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Код услуги";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb0.Location.X + 200, lb0.Location.Y + lb0.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Удалить_Услуги_Click);
            b4.Focus();
        }
        void Выполнить_Удалить_Услуги_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";

            int i = 0;
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from Услуги where Код_услуги = @Код_услуги";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_услуги", SqlDbType.Int));
            i = Convert.ToInt32(tb0.Text);
            cmdOrderID.Parameters["@Код_услуги"].Value = i;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            dg1.DataSource = null;
            string sql1 = "select * from Услуги";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void УчетныеЗаписи_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet zapisi = new DataSet();
            DataTable zap = zapisi.Tables.Add("УчетныеЗаписи");
            SqlCommand cm = new SqlCommand("SELECT * FROM УчетныеЗаписи", cn);
            SqlDataAdapter zapisiAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            zapisiAdapter.Fill(zap);
            dg1.DataSource = zap.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(УчетныеЗаписи_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(УчетныеЗаписи_Изменить_Click);

            b3 = new Button();
            b3.Text = "Удалить";
            b3.AutoSize = true;
            b3.Location = new Point(dg1.Location.X + 250, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b3);
            b3.Click += new EventHandler(УчетныеЗаписи_Удалить_Click);
            //добавить таблицу учеток
            //сделать рид-онли
            // защитить от удаления учетку админа
        }
        void УчетныеЗаписи_Добавить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb1 = new Label();
            lb1.Text = "Логин";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Пароль";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb2.Location.X + 200, lb2.Location.Y + lb2.Height + 35);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Добавление_УчетныеЗаписи_Click);
            b4.Focus();
        }
        void Выполнить_Добавление_УчетныеЗаписи_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into УчетныеЗаписи (Логин, Пароль, ИД) values (@Логин, @Пароль, DEFAULT)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Логин", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Логин"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пароль", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Пароль"].Value = tb2.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from УчетныеЗаписи";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void УчетныеЗаписи_Изменить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 300);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Старый логин";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            lb1 = new Label();
            lb1.Text = "Новый логин";
            lb1.Location = new Point(lb0.Location.X, lb0.Location.Y + lb0.Height + 15);
            lb1.AutoSize = true;
            subpanel.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(200, 20);
            subpanel.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Новый пароль";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            subpanel.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb2);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb2.Location.X + 200, lb2.Location.Y + lb2.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Изменить_УчетныеЗаписи_Click);
            b4.Focus();
        }
        void Выполнить_Изменить_УчетныеЗаписи_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "update УчетныеЗаписи set Логин = @Логин, Пароль = @Пароль where Логин = @Старый_Логин";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Логин", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Логин"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Пароль", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Пароль"].Value = tb2.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Старый_Логин", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Старый_Логин"].Value = tb0.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;

            string sql1 = "select * from УчетныеЗаписи";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void УчетныеЗаписи_Удалить_Click(object sender, EventArgs e)
        {
            subpanel.Controls.Clear();
            subpanel.Location = new Point(0, b1.Location.Y + b1.Height + 15);
            subpanel.Size = new Size(this.Width, 100);
            panel.Controls.Add(subpanel);

            lb0 = new Label();
            lb0.Text = "Логин";
            lb0.Location = new Point(50, 40);
            lb0.AutoSize = true;
            subpanel.Controls.Add(lb0);

            tb0 = new TextBox();
            tb0.Location = new Point(lb0.Location.X + lb0.Width + 20, lb0.Location.Y - 2);
            tb0.Size = new System.Drawing.Size(40, 20);
            subpanel.Controls.Add(tb0);

            b4 = new Button();
            b4.Text = "Принять";
            b4.AutoSize = true;
            b4.Location = new Point(lb0.Location.X + 200, lb0.Location.Y + lb0.Height + 15);
            subpanel.Controls.Add(b4);
            b4.Click += new EventHandler(Выполнить_Удалить_УчетныеЗаписи_Click);
            b4.Focus();
        }
        void Выполнить_Удалить_УчетныеЗаписи_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from УчетныеЗаписи where Логин = @Логин";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            cmdOrderID.Parameters.Add(new SqlParameter("@Логин", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Логин"].Value = tb0.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            dg1.DataSource = null;
            string sql1 = "select * from УчетныеЗаписи";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
            subpanel.Controls.Clear();
        }
        void Архив_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet zapisi = new DataSet();
            DataTable zap = zapisi.Tables.Add("Архив");
            SqlCommand cm = new SqlCommand("SELECT * FROM Архив", cn);
            SqlDataAdapter zapisiAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            zapisiAdapter.Fill(zap);
            dg1.DataSource = zap.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Location = new Point(100, dg1.Location.Y + dg1.Size.Height + 50);
            b1.Text = "Удалить все";
            b1.AutoSize = true;
            b1.Click += Удалить_Архив_Click;
            panel.Controls.Add(b1);
        }
        void Удалить_Архив_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "delete from Архив";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();

            dg1.DataSource = null;
            string sql1 = "select * from Архив";
            SqlCommand cmdOrderID1 = new SqlCommand(sql1, conn);
            conn.Open();
            SqlDataReader rdr = cmdOrderID1.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(rdr);
            this.dg1.DataSource = dataTable;
            rdr.Close();
            conn.Close();
            menu.Focus();
        }
        void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
/*Вычисляемый столбец
             
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 197, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);

            dg1 = new DataGrid();
            dg1.Location = new Point(50, 25);
            dg1.Size = new System.Drawing.Size(600, 375);
            dg1.ReadOnly = true;//read-only
            dg1.RowHeadersVisible = false;
            panel.Controls.Add(dg1);

            string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection cn = new SqlConnection(connectionString);
            DataSet biblioteka = new DataSet();
            DataTable bibl = biblioteka.Tables.Add("Библиотека");
            SqlCommand cm = new SqlCommand("SELECT * FROM Библиотека", cn);
            DataColumn kod = bibl.Columns.Add("Код", typeof(Int32));
            DataColumn kod1 = bibl.Columns.Add("Код_библиотеки", typeof(Int32));
            kod.Expression = "Код_библиотеки*100";
            SqlDataAdapter biblAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            biblAdapter.Fill(bibl);
            dg1.DataSource = bibl.DefaultView;
            cn.Close();*/
