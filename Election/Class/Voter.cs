using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("voter")]
    public class Voter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("VoterId", TypeName = "int")]
        public int VoterId { get; set; }
        [Column("VoterIdNumber", TypeName = "varchar(75)")]
        public string? VoterIdNumber { get; set; }
        [Column("Name", TypeName = "varchar(75)")]
        public string? Name { get; set; }
        [Column("Address", TypeName = "varchar(75)")]
        public string? Address { get; set; }
        [Column("Photo", TypeName = "varchar(75)")]
        public string? Photo { get; set; }
        [Column("IsApproved", TypeName = "bit")]
        public bool? IsApproved { get; set; }
        [Column("CandidateId", TypeName = "int")]
        public int CandidateId { get; set; }
        [JsonIgnore]
        public Candidate? Candidate { get; set; }
    }
}
