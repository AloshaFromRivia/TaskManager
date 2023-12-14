using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerClient.Models
{
    public class TaskModel
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Название не заполнено")]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описание не заполнено")]
        [DisplayName("Описание")]
        public string Description { get; set; }

        public Guid StatusId { get; set; }
        public Status Status { get; set; }
    }
}