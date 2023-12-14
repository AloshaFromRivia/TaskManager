using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerClient.Models
{
    public class Status
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}