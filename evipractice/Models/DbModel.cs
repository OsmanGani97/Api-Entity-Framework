using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evipractice.Models
{
    public enum Skill { Masonry = 1, Electrical, Painting, Plumbing, Labor }
    public class Worker
    {
        public int WorkerId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, StringLength(50)]
        public string ContactNo { get; set; } = default!;
        [Required, EnumDataType(typeof(Skill))]
        public Skill Skill { get; set; }
        [Required, Column(TypeName = "money")]//, Display(Name = "Pay rate/day")]
        public decimal PayRate { get; set; }
        [Required, Column(TypeName = "date")]//, Display(Name = "Hire Date")]
        public DateTime? HireDate { get; set; }
        [Required, StringLength(50)]
        public string Picture { get; set; } = default!;
        public bool IsActive { get; set; }
        //
        public virtual ICollection<WorkLog> WorkLogs { get; set; } = [];
    }
    public class WorkLog
    {
        public int WorkLogId { get; set; }
        [Required, Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }
        [Required, StringLength(150)]
        public string Description { get; set; } = default!;
        [Required, ForeignKey("Worker")]
        public int WorkerId { get; set; }
        //Navigation
        public virtual Worker? Worker { get; set; }
    }
    public class WorkerDbContext(DbContextOptions<WorkerDbContext> options) : DbContext(options)
    {
        //public WorkerDbContext(DbContextOptions<WorkerDbContext> options) : base(options) { }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<WorkLog> WorkLogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker { WorkerId = 1, Name = "Abul H", PayRate = 1000, ContactNo = "01710XXXXXX", Skill = Skill.Masonry, HireDate = DateTime.Parse("2024-02-07"), Picture = "e1.jpg", IsActive = true },
                new Worker { WorkerId = 2, Name = "Belayet H", PayRate = 1000, ContactNo = "01910XXXXXX", Skill = Skill.Electrical, HireDate = DateTime.Parse("2024-02-07"), Picture = "e2.jpg", IsActive = true },
                new Worker { WorkerId = 3, Name = "Kamrul I", PayRate = 1000, ContactNo = "01610XXXXXX", Skill = Skill.Painting, HireDate = DateTime.Parse("2024-02-07"), Picture = "e3.jpg", IsActive = true },
                new Worker { WorkerId = 4, Name = "Jubayer H", PayRate = 1000, ContactNo = "01710XXXXXX", Skill = Skill.Plumbing, HireDate = DateTime.Parse("2024-02-07"), Picture = "e4.jpg", IsActive = true },
                new Worker { WorkerId = 5, Name = "Imran H", PayRate = 1000, ContactNo = "01710XXXXXX", Skill = Skill.Labor, HireDate = DateTime.Parse("2024-02-07"), Picture = "e5.jpg", IsActive = true },
                new Worker { WorkerId = 6, Name = "Kedus H", PayRate = 1000, ContactNo = "01710XXXXXX", Skill = Skill.Labor, HireDate = DateTime.Parse("2024-02-07"), Picture = "e4.jpg", IsActive = true }

                );
            modelBuilder.Entity<WorkLog>().HasData(
                new WorkLog { WorkLogId = 1, StartDate = DateTime.Parse("2024-02-09"), EndDate = DateTime.Parse("2024-02-13"), WorkerId = 1, Description = "Uttara prject Boundary wall" },
                new WorkLog { WorkLogId = 2, StartDate = DateTime.Parse("2024-09-02"), WorkerId = 1, Description = "Plustering Baridhara project" }
                );
        }
    }
}
