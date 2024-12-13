﻿using Core.DataAccess.Abstract;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IStatisticDal : IBaseRepository<Statistic>
    {
        List<Statistic> GetAllByLanguage(string culture);

    }
}
