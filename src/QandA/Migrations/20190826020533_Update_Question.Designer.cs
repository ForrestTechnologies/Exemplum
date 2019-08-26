﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QandA.Data;

namespace qanda.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20190826020533_Update_Question")]
    partial class Update_Question
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("QandA.Features.Questions.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AnswererId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int?>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("AnswererId");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("QandA.Features.Questions.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("QuestionContent")
                        .IsRequired();

                    b.Property<int>("QuestionerId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.HasKey("Id");

                    b.HasIndex("QuestionerId")
                        .IsUnique();

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QandA.Features.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("QandA.Features.Questions.Answer", b =>
                {
                    b.HasOne("QandA.Features.Users.User", "Answerer")
                        .WithMany()
                        .HasForeignKey("AnswererId");

                    b.HasOne("QandA.Features.Questions.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("QandA.Features.Questions.Question", b =>
                {
                    b.HasOne("QandA.Features.Users.User", "Questioner")
                        .WithOne()
                        .HasForeignKey("QandA.Features.Questions.Question", "QuestionerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
