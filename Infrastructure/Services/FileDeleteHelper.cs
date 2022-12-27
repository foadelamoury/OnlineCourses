using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.FileProviders;

namespace Infrastructure.Services
{
  public class FileDeleteHelper : IFileDeleteHelper
  {
    public string Objectname { get; set; } = string.Empty;
    public string ObjectID { get; set; } = string.Empty;
    public string Property { get; set; } = string.Empty;

    public async Task<bool> DeleteFile()
    {
      bool ret = true;
      string? filepath = "";
      if (!string.IsNullOrEmpty(Objectname) && !string.IsNullOrEmpty(Property))
      {

        string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Photos", Objectname, Property, ObjectID.ToString());
        if (!Directory.Exists(FolderPath))
          ret = false;
        
      
        try
        {
          var dir = new DirectoryInfo(@FolderPath);
          dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
          dir.Delete(true);
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

    public async Task<bool> DeleteFile(string id, string objectName, string property)
    {
      Objectname = objectName;
      ObjectID = id;
      Property = property;
      return await DeleteFile();
    }
  }
}
