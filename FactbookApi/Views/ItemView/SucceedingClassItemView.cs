using FactbookApi.Models;
using FactbookApi.Views.Base;

namespace FactbookApi.Views.ItemView
{
    public class SucceedingClassItemView : SucceedingClassView
    {
        public new ShipClassItemView PrecedingShipClass => GetView<ShipClassItemView, ShipClass>(ViewObject.PrecedingShipClass);
        public new ShipClassItemView SucceedingShipClass => GetView<ShipClassItemView, ShipClass>(ViewObject.SucceedingShipClass);
    }
}
