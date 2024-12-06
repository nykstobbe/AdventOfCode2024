namespace Shared
{
	public struct Coord(int x, int y)
	{
		public int X = x;
		public int Y = y;

		public static Coord operator +(Coord a, Coord b) => new(a.X + b.X, a.Y + b.Y);
		public static Coord operator -(Coord a, Coord b) => new(a.X - b.X, a.Y - b.Y);

		public static bool operator ==(Coord a, Coord b) => a.X == b.X && a.Y == b.Y;
		public static bool operator !=(Coord a, Coord b) => a.X != b.X || a.Y != b.Y;

		public override readonly bool Equals(object obj)
		{
			if (obj is Coord other)
				return this == other;
			return false;
		}

		public override readonly int GetHashCode() => HashCode.Combine(X, Y);
	}
}
