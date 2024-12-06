namespace DayFour
{
	public class PuzzleOne : IPuzzle
	{
		private readonly Coord[] _directions = [
			Directions.NorthEast,
			Directions.East,
			Directions.South,
			Directions.SouthEast,
		];

		private const string Xmas = "XMAS";
		private const string SamX = "SAMX";

		private List<string>? Lines;

		public void Solve()
		{
			Lines = FileReader.ReadLines("input.txt");

			int total = 0;

			for (var y = 0; y < Lines.Count; y++)
			{
				for (var x = 0; x < Lines[y].Length; x++)
				{
					foreach (var direction in _directions)
					{
						if (CheckWord(Xmas, 0, new Coord(x, y), direction))
							total++;
					}

					foreach (var direction in _directions)
					{
						if (CheckWord(SamX, 0, new Coord(x, y), direction))
							total++;
					}
				}
			}

			Console.WriteLine(total);
		}

		public bool CheckWord(string word, int letter, Coord point, Coord direction)
		{
			if (letter >= word.Length)
				return false;

			if (point.Y < 0 || point.Y >= Lines!.Count || point.X < 0 || point.X >= Lines[point.Y].Length)
				return false;

			if (Lines![point.Y][point.X] == word[letter])
			{
				if (letter == word.Length - 1)
					return true;

				return CheckWord(word, letter + 1, point + direction, direction);
			}

			return false;
		}
	}
}
