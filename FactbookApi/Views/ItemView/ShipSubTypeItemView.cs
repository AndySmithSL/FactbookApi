using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipSubTypeItemView : ShipSubTypeView
    {
        public new ShipTypeItemView ShipType => GetView<ShipTypeItemView, ShipType>(ViewObject.ShipType);
        public new ICollection<ShipServiceListView> ShipServices => GetViewList<ShipServiceListView, ShipService>(ViewObject.ShipServices);

        public new ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
        public new ICollection<ShipClassListView> ShipClasses => GetViewList<ShipClassListView, ShipClass>(ViewObject.ShipClasses);
    }
}
