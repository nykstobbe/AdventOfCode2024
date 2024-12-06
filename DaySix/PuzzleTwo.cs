namespace DaySix
{
	public class PuzzleTwo : IPuzzle
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

			var startingPosition = Shared.FindInGrid(Grid, '^') ?? throw new Exception("No starting position found");
			var currentPosition = startingPosition;

			var direction = North;

			var positions = new List<Coord>();

			while (true)
			{
				positions.Add(currentPosition);

				Grid[currentPosition.Y][currentPosition.X] = '+';
				var newPosition = currentPosition + direction;

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

				currentPosition += direction;
			}

			var total = 0;

			foreach (var position in positions.Distinct())
			{
				if (position == startingPosition)
					continue;

				var grid = lines.Select(lines => lines.ToCharArray()
														 .ToList())
									 .ToList();

				grid[position.Y][position.X] = 'O';

				direction = North;
				currentPosition = startingPosition;

				var directionsByPosition = new Dictionary<Coord, Coord>();

				while (true)
				{
					grid[currentPosition.Y][currentPosition.X] = '+';
					var newPosition = currentPosition + direction;

					if (directionsByPosition.TryGetValue(newPosition, out Coord dir) && dir == direction)
					{
						total++;
						break;
					}

					if (newPosition.X < 0 || newPosition.X >= Grid[0].Count || newPosition.Y < 0 || newPosition.Y >= Grid.Count)
						break;

					if (grid[newPosition.Y][newPosition.X] == '#' || grid[newPosition.Y][newPosition.X] == 'O')
					{
						if (direction == North)
							direction = East;
						else if (direction == East)
							direction = South;
						else if (direction == South)
							direction = West;
						else if (direction == West)
							direction = North;

						continue;
					}

					currentPosition += direction;
					directionsByPosition[currentPosition] = direction;

				}
			}

			Console.WriteLine(total);
		}

		public static void PrintGrid(List<List<char>> grid)
		{
			foreach (var row in grid)
			{
				foreach (var cell in row)
				{
					Console.Write(cell);
				}
				Console.Write("\n");
			}
			Console.Write("\n\n\n");
		}
	}
}
