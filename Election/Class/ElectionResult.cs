using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("electionresult")]
    public class ElectionResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ElectionResultId", TypeName = "int")]
        public int ElectionResultId { get; set; }
        [Column("CandidateId", TypeName = "int")]
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
        [Column("NumberOfVotes", TypeName = "int")]
        public int NumberOfVotes { get; set; }
    }
}
