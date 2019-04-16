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
	/// Is here to secure rules of pexeso game
	/// </summary>
	class Controler
	{
		public readonly int BufferSize;

		public delegate void LockInfo();
		public delegate void RemoveInfo(Card ToRemove);

		public event LockInfo Lock = delegate { };
		public event LockInfo UnLock = delegate { };
		public event RemoveInfo Remove = delegate { };

		private List<Card> Buffer;
		private Timer Clock;
		
		/// <summary>
		/// Create a Controler
		/// </summary>
		/// <param name="BufferSize">Maximal count of Card in Buffer</param>
		public Controler(int BufferSize)
		{
			this.BufferSize = BufferSize;
			this.Buffer = new List<Card>();

		}

		public void Add(Card next)
		{
			this.Buffer.Add(next);
			next.ShowFace();
			next.Enabled = false;

			if (Buffer.Count == BufferSize)
			{
				this.Lock();
				this.Clock = new Timer()
				{
					Interval = 500,
				};
				Clock.Tick += ToClose;
				Clock.Start();
			}
		}

		public void ToClose(object sender, EventArgs e)
		{
			if (Buffer[0].PairID == Buffer[1].PairID)
			{
				Remove(Buffer[0]);
				Remove(Buffer[1]);
			}
			else
			{

				Buffer[0].Enabled = true;
				Buffer[0].ShowBack();
				Buffer[1].Enabled = true;
				Buffer[1].ShowBack();
			}
			Buffer.Clear();
			
			this.Clock.Stop();
			this.Clock = null;
			this.UnLock();
		}

	}
}
