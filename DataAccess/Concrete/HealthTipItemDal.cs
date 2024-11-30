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
    public class HealthTipItemDal : BaseRepository<HealthTipItem, ApplicationDbContext>, IHealthTipItemDal
    {
        private ApplicationDbContext _context;

        public HealthTipItemDal(ApplicationDbContext context)
        {
            _context = context;
        }

     
        public List<HealthTipItemDto> GetAllJoin()
        {
            var  result = from healthTipItem in _context.HealthTipItems
                         where healthTipItem.Deleted == 0
                         join healthTip in _context.HealthTips
                         on healthTipItem.HealthTipId equals healthTip.Id
                         where healthTip.Deleted == 0
                         select new HealthTipItemDto { 
                             Text = healthTipItem.Text,
                             Name = healthTip.Name,
                             Surname = healthTip.Surname,
                             Header = healthTip.Header,
                             Title = healthTip.Title,
                             Description = healthTip.Description,
                             SubTitle = healthTip.SubTitle,
                             PhotoUrl = healthTip.PhotoUrl,
                             HealthTipId = healthTip.Id
                         };

            return result.ToList();

        }

        public List<HealthTipItemDto> GetDeleteAllJoin()
        {
            var result = from healthTipItem in _context.HealthTipItems
                         where healthTipItem.Deleted != 0
                         join healthTip in _context.HealthTips
                         on healthTipItem.HealthTipId equals healthTip.Id
                         where healthTip.Deleted == 0
                         select new HealthTipItemDto
                         {
                             Text = healthTipItem.Text,
                             Name = healthTip.Name,
                             Surname = healthTip.Surname,
                             Header = healthTip.Header,
                             Title = healthTip.Title,
                             Description = healthTip.Description,
                             SubTitle = healthTip.SubTitle,
                             PhotoUrl = healthTip.PhotoUrl,
                             HealthTipId = healthTip.Id
                         };

            return result.ToList() ;


        }
    }
}
