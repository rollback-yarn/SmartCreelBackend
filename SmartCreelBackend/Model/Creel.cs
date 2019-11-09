using System;
using System.Collections.Generic;

namespace SmartCreelBackend.Model
{
    public partial class Creel
    {
        public Creel()
        {
            CreelSide = new HashSet<CreelSide>();
        }

        public int Id { get; set; }
        public string CreelName { get; set; }

        public virtual ICollection<CreelSide> CreelSide { get; set; }
    }
}