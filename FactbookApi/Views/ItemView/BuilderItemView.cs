using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class BuilderItemView : BuilderView
    {
        public new ICollection<ShipListView> Ships => GetViewList<ShipListView, Ship>(ViewObject.Ships);
    }
}
