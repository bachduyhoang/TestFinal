namespace ClassLibrary1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Faculty")]
    public partial class Faculty
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FacultyID { get; set; }

        [Column("Full Name")]
        [StringLength(50)]
        public string Full_Name { get; set; }

        public int? Age { get; set; }

        [StringLength(30)]
        public string Address { get; set; }
    }
}
