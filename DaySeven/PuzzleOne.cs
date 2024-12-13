namespace DaySeven
{
	public class PuzzleOne : IPuzzle
	{
		public void Solve()
		{
			var lines = FileReader.ReadLines("input.txt");

			var results = lines.Select(line => line.Split(':'))
									 .Select(parts => long.Parse(parts[0]))
									 .ToList();

			var values = lines.Select(line => line.Split(':'))
									 .Select(parts => parts[1].Split(' ', StringSplitOptions.RemoveEmptyEntries)
																	  .Select(long.Parse)
																	  .ToList())
									 .ToList();
			var sum = 0L;

			for (var i = 0; i < results.Count; i++)
			{
				var amount = values.ElementAt(i).Count - 1;
				var permutations = Shared.GetPermutations(amount, 1);

				foreach (var permutation in permutations)
				{
					var result = 0L;
					for (var j = 0; j < amount; j++)
					{
						var first = values.ElementAt(i).ElementAt(j);
						var second = values.ElementAt(i).ElementAt(j + 1);
						
						if (j != 0)
							first = result;

						if (permutation[j] == 0)
							result = first + second;
						else
							result = first * second;
					}
					if (result == results.ElementAt(i))
					{
						sum += result;
						break;
					}
				}
			}

			Console.WriteLine(sum);
		}
	}
}
