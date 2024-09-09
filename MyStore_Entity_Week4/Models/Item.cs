namespace MyStore_Entity_Week4.Models
{
    /// <summary>
    /// Represents an item in the store.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Gets or sets the unique identifier for the item.
        /// </summary>
        public int ItemId { get; set; }
    
        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        public string Name { get; set; } = String.Empty;
    
        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        public decimal Price { get; set; }
    
        /// <summary>
        /// Gets or sets the description of the item.
        /// </summary>
        public string? Description { get; set; }
    
        /// <summary>
        /// Gets or sets the URL of the item's image.
        /// </summary>
        public string? ImageUrl { get; set; }
    }
}