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
    public partial class Form3 : Form
    {
        //Вход для юзеров
        Panel panel = new Panel();
        MenuStrip menu = new MenuStrip();
        ToolStripMenuItem Вызовы = new ToolStripMenuItem("Вызовы");
        ToolStripMenuItem Автомобили = new ToolStripMenuItem("Автомобили");
        ToolStripMenuItem Тарифы_и_услуги = new ToolStripMenuItem("Тарифы и услуги");
        ToolStripMenuItem Тарифы = new ToolStripMenuItem("Тарифы");
        ToolStripMenuItem Услуги = new ToolStripMenuItem("Услуги");
        ToolStripLabel dateLabel = new ToolStripLabel();
        ToolStripLabel timeLabel = new ToolStripLabel();
        ToolStripLabel infoLabel1 = new ToolStripLabel() { Text = "Текущие дата и время:" };
        ToolStripLabel infoLabel2 = new ToolStripLabel() { Text = "         Уровень доступа: Пользователь" };
        StatusStrip statusStrip = new StatusStrip();
        DataGrid dg1;
        Form form;
        Button b1;
        Button b2;
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
        Timer timer = new Timer() { Interval = 1000 };
        Button exit = new Button()
        {
            Text = "Выход",
            AutoSize = true
        };

        public Form3()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            panel.AutoSize = true;
            panel.Location = new Point(0, 30);
            panel.Size = new Size(this.Width, this.Height - 60);
            Вызовы.Click += new EventHandler(Вызовы_Click);
            Автомобили.Click += new EventHandler(Автомобили_Click);
            Тарифы.Click += new EventHandler(Тарифы_Click);
            Услуги.Click += new EventHandler(Услуги_Click);
            this.Controls.Add(panel);
            this.Controls.Add(menu);
            menu.Focus();
            menu.Items.Add(Вызовы);
            menu.Items.Add(Автомобили);
            menu.Items.Add(Тарифы_и_услуги);
            Тарифы_и_услуги.DropDownItems.Add(Тарифы);
            Тарифы_и_услуги.DropDownItems.Add(Услуги);
            exit.Location = new Point(this.Width - 180, this.Height - 100);
            exit.Click += new EventHandler(exit_Click);
            panel.Controls.Add(exit);
            statusStrip.Items.Add(infoLabel1);
            statusStrip.Items.Add(dateLabel);
            statusStrip.Items.Add(timeLabel);
            statusStrip.Items.Add(infoLabel2);
            this.Controls.Add(statusStrip);
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
            //поле время и дата система добавит сама
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 180, this.Height - 100);
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
            DataSet visovi = new DataSet();
            DataTable vis = visovi.Tables.Add("Вызовы");
            SqlCommand cm = new SqlCommand("SELECT * FROM Вызовы", cn);
            SqlDataAdapter visovAdapter = new SqlDataAdapter(cm);
            try
            {
                cn.Open();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            visovAdapter.Fill(vis);
            dg1.DataSource = vis.DefaultView;
            cn.Close();

            b1 = new Button();
            b1.Text = "Добавить";
            b1.AutoSize = true;
            b1.Location = new Point(dg1.Location.X + 50, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b1);
            b1.Click += new EventHandler(Вызовы_Добавить_Click);

            b2 = new Button();
            b2.Text = "Изменить";
            b2.AutoSize = true;
            b2.Location = new Point(dg1.Location.X + 150, dg1.Location.Y + dg1.Height + 8);
            panel.Controls.Add(b2);
            b2.Click += new EventHandler(Вызовы_Изменить_Click);
        }
        void Вызовы_Добавить_Click(object sender, EventArgs e)
        {
            form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.AutoScroll = true;
            form.Size = new System.Drawing.Size(640, 480);
            form.ShowInTaskbar = false;
            form.Show();

            lb1 = new Label();
            lb1.Text = "Телефон";
            lb1.Location = new Point(50, 40);
            lb1.AutoSize = true;
            form.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(80, 20);
            form.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Откуда";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            form.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Куда";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            form.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Код тарифа";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            form.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Код услуги";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            form.Controls.Add(lb5);

            tb5 = new TextBox();
            tb5.Location = new Point(lb5.Location.X + lb5.Width + 20, lb5.Location.Y - 2);
            tb5.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb5);

            lb6 = new Label();
            lb6.Text = "Код машины";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            form.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb6);

            lb7 = new Label();
            lb7.Text = "Код оператора";
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

            lb9 = new Label();
            lb9.Text = "Отзыв";
            lb9.Location = new Point(lb8.Location.X, lb8.Location.Y + lb8.Height + 15);
            lb9.AutoSize = true;
            form.Controls.Add(lb9);

            tb9 = new TextBox();
            tb9.Location = new Point(lb9.Location.X + lb9.Width + 20, lb9.Location.Y - 2);
            tb9.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb9);

            b1 = new Button();
            b1.Text = "Принять";
            b1.AutoSize = true;
            b1.Location = new Point(lb8.Location.X + 200, lb8.Location.Y + lb8.Height + 35);
            form.Controls.Add(b1);
            b1.Click += new EventHandler(Выполнить_Добавление_Вызовы_Click);
            b1.Focus();
        }
        void Выполнить_Добавление_Вызовы_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "insert into Вызовы (Дата, Время, Телефон, Откуда, Куда, Код_тарифа, Код_услуги, Код_автомобиля, Код_сотрудника_оператора, Состояние_услуги, Отзыв) values (@Дата, @Время, @Телефон, @Откуда, @Куда, @Код_тарифа, @Код_услуги, @Код_автомобиля, @Код_сотрудника_оператора, @Состояние_услуги, @Отзыв)";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
            cmdOrderID.Parameters["@Дата"].Value = dateLabel.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Время", SqlDbType.Time));
            cmdOrderID.Parameters["@Время"].Value = timeLabel.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Телефон", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Телефон"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Откуда", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Откуда"].Value = tb2.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Куда", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Куда"].Value = tb3.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_тарифа", SqlDbType.Int));
            i = Convert.ToInt32(tb4.Text);
            cmdOrderID.Parameters["@Код_тарифа"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_услуги", SqlDbType.Int));
            i = Convert.ToInt32(tb5.Text);
            cmdOrderID.Parameters["@Код_услуги"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_автомобиля", SqlDbType.Int));
            i = Convert.ToInt32(tb6.Text);
            cmdOrderID.Parameters["@Код_автомобиля"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника_оператора", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Код_сотрудника_оператора"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Состояние_услуги", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Состояние_услуги"].Value = tb8.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Отзыв", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Отзыв"].Value = tb9.Text;

            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;
            form.Close();

            string sql1 = "SELECT * FROM Вызовы";
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
        void Вызовы_Изменить_Click(object sender, EventArgs e)
        {
            form = new Form();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.BackColor = Color.White;
            form.AutoScroll = true;
            form.Size = new System.Drawing.Size(640, 480);
            form.ShowInTaskbar = false;
            form.Show();

            lb10 = new Label();
            lb10.Text = "Введите старую дату";
            lb10.Location = new Point(50, 40);
            lb10.AutoSize = true;
            form.Controls.Add(lb10);

            tb10 = new TextBox();
            tb10.Location = new Point(lb10.Location.X + lb10.Width + 20, lb10.Location.Y - 2);
            tb10.Size = new System.Drawing.Size(80, 20);
            form.Controls.Add(tb10);

            lb11 = new Label();
            lb11.Text = "Введите старое время";
            lb11.Location = new Point(lb10.Location.X, lb10.Location.Y + lb10.Height + 15);
            lb11.AutoSize = true;
            form.Controls.Add(lb11);

            tb11 = new TextBox();
            tb11.Location = new Point(lb11.Location.X + lb11.Width + 20, lb11.Location.Y - 2);
            tb11.Size = new System.Drawing.Size(80, 20);
            form.Controls.Add(tb11);

            lb1 = new Label();
            lb1.Text = "Телефон";
            lb1.Location = new Point(lb11.Location.X, lb11.Location.Y + lb11.Height + 15);
            lb1.AutoSize = true;
            form.Controls.Add(lb1);

            tb1 = new TextBox();
            tb1.Location = new Point(lb1.Location.X + lb1.Width + 20, lb1.Location.Y - 2);
            tb1.Size = new System.Drawing.Size(80, 20);
            form.Controls.Add(tb1);

            lb2 = new Label();
            lb2.Text = "Откуда";
            lb2.Location = new Point(lb1.Location.X, lb1.Location.Y + lb1.Height + 15);
            lb2.AutoSize = true;
            form.Controls.Add(lb2);

            tb2 = new TextBox();
            tb2.Location = new Point(lb2.Location.X + lb2.Width + 20, lb2.Location.Y - 2);
            tb2.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb2);

            lb3 = new Label();
            lb3.Text = "Куда";
            lb3.Location = new Point(lb2.Location.X, lb2.Location.Y + lb2.Height + 15);
            lb3.AutoSize = true;
            form.Controls.Add(lb3);

            tb3 = new TextBox();
            tb3.Location = new Point(lb3.Location.X + lb3.Width + 20, lb3.Location.Y - 2);
            tb3.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb3);

            lb4 = new Label();
            lb4.Text = "Код тарифа";
            lb4.Location = new Point(lb3.Location.X, lb3.Location.Y + lb3.Height + 15);
            lb4.AutoSize = true;
            form.Controls.Add(lb4);

            tb4 = new TextBox();
            tb4.Location = new Point(lb4.Location.X + lb4.Width + 20, lb4.Location.Y - 2);
            tb4.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb4);

            lb5 = new Label();
            lb5.Text = "Код услуги";
            lb5.Location = new Point(lb4.Location.X, lb4.Location.Y + lb4.Height + 15);
            lb5.AutoSize = true;
            form.Controls.Add(lb5);

            tb5 = new TextBox();
            tb5.Location = new Point(lb5.Location.X + lb5.Width + 20, lb5.Location.Y - 2);
            tb5.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb5);

            lb6 = new Label();
            lb6.Text = "Код машины";
            lb6.Location = new Point(lb5.Location.X, lb5.Location.Y + lb5.Height + 15);
            lb6.AutoSize = true;
            form.Controls.Add(lb6);

            tb6 = new TextBox();
            tb6.Location = new Point(lb6.Location.X + lb6.Width + 20, lb6.Location.Y - 2);
            tb6.Size = new System.Drawing.Size(40, 20);
            form.Controls.Add(tb6);

            lb7 = new Label();
            lb7.Text = "Код оператора";
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

            lb9 = new Label();
            lb9.Text = "Отзыв";
            lb9.Location = new Point(lb8.Location.X, lb8.Location.Y + lb8.Height + 15);
            lb9.AutoSize = true;
            form.Controls.Add(lb9);

            tb9 = new TextBox();
            tb9.Location = new Point(lb9.Location.X + lb9.Width + 20, lb9.Location.Y - 2);
            tb9.Size = new System.Drawing.Size(200, 20);
            form.Controls.Add(tb9);

            b1 = new Button();
            b1.Text = "Принять";
            b1.AutoSize = true;
            b1.Location = new Point(lb8.Location.X + 200, lb8.Location.Y + lb8.Height + 35);
            form.Controls.Add(b1);
            b1.Click += new EventHandler(Выполнить_Изменение_Вызовы_Click);
            b1.Focus();
        }
        void Выполнить_Изменение_Вызовы_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();
            string sql = "update Вызовы set Телефон = @Телефон, Откуда = @Откуда, Куда = @Куда, Код_тарифа = @Код_тарифа, Код_услуги = @Код_услуги, Код_автомобиля = @Код_автомобиля, Код_сотрудника_оператора = @Код_сотрудника_оператора, Состояние_услуги = @Состояние_услуги, Отзыв = @Отзыв where Дата = @Дата and Время = @Время";
            SqlCommand cmdOrderID = new SqlCommand(sql, conn);
            int i = 0;
            cmdOrderID.Parameters.Add(new SqlParameter("@Дата", SqlDbType.Date));
            cmdOrderID.Parameters["@Дата"].Value = tb10.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Время", SqlDbType.Time));
            cmdOrderID.Parameters["@Время"].Value = tb11.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Телефон", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Телефон"].Value = tb1.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Откуда", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Откуда"].Value = tb2.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Куда", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Куда"].Value = tb3.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_тарифа", SqlDbType.Int));
            i = Convert.ToInt32(tb4.Text);
            cmdOrderID.Parameters["@Код_тарифа"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_услуги", SqlDbType.Int));
            i = Convert.ToInt32(tb5.Text);
            cmdOrderID.Parameters["@Код_услуги"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_автомобиля", SqlDbType.Int));
            i = Convert.ToInt32(tb6.Text);
            cmdOrderID.Parameters["@Код_автомобиля"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Код_сотрудника_оператора", SqlDbType.Int));
            i = Convert.ToInt32(tb7.Text);
            cmdOrderID.Parameters["@Код_сотрудника_оператора"].Value = i;
            cmdOrderID.Parameters.Add(new SqlParameter("@Состояние_услуги", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Состояние_услуги"].Value = tb8.Text;
            cmdOrderID.Parameters.Add(new SqlParameter("@Отзыв", SqlDbType.NVarChar));
            cmdOrderID.Parameters["@Отзыв"].Value = tb9.Text;
            int j = cmdOrderID.ExecuteNonQuery();
            conn.Close();
            dg1.DataSource = null;
            form.Close();

            string sql1 = "select * from Вызовы";
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
        void Автомобили_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 180, this.Height - 100);
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
        }
        void Тарифы_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 180, this.Height - 100);
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
        }
        void Услуги_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            menu.Focus();
            exit.Location = new Point(this.Width - 180, this.Height - 100);
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
        }
        void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
