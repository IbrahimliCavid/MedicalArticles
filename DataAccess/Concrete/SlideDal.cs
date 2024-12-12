using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class SlideDal : BaseRepository<Slide, ApplicationDbContext>, ISlideDal
    {
        private readonly ApplicationDbContext _context;

        public SlideDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Slide> GetAllByLanguage(string culture)
        {
           var data = _context.Slides
                .Include(d => d.Language)
                .Where(d => d.Language.Key == culture)
                .Where(d=>d.Deleted == 0).ToList();
            return data;
        }
    }
}
