namespace DaySix
{
	public class PuzzleOne : IPuzzle
	{
		public List<List<char>> Grid = [];

		public Coord North = new(0, -1);
		public Coord East = new(1, 0);
		public Coord South = new(0, 1);
		public Coord West = new(-1, 0);

		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			Grid = lines.Select(lines => lines.ToCharArray()
														 .ToList())
							.ToList();

			var position = Shared.FindInGrid(Grid, '^') ?? throw new Exception("No starting position found");

			var direction = North;

			while (true)
			{
				Grid[position.Y][position.X] = '+';
				var newPosition = position + direction;

				if (newPosition.X < 0 || newPosition.X >= Grid[0].Count || newPosition.Y < 0 || newPosition.Y >= Grid.Count)
					break;

				if (Grid[newPosition.Y][newPosition.X] == '#')
				{
					if (direction == North)
						direction = East;
					else if (direction == East)
						direction = South;
					else if (direction == South)
						direction = West;
					else if (direction == West)
						direction = North;
				}

				position += direction;
			}

			var total = Grid.SelectMany(x => x)
							    .Count(x => x == '+');

			Console.WriteLine(total);
		}
	}
}
