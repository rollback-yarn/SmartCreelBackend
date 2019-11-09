using System;
using System.Collections.Generic;

namespace SmartCreelBackend.Model
{
    public partial class Machine
    {
        public Machine()
        {
            CreelSide = new HashSet<CreelSide>();
        }

        public int Id { get; set; }
        public string MachineName { get; set; }

        public virtual ICollection<CreelSide> CreelSide { get; set; }
    }
}