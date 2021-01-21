namespace HexSense
{
	partial class MainForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.richTextBox = new System.Windows.Forms.RichTextBox();
			this.fixedRichTextBox1 = new HexSense.FixedRichTextBox();
			this.SuspendLayout();
			// 
			// richTextBox
			// 
			this.richTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.richTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.richTextBox.ForeColor = System.Drawing.Color.White;
			this.richTextBox.Location = new System.Drawing.Point(195, 171);
			this.richTextBox.Margin = new System.Windows.Forms.Padding(0);
			this.richTextBox.Name = "richTextBox";
			this.richTextBox.Size = new System.Drawing.Size(344, 234);
			this.richTextBox.TabIndex = 0;
			this.richTextBox.Text = resources.GetString("richTextBox.Text");
			this.richTextBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
			// 
			// fixedRichTextBox1
			// 
			this.fixedRichTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
			this.fixedRichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.fixedRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.fixedRichTextBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold);
			this.fixedRichTextBox1.ForeColor = System.Drawing.Color.White;
			this.fixedRichTextBox1.Location = new System.Drawing.Point(0, 0);
			this.fixedRichTextBox1.Margin = new System.Windows.Forms.Padding(0);
			this.fixedRichTextBox1.Name = "fixedRichTextBox1";
			this.fixedRichTextBox1.Size = new System.Drawing.Size(548, 432);
			this.fixedRichTextBox1.TabIndex = 1;
			this.fixedRichTextBox1.Text = resources.GetString("fixedRichTextBox1.Text");
			this.fixedRichTextBox1.TextChanged += new System.EventHandler(this.fixedRichTextBox1_TextChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Black;
			this.ClientSize = new System.Drawing.Size(548, 432);
			this.Controls.Add(this.fixedRichTextBox1);
			this.Controls.Add(this.richTextBox);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox richTextBox;
		private FixedRichTextBox fixedRichTextBox1;
	}
}

