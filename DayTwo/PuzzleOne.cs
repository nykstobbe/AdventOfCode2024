namespace DayTwo
{
	public class PuzzleOne : IPuzzle
	{
		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			var reports = lines.Select(l => l.Split().Select(int.Parse));

			var outcomes = new List<bool>();

			foreach (var report in reports)
			{
				outcomes.Add(Shared.IsSafe(report).Item1);
			}

			Console.WriteLine(outcomes.Where(x => x).Count());
		}
	}
}
