namespace Shared
{
	public static class Directions
	{
		public static readonly Coord North = new(0, -1);
		public static readonly Coord NorthEast = new(1, -1);
		public static readonly Coord NorthWest = new(-1, -1);
		public static readonly Coord East = new(1, 0);
		public static readonly Coord South = new(0, 1);
		public static readonly Coord SouthEast = new(1, 1);
		public static readonly Coord SouthWest = new(-1, 1);
		public static readonly Coord West = new(-1, 0);
	}
}