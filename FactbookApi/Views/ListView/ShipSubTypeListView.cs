using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipSubTypeListView : ShipSubTypeView
    {
        public new string ShipType => ViewObject?.ShipType?.Type;
        public string ShipCategory => ViewObject?.ShipType?.ShipCategory?.Category;

        public new int? Branches => ViewObject?.Branches?.Count;
        public new int? ShipClasses => ViewObject?.ShipClasses?.Count;
    }
}
