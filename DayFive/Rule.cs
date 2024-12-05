namespace DayFive
{
	public struct Rule(int page, int mustComeBefore)
	{
		public int Page = page;
		public int MustComeBefore = mustComeBefore;

		public readonly bool IsMet(List<int> pageList)
		{
			var pageIndex = pageList.IndexOf(Page);
			var mustComeBeforeIndex = pageList.IndexOf(MustComeBefore);

			if (pageIndex < 0 || mustComeBeforeIndex < 0)
				return true;
			else
				return pageIndex < mustComeBeforeIndex;
		}
	}
}
