using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoShowroomFinal
{
    public partial class Car
    {
        public Car()
        {
            CarAutoShowrooms = new HashSet<CarAutoShowroom>();
            CountryCars = new HashSet<CountryCar>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        public string Name { get; set; } = null!;
        public string? Info { get; set; }
        public int BrandId { get; set; }
        [Required(ErrorMessage = "Field cannot be empty")]
        [Display(Name = "Country")]
        public virtual Brand? Brand { get; set; } = null!;
        public virtual ICollection<CarAutoShowroom>? CarAutoShowrooms { get; set; }
        public virtual ICollection<CountryCar>? CountryCars { get; set; }
    }
}
