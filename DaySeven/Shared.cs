namespace DaySeven
{
	public class Shared
	{
		/// <summary>
		/// Method for getting permutations courtasy of chatgpt
		/// </summary>
		public static List<List<int>> GetPermutations(int length, int maxValue)
		{
			var result = new List<List<int>>();
			int totalPermutations = (int)Math.Pow(maxValue + 1, length);

			for (int i = 0; i < totalPermutations; i++)
			{
				var current = new List<int>();
				int temp = i;

				for (int j = 0; j < length; j++)
				{
					current.Add(temp % (maxValue + 1));
					temp /= (maxValue + 1);
				}

				result.Add(current);
			}

			return result;
		}
	}
}
