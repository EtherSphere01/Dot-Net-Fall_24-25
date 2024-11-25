using Demo_program.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demo_program.DTOs
{
    public class ChannelDTO
    {
        public int ChannelId { get; set; }

        [Required]
        [StringLength(100)]
        public string ChannelName { get; set; }

        [Required]
        public int EstablishedYear { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Program> Programs { get; set; }
    }
}