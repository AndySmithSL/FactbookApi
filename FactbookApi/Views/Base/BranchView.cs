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

        //[JsonIgnore]
        //public BranchTypeView BranchType => GetView<BranchTypeView, BranchType>(ViewObject.BranchType);

        //[JsonIgnore]
        //public ArmedForceView ArmedForce => GetView<ArmedForceView, ArmedForce>(ViewObject.ArmedForce);


        //public ICollection<BranchFlagView> BranchFlags => GetViewList<BranchFlagView, BranchFlag>(ViewObject.BranchFlags);
        //public ICollection<ShipServiceView> ShipServices => GetViewList<ShipServiceView, ShipService>(ViewObject.ShipServices);

        #endregion Foreign Properties

        #region Other Properties

        //public bool HasFlag => Flags.Count > 0;

        //public ICollection<FlagView> Flags => BranchFlags.Select(f => f.Flag).Distinct(f => f.Id).ToList();

        //public FlagView CurrentFlag => Flags.OrderByDescending(x => x.StartDate).FirstOrDefault();

        //public string ImageSource => CurrentFlag?.ImageSource;

        //public string Image => CurrentFlag?.Image;

        #endregion Other Properties

        #region Methods

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
