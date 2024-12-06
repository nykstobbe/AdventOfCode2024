namespace DaySix
{
	public static class Shared
	{
		public static Coord? FindInGrid(List<List<char>> grid, char charToFind)
		{
			for (int y = 0; y < grid.Count; y++)
			{
				for (int x = 0; x < grid[y].Count; x++)
				{
					if (grid[y][x] == charToFind)
						return new Coord(x, y);
				}
			}
			return null;
		}
	}
}
