namespace MultiShop.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool isDelete { get; set; }
        public DateTime DateTime { get; set; }
    }
}
