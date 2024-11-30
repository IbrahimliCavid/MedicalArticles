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
    public class ServiceAboutItemDal : BaseRepository<ServiceAboutItem, ApplicationDbContext>, IServiceAboutItemDal
    {
        private readonly ApplicationDbContext _context;

        public ServiceAboutItemDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServiceAboutItemDto> GetServiceAboutItem()
        {
            var result = from aboutItem in _context.ServiceAboutItems
                         where aboutItem.Deleted == 0
                         join serviceAbout in _context.ServiceAbouts
                         on aboutItem.ServiceAboutId equals serviceAbout.Id
                         where serviceAbout.Deleted == 0
                         select new ServiceAboutItemDto
                         {
                             Id = aboutItem.Id,
                             Text = aboutItem.Text,
                             ServiceAboutId = aboutItem.ServiceAboutId,
                             Title = serviceAbout.Title,
                             Description = serviceAbout.Description,
                             PhotoUrl = serviceAbout.PhotoUrl,
                         };

            return result.ToList();

        }

        public List<ServiceAboutItemDto> GetDeletedServiceAboutItem()
        {
           var result = from aboutItem in _context.ServiceAboutItems
                         where aboutItem.Deleted != 0
                         join serviceAbout in _context.ServiceAbouts
                         on aboutItem.ServiceAboutId equals serviceAbout.Id
                         where serviceAbout.Deleted == 0
                         select new ServiceAboutItemDto
                         {
                             Id = aboutItem.Id,
                             Text = aboutItem.Text,
                             ServiceAboutId = aboutItem.ServiceAboutId,
                             Title = serviceAbout.Title,
                             Description = serviceAbout.Description,
                             PhotoUrl = serviceAbout.PhotoUrl,
                         };

            return result.ToList();



        }
    }
}
