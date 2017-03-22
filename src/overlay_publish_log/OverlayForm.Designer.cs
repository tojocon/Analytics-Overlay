/*
 * Created by SharpDevelop.
 * User: toby
 * Date: 3/26/2013
 * Time: 2:37 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace overlay_publish_log
{
	partial class OverlayForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 3, 30, 3);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(632, 473);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.SizeChanged += new System.EventHandler(this.PictureBox1SizeChanged);
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Verdana", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Coral;
			this.label1.Location = new System.Drawing.Point(97, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(457, 126);
			this.label1.TabIndex = 1;
			this.label1.Text = "Stretch This Window";
			this.label1.SizeChanged += new System.EventHandler(this.Label1SizeChanged);
			// 
			// OverlayForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(632, 473);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "OverlayForm";
			this.Opacity = 0.5;
			this.Text = "OverlayForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
