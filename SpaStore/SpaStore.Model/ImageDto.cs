namespace SpaStore.Model
{
    public class ImageDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int ProductId { get; set; }
        public bool IsPrimary { get; set; }
    }
}