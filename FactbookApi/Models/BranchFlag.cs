using FactbookApi.Code.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace FactbookApi.Models
{
    public class BranchFlag : IIdentifiable
    {
        #region Constructor

        public BranchFlag() { }

        #endregion Constructor

        #region Database Properties

        [Key]
        public int Id { get; set; }

        [Required]
        public int BranchId { get; set; }

        [Required]
        public int FlagId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Start { get; set; }

        [DataType(DataType.Date)]
        public DateTime? End { get; set; }

        #endregion Database Properties

        #region Foreign Properties

        public Branch Branch { get; set; }
        public Flag Flag { get; set; }

        #endregion Foreign Properties
    }
}
