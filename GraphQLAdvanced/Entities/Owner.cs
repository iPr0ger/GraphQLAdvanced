using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLAdvanced.Entities
{
    [Table("owners")]
    public class Owner
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column("name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [Column("address")]
        public string Address { get; set; }
        
        public ICollection<Account> Accounts { get; set; }
    }
}