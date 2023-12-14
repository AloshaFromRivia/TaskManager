using System;

namespace TaskManagerAPI.Models.Requests
{
    public class PostTaskRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid StatusId { get; set; }
    }
}