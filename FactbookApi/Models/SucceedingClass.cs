using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public partial class SucceedingClass
    {
        #region Constructor

        public SucceedingClass() { }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public int ShipClassId { get; set; }

        [Required]
        public int SucceedingClassId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ShipClass PrecedingShipClass { get; set; }
        public ShipClass SucceedingShipClass { get; set; }

        #endregion Foreign Properties
    }
}
