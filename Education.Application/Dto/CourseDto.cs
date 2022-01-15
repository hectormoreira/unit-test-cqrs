using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Dto
{
    public class CourseDto
    {
        public Guid CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PublishOn { get; set; }        
        public decimal Price { get; set; }
    }
}
