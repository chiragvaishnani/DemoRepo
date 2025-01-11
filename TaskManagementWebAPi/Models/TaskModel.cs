using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace TaskManagementWebAPi.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "TaskName field is required")]
        public string TaskName { get; set; } = string.Empty;

        [Display(Name = "Description")]
        [Required(ErrorMessage = "TaskDescription field is required")]
        public string TaskDescription { get; set; } = string.Empty;

        [Required(ErrorMessage = "Task Status field is required")]
        public string TaskStatusId { get; set; } = string.Empty;

        [Display(Name = "Status")]
        public string StatusName { get; set; } = string.Empty;

        public List<SelectListItem> StatusList { get; set; } = new List<SelectListItem>();
    }
}
