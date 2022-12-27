using Application.Common.Interfaces;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Services;

public class FileUploadHelper : IFileUploadHelper
{
    public string Objectname { get; set; } = string.Empty;
    public string ObjectID { get; set; } = string.Empty;
    public string Property { get; set; } = string.Empty;
    public async Task<bool> Upload(IFormFile file)
    {
        bool ret = true;
        string filepath = "";
        if (!string.IsNullOrEmpty(Objectname) && !string.IsNullOrEmpty(Property))
        {

            string FolderPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "wwwroot", "Photos", Objectname, Property, ObjectID.ToString());
            if (!Directory.Exists(FolderPath))
                Directory.CreateDirectory(FolderPath);

            var fileName = Path.GetFileName(file.FileName);
            filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", Objectname, Property, ObjectID.ToString())).Root + $@"\{fileName}";

            if (!IsvalidExtension(filepath))
                throw new FileError();
            try
            {
                using (var stream = new FileStream(filepath, FileMode.Create))
                {
                    await file.CopyToAsync(stream, new System.Threading.CancellationToken());
                }
            }
            catch (Exception e)
            {
                ret = false;
                string ex = e.Message;
            }
        }
        else
            ret = false;
        return ret;
    }
    public async Task<bool> Upload(IFormFile file, string id, string objectName, string property)
    {
        Objectname = objectName;
        ObjectID = id;
        Property = property;
        return await Upload(file);
    }



    public bool IsvalidExtension(string filename)
    {
        List<string> availableExtensions = new List<string> { ".pdf", ".docx", ".xlsx", ".xlsm", ".xlsb", ".xltx", ".png", ".jpg", ".jpeg", ".svg", ".gif", ".jfif" };
        string ext = Path.GetExtension(filename);
        if (availableExtensions.Contains(ext.ToLower()))
            return true;
        else
            return false;
    }
}

