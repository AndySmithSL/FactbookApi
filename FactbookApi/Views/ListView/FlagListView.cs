using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class FlagListView : FlagView
    {
        public int ArmedForceFlags => ViewObject.ArmedForceFlags.Count;
        public int ArmedForces => ViewObject.ArmedForces.Count;
    }
}
