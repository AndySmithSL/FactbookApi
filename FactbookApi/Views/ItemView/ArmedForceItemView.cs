using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ArmedForceItemView : ArmedForceView
    {
        public new ICollection<ArmedForceFlagListView> ArmedForceFlags => GetViewList<ArmedForceFlagListView, ArmedForceFlag>(ViewObject.ArmedForceFlags);
        public new ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
        public new ICollection<FlagListView> Flags => GetViewList<FlagListView, Flag>(ViewObject.Flags);
    }
}
