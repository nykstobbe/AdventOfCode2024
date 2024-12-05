namespace DayFive
{
	public class PuzzleTwo : IPuzzle
	{
		public List<Rule> Rules = [];
		public List<List<int>> PageLists = [];

		public List<int> ReOrder(List<int> input)
		{
			bool changed;
			do
			{
				changed = false;

				foreach (var rule in Rules)
				{
					if (input.Contains(rule.Page) && input.Contains(rule.MustComeBefore))
					{
						if (!rule.IsMet(input))
						{
							var pageIndex = input.IndexOf(rule.Page);
							var mustComeBeforeIndex = input.IndexOf(rule.MustComeBefore);

							input.RemoveAt(pageIndex);
							input.Insert(mustComeBeforeIndex, rule.Page);
							changed = true;
						}
					}
				}
			} while (changed);

			return input;
		}

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
									  .Where(rule => !rule.IsMet(pageList))
									  .Any()
				 )
				 .Select(ReOrder)
				 .Sum(pageList => pageList.ElementAt(pageList.Count / 2));

			Console.WriteLine(sum);
		}
	}
}