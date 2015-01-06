using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = System.Web.UI.WebControls.Image;

namespace DevelopmentWithADot.AspNetServerImage
{
	public class ServerImage : Image
	{
		public ServerImage()
		{
			this.ImageFormat = ImageFormat.Png;
			this.CompositingQuality = CompositingQuality.HighQuality;
			this.InterpolationMode = InterpolationMode.HighQualityBicubic;
			this.Quality = 100L;
			this.SmoothingMode = SmoothingMode.HighQuality;
		}

		[DefaultValue(typeof(ImageFormat), "Png")]
		public ImageFormat ImageFormat { get; set; }

		[DefaultValue(100L)]
		public Int64 Quality { get; set; }

		[DefaultValue(CompositingQuality.HighQuality)]
		public CompositingQuality CompositingQuality { get; set; }

		[DefaultValue(InterpolationMode.HighQualityBicubic)]
		public InterpolationMode InterpolationMode { get; set; }

		[DefaultValue(SmoothingMode.HighQuality)]
		public SmoothingMode SmoothingMode { get; set; }

		public event EventHandler<GraphicsEventArgs> Draw;

		protected virtual void OnDraw(GraphicsEventArgs e)
		{
			var handler = this.Draw;

			if (handler != null)
			{
				handler(this, e);
			}
		}

		protected override void OnInit(EventArgs e)
		{
			if ((this.Width == Unit.Empty) || (this.Height == Unit.Empty) || (this.Width.Value == 0) || (this.Height.Value == 0))
			{
				throw (new InvalidOperationException("Width or height are invalid."));
			}


			base.OnInit(e);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			using (var stream = new MemoryStream())
			using (var image = new Bitmap((Int32)this.Width.Value, (Int32)this.Height.Value))
			using (var graphics = System.Drawing.Graphics.FromImage(image))
			{
				graphics.CompositingQuality = this.CompositingQuality;
				graphics.InterpolationMode = this.InterpolationMode;
				graphics.SmoothingMode = this.SmoothingMode;

				this.OnDraw(new GraphicsEventArgs(graphics));

				var codec = ImageCodecInfo.GetImageEncoders().Single(x => x.FormatID == this.ImageFormat.Guid);

				var parameters = new EncoderParameters(1);
				parameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, this.Quality);

				image.Save(stream, codec, parameters);

				this.ImageUrl = String.Format("data:image/{0};base64,{1}", this.ImageFormat.ToString().ToLower(), Convert.ToBase64String(stream.ToArray()));
			}

			base.Render(writer);
		}
	}
}