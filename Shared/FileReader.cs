namespace Shared
{
	public static class FileReader
	{
		public static List<string> ReadLines(string fileName)
		{
			return [.. File.ReadAllLines(fileName)];
		}
	}
}
