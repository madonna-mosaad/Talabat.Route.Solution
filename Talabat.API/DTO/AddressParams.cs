﻿using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTO
{
    public class AddressParams
    {
        [Required]
        public string FName { get; set; }
        [Required]
        public string SName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
