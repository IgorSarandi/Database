using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sql
{
    public partial class Form1 : Form
    {
        Label loglab = new Label();
        Label passlab = new Label();
        TextBox logtext = new TextBox();
        TextBox passtext = new TextBox();
        Button butload = new Button();
        //public bool k1 = false;?????
        public bool b = false;
        public bool a = false;
        public Form1()
        {
            InitializeComponent();
            FormLoad fl = new FormLoad();
            fl.ShowDialog();
            this.Text = "Вход";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(640, 360);
            int x = (this.Width - loglab.Width) / 3;
            int y = (this.Height - loglab.Height) / 5;
            loglab.Text = "Введите логин";
            loglab.AutoSize = true;
            loglab.Location = new Point(x, y);
            y += logtext.Height;
            logtext.AutoSize = true;
            logtext.Location = new Point(x, y);
            y += 2 * passlab.Height;
            passlab.Text = "Введите пароль";
            passlab.AutoSize = true;
            passlab.Location = new Point(x, y);
            y += passtext.Height;
            passtext.AutoSize = true;
            passtext.Location = new Point(x, y);
            passtext.PasswordChar = '*';
            y += 2 * passtext.Height;
            butload.Text = "Вход";
            butload.AutoSize = true;
            //butload.CanFocus
            //butload.CanSelect = true;
            butload.Location = new Point(x, y);
            butload.Click += butload_Click;
            this.Controls.Add(loglab);
            this.Controls.Add(logtext);
            this.Controls.Add(passlab);
            this.Controls.Add(passtext);
            this.Controls.Add(butload);
        }
        
//        private void logtext_KeyUp(object sender, KeyEventArgs e)

        void butload_Click(object sender, EventArgs e)
        {
            /*string connectionString = @"Data Source=.\COMPUTER;
 Initial Catalog=Таксопарк;Integrated Security=True";*/
            string connectionString = @"Server=COMPUTER;Database=Таксопарк;Integrated Security=True;Asynchronous Processing = True;";
            // Создание подключения
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            Person p = new Person();
            command = connection.CreateCommand();
            command.CommandText = CommandType.Text.ToString();
            connection.Open();
            MessageBox.Show("подключено", "Состояние");
            command.CommandText = "SELECT Логин, Пароль, ИД FROM УчетныеЗаписи";
            command.Connection = connection;
            SqlDataReader reader1 = command.ExecuteReader();
            if (reader1.HasRows) // если есть данные
            {
                reader1.Close();
                SqlCommand command1 = new SqlCommand("SELECT Count(*) As Логин FROM УчетныеЗаписи", connection);
                uint Z = Convert.ToUInt32(command1.ExecuteScalar());
                command.CommandType = CommandType.Text;
                SqlDataReader reader2 = command.ExecuteReader();
                while (reader2.Read())
                {
                    p.login = reader2["Логин"].ToString();
                    p.password = reader2["Пароль"].ToString();
                    p.id = reader2["ИД"].ToString();
                    if (logtext.Text == p.login && passtext.Text == p.password)
                    {
                        b = true;
                        if (p.id == "True")//замененить на нужный индекс int
                        {
                            a = true;// тоже самое
                        }
                    }
                    else
                        Z -= 1;
                }
                reader2.Close();
                if (Z == 0)
                {
                    MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (b)
                {
                    if (a)// = int admina
                    {
                        Form2 fr2 = new Form2();
                        fr2.Show();
                        this.Hide();
                    }
                    else // if (a = int 1 sotrudnika i tak dalee
                    {
                        Form3 fr3 = new Form3();
                        fr3.Show();
                        this.Hide();
                    }
                }
            }
        }
    }
    class Person
    {
        public string login;
        public string password;
        public string id;
    }
	class FormLoad : Form
    {
        Timer tmr = new Timer() { Interval = 1000 };
        public FormLoad()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Image myimage = new Bitmap(@"1.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.BackgroundImage = myimage;
            tmr.Tick += tmr_Tick;
            tmr.Start();
        }
        void tmr_Tick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
