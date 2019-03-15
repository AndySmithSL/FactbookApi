using FactbookApi.Code.Classes;
using FactbookApi.Code.Util;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FactbookApi.Views.Base
{
    public class ShipServiceView : View<ShipService>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Penant => ViewObject.Penant;
        public string Name => ViewObject.Name;
        public int ShipId => ViewObject.ShipId;
        public int ShipClassId => ViewObject.ShipClassId;
        public int ShipSubTypeId => ViewObject.ShipSubTypeId;
        public DateTime? StartService => ViewObject.StartService;
        public DateTime? EndService => ViewObject.EndService;
        public int? BranchId => ViewObject.BranchId;
        public string Fate => ViewObject.Fate;
        public bool Active => ViewObject.Active;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ShipView Ship => GetView<ShipView, Ship>(ViewObject.Ship);

        [JsonIgnore]
        public ShipClassView ShipClass => GetView<ShipClassView, ShipClass>(ViewObject.ShipClass);

        [JsonIgnore]
        public ShipSubTypeView ShipSubType => GetView<ShipSubTypeView, ShipSubType>(ViewObject.ShipSubType);

        [JsonIgnore]
        public BranchView Branch => GetView<BranchView, Branch>(ViewObject.Branch);

        #endregion Foreign Properties

        #region Other Properties

        public override string ListName => Name + ":" + PenantLabel + ":" + StartServiceLabel + ":" + EndServiceLabel;

        [JsonIgnore]
        public DateTime AbsoluteStartService => StartService.HasValue ? StartService.Value : DateTime.MinValue;

        [JsonIgnore]
        public DateTime AbsoluteEndService => EndService.HasValue ? EndService.Value : DateTime.MaxValue;

        [JsonIgnore]
        public ICollection<BranchFlagView> BranchFlags => GetBranchFlags(AbsoluteStartService, AbsoluteEndService);

        public bool HasFlag => BranchFlags.Count > 0;

        [JsonIgnore]
        public BranchFlagView CurrentBranchFlag => BranchFlags.OrderBy(x => x.AbsoluteStart).ToList().FirstOrDefault();

        [JsonIgnore]
        public FlagView CurrentFlag => CurrentBranchFlag?.Flag;

        public string ImageSource => CurrentFlag?.ImageSource;
        public string Image => CurrentFlag?.Image;

        public string PenantLabel => String.IsNullOrEmpty(Penant) ? "--" : Penant;
        public string StartServiceLabel => CommonFunctions.GetDateLabel(StartService);
        public string EndServiceLabel => CommonFunctions.GetDateLabel(EndService);
        public TimeSpan TimeSpan => GetCareerTimepan();
        public string TimeSpanLabel => CommonFunctions.Format(TimeSpan);

        #endregion Other Properties

        #region Methods

        private ICollection<BranchFlagView> GetBranchFlags(DateTime startDate, DateTime endDate)
        {
            ICollection<BranchFlagView> result = new List<BranchFlagView>();

            if (Branch != null)
            {
                foreach (var item in Branch.BranchFlags)
                {
                    if (IsValidBranchFlag(item, startDate, endDate))
                    {
                        result.Add(item);
                    }
                }
            }

            return result;
        }

        private bool IsValidBranchFlag(BranchFlagView branchFlag, DateTime startDate, DateTime endDate)
        {
            if (branchFlag.AbsoluteEnd < startDate)
            {
                return false;
            }
            if (branchFlag.AbsoluteStart > endDate)
            {
                return false;
            }

            return true;
        }

        private TimeSpan GetCareerTimepan()
        {
            if (StartService.HasValue)
            {
                if (Active)
                {
                    //Is active therefore will not have a decomissioned date, use DateTime.Now
                    return DateTime.Now - StartService.Value;
                }
                else
                {
                    //Is not active, therefore will have been decomissioned.
                    if (EndService.HasValue)
                    {
                        return EndService.Value - StartService.Value;
                    }
                    else
                    {
                        //No decomissioned value, therefore can't calculate.
                        return TimeSpan.Zero;
                    }
                }
            }
            else
            {
                //Never commissioned (possibly fitting out)
                return TimeSpan.Zero;
            }
        }

        #endregion Methods
    }
}
