using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
	public partial class Form1 : Form
	{
		private Game G;
		public Form1()
		{
			InitializeComponent();

			this.Size = new Size(800, 1000);

			G = new Game(6, 6)
			{
				Size = new Size(800,800),
			};
			this.Controls.Add(G);
			G.Init();

		}

		private void FormClick(object sender, MouseEventArgs e)
		{
			G.Clear();
			G.Init();
		}
	}
}
