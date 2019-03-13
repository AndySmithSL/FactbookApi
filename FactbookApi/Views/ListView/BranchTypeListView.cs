using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BranchTypeListView : BranchTypeView
    {
        public int Branches => ViewObject.Branches.Count;
    }
}
