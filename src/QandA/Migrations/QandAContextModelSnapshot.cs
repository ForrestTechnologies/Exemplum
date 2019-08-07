﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QandA.Data;

namespace QandA.Migrations
{
    [DbContext(typeof(QandAContext))]
    partial class QandAContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.ToTable("Answer");
                });

            modelBuilder.Entity("QandA.Features.Questions.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<int?>("QuestionerId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("QuestionerId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QandA.Features.Questions.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created");

                    b.Property<string>("Email");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("QandA.Features.Questions.Answer", b =>
                {
                    b.HasOne("QandA.Features.Questions.User", "Answerer")
                        .WithMany()
                        .HasForeignKey("AnswererId");

                    b.HasOne("QandA.Features.Questions.Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId");
                });

            modelBuilder.Entity("QandA.Features.Questions.Question", b =>
                {
                    b.HasOne("QandA.Features.Questions.User", "Questioner")
                        .WithMany()
                        .HasForeignKey("QuestionerId");
                });
#pragma warning restore 612, 618
        }
    }
}
