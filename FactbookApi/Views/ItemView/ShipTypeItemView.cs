using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipTypeItemView : ShipTypeView
    {
        public new ShipCategoryItemView ShipCategory => GetView<ShipCategoryItemView, ShipCategory>(ViewObject.ShipCategory);
        public new ICollection<ShipSubTypeListView> ShipSubTypes => GetViewList<ShipSubTypeListView, ShipSubType>(ViewObject.ShipSubTypes);
    }
}
