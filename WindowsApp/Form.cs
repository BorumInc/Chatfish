using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;

public class FirstForm : Form
{
  private Container components;
  private Label   howdyLabel;
	private Form form1 = new Form();

  public FirstForm()
  {
    InitializeComponent();
  }

  private void InitializeComponent()
  {
    components = new Container ();
    howdyLabel = new Label ();

    howdyLabel.Location = new Point (12, 116);
    howdyLabel.Text   = "Howdy, Partner!";
    howdyLabel.Size   = new Size (267, 40);
    howdyLabel.AutoSize = true;
    howdyLabel.Font   = new Font (
      "Microsoft Sans Serif",
      26, System.
      Drawing.FontStyle.Bold);
    howdyLabel.TabIndex = 0;
    howdyLabel.Anchor  = AnchorStyles.None;
    howdyLabel.TextAlign = ContentAlignment.MiddleCenter;

    Text = "First Form";
    Controls.Add (howdyLabel);
  }

	public void CreateMyForm()
	{
	   // Create two buttons to use as the accept and cancel buttons.
	   Button button1 = new Button ();
	   Button button2 = new Button ();

	   // Set the text of button1 to "OK".
	   button1.Text = "OK";
	   // Set the position of the button on the form.
	   button1.Location = new Point (10, 10);
		 //
		 button1.Click += button1_Click;
	   // Set the text of button2 to "Cancel".
	   button2.Text = "Cancel";
	   // Set the position of the button based on the location of button1.
	   button2.Location
	      = new Point (button1.Left, button1.Height + button1.Top + 10);
	   // Set the caption bar text of the form.
	   form1.Text = "My Dialog Box";
	   // Display a help button on the form.
	   form1.HelpButton = true;

	   // Define the border style of the form to a dialog box.
	   form1.FormBorderStyle = FormBorderStyle.FixedDialog;
	   // Set the MaximizeBox to false to remove the maximize box.
	   form1.MaximizeBox = false;
	   // Set the MinimizeBox to false to remove the minimize box.
	   form1.MinimizeBox = false;
	   // Set the accept button of the form to button1.
	   form1.AcceptButton = button1;
	   // Set the cancel button of the form to button2.
	   form1.CancelButton = button2;
	   // Set the start position of the form to the center of the screen.
	   form1.StartPosition = FormStartPosition.CenterScreen;

	   // Add button1 to the form.
	   form1.Controls.Add(button1);
	   // Add button2 to the form.
	   form1.Controls.Add(button2);

	   // Display the form as a modal dialog box.
	   form1.ShowDialog();
	}

	private void button1_Click(object sender, EventArgs e)
	{
	    Console.WriteLine("Button 1 was clicked!");
	}

  public static void Main()
  {
		new FirstForm().CreateMyForm();
    Application.Run(new FirstForm());
  }
}
