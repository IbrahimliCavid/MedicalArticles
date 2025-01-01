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
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal
    {
        private readonly ApplicationDbContext _context;

        public BlogDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<Blog> GetAllByLanguage(string culture)
        {
            var data = _context.Blogs
                 .Include(d => d.Language)
                 .Where(d => d.Language.Key == culture)
                 .Where(d => d.Deleted == 0)
                 .Include(b => b.Comments)
                 .ThenInclude(c=>c.Replies).ToList();
            return data;
        }
    }
}
