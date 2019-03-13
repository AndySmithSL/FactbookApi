using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipCategoryListView : ShipCategoryView
    {
        public int ShipTypes => ViewObject.ShipTypes.Count;
    }
}
