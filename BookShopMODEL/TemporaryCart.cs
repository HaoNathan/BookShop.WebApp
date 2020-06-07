namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TemporaryCart")]
    public partial class TemporaryCart:BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateTime { get; set; }

        public int BookId { get; set; }

        public int UserId { get; set; }

        public int? Num { get; set; }
    }
}
