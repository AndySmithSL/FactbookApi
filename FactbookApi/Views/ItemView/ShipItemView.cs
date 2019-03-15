using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipItemView : ShipView
    {
        public new BuilderItemView Builder => GetView<BuilderItemView, Builder>(ViewObject.Builder);
        public new ICollection<ShipServiceListView> ShipServices => GetViewList<ShipServiceListView, ShipService>(ViewObject.ShipServices);

        public new ICollection<ShipSubTypeListView> ShipSubTypes => GetViewList<ShipSubTypeListView, ShipSubType>(ViewObject.ShipSubTypes);
        public new ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
        public new ICollection<ShipClassListView> ShipClasses => GetViewList<ShipClassListView, ShipClass>(ViewObject.ShipClasses);
    }
}
