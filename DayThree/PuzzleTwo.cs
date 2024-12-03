namespace DayThree
{
	public partial class PuzzleTwo : IPuzzle
	{
		private static readonly Regex _matchMul = MatchMul();

		public void Solve()
		{
			var text = FileReader.Read("input.txt");

			var cleanedText = "";
			var splitText = text.Split("do()");

			foreach (var t in splitText)
			{
				cleanedText += t.Split("don't()")[0];
			}

			var numbers = _matchMul.Matches(cleanedText)
										  .Select(x => x.ToString())
										  .Select(x => x.Replace("mul(", ""))
										  .Select(x => x.Replace(")", ""))
										  .Select(x => x.Split(","))
										  .Select(x => (int.Parse(x[0]), int.Parse(x[1])));

			var total = numbers.Select(x => x.Item1 * x.Item2)
									 .Aggregate((x, y) => x + y);

			Console.WriteLine(total);
		}

		[GeneratedRegex(@"mul\(\d{1,3},\d{1,3}\)")]
		private static partial Regex MatchMul();
	}
}
