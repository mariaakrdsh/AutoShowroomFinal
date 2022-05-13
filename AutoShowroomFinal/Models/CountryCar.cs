using System;
using System.Collections.Generic;

namespace AutoShowroomFinal
{
    public partial class CountryCar
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CountryId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual Country Country { get; set; } = null!;
    }
}
