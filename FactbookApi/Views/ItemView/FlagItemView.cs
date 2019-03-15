using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class FlagItemView : FlagView
    {
        public new ICollection<ArmedForceFlagListView> ArmedForceFlags => GetViewList<ArmedForceFlagListView, ArmedForceFlag>(ViewObject.ArmedForceFlags);
        public ICollection<ArmedForceListView> ArmedForces => GetViewList<ArmedForceListView, ArmedForce>(ViewObject.ArmedForces);

        public new ICollection<BranchFlagListView> BranchFlags => GetViewList<BranchFlagListView, BranchFlag>(ViewObject.BranchFlags);
        public ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
    }
}
