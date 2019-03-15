using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BranchTypeListView : BranchTypeView
    {
        public new int Branches => ViewObject.Branches.Count;
    }
}
