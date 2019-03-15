using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipCategoryListView : ShipCategoryView
    {
        public new int ShipTypes => ViewObject.ShipTypes.Count;
    }
}
