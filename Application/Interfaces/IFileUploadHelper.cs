using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces;

public interface IFileUploadHelper
{
    string Objectname { get; set; }
    string ObjectID { get; set; }
    string Property { get; set; }
    Task<bool> Upload(IFormFile file);
    Task<bool> Upload(IFormFile file, string id, string objectName, string property);
    bool IsvalidExtension(string filename);

}

