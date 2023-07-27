using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentalApp.Data
{
    public class CarModel : BaseDomainEntity
    {
        [Display(Name = "Model")]
        public string Name { get; set; }
        [Display(Name = "Manufacturer")]
        public int? MakeId { get; set; }
        public virtual Make Make { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}