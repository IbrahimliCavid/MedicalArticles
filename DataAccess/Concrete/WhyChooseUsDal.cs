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
    public class WhyChooseUsDal : BaseRepository<WhyChooseUs, ApplicationDbContext>, IWhyChooseUsDal
    {
        private readonly ApplicationDbContext _context;

        public WhyChooseUsDal(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<WhyChooseUsDto> GetAllWhyUsWithItems(string culture)
        {
            var result = from whyUs in _context.WhyChooseUses
                         .Include(s => s.Language)
                         .Where(s => s.Language.Key == culture)
                         .Where(s => s.Deleted == 0)
                         join item in _context.WhyChooseUsItems
                         on whyUs.Id equals item.WhyChooseUsId
                         into whyUsItemGroup
                         select new WhyChooseUsDto
                         {
                             Id = whyUs.Id,
                             Header = whyUs.Header,
                             PhotoUrl = whyUs.PhotoUrl,
                             LanguageId = whyUs.LanguageId,
                             WhyChooseUsItems = whyUsItemGroup
                             .Where(item => item.Deleted == 0)
                             .Select(item => new WhyChooseUsItem
                             {
                                 Id = item.Id,
                                 Title = item.Title,
                                 Description = item.Description,
                             }).ToList()
                         };
            return result.ToList();
        }
    }
}
