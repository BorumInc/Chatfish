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
	public class ContactLabel : Label
	{
		private static int count = 0;
		public ContactLabel(string contactName) : base()
		{
			// Set border to none
			this.BorderStyle = BorderStyle.FixedSingle;
			// Use the second image in imageList1.
			this.ImageIndex = 1;
			// Align the image to the top left corner.
			this.ImageAlign = ContentAlignment.TopLeft;

			// Specify that the text can display mnemonic characters.
			this.UseMnemonic = true;
			// Set the text of the control and specify a mnemonic character.
			this.Text = contactName;

			/* Set the size of the control based on the PreferredHeight and PreferredWidth values. */
			int height = 200;
			int margin = 10;
			base.Size = new Size (height, 40);
			base.TextAlign = ContentAlignment.TopCenter;
			base.Location = new Point(margin + (count * height), margin);
			base.Font = new Font(this.Font.FontFamily, 16);

			count++;
		}
	}
}
