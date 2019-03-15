using FactbookApi.Code.Classes;
using FactbookApi.Code.Util;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;

namespace FactbookApi.Views.Base
{
    public class BranchFlagView : View<BranchFlag>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public int BranchId => ViewObject.BranchId;
        public int FlagId => ViewObject.FlagId;
        public DateTime? Start => ViewObject.Start;
        public DateTime? End => ViewObject.End;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public BranchView Branch => GetView<BranchView, Branch>(ViewObject.Branch);

        [JsonIgnore]
        public FlagView Flag => GetView<FlagView, Flag>(ViewObject.Flag);

        #endregion Foreign Properties

        #region Other Properties

        public string StartDateLabel => CommonFunctions.GetDateLabel(Start);
        public string EndDateLabel => CommonFunctions.GetDateLabel(End);

        [JsonIgnore]
        public DateTime AbsoluteStart => Start.HasValue ? Start.Value : DateTime.MinValue;

        [JsonIgnore]
        public DateTime AbsoluteEnd => End.HasValue ? End.Value : DateTime.MaxValue;

        public override string ListName => Branch?.Name + ":" + Flag?.Name;

        #endregion Other Properties
    }
}
