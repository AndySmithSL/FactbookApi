using FactbookApi.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactbookApi.Models
{
    public class Branch : IIdentifiable
    {
        #region Constructor

        public Branch()
        {
            //BranchFlags = new HashSet<BranchFlag>();
            //ShipServices = new HashSet<ShipService>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public int ArmedForceId { get; set; }

        [Required]
        public int BranchTypeId { get; set; }

        [Required]
        public bool HasEmblem { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ArmedForce ArmedForce { get; set; }

        public BranchType BranchType { get; set; }

        //public ICollection<BranchFlag> BranchFlags { get; set; }

        //public ICollection<ShipService> ShipServices { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        //public ICollection<Flag> Flags => BranchFlags.Select(f => f.Flag).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
