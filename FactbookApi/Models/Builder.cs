using FactbookApi.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public class Builder : IIdentifiable
    {
        #region Constructor

        public Builder()
        {
            Ships = new HashSet<Ship>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? Founded { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<Ship> Ships { get; set; }

        #endregion Foreign Properties
    }
}
