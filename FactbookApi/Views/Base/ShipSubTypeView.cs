using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class ShipSubTypeView : View<ShipSubType>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Type => ViewObject.Type;
        public int ShipTypeId => ViewObject.ShipTypeId;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ShipTypeView ShipType => GetView<ShipTypeView, ShipType>(ViewObject.ShipType);

        [JsonIgnore]
        public ICollection<ShipServiceView> ShipServices => GetViewList<ShipServiceView, ShipService>(ViewObject.ShipServices);

        #endregion Foreign Properties

        #region Other Properties

        [JsonIgnore]
        public ICollection<BranchView> Branches => GetViewList<BranchView, Branch>(ViewObject.Branches);

        [JsonIgnore]
        public ICollection<ShipClassView> ShipClasses => GetViewList<ShipClassView, ShipClass>(ViewObject.ShipClasses);

        public override string ListName => Type + ":" + ShipType?.Type;

        #endregion Other Properties
    }
}
