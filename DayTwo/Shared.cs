namespace DayTwo
{
	public static class Shared
	{
		public static Tuple<bool, int> IsSafe(IEnumerable<int> report)
		{
			bool safe = true;
			bool increasing = true;

			int previous = 0;

			int i = 0;
			foreach (var level in report)
			{
				if (i == 0)
				{
					previous = level;
					i++;
					continue;
				}

				if (i == 1)
				{
					if (previous < level)
					{
						increasing = true;
					}
					else
					{
						increasing = false;
					}
				}

				var delta = level - previous;

				if (delta == 0)
				{
					safe = false;
					break;
				}
				if (increasing && delta < 0)
				{
					safe = false;
					break;
				}
				if (!increasing && delta > 0)
				{
					safe = false;
					break;
				}
				if (Math.Abs(delta) > 3)
				{
					safe = false;
					break;
				}

				previous = level;
				i++;
			}
			return new Tuple<bool, int>(safe, i);
		}
	}
}
