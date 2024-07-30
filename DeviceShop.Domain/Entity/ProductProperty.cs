using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceShop.Domain.Entity
{
    public class ProductProperty
    {
        [Key, Column(Order = 0)]
        public int PropertyId { get; set; }
        [Key, Column(Order = 1)]
        public int ProductId { get; set; }

        public string PropertyName { get; set; }

        public virtual Product Product { get; set; }
        public virtual Property Property { get; set; }
    }
}
