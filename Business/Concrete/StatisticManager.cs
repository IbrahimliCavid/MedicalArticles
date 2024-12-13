using Business.Abstract;
using Business.BaseMessages;
using Business.Mapper;
using Core.Extension;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class StatisticManager : IStatisticService
    {
        private readonly IStatisticDal _statisticDal;
        private readonly IValidator<Statistic> _validator;

        public StatisticManager(IStatisticDal statisticDal, IValidator<Statistic> validator)
        {
            _statisticDal = statisticDal;
            _validator = validator;
        }

        public IResult Add(StatisticCreateDto dto)
        {
            Statistic model = StatisticMapper.ToModel(dto);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            _statisticDal.Add(model);

            return new SuccessResult(UiMessages.SuccessAddedMessage(model.Name));
        }

        public IDataResult<List<StatisticDto>> GetAll()
        {
            var data = _statisticDal.GetAll(x => x.Deleted == 0);
            return new SuccessDataResult<List<StatisticDto>>(StatisticMapper.ToDto(data));
        }
         public IDataResult<List<StatisticDto>> GetAllByLanguage(string culture)
        {
            var data = _statisticDal.GetAllByLanguage(culture);
            return new SuccessDataResult<List<StatisticDto>>(StatisticMapper.ToDto(data));
        }

        public IDataResult<List<StatisticDto>> GetAllDeleted()
        {
            var data = _statisticDal.GetAll(x => x.Deleted != 0);
            return new SuccessDataResult<List<StatisticDto>>(StatisticMapper.ToDto(data));
        }
       

        public IDataResult<StatisticDto> GetById(int id)
        {
            var data = _statisticDal.GetById(id);
            return new SuccessDataResult<StatisticDto>(StatisticMapper.ToDto(data));
        }

        public IResult HardDelete(int id)
        {
            var data = GetById(id).Data;
            _statisticDal.Delete(StatisticMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessDeletedMessage(data.Name));
        }

        public IResult Restore(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = 0;
            _statisticDal.Update(StatisticMapper.ToModel(data));
            return new SuccessResult();
        }

        public IResult SoftDelete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;
            _statisticDal.Update(StatisticMapper.ToModel(data));

            return new SuccessResult(UiMessages.SuccessCopyTrashMessage(data.Name));
        }

        public IResult Update(StatisticUpdateDto dto)
        {
            Statistic model = StatisticMapper.ToModel(dto);
            Statistic existData =StatisticMapper.ToModel( GetById(model.Id).Data);
            var validator = _validator.Validate(model);

            string errorMessage = "";

            foreach (var error in validator.Errors)
            {
                errorMessage = error.ErrorMessage;
            }

            if (!validator.IsValid)
            {
                return new ErrorResult(errorMessage);
            }

            model.UpdatedDate = DateTime.Now;
            _statisticDal.Update(model);

            return new SuccessResult(UiMessages.SuccessUpdatedMessage(model.Name));

        }

       
    }
}
