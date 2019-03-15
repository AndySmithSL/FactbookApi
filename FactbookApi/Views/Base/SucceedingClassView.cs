using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;

namespace FactbookApi.Views.Base
{
    public class SucceedingClassView : View<SucceedingClass>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public int ShipClassId => ViewObject.ShipClassId;
        public int SucceedingClassId => ViewObject.SucceedingClassId;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ShipClassView PrecedingShipClass => GetView<ShipClassView, ShipClass>(ViewObject.PrecedingShipClass);

        [JsonIgnore]
        public ShipClassView SucceedingShipClass => GetView<ShipClassView, ShipClass>(ViewObject.SucceedingShipClass);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => PrecedingShipClass.Name + ":" + SucceedingShipClass.Name;

        #endregion Other Properties
    }
}
