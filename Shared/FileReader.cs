namespace Shared
{
	public static class FileReader
	{
		public static List<string> ReadLines(string fileName)
		{
			return [.. File.ReadAllLines(fileName)];
		}

		public static string Read(string fileName)
		{
			return File.ReadAllText(fileName);
		}
	}
}
