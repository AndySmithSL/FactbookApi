using FactbookApi.Code.Classes;
using FactbookApi.Code.Interfaces;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FactbookApi.Views.Base
{
    public class BranchView : View<Branch>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public int ArmedForceId => ViewObject.ArmedForceId;
        public int BranchTypeId => ViewObject.BranchTypeId;
        public bool HasEmblem => ViewObject.HasEmblem;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public BranchTypeView BranchType => GetView<BranchTypeView, BranchType>(ViewObject.BranchType);

        [JsonIgnore]
        public ArmedForceView ArmedForce => GetView<ArmedForceView, ArmedForce>(ViewObject.ArmedForce);

        [JsonIgnore]
        public ICollection<BranchFlagView> BranchFlags => GetViewList<BranchFlagView, BranchFlag>(ViewObject.BranchFlags);

        [JsonIgnore]
        public ICollection<ShipServiceView> ShipServices => GetViewList<ShipServiceView, ShipService>(ViewObject.ShipServices);

        #endregion Foreign Properties

        #region Other Properties

        [JsonIgnore]
        public ICollection<FlagView> Flags => GetViewList<FlagView, Flag>(ViewObject.Flags);

        public bool HasFlag => Flags.Count > 0;

        [JsonIgnore]
        public FlagView CurrentFlag => Flags.OrderByDescending(x => x.StartDate).FirstOrDefault();

        public string ImageSource => CurrentFlag?.ImageSource;
        public string Image => CurrentFlag?.Image;

        public override string ListName => Name + ":" + ArmedForce?.Name;

        #endregion Other Properties

        #region Methods

        //TODO: AS sort flags
        //public FlagView GetFlagByDate(DateTime date)
        //{
        //    if (BranchFlags.Count > 0)
        //    {
        //        foreach (var item in BranchFlags)
        //        {
        //            if (item.AbsoluteStart <= date && date <= item.AbsoluteEnd)
        //            {
        //                return item.Flag;
        //            }
        //        }

        //        //If we get here return null
        //        return null;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        #endregion Methods
    }
}
