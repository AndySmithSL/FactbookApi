using FactbookApi.Models;
using FactbookApi.Views.Base;

namespace FactbookApi.Views.ItemView
{
    public class ShipServiceItemView : ShipServiceView
    {
        public new ShipItemView Ship => GetView<ShipItemView, Ship>(ViewObject.Ship);
        public new ShipClassItemView ShipClass => GetView<ShipClassItemView, ShipClass>(ViewObject.ShipClass);
        public new ShipSubTypeItemView ShipSubType => GetView<ShipSubTypeItemView, ShipSubType>(ViewObject.ShipSubType);
        public new BranchItemView Branch => GetView<BranchItemView, Branch>(ViewObject.Branch);
    }
}
