using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.SqlServerDBContext;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class AdressDal : BaseRepository<Adress, ApplicationDbContext> ,IAdressDal
    {
    }
}
