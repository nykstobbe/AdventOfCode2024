namespace DayOne
{
	public class PuzzleTwo : IPuzzle
	{
		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			var left = new List<int>();
			var right = new List<int>();

			foreach (var line in lines)
			{
				var splitLine = line.Split(" ");

				left.Add(int.Parse(splitLine[0]));
				right.Add(int.Parse(splitLine[^1]));
			}

			var total = new List<int>();

			foreach (var l in left)
			{
				int amount = 0;

				foreach (var r in right)
				{
					if (l == r)
					{
						amount++;
					}
				}

				total.Add(amount * l);
			}

			Console.WriteLine(total.Sum());
		}
	}
}
