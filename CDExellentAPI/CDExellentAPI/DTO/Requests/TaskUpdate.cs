﻿using System.ComponentModel.DataAnnotations;

namespace CDExellentAPI.DTO.Requests
{
    public class TaskUpdate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int AssigneeId { get; set; }
        [Required]
        public int ReporterId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
