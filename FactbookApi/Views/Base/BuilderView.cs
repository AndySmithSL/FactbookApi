using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class BuilderView : View<Builder>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public int? Founded => ViewObject.Founded;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<ShipView> Ships => GetViewList<ShipView, Ship>(ViewObject.Ships);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Founded.HasValue ? Name + ":" + FoundedLabel : Name;
        public string FoundedLabel => Founded.HasValue ? Founded.Value.ToString() : "--";

        #endregion Other Properties
    }
}
