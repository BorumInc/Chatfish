using System;
using System.Windows.Forms;
using System.Drawing;
namespace Chatfish {
	public class Hello : Form {
		    public Hello() {
		        this.Paint += new PaintEventHandler(f1_paint);
		    }
		    private void f1_paint(object sender, PaintEventArgs e) {
		        Graphics g = e.Graphics;
						int x = 650;
						int y = 520;
		        g.DrawString("Enter your message here", new Font("Verdana", 20), new SolidBrush(Color.Tomato), x, y);
		        g.DrawRectangle(new Pen(Color.Pink, 3), x, y, 700, 75);
						g.DrawLine(new Pen(Color.Black, 3), 300, 0, 300, 800);
		    }
		    public static void Main() {
		        Application.Run(new Hello());
		    }
		    // End of class
		}
}
