using System;
using System.Drawing;
using System.Windows.Forms;

namespace HexSense
{
	public partial class MainForm : Form
	{
		bool firstpass = false;

		public MainForm()
		{
			InitializeComponent();
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			ColorUtil.GenerateColors();
			richTextBox.Visible = false;

			ParseColors();
			firstpass = true;
		}

		public void ParseColors()
		{
			//menuStrip.ForeColor = Color.FromArgb(-1);
			int linenum = 0;
			bool flip = false;
			
			int currentSelectionStart = fixedRichTextBox1.SelectionStart;
			int currentSelectionLength = fixedRichTextBox1.SelectionLength;
			foreach (string line in fixedRichTextBox1.Lines)
			{
				char[] parsed = new char[2]; //the actual character: [0, 5]
				byte[] read; //the hex number the two characters represent: [0x05]
				int len;
				char c;

				len = line.Length;
				for (int i = 0; i < len; i++)
				{
					//parsed[0] = line[i];
					////Console.WriteLine($"string {line[i]}, parsed {Encoding.ASCII.GetBytes(parsed)[0].ToString("X")}");
					if (i + 1 < len)
					{
						c = line[i];
						parsed[0] = c;
						if (IsCharValid(c))
						{
							c = line[i + 1];
							parsed[1] = c;
							if (IsCharValid(c))
							{
								read = FastHex.FromHexString(new string(parsed));
								//flip = !flip;

								fixedRichTextBox1.SelectionStart = i + linenum;
								fixedRichTextBox1.SelectionLength = 2;

								fixedRichTextBox1.SelectionColor = Color.FromArgb(ColorUtil.Map[read[0]]);
								//richTextBox.SelectionColor = flip ? Color.DeepPink : Color.DeepSkyBlue;


								//Console.WriteLine($"Valid pair! {parsed[0]} {parsed[1]} = {read[0].ToString("X")}");
								i++; //skip to the next character so that we don't get 1 color per character in a situation with 010203040
							}
						}
					}
				}
				linenum += len + 1;
			}

			fixedRichTextBox1.SelectionStart = currentSelectionStart;
			fixedRichTextBox1.SelectionLength = currentSelectionLength;
			fixedRichTextBox1.SelectionColor = Color.White;
		}

		public bool IsCharValid(char c)
		{
			if (c >= 0x30 && c <= 0x39) //0-9
			{
				return true;
			}
			if (c >= 0x41 && c <= 0x46) //A-F
			{
				return true;
			}
			if (c >= 0x61 && c <= 0x66) //a-f
			{
				return true;
			}
			//Console.WriteLine("Invalid " + c);
			return false;
		}

		private void richTextBox_TextChanged(object sender, EventArgs e)
		{
			if (firstpass)
				ParseColors();
		}

		private void fixedRichTextBox1_TextChanged(object sender, EventArgs e)
		{
			fixedRichTextBox1.BeginUpdate();
			
			if (firstpass)
				ParseColors();
			
			fixedRichTextBox1.EndUpdate();
		}
	}
}
