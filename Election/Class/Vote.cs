using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("vote")]
    public class Vote
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("VoteId", TypeName = "int")]
        public int VoteId { get; set; }
        [Column("VoterId", TypeName = "int")]
        public int VoterId { get; set; }
        [JsonIgnore]
        public Voter? Voter { get; set; }
        [Column("CandidateId", TypeName = "int")]
        public int CandidateId { get; set; }
        [JsonIgnore] 
        public Candidate? Candidate { get; set; }
    }
}
