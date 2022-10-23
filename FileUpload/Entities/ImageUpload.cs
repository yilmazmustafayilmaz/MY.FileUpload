using System.ComponentModel.DataAnnotations.Schema;

namespace FileUpload.API.Entities;
public class ImageUpload
{
    public int Id { get; set; }
    public string ImagePath { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    [NotMapped]
    public IFormFile FormFile { get; set; }
}

