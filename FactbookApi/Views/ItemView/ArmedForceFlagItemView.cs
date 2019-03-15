using FactbookApi.Models;
using FactbookApi.Views.Base;

namespace FactbookApi.Views.ItemView
{
    public class ArmedForceFlagItemView : ArmedForceFlagView
    {
        public new ArmedForceItemView ArmedForce => GetView<ArmedForceItemView, ArmedForce>(ViewObject.ArmedForce);
        public new FlagItemView Flag => GetView<FlagItemView, Flag>(ViewObject.Flag);
    }
}
