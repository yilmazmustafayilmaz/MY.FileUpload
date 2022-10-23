namespace FileUpload.API.Core.Utilities.Helpers.FileHelpers;
public class FileHelper : IFileHelper
{
    /// <summary>
    /// File Upload
    /// </summary>
    /// <param name="file"></param>
    /// <param name="root"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string Upload(IFormFile file, string root)
    {
        if (file.Length > 0)
        {
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);

            var extension = Path.GetExtension(file.FileName);
            var guid = Guid.NewGuid().ToString();
            var filePath = guid + extension;

            using (FileStream fileStream = File.Create(root + filePath))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
                return filePath;
            }
        }
        return null;
    }

    /// <summary>
    /// File Delete
    /// </summary>
    /// <param name="filePath"></param>
    public void Delete(string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);
    }

    /// <summary>
    /// File Update
    /// </summary>
    /// <param name="file"></param>
    /// <param name="root"></param>
    /// <param name="filePath"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public string Update(IFormFile file, string root, string filePath)
    {
        if (File.Exists(filePath))
            File.Delete(filePath);

        return Upload(file, root);
    }
}

