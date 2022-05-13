using System;
using System.Collections.Generic;

namespace AutoShowroomFinal
{
    public partial class Country
    {
        public Country()
        {
            CountryCars = new HashSet<CountryCar>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Info { get; set; }

        public virtual ICollection<CountryCar> CountryCars { get; set; }
    }
}
