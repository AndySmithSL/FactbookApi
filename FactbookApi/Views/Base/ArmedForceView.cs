using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace FactbookApi.Views.Base
{
    public class ArmedForceView : View<ArmedForce>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public string Code => ViewObject.Code;
        public bool IsActive => ViewObject.IsActive;
        public long? Budget => ViewObject.Budget;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<ArmedForceFlagView> ArmedForceFlags => GetViewList<ArmedForceFlagView, ArmedForceFlag>(ViewObject.ArmedForceFlags);

        [JsonIgnore]
        public ICollection<BranchView> Branches => GetViewList<BranchView, Branch>(ViewObject.Branches);

        #endregion Foreign Properties

        #region Other Properties

        [JsonIgnore]
        public ICollection<FlagView> Flags => GetViewList<FlagView, Flag>(ViewObject.Flags);

        public bool HasFlag => Flags.Count > 0;

        //TODO: AS needs to be more intelligent than this, i.e. get flags by dates
        [JsonIgnore]
        public FlagView CurrentFlag => Flags.OrderByDescending(x => x.StartDate).FirstOrDefault();

        [JsonIgnore]
        public FlagView DefaultFlag => Flags.OrderByDescending(x => x.StartDate).FirstOrDefault();

        public string ImageSource => CurrentFlag?.ImageSource;

        public string BudgetLabel => Budget.HasValue ? "$" + Budget.Value.ToString("N0") : "--";

        public override string ListName => Name + ":" + Code;

        #endregion Other Properties
    }
}
