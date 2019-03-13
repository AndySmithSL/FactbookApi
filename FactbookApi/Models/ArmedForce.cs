using FactbookApi.Code.Interfaces;
using FactbookApi.Code.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FactbookApi.Models
{
    public class ArmedForce : IIdentifiable
    {
        #region Constructor

        public ArmedForce()
        {
            ArmedForceFlags = new HashSet<ArmedForceFlag>();
            Branches = new HashSet<Branch>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [StringLength(5)]
        [Required]
        public string Code { get; set; }

        [Required]
        public bool IsActive { get; set; }

        public long? Budget { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<ArmedForceFlag> ArmedForceFlags { get; set; }

        public ICollection<Branch> Branches { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Flag> Flags => ArmedForceFlags.Select(f => f.Flag).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
