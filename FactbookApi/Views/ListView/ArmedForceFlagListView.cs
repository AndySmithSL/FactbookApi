using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ArmedForceFlagListView : ArmedForceFlagView
    {
        public new string ArmedForce => ViewObject.ArmedForce?.Name;
        public new string Flag => ViewObject.Flag?.Name;
    }
}
