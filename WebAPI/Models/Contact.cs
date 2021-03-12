#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    [Table("contact")]
    [Index(nameof(Email), nameof(Telephone), IsUnique = true, Name = "IndexEmail")]
    public class Contact : BaseEntity<int>
    {
        [Column("name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; } = string.Empty;

        [Column("email")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; init; } = string.Empty;

        [Column("telephone")]
        [Required(AllowEmptyStrings = false)]
        public string Telephone { get; init; } = string.Empty;

        public ICollection<Message> Messages { get; init; } = new HashSet<Message>();

        public Contact AddMessage(Message message)
        {
            Messages.Add(message);
            return this;
        }
        
        public override bool Equals(object? obj)
        {
            if (!base.Equals(obj)) return false;

            return obj is Contact entity && Email == entity.Email && Telephone == entity.Telephone;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Email, Telephone);
        }
    }
}