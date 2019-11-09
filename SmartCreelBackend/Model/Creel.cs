using System;
using System.Collections.Generic;

namespace SmartCreelBackend.Model
{
    public partial class Creel
    {
        public int Id { get; set; }
        public int? CreelSideAid { get; set; }
        public int? CreelSideBid { get; set; }

        public virtual CreelSide CreelSideA { get; set; }
        public virtual CreelSide CreelSideB { get; set; }
    }
}