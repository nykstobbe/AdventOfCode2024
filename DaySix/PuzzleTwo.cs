namespace DaySix
{
	public class PuzzleTwo : IPuzzle
	{
		public Grid<char>? Grid;

		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			Grid = new Grid<char>(lines.Select(x => x.ToCharArray()
																  .ToList())
												.ToList()
				);

			var startingPosition = Grid.FindFirst('^') ?? throw new Exception("No starting position found");
			var currentPosition = startingPosition;

			var direction = Directions.North;

			var positions = new List<Coord>();

			while (true)
			{
				positions.Add(currentPosition);

				Grid.Set(currentPosition, '+');
				var newPosition = currentPosition + direction;

				if (!Grid.IsInside(newPosition))
					break;

				if (Grid.Get(newPosition) == '#')
				{
					if (direction == Directions.North)
						direction = Directions.East;
					else if (direction == Directions.East)
						direction = Directions.South;
					else if (direction == Directions.South)
						direction = Directions.West;
					else if (direction == Directions.West)
						direction = Directions.North;
				}

				currentPosition += direction;
			}

			var total = 0;

			foreach (var position in positions.Distinct())
			{
				if (position == startingPosition)
					continue;

				var grid = new Grid<char>(lines.Select(x => x.ToCharArray()
																  .ToList())
														 .ToList()
					);

				grid.Set(position, 'O');

				direction = Directions.North;
				currentPosition = startingPosition;

				var directionsByPosition = new Dictionary<Coord, Coord>();

				while (true)
				{
					grid.Set(currentPosition, '+');
					var newPosition = currentPosition + direction;

					if (directionsByPosition.TryGetValue(newPosition, out Coord dir) && dir == direction)
					{
						total++;
						break;
					}

					if (!grid.IsInside(newPosition))
						break;

					if (grid.Get(newPosition) == '#' || grid.Get(newPosition) == 'O')
					{
						if (direction == Directions.North)
							direction = Directions.East;
						else if (direction == Directions.East)
							direction = Directions.South;
						else if (direction == Directions.South)
							direction = Directions.West;
						else if (direction == Directions.West)
							direction = Directions.North;

						continue;
					}

					currentPosition += direction;
					directionsByPosition[currentPosition] = direction;
				}
			}

			Console.WriteLine(total);
		}
	}
}
