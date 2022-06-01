namespace ShoppingAPI.Models
{
    public class productItem
    {
        [System.ComponentModel.DataAnnotations.Key]

        public int productId { get; set; }

        //[Required(ErrorMessage = "Description is required")]

        //[MaxLength(64, ErrorMessage = "Length of description cannot be greater than 64 characters")]

        //[MinLength(2, ErrorMessage = "Length of description cannot be less than 2 characters")]

        public string? productDescription { get; set; }

        //[Required(ErrorMessage = "Status is required")]

        public string? ProductStatus { get; set; }
        public int productStock { get; set; }
    }
}
