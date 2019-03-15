using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;

namespace FactbookApi.Views.ItemView
{
    public class BranchFlagItemView : BranchFlagView
    {
        public new BranchItemView Branch => GetView<BranchItemView, Branch>(ViewObject.Branch);
        public new FlagItemView Flag => GetView<FlagItemView, Flag>(ViewObject.Flag);
    }
}
