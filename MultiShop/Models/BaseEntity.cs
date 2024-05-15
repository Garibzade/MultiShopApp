namespace MultiShop.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
