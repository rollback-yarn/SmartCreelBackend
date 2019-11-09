using System;
using System.Collections.Generic;

namespace SmartCreelBackend.Model

{
    public partial class CreelSide
    {
        public CreelSide()
        {
            CreelCreelSideA = new HashSet<Creel>();
            CreelCreelSideB = new HashSet<Creel>();
        }

        public int Id { get; set; }
        public bool? LightOn { get; set; }
        public DateTime? LoadingTime { get; set; }
        public int? MachineId { get; set; }

        public virtual Machine Machine { get; set; }
        public virtual ICollection<Creel> CreelCreelSideA { get; set; }
        public virtual ICollection<Creel> CreelCreelSideB { get; set; }
    }
}