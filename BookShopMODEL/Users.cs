namespace BookShopMODEL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users:BookShopContext
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginId { get; set; }

        [Required]
        [StringLength(50)]
        public string LoginPwd { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Mail { get; set; }

        public DateTime? Birthday { get; set; }

        public int UserRoleId { get; set; }

        public int UserStateId { get; set; }

        [StringLength(50)]
        public string RegisterIp { get; set; }

        public DateTime? RegisterTime { get; set; }

        public new virtual UserRoles UserRoles { get; set; }

        public new virtual UserStates UserStates { get; set; }
    }
}
