﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartSchool_WebApi.Data;

#nullable disable

namespace SmartSchool_WebApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230718164016_utilizadorv7")]
    partial class utilizadorv7
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("SmartSchool_WebApi.Models.Aluno", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("sobrenome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Marta",
                            sobrenome = "Kent",
                            telefone = "33225555"
                        },
                        new
                        {
                            id = 2,
                            nome = "Paula",
                            sobrenome = "Isabela",
                            telefone = "3354288"
                        },
                        new
                        {
                            id = 3,
                            nome = "Laura",
                            sobrenome = "Antonia",
                            telefone = "55668899"
                        },
                        new
                        {
                            id = 4,
                            nome = "Luiza",
                            sobrenome = "Maria",
                            telefone = "6565659"
                        },
                        new
                        {
                            id = 5,
                            nome = "Lucas",
                            sobrenome = "Machado",
                            telefone = "565685415"
                        },
                        new
                        {
                            id = 6,
                            nome = "Pedro",
                            sobrenome = "Alvares",
                            telefone = "456454545"
                        },
                        new
                        {
                            id = 7,
                            nome = "Paulo",
                            sobrenome = "José",
                            telefone = "9874512"
                        });
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("alunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("disciplinaId")
                        .HasColumnType("INTEGER");

                    b.HasKey("alunoId", "disciplinaId");

                    b.HasIndex("disciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            alunoId = 1,
                            disciplinaId = 2
                        },
                        new
                        {
                            alunoId = 1,
                            disciplinaId = 4
                        },
                        new
                        {
                            alunoId = 1,
                            disciplinaId = 5
                        },
                        new
                        {
                            alunoId = 2,
                            disciplinaId = 1
                        },
                        new
                        {
                            alunoId = 2,
                            disciplinaId = 2
                        },
                        new
                        {
                            alunoId = 2,
                            disciplinaId = 5
                        },
                        new
                        {
                            alunoId = 3,
                            disciplinaId = 1
                        },
                        new
                        {
                            alunoId = 3,
                            disciplinaId = 2
                        },
                        new
                        {
                            alunoId = 3,
                            disciplinaId = 3
                        },
                        new
                        {
                            alunoId = 4,
                            disciplinaId = 1
                        },
                        new
                        {
                            alunoId = 4,
                            disciplinaId = 4
                        },
                        new
                        {
                            alunoId = 4,
                            disciplinaId = 5
                        },
                        new
                        {
                            alunoId = 5,
                            disciplinaId = 4
                        },
                        new
                        {
                            alunoId = 5,
                            disciplinaId = 5
                        },
                        new
                        {
                            alunoId = 6,
                            disciplinaId = 1
                        },
                        new
                        {
                            alunoId = 6,
                            disciplinaId = 2
                        },
                        new
                        {
                            alunoId = 6,
                            disciplinaId = 3
                        },
                        new
                        {
                            alunoId = 6,
                            disciplinaId = 4
                        },
                        new
                        {
                            alunoId = 7,
                            disciplinaId = 1
                        },
                        new
                        {
                            alunoId = 7,
                            disciplinaId = 2
                        },
                        new
                        {
                            alunoId = 7,
                            disciplinaId = 3
                        },
                        new
                        {
                            alunoId = 7,
                            disciplinaId = 4
                        },
                        new
                        {
                            alunoId = 7,
                            disciplinaId = 5
                        });
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Disciplina", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            id = 1,
                            ProfessorId = 1,
                            nome = "Matemática"
                        },
                        new
                        {
                            id = 2,
                            ProfessorId = 2,
                            nome = "Física"
                        },
                        new
                        {
                            id = 3,
                            ProfessorId = 3,
                            nome = "Português"
                        },
                        new
                        {
                            id = 4,
                            ProfessorId = 4,
                            nome = "Inglês"
                        },
                        new
                        {
                            id = 5,
                            ProfessorId = 5,
                            nome = "Programação"
                        });
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Professor", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            id = 1,
                            nome = "Lauro"
                        },
                        new
                        {
                            id = 2,
                            nome = "Roberto"
                        },
                        new
                        {
                            id = 3,
                            nome = "Ronaldo"
                        },
                        new
                        {
                            id = 4,
                            nome = "Rodrigo"
                        },
                        new
                        {
                            id = 5,
                            nome = "Alexandre"
                        });
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Utilizador", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("estado")
                        .HasColumnType("TEXT");

                    b.Property<string>("funcao")
                        .HasColumnType("TEXT");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("id");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("SmartSchool_WebApi.Models.Aluno", "aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("alunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SmartSchool_WebApi.Models.Disciplina", "disciplina")
                        .WithMany("AlunoDisciplinas")
                        .HasForeignKey("disciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("aluno");

                    b.Navigation("disciplina");
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Disciplina", b =>
                {
                    b.HasOne("SmartSchool_WebApi.Models.Professor", "Professor")
                        .WithMany("Disciplina")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Aluno", b =>
                {
                    b.Navigation("AlunosDisciplinas");
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Disciplina", b =>
                {
                    b.Navigation("AlunoDisciplinas");
                });

            modelBuilder.Entity("SmartSchool_WebApi.Models.Professor", b =>
                {
                    b.Navigation("Disciplina");
                });
#pragma warning restore 612, 618
        }
    }
}
