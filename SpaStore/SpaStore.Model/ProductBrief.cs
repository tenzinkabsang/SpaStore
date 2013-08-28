namespace SpaStore.Model
{
    public class ProductBrief :TEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        
        public string PrimaryUrl { get; set; }
    }
}
