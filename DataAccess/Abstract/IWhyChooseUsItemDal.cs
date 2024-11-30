using Core.DataAccess.Abstract;
using Entities.Dtos;
using Entities.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IWhyChooseUsItemDal : IBaseRepository<WhyChooseUsItem>
    {
        public List<WhyChooseUsItemDto> GetWhyUsItem();
        public List<WhyChooseUsItemDto> GetDeletedWhyUsItem();
    }
}
