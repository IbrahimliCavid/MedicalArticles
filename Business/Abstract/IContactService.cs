using Core.Results.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        IResult Add(ContactCreateDto dto);
        IResult Update(ContactUpdateDto dto);
        IDataResult<List<ContactDto>> GetAll();
        IDataResult<ContactDto> GetById(int id);
        IResult Delete(int id);
    }
}
