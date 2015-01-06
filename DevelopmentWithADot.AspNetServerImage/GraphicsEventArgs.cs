using System;
using System.Drawing;

namespace DevelopmentWithADot.AspNetServerImage
{
	[Serializable]
	public sealed class GraphicsEventArgs : EventArgs
	{
		public GraphicsEventArgs(Graphics g)
		{
			this.Graphics = g;
		}

		public Graphics Graphics { get; private set; }
	}
}
