namespace studreg_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Available")]
    public partial class Available
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseId { get; set; }

        public int SeatsTaken { get; set; }

        public int Capacity { get; set; }

        public int? Waitlist { get; set; }

        public virtual Courses Courses { get; set; }
    }
}
