using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EBNFForm
{
	public class Symbol
	{
        #region Variables

        public static ArrayList terminals = new ArrayList();
		public static ArrayList nonterminals = new ArrayList();

		public int typ;         // t, nt
		public string name;        // symbol name
		public Graph graph;       // nt: to first node of syntax graph

        #endregion
        #region Constructors

        public Symbol(int typ, string name)
		{
			if (name.Length == 2 && name[0] == '"')
			{
				Console.WriteLine("empty token not allowed"); name = "???";
			}
			this.typ = typ; this.name = name;
			switch (typ)
			{
				case Node.t: terminals.Add(this); break;
				case Node.nt: nonterminals.Add(this); break;
			}
		}

		public static Symbol Find(string name)
		{
			foreach (Symbol s in terminals)
				if (s.name == name) return s;
			foreach (Symbol s in nonterminals)
				if (s.name == name) return s;
			return null;
		}

        #endregion
        #region Methods

        public static void terminalToNt(string name)
		{
			foreach (Symbol s in terminals)
			{
				if (s.name == name)
				{
					nonterminals.Add(s);
					terminals.Remove(s);
					break;
				}
			}
		}

        #endregion
    }
}
