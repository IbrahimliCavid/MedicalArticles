﻿using Core.Results.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IServiceService
    {
        IResult Add(ServiceCreateDto dto, IFormFile photoUrl, string webRootPath);
        IResult Update(ServiceUpdateDto dto, IFormFile photoUrl, string webRootPath);
        IDataResult<List<ServiceDto>> GetAll();
        IDataResult<List<ServiceDto>> GetAllDeleted();
        IDataResult<List<ServiceDto>> GetServiceWithServiceCategoryId();
        IDataResult<ServiceDto> GetById(int id);
        IResult SoftDelete(int id); 
        IResult HardDelete(int id); 
        IResult Restore(int id);
    }
}
