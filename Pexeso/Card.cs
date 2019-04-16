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
	/// <summary>
	/// Card of pexeso game
	/// </summary>
	public class Card : PictureBox
	{
		public int PairID { get; private set; }
		public ActualCard ActualSide { get; private set; }


		public delegate void CardInfo(Card sender);

		public event CardInfo CardClick = delegate { };
	

		private Image Back;
		private Image Face;



		private static string BackPath = $@"{Environment.CurrentDirectory}\Pictures\Back.jpg";

		public Card(int PairID)
		{
			this.PairID = PairID;
			this.Back = Image.FromFile(Card.BackPath);
			this.Face = Image.FromFile($@"{Environment.CurrentDirectory}\Pictures\obr{PairID}.jpg");
			this.SizeMode = PictureBoxSizeMode.StretchImage;
			this.MouseClick += Card_MouseClick;
		}
		public void ShowFace()
		{
			this.Image = Face;
			this.ActualSide = ActualCard.Face;
		}

		public void ShowBack()
		{
			this.Image = Back;
			this.ActualSide = ActualCard.Back;
		}

		private void Card_MouseClick(object sender, MouseEventArgs e)
		{
			CardClick(this);
		}

		public enum ActualCard
		{
			Back,
			Face
		}
	}
}
