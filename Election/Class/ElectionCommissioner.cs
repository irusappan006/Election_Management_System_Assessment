using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Election.Class
{
    [Table("electioncommissioner")]
    public class ElectionCommissioner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CommissionerId", TypeName = "int")]
        public int CommissionerId { get; set; }
        [Column("Name", TypeName = "varchar(75)")]
        public string? Name { get; set; }
    }
}
