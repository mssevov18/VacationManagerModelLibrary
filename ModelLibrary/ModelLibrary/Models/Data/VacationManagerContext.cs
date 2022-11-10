using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ModelLibrary.Models.Data
{
    public partial class VacationManagerContext : DbContext
    {
        public VacationManagerContext()
        {
        }

        public VacationManagerContext(DbContextOptions<VacationManagerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttachedFile> AttachedFiles { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamsWorkingOnProjectsConnection> TeamsWorkingOnProjectsConnections { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersInTeamsConnection> UsersInTeamsConnections { get; set; }
        public virtual DbSet<VacationRequest> VacationRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=VacationManager");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamsWorkingOnProjectsConnection>(entity =>
            {
                entity.HasOne(d => d.Project)
                    .WithMany(p => p.TeamsWorkingOnProjectsConnections)
                    .HasForeignKey(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamsWorkingOnProjectsConnection_Projects");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamsWorkingOnProjectsConnections)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TeamsWorkingOnProjectsConnection_Teams");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Role)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UsersInTeamsConnection>(entity =>
            {
                entity.HasOne(d => d.Team)
                    .WithMany(p => p.UsersInTeamsConnections)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInTeamsConnection_Teams");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersInTeamsConnections)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersInTeamsConnection_Users");
            });

            modelBuilder.Entity<VacationRequest>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ApprovedBy)
                    .WithMany(p => p.VacationRequestApprovedBies)
                    .HasForeignKey(d => d.ApprovedById)
                    .HasConstraintName("FK_VacationRequests_Users");

                entity.HasOne(d => d.AttachedFile)
                    .WithMany(p => p.VacationRequests)
                    .HasForeignKey(d => d.AttachedFileId)
                    .HasConstraintName("FK_VacationRequests_AttachedFiles");

                entity.HasOne(d => d.Requester)
                    .WithMany(p => p.VacationRequestRequesters)
                    .HasForeignKey(d => d.RequesterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VacationRequests_Users1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
