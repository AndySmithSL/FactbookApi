using FactbookApi.Code.Classes;
using FactbookApi.Code.Util;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactbookApi.Views.Base
{
    public class ShipClassView : View<ShipClass>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public string SubClassName => ViewObject.SubClassName;
        public int? Displacement => ViewObject.Displacement;
        public double? Length => ViewObject.Length;
        public double? Beam => ViewObject.Beam;
        public int? Propulsion => ViewObject.Propulsion;
        public double? Speed => ViewObject.Speed;
        public int? Crew => ViewObject.Crew;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<ShipServiceView> ShipServices => GetViewList<ShipServiceView, ShipService>(ViewObject.ShipServices);

        [JsonIgnore]
        public ICollection<SucceedingClassView> PrecedingClasses => GetViewList<SucceedingClassView, SucceedingClass>(ViewObject.PrecedingClasses);

        [JsonIgnore]
        public ICollection<SucceedingClassView> SucceedingClasses => GetViewList<SucceedingClassView, SucceedingClass>(ViewObject.SucceedingClasses);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Name + ":" + SubClassNameLabel + ":" + Year;

        public string FullName => Name + " (" + Year + ")";
        public string SubClassNameLabel => String.IsNullOrEmpty(SubClassName) ? "--" : SubClassName;
        public string DisplacementLabel => Displacement.HasValue ? Displacement.Value.ToString("N0") + " tons" : "--";
        public string LengthLabel => Length.HasValue ? Length.Value.ToString("N0") + " m" : "--";
        public string BeamLabel => Beam.HasValue ? Beam.Value.ToString("N0") + " m" : "--";
        public string PropulsionLabel => Propulsion.HasValue ? Propulsion.Value.ToString("N0") + " hp" : "--";
        public string SpeedLabel => Speed.HasValue ? Speed.Value.ToString("N0") + " knots" : "--";
        public string CrewLabel => Crew.HasValue ? Crew.Value.ToString("N0") : "--";
        
        [JsonIgnore]
        public ICollection<ShipClassView> PrecedingShipClasses => GetViewList<ShipClassView, ShipClass>(ViewObject.PrecedingShipClasses);

        [JsonIgnore]
        public ICollection<ShipClassView> SucceedingShipClasses => GetViewList<ShipClassView, ShipClass>(ViewObject.SucceedingShipClasses);

        [JsonIgnore]
        public ICollection<ShipView> Ships => GetViewList<ShipView, Ship>(ViewObject.Ships);

        [JsonIgnore]
        public ICollection<BranchView> Branches => GetViewList<BranchView, Branch>(ViewObject.Branches);

        [JsonIgnore]
        public ICollection<ShipSubTypeView> ShipSubTypes => GetViewList<ShipSubTypeView, ShipSubType>(ViewObject.ShipSubTypes);

        public string Year => Ships.OrderBy(x => x.Launched).FirstOrDefault()?.Year;

        [JsonIgnore]
        public DateTime? StartService => ShipServices.OrderBy(x => x.StartService)?.FirstOrDefault()?.StartService;

        [JsonIgnore]
        public DateTime? EndService => ShipServices.OrderByDescending(x => x.EndService)?.FirstOrDefault()?.EndService;

        [JsonIgnore]
        public TimeSpan? TimeSpan => CommonFunctions.GetTimepan(StartService, EndService);

        [JsonProperty(PropertyName = "StartService")]
        public string StartServiceLabel => CommonFunctions.GetDateLabel(StartService);
        public string EndServiceLabel => CommonFunctions.GetDateLabel(EndService);
        public string TimeSpanLabel => CommonFunctions.Format(TimeSpan);

        #endregion Other Properties
    }
}
