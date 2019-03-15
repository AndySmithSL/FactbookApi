using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class ShipServiceListView : ShipServiceView
    {
        public new string Ship => ViewObject?.Ship?.Name;
        public new string ShipClass => ViewObject?.ShipClass?.Name;
        public new string ShipSubType => ViewObject?.ShipSubType?.Type;
        public new string Branch => ViewObject?.Branch?.Name;
    }
}
