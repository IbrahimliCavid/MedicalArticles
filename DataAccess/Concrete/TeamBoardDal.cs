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
    public class TeamBoardDal : BaseRepository<TeamBoard, ApplicationDbContext>, ITeamBoardDal
    {
        private readonly ApplicationDbContext _context;

        public TeamBoardDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<TeamBoard> GetAllByLanguage(string culture = "az-Latn")
        {
            var data = _context.TeamBoards
                 .Include(d => d.Language)
                 .Where(d => d.Language.Key == culture)
                 .Where(d => d.Deleted == 0).ToList();
            return  data;
        }
    }
}
