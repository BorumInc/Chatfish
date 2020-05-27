using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChatfishDesktop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WriteLine("Component initializing...PaintHandler painting...");
            InitializeComponent();
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(f1_paint);
            TextBox msgInput = new TextBox();
            msgInput.Location = new Point(650, 530);
            this.Controls.Add(msgInput);
            this.ResumeLayout(false);
            this.PerformLayout();
            //StartConnection();
        }

        public void StartConnection()
        {
          String world = "world";
          Console.WriteLine($"Hello {world}!");
          String server = "160.153.59.192";
          String database = "Chatfish";
          String uid = "libuc6kfb0jg";
          String password = "LearnPhp@@@1";
          String connectionString;
          connectionString = "SERVER=" + server + ";" + "DATABASE=" +
          database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
          using (MySqlConnection connection = new MySqlConnection(
               connectionString))
          {
            MySqlCommand command = new MySqlCommand("SELECT * FROM messages", connection);
            command.Connection.Open();
            Console.WriteLine($"Connection connected to {database}");
            MySqlDataReader myReader = command.ExecuteReader();
            try
            {
              while (myReader.Read())
              {
                Console.WriteLine(myReader.GetString(1));
              }
            }
            finally
            {
              myReader.Close();
              connection.Close();
            }
          }
        }

        private void f1_paint(object sender, PaintEventArgs e)
        {
          Graphics g = e.Graphics;
          int messageBoxX = 650;
          int messageBoxY = 530;
          Font myFont = new Font("Verdana", 16);
          g.DrawString("Contacts", myFont, new SolidBrush(Color.Black), 40, 40);
          g.DrawString("Enter your message here", myFont, new SolidBrush(Color.Tomato), messageBoxX, messageBoxY);
          g.DrawRectangle(new Pen(Color.Gray, 3), messageBoxX, messageBoxY, 700, 75);
          g.DrawLine(new Pen(Color.Black, 3), 300, 0, 300, 800);
          g.DrawEllipse(new Pen(Color.Black, 3), new Rectangle(messageBoxX + 600, messageBoxY + 10, 50, 50));
        }
    }
}
