using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace identiyOrnekCalisma.Models
{
    public class ProjectModel
    {
        [Key]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Project Title is required.")]
        public string ProjectTitle { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Budget is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Budget must be greater than 0.")]
        public decimal Budget { get; set; }

        [Required(ErrorMessage = "End Time is required.")]
        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public string CustomerName { get; set; }
    }


}