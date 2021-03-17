/*-------------------------------------------------------------------------
EBNF Visualizer
Copyright (c) 2005 Stefan Schoergenhumer, Markus Dopler
supported by Hanspeter Moessenboeck, University of Linz

This program is free software; you can redistribute it and/or modify it 
under the terms of the GNU General Public License as published by the 
Free Software Foundation; either version 2, or (at your option) any 
later version.

This program is distributed in the hope that it will be useful, but 
WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU General Public License 
for more details.

You should have received a copy of the GNU General Public License along 
with this program; if not, write to the Free Software Foundation, Inc., 
59 Temple Place - Suite 330, Boston, MA 02111-1307, USA.
-------------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Drawing;

namespace EBNFForm
{

	

//---------------------------------------------------------------------
// Syntax graph (class Node, class Graph)
//---------------------------------------------------------------------



	public class Graph
	{

		public Node l;  // left end of graph = head
		public Node r;  // right end of graph = list of nodes to be linked to successor graph
		public Size graphSize;

		public Graph()
		{
			l = null; r = null;
		}

		public Graph(Node left, Node right)
		{
			l = left; r = right;
		}

		public Graph(Node p)
		{
			l = p; r = p;
		}

		public static void MakeFirstAlt(Graph g)
		{
			g.l = new Node(Node.alt, g.l);
			g.l.next = g.r;
			g.r = g.l;
		}

		public static void MakeAlternative(Graph g1, Graph g2)
		{
			g2.l = new Node(Node.alt, g2.l);
			Node p = g1.l; while (p.down != null) p = p.down;
			p.down = g2.l;
			p = g1.r; while (p.next != null) p = p.next;
			p.next = g2.r;
		}

		public static void MakeSequence(Graph g1, Graph g2)
		{
			if (g1.l == null && g1.r == null)
			{/*case: g1 is empty */
				g1.l = g2.l; g1.r = g2.r;
			}
			else
			{

				Node p = g1.r.next; g1.r.next = g2.l; // link head node
				while (p != null)
				{  // link substructure
					Node q = p.next; p.next = g2.l; p.up = true;
					p = q;
				}
				g1.r = g2.r;
			}
		}

		public static void MakeIteration(Graph g)
		{
			g.l = new Node(Node.iter, g.l);
			Node p = g.r;
			g.r = g.l;
			while (p != null)
			{
				Node q = p.next; p.next = g.l; p.up = true;
				p = q;
			}
		}

		public static void MakeOption(Graph g)
		{
			g.l = new Node(Node.opt, g.l);
			g.l.next = g.r;
			g.r = g.l;
		}

		public static void Finish(Graph g)
		{
			Node p = g.r;
			while (p != null)
			{
				Node q = p.next; p.next = null; p = q;
			}
		}
	}
}
