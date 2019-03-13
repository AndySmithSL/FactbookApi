using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;

namespace FactbookApi.Views.ItemView
{
    public class ArmedForceFlagItemView : ArmedForceFlagView
    {
        public ArmedForceListView ArmedForce => GetView<ArmedForceListView, ArmedForce>(ViewObject.ArmedForce);
        public FlagListView Flag => GetView<FlagListView, Flag>(ViewObject.Flag);
    }
}
