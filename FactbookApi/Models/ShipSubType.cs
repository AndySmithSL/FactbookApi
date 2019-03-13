using FactbookApi.Code.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FactbookApi.Models
{
    public class ShipSubType : IIdentifiable
    {
        #region Constructor

        public ShipSubType()
        {
            //ShipServices = new HashSet<ShipService>();
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

        //public ICollection<ShipService> ShipServices { get; set; }

        #endregion Foreign Properties
    }
}
