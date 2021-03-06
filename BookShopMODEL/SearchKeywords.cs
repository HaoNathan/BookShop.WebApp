namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SearchKeywords:BaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Keyword { get; set; }

        public int SearchCount { get; set; }
    }
}
