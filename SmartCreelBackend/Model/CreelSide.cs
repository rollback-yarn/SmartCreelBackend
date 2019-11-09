using System;
using System.Collections.Generic;

namespace SmartCreelBackend.Model
{
    public partial class CreelSide
    {
        public int Id { get; set; }
        public bool? LightOn { get; set; }
        public DateTime? LoadingTime { get; set; }
        public int? MachineId { get; set; }
        public int? CreelId { get; set; }
        public bool? IsLeftSide { get; set; }

        public virtual Creel Creel { get; set; }
        public virtual Machine Machine { get; set; }
    }
}