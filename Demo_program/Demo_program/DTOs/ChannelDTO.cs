﻿using Demo_program.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_program.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }
        public string ChannelName { get; set; }
        public int EstablishedYear { get; set; }
        public string Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}