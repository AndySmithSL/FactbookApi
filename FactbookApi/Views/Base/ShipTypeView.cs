using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        [JsonIgnore]
        public ShipCategoryView ShipCategory => GetView<ShipCategoryView, ShipCategory>(ViewObject.ShipCategory);

        [JsonIgnore]
        public ICollection<ShipSubTypeView> ShipSubTypes => GetViewList<ShipSubTypeView, ShipSubType>(ViewObject.ShipSubTypes);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Type + ":" + ShipCategory.Category;

        #endregion Other Properties
    }
}
