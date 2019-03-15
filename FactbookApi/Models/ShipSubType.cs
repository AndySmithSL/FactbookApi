using FactbookApi.Code.Interfaces;
using FactbookApi.Code.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FactbookApi.Models
{
    public class ShipSubType : IIdentifiable
    {
        #region Constructor

        public ShipSubType()
        {
            ShipServices = new HashSet<ShipService>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int ShipTypeId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ShipType ShipType { get; set; }
        public ICollection<ShipService> ShipServices { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<Branch> Branches => ShipServices.Select(x => x.Branch).Distinct(x => x.Id).ToList();

        [NotMapped]
        public ICollection<ShipClass> ShipClasses => ShipServices.Select(x => x.ShipClass).Distinct(x => x.Id).ToList();

        #endregion Other Properties
    }
}
