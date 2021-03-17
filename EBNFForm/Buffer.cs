using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EBNFForm
{
	public class Buffer
	{
		public const char EOF = (char)256;
		static byte[] buf;
		static int bufLen;
		static int pos;

		public static void Fill(Stream s)
		{
			bufLen = (int)s.Length;
			buf = new byte[bufLen];
			s.Read(buf, 0, bufLen);
			pos = 0;
		}

		public static int Read()
		{
			if (pos < bufLen) return buf[pos++];
			else return EOF;                          /* pdt */
		}

		public static int Peek()
		{
			if (pos < bufLen) return buf[pos];
			else return EOF;                          /* pdt */
		}

		/* AW 2003-03-10 moved this from ParserGen.cs */
		public static string GetString(int beg, int end)
		{
			StringBuilder s = new StringBuilder(64);
			int oldPos = Buffer.Pos;
			Buffer.Pos = beg;
			while (beg < end) { s.Append((char)Buffer.Read()); beg++; }
			Buffer.Pos = oldPos;
			return s.ToString();
		}

		public static int Pos
		{
			get { return pos; }
			set
			{
				if (value < 0) pos = 0;
				else if (value >= bufLen) pos = bufLen;
				else pos = value;
			}
		}
	}
}
