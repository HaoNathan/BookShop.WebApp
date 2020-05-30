namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderBook")]
    public partial class OrderBook:BookShopContext
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public new virtual Books Books { get; set; }

        public new virtual Orders Orders { get; set; }
    }
}
