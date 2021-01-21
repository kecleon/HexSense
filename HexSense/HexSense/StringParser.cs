using System;

namespace HexSense
{

	public class StringParser
	{
		public const string FULL_HEX = @"00 01 02 03 04 05 06 07 08 09 0A 0B 0C 0D 0E 0F 
10 11 12 13 14 15 16 17 18 19 1A 1B 1C 1D 1E 1F 
20 21 22 23 24 25 26 27 28 29 2A 2B 2C 2D 2E 2F 
30 31 32 33 34 35 36 37 38 39 3A 3B 3C 3D 3E 3F 
40 41 42 43 44 45 46 47 48 49 4A 4B 4C 4D 4E 4F 
50 51 52 53 54 55 56 57 58 59 5A 5B 5C 5D 5E 5F 
60 61 62 63 64 65 66 67 68 69 6A 6B 6C 6D 6E 6F 
70 71 72 73 74 75 76 77 78 79 7A 7B 7C 7D 7E 7F 
80 81 82 83 84 85 86 87 88 89 8A 8B 8C 8D 8E 8F 
90 91 92 93 94 95 96 97 98 99 9A 9B 9C 9D 9E 9F 
A0 A1 A2 A3 A4 A5 A6 A7 A8 A9 AA AB AC AD AE AF 
B0 B1 B2 B3 B4 B5 B6 B7 B8 B9 BA BB BC BD BE BF 
C0 C1 C2 C3 C4 C5 C6 C7 C8 C9 CA CB CC CD CE CF 
D0 D1 D2 D3 D4 D5 D6 D7 D8 D9 DA DB DC DD DE DF 
E0 E1 E2 E3 E4 E5 E6 E7 E8 E9 EA EB EC ED EE EF 
F0 F1 F2 F3 F4 F5 F6 F7 F8 F9 FA FB FC FD FE FF";

		//[Benchmark]
		public void readFull_char1()
		{
			string[] split = FULL_HEX.Split('\n');
			foreach (string line in split)
			{
				char[] parsed = new char[2]; //the actual character: [0, 5]
				byte[] read; //the hex number the two characters represent: [0x05]
				for (int i = 0; i < line.Length; i++)
				{
					parsed[0] = line[i];
					////Console.WriteLine($"string {line[i]}, parsed {Encoding.ASCII.GetBytes(parsed)[0].ToString("X")}");
					if (i + 1 < line.Length)
					{
						parsed[0] = line[i];
						if (charValid(parsed[0]))
						{
							parsed[1] = line[i + 1];
							if (charValid(parsed[1]))
							{
								read = FastHex.FromHexString(new string(parsed));
								//Console.WriteLine($"Valid pair! {parsed[0]} {parsed[1]} = {read[0].ToString("X")}");
							}
						}
					}
				}
			}
		}

		//[Benchmark]
		public void readFull_char2()
		{
			string[] split = FULL_HEX.Split('\n');
			char[] parsed = new char[2]; //the actual character: [0, 5]
			byte[] read; //the hex number the two characters represent: [0x05]
			int len;
			char c;
			foreach (string line in split)
			{
				len = line.Length;
				for (int i = 0; i < len; i++)
				{
					//parsed[0] = line[i];
					////Console.WriteLine($"string {line[i]}, parsed {Encoding.ASCII.GetBytes(parsed)[0].ToString("X")}");
					if (i + 1 < len)
					{
						c = line[i];
						parsed[0] = c;
						if (charValid(c))
						{
							c = line[i + 1];
							parsed[1] = c;
							if (charValid(c))
							{
								read = FastHex.FromHexString(new string(parsed));
								//Console.WriteLine($"Valid pair! {parsed[0]} {parsed[1]} = {read[0].ToString("X")}");
							}
						}
					}
				}
			}
		}

		public bool charValid(char c)
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
	}
}
