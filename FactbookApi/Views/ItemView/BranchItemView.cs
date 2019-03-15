using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class BranchItemView : BranchView
    {
        public new BranchTypeItemView BranchType => GetView<BranchTypeItemView, BranchType>(ViewObject.BranchType);
        public new ArmedForceItemView ArmedForce => GetView<ArmedForceItemView, ArmedForce>(ViewObject.ArmedForce);

        public new ICollection<BranchFlagListView> BranchFlags => GetViewList<BranchFlagListView, BranchFlag>(ViewObject.BranchFlags);
        public new ICollection<FlagListView> Flags => GetViewList<FlagListView, Flag>(ViewObject.Flags);
    }
}
