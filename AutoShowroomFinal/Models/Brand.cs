using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoShowroomFinal
{
    public partial class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Brand's name")]
        public string Name { get; set; } = null!;
        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Country")]
        public string? Info { get; set; }

        public virtual ICollection<Car>? Cars { get; set; }
    }
}
