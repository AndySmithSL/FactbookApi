﻿using FactbookApi.Code.Classes;
using FactbookApi.Code.Util;
using FactbookApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class FlagView : View<Flag>
    {
        #region Private Declarations

        private const string FLAG_PATH = "/images/flags/";
        private const string FLAG_EXTENSION = ".png";

        #endregion Private Declarations

        #region Database Properties
        
        public int Id => ViewObject.Id;
        public string Name => ViewObject.Name;
        public string Code => ViewObject.Code;
        public string Description => ViewObject.Description;
        public DateTime? StartDate => ViewObject.StartDate;
        public DateTime? EndDate => ViewObject.EndDate;
        public bool Active => ViewObject.Active;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<ArmedForceFlagView> ArmedForceFlags => GetViewList<ArmedForceFlagView, ArmedForceFlag>(ViewObject.ArmedForceFlags);

        [JsonIgnore]
        public ICollection<BranchFlagView> BranchFlags => GetViewList<BranchFlagView, BranchFlag>(ViewObject.BranchFlags);

        #endregion Foreign Properties

        #region Other Properties

        public string Image => Code + FLAG_EXTENSION;
        public string ImageSource => FLAG_PATH + Image;

        public string StartDateLabel => CommonFunctions.GetDateLabel(StartDate);
        public string EndDateLabel => CommonFunctions.GetDateLabel(EndDate);

        [JsonIgnore]
        public DateTime AbsoluteStart => StartDate.HasValue ? StartDate.Value : DateTime.MinValue;

        [JsonIgnore]
        public DateTime AbsoluteEnd => EndDate.HasValue ? EndDate.Value : DateTime.MaxValue;

        public override string ListName => Name + ":" + Code;

        #endregion Other Properties
    }
}
