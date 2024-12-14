using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.Dtos;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class ServiceAboutDal : BaseRepository<ServiceAbout, ApplicationDbContext>, IServiceAboutDal
    {
        private readonly ApplicationDbContext _context;

        public ServiceAboutDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceAboutDto> GetAllServiceWithItems(string culture)
        {
            var result = from service in _context.ServiceAbouts
                         .Include(s => s.Language)
                         .Where(s => s.Language.Key == culture)
                         .Where(s => s.Deleted == 0)
                         join item in _context.ServiceAboutItems
                         on service.Id equals item.ServiceAboutId
                         into serviceAbouItemGroup
                         select new ServiceAboutDto
                         {
                             Id = service.Id,
                             Description = service.Description,
                             Title = service.Title,
                             PhotoUrl = service.PhotoUrl,
                             LanguageId = service.LanguageId,
                             ServiceAboutItems = serviceAbouItemGroup
                             .Where(item => item.Deleted == 0)
                             .Select(item => new ServiceAboutItem
                             {
                                 Id = item.Id,
                                 Text = item.Text
                             }).ToList()
                         };
            return result.ToList();
        }
    }
}
