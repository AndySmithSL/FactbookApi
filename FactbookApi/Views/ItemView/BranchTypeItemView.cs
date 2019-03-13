using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class BranchTypeItemView : BranchTypeView
    {
        public ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
    }
}
