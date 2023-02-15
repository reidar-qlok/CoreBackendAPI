using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace ACoreBackend.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentId { get; set; } = 0;
        [Required]
        [StringLength(50)]
        public string FirstMidName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
