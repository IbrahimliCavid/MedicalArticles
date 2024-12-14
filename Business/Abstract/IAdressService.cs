using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface IAdressService
    {
        IResult Add(AdressCreateDto dto);
        IResult Update(AdressUpdateDto dto);
        IDataResult<List<AdressDto>> GetAll();
        IDataResult<List<AdressDto>> GetAllByLanguage(string culture);
        IDataResult<List<Adress>> GetAllDeleted();
        IDataResult<Adress> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
