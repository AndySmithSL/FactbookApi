using FactbookApi.Code.Classes;
using FactbookApi.Models;

namespace FactbookApi.Views.Base
{
    public class ShipCategoryView : View<ShipCategory>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Category => ViewObject.Category;

        #endregion Database Properties

        //[JsonIgnore]
        //public ICollection<ShipTypeView> ShipTypes => GetViewList<ShipTypeView, ShipType>(ViewObject.ShipTypes);
    }
}
