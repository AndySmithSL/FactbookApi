using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipTypeListView : ShipTypeView
    {
        public new string ShipCategory => ViewObject.ShipCategory.Category;
        public new int ShipSubTypes => ViewObject.ShipSubTypes.Count;
    }
}
