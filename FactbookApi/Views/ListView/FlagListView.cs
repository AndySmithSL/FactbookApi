﻿using FactbookApi.Views.Base;

namespace FactbookApi.Views.ListView
{
    public class FlagListView : FlagView
    {
        public new int? ArmedForceFlags => ViewObject?.ArmedForceFlags?.Count;
        public int? ArmedForces => ViewObject?.ArmedForces?.Count;
        public new int? BranchFlags => ViewObject?.BranchFlags?.Count;
        public int? Branches => ViewObject?.Branches?.Count;
    }
}
