namespace DayOne
{
	public class PuzzleOne : IPuzzle
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

			left.Sort();
			right.Sort();

			var distances = new List<int>();

			var i = 0;

			foreach (var l in left)
			{
				var d = Math.Abs(l - right[i]);

				distances.Add(d);

				i++;
			}

			var sum = distances.Sum();
			Console.WriteLine(sum);
		}
	}
}
