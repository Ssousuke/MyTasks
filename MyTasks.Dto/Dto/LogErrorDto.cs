﻿namespace MyTasks.Dto.Dto
{
    public class LogErrorDto
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
