using FactbookApi.Code.Classes;
using FactbookApi.Models;

namespace FactbookApi.Views.Base
{
    public class ShipSubTypeView : View<ShipSubType>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Type => ViewObject.Type;
        public int ShipTypeId => ViewObject.ShipTypeId;

        #endregion Database Properties

        //[JsonIgnore]
        //public ShipTypeView ShipType => GetView<ShipTypeView, ShipType>(ViewObject.ShipType);
    }
}
