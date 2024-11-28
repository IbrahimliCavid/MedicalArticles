using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ServiceDal : BaseRepository<Service, ApplicationDbContext>, IServiceDal
    {
        private readonly ApplicationDbContext _context;

        public ServiceDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceDto> GetServiceWithServiceCategories()
        {
            var result = from service in _context.Services
                         where service.Deleted == 0
                         join category in _context.Categories
                         on service.CategoryId equals category.Id
                         where category.Deleted == 0
                         select new ServiceDto
                         {
                             Id = service.Id,
                             Title = service.Title,
                             CategoryId = service.CategoryId,
                             PhotoUrl = service.PhotoUrl,
                             Description = service.Description,
                             CategoryName = category.Name
                         };

            return result.ToList();

        } 
        
        public List<ServiceDto> GetDeletedServiceWithServiceCategories()
        {
            var result = from service in _context.Services
                         where service.Deleted != 0
                         join category in _context.Categories
                         on service.CategoryId equals category.Id
                         where category.Deleted == 0
                         select new ServiceDto
                         {
                             Id = service.Id,
                             Title = service.Title,
                             CategoryId = service.CategoryId,
                             PhotoUrl = service.PhotoUrl,
                             Description = service.Description,
                             CategoryName = category.Name
                         };

            return result.ToList();



        }
    }
}

