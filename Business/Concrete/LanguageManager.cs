using Business.Abstract;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LanguageManager : ILanguageService
    {
        private readonly ILanguageDal _languageDal;

        public LanguageManager(ILanguageDal languageDal)
        {
            _languageDal = languageDal;
        }

        public IDataResult<List<Language>> GetAll()
        {
            List<Language> data = _languageDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<Language>>(data);
        }

        public IDataResult<Language> GetById(int id)
        {
            Language data = _languageDal.GetById(id);
            return new SuccessDataResult<Language>(data);
        }
    }
}
