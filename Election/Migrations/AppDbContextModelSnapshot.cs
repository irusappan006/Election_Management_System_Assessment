﻿// <auto-generated />
using System;
using Election.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Election.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.15");

            modelBuilder.Entity("Election.Class.Candidate", b =>
                {
                    b.Property<int>("CandidateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CandidateId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Name");

                    b.Property<int>("PartyId")
                        .HasColumnType("int")
                        .HasColumnName("PartyId");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Photo");

                    b.Property<int>("StateId")
                        .HasColumnType("int")
                        .HasColumnName("StateId");

                    b.HasKey("CandidateId");

                    b.HasIndex("PartyId");

                    b.HasIndex("StateId");

                    b.ToTable("candidate");
                });

            modelBuilder.Entity("Election.Class.ElectionResult", b =>
                {
                    b.Property<int>("ElectionResultId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ElectionResultId");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("CandidateId");

                    b.Property<int>("NumberOfVotes")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfVotes");

                    b.HasKey("ElectionResultId");

                    b.HasIndex("CandidateId");

                    b.ToTable("electionresult");
                });

            modelBuilder.Entity("Election.Class.Party", b =>
                {
                    b.Property<int>("PartyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PartyId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Name");

                    b.Property<string>("Symbol")
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Symbol");

                    b.HasKey("PartyId");

                    b.ToTable("party");
                });

            modelBuilder.Entity("Election.Class.State", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StateId");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Name");

                    b.Property<int>("NumberOfMpSeats")
                        .HasColumnType("int")
                        .HasColumnName("NumberOfMpSeats");

                    b.HasKey("StateId");

                    b.ToTable("state");
                });

            modelBuilder.Entity("Election.Class.Vote", b =>
                {
                    b.Property<int>("VoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VoteId");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("CandidateId");

                    b.Property<int>("VoterId")
                        .HasColumnType("int")
                        .HasColumnName("VoterId");

                    b.HasKey("VoteId");

                    b.HasIndex("CandidateId");

                    b.HasIndex("VoterId");

                    b.ToTable("vote");
                });

            modelBuilder.Entity("Election.Class.Voter", b =>
                {
                    b.Property<int>("VoterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("VoterId");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Address");

                    b.Property<int>("CandidateId")
                        .HasColumnType("int")
                        .HasColumnName("CandidateId");

                    b.Property<bool?>("IsApproved")
                        .HasColumnType("bit")
                        .HasColumnName("IsApproved");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Name");

                    b.Property<string>("Photo")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("Photo");

                    b.Property<string>("VoterIdNumber")
                        .HasColumnType("varchar(75)")
                        .HasColumnName("VoterIdNumber");

                    b.HasKey("VoterId");

                    b.HasIndex("CandidateId");

                    b.ToTable("voter");
                });

            modelBuilder.Entity("Election.Class.Candidate", b =>
                {
                    b.HasOne("Election.Class.Party", "Party")
                        .WithMany("Candidates")
                        .HasForeignKey("PartyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Election.Class.State", "State")
                        .WithMany("Candidates")
                        .HasForeignKey("StateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Party");

                    b.Navigation("State");
                });

            modelBuilder.Entity("Election.Class.ElectionResult", b =>
                {
                    b.HasOne("Election.Class.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Election.Class.Vote", b =>
                {
                    b.HasOne("Election.Class.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Election.Class.Voter", "Voter")
                        .WithMany()
                        .HasForeignKey("VoterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");

                    b.Navigation("Voter");
                });

            modelBuilder.Entity("Election.Class.Voter", b =>
                {
                    b.HasOne("Election.Class.Candidate", "Candidate")
                        .WithMany()
                        .HasForeignKey("CandidateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Candidate");
                });

            modelBuilder.Entity("Election.Class.Party", b =>
                {
                    b.Navigation("Candidates");
                });

            modelBuilder.Entity("Election.Class.State", b =>
                {
                    b.Navigation("Candidates");
                });
#pragma warning restore 612, 618
        }
    }
}
