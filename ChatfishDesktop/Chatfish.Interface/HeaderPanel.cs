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
    public class HeaderPanel : Panel
    {
			public HeaderPanel() : base()
			{
				this.Size = new Size(1300, 60);
				this.Location = new Point(35, 10);
				this.BorderStyle = BorderStyle.FixedSingle;
			}
    }
}
