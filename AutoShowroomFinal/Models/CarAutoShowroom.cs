using System;
using System.Collections.Generic;

namespace AutoShowroomFinal
{
    public partial class CarAutoShowroom
    {
        public int Id { get; set; }
        public int ShowroomId { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; } = null!;
        public virtual AutoShowroom Showroom { get; set; } = null!;
    }
}
