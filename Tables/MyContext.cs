using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace HrAdm.Tables
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Code> Code { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Flow> Flow { get; set; }
        public virtual DbSet<FlowLine> FlowLine { get; set; }
        public virtual DbSet<FlowNode> FlowNode { get; set; }
        public virtual DbSet<FlowSign> FlowSign { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<Prog> Prog { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RoleProg> RoleProg { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserJob> UserJob { get; set; }
        public virtual DbSet<UserLang> UserLang { get; set; }
        public virtual DbSet<UserLicense> UserLicense { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserSchool> UserSchool { get; set; }
        public virtual DbSet<UserSkill> UserSkill { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Hr;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Code>(entity =>
            {
                entity.HasKey(e => new { e.Type, e.Value })
                    .HasName("PK__Code");

                entity.Property(e => e.Type)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Ext)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Note).HasMaxLength(255);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MgrId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Flow>(entity =>
            {
                entity.HasIndex(e => e.Code, "NonClusteredIndex-20210205-193224")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<FlowLine>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CondStr)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.EndNode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartNode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowNode>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.NodeType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.PassType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SignerType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.SignerValue)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FlowSign>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FlowId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.NodeName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Note).HasMaxLength(255);

                entity.Property(e => e.SignStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.SignTime).HasColumnType("datetime");

                entity.Property(e => e.SignerId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SignerName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.SourceId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AgentId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Created).HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.FlowStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Hours).HasColumnType("decimal(5, 1)");

                entity.Property(e => e.LeaveType)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Revised).HasColumnType("datetime");

                entity.Property(e => e.Reviser)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Prog>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Icon)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Url)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<RoleProg>(entity =>
            {
                entity.HasIndex(e => new { e.RoleId, e.ProgId }, "NonClusteredIndex-20210116-190117")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ProgId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.Account, "User_Account");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DeptId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserJob>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CorpName).HasMaxLength(30);

                entity.Property(e => e.JobDesc).IsUnicode(false);

                entity.Property(e => e.JobName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.JobPlace).HasMaxLength(30);

                entity.Property(e => e.JobType).HasMaxLength(30);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLang>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LangName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserLicense>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.FileName).HasMaxLength(100);

                entity.Property(e => e.LicenseName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.RoleId }, "NonClusteredIndex-20210116-185929")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSchool>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolDept).HasMaxLength(20);

                entity.Property(e => e.SchoolName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SchoolType).HasMaxLength(20);

                entity.Property(e => e.StartEnd)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserSkill>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.SkillDesc).HasMaxLength(500);

                entity.Property(e => e.SkillName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
