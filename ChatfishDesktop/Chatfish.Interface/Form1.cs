﻿using System;
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
        private Label lastMessage;

        public Form1()
        {
            Console.WriteLine("Component initializing...PaintHandler painting...");
            InitializeComponent();
            int height = Screen.PrimaryScreen.Bounds.Height;
            int width = Screen.PrimaryScreen.Bounds.Width;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Paint += new PaintEventHandler(f1_paint);
            int msgX = 650;

            TextBox msgInput = new TextBox();

            Font myFont = new Font(msgInput.Font.FontFamily, 16);
            Size msgBoxSize = new Size(700, 75);

            msgInput.Location = new Point(msgX, 530);
            msgInput.Size = msgBoxSize;
            msgInput.Font = myFont;
            msgInput.Multiline = true;
            msgInput.GotFocus += RemoveText;
            msgInput.LostFocus += AddText;
            msgInput.KeyDown += msgInput_KeyDown;
            msgInput.KeyPress += msgInput_KeyPress;
            msgInput.Text = ph;
            this.Controls.Add(msgInput);

            lastMessage = new Label();
            lastMessage.Location = new Point(msgX, 430);
            lastMessage.Size = msgBoxSize;
            lastMessage.Text = "This label has the last message";
            lastMessage.Font = myFont;

            this.Controls.Add(lastMessage);

            Button newFish = new Button();
            newFish.Location = new Point(100, 530);
            newFish.Text = "New Fish";
            newFish.Size = new Size(200, 60);
            this.Controls.Add(newFish);

            HeaderPanel btnsPanel = new HeaderPanel();

            CreateContacts(btnsPanel);
            CreateFish(btnsPanel);

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

        public void CreateFish(Panel btnsPanel)
        {
          Panel chatList = new SystemPanel();
          for (int i = 0; i < 10; i++) {
            Label chat = new Label();
            chat.Text = "Hello";
            chatList.Controls.Add(chat);
          }

          // Create button that shows/hides chats and display it
          Button chatsBtn = new HeaderButton("Fish", chatList);
          btnsPanel.Controls.Add(chatsBtn);
          this.Controls.Add(chatList);
        }

        public void CreateContacts(Panel btnsPanel)
        {
          Panel contactsPanel = new SystemPanel();
          // Initialize list of contacts
          String[] contactNames = new String[] {"Varun Singh", "Manav Singh", "Peter Peterson", "John Johnson"};

          // Add contact labels to contacts container
          for (int i = 0; i < 10; i++)
            contactsPanel.Controls.Add(new ContactLabel(contactNames[i % 4]));

          // Create button that shows/hides contacts and display it
          Button contactsBtn = new HeaderButton("Contacts", contactsPanel);
          btnsPanel.Controls.Add(contactsBtn);
          this.Controls.Add(contactsPanel);
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
                lastMessage.Text = ((TextBox) sender).Text;
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