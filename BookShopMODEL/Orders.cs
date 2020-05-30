namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders:BookShopContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Orders()
        {
            OrderBook = new HashSet<OrderBook>();
        }

        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int UserId { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        [StringLength(150)]
        public string Address { get; set; }

        [StringLength(50)]
        public string AcceptName { get; set; }

        [StringLength(20)]
        public string AcceptPhone { get; set; }

        [StringLength(50)]
        public string PayStyle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public new virtual ICollection<OrderBook> OrderBook { get; set; }
    }
}
