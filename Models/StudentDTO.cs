﻿using System.ComponentModel.DataAnnotations;

namespace WebCoreApi.Models
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
    }
}
