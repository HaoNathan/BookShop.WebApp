namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Books:BookShopContext
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Books()
        {
            OrderBook = new HashSet<OrderBook>();
            ReaderComments = new HashSet<ReaderComments>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        [StringLength(200)]
        public string Author { get; set; }

        public int PublisherId { get; set; }

        public DateTime PublishDate { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }

        public string ContentDescription { get; set; }

        public string TOC { get; set; }

        public int CategoryId { get; set; }

        public int Clicks { get; set; }

        public new  virtual Categories Categories { get; set; }

        public new virtual Publishers Publishers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public new virtual ICollection<OrderBook> OrderBook { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public new  virtual ICollection<ReaderComments> ReaderComments { get; set; }
    }
}
