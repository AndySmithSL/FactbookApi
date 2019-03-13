using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ArmedForceFlagListView : ArmedForceFlagView
    {
        public string ArmedForce => ViewObject.ArmedForce.Name;
        public string Flag => ViewObject.Flag.Name;
    }
}
