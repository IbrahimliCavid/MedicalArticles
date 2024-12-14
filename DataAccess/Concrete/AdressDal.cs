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
    public class AdressDal : BaseRepository<Adress, ApplicationDbContext> ,IAdressDal
    {
        private readonly ApplicationDbContext _context;

        public AdressDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Adress> GetAllByLanguage(string culture)
        {
            var data = _context.Adresses
                 .Include(d => d.Language)
                 .Where(d => d.Language.Key == culture)
                 .Where(d => d.Deleted == 0).ToList();
            return data;
        }
    }
}
