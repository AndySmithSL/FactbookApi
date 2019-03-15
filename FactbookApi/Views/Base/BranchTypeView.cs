using FactbookApi.Code.Classes;
using FactbookApi.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FactbookApi.Views.Base
{
    public class BranchTypeView : View<BranchType>
    {
        #region Database Properties

        public int Id => ViewObject.Id;
        public string Type => ViewObject.Type;
        public string Code => ViewObject.Code;

        #endregion Database Properties

        #region Foreign Properties

        [JsonIgnore]
        public ICollection<BranchView> Branches => GetViewList<BranchView, Branch>(ViewObject.Branches);

        #endregion Foreign Properties

        #region Other Properties

        public string IconLight => Code + "-light.png";
        public string IconDark => Code + "-dark.png";

        public override string ListName => Type + ":" + Code;

        #endregion Other Properties
    }
}
