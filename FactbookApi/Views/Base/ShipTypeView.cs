using FactbookApi.Code.Classes;
using FactbookApi.Models;

namespace FactbookApi.Views.Base
{
    public class ShipTypeView : View<ShipType>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Type => ViewObject.Type;
        public int ShipCategoryId => ViewObject.ShipCategoryId;

        #endregion Database Properties

        #region Foreign Properties

        //[JsonIgnore]
        //public ShipCategoryView ShipCategory => GetView<ShipCategoryView, ShipCategory>(ViewObject.ShipCategory);

        //[JsonIgnore]
        //public ICollection<ShipSubTypeView> ShipSubTypes => GetViewList<ShipSubTypeView, ShipSubType>(ViewObject.ShipSubTypes);

        #endregion Foreign Properties
    }
}
