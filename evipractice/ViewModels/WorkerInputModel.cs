using evipractice.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace evipractice.ViewModels
{
    public class WorkerInputModel
    {
      
       
            public int WorkerId { get; set; }
            [Required, StringLength(50)]
            public string Name { get; set; } = default!;
            [Required, StringLength(50)]
            public string ContactNo { get; set; } = default!;
            [Required, EnumDataType(typeof(Skill))]
            public Skill Skill { get; set; }
            [Required, Display(Name = "Pay rate/day")]
            public decimal? PayRate { get; set; }
            [Required, Column(TypeName = "date")]//, Display(Name = "Hire Date")]
            public DateTime? HireDate { get; set; }
            [Required]
            public IFormFile Picture { get; set; } = default!;
            public bool IsActive { get; set; }
            //
            public virtual List<WorkLog> WorkLogs { get; set; } = [];
        
    }
}
