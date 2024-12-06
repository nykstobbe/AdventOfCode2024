namespace DaySix
{
	public class PuzzleOne : IPuzzle
	{
		public Grid<char>? Grid;

		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			Grid = new Grid<char>(lines.Select(x => x.ToCharArray()
																  .ToList())
												.ToList()
				);

			var position = Grid.FindFirst('^') ?? throw new Exception("No starting position found");

			var direction = Directions.North;

			while (true)
			{
				Grid.Set(position, '+');
				var newPosition = position + direction;

				if(!Grid.IsInside(newPosition))
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

				position += direction;
			}

			var total = Grid.AmountOf('+');

			Console.WriteLine(total);
		}
	}
}
