using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class Status
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Не задано название")]
        public string Name { get; set; }
    }
}