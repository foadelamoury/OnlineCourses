namespace Application.Features.GlobalModels
{
    public abstract class GlobalModel
    {

        public long Id { get; set; }
        public int SortIndex { get; set; }
        public bool Focus { get; set; }
        public bool Active { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.Now;

        public DateTime ModifyDate { get; set; } = DateTime.Now;

    }
}
