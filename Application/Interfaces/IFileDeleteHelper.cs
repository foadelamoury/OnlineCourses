namespace Application.Common.Interfaces
{
    public interface IFileDeleteHelper
    {
        string Objectname { get; set; }
        string ObjectID { get; set; }
        string Property { get; set; }
        Task<bool> DeleteFile();
        Task<bool> DeleteFile(string id, string objectName, string property);
    }
}
