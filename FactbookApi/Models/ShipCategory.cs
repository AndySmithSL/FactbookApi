using FactbookApi.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public class ShipCategory: IIdentifiable
    {
        #region Constructor

        public ShipCategory()
        {
            ShipTypes = new HashSet<ShipType>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<ShipType> ShipTypes { get; set; }

        #endregion Foreign Properties
    }
}
