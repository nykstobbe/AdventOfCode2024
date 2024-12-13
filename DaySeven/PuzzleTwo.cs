namespace DaySeven
{
	public class PuzzleTwo : IPuzzle
	{
		public void Solve()
		{
			var lines = FileReader.ReadLines("test.txt");

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
				var permutations = Shared.GetPermutations(amount, 2);
				var x = values.ElementAt(i);

				foreach (var permutation in permutations)
				{
					var result = 0L;

					for (var j = 0; j < permutation.Count; j++)
					{
						if (x.Count == 1)
						{
							if (result == results.ElementAt(i))
								sum += result;
							break;
						}

						//var first =.ElementAt(j);
						//var second = values.ElementAt(i).ElementAt(j + 1);
						var first = x.First() ;
						var second = x[1] ;

						if (j != 0)
							first = result;

						var solve = permutation[0] switch
						{
							0 => first * second,
							1 => first + second,
							2 => long.Parse(first.ToString() + second.ToString()),
							_ => throw new Exception("Invalid operation"),
						};

						if (solve > results.ElementAt(i)) {
							break;
						}


						x = new List<long>(x.GetRange(2, x.Count - 2));
						x.Insert(0, solve);
						permutation.RemoveAt(0);


						//if (permutation[j] == 0)
						//	result += first * second;
						//else if (permutation[j] == 1)
						//	result += first + second;
						//if (permutation[j] == 2)
						//{
						//	values.ElementAt(i).Insert(j, long.Parse(first.ToString() + second.ToString()));
						//	values.ElementAt(i).RemoveAt(0);
						//}
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
