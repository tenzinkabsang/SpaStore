namespace SpaStore.Model
{
    public class Image: TEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsPrimary { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}