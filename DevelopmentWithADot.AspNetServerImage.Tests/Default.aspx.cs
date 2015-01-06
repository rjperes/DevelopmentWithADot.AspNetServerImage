using System;
using System.Drawing;
using System.Web.UI;

namespace DevelopmentWithADot.AspNetServerImage.Tests
{
	public partial class Default : Page
	{
		protected void OnDraw(Object sender, GraphicsEventArgs e)
		{
			e.Graphics.DrawString("Hello, World!", new Font("Verdana", 20, FontStyle.Regular, GraphicsUnit.Pixel), new SolidBrush(Color.Blue), 0, 0);
		}
	}
}