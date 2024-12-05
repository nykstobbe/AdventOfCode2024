namespace DayFive
{
	public class PuzzleOne : IPuzzle
	{
		public List<Rule> Rules = [];
		public List<List<int>> PageLists = [];

		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			Rules.AddRange(
				lines.Where(line => line.Contains('|'))
					  .Select(line => line.Split('|'))
					  .Select(line => new Rule(int.Parse(line[0]), int.Parse(line[1])))
				);

			PageLists.AddRange(
				lines.Where(line => line.Contains(','))
					  .Select(line => line.Split(','))
					  .Select(line => line.Select(int.Parse)
												 .ToList()
						)
				);

			var sum = PageLists
				 .Where(pageList => 
								Rules.Where(rule => pageList.Contains(rule.Page))
									  .All(rule => rule.IsMet(pageList))
				 )
				 .Sum(pageList => pageList.ElementAt(pageList.Count / 2));

			Console.WriteLine(sum);
		}
	}
}
