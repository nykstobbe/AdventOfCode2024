namespace DayTwo
{
	public class PuzzleTwo : IPuzzle
	{
		/// <summary>
		/// Truly a very awful solution. I'm not proud of this one.
		/// </summary>
		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			var reports = lines.Select(l => l.Split().Select(int.Parse));

			var outcomes = new List<bool>();

			foreach (var report in reports)
			{
				var isSafe = Shared.IsSafe(report);

				if (!isSafe.Item1)
				{
					var cleanReport = report.ToList();
					cleanReport.RemoveAt(isSafe.Item2);
					isSafe = Shared.IsSafe(cleanReport);

					if (!isSafe.Item1)
					{
						cleanReport = report.ToList();
						cleanReport.RemoveAt(isSafe.Item2 - 1);
						isSafe = Shared.IsSafe(cleanReport);

						if (!isSafe.Item1)
						{
							cleanReport = report.ToList();
							cleanReport.RemoveAt(0);
							isSafe = Shared.IsSafe(cleanReport);
						}
					}
				}

				outcomes.Add(isSafe.Item1);
			}

			Console.WriteLine(outcomes.Where(x => x).Count());
		}
	}
}
