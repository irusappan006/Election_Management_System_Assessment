using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("candidate")]
    public class Candidate
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("CandidateId", TypeName = "int")]
        public int CandidateId { get; set; }
        [Column("Name", TypeName = "varchar(75)")]
        public string? Name { get; set; }
        [Column("Photo", TypeName = "varchar(75)")]
        public string? Photo { get; set; }
        [Column("StateId", TypeName = "int")]
        public int StateId { get; set; }
        [JsonIgnore]
        public State? State { get; set; }
        [Column("PartyId", TypeName = "int")]
        public int PartyId { get; set; }
        [JsonIgnore]
        public Party? Party { get; set; }
    }
}
