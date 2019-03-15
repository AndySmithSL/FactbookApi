using FactbookApi.Code.Interfaces;
using FactbookApi.Code.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FactbookApi.Models
{
    public class Ship : IIdentifiable
    {
        #region Constructor

        public Ship()
        {
            ShipServices = new HashSet<ShipService>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Launched { get; set; }

        public int? BuilderId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Builder Builder { get; set; }
        public ICollection<ShipService> ShipServices { get; set; }

        #endregion Foreign Properties

        #region Other Properties

        [NotMapped]
        public ICollection<ShipSubType> ShipSubTypes => ShipServices.Select(f => f.ShipSubType).Distinct(f => f.Id).ToList();

        //[NotMapped]
        //public ICollection<ShipType> ShipTypes => ShipSubTypes.Select(f => f?.ShipType).Distinct(f => f.Id).ToList();

        //[NotMapped]
        //public ICollection<ShipCategory> ShipCategories => ShipTypes.Select(f => f?.ShipCategory).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<Branch> Branches => ShipServices.Select(f => f.Branch).Distinct(f => f.Id).ToList();

        [NotMapped]
        public ICollection<ShipClass> ShipClasses => ShipServices.Select(f => f.ShipClass).Distinct(f => f.Id).ToList();

        #endregion Other Properties
    }
}
