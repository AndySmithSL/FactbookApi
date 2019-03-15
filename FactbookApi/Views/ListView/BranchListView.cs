using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BranchListView : BranchView
    {
        public new string BranchType => ViewObject.BranchType?.Type;
        public new string ArmedForce => ViewObject.ArmedForce?.Name;
        public new int BranchFlags => ViewObject.BranchFlags.Count;
        public new int Flags => ViewObject.Flags.Count;
    }
}
