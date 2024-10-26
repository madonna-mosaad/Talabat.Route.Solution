using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTO
{
    public class AddressDTO
    {
        //first person can recieve the item
        [Required]
        public string FName { get; set; }
        //second person can recieve the item
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
