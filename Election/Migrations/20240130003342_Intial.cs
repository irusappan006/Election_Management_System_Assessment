using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Election.Migrations
{
    /// <inheritdoc />
    public partial class Intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "party",
                columns: table => new
                {
                    PartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(75)", nullable: true),
                    Symbol = table.Column<string>(type: "varchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_party", x => x.PartyId);
                });

            migrationBuilder.CreateTable(
                name: "state",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(75)", nullable: true),
                    NumberOfMpSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "candidate",
                columns: table => new
                {
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "varchar(75)", nullable: true),
                    Photo = table.Column<string>(type: "varchar(75)", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    PartyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_candidate", x => x.CandidateId);
                    table.ForeignKey(
                        name: "FK_candidate_party_PartyId",
                        column: x => x.PartyId,
                        principalTable: "party",
                        principalColumn: "PartyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_candidate_state_StateId",
                        column: x => x.StateId,
                        principalTable: "state",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "electionresult",
                columns: table => new
                {
                    ElectionResultId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CandidateId = table.Column<int>(type: "int", nullable: false),
                    NumberOfVotes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_electionresult", x => x.ElectionResultId);
                    table.ForeignKey(
                        name: "FK_electionresult_candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "voter",
                columns: table => new
                {
                    VoterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoterIdNumber = table.Column<string>(type: "varchar(75)", nullable: true),
                    Name = table.Column<string>(type: "varchar(75)", nullable: true),
                    Address = table.Column<string>(type: "varchar(75)", nullable: true),
                    Photo = table.Column<string>(type: "varchar(75)", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: true),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voter", x => x.VoterId);
                    table.ForeignKey(
                        name: "FK_voter_candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vote",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VoterId = table.Column<int>(type: "int", nullable: false),
                    CandidateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vote", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_vote_candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "candidate",
                        principalColumn: "CandidateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vote_voter_VoterId",
                        column: x => x.VoterId,
                        principalTable: "voter",
                        principalColumn: "VoterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_candidate_PartyId",
                table: "candidate",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_candidate_StateId",
                table: "candidate",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_electionresult_CandidateId",
                table: "electionresult",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_vote_CandidateId",
                table: "vote",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_vote_VoterId",
                table: "vote",
                column: "VoterId");

            migrationBuilder.CreateIndex(
                name: "IX_voter_CandidateId",
                table: "voter",
                column: "CandidateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "electionresult");

            migrationBuilder.DropTable(
                name: "vote");

            migrationBuilder.DropTable(
                name: "voter");

            migrationBuilder.DropTable(
                name: "candidate");

            migrationBuilder.DropTable(
                name: "party");

            migrationBuilder.DropTable(
                name: "state");
        }
    }
}
