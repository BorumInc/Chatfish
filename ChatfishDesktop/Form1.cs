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
        string ph = "Enter your message";

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
            msgInput.Size = new Size(700, 75);
            msgInput.Font = new Font(msgInput.Font.FontFamily, 16);
            msgInput.Multiline = true;
            msgInput.GotFocus += RemoveText;
            msgInput.LostFocus += AddText;
            msgInput.KeyDown += msgInput_KeyDown;
            msgInput.KeyPress += msgInput_KeyPress;
            msgInput.Text = ph;
            this.Controls.Add(msgInput);

            Button newFish = new Button();
            newFish.Location = new Point(100, 530);
            newFish.Text = "New Fish";
            newFish.Size = new Size(200, 60);
            this.Controls.Add(newFish);

            String[] contactNames = new String[] {"Varun Singh", "Manav Singh", "Peter Peterson", "John Johnson"};
            Panel p = new Panel();
            p.Location = new Point(35, 80);
            p.Size = new Size(ClientRectangle.Width + 500, 60);
            p.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 0; i < 10; i++)
              p.Controls.Add(new ContactLabel(contactNames[i % 4]));
            this.Controls.Add(p);

            Panel chatList = new Panel();
            chatList.Location = new Point(35, 80);
            chatList.Size = new Size(ClientRectangle.Width + 500, 60);
            chatList.BorderStyle = BorderStyle.FixedSingle;
            for (int i = 0; i < 10; i++)
              chatList.Controls.Add(new Button());
            this.Controls.Add(chatList);

            Panel btnsPanel = new Panel();
            btnsPanel.Location = new Point(35, 10);
            btnsPanel.Size = new Size(ClientRectangle.Width + 500, 60);
            btnsPanel.BorderStyle = BorderStyle.FixedSingle;

            Button contactsBtn = new HeaderButton("Contacts", p);
            btnsPanel.Controls.Add(contactsBtn);

            Button chatsBtn = new HeaderButton("Fish", p);
            btnsPanel.Controls.Add(chatsBtn);

            this.Controls.Add(btnsPanel);

            this.ResumeLayout(false);
            this.PerformLayout();
            //StartConnection();
        }

        public void StartConnection()
        {
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

        public void RemoveText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            myTxtbx.ForeColor = Color.Black;
            if (myTxtbx.Text == ph)
                myTxtbx.Text = "";
        }

        public void AddText(object sender, EventArgs e)
        {
            TextBox myTxtbx = sender as TextBox;
            if (String.IsNullOrWhiteSpace(myTxtbx.Text))
            {
                myTxtbx.ForeColor = Color.Gray;
                myTxtbx.Text = ph;
            }
        }

        // Boolean flag used to determine when a character other than a number is entered.
        private bool enterEntered = false;

        public void msgInput_KeyDown(object sender, KeyEventArgs e)
        {
          // Initialize the flag to false.
          enterEntered = false;
          if (e.KeyCode == Keys.Enter && Control.ModifierKeys != Keys.Shift)
          {
            enterEntered = true;
          }

        }

        // This event occurs after the KeyDown event and can be used to prevent
        // characters from entering the control.
        private void msgInput_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (enterEntered == true)
            {
                e.Handled = true;
                ((TextBox) sender).Text = "";
            }
        }

        private void f1_paint(object sender, PaintEventArgs e)
        {
          Graphics g = e.Graphics;
          int messageBoxX = 650;
          int messageBoxY = 530;
          Font myFont = new Font("Verdana", 16);
          g.DrawString("~", myFont, new SolidBrush(Color.Black), 40, 40);
          g.DrawEllipse(new Pen(Color.Black, 3), new Rectangle(40, 40, 40, 40));
          g.DrawLine(new Pen(Color.Black, 3), 0, 150, ClientRectangle.Width, 150);
          g.DrawEllipse(new Pen(Color.Black, 3), new Rectangle(messageBoxX + 600, messageBoxY + 10, 50, 50));
        }
    }
}
