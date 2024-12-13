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
    public class StatisticDal : BaseRepository<Statistic, ApplicationDbContext>, IStatisticDal
    {
        private readonly ApplicationDbContext _context;

        public StatisticDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Statistic> GetAllByLanguage(string culture)
        {
            var data = _context.Statistics
                 .Include(d => d.Language)
                 .Where(d => d.Language.Key == culture)
                 .Where(d => d.Deleted == 0).ToList();
            return data;
        }
    }
}
