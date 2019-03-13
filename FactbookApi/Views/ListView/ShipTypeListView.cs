using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipTypeListView : ShipTypeView
    {
        public string ShipCategory => ViewObject.ShipCategory.Category;
        public int ShipSubTypes => ViewObject.ShipSubTypes.Count;
    }
}
