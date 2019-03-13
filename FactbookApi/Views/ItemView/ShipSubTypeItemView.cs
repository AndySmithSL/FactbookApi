using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;

namespace FactbookApi.Views.ItemView
{
    public class ShipSubTypeItemView : ShipSubTypeView
    {
        public ShipTypeListView ShipType => GetView<ShipTypeListView, ShipType>(ViewObject.ShipType);
    }
}
