using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Election.Class
{
    [Table("state")]
    public class State
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("StateId", TypeName = "int")]
        public int StateId { get; set; }
        [Column("Name", TypeName = "varchar(75)")]
        public string? Name { get; set; }
        [Column("NumberOfMpSeats", TypeName = "int")]
        public int NumberOfMpSeats { get; set; }
        [JsonIgnore]

        public List<Candidate>? Candidates { get; set; }
    }
}
