using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;

namespace Business.Abstract
{
    public interface IAdressService
    {
        IResult Add(AdressCreateDto dto);
        IResult Update(AdressUpdateDto dto);
        IDataResult<List<Adress>> GetAll();
        IDataResult<List<Adress>> GetAllDeleted();
        IDataResult<Adress> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
