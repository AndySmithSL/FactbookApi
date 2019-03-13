using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BranchListView : BranchView
    {
        public string BranchType => ViewObject.BranchType.Type;
        public string ArmedForce => ViewObject.ArmedForce.Name;
    }
}
