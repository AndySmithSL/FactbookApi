using FactbookApi.Code.Interfaces;
using FactbookApi.Code.Util;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FactbookApi.Models
{
    public partial class ShipClass : IIdentifiable
    {
        #region Constructor

        public ShipClass()
        {
            ShipServices = new HashSet<ShipService>();
            PrecedingClasses = new HashSet<SucceedingClass>();
            SucceedingClasses = new HashSet<SucceedingClass>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string SubClassName { get; set; }

        public int? Displacement { get; set; }
        public double? Length { get; set; }
        public double? Beam { get; set; }
        public int? Propulsion { get; set; }
        public double? Speed { get; set; }
        public int? Crew { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ICollection<ShipService> ShipServices { get; set; }
        public ICollection<SucceedingClass> PrecedingClasses { get; set; }
        public ICollection<SucceedingClass> SucceedingClasses { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<ShipClass> PrecedingShipClasses => PrecedingClasses.Select(x => x.PrecedingShipClass).Distinct(x => x.Id).ToList();

        [NotMapped]
        public ICollection<ShipClass> SucceedingShipClasses => SucceedingClasses.Select(x => x.SucceedingShipClass).Distinct(x => x.Id).ToList();

        [NotMapped]
        public ICollection<Ship> Ships => ShipServices.Select(x => x.Ship).Distinct(x => x.Id).ToList();

        [NotMapped]
        public ICollection<Branch> Branches => ShipServices.Select(x => x.Branch).Distinct(x => x.Id).ToList();

        [NotMapped]
        public ICollection<ShipSubType> ShipSubTypes => ShipServices.Select(x => x.ShipSubType).Distinct(x => x.Id).ToList();

        #endregion Other Properties
    }
}
