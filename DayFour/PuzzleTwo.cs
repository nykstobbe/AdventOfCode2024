namespace DayFour
{
	public class PuzzleTwo : IPuzzle
	{
		private const string Mas = "MAS";
		private const string Sam = "SAM";

		private List<string>? Lines;

		public void Solve()
		{
			Lines = FileReader.ReadLines("input.txt");

			int total = 0;

			for (var y = 0; y < Lines.Count; y++)
			{
				for (var x = 0; x < Lines[y].Length; x++)
				{
					if (CheckWords(Mas, 0, new Coord(x, y), Directions.SouthEast) 
					 || CheckWords(Sam, 0, new Coord(x, y), Directions.SouthEast))
						total++;
					
				}
			}

			Console.WriteLine(total);
		}

		public bool CheckWords(string word, int letter, Coord point, Coord direction, bool secondWord = false)
		{
			if (letter >= word.Length)
				return false;

			if (point.Y < 0 || point.Y >= Lines!.Count || point.X < 0 || point.X >= Lines[point.Y].Length)
				return false;

			if (Lines![point.Y][point.X] == word[letter])
			{
				if (letter == word.Length - 1)
				{
					if (secondWord)
						return true;
					else 
						return CheckWords(Sam, 0, point + new Coord(-2, 0), Directions.NorthEast, true) 
							 || CheckWords(Mas, 0, point + new Coord(-2, 0), Directions.NorthEast, true);
				}

				return CheckWords(word, letter + 1, point + direction, direction, secondWord);
			}

			return false;
		}
	}
}