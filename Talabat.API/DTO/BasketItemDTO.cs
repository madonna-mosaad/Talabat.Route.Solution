using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTO
{
    public class BasketItemDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [Range(0.1, double.MaxValue ,ErrorMessage ="unacceptable price")]
        public double Price { get; set; }//#this item 
    }
}
