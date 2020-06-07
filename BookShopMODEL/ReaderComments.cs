namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReaderComments:BaseEntity
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        [Required]
        [StringLength(10)]
        public string ReaderName { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(300)]
        public string Comment { get; set; }

        public DateTime Date { get; set; }

        public  virtual Books Books { get; set; }
    }
}
