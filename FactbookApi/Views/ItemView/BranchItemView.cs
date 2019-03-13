using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;

namespace FactbookApi.Views.ItemView
{
    public class BranchItemView : BranchView
    {
        public BranchTypeListView BranchType => GetView<BranchTypeListView, BranchType>(ViewObject.BranchType);
        public ArmedForceListView ArmedForce => GetView<ArmedForceListView, ArmedForce>(ViewObject.ArmedForce);
    }
}
