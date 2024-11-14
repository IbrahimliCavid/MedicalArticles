using Core.Results.Abstract;
using Entities.Dtos;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        IResult Add(CategoryCreateDto dto);
        IResult Update(CategoryUpdateDto dto);
        IDataResult<List<CategoryDto>> GetAll();
        IDataResult<List<CategoryDto>> GetAllDeleted();
        IDataResult<CategoryDto> GetById(int id);
        IResult SoftDelete (int id);
        IResult HardDelete (int id);
    }
}
