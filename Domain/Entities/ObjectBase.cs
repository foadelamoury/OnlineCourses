
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{

    public abstract class ObjectBase : AuditableEntity
    {
        [Column(Order = 0)]
        public long Id { get; set; }
        public int SortIndex { get; set; }
        public bool Focus { get; set; }
        public bool Active { get; set; } = true;

    }
}
