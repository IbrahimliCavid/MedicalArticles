using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation.Results;

namespace Business.Abstract
{
    public interface IAdressService
    {
        IResult Add(AdressCreateDto dto, out List<ValidationFailure> errors);
        IResult Update(AdressUpdateDto dto, out List<ValidationFailure> errors);
        IDataResult<List<AdressDto>> GetAll();
        IDataResult<List<AdressDto>> GetAllByLanguage(string culture);
        IDataResult<List<Adress>> GetAllDeleted();
        IDataResult<Adress> GetById(int id);
        IResult SoftDelete(int id);
        IResult HardDelete(int id);
    }
}
