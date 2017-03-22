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
	partial class MainForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label3 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(15, 35);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(147, 34);
			this.button1.TabIndex = 0;
			this.button1.Text = "Show Overlay";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(15, 363);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(257, 45);
			this.label1.TabIndex = 1;
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(15, 253);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(257, 98);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Sites";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker1.Location = new System.Drawing.Point(20, 117);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(136, 20);
			this.dateTimePicker1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(22, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 4;
			this.label2.Text = "start date";
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dateTimePicker2.Location = new System.Drawing.Point(20, 186);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(136, 20);
			this.dateTimePicker2.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(22, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 6;
			this.label3.Text = "end date";
			this.label3.Click += new System.EventHandler(this.Label3Click);
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(133, 399);
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Orientation = System.Windows.Forms.Orientation.Vertical;
			this.trackBar1.Size = new System.Drawing.Size(45, 202);
			this.trackBar1.TabIndex = 7;
			this.trackBar1.Value = 5;
			this.trackBar1.ValueChanged += new System.EventHandler(this.TrackBar1ValueChanged);
			this.trackBar1.Scroll += new System.EventHandler(this.TrackBar1Scroll);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(20, 408);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 23);
			this.label4.TabIndex = 8;
			this.label4.Text = "Opacity for overlay";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 603);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.trackBar1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dateTimePicker2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.dateTimePicker1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Name = "MainForm";
			this.Text = "Overlay Analytics";
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
	}
}
