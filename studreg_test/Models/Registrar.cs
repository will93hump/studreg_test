namespace studreg_test.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registrar")]
    public partial class Registrar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegistrarId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
