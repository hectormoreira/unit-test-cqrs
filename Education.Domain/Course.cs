using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Domain
{
    public class Course
    {
        [Key]
        public Guid CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DateInFuture]
        public DateTime? PublishOn { get; set; }

        [DataType(DataType.Date)]
        public DateTime? CreatedOn { get; set; }

        public decimal Price { get; set; }
    }
}
