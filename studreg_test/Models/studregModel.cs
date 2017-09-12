namespace studreg_test.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class studregModel : DbContext
    {
        public studregModel()
            : base("name=studregModel1")
        {
        }

        public virtual DbSet<Available> Available { get; set; }
        public virtual DbSet<ClassTime> ClassTime { get; set; }
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Registrar> Registrar { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Professor> Professor { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClassTime>()
                .HasOptional(e => e.Courses)
                .WithRequired(e => e.ClassTime);

            modelBuilder.Entity<Courses>()
                .HasOptional(e => e.Available)
                .WithRequired(e => e.Courses);

            modelBuilder.Entity<Courses>()
                .HasOptional(e => e.Professor)
                .WithRequired(e => e.Courses);

            modelBuilder.Entity<Courses>()
                .HasMany(e => e.Student)
                .WithMany(e => e.Courses)
                .Map(m => m.ToTable("CoursesEnrolled").MapLeftKey("CourseId").MapRightKey("StudentId"));

            modelBuilder.Entity<Student>()
                .Property(e => e.Major)
                .IsFixedLength();
        }
    }
}
