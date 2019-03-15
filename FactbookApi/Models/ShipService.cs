using System;
using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public partial class ShipService
    {
        #region Database Properties

        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Penant { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int ShipId { get; set; }

        [Required]
        public int ShipClassId { get; set; }

        [Required]
        public int ShipSubTypeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartService { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndService { get; set; }

        public int? BranchId { get; set; }

        public string Fate { get; set; }

        public bool Active { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Ship Ship { get; set; }
        public ShipClass ShipClass { get; set; }
        public ShipSubType ShipSubType { get; set; }
        public Branch Branch { get; set; }

        #endregion Foreign Properties
    }
}
