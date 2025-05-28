using System;
using System.Collections.Generic;
using System.Text;

namespace EBNFForm
{
	public static class Errors
	{
        #region Variables
        
		public static int count = 0;                                    // number of errors detected
		public static string errMsgFormat = "-- line {0} col {1}: {2}"; // 0=line, 1=column, 2=text

        #endregion
        #region Methods

        public static void SynErr(int line, int col, int n)
		{
			string s;
			switch (n)
			{
				case 0:
					{
						s = "EOF expected";
						break;
					}
				case 1:
					{
						s = "identifier expected";
						break;
					}
				case 2:
					{
						s = "terminal expected";
						break;
					}
				case 3:
					{
						s = "wrap expected";
						break;
					}
				case 4:
					{
						s = "\"=\" expected";
						break;
					}
				case 5:
					{
						s = "terminator expected";
						break;
					}
				case 6:
					{
						s = "\"|\" expected";
						break;
					}
				case 7:
					{
						s = "\"(\" expected";
						break;
					}
				case 8:
					{
						s = "\")\" expected";
						break;
					}
				case 9:
					{
						s = "\"[\" expected";
						break;
					}
				case 10:
					{
						s = "\"]\" expected";
						break;
					}
				case 11:
					{
						s = "\"{\" expected";
						break;
					}
				case 12:
					{
						s = "\"}\" expected";
						break;
					}
				case 13:
					{
						s = "??? expected";
						break;
					}
				case 14:
					{
						s = "invalid Sym";
						break;
					}

				default: s = "error " + n; break;
			}
			Console.WriteLine(Errors.errMsgFormat, line, col, s);
			EbnfForm.WriteLine("ERROR: Line: " + line + " Col: " + col + ": " + s);
			count++;
		}

		public static void SemErr(int line, int col, int n)
		{
			Console.WriteLine(errMsgFormat, line, col, ("error " + n));
			count++;
		}

		public static void Error(int line, int col, string s)
		{
			Console.WriteLine(errMsgFormat, line, col, s);
			count++;
		}

		public static void Exception(string s)
		{
			Console.WriteLine(s);
			System.Environment.Exit(1);
		}

        #endregion
    }
}