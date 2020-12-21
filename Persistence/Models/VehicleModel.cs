using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VehicleModel
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Brand { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string Model { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
