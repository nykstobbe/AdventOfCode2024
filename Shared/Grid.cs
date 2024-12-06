using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
	public class Grid<T>
	{
		public List<List<T>> Data = new();

		public Grid()
		{
		}

		public Grid(List<List<T>> data)
		{
			Data = data;
		}

		public Grid<T> Clone()
		{
			return new Grid<T>(Data.Select(row => row.ToList())
									.ToList());
		}

		public T Get(Coord coord)
		{
			return Data[coord.Y][coord.X];
		}

		public void Set(Coord coord, T value)
		{
			Data[coord.Y][coord.X] = value;
		}

		public void Set(int x, int y, T value)
		{
			Data[y][x] = value;
		}

		public int AmountOf(T value)
		{
			return Data.SelectMany(x => x)
						  .Count(x => x!.Equals(value));
		}

		public Coord? FindFirst(T value)
		{
			for (var y = 0; y < Height; y++)
			{
				for (var x = 0; x < Width; x++)
				{
					if (Data[y][x]!.Equals(value))
						return new Coord(x, y);
				}
			}

			return null;
		}

		public bool IsInside(Coord coord)
		{
			return coord.X >= 0 && coord.X < Width && coord.Y >= 0 && coord.Y < Height;
		}

		public int Width => Data[0].Count;
		public int Height => Data.Count;

		public override string ToString()
		{
			var sb = new StringBuilder();

			foreach (var row in Data)
			{
				foreach (var cell in row)
				{
					sb.Append(cell);
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}
	}
}
