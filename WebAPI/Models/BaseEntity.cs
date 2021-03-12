#nullable enable

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public abstract class BaseEntity<TId>
        where TId : IComparable<TId>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public TId Id { get; init; } = default!;

        public override bool Equals(object? obj)
        {
            return obj switch
            {
                null => false,
                BaseEntity<TId> entity => Id.CompareTo(entity.Id) == 0,
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
