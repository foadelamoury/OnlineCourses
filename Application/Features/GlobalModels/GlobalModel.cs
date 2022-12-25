namespace Application.Features.GlobalModels
{
    public abstract class GlobalModel
    {

        public int Id { get; set; }
        public int SortIndex { get; set; }
        public bool Focus { get; set; }
        public bool Active { get; set; }
    }
}
