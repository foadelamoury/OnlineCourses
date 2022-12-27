namespace Application.Common.Interfaces
{
    public interface IFileDeleteHelper
    {
        string Objectname { get; set; }
        string ObjectID { get; set; }
        string Property { get; set; }
        bool DeleteFile();
        bool DeleteFile(string id, string objectName, string property);
    }
}
