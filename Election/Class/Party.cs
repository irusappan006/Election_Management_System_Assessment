using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("party")]
    public class Party
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PartyId", TypeName = "int")]
        public int PartyId { get; set; }
        [Column("Name", TypeName = "varchar(75)")]
        public string? Name { get; set; }
        [Column("Symbol", TypeName = "varchar(100)")]
        public string? Symbol { get; set; }
        [JsonIgnore]

        public List<Candidate>? Candidates { get; set; }
    }
}
