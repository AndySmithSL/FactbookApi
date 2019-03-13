using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipTypeItemView : ShipTypeView
    {
        public ShipCategoryListView ShipCategory => GetView<ShipCategoryListView, ShipCategory>(ViewObject.ShipCategory);
        public ICollection<ShipSubTypeListView> ShipSubTypes => GetViewList<ShipSubTypeListView, ShipSubType>(ViewObject.ShipSubTypes);
    }
}
