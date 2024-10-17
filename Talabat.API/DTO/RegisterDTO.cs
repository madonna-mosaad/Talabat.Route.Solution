﻿using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber {  get; set; }
    }
}
