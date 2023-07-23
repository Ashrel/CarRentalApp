using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalApp.Data
{
    public class Make
    {
        public int Id { get; set; }
        [Display(Name="Manufacturer")]
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; }
    }
}
