using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ArmedForceListView : ArmedForceView
    {
        public int Branches => ViewObject.Branches.Count;
        public int ArmedForceFlags => ViewObject.ArmedForceFlags.Count;
        public new int Flags => ViewObject.Flags.Count;
    }
}
