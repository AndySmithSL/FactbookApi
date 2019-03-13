using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipSubTypeListView : ShipSubTypeView
    {
        public string ShipType => ViewObject.ShipType.Type;
        public string ShipCategory => ViewObject.ShipType.ShipCategory.Category;
    }
}
