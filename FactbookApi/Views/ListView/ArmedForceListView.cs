using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ArmedForceListView : ArmedForceView
    {
        public new int Branches => ViewObject.Branches.Count;
        public new int ArmedForceFlags => ViewObject.ArmedForceFlags.Count;
        public new int Flags => ViewObject.Flags.Count;
    }
}
