using Application.Common.Interfaces;

namespace Infrastructure.Services
{
    public class FileDeleteHelper : IFileDeleteHelper
    {
        public string Objectname { get; set; } = string.Empty;
        public string ObjectID { get; set; } = string.Empty;
        public string Property { get; set; } = string.Empty;

        public bool DeleteFile()
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

        public bool DeleteFile(string id, string objectName, string property)
        {
            Objectname = objectName;
            ObjectID = id;
            Property = property;
            return DeleteFile();
        }
    }
}
