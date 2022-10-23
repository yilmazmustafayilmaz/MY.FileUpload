using FileUpload.API.Entities;
using System.Linq.Expressions;

namespace FileUpload.API.DataAccess.Abstract;
public interface IImageUploadDal
{
    void Add(ImageUpload imageUpload);
    void Delete(int id);
    void Update(ImageUpload imageUpload);
    List<ImageUpload> GetAll(Expression<Func<ImageUpload, bool>> filter = null);
    ImageUpload Get(Expression<Func<ImageUpload, bool>> filter);
}

