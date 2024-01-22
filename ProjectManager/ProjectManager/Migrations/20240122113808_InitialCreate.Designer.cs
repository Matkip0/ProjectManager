﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectManager;

#nullable disable

namespace ProjectManager.Migrations
{
    [DbContext(typeof(ProjectManagerContext))]
    [Migration("20240122113808_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("ProjectManager.Task", b =>
                {
                    b.Property<int>("TaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TeamID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TaskId");

                    b.HasIndex("TeamID");

                    b.ToTable("Task");
                });

            modelBuilder.Entity("ProjectManager.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTaskTaskId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("TeamID");

                    b.HasIndex("CurrentTaskTaskId");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("ProjectManager.TeamWorker", b =>
                {
                    b.Property<int>("TeamID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WorkerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamID", "WorkerID");

                    b.HasIndex("WorkerID");

                    b.ToTable("TeamWorker");
                });

            modelBuilder.Entity("ProjectManager.Todo", b =>
                {
                    b.Property<int>("TodoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsComplete")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TaskId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("WorkerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TodoID");

                    b.HasIndex("TaskId");

                    b.HasIndex("WorkerID");

                    b.ToTable("Todo");
                });

            modelBuilder.Entity("ProjectManager.Worker", b =>
                {
                    b.Property<int>("WorkerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CurrentTodoTodoID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("TodoID")
                        .HasColumnType("INTEGER");

                    b.HasKey("WorkerID");

                    b.HasIndex("CurrentTodoTodoID");

                    b.HasIndex("TodoID");

                    b.ToTable("Worker");
                });

            modelBuilder.Entity("ProjectManager.Task", b =>
                {
                    b.HasOne("ProjectManager.Team", null)
                        .WithMany("Tasks")
                        .HasForeignKey("TeamID");
                });

            modelBuilder.Entity("ProjectManager.Team", b =>
                {
                    b.HasOne("ProjectManager.Task", "CurrentTask")
                        .WithMany()
                        .HasForeignKey("CurrentTaskTaskId");

                    b.Navigation("CurrentTask");
                });

            modelBuilder.Entity("ProjectManager.TeamWorker", b =>
                {
                    b.HasOne("ProjectManager.Team", "team")
                        .WithMany("Workers")
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectManager.Worker", "Worker")
                        .WithMany("Teams")
                        .HasForeignKey("WorkerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Worker");

                    b.Navigation("team");
                });

            modelBuilder.Entity("ProjectManager.Todo", b =>
                {
                    b.HasOne("ProjectManager.Task", null)
                        .WithMany("Todos")
                        .HasForeignKey("TaskId");

                    b.HasOne("ProjectManager.Worker", null)
                        .WithMany("Todos")
                        .HasForeignKey("WorkerID");
                });

            modelBuilder.Entity("ProjectManager.Worker", b =>
                {
                    b.HasOne("ProjectManager.Todo", "CurrentTodo")
                        .WithMany()
                        .HasForeignKey("CurrentTodoTodoID");

                    b.HasOne("ProjectManager.Todo", null)
                        .WithMany()
                        .HasForeignKey("TodoID");

                    b.Navigation("CurrentTodo");
                });

            modelBuilder.Entity("ProjectManager.Task", b =>
                {
                    b.Navigation("Todos");
                });

            modelBuilder.Entity("ProjectManager.Team", b =>
                {
                    b.Navigation("Tasks");

                    b.Navigation("Workers");
                });

            modelBuilder.Entity("ProjectManager.Worker", b =>
                {
                    b.Navigation("Teams");

                    b.Navigation("Todos");
                });
#pragma warning restore 612, 618
        }
    }
}
