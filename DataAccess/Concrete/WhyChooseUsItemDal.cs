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
    public class WhyChooseUsItemDal : BaseRepository<WhyChooseUsItem, ApplicationDbContext>, IWhyChooseUsItemDal
    {
        private readonly ApplicationDbContext _context;

        public WhyChooseUsItemDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<WhyChooseUsItemDto> GetWhyUsItem()
        {
            var result = from usItem in _context.WhyChooseUsItems
                         where usItem.Deleted == 0
                         join us in _context.WhyChooseUses
                         on usItem.WhyChooseUsId equals us.Id
                         where us.Deleted == 0
                         select new WhyChooseUsItemDto
                         {
                             Id = usItem.Id,
                             Title = usItem.Title,
                             Description = usItem.Description,
                             WhyChooseUsId = usItem.WhyChooseUsId,
                             Header = us.Header,
                             PhotoUrl = us.PhotoUrl,
                         };

            return result.ToList();

        }

        public List<WhyChooseUsItemDto> GetDeletedWhyUsItem()
        {
            var result = from usItem in _context.WhyChooseUsItems
                         where usItem.Deleted != 0
                         join us in _context.WhyChooseUses
                         on usItem.WhyChooseUsId equals us.Id
                         where us.Deleted == 0
                         select new WhyChooseUsItemDto
                         {
                             Id = usItem.Id,
                             Title = usItem.Title,
                             Description = usItem.Description,
                             WhyChooseUsId = usItem.WhyChooseUsId,
                             Header = us.Header,
                             PhotoUrl = us.PhotoUrl,
                         };

            return result.ToList();

        }

    }
}
