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
    public class HealthTipDal : BaseRepository<HealthTip, ApplicationDbContext>, IHealthTipDal
    {
        private readonly ApplicationDbContext _context;

        public HealthTipDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<HealthTipDto> GetAllHealthTipWithItems(string culture)
        {
            var result = from tip in _context.HealthTips
                         .Include(t => t.Language)
                         .Where(t => t.Language.Key == culture)
                         .Where(t => t.Deleted == 0)
                         join item in _context.HealthTipItems
                         on tip.Id equals item.HealthTipId
                         into healthTipItemGroup
                         select new HealthTipDto
                         {
                             Id = tip.Id,
                             Name = tip.Name,
                             Surname = tip.Surname,
                             Header = tip.Header,
                             Title = tip.Title,
                             Description = tip.Description,
                             SubTitle = tip.SubTitle,
                             PhotoUrl = tip.PhotoUrl,
                             LanguageId = tip.LanguageId,
                             HealthTipItems = healthTipItemGroup
                             .Where(item => item.Deleted == 0)
                             .Select(item => new HealthTipItem
                             {
                                 Id = item.Id,
                                 Text = item.Text
                             }).ToList()
                         };
            return result.ToList();
        }
    }
}
