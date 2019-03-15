using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipClassListView : ShipClassView
    {
        public new int? ShipServices => ViewObject?.ShipServices?.Count;

        public new int? PrecedingShipClasses => ViewObject?.PrecedingShipClasses?.Count;
        public new int? SucceedingShipClasses => ViewObject?.SucceedingShipClasses?.Count;

        public new int? Ships => ViewObject?.Ships?.Count;
        public new int? Branches => ViewObject?.Branches?.Count;
        public new int? ShipSubTypes => ViewObject?.ShipSubTypes?.Count;
    }
}
