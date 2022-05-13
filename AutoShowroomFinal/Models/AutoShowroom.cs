using System;
using System.Collections.Generic;

namespace AutoShowroomFinal
{
    public partial class AutoShowroom
    {
        public AutoShowroom()
        {
            CarAutoShowrooms = new HashSet<CarAutoShowroom>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Info { get; set; }

        public virtual ICollection<CarAutoShowroom> CarAutoShowrooms { get; set; }
    }
}
