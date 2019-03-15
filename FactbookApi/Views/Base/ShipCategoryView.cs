using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class ShipCategoryView : View<ShipCategory>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Category => ViewObject.Category;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<ShipTypeView> ShipTypes => GetViewList<ShipTypeView, ShipType>(ViewObject.ShipTypes);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Category;

        #endregion Other Properties
    }
}
