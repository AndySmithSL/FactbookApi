using FactbookApi.Models;
using FactbookApi.Views.Base;
using FactbookApi.Views.ListView;
using System.Collections.Generic;

namespace FactbookApi.Views.ItemView
{
    public class ShipClassItemView : ShipClassView
    {
        public new ICollection<ShipServiceListView> ShipServices => GetViewList<ShipServiceListView, ShipService>(ViewObject.ShipServices);

        public new ICollection<ShipClassListView> PrecedingShipClasses => GetViewList<ShipClassListView, ShipClass>(ViewObject.PrecedingShipClasses);
        public new ICollection<ShipClassListView> SucceedingShipClasses => GetViewList<ShipClassListView, ShipClass>(ViewObject.SucceedingShipClasses);

        public new ICollection<ShipListView> Ships => GetViewList<ShipListView, Ship>(ViewObject.Ships);
        public new ICollection<BranchListView> Branches => GetViewList<BranchListView, Branch>(ViewObject.Branches);
        public new ICollection<ShipSubTypeListView> ShipSubTypes => GetViewList<ShipSubTypeListView, ShipSubType>(ViewObject.ShipSubTypes);
    }
}
