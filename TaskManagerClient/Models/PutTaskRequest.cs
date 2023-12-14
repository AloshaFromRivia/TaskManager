using System;

namespace TaskManagerClient.Models
{
    public class PutTaskRequest
    {
        public Guid Id { get; set; }
        public TaskModel TaskModel { get; set; }
    }
}