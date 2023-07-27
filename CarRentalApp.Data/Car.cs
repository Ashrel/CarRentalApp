using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Data
{
    public class Car : BaseDomainEntity
    {

        [Required]
        [Range(1990, 2023)]
        public int Year { get; set; }

        [Required]
        [StringLength(8)]
        public string LicensePlateNumber { get; set; }

        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        public int? ColourId { get; set; }
        public virtual Colour Colour { get; set; }

        public int? CarModelId { get; set; }
        public virtual CarModel CarModel { get; set; }

    }
}
