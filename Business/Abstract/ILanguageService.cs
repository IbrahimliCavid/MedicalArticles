using Core.Results.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ILanguageService
    {
        IDataResult<List<Language>> GetAll();
        IDataResult<Language> GetById(int id);
    }
}
