using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipCategoryItemView : ShipCategoryView
    {
        public ICollection<ShipTypeListView> ShipTypes => GetViewList<ShipTypeListView, ShipType>(ViewObject.ShipTypes);
    }
}
