using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GraphQLAdvanced.Entities
{
    [Table("accounts")]
    public class Account
    {
        [Column("id")]
        [Key]
        public Guid Id { get; set; }
        
        [Column("name")]
        [Required(ErrorMessage = "Type is required")]
        public TypeOfAccount Type { get; set; }
        
        [Column("description")]
        public string Description { get; set; }
        
        [Column("ownerId")]
        [ForeignKey("OwnerId")]
        public Guid OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
}