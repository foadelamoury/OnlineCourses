namespace Domain.Entities;


public class Image : ObjectBase<int>
{
    public string Name;
    public int ParentId;
    public string ParentTableName;
}