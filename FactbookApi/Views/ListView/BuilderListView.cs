using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class BuilderListView : BuilderView
    {
        public new int Ships => ViewObject.Ships.Count;
    }
}
