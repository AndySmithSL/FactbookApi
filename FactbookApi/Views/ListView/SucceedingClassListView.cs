using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class SucceedingClassListView : SucceedingClassView
    {
        public new string PrecedingShipClass => ViewObject.PrecedingShipClass.Name;
        public new string SucceedingShipClass => ViewObject.SucceedingShipClass.Name;
    }
}
