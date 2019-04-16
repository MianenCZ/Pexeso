using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pexeso
{
	partial class Game : Panel
	{
		private Card[] Desk;
		private List<Card> OnDesk;
		private Controler MainContorler;
		public readonly int Rows;
		public readonly int Columns;


		public Game(int Rows, int Columns)
		{
			this.Rows = Rows;
			this.Columns = Columns;

			Desk = new Card[this.Columns * this.Rows];
			for (int i = 0; i < this.Columns * this.Rows; i++)
			{
				Desk[i] = new Card(i / 2);
				OnDesk.Add(Desk[i]);
			}
			this.BackColor = Color.Black;
			this.MainContorler = new Controler(2);
			MainContorler.Lock += MainContorlerLock;
			MainContorler.UnLock += MainContorlerUnLock;
			MainContorler.Remove += MainContorler_RemoveCard;
		}

		private void MainContorler_RemoveCard(Card ToRemove)
		{
			this.Controls.Remove(ToRemove);
			OnDesk.Remove(ToRemove);
		}

		private void MainContorlerUnLock()
		{
			this.Enabled = true;
		}

		private void MainContorlerLock()
		{
			this.Enabled = false;
		}

		public void Init()
		{
			MixCard();
			for (int i = 0; i < Rows; i++)
			{
				for (int j = 0; j < Columns; j++)
				{
					Desk[i * Rows + j].Size = new Size(100,100);
					int X = 10 + (Desk[i * Rows + j].Width + 5) * j;
					int Y = 10 + (Desk[i * Rows + j].Height + 5) * i;
					Desk[i * Rows + j].Location = new Point(X, Y);
					this.Controls.Add(Desk[i * Rows + j]);
					Desk[i * Rows + j].ShowBack();

					Desk[i * Rows + j].CardClick += Game_CardClick;
				}
			}
		}


		private void Game_CardClick(Card sender)
		{
			MainContorler.Add(sender);
		}

		public void Clear()
		{
			for (int i = 0; i < Rows*Columns; i++)
			{
				this.Controls.Remove(Desk[i]);
			}
		}
		
		private void MixCard()
		{
			Random rnd = new Random();
			Desk = Desk.OrderBy(x => rnd.NextDouble()).ToArray();
		}
	}
}
