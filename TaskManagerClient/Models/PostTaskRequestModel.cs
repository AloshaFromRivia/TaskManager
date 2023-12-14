using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerClient.Models
{
    public class PostTaskRequestModel
    {
        [Required(ErrorMessage = "Название не заполнено")]
        [DisplayName("Название")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Описание не заполнено")]
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("Состояние")]
        public Guid StatusId { get; set; }
    }
}