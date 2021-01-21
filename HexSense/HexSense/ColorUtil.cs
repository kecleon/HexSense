using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HexSense
{
	enum Direction { None, Up, Down };

	public class ColorUtil
	{
		public static Dictionary<byte, int> Map = new Dictionary<byte, int>();

		public static void GenerateColors()
		{
			const int INCREMENT = 4;
			const int MAXIMUM = 256;
			const int MINIMUM = 0;
			char current = 'g';
			int R = MAXIMUM, G = MINIMUM, B = MINIMUM;
			Direction dirR = Direction.None;
			Direction dirG = Direction.Up;
			Direction dirB = Direction.None;
			int color = 0;

			int j = 0;
			while(j != 256)
			{
				if (current == 'g')
				{
					if (dirG == Direction.Up)
					{
						if (G >= MAXIMUM)
						{
							current = 'r';
							dirG = Direction.None;
							dirR = Direction.Down;
						}
						else
						{
							G += INCREMENT;
						}
					}
					else if (dirG == Direction.Down)
					{
						if (G <= MINIMUM)
						{
							current = 'r';
							dirG = Direction.None;
							dirR = Direction.Up;
						}
						else
						{
							G -= INCREMENT;
						}
					}
				}
				else if (current == 'r')
				{
					if (dirR == Direction.Up)
					{
						if (R >= MAXIMUM)
						{
							current = 'b';
							dirR = Direction.None;
							dirB = Direction.Down;
						}
						else
						{
							R += INCREMENT;
						}
					}
					else if (dirR == Direction.Down)
					{
						if (R <= MINIMUM)
						{
							current = 'b';
							dirR = Direction.None;
							dirB = Direction.Up;
						}
						else
						{
							R -= INCREMENT;
						}
					}
				}
				else if (current == 'b')
				{
					if (dirB == Direction.Up)
					{
						if (B >= MAXIMUM)
						{
							current = 'g';
							dirB = Direction.None;
							dirG = Direction.Down;
						}
						else
						{
							B += INCREMENT;
						}
					}
					else if (dirB == Direction.Down)
					{
						if (B <= MINIMUM)
						{
							current = 'g';
							dirB = Direction.None;
							dirG = Direction.Up;
						}
						else
						{
							B -= INCREMENT;
						}
					}
				}
				int tempR = R;
				int tempG = G;
				int tempB = B;
				if (tempR == 256) tempR = 255;
				if (tempG == 256) tempG = 255;
				if (tempB == 256) tempB = 255;
				color = tempR << 16 | tempG << 8 | tempB;

				Map.Add((byte)j, color);

				//Console.WriteLine($"Assigning {R.ToString("X").PadLeft(2, '0')},{G.ToString("X").PadLeft(2, '0')},{B.ToString("X").PadLeft(2, '0')} to {j.ToString("X")}");
				//Console.WriteLine($"Assigning {color.ToString("X").PadLeft(1, '0')} to {i}");
				j++;
			}
			Console.WriteLine("Finished assigning colors");
		}

		public static int clamp(int value)
		{
			if (value < 0)
			{
				return 0;
			}
			if (value > 255)
			{
				return 255;
			}
			return value;
		}
	}
}
