using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DayFour
{
	public struct Coord(int x, int y)
	{
		public int X = x;
		public int Y = y;

		public static Coord operator +(Coord a, Coord b) => new(a.X + b.X, a.Y + b.Y);
		public static Coord operator -(Coord a, Coord b) => new(a.X - b.X, a.Y - b.Y);
	}
}
