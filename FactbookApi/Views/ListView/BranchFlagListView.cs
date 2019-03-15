using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BranchFlagListView : BranchFlagView
    {
        public new string Branch => ViewObject?.Branch?.Name;
        public new string Flag => ViewObject?.Flag?.Name;
    }
}
