using FileUpload.API.Constants;
using FileUpload.API.Core.Utilities.Helpers.FileHelpers;
using FileUpload.API.DataAccess.Abstract;
using FileUpload.API.DataAccess.Context;
using FileUpload.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FileUpload.API.DataAccess.Concrete;
public class ImageUploadDal : IImageUploadDal
{
    private readonly DatabaseContext _context;
    private readonly IFileHelper _fileHelper;

    public ImageUploadDal(DatabaseContext context, IFileHelper fileHelper)
    {
        _context = context;
        _fileHelper = fileHelper;
    }

    public ImageUpload Get(Expression<Func<ImageUpload, bool>> filter)
    {
        return _context.Set<ImageUpload>().SingleOrDefault(filter);
    }

    public List<ImageUpload> GetAll(Expression<Func<ImageUpload, bool>> filter = null)
    {
        return filter == null ?
            _context.Set<ImageUpload>().AsNoTracking().ToList() :
            _context.Set<ImageUpload>().AsNoTracking().Where(filter).ToList();
    }

    public void Add(ImageUpload imageUpload)
    {
        imageUpload.ImagePath = _fileHelper.Upload(imageUpload.FormFile, FilePath.Root);
        _context.Add(imageUpload);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var deletedImage = Get(my => my.Id == id);
        _fileHelper.Delete(FilePath.Root + deletedImage.ImagePath);
        _context.Remove(deletedImage);
        _context.SaveChanges();
    }

    public void Update(ImageUpload imageUpload)
    {
        var updatedImage = Get(my => my.Id == imageUpload.Id);
        updatedImage.ImagePath = _fileHelper.Update(imageUpload.FormFile, FilePath.Root, FilePath.Root + updatedImage.ImagePath);
        _context.Update(updatedImage);
        _context.SaveChanges();
    }
}

