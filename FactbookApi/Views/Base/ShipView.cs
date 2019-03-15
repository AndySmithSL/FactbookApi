using FactbookApi.Code.Classes;
using FactbookApi.Code.Util;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class ShipView : View<Ship>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public DateTime? Launched => ViewObject.Launched;
        public int? BuilderId => ViewObject.BuilderId;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public BuilderView Builder => GetView<BuilderView, Builder>(ViewObject.Builder);

        [JsonIgnore]
        public ICollection<ShipServiceView> ShipServices => GetViewList<ShipServiceView, ShipService>(ViewObject.ShipServices);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Name + ":" + Year;

        public string Year => Launched.HasValue ? Launched.Value.Year.ToString() : "--";
        public string LaunchedLabel => Launched.HasValue ? Launched.Value.ToString("dd MMMM yyyy") : "--";

        [JsonIgnore]
        public TimeSpan? TimeSpan => CommonFunctions.GetTimepan(Launched);

        [JsonProperty(PropertyName = "TimeSpan")]
        public string TimeSpanLabel => CommonFunctions.Format(TimeSpan);

        [JsonIgnore]
        public ICollection<ShipSubTypeView> ShipSubTypes => GetViewList<ShipSubTypeView, ShipSubType>(ViewObject.ShipSubTypes);

        //public ICollection<ShipTypeView> ShipTypes => ShipSubTypes.Select(f => f.ShipType).Distinct(f => f.Id).ToList();
        //public ICollection<ShipCategoryView> ShipCategories => ShipTypes.Select(f => f.ShipCategory).Distinct(f => f.Id).ToList();

        [JsonIgnore]
        public ICollection<BranchView> Branches => GetViewList<BranchView, Branch>(ViewObject.Branches);

        [JsonIgnore]
        public ICollection<ShipClassView> ShipClasses => GetViewList<ShipClassView, ShipClass>(ViewObject.ShipClasses);

        #endregion Other Properties
    }
}
