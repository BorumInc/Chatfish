using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatfishDesktop
{
	public class HeaderButton : Button
	{
		private Panel panel;

		private static int count = 0;

		public HeaderButton(string text, Panel panel) : base()
		{
			this.Text = text;
			int bWidth = 300;
			this.Location = new Point(10 + bWidth * count, 10);
			this.Size = new Size(bWidth, 40);
			this.Click += showPanel;
			this.panel = panel;
			count++;
		}

		private void showPanel(object sender, EventArgs e)
		{
			if (panel.Visible)
				panel.Hide();
			else
				panel.Show();
		}
	}
}
