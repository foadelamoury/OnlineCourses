namespace Domain.Entities
{
    public class AuditableEntity
    {

        public DateTime CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
    }
}
