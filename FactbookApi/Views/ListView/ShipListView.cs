using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipListView : ShipView
    {
        public new string Builder => ViewObject?.Builder?.Name;
        public new int? ShipServices => ViewObject?.ShipServices?.Count;

        public new int? ShipSubTypes => ViewObject?.ShipSubTypes?.Count;
        public new int? Branches => ViewObject?.Branches?.Count;
        public new int? ShipClasses => ViewObject?.ShipClasses?.Count;
    }
}
