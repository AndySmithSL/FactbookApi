﻿using FactbookApi.Code.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public class ShipType : IIdentifiable
    {
        #region Constructor

        public ShipType()
        {
            ShipSubTypes = new HashSet<ShipSubType>();
        }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Type { get; set; }

        [Required]
        public int ShipCategoryId { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public ShipCategory ShipCategory { get; set; }
        public ICollection<ShipSubType> ShipSubTypes { get; set; }

        #endregion Foreign Properties
    }
}
